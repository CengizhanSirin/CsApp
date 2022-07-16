
using CsApp.Application.Features.Commands.CreateClient;
using CsApp.Application.Features.Commands.DeleteClient;
using CsApp.Application.Features.Commands.UpdateClient;
using CsApp.Application.Features.Queries.GetAllClient;
using CsApp.Application.Features.Queries.GetOneClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CsMvcApp.Controllers
{
    [Route("[controller]/[action]")]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string phoneNumber)
        {

            return View(await _mediator.Send(new GetAllClientQuery { phoneNumber = phoneNumber }));
        }

        [HttpGet]
        public IActionResult ClientAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientAdd(CreateClientCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Bring([FromQuery] int id)
        {

            return View("Bring", await _mediator.Send(new GetOneClientQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> ClientUpdate(UpdateClientCommand updateClient)
        {

            await _mediator.Send(updateClient);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ClientDelete([FromQuery] int id)
        {
            await _mediator.Send(new DeleteClientCommand { id = id });
            return RedirectToAction("Index");
        }

    }
}
