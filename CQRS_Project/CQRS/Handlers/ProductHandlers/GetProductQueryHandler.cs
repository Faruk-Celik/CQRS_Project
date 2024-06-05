using CQRS_Project.CQRS.Results;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(c => new GetProductQueryResult
            {
                ProductID = c.ProductID,
                ProductName = c.ProductName,
                ProductPrice = c.ProductPrice

            }).ToList();
            return values.ToList();
        }
    }
}
