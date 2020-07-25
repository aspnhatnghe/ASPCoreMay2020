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
        }
    }
}
