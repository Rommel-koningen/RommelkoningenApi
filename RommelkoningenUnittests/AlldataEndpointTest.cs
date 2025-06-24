using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RommelkoningenApi.Controllers;
using RommelkoningenApi.Data;
using RommelkoningenApi.Models;

namespace RommelkoningenUnittests;

[TestClass]
public class AllDataEndpointTest
{
    [TestMethod]
    public async Task AllDataTestShouldReturnAllRecords()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AfvalDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new AfvalDbContext(options);

        context.FotoData.AddRange(
            new FotoData
            {
                Datum_En_Tijd = new DateTime(2024, 02, 05),
                Camera_Naam = "Camera1",
                Postcode = "1234AB"
            },
            new FotoData
            {
                Datum_En_Tijd = new DateTime(2023, 12, 31),
                Camera_Naam = "Camera2",
                Postcode = "5678CD"
            }
        );

        await context.SaveChangesAsync();

        var controller = new MonitoringTrashdataController(context);

        // Act
        var result = await controller.GetCombinedData();
        var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Xunit.Assert.IsAssignableFrom<IEnumerable<FotoDataMetAfvalDataDto>>(okResult.Value);

        // Assert
        Xunit.Assert.Equal(2, returnValue.Count());

        var returnedIds = returnValue.Select(r => r.Foto_Id).ToList();
    }
}
