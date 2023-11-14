using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Repository.Base;
using System.ComponentModel.DataAnnotations;
using Shop.Models.Domain;
using Azure;
using static Shop.Application.Food.GetFood;

namespace Shop.Application.Food
{
    public class AddFood
    {
        public class Command : IRequest<Response>
        {
            public string FoodName { get; set; }

            public string FoodQuantity { get; set; }

            public double FoodPrice { get; set; }

            public Category.category FoodCatagory { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly DBContextConnection _dBContext;


            public Handler(DBContextConnection db)
            {
                _dBContext = db;

            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {

                var food = await _dBContext.Foods.AddAsync(new Models.Domain.Food()
                {
                    FoodID = Guid.NewGuid(),
                    FoodName = request.FoodName,
                    FoodPrice = request.FoodPrice,
                    FoodQuantity = request.FoodQuantity,
                    FoodCatagory = request.FoodCatagory,
                });
                await _dBContext.SaveChangesAsync();

                return new Response
                {
                    food = food.Entity,
                };
            }
        }
            public class Response
            {
                public Models.Domain.Food food { get; set; }
            }
        }
    }

