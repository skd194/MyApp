using System.Xml.Linq;

namespace MyApp
{
    public class Employee(int id, string name, DateTime dob)
    {
        public Employee()
            : this(0, string.Empty, DateTime.MinValue)
        {
        }

        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public DateTime Dob { get; set; } = dob;
    }

    public class EmployeeUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
    }
}
