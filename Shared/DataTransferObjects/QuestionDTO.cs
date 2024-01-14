using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class QuestionDTO
    {
        public Guid QuestionId { get; init; }

        public string? Content { get; init; }

        public IEnumerable<AnswerDTO>? Answers { get; set; }
    }
}
