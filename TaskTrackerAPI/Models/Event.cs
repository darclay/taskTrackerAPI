using System.ComponentModel.DataAnnotations;

namespace TaskTrackerAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Text { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "The day has to be no more 10 characters long")]
        public string Day { get; set; }

        public bool Reminder { get; set; }
    }
}