using AutoMapper;
using Bogus;
using GraphqlBlazorTest.Server.Data;
using GraphqlBlazorTest.Server.FilterGraphql;
using GraphqlBlazorTest.Server.SortingGraphql;
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
    [UseOffsetPaging(IncludeTotalCount = true)]
    public async ValueTask<List<Employee>> PaginatedEmployees([Service] ApplicationDbContext context)
    {
        var result = await context.Employees.AsNoTracking().ToListAsync();
        return result;
    }
    [UseOffsetPaging(IncludeTotalCount = true)]
    [UseFiltering]
    public async ValueTask<List<Employee>> PaginatedWithFilterEmployees([Service] ApplicationDbContext context)
    {
        var result = await context.Employees.AsNoTracking().ToListAsync();
        return result;
    }



    public async ValueTask<bool> GenerateUsers([Service] ApplicationDbContext context)
    {
        Faker faker = new();
        Employee employee = new Employee(); 

        for (int i = 0; i < 50; i++)
        {
            employee.Id =Guid.NewGuid();
            employee.FullName = faker.Name.FullName();
            employee.UserName = faker.Internet.UserName();
            employee.BirhDate = faker.Date.BetweenDateOnly(new DateOnly(1950,1,1),new DateOnly(2020,1,1));
            employee.Job = faker.Name.JobTitle();
            employee.Picture = faker.Image.Abstract();
            employee.Password = "123456";
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }
        return true;
    }
   
}
