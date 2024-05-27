using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMEProject.Feature.BasicContent.Models
{
    public class AboutUs
    {
        public string Image { get; set; }
        public HtmlString AboutSubTitle { get; set; }
        public HtmlString AboutTitle { get; set; }
        public HtmlString AboutQuote { get; set; }
        public HtmlString AboutDescription { get; set; }
    }
}