﻿using System.ComponentModel.DataAnnotations;

namespace Utilities.Models.Autenticacion
{
    public class Registro
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
