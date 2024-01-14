using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Survey
{
    public Guid SurveyId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
