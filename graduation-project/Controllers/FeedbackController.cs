using graduation_project.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graduation_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly DataContext dataContext;

        public FeedbackController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(string userGuid, string feedBack)
        {
            var feedBackObj = graduation_project.Entities.FeedBack.Create(userGuid, feedBack);

            await dataContext.FeedBack.AddAsync(feedBackObj);
            var rowEfected = await dataContext.SaveChangesAsync();
            if (rowEfected > 0)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
