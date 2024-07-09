using AutoMapper;
using ChooseYourDrink.BLL.BusinessObjects;
using ChooseYourDrink.Models;

namespace ChooseYourDrink.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserBO, UserViewModel>();
            CreateMap<UserViewModel, UserBO>();
        }
    }
}
