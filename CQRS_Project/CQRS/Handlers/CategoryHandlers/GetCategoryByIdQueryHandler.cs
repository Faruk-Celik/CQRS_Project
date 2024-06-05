using CQRS_Project.CQRS.Queries;
using CQRS_Project.CQRS.Results;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly Context _context;

        public GetCategoryByIdQueryHandler ( Context context )
        {
            _context = context;
        }
        public GetCategoryByIdQueryResult Handle ( GetCategoryByIdQuery query )
        {
            var value = _context.Categories.Find ( query.Id );
            return new GetCategoryByIdQueryResult
            {
                CategoryID = value.CategoryID,
                CategoryName = value.CategoryName
            };
        }


    }
}
