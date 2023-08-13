using AutoMapper;
using GraphqlBlazorTest.Server.Data;
using GraphqlBlazorTest.Shared;
using Microsoft.EntityFrameworkCore;

namespace GraphqlBlazorTest.Server.GraphqlServices;

public class EmployeeServiceQuery
{
    
    public async ValueTask<List<Employee>> GetEmployees([Service] ApplicationDbContext context)
    {
        var result = await context.Employees.AsNoTracking().ToListAsync();
        return result;
    }

   
}
