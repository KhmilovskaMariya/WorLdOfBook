using AutoMapper;
using Core.Models;
using Core.ViewModels;

namespace Utils
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<ReaderModeratorViewModel, ApplicationUser>()
                .ForMember();
        }
    }
}
