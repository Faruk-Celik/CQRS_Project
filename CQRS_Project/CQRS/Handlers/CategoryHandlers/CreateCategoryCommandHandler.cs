using CQRS_Project.CQRS.Commands;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly Context _context;
        public CreateCategoryCommandHandler ( Context context)
        {
            _context = context;
        }
        public void Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category    
            {
                CategoryName = command.CategoryName
            });
            
            _context.SaveChanges();
        }
    }
}
