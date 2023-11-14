using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Repository.Base;

namespace Shop.Application.Food
{
    public class GetFood
    {
        public class Query : IRequest<Response>
        {
            public Guid Id { get; set; }
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
                var food = await _dBContext.Foods.FindAsync(request.Id);
                return new Response
                {
                    food = food,
                };
            }
        }

        public class Response
        {
            public Models.Domain.Food food { get; set; }
        }
    }
}
