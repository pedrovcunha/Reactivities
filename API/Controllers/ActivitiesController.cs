using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new List.Query(), cancellationToken);
        }

        [HttpGet("{activityId}")]
        public async Task<ActionResult<Activity>> GetActivity([FromRoute] Guid activityId)
        {
            return await Mediator.Send(new Details.Query{ Id = activityId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{ Activity = activity }));
        }

        [HttpPut("{activityId}")]
        public async Task<IActionResult> EditActivity([FromRoute] Guid activityId, [FromBody] Activity activity)
        {
            activity.Id = activityId;
            return Ok(await Mediator.Send(new Edit.Command{ Activity = activity}));
        }

        [HttpDelete("{activityId}")]
        public async Task<IActionResult> DeleteActivity(Guid activityId) 
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = activityId}));
        }
    }
}