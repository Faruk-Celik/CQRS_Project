namespace CQRS_Project.CQRS.Commands
{
    public class RemoveCategoryCommand
    {
        public int CategoryID { get; set; }

        public RemoveCategoryCommand ( int categoryID )
        {
            CategoryID = categoryID;
        }
    }
}
