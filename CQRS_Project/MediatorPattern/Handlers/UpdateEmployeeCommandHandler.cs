

using CQRS_Project.DAL;
using CQRS_Project.MediatorPattern.Commands;
using MediatR;

namespace CQRS_Project.MediatorPattern.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly Context _context;
        public UpdateEmployeeCommandHandler ( Context context )
        {
            _context = context;
        }
        public async Task Handle ( UpdateEmployeeCommand request, CancellationToken cancellationToken )
        {
            var values = await _context.Employees.FindAsync(request.EmployeeID);
            values.Surname = request.Surname;
            values.Name = request.Name;
            values.Salary = request.Salary;
            await _context.SaveChangesAsync();
        }
    }
}
