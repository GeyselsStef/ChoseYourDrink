using AutoMapper;
using ChoseYourDrink.BLL.BusinessObjects;
using ChoseYourDrink.Models;

namespace ChoseYourDrink.MapperProfiles
{
    public class DrinkOrderItemMapperProfile : Profile
    {
        public DrinkOrderItemMapperProfile()
        {
            CreateMap<DrinkOrderItemBO, DrinkOrderItemViewModel>();
            CreateMap<DrinkOrderItemViewModel, DrinkOrderItemBO>();
        }
    }
}
