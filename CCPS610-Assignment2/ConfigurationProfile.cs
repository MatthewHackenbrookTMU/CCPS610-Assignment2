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
        }
    }
}
