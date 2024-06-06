using CQRS_Project.DAL;
using CQRS_Project.MediatorPattern.Commands;
using MediatR;

namespace CQRS_Project.MediatorPattern.Handlers
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly Context _context;

        public RemoveEmployeeCommandHandler ( Context context )
        {
            _context = context;
        }

        public async Task Handle ( RemoveEmployeeCommand request, CancellationToken cancellationToken )
        {
            
            var value = _context.Employees.Find(request.EmployeeID);
            _context.Employees.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
