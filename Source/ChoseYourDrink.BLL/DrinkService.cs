using ChoseYourDrink.BLL.BusinessObjects;
using ChoseYourDrink.BLL.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;

namespace ChoseYourDrink.BLL
{
    public interface IDrinkService
    {
        Task<HttpResponseMessage> OrderDrinkAsync(DrinkItemBO drinkItem, UserBO user, int quantity);
    }

    public class DrinkService : IDrinkService
    {
        private readonly ILogger<DrinkService> _logger;
        private readonly IConfiguration _configuration;
        private readonly OrderApiHttpClient _orderApi;

        protected Dictionary<string, string> ApiEndpoints
        {
            get
            {
                return _configuration.GetSection("ApiEndpoints")
                                     .Get<Dictionary<string, string>>()
                                     .ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            }
        }

        public DrinkService(ILogger<DrinkService> logger, IConfiguration configuration, OrderApiHttpClient orderApi)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._orderApi = orderApi;
        }

        public async Task<HttpResponseMessage> OrderDrinkAsync(DrinkItemBO drinkItem, UserBO user, int quantity)
        {

            try
            {
                DrinkOrderItemBO drinkOrderItem = new()
                {
                    User = user,
                    Drink = drinkItem,
                    Quantity = quantity
                };

                JsonSerializerOptions jsonSerializerOptions = new()
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
                };
                HttpResponseMessage responseMessage = await _orderApi.PostAsJsonAsync(ApiEndpoints["orderDrink"], drinkOrderItem, jsonSerializerOptions);

                return responseMessage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ordering drink");
                throw;
            }



            //try
            //{
            //    var drinkOrderItems = await _jSRunitmeServices.GetItemAsync<List<DrinkOrderItemViewModel>>("drinkOrderItems");
            //    if (drinkOrderItems == null)
            //    {
            //        drinkOrderItems = new List<DrinkOrderItemViewModel>();
            //    }

            //    var existingItem = drinkOrderItems.FirstOrDefault(x => x.Drink.DrinkId == drinkOrderItem.Drink.DrinkId);
            //    if (existingItem != null)
            //    {
            //        existingItem.Quantity += drinkOrderItem.Quantity;
            //    }
            //    else
            //    {
            //        drinkOrderItems.Add(drinkOrderItem);
            //    }

            //    await _jSRunitmeServices.SetItemAsync("drinkOrderItems", drinkOrderItems);
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "Error ordering drink");
            //}
        }

    }
}
