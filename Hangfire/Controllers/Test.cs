using Hangfire.Models;
using Microsoft.EntityFrameworkCore;

namespace Hangfire.Controllers
{
    public class Test
    {
        private CompanyDBContext _context;

        public Test(CompanyDBContext context)
        {
            this._context = context;
        }
        public async Task AddNewEmployee()
        {
            Console.WriteLine(DateTime.Now);
            int minute = int.Parse(DateTime.Now.ToString("mm"));

            if (minute % 2 == 0)
            {
                _context.Employees.Add(new Employee
                {
                    Name = "Mohamed",
                    Dob = DateTime.Now,
                    Status = true,
                });

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { throw; }
            }
            else
            {
                _context.Employees.Add(new Employee
                {
                    Name = "New Employee",
                    Dob = DateTime.Now,
                    Status = false
                });
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { throw; }
            }

        }
    }
}
