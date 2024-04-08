using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Sach, SachDTO>()
                .ForMember(dest => dest.UrlImage, opt => opt.MapFrom(src => src.TtSaches.FirstOrDefault().UrlImage ?? ""))
                .ForMember(dest => dest.Mota, opt => opt.MapFrom(src => src.TtSaches.FirstOrDefault().Mota ?? ""));
        }
    }
}
