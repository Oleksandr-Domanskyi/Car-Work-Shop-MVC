using CarWorkShop.Application.Commands.CreateCarWorkShop;
using CarWorkShop.Application.Commands.Queries.GetAllCarWorkShops;
using CarWorkShop.Application.DataTranferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkShop.Controllers
{
    public class CarWorkShopController:Controller
    {
        private readonly IMediator _mediator;

        public CarWorkShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var CarWorkShops = await _mediator.Send(new GetAllCarWorkShopsQuery());
            return View(CarWorkShops);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkShopCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
