using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScheduler.Classes;
using WebScheduler.Models;

namespace WebScheduler.Controllers
{
    public class PictureController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Picture/Index/1232134

        public ActionResult Index(string id)
        {
                byte[] image = db.Images.Find(ImageHelper.GetImageHash(int.Parse(id))).Image;
                MemoryStream ms = new MemoryStream(image);
                string format;
                if (Image.FromStream(ms).RawFormat == ImageFormat.Gif)
                    format = "image/gif";
                else if (Image.FromStream(ms).RawFormat == ImageFormat.Jpeg)
                    format = "image/jpeg";
                else if (Image.FromStream(ms).RawFormat == ImageFormat.Png)
                    format = "image/png";
                else format = "image/jpeg";
                    return base.File(image, format);
        }

    }
}
