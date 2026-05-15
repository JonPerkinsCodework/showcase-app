using System;
using System.Collections.Generic;
using System.Text;

namespace Utopia.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        public string Title { get; set; } = default!;
        public string? Description { get; set; }

        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Project? Project { get; set; }
    }
}
