using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RommelkoningenApi.Data;
using RommelkoningenApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RommelkoningenApi.Controllers
{
    [ApiController]
    [Route("TrashdataSensoring")]
    public class SensoringTrashdataController : ControllerBase
    {
        private readonly AfvalDbContext _context;
        public SensoringTrashdataController(AfvalDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "CreateTrashdata")]
        public async Task<ActionResult> Add([FromBody] FotoDataMetAfvalDataDto fotoDto)
        {
            float latitude = 51.591475f;
            float longitude = 4.780472f;

            string externalApiKey = "93b3c797bb8bc4b7eb2ce75c4a130423"; 
            string url = $" http://api.weatherstack.com/current?access_key={externalApiKey}&query={latitude},{longitude}";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Weather API call failed");



            var json = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(json);

            var fotoData = new FotoData
            {
                Foto_Id = Guid.NewGuid(),
                Datum_En_Tijd = DateTime.UtcNow,
                Camera_Naam = "Cam 1",
                Longitude = longitude,
                Latitude = latitude,
                Postcode = "4811 ET",
                Windrichting = weatherData.current.wind_dir,
                Temperatuur = weatherData.current.temperature,
                Weer_Omschrijving = weatherData.current.weather_descriptions.FirstOrDefault()
            };

            _context.FotoData.Add(fotoData);

            var afvalDatas = fotoDto.AfvalData.Select(a => new AfvalData
            {
                Afval_Id = Guid.NewGuid(),
                Foto_Id = fotoData.Foto_Id,
                Afval_Type = a.Afval_Type,
                Confidence = a.Confidence
            }).ToList();

            _context.AfvalData.AddRange(afvalDatas);
            await _context.SaveChangesAsync();


            return Created();
        }
    }
}
