using AutoMapper;
using Stocking.Domain.AggregatesModel;
using StockingAPI.Presentation.Models.Articles.Requests;
using StockingAPI.Presentation.Models.Articles.Responses;

namespace StockingAPI.Presentation.Profiles
{
    public class ConfigProfile : Profile
    {
        public ConfigProfile()
        {
            CreateMap<Article, ArticlesDTO>()
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.HT))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TVA, opt => opt.MapFrom(src => src.TVA))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ReverseMap();
            CreateMap<Article, CreateArticlesDTO>()
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.HT))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.IsTakeAway, opt => opt.MapFrom(src => src.IsTakeAway))
                
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ReverseMap();
            CreateMap<Article, ArticleResponse>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HT, opt => opt.MapFrom(src => src.HT))
                .ForMember(dest => dest.TTC, opt => opt.MapFrom(src => src.TTC))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TVA, opt => opt.MapFrom(src => src.TVA))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.IsTakeAway, opt => opt.MapFrom(src => src.IsTakeAway))
                .ReverseMap();
            CreateMap<Article, UpdateArticlesDTO>().ReverseMap()               
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HT, opt => opt.MapFrom(src => src.HT))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TVA, opt => opt.MapFrom(src => src.TVA))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ReverseMap();
        }
    }
}
