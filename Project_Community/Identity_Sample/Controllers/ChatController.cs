using Identity_Sample.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Identity_Sample.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Chat()
        {
            ViewBag.Token = MD5Helper.GetMd5Hash(TokenHelper.GetToken(User.Identity.Name));

            return View();
        }
    }
}