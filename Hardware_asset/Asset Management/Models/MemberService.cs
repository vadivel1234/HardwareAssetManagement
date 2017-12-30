using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asset_Management.DataModel;
using System.Net;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Asset_Management.Models
{
    public class MemberService
    {
        public User GetUser(string email)
        {
            var user = new User();
            using (var entity = new AssetManagementEntities())
            {
                user = entity.Users.Where(employee => employee.Email == email).FirstOrDefault();
            }
            return user;
        }
        public User AddUser(string email)
        {
            var user = new User();
            user.Email = email;
            user.AssetCount = 1;
            user.IsActive = true;
            user.LocationId = 1;
            user.Name = email;
            user.ReportingPerson = "Vijay";
            user.TeamName = "Syncfusion";
            user.RoleId = 1;
            user.CreatedDate = DateTime.Now;
            using (var entity = new AssetManagementEntities())
            {
                entity.Users.Add(user);
                entity.SaveChanges();
            }
            return user;
        }
        public static void UpdateLoggedUserProfileImageFromHRPortal()
        {
            if (HttpContext.Current.Request.IsAuthenticated && HttpContext.Current.Session["UserProfileImage"] == null)
            {
                var Imageurl = ConfigurationManager.AppSettings["HRPortalAPI"] + "getprofileimage?apikey=" +
                          ConfigurationManager.AppSettings["HRPortalAPIKey"] + "&emailid=" + HttpContext.Current.User.Identity.Name + "&size=64";
                string profileImage = string.Empty;
                using (WebClient client = new WebClient())
                {
                    profileImage = client.DownloadString(Imageurl);
                }

                HttpContext.Current.Session["UserProfileImage"] = string.IsNullOrEmpty(profileImage) ? null : JObject.Parse(profileImage).SelectToken("ProfileImageUrl").Value<string>();
            }
        }
    }
}