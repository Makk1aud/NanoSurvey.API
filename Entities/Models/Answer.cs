using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Answer
{
    public Guid AnswerId { get; set; }

    public Guid QuestionId { get; set; }

    public string Content { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
