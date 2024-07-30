using GPB.Application.Dtos.EntryExitDto;

namespace GPB.Application.Services.EntryExitServices
{
    public interface IEntryExitServices
    {
        Task CreateEntryExitAsync(CreateEntryExitDto model);
        Task<GetByIdEntryExitDto> GetEntryExitByIdAsync(int entryexitId);
        Task<List<ResultEntryExitDto>> GetAllEntryExitAsync();
        Task UpdateEntryExitAsync(UpdateEntryExitDto model);
        Task DeleteEntryExitAsync(int entryexitId);
    }
}