using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using WebScheduler.Filters;

namespace WebScheduler.Models
{
    public class UserDataViewModel
    {

        public UserDataViewModel() { }

        public UserDataViewModel(int id)
            : this((from users in (new Entities()).UserData
                                       where users.UserId == WebSecurity.CurrentUserId
                                       select users).First())
        {
        }

        public UserDataViewModel(UserData source) 
        {
            this.UserId = source.UserId;
            this.UserProperties = source.UserProperties.ToList();
            this.Name = source.Name;
            this.Surname = source.Surname;
            this.SecondName = source.SecondName;
            this.BirthDate = source.BirthDate;
            this.PictureId = source.PictureId;
            //this.Picture = (new MemoryStream(source.Picture));
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public int? PictureId { get; set; }

        [ValidateImage(ErrorMessage = "Image must be less than 1 MB and have format png, jpeg or gif.")]
        public HttpPostedFileBase Picture { get; set; }
        public int LangId { get; set; }

        public List<UserProperties> UserProperties { get; set; }

        public UserData ToUserData()
        {
            UserData userdata = new UserData
            {
                UserId = this.UserId,
                Name = this.Name,
                Surname = this.Surname,
                SecondName = this.SecondName,
                BirthDate = this.BirthDate,
                LangId = this.LangId,
                
            };
            if (this.UserProperties != null) userdata.UserProperties = (from property in this.UserProperties
                                                                        where property.Name != null && property.Value !=null
                                                                        select property).ToList();
            if (Picture != null)
            {
                MemoryStream ms = new MemoryStream();
                Image img = Image.FromStream(this.Picture.InputStream);
                img.Save(ms, img.RawFormat);
                userdata.Images = new Images { Image = ms.ToArray() };
            }
            return userdata;
        }

    }
}