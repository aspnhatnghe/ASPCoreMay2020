using AutoMapper;

namespace Buoi10_Layout.Models
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            //khai báo Map
            CreateMap<ProductModel, Product>()
                .ReverseMap();//map 2 chiều
        }
    }
}
