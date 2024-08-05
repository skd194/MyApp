namespace MyApp
{
    public sealed class EmployeeRepository: IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees =
            [
                new (Guid.NewGuid(), "John", new DateTime(1990, 10, 15)),
                new (Guid.NewGuid(), "Sam", new DateTime(2005, 6, 08)),
                new (Guid.NewGuid(), "Rohan", new DateTime(2015, 1, 1)),
                new (Guid.NewGuid(), "Don", new DateTime(1998, 2, 20)),
            ];
        }

        public IReadOnlyCollection<Employee> GetAll()
        {
            return _employees.AsReadOnly();
        }

        public Employee? GetById(Guid id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            if (_employees.Any(e => e.Id == employee.Id))
            {
                throw new ArgumentException("An employee with the same Id already exists.");
            }

            _employees.Add(employee);
        }

        public void Remove(Guid id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
