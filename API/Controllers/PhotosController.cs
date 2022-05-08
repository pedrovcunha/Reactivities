using Application.Photos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhotosController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("{photoId}")]
        public async Task<IActionResult> Delete([FromRoute] string photoId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = photoId }));
        }

        [HttpPost("{photoId}/setMain")]
        public async Task<IActionResult> SetMain(string photoId)
        {
            return HandleResult(await Mediator.Send(new SetMain.Command { PhotoId = photoId }));
        }
    }
}