using AutoMapper;
using ChoseYourDrink.BLL.BusinessObjects;
using ChoseYourDrink.Models;

namespace ChoseYourDrink.MapperProfiles
{
    public class DrinkItemMapperProfile : Profile
    {
        public DrinkItemMapperProfile()
        {
            CreateMap<DrinkItemBO, DrinkItemViewModel>();
            CreateMap<DrinkItemViewModel, DrinkItemBO>();
        }
    }
}
