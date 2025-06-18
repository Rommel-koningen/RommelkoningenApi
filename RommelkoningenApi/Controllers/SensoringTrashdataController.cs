using System;
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
            var fotoData = new FotoData
            {
                Foto_Id = Guid.NewGuid(),
                Datum_En_Tijd = DateTime.UtcNow,
                Camera_Naam = fotoDto.Camera_Naam,
                Longitude = fotoDto.Longitude,
                Latitude = fotoDto.Latitude,
                Postcode = fotoDto.Postcode,
                Windrichting = fotoDto.Windrichting,
                Temperatuur = fotoDto.Temperatuur,
                Weer_Omschrijving = fotoDto.Weer_Omschrijving
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
