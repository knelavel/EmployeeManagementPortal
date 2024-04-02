using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _applicationContext;

        public EmployeesController(ApplicationDbContext context)
        {
            _applicationContext = context;
        }


        public async Task<IActionResult> Index(string phoneNumber, string ZipCode) {

            var employees = _applicationContext.Employees.Include(e => e.EmployeePhones)
                .Include(e => e.EmployeeAddresss)
                .Include(e => e.EmployeeAddresss)
                .AsQueryable();

            if(string.IsNullOrWhiteSpace(phoneNumber))
            {
                employees = employees.Where(e => e.EmployeePhones.Any(p => p.PhoneNumber == phoneNumber));
            }

            if (string.IsNullOrWhiteSpace(ZipCode))
            {
                employees = employees.Where(e => e.EmployeeAddresss.Any(p => p.ZIPCode == ZipCode));
            }

            employees = employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            return View(await employees.Distinct().ToListAsync());

        }

        public async Task<IActionResult> EmployementDetails()
        {
            var employees = await _applicationContext.Employees.ToListAsync();

            var employeeDetails = employees.Select(
                e => new EmployeeEmploymentDetailsViewModel
                {
                    FullName = $"${e.FirstName} {e.LastName}",
                    EarliestHireDate = employees.Min(employees => e.HireDate),
                    LatestHireDate = employees.Max(employees => e.HireDate),
                    AverageLengthOfEmployment = employees.Average(emp => (DateTime.Now - emp.HireDate).TotalDays / 365)
                }
            ).ToList();

            return View(employeeDetails);
        }
    }
}

public class EmployeeEmploymentDetailsViewModel
{
    public string FullName { get; set; }
    public DateTime EarliestHireDate { get; set; }

    public DateTime LatestHireDate { get; set; }

    public double AverageLengthOfEmployment { get; set; }

}

