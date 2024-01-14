using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Question
{
    public Guid QuestionId { get; set; }

    public Guid SurveyId { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Survey Survey { get; set; } = null!;
}
