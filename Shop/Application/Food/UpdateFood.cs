using MediatR;
using Shop.Repository.Base;
using Shop.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Food
{
    public class UpdateFood
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public string FoodName { get; set; }

            public string FoodQuantity { get; set; }

            public double FoodPrice { get; set; }

            public Category.category FoodCatagory { get; set; }

        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DBContextConnection _dBContext;


            public Handler(DBContextConnection db)
            {
                _dBContext = db;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var food = await _dBContext.Foods.FindAsync(request.Id, cancellationToken);

                    if (food != null)
                    {
                        food.FoodName = request.FoodName;
                        food.FoodPrice = request.FoodPrice;
                        food.FoodQuantity = request.FoodQuantity;
                        food.FoodCatagory = request.FoodCatagory;


                        try
                        {
                            _dBContext.Foods.Update(food);
                            await _dBContext.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error updating database: {ex.Message}");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Deleting database: {ex.Message}");
                }


                return Unit.Value;
            }
        }
    }
}
