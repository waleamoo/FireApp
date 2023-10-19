using Microsoft.AspNetCore.Mvc;
using FireApp.Models;
using Hangfire;
using FireApp.Services;

namespace FireApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private static List<Driver> drivers = new List<Driver>();
    public DriversController()
    {
    }
    
    [HttpPost]
    public IActionResult AddDriver(Driver driver)
    {
        if(ModelState.IsValid)
        {
            drivers.Add(driver);
            // call the Hangfire to run a job 
            var jobId = BackgroundJob.Enqueue<IServiceManagement>(x => x.SendEmail());
            return CreatedAtAction("GetDriver", new {driver.Id}, driver);
        }
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetDriver(Guid id)
    {
        var driver = drivers.FirstOrDefault(x => x.Id == id);
        if(driver == null)
        {
            return NotFound();
        }
        return Ok(driver);
    }

    [HttpDelete]
    public IActionResult DeleteDriver(Guid id)
    {
        var driver = drivers.FirstOrDefault(x => x.Id == id);
        if(driver == null)
            return NotFound();

        driver.Status = 0;
        RecurringJob.AddOrUpdate<IServiceManagement>(x => x.UpdatedDatabase(), Cron.Hourly);
        return NoContent();
    }
}
