using AutoMapper;
using Core.Common;
using Core.Models;
using Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                cfg.CreateMap<UserProfileViewModel, ApplicationUser>();
                cfg.CreateMap<AddBookViewModel, Book>()
                    .ForMember(d => d.Status, opt => opt.MapFrom(s => BookStatus.New))
                    .ForMember(d => d.Comments, opt => opt.MapFrom(s => new List<Comment>()))
                    .ForMember(d => d.RatingMarks, opt => opt.MapFrom(s => new List<int>()));
                cfg.CreateMap<Book, AuthorBookViewModel>();
                cfg.CreateMap<Book, ModeratorBookViewModel>()
                    .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Users.FirstOrDefault(u => u.Status == UserStatus.Author)));
                cfg.CreateMap<Comment, ModeratorCommentViewModel>();
                cfg.CreateMap<Book, PopularBookViewModel>();
                cfg.CreateMap<Book, BookViewModel>()
                    .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Users.FirstOrDefault(u => u.Status == UserStatus.Author)));
                cfg.CreateMap<CommentViewModel, Comment>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<ApplicationUser, AdminUserProfileViewModel>();
                cfg.CreateMap<ApplicationUser, ReaderModeratorProfileViewModel>();
                cfg.CreateMap<Book, ModeratorBookPreviewViewModel>()
                    .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Users.FirstOrDefault(u => u.Status == UserStatus.Author)));
                cfg.CreateMap<ApplicationUser, AuthorModeratorProfileViewModel>();
                cfg.CreateMap<Book, SearchBookViewModel>()
                    .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Users.FirstOrDefault(u => u.Status == UserStatus.Author)));
            });
        }
    }
}
