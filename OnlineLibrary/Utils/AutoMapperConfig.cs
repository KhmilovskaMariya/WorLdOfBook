using AutoMapper;
using Core.Common;
using Core.Models;
using Core.ViewModels;
using System.Collections.Generic;

namespace Utils
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, ReaderModeratorViewModel>();
                cfg.CreateMap<ApplicationUser, AuthorModeratorViewModel>();
                cfg.CreateMap<ApplicationUser, AdminUserViewModel>();
                cfg.CreateMap<ApplicationUser, UserProfileViewModel>();
                cfg.CreateMap<AddBookViewModel, Book>()
                    .ForMember(d => d.Status, opt => opt.MapFrom(s => BookStatus.New))
                    .ForMember(d => d.Comments, opt => opt.MapFrom(s => new List<Comment>()));
                cfg.CreateMap<Book, AuthorBookViewModel>();
            });
        }
    }
}
