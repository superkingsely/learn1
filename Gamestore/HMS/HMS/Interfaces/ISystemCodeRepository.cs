using HMS.Models;

namespace HMS.Interfaces
{
    public interface ISystemCodeRepository
    {
        Task<List<SystemCode>> GetSystemCodesAsync();
        Task<SystemCode> GetSystemCodeByIdAsync(int id);
        Task<List<SystemCodeDetail>> GetSystemCodeDetailsAsync(int systemCodeId);
        Task<SystemCode> AddSystemCodeAsync(SystemCode systemCode);
        Task<SystemCode> UpdateSystemCodeAsync(SystemCode systemCode);
        Task<SystemCode> DeleteSystemCodeAsync(int id);
    }
}
