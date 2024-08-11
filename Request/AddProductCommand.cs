using MediatR;

namespace MediatWithCQRS.Request
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
