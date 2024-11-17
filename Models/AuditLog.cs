namespace CrudOperations.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Action { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
