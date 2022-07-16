using CsApp.Application.Features.Commands.CreateComplaint;
using CsApp.Application.Features.Commands.UpdateComplaint;
using CsApp.Application.Features.Queries.GetAllComplaint;
using CsApp.Application.Features.Queries.GetOneBringComplaint;
using CsApp.Application.Features.Queries.GetOneComplaint;
using CsApp.Application.Features.Queries.PrintComplaint;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CsMvcApp.Controllers
{
    public class ComplaintController : Controller
    {

        private readonly IMediator _mediator;

        public ComplaintController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllComplaintQuery()));
        }

        [Route("ComplaintAdd")]
        [HttpGet]
        public IActionResult ComplaintAdd()
        {
            return View();
        }

        [Route("ComplaintAdd")]
        [HttpPost]
        public async Task<IActionResult> ComplaintAdd(int id, CreateComplaintCommand command)
        {
            command.ClientId = id;
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [Route("GetBringOneComplaint")]
        [HttpGet]
        public async Task<IActionResult> GetBringOneComplaint(int id)
        {
            return View(await _mediator.Send(new GetOneComplaintQuery() { Id = id }));
        }

        [Route("BringComplaint")]
        [HttpGet]
        public async Task<IActionResult> BringComplaint([FromQuery] int id)
        {

            return View("BringComplaint", await _mediator.Send(new GetOneBringComplaintQuery { Id = id }));
        }

        [Route("ComplaintUpdate")]
        [HttpPost]
        public async Task<IActionResult> ComplaintUpdate(UpdateComplaintCommand updateCompliant)
        {
            await _mediator.Send(updateCompliant);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            return View(await _mediator.Send(new PrintComplaintQuery() { Id = id }));
        }


    }
}
