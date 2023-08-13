using AutoMapper;
using GraphqlBlazorTest.Shared;

namespace GraphqlBlazorTest.Server.Mapping;

public class EmployeeMapping:Profile
{
    public EmployeeMapping()
    {
        CreateMap<EmployeeDto, Employee>().ReverseMap();
    }
}
