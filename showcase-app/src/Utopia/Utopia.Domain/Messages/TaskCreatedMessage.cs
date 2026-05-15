using System;
using System.Collections.Generic;
using System.Text;

namespace Utopia.Domain.Messages
{
    public record TaskCreatedMessage(
       Guid TaskId,
       Guid ProjectId,
       string Title
   );
}
