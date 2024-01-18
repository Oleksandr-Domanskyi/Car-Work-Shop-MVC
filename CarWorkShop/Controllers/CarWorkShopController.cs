﻿using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkShop.Controllers
{
    public class CarWorkShopController:Controller
    {
        private readonly ICarWorkShopService _carWorkShopService;

        public CarWorkShopController(ICarWorkShopService carWorkShopService)
        {
            _carWorkShopService = carWorkShopService;
        }
        public async Task<IActionResult> Index()
        {
            var CarWorkShops = await _carWorkShopService.GetAll();
            return View(CarWorkShops);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarWorkShopObject carWorkShopDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
           await _carWorkShopService.Create(carWorkShopDto);
           return RedirectToAction(nameof(Index));//TODO: refactor
        }
    }
}