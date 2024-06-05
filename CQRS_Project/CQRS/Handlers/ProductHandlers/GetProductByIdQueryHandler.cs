using CQRS_Project.CQRS.Queries;
using CQRS_Project.CQRS.Results;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly Context _context;

        public GetProductByIdQueryHandler ( Context context )
        {
            _context = context;
        }
        public GetProductByIdQueryResult Handle ( GetProductByIdQuery query )
        {
            var value = _context.Products.Find ( query.Id );
            return new GetProductByIdQueryResult
            {
                ProductID = value.ProductID,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,

               
            };
        }
    }
}
