﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asset_Management.Models;
using System.Security.Claims;
using System.Web.Security;

namespace Asset_Management.Controllers
{
    public class MembersController : Controller
    {
        // GET: Mmeber
        public ActionResult Register(string returnUrl)
        {
            var membershipService = new MemberService();
            var user = membershipService.GetUser(HttpContext.User.Identity.Name);
            if (user == null)
            {
                user = membershipService.AddUser(HttpContext.User.Identity.Name);                
            }
            return Redirect(returnUrl == null ? "/" : returnUrl);
        }
    }
}
