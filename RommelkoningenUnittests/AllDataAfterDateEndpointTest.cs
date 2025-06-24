using Moq;
using Xunit;
using RommelkoningenApi.Repositories;
using RommelkoningenApi.Controllers;
using RommelkoningenApi.Models;
using RommelkoningenApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RommelkoningenUnittests
{
    [TestClass]
    public class AllDataAfterDateEndpointTest
    {
        
        [TestMethod]
        public async Task AllDataAfterDateShouldReturn1RecordWithDateAftertestDate()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AfvalDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new AfvalDbContext(options);

            var testDate = new DateTime(2024, 02, 01);

            context.FotoData.AddRange(
                new FotoData {
                    Datum_En_Tijd = new DateTime(2024, 02, 05),
                    Camera_Naam = "Camera1",
                    Postcode = "1234AB"
                },
                new FotoData {
                    Datum_En_Tijd = new DateTime(2023, 12, 31),
                    Camera_Naam = "Camera2",
                    Postcode = "5678CD"
                }
            );

            

            await context.SaveChangesAsync();

            var controller = new MonitoringTrashdataController(context);

            // Act
            var result = await controller.GetCombinedDataAfterSpecifiedDate(testDate);
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Xunit.Assert.IsAssignableFrom<IEnumerable<FotoDataMetAfvalDataDto>>(okResult.Value);

            // Assert
            Xunit.Assert.Single(returnValue);
            Xunit.Assert.Equal(new DateTime(2024, 02, 05), returnValue.First().Datum_En_Tijd);
        }
        
    }
}
