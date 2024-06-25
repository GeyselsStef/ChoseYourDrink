using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoseYourDrink.BLL.HttpClients
{
    public class OrderApiHttpClient:HttpClient
    {
        private readonly IConfiguration configuration;

        public OrderApiHttpClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            BaseAddress = new Uri(configuration.GetSection("OrderDrinkUrl").Value);
        }
    }
}
