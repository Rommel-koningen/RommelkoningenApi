using RommelkoningenApi.Models;

namespace RommelkoningenApi.Repositories
{
    public interface IFotoDataRepository
    {
        Task<FotoData> InsertAsync(FotoData fotoData);
    }
}