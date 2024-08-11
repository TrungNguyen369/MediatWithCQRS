using MediatR;
using MediatWithCQRS.Model;
using MediatWithCQRS.Model.Context;
using MediatWithCQRS.Request;

namespace MediatWithCQRS.Handler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AddProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }

}
