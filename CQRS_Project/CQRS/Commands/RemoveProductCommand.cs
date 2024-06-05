namespace CQRS_Project.CQRS.Commands
{
    public class RemoveProductCommand
    {
        public int ProductID { get; set; }

        public RemoveProductCommand ( int productID )
        {
            ProductID = productID;
        }
    }
}
