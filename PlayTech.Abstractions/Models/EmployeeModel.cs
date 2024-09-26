namespace PlayTech.Abstractions.Models;

public class EmployeeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public DepartmentModel Department { get; set; }
    public ManagerModel Manager { get; set; }
}