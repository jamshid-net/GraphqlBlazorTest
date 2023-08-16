using GraphqlBlazorTest.Shared;
using HotChocolate.Data.Filters;

namespace GraphqlBlazorTest.Server.FilterGraphql;

public class FilterEmployeeByFullName:FilterInputType<Employee>
{
    protected override void Configure(
        IFilterInputTypeDescriptor<Employee> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(f => f.FullName).Name("custom_name");
    }
}


