using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMEProject.Feature.BasicContent.Models
{
    public class OurRoom
    {
        public HtmlString RoomIntro { get; set; }

        public HtmlString RoomService { get; set; }
        public HtmlString RoomSpecial { get; set; }
        public string RoomImage { get; set; }
        public string RoomImageAlt { get; set; }
        public string BookingForm { get; set; }
    }
}