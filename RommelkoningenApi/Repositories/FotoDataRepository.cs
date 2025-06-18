using Dapper;
using Microsoft.Data.SqlClient;
using RommelkoningenApi.Models;

namespace RommelkoningenApi.Repositories
{
    public class FotoDataRepository
    {
        private readonly string connectionString;

        public FotoDataRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<FotoData> InsertAsync(FotoData fotoData)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var environmentId = await sqlConnection.ExecuteAsync("INSERT INTO [FotoData] (Foto_Id, Datum_En_Tijd, Camera_Naam, Longitude, Latitude, Postcode, Windrichting, Temperatuur, Weer_Omschrijving) VALUES (@Foto_Id, @Datum_En_Tijd, @Camera_Naam, @Longitude, @Latitude, @Postcode, @Windrichting, @Temperatuur, @Weer_Omschrijving)", fotoData);
                return fotoData;
            }
        }
    }
}
