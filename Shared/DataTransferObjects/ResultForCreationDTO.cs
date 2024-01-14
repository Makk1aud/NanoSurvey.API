using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ResultForCreationDTO
    {
        [Required(ErrorMessage = "Field QuestionId is required")]
        public Guid QuestionId { get; init; }

        [Required(ErrorMessage ="Field AnswerId is required")]
        public Guid AnswerId { get; init; }

        [Required(ErrorMessage = "Field UserId is required")]
        public Guid UserId { get; init; }
    }
}
