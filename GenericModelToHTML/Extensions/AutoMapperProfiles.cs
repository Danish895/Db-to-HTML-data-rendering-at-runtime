using AutoMapper;
using GenericModelToHTML.Model;

namespace GenericModelToHTML.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Document, DocumentDTO>();
        }
    }
}
