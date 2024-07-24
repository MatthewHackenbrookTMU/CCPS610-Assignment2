using AutoMapper;
using CCPS610_Assignment2.DatabaseContext.Tables;
using CCPS610_Assignment2.Models;

namespace CCPS610_Assignment2
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<HrEmployee, EmployeeModel>();
            CreateMap<EmployeeModel, HrEmployee>();

            CreateMap<JobModel, HrJob>();
            CreateMap<HrJob, JobModel>();

            CreateMap<DepartmentModel, HrDepartment>();
            CreateMap<HrDepartment, DepartmentModel>()
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName));
        }
    }
}
