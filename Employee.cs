namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public virtual ICollection<EmployeePhone> EmployeePhones { get; set; }

        public virtual ICollection<EmployeeAddress> EmployeeAddresss { get; set; }
    }
}
