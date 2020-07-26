using AutoMapper;
using MyProject.DataModels;
using MyProject.ViewModels;

namespace MyProject.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HangHoa, HangHoaViewModel>()
                .ReverseMap();
            CreateMap<HangHoa, CartItem>()
                .ForMember(ci => ci.DonGia, opt => opt.MapFrom(hh => hh.DonGia * (100 -hh.GiamGia)/ 100.0));
        }
    }
}
