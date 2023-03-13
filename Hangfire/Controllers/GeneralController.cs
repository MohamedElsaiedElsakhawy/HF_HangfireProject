using Hangfire.Common;
using Hangfire.Models;
using HF.Hangfire.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IRunJobs _jobs;
        private readonly CompanyDBContext _context;
        Test t = null;
        public GeneralController(IRunJobs jobs, CompanyDBContext context)
        {
            _jobs = jobs;
            _context = context;
            t= new Test(_context);
        }

        [HttpPost("run-when-you-call")]
        public async Task RunAllJobs()
        {
            await _jobs.Enqueue(() => t.AddNewEmployee());
        }

        [HttpPost("run-schedule")]
        public async Task RunAllJobsSchedule()
        {
            await _jobs.Schedule(() => t.AddNewEmployee(), TimeSpan.FromMinutes(2));
        }

        [HttpPost("run-recurring")]
        public async Task RunAllJobsRecurring()
        {
            await _jobs.Recurring(() => t.AddNewEmployee(), Cron.Minutely );
        }
    }
}
