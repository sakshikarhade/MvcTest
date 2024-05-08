using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcTest.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult InfoIndex()
        {
            return View();
        }

        public ActionResult SaveInfo(InformationModel model)
        {
            try
            {
                return Json(new { Message = new InformationModel().SaveInfo(model) }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetInformationList()
        {
            try
            {
                return Json(new {model = new InformationModel().GetInformationList() }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new {model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}