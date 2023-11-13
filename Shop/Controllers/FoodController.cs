using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return Ok(await _dBContext.Foods.ToListAsync());
        }

        [HttpPost(Name = "PostFood")]
        public async Task<IActionResult> PostFood(Food food)
        {
           _dBContext.Foods.Add(food);
            await _mediator.Publish(new FoodCreatedNotification { FoodId = food.FoodID });
            await _dBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFood), new { id = food.FoodID }, food);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(Guid id)
        {
            var food = await _dBContext.Foods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, Food food)
        {
            if (id != food.FoodID)
            {
                return BadRequest();
            }

            _dBContext.Entry(food).State = EntityState.Modified;

            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExsist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var food = await _dBContext.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _dBContext.Foods.Remove(food);
            await _dBContext.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExsist(Guid id)
        {
            return _dBContext.Foods.Any(e => e.FoodID == id);
        }
    }
}
