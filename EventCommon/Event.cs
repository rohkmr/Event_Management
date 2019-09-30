using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCommon
{
    public class Event
    {
        public int Id { get; set; }
        [Required()]
        public string Title { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public bool IsPrivate { get; set; }
        [Range(0, 4)]
        public Nullable<float> Duration { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string OtherDetails { get; set; }
        public string InvitedEmails { get; set; }
    }
}
