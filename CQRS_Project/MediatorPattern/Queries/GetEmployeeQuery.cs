using CQRS_Project.MediatorPattern.Results;
using MediatR;

namespace CQRS_Project.MediatorPattern.Queries
{
    public class GetEmployeeQuery : IRequest<List<GetEmployeeQueryResult>>
    {
    }
}
