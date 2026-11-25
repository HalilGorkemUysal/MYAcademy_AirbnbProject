using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MYAcademy_AirbnbProject.Dtos.CategoryDtos;
using MYAcademy_AirbnbProject.Dtos.HouseDtos;
using MYAcademy_AirbnbProject.Entities;
using MYAcademy_AirbnbProject.Services.Abstract;
using MYAcademy_AirbnbProject.Settings;

namespace MYAcademy_AirbnbProject.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IOptions<MongoDbSettings> settings, IMapper mapper)
        {
            _mapper = mapper;
            var stngs = settings.Value;

            var client = new MongoClient(stngs.ConnectionString);
            var db = client.GetDatabase(stngs.DatabaseName);
            _categoryCollection = db.GetCollection<Category>(stngs.CategoryCollectionName);
            
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();   
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.ReplaceOneAsync(x => x.CategoryId == updateCategoryDto.CategoryId, category);
        }
    }
}
