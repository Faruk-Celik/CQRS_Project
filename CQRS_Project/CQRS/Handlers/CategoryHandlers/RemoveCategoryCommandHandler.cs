using CQRS_Project.CQRS.Commands;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly Context _context;
        public RemoveCategoryCommandHandler ( Context context)
        {
            _context = context;
        }
        public void Handle(RemoveCategoryCommand command)
        {
            var values = _context.Categories.Find(command.CategoryID);
            _context.Categories.Remove(values);
            _context.SaveChanges();
        }
    }
}
