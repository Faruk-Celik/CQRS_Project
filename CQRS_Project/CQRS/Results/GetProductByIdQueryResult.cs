namespace CQRS_Project.CQRS.Results
{
    public class GetProductByIdQueryResult
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
