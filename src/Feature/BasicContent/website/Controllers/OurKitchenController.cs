using Sitecore.Data.Fields;
using Sitecore.Data.Items;
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
    public class OurKitchenController : Controller
    {
        // GET: OurKitchen
        public ActionResult OurKitchen()
        {
            Item item = Sitecore.Context.Item;
            List<OurKitchen> selectedItemsData = new List<OurKitchen>();
            MultilistField menuList = item.Fields["Meals"];
            if (menuList != null)
            {
                selectedItemsData = menuList.GetItems()
                                        .Select(x => new Models.OurKitchen
                                        {
                                            Image = GetImageUrl(x, "MealImage"),
                                            ImageAlt = GetImagealt(x, "MealImage"),
                                            Title = x.Fields["MealTitle"].Value,
                                        }).ToList();
                
            }
            return View("/Views/SMEProject/BasicContent/OurKitchen.cshtml",selectedItemsData);

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
    }
}