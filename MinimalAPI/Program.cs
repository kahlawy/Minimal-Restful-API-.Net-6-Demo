using MinimalAPI.Model;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
"### Minimal API Dmo ### "+
"1- For Select One Employee '/Employee' " +
"2- For Select Employee by Id  '/Employees/{id}' " +
"3- For Select Many Employees '/Employees' "
);

app.MapGet("/Employee", (Func<Employee>)(() =>
{
    return new Employee
        {
            Id = 1,
            Name = "ALi",
            Salary =1200
        };
}));

app.MapGet("/Employees", (Func<List<Employee>>)(() =>
{
    return new EmployeeCollection().GetEmployees();

}));

app.MapGet("/Employee/{id}",async (http) =>
{
    if (!http.Request.RouteValues.TryGetValue("id", out var id))
    {
        http.Response.StatusCode = 400;
        return;
    }
    else
    {
        int empId = 0;
        Int32.TryParse((string?)id, out empId);
        await http.Response.WriteAsJsonAsync(new EmployeeCollection()
                           .GetEmployees()
                           .FirstOrDefault(e => e.Id == empId)
                            );
    }
 
});

app.Run();
