using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMEProject.Foundation.Navigation.Models
{
    public class NavigationMenu
    {
        public NavigationItem HomePage { get; set; }
        public List<MainNavigation> MainNavigation { get; set; }
    }
}