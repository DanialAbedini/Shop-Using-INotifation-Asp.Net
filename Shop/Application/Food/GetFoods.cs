using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Repository.Base;

namespace Shop.Application.Food
{
    public class GetFoods
    {
        public class Query : IRequest<Response>
        {
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly DBContextConnection _dBContext;

            public Handler(DBContextConnection db)
            {
                _dBContext = db;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var food = await _dBContext.Foods.ToListAsync();
                return new Response
                {
                    food = food,
                };
            }
        }

        public class Response
        {
            public List<Models.Domain.Food> food { get; set; }
        }
    }
}

