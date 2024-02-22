﻿namespace Technical_Assesment.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Country {  get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required byte[] IdentityPhoto {  get; set; }
    }
}
