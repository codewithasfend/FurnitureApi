using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureApi.Data;
using FurnitureApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private FurnitureDbContext _dbContext;
        public ComplaintsController(FurnitureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Complaints
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            var complaints = _dbContext.Complaints;
            if (complaints == null)
            {
                return NotFound();
            }
            return Ok(complaints);
        }


        // POST: api/Complaints
        [HttpPost]
        public IActionResult Post([FromBody] Complaint complaint)
        {
            complaint.Date = DateTime.Now;
            _dbContext.Complaints.Add(complaint);
            _dbContext.SaveChanges();
            return Ok("Your Complaint has been registered");
        }

    }
}
