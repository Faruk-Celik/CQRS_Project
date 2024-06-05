using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers.ProductHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public ProductController ( GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler )
        {

            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
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

    }
}
