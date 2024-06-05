using CQRS_Project.CQRS.Commands;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly Context _context;

        public UpdateCategoryCommandHandler ( Context context )
        {
            _context = context;
        }
        public void Handle ( UpdateCategoryCommand command )
        {
            var value = _context.Categories.Find ( command.CategoryID );
            value.CategoryName = command.CategoryName;
            _context.SaveChanges ();
        }
    }
}
