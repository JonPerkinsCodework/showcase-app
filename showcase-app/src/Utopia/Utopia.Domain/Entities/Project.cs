using System;
using System.Collections.Generic;
using System.Text;

namespace Utopia.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<TaskItem> Tasks { get; set; } = new();
    }
}
