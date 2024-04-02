namespace WebApplication1.Models
{
    public class EmployeePhone
    {
        public int EmployeePhoneID { get; set; }

        public string EmployeeId { get; set; }
        public string PhoneNumber { get; set;}

        public string PhoneType { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
