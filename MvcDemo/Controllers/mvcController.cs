using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
namespace MvcDemo.Controllers
{
    public class mvcController : Controller
    {
        // GET: mvc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult detailsIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult mvcIndex()
        {
            return View();

        }
        public ActionResult SaveReg(RegistrationModel model)
        {
            try

            {
                return Json(new { message = new RegistrationModel().SaveReg(model)}, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRegistrationList()
        {
            try

            {
                return Json(new { model = new RegistrationModel().GetRegistrationList() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new {model= ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deleteregistration(int Id)
        {
            try

            {
                return Json(new { model = new RegistrationModel().deleteregistration(Id) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRegisterbyId(int Id)
        {
            try

            {
                return Json(new { model = new RegistrationModel().GetRegisterbyId(Id) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}