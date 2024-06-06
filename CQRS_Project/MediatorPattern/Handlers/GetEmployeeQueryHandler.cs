using CQRS_Project.DAL;
using CQRS_Project.MediatorPattern.Queries;
using CQRS_Project.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace CQRS_Project.MediatorPattern.Handlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<GetEmployeeQueryResult>>
    {
        private readonly Context _context;

        public GetEmployeeQueryHandler ( Context context )
        {
            _context = context;
        }

        public async Task<List<GetEmployeeQueryResult>> Handle ( GetEmployeeQuery request, CancellationToken cancellationToken )
        {
            return await _context.Employees.Select ( x => new GetEmployeeQueryResult
            {
                EmployeeID = x.EmployeeID,
                Name = x.Name,
                Surname = x.Surname,
                Salary = x.Salary
            } ).ToListAsync();
        }
    }
}
