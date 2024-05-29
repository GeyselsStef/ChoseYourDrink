using ChoseYourDrink.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ChoseYourDrink.Services
{
    public interface IDrinkService
    {

        Task<IEnumerable<DrinkCategoryViewModel>> GetCategoriesAsync();

        Task<IEnumerable<DrinkItemViewModel>> GetDrinksByCategoryAsync(DrinkCategoryViewModel category);

        Task<DrinkItemViewModel> GetDrinkDetailsAsync(string drinkItemId);
    }

    public class DrinkService : IDrinkService
    {
        private readonly HttpClient _httpClient;

        public DrinkService(DrinksHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<DrinkCategoryViewModel>> GetCategoriesAsync()
        {
            var options = new JsonSerializerOptions { Converters = { new DrinksCategoryConverter() } };
            var drinkCategories = await _httpClient.GetFromJsonAsync<List<DrinkCategoryViewModel>>("list.php?c=list", options);

            return drinkCategories?? Enumerable.Empty<DrinkCategoryViewModel>();
        }

        public async Task<DrinkItemViewModel> GetDrinkDetailsAsync(string drinkItemId)
        {
            var options = new JsonSerializerOptions { Converters = { new DrinkItemConverter() } };
            var drinkCategories = await _httpClient.GetFromJsonAsync<List<DrinkItemViewModel>>($"lookup.php?i={drinkItemId}", options);

            return drinkCategories?.First() ?? new DrinkItemViewModel() { DrinkId = drinkItemId };
        }

        public async Task<IEnumerable<DrinkItemViewModel>> GetDrinksByCategoryAsync(DrinkCategoryViewModel category)
        {
            var options = new JsonSerializerOptions { Converters = { new DrinkItemConverter() } };
            var drinkCategories = await _httpClient.GetFromJsonAsync<List<DrinkItemViewModel>>($"filter.php?c={category.StrCategory}", options);

            return drinkCategories??Enumerable.Empty<DrinkItemViewModel>();
        }
    }
}
