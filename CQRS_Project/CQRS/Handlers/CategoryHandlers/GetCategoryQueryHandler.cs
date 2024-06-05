using CQRS_Project.CQRS.Results;
using CQRS_Project.DAL;

namespace CQRS_Project.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly Context _context;

        public GetCategoryQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetCategoryQueryResult> Handle()
        {
            var values = _context.Categories.Select(c => new GetCategoryQueryResult
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName
            }).ToList();
            return values.ToList();
        }
    }
}
