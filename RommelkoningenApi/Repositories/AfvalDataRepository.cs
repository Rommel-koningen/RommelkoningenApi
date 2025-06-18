using Dapper;
using Microsoft.Data.SqlClient;
using RommelkoningenApi.Models;

namespace RommelkoningenApi.Repositories
{
    public class AfvalDataRepository
    {
        private readonly string connectionString;

        public AfvalDataRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<AfvalData> InsertAsync(AfvalData afvalData)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var environmentId = await sqlConnection.ExecuteAsync("INSERT INTO [AfvalData] (Afval_Id, Foto_Id, Afval_Type, Confidence) VALUES (@Afval_Id, @Foto_Id, @Afval_Type, @Confidence)", afvalData);
                return afvalData;
            }
        }
    }
}
