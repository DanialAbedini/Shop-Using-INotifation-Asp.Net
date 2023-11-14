using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Application.Food;
using Shop.Models;
using Shop.Models.Domain;
using Shop.Notifications;
using Shop.Repository.Base;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly DBContextConnection _dBContext;
        private readonly IMediator _mediator;

        public FoodController(DBContextConnection db, IMediator mediator)
        {
            _dBContext = db;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetFoods")]
        public async Task<IActionResult> GetFoods()
        {
            return StatusCode(200, await _mediator.Send(new GetFoods.Query()));
        }

        [HttpPost(Name = "PostFood")]
        public async Task<IActionResult> PostFood(FoodModel food)
        {
            var f = await _mediator.Send(new AddFood.Command
            {
                FoodName = food.FoodName,
                FoodPrice = food.FoodPrice,
                FoodQuantity = food.FoodQuantity,
                FoodCatagory = food.FoodCatagory,

            });

            if (f.food == null)
            {
                return StatusCode(400, "Error Comes From here!");
            }

            await _mediator.Publish(new FoodCreatedNotification { FoodId = f.food.FoodID });
            return StatusCode(201, $"Food With ID = {f.food.FoodID}, FoodName= {f.food.FoodName}");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(Guid id)
        {

            var food = await _mediator.Send(new GetFood.Query { Id = id });
            if (food.food == null)
            {
                return StatusCode(400, $"Can't Find Food With ID={id}");
            }
            return StatusCode(200, food.food);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(Guid id, FoodModel food)
        {
            var result = await _mediator.Send(new UpdateFood.Command
            {
                Id = id,
                FoodName = food.FoodName,
                FoodPrice = food.FoodPrice,
                FoodQuantity = food.FoodQuantity,
                FoodCatagory = food.FoodCatagory,
            });
            if (result != null)
            {
                return StatusCode(200, "Updated Successfully");
            }
            else
            {
                return StatusCode(404, "Can't Updated !");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(Guid id)
        {
            var result = await _mediator.Send(new DeleteFood.Command
            {
                Id = id,
            });
            if (result != null)
            {
                return StatusCode(200, "Delete Successfully");
            }
            else
            {
                return StatusCode(404, "Can't Updated !");
            }
        }


    }
}
