namespace CQRS_Project.CQRS.Results
{
    public class GetProductQueryResult
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
