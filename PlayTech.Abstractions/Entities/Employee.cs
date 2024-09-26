namespace PlayTech.Abstractions.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int ManagerId { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public Manager Manager { get; set; }
}