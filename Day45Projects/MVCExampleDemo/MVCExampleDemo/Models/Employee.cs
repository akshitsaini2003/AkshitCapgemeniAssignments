namespace MVCExampleDemo.Models
{
    public class Employee
    {
        public int EmployeeId {  get; set; }
        public string EmployeeName { get; set; }
        public int EmpSalary {  get; set; }
        public string? ImageUrl {  get; set; }

        //fk+reference
        public int DeptId {  get; set; }
        public Dept? Dept { get; set; }
    }
}
