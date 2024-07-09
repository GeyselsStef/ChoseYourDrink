using AutoMapper;
using ChooseYourDrink.BLL.BusinessObjects;
using ChooseYourDrink.Models;

namespace ChooseYourDrink.MapperProfiles
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
