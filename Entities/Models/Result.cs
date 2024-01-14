using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Result
{
    public Guid ResultId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid AnswerId { get; set; }

    public Guid UserId { get; set; }

    public virtual Answer Answer { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
