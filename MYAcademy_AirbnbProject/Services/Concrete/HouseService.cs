using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MYAcademy_AirbnbProject.Dtos.HouseDtos;
using MYAcademy_AirbnbProject.Entities;
using MYAcademy_AirbnbProject.Services.Abstract;
using MYAcademy_AirbnbProject.Settings;

namespace MYAcademy_AirbnbProject.Services.Concrete
{
    public class HouseService : IHouseService
    {
        private readonly IMongoCollection<House> _houseCollection;
        private readonly IMapper _mapper;
        public HouseService(IOptions<MongoDbSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            var stngs = settings.Value;

            var client = new MongoClient(stngs.ConnectionString);
            var database = client.GetDatabase(stngs.DatabaseName);
            _houseCollection = database.GetCollection<House>(stngs.HouseCollectionName);
        }
        public async Task CreateHouseAsync(CreateHouseDto createHouseDto)
        {
            var values = _mapper.Map<House>(createHouseDto);
            await _houseCollection.InsertOneAsync(values);
        }

        public async Task DeleteHouseAsync(string id)
        {
            await _houseCollection.DeleteOneAsync(x => x.HouseId == id);
        }

        public async Task<List<ResultHouseDto>> GetAllHousesAsync()
        {
            var values = await _houseCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultHouseDto>>(values);
        }

        public async Task<GetByIdHouseDto> GetByIdHouseAsync(string id)
        {
            var value = await _houseCollection.Find(x => x.HouseId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdHouseDto>(value);
        }

        public async Task UpdateHouseAsync(UpdateHouseDto updateHouseDto)
        {
            var house = _mapper.Map<House>(updateHouseDto);
            await _houseCollection.ReplaceOneAsync(x => x.HouseId == updateHouseDto.HouseId, house);
        }
    }
}
