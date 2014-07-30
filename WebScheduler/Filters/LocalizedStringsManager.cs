using System;
using System.Linq;
using System.Web;
using WebScheduler.Models;
using WebMatrix.WebData;


namespace WebScheduler.Filters
{
    public class LocalizedStringsManager
    {
        static Entities db = new Entities();
        int culture;
        static LocalizedStringsManager instance;

        public string Lang
        {
            get
            {
                return (from lang in db.Langs where lang.Id == this.culture select lang.Name).First();
            }
        }

        public static string StaticLang
        {
            get
            {
                return instance.Lang;
            }
        }

        public static bool IsInitialized
        {
            get { return instance != null; }
        }

        public static LocalizedStringsManager GetInstance()
        {
            if (instance == null) throw new InvalidOperationException();
            return instance;
        }

        public static void Initialize(HttpRequestBase request)
        {
            if (request.IsAuthenticated)
                instance = new LocalizedStringsManager((from user in db.UserData
                                                        where user.UserId == WebSecurity.CurrentUserId
                                                        select user.LangId).First());
            else if (request.Cookies["lang"] != null)
                instance = new LocalizedStringsManager(request.Cookies["lang"].Value);
            else throw new InvalidOperationException();
        }

        public static void Initialize(string lang)
        {
            instance = new LocalizedStringsManager(lang);
        }

        private LocalizedStringsManager(string culture)
        {
            this.culture = (from lang in db.Langs where lang.Name == culture select lang.Id).First();
        }

        private LocalizedStringsManager(int culture)
        {
            this.culture = culture;
        }


        public string this[string key]
        {
            get
            {
                return (from str in db.StringsLocalization
                        where str.LangId == culture && str.StringNames.Name == key
                        select str.LocalizedString).First();
            }
            set
            {
                StringsLocalization str = new StringsLocalization()
                {
                    LangId = culture,
                    StringNames = (from name in db.StringNames
                                   where name.Name == key
                                   select name).First()
                                ?? new StringNames() { Name = key },
                    LocalizedString = value
                };
                db.StringsLocalization.Add(str);
                db.SaveChanges();
            }
        }
    }
}