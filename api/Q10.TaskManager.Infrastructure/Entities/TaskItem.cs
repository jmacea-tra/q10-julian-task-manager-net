using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Entities
{
    public class TaskItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(400)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
