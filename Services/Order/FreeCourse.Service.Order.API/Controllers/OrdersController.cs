using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Queries;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Service.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mcdiator;
        private readonly SharedItentityService _sharedItentityService;

        public OrdersController(IMediator mcdiator, SharedItentityService sharedItentityService)
        {
            _mcdiator = mcdiator;
            _sharedItentityService = sharedItentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mcdiator.Send(new GetOrdersByUserIdQuery { UserId = _sharedItentityService.GetUserId });
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand model)
        {
            var response = await _mcdiator.Send(model);
            return CreateActionResultInstance(response);
        }
    }
}
