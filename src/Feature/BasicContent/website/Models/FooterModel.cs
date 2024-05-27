using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMEProject.Feature.BasicContent.Models
{
    public class FooterModel
    {
        public HtmlString ContactTitle { get; set; }
        public HtmlString HotelName { get; set; }
        public HtmlString Address { get; set; }
        public HtmlString PhoneNumber { get; set; }
        public HtmlString HotelEmail { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public HtmlString SocialTitle { get; set; }
        public HtmlString Copywright { get; set; }
        public HtmlString FacebookPlaceholder { get; set; }
        public HtmlString InstagramPlaceholder { get; set; }
        public HtmlString TwitterPlaceholder { get; set; }
        public HtmlString RoomPlaceholder { get; set; }
        public HtmlString DinningPlaceholder { get; set; }
        public string Rooms { get; set; }
        public string Dinning { get; set; }
        public HtmlString ExploreTitle { get; set; }

    }
}