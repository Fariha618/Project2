using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.BLL.BLL;

namespace BusinessManagementSystem.Controllers
{
    public class BusinessController : Controller
    {
        BusinessManager _businessManager = new BusinessManager();

        // GET: Business
        public ActionResult Index()
        {
            return View();
        }
    }
}