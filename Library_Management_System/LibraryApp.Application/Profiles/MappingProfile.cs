using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.Application.Dtos.BookDto;
using LibraryApp.Domain;

namespace LibraryApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, GetBookDto>()
                        .ForMember(dest => dest.Name,
                                   opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
        }
    }
}
