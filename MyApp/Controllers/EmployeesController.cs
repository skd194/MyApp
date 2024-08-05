using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly List<Employee> _employees;

        public EmployeesController()
        {
            _employees = GetEmployees().ToList();
        }

        [HttpGet(Name = "Get Employees")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(_employees);
        }

        [HttpGet("{id}", Name = "Get Employees")]
        public ActionResult<IEnumerable<Employee>> Get(int id)
        {
            var employee = _employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost(Name = "Create Employee")]
        public ActionResult Create(Employee employee)
        {
            _employees.Add(employee);

            return Created();
        }

        [HttpPut("{id}", Name = "Update Employee")]
        public ActionResult Update(int id, EmployeeUpdateDto employee)
        {
            var employeeToUpdate = _employees.SingleOrDefault(x => x.Id == id);

            if (employeeToUpdate == null) 
            { 
                return NotFound();
            }
            
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Dob = employee.Dob;

            return Ok();
        }

        [HttpDelete("{id}", Name = "Delete Employee")]
        public ActionResult Delete(int id)
        {
            var employeeToDelete = _employees.SingleOrDefault(x=> x.Id == id);

            if(employeeToDelete == null)
            {
                return NotFound();
            }

            _employees.Remove(employeeToDelete);
            
            return Ok();
        }


        private static IEnumerable<Employee> GetEmployees()
        {
            return
            [
                new(1, "John", new DateTime(1990, 10, 15)),
                new(2, "Sam", new DateTime(2005, 6, 08)),
                new(3, "Rohan", new DateTime(2015, 1, 1)),
                new(3, "Don", new DateTime(1998, 2, 20)),
            ];
        }
    }
}
