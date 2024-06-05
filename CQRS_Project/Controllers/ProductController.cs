using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers.ProductHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;

        public ProductController ( GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler )
        {

            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
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
    }
}
