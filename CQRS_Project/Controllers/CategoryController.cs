using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers.CategoryHandlers;
using CQRS_Project.CQRS.Queries;
using CQRS_Project.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoryController ( GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler )
        {

            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
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
        [HttpGet]
        public IActionResult UpdateCategory ( int id)
        {
            var value = _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory ( UpdateCategoryCommand command )
        {
            _updateCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryResult");
        }
    }
}
