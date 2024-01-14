using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Interview
{
    public Guid InterviewId { get; set; }

    public Guid SurveyId { get; set; }

    public Guid UserId { get; set; }

    public DateTime PassingDate { get; set; }

    public virtual Survey Survey { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
