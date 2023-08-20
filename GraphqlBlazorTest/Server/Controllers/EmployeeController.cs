using GraphqlBlazorTest.Server.Data;
using GraphqlBlazorTest.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphqlBlazorTest.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("getall")]
    public async ValueTask<List<Employee>> GetEmployees()
    {
        var result = await _context.Employees.AsNoTracking().ToListAsync();
        return result;
    }
}
