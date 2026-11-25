using MYAcademy_AirbnbProject.Dtos.HouseDtos;

namespace MYAcademy_AirbnbProject.Services.Abstract
{
    public interface IHouseService
    {
        Task<List<ResultHouseDto>> GetAllHousesAsync();
        Task<GetByIdHouseDto> GetByIdHouseAsync(string id);
        Task CreateHouseAsync(CreateHouseDto createHouseDto);
        Task DeleteHouseAsync(string id);
        Task UpdateHouseAsync(UpdateHouseDto updateHouseDto);
    }
}
