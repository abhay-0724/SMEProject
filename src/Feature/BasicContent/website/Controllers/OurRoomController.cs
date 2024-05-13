﻿using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using SMEProject.Feature.BasicContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Web.UI.WebControls;

namespace SMEProject.Feature.BasicContent.Controllers
{
    public class OurRoomController : Controller
    {
        // GET: OurRoom
        public ActionResult OurRoom()
        {
            Item item = Sitecore.Context.Item;
            List<OurRoom> selectedItemsData = new List<OurRoom>();
            MultilistField roomList = item.Fields["RoomList"];
            if (roomList != null)
            {
                selectedItemsData = roomList.GetItems()
                                        .Select(x => new Models.OurRoom
                                        {
                                            RoomImage = GetImageUrl(x, "RoomImage"),
                                            RoomImageAlt = GetImagealt(x, "RoomImage"),
                                            RoomDescription = new HtmlString(FieldRenderer.Render(x, "RoomDescription")),
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
    }
}