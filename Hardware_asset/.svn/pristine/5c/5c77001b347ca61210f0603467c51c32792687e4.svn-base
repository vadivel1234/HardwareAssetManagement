using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Asset_Management.DataModel;

namespace Asset_Management.Models
{
    public class AssetManagement
    {
        [Required(ErrorMessage = "Please enter asset name")]
        public string AssetName { get; set; }

        [Required(ErrorMessage = "Please enter model name")]
        public string ModelName { get; set; }

        public static MultiSelectList VendorList { get; set; }

        public int VendorName { get; set; }

        public string Comments { get; set; }

        public static MultiSelectList GetVendorList()
        {
            try
            {
                using (AssetManagementEntities assetEntities = new AssetManagementEntities())
                {
                    var vendorList = (from vendorTypeList in assetEntities.VendorLists
                                      select new
                                      {
                                          id = vendorTypeList.VendorId,
                                          name = vendorTypeList.VendorName
                                      }).ToDictionary(x => x.id, y => y.name);
                    return new SelectList(vendorList.OrderBy(k => k.Value), "Key", "Value");
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public bool LogPurchaseRequest(AssetManagement assetManagement)
        {
            bool isSuccess = false;
            try
            {
                using (AssetManagementEntities assetEntities = new AssetManagementEntities())
                {
                    var purchaseRequest = new PurchaseRequest();
                    purchaseRequest.AssetName = assetManagement.AssetName == null ? "Assert" : assetManagement.AssetName;
                    purchaseRequest.ModelName = assetManagement.ModelName == null ? "ModelName" : assetManagement.ModelName;
                    purchaseRequest.VendorId = assetManagement.VendorName;
                    purchaseRequest.Comments = assetManagement.Comments != null ? Comments : "Comments here";
                    purchaseRequest.RequestedDate = DateTime.Now;
                    purchaseRequest.IsApproved = false;
                    purchaseRequest.IsActive = true;
                    assetEntities.PurchaseRequests.Add(purchaseRequest);
                    assetEntities.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }
    }

    public class DeviceRequest
    {
        public int LocationId { get; set; }

        public int AssetTypeId { get; set; }
        public string Description { get; set; }

    }
    public class AssertTypeDetails
    {
        public static MultiSelectList LocationList()
        {
            using (AssetManagementEntities assetEntities = new AssetManagementEntities())
            {
                var location = (from loc in assetEntities.Locations
                                select new
                                {
                                    id = loc.LocationId,
                                    name = loc.LocationName
                                }).ToDictionary(x => x.id, y => y.name);
                return new SelectList(location.OrderBy(k => k.Value), "Key", "Value");
            }
        }
        public static MultiSelectList AssetTypeList()
        {

            using (AssetManagementEntities assetEntities = new AssetManagementEntities())
            {
                var location = (from loc in assetEntities.AssetTypes
                                select new
                                {
                                    id = loc.TypeId,
                                    name = loc.AssetTypeName
                                }).ToDictionary(x => x.id, y => y.name);
                return new SelectList(location.OrderBy(k => k.Value), "Key", "Value");
            }
        }
        public static bool LogDeviceRequest(DeviceRequest deviceRequest)
        {
            bool isSuccess = false;
            var user = new MemberService().GetUser(HttpContext.Current.User.Identity.Name);
            try
            {
                using (AssetManagementEntities assetEntities = new AssetManagementEntities())
                {
                    var DevRequest = new UserRequest();
                    DevRequest.AssetType = deviceRequest.AssetTypeId;
                    DevRequest.Description = deviceRequest.Description == null ? "Provide Device" : deviceRequest.Description;
                    DevRequest.LocationId = deviceRequest.LocationId;
                    DevRequest.RequestedDate = DateTime.Now;
                    DevRequest.IsActive = true;
                    DevRequest.DueDate = DateTime.Now.AddDays(30);
                    DevRequest.StatusId = 1;
                    DevRequest.UserId = user.UserId;
                    assetEntities.UserRequests.Add(DevRequest);
                    assetEntities.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }
    }
}