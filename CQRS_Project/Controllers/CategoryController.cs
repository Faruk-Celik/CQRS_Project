using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers.CategoryHandlers;
using CQRS_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoryController ( GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler )
        {

            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        public IActionResult CategoryResult ()
        {
            var values = _getCategoryQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory ( CreateCategoryCommand command )
        {
            _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryResult");
        }
        public IActionResult RemoveCategory ( int id)
        {
            _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("CategoryResult");
        }
    }
}
