using System;
using System.Collections.Generic;
using System.Text;

namespace Utopia.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public string Notes { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
