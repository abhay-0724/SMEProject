
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using SMEProject.Feature.BasicContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMEProject.Feature.BasicContent.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            var contextItem = RenderingContext.Current.Rendering.Item;
            AboutUs about = new AboutUs()
            {
                Image = GetImageUrl(contextItem,"AboutImage"),
                AboutDescription = new HtmlString(FieldRenderer.Render(contextItem,"AboutDescription")),
                AboutQuote = new HtmlString(FieldRenderer.Render(contextItem, "AboutQuote")),
                AboutSubTitle = new HtmlString(FieldRenderer.Render(contextItem, "AboutSubTitle")),
                AboutTitle = new HtmlString(FieldRenderer.Render(contextItem, "AboutTitle")),
            };
            return View("/Views/SMEProject/BasicContent/AboutUs.cshtml",about);
        }
        private string GetImageUrl(Item item, string fieldName)
        {
            ImageField imageField = item.Fields[fieldName];
            return MediaManager.GetMediaUrl(imageField.MediaItem);
        }
    }
}