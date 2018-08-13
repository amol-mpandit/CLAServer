
using AutoMapper;
using CLAServer.Models;
using Core;

namespace CLAServer.Mappers
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}