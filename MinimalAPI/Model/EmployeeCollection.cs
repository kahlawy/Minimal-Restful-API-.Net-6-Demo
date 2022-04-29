using MinimalAPI.Model;

public class EmployeeCollection
{
    public List<Employee>? Employees { get; set; }

    public List<Employee> GetEmployees()
    {
        return new List<Employee>()
         {
             new Employee()
             {
                 Id = 1,
                 Name ="Ali",
                 Salary =1200
              },

             new Employee()
             {
                 Id = 2,
                 Name ="Mohamed",
                 Salary =2000
              },

              new Employee()
               {
                 Id = 3,
                 Name ="Hany",
                 Salary =3500
               }
         };
    }

}
