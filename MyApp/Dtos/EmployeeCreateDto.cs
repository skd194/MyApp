using System.ComponentModel.DataAnnotations;

namespace MyApp
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
    }
}
