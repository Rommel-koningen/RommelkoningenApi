using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RommelkoningenApi.Data;
using RommelkoningenApi.Models;

namespace RommelkoningenApi.Controllers
{
    [ApiController]
    [Route("Trashdata")]
    public class MonitoringTrashdataController : ControllerBase
    {
        private readonly AfvalDbContext _context;
        public MonitoringTrashdataController(AfvalDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "AllData")]
        public async Task<ActionResult<IEnumerable<FotoDataMetAfvalDataDto>>> GetCombinedData()
        {
            var fotodatas = await _context.FotoData.ToListAsync();
            var afvaldatas = await _context.AfvalData.ToListAsync();
            var result = fotodatas.Select(foto => new FotoDataMetAfvalDataDto
            {
                Foto_Id = foto.Foto_Id,
                Datum_En_Tijd = foto.Datum_En_Tijd,
                Camera_Naam = foto.Camera_Naam,
                Longitude = foto.Longitude,
                Latitude = foto.Latitude,
                Postcode = foto.Postcode,
                Windrichting = foto.Windrichting,
                Temperatuur = foto.Temperatuur,
                Weer_Omschrijving = foto.Weer_Omschrijving,
                AfvalData = afvaldatas.Where(a => a.Foto_Id == foto.Foto_Id)
                                      .Select(a => new AfvalDataDto
                                      {
                                          Afval_Id = a.Afval_Id,
                                          Afval_Type = a.Afval_Type,
                                          Confidence = a.Confidence
                                      }).ToList()
            }).ToList();
            return Ok(result);
        }

        [HttpGet("AfterDate", Name = "DataAfterDate")]
        public async Task<ActionResult<IEnumerable<FotoDataMetAfvalDataDto>>> GetCombinedDataAfterSpecifiedDate([FromQuery] DateTime Datum_En_Tijd)
        {
            var fotodatas = await _context.FotoData
                .Where(f => f.Datum_En_Tijd >= Datum_En_Tijd)
                .ToListAsync();

            var afvaldatas = await _context.AfvalData.ToListAsync();

            var result = fotodatas.Select(foto => new FotoDataMetAfvalDataDto
            {
                Foto_Id = foto.Foto_Id,
                Datum_En_Tijd = foto.Datum_En_Tijd,
                Camera_Naam = foto.Camera_Naam,
                Longitude = foto.Longitude,
                Latitude = foto.Latitude,
                Postcode = foto.Postcode,
                Windrichting = foto.Windrichting,
                Temperatuur = foto.Temperatuur,
                Weer_Omschrijving = foto.Weer_Omschrijving,
                AfvalData = afvaldatas
                    .Where(a => a.Foto_Id == foto.Foto_Id)
                    .Select(a => new AfvalDataDto
                    {
                        Afval_Id = a.Afval_Id,
                        Afval_Type = a.Afval_Type,
                        Confidence = a.Confidence
                    }).ToList()
            }).ToList();

            return Ok(result);
        }
    }
}
