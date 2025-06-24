using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RommelkoningenApi.Controllers;
using RommelkoningenApi.Data;
using RommelkoningenApi.Models;

namespace RommelkoningenUnittests;

[TestClass]
public class CreateTrashDataEndpointTest
{
    [TestMethod]
    public async Task TestMethod1()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AfvalDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new AfvalDbContext(options);

        var controller = new SensoringTrashdataController(context);

        var inputDto = new FotoDataMetAfvalDataDto
        {
            Camera_Naam = "Cam 1",
            Postcode = "4811 ET",
            AfvalData = new List<AfvalDataDto>
        {
            new AfvalDataDto
            {
                Afval_Type = "Plastic"
            }
        }
        };

        // Act
        var result = await controller.Add(inputDto);

        // Assert
        var createdResult = Xunit.Assert.IsType<CreatedResult>(result);

        // Verify FotoData was saved
        var fotoData = context.FotoData.FirstOrDefault();
        Xunit.Assert.NotNull(fotoData);
        Xunit.Assert.Equal("Cam 1", fotoData.Camera_Naam);
        Xunit.Assert.Equal("4811 ET", fotoData.Postcode);

        // Verify AfvalData was saved and linked
        var afvalData = context.AfvalData.FirstOrDefault();
        Xunit.Assert.NotNull(afvalData);
        Xunit.Assert.Equal("Plastic", afvalData.Afval_Type);
        Xunit.Assert.Equal(fotoData.Foto_Id, afvalData.Foto_Id);
    }
}
