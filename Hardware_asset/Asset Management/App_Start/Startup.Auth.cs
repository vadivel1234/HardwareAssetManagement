using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Asset_Management.Models;


namespace Asset_Management
{
    public static partial class Startup
    {
        /// <summary>
        /// Client id for outlook 365 connect
        /// </summary>
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];

        /// <summary>
        /// Add instance for outlook 365 connect
        /// </summary>
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];

        /// <summary>
        /// Assign Tenant value
        /// </summary>
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];

        /// <summary>
        /// Redirect link 
        /// </summary>
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];

        /// <summary>
        /// Redirect link 
        /// </summary>
        private static string redirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];

        /// <summary>
        /// Authority value
        /// </summary>
        private static string authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        /// <summary>
        /// configure cookies
        /// </summary>
        /// <param name="app">app builder value</param>
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseKentorOwinCookieSaver();
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                CookieName = "Staging",
            });
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    RedirectUri = redirectUri,
                    UseTokenLifetime = false,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        SecurityTokenValidated = context =>
                        {
                            string returnUrl = context.AuthenticationTicket.Properties.RedirectUri;
                            context.AuthenticationTicket.Properties.RedirectUri = "/members/register?returnUrl=" + returnUrl;
                            return Task.FromResult(0);
                        },
                        AuthenticationFailed = context =>
                        {
                            if (context.Exception.Message.StartsWith("OICE_20004") || context.Exception.Message.Contains("IDX10311"))
                            {
                                context.SkipToNextMiddleware();
                                context.Response.Redirect("/members/register");
                                return Task.FromResult(0);
                            }

                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}