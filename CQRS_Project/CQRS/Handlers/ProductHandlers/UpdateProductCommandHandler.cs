using CQRS_Project.CQRS.Commands;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler ( Context context )
        {
            _context = context;
        }
        public void Handle ( UpdateProductCommand command )
        {
            var value = _context.Products.Find ( command.ProductID );
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;           
            _context.SaveChanges ();
        }
    }
}
