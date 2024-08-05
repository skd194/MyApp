namespace MyApp
{
    public interface IEmployeeRepository
    {
        IReadOnlyCollection<Employee> GetAll();

        Employee? GetById(Guid id);
        
        void Add(Employee employee);

        void Remove(Guid id);
    }
}
