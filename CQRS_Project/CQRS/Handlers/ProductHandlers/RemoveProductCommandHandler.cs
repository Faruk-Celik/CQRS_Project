using CQRS_Project.CQRS.Commands;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context _context;

        public RemoveProductCommandHandler ( Context context )
        {
            _context = context;
        }
        public void Handle ( RemoveProductCommand command )
        {
            var values = _context.Products.Find(command.ProductID);
            _context.Products.Remove(values);
            _context.SaveChanges();
        }
    }
}
