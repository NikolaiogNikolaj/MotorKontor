﻿namespace MotorKontor.BL.Models.DTO
{
    public class CustomerDTO
    {
        public string? CustomerId { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public Roles Role { get; set; }
    }
}
