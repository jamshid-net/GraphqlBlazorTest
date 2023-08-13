using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlBlazorTest.Shared;
public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; }

    public DateOnly BirhDate { get; set; }

    public string Picture { get; set; }

    public string Job { get; set; }

    public string Password { get; set; }

    public string UserName { get; set; }

    public string[]? Roles { get; set; }


}
