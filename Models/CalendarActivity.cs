using System;
using System.ComponentModel.DataAnnotations;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class CalendarActivity
    {
        [Key]
        public int CalendarId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
        public string ZoomLink { get; set; }
    }
}
