﻿namespace MVC5Course.Models
{
    public interface IClientViewModel
    {
        int ClientId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
    }
}