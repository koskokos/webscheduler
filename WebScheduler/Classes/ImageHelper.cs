using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebScheduler.Classes
{
    public static class ImageHelper
    {
        public static int? GetImageHash(int? id)
        {
            return id ^ 1541014539;
        }
        public static IHtmlString Picture(this HtmlHelper Html, int? id, string alt)
        {
            return Html.Raw(String.Format("<img src=\"/Picture/Index/{0}\" alt=\"{1}\">",GetImageHash(id),alt));
        }
    }
}