using MediatR;
using Shop.Repository.Base;

namespace Shop.Application.Food
{
    public class DeleteFood
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }

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
                        try
                        {
                            _dBContext.Foods.Remove(food);
                            await _dBContext.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error Deleting database: {ex.Message}");
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
