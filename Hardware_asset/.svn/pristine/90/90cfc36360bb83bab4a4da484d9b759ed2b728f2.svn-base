using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asset_Management.Models;
using Asset_Management.DataModel;
namespace Asset_Management.Controllers
{
    public class AssetManagementController : Controller
    {
        // GET: AssetManagement
        [HttpGet]
        [Authorize]
        public ActionResult PurchaseRequest()
        {
            AssetManagement assetManagement = new AssetManagement();
            return View(assetManagement);
        }

        [HttpPost]
        [Authorize]
        public ActionResult PurchaseRequest(AssetManagement assetManagement)
        {
            assetManagement.LogPurchaseRequest(assetManagement);
            TempData["PurchaseRequest"] = true;
            return Redirect("/");
        }

        public ActionResult DeviceList()
        {            
            return View();
        }

        public ActionResult RequestDevice(string devicetype)
        {
            var deviceRequest = new DeviceRequest();
            var devices = AssertTypeDetails.AssetTypeList();
            devices.Where(item => item.Text.ToLower() == devicetype).FirstOrDefault().Selected = true;
            ViewBag.devicetype = devices;
            return View(deviceRequest);
        }
        

        [HttpPost]        
        public ActionResult RequestDevice(DeviceRequest deviceRequest)
        {
            AssertTypeDetails.LogDeviceRequest(deviceRequest);
            TempData["DeviceRequest"] = true;
            return Redirect("/");
        }
    }
}