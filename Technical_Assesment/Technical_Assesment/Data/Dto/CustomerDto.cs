namespace Technical_Assesment.Data.Dto
{
    public class CustomerDto
    {
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; } = string.Empty;
        public required string Country { get; set; } = string.Empty;
        public required string PhoneNumber { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required byte[] IdentityPhoto { get; set; }
    }
}
