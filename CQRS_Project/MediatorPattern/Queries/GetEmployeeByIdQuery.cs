using CQRS_Project.MediatorPattern.Results;
using MediatR;

namespace CQRS_Project.MediatorPattern.Queries
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdQueryResult>
    {
        public int Id { get; set; }

        public GetEmployeeByIdQuery ( int id )
        {
            Id = id;
        }
    }
}
