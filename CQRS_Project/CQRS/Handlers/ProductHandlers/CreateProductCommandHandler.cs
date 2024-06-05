using CQRS_Project.CQRS.Commands;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler ( Context context )
        {
            _context = context;
        }
        public void Handle ( CreateProductCommand command )
        {
            _context.Products.Add(new Product
            {
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
            });
            _context.SaveChanges();
        }
    }
}
