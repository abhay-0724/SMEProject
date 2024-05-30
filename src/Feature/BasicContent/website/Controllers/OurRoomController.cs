using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using SMEProject.Feature.BasicContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Web.UI.WebControls;
using Sitecore.Mvc.Presentation;
using Sitecore.Links;

namespace SMEProject.Feature.BasicContent.Controllers
{
    public class OurRoomController : Controller
    {
        // GET: OurRoom
        public ActionResult OurRoom()
        {
            Item item = RenderingContext.Current.Rendering.Item;
           
            List<OurRoom> selectedItemsData = new List<OurRoom>();
            MultilistField roomList = item.Fields["RoomList"];
            if (roomList != null)
            {
                selectedItemsData = roomList.GetItems()
                                        .Select(x => new Models.OurRoom
                                        {   
                                            BookingForm = GetLinkUrl(x,"BookingPage"),
                                            RoomImage = GetImageUrl(x, "RoomImage"),
                                            RoomImageAlt = GetImagealt(x, "RoomImage"),
                                            RoomIntro = new HtmlString(FieldRenderer.Render(x, "RoomIntro")),
                                            RoomService = new HtmlString(FieldRenderer.Render(x, "RoomService")),
                                            RoomSpecial = new HtmlString(FieldRenderer.Render(x, "RoomSpecial")),
                                        }).ToList();

            }
            return View("/Views/SMEProject/BasicContent/OurRoom.cshtml", selectedItemsData);

        }
        private string GetImageUrl(Item item, string fieldName)
        {
            ImageField imageField = item.Fields[fieldName];
            return MediaManager.GetMediaUrl(imageField.MediaItem);
        }
        private string GetImagealt(Item item, string fieldName)
        {
            ImageField imageField = item.Fields[fieldName];
            return imageField.Alt;
      
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