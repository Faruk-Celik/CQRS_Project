using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers.CategoryHandlers;
using CQRS_Project.CQRS.Handlers.ProductHandlers;
using CQRS_Project.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public ProductController ( GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler )
        {

            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult ProductResult ()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct ( CreateProductCommand command )
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("ProductResult");
        }
        public IActionResult RemoveProduct ( int id )
        {

            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("ProductResult");
        }
        [HttpGet]
        public IActionResult UpdateProduct ( int id )
        {
            var value = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct ( UpdateProductCommand command )
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("ProductResult");
        }

    }
}
