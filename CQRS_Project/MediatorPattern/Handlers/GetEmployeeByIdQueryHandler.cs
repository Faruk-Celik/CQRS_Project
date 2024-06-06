using CQRS_Project.DAL;
using CQRS_Project.MediatorPattern.Queries;
using CQRS_Project.MediatorPattern.Results;
using MediatR;

namespace CQRS_Project.MediatorPattern.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        private readonly Context _context;

        public GetEmployeeByIdQueryHandler ( Context context )
        {
            _context = context;
        }

        public async Task<GetEmployeeByIdQueryResult> Handle ( GetEmployeeByIdQuery request, CancellationToken cancellationToken )
        {
           var values = await _context.Employees.FindAsync(request.Id);
            return new GetEmployeeByIdQueryResult
            {
                EmployeeID = values.EmployeeID,
                Name = values.Name,
                Surname = values.Surname,
                Salary = values.Salary
            };
        }
    }
}
