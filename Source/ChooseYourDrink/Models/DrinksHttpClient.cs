namespace ChooseYourDrink.Models
{
    public class DrinksHttpClient: HttpClient
    {
        public DrinksHttpClient()
        {
            BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        }
    }
}
