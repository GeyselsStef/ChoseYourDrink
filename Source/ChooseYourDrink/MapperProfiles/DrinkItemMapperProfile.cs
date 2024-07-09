using AutoMapper;
using ChooseYourDrink.BLL.BusinessObjects;
using ChooseYourDrink.Models;

namespace ChooseYourDrink.MapperProfiles
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
