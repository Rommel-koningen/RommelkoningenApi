using RommelkoningenApi.Models;

namespace RommelkoningenApi.Repositories
{
    public interface IAfvalDataRepository
    {
        Task<AfvalData> InsertAsync(AfvalData afvalData);
    }
}