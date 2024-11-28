using AutoMapper;
using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Application.Automapper
{
    public class MappingProfile : Profile
    {
    }


    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDetailsDto, Movie>().ReverseMap();
            //.ForPath(dest => dest.Category.Name, opt => opt.MapFrom(src => src.category.Name));

            CreateMap<MovieCreateDto, Movie>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
            CreateMap<MovieDeleteDto, Movie>().ReverseMap();
            CreateMap<MovieReviewDto, Movie>().ReverseMap();
        }
    }


    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDetailsDto, Category>().ReverseMap();
            CreateMap<ParentCategoryDto, Category>().ReverseMap();
            CreateMap<SubCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryDeleteDto, Category>().ReverseMap();
        }
    }


    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDetailsDto,Reviews>().ReverseMap();
            CreateMap<ReviewCreateDto, Reviews>().ReverseMap();
            CreateMap<ReviewUpdateDto, Reviews>().ReverseMap();
            CreateMap<ReviewDeleteDto, Reviews>().ReverseMap();
        }
    }



    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            //CreateMap<RoleDetailsDto, Roles>().ReverseMap();
            //CreateMap<RoleCreateDto,  Roles>().ReverseMap();
            //CreateMap<RoleUpdateDto,  Roles>().ReverseMap();
            //CreateMap<RoleDeleteDto,  Roles>().ReverseMap();
        }
    }


    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetailsDto, Users>().ReverseMap();
            CreateMap<UserCreateDto, Users>().ReverseMap();
            CreateMap<UserUpdateDto, Users>().ReverseMap();
            CreateMap<UserDeleteDto, Users>().ReverseMap();
            CreateMap<UserReviewDto, Users>().ReverseMap();
        }
    }



}
