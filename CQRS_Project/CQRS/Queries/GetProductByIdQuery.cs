namespace CQRS_Project.CQRS.Queries
{
    public class GetProductByIdQuery
    {
        public int Id { get; set; }

        public GetProductByIdQuery ( int id )
        {
            Id = id;
        }
    }
}
