using Microsoft.AspNetCore.Mvc;

namespace MyApp
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet(Name = "GetEmployees")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(Guid id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost(Name = "CreateEmployee")]
        public ActionResult<Employee> Create([FromBody] EmployeeCreateDto employeeDto)
        {

            var newEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = employeeDto.Name,
                Dob = employeeDto.Dob
            };

            _employeeRepository.Add(newEmployee);

            return CreatedAtRoute("GetEmployee", new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}", Name = "UpdateEmployee")]
        public ActionResult Update(Guid id, [FromBody] EmployeeUpdateDto employeeDto)
        {
            var employeeToUpdate = _employeeRepository.GetById(id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            employeeToUpdate.Name = employeeDto.Name;
            employeeToUpdate.Dob = employeeDto.Dob;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        public ActionResult Delete(Guid id)
        {
            _employeeRepository.Remove(id);

            return NoContent();
        }

       
    }
}
