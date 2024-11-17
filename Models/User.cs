namespace CrudOperations.Models
{
    public class User
    {
        public int Id { get; set; }
        public required  string UserName { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? LiddleName { get; set; }
        public required string Email { get; set; }
        public required int PhoneNumber { get; set; }
        public required string Role { get; set; }


    }
}
