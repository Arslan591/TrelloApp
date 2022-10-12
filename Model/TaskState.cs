using System.ComponentModel.DataAnnotations;

namespace TrelloApp.Model
{
    public class TaskState
    {
        [Key]
        public Guid TaskId { get; set; }

        [Required]
        public String TaskTitle { get; set; } = String.Empty;

        public String TaskDescription { get; set; } = String.Empty;

        public String Img { get; set; }

        [Required]
        public String Status { get; set; }


    }
}
