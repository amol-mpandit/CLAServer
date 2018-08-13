using AutoMapper;
using CLAServer.Mappers;
using StructureMap;

namespace CLAServer.DependencyResolution
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<StudentMapperProfile>();
                cfg.AddProfile<ClassesMapperProfile>();
                cfg.AddProfile<FacultyMapperProfile>();
                cfg.AddProfile<SubjectMapperProfile>();
                cfg.AddProfile<TimeTableProfiler>();
                cfg.AddProfile<AttendanceProfiler>();
            });
        }
    }
}