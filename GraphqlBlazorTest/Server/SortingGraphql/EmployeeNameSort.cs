using GraphqlBlazorTest.Shared;
using HotChocolate.Data.Sorting;

namespace GraphqlBlazorTest.Server.SortingGraphql;

public class EmployeeNameSort: SortInputType<Employee>
{
    protected override void Configure(ISortInputTypeDescriptor<Employee> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(f => f.FullName).Name("custom_name");
    }
}

