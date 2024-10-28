namespace MedicalStaff.Domain

{
    public class Nurse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }

        public Nurse(string name, string departmentName) 
        {
            Name = name;
            DepartmentName = departmentName;
        }

        public Nurse(){}
    }
}
