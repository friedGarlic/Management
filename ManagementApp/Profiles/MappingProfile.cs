using AutoMapper;
using Management;
using Management.Application.DTOs.DataType.Process;
using Management.Application.DTOs.LeaveAllocation.Process;

namespace ManagementApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataType, DataTypeDTO>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveAllocationDTO>().ReverseMap();
        }
    }
}
