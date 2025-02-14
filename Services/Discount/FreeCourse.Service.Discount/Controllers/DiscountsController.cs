﻿using FreeCourse.Service.Discount.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Service.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedItentityService _sharedItentityService;

        public DiscountsController(IDiscountService discountService, ISharedItentityService sharedItentityService)
        {
            _discountService = discountService;
            _sharedItentityService = sharedItentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetById(id);
            return CreateActionResultInstance(discount);
        }
        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _sharedItentityService.GetUserId;
            var discount = await _discountService.GetByCodeAndUserId(code,userId);
            return CreateActionResultInstance(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount model)
        {
            return CreateActionResultInstance(await _discountService.Save(model));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount model)
        {
            return CreateActionResultInstance(await _discountService.Update(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _discountService.Delete(id));
        }
    }
}
