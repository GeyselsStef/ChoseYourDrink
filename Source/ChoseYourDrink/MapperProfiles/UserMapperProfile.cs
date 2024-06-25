using AutoMapper;
using ChoseYourDrink.BLL.BusinessObjects;
using ChoseYourDrink.Models;

namespace ChoseYourDrink.MapperProfiles
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
