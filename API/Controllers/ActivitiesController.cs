using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        
        [HttpGet]
        public async Task<IActionResult> GetActivities(CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new List.Query(), cancellationToken));
        }

        [HttpGet("{activityId}")]
        public async Task<IActionResult> GetActivity([FromRoute] Guid activityId)
        {
            return HandleResult(await Mediator.Send(new Details.Query{ Id = activityId }));            
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command{ Activity = activity }));
        }

        [Authorize(Policy ="IsActivityHost")]
        [HttpPut("{activityId}")]
        public async Task<IActionResult> EditActivity([FromRoute] Guid activityId, [FromBody] Activity activity)
        {
            activity.Id = activityId;
            return HandleResult(await Mediator.Send(new Edit.Command{ Activity = activity}));
        }

        [Authorize(Policy ="IsActivityHost")]
        [HttpDelete("{activityId}")]
        public async Task<IActionResult> DeleteActivity(Guid activityId) 
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = activityId}));
        }

        [HttpPost("{activityId}/attend")]
        public async Task<IActionResult> Attend(Guid activityId)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command{Id = activityId}));
        }
    }
}