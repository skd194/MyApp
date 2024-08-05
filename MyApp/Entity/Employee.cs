using System.Xml.Linq;

namespace MyApp
{
    public class Employee(Guid id, string name, DateTime dob)
    {
        public Employee()
            : this(Guid.Empty, string.Empty, DateTime.MinValue)
        {
        }

        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public DateTime Dob { get; set; } = dob;
    }
}
