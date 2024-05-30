using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Web;
using System.Web.Mvc;
using SMEProject.Feature.BasicContent.Models;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace SMEProject.Feature.BasicContent.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Footer()
        {
            var item = RenderingContext.Current.Rendering.Item;
            FooterModel footerModel = new FooterModel()
            {
                DinningPlaceholder = new HtmlString(FieldRenderer.Render(item, "DinningPlaceholder")),
                RoomPlaceholder = new HtmlString(FieldRenderer.Render(item, "RoomPlaceholder")),
                ContactTitle = new HtmlString(FieldRenderer.Render(item, "ContactTitle")),
                HotelName = new HtmlString(FieldRenderer.Render(item, "HotelName")),
                Address = new HtmlString(FieldRenderer.Render(item, "Address")),
                PhoneNumber = new HtmlString(FieldRenderer.Render(item, "PhoneNumber")),
                HotelEmail = new HtmlString(FieldRenderer.Render(item, "HotelEmail")),
                Facebook = GetLinkUrl(item, "Facebook"),
                Instagram = GetLinkUrl(item, "Instagram"),
                Twitter = GetLinkUrl(item, "Twitter"),
                FacebookPlaceholder = new HtmlString(FieldRenderer.Render(item, "FacebookPlaceholder")),
                TwitterPlaceholder = new HtmlString(FieldRenderer.Render(item, "TwitterPlaceholder")),
                InstagramPlaceholder = new HtmlString(FieldRenderer.Render(item, "InstagramPlaceholder")),
                SocialTitle = new HtmlString(FieldRenderer.Render(item, "SocialTitle")),
                Copywright = new HtmlString(FieldRenderer.Render(item, "Copywright")),
                Rooms = GetLinkUrl(item, "Rooms"),
                Dinning = GetLinkUrl(item, "Dinning"),
                ExploreTitle = new HtmlString(FieldRenderer.Render(item, "ExploreTitle")),
            };
            return View("/Views/SMEProject/BasicContent/Footer.cshtml", footerModel);
        }

        private string GetLinkUrl(Item item, string fieldName)
        {
            if (item == null || string.IsNullOrEmpty(fieldName))
                return null;

            LinkField linkField = item.Fields[fieldName];

            if (linkField != null)
            {
                if (linkField.IsInternal)
                {
                    // Use LinkManager to generate the URL for internal links
                    return LinkManager.GetItemUrl(linkField.TargetItem);
                }
                else
                {
                    // For external links or other link types
                    return linkField.Url;
                }
            }
            return null;
        }
    }
}
