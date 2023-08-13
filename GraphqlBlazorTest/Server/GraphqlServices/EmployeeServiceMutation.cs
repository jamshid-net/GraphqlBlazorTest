using AutoMapper;
using GraphqlBlazorTest.Server.Data;
using GraphqlBlazorTest.Shared;

namespace GraphqlBlazorTest.Server.GraphqlServices;

public class EmployeeServiceMutation
{
    public async ValueTask<bool> DeleteEmployee([Service] ApplicationDbContext context, Guid Id)
    {
        var foundemp = await context.Employees.FindAsync(new object[] { Id });
        if (foundemp is not null)
        {
            context.Remove(foundemp);

        }
        return await context.SaveChangesAsync() > 0;
    }

    public async ValueTask<Employee> GetEmployeeById([Service] ApplicationDbContext context, Guid Id)
    {
        var foundemp = await context.Employees.FindAsync(new object[] { Id });
        if (foundemp is null)
            return new Employee();

        return foundemp;

    }

    public async ValueTask<bool> CreateEmployee
        ([Service] ApplicationDbContext context, [Service] IMapper mapper, EmployeeDto employee)
    {

        var mappedEmployee = mapper.Map<Employee>(employee);
        await context.Employees.AddAsync(mappedEmployee);

        return await context.SaveChangesAsync() > 0;

    }
}
