using GraphqlBlazorTest.Server.Data;
using GraphqlBlazorTest.Server.ExelFileGenerator;
using GraphqlBlazorTest.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphqlBlazorTest.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FileTestController : ControllerBase
{
    private readonly ExelFileGenerator<Employee> fileGenerator;
    private readonly ApplicationDbContext context;

    public FileTestController(ApplicationDbContext context, ExelFileGenerator<Employee> fileGenerator)
    {
        this.context = context;
        this.fileGenerator = fileGenerator;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> DownloadFile()
    {
        byte[] filebyte = await System.IO.File.ReadAllBytesAsync(@"D:\JSPresentation.pptx");
        return  File(filebyte, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> DownloadExelOfEmployees()
    {
        List<Employee> employees = await context.Employees.AsNoTracking().ToListAsync();
        var file =  await fileGenerator.Handle(employees, "employees");
        return File(file.FileContents, file.Option,file.FileName);
    }
}
