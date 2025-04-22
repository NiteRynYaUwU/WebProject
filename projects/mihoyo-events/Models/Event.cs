using System;
using System.ComponentModel.DataAnnotations;

namespace mihoyo_events.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public string Status { get; set; } // Past/Current/Future

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Rewards { get; set; }
    }
}