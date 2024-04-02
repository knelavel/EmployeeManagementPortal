namespace WebApplication1.Models
{
    public class EmployeeAddress
    {
        public int EmployeeAddressId { get; set; }

        public string EmployeeId { get; set;}

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZIPCode { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
