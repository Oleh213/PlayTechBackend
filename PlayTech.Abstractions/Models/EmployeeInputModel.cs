namespace PlayTech.Abstractions.Models;

public class EmployeeInputModel
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public int ManagerId { get; set; }
}