namespace Utopia.Api.Models
{
    public sealed class ClientUpdateDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = default!;
        public string? Phone { get; set; }
        public string? Notes { get; set; }
    }

}
