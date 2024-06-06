using CQRS_Project.DAL;
using CQRS_Project.MediatorPattern.Commands;
using MediatR;

namespace CQRS_Project.MediatorPattern.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly Context _context;

        public CreateEmployeeCommandHandler ( Context context )
        {
            _context = context;
        }

        public async Task Handle ( CreateEmployeeCommand request, CancellationToken cancellationToken )
        {
            await _context.Employees.AddAsync ( new Employee
            {
                Name = request.Name,
                Surname = request.Surname,
                Salary = request.Salary
            } );
            await _context.SaveChangesAsync ();
        }
    }
}
