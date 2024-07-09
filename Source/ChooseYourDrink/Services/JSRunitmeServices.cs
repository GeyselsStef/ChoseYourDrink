using Microsoft.JSInterop;

namespace ChooseYourDrink.Services
{
    public interface IJSRunitmeServices
    {
        Task<T> GetItemAsync<T>(string key);
        Task RemoveItem(string key);
        Task SetItemAsync<T>(string key, T value);
    }

    public class JSRunitmeServices : IJSRunitmeServices
    {
        private readonly IJSRuntime _jSRunitme;

        public JSRunitmeServices(IJSRuntime jSRunitmeServices)
        {
            _jSRunitme = jSRunitmeServices;
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            if (value == null)
            {
                await RemoveItem(key);
                return;
            }
            else if (value.GetType().IsClass)
            {
                string json = System.Text.Json.JsonSerializer.Serialize(value);
                await _jSRunitme.InvokeVoidAsync("localStorage.setItem", key, json);
                return;
            }

            await _jSRunitme.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            try
            {
                if (typeof(T).IsClass) {                  
                    string json = await _jSRunitme.InvokeAsync<string>("localStorage.getItem", key);
                    return  System.Text.Json.JsonSerializer.Deserialize<T>(json);
                }

               return await _jSRunitme.InvokeAsync<T>("localStorage.getItem", key);

            }
            catch (Exception ex)
            {
                var f = ex.Message;
            }
            return default;
        }

        public async Task RemoveItem(string key)
        {
            await _jSRunitme.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
