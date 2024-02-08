using AutoMapper;
using CarWorkShop.Application.ApplicationUser;
using CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop;
using CarWorkShop.Application.CarWorkShop.Queries.GetCarWorkShopByEncodedName;
using CarWorkShop.Application.Commands.CreateCarWorkShop;
using CarWorkShop.Application.Commands.Queries.GetAllCarWorkShops;
using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Extentions;
using CarWorkShop.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarWorkShop.Controllers
{
    public class CarWorkShopController:Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
 

        public CarWorkShopController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var CarWorkShops = await _mediator.Send(new GetAllCarWorkShopsQuery());
            return View(CarWorkShops);
        }
        [Authorize]
        public IActionResult Create()
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkShopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);

            this.SetNotification("success", $"Created carworkshop: {command.Name}");

            return RedirectToAction(nameof(Index));
        }
        [Route("CarWorkShop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkShopByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return View(nameof(NoAcces));
            }

            EditCarWorkShopCommand model = _mapper.Map<EditCarWorkShopCommand>(dto);

            return View(model);
        }
        [HttpPost]
        [Route("CarWorkShop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkShopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("CarWorkShop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkShopByEncodedNameQuery(encodedName));
            return View(dto);
        }
        public IActionResult NoAcces()
        {
            return View();
        }

    }
}
