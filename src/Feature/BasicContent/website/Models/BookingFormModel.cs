using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMEProject.Feature.BasicContent.Models
{
    public class BookingFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string RoomNumber { get; set; }
        public string BookingDate { get; set; }
        public string VacatingDate { get; set; }
    }
}