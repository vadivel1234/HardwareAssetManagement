﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Syncfusion.JavaScript;
using Asset_Management.DataModel;

namespace Asset_Management.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class EmployeeModel
    {
        public int Eid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string TeamName { get; set; }
        public string ReportingPerson { get; set; }
        public string Location { get; set; }
        public int RollId { get; set; }

        public int ReqId { get; set; }
        public int? AssetCount { get; set; }    

        public string ModelName { get; set; }

        public string AssetName { get; set; }

        public string VendorName { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime DueDate { get; set; }

        public List<EmployeeModel> GetEmployeeList(DataManager dataManager)
        {
            var employeeDetails = new List<EmployeeModel>();
            using (var entity = new AssetManagementEntities())
            {
                employeeDetails = (from employee in entity.Users
                                   join role in entity.UserRoles on employee.RoleId equals role.RoleId
                                   join location in entity.Locations on employee.LocationId equals location.LocationId
                                   where employee.IsActive
                                   select new EmployeeModel
                                   {
                                       Eid = employee.UserId,
                                       Name = employee.Name,
                                       Email = employee.Email,
                                       DateOfJoining = employee.CreatedDate,
                                       TeamName = employee.TeamName,
                                       Location = location.LocationName,
                                       AssetCount = employee.AssetCount,
                                       ReportingPerson = employee.ReportingPerson
                                   }).ToList();
            }
            return employeeDetails;            
        }

        public List<EmployeeModel> GetEmployeeAsset(DataManager dataManager, string email)
        {
            var employeeAssetDetails = new List<EmployeeModel>();
            using (var entity = new AssetManagementEntities())
            {
                employeeAssetDetails = (from user in entity.Users where user.Email == email
                                        join userReq in entity.UserRequests on user.UserId equals userReq.UserId
                                        join location in entity.Locations on userReq.LocationId equals location.LocationId
                                        join assetType in entity.AssetTypes on userReq.AssetType equals assetType.TypeId
                                        where userReq.IsActive && userReq.StatusId == 2
                                        select new EmployeeModel
                                        {
                                            ModelName = assetType.AssetTypeName,
                                            PurchaseDate = userReq.RequestedDate,
                                            DueDate = userReq.DueDate,
                                            TeamName = user.TeamName,
                                            Location = location.LocationName,
                                            ReportingPerson = user.ReportingPerson
                                        }).ToList();
            }
            return employeeAssetDetails;
        }

        public List<EmployeeModel> GetRequestAsset(DataManager dataManager)
        {
            var employeeAssetDetails = new List<EmployeeModel>();
            using (var entity = new AssetManagementEntities())
            {
                employeeAssetDetails = (from userReq in entity.UserRequests                                        
                                        join location in entity.Locations on userReq.LocationId equals location.LocationId
                                        join assetType in entity.AssetTypes on userReq.AssetType equals assetType.TypeId
                                        join user in entity.Users on userReq.UserId equals user.UserId
                                        where userReq.IsActive && userReq.StatusId == 1
                                        select new EmployeeModel
                                        {
                                            ReqId = userReq.RequestId,
                                            Eid = user.UserId,
                                            Email = user.Email,
                                            ModelName = assetType.AssetTypeName,
                                            TeamName = user.TeamName,
                                            Location = location.LocationName,
                                            ReportingPerson = user.ReportingPerson,
                                        }).ToList();
            }
            return employeeAssetDetails;
        }

        public bool IsAssetApproved(int reqId)
        {
            using (var entity = new AssetManagementEntities())
            {
                var approvedAsset = (from userReq in entity.UserRequests
                                     where userReq.RequestId == reqId && userReq.IsActive
                                     select userReq).FirstOrDefault();
                approvedAsset.StatusId = 2;
                entity.SaveChanges();
            }
            return true;
        }

        public List<EmployeeModel> GetPurchaseAsset(DataManager dataManager)
        {
            var purchaseAssetDetails = new List<EmployeeModel>();
            using (var entity = new AssetManagementEntities())
            {
                purchaseAssetDetails = (from purchaseReq in entity.PurchaseRequests
                                        join vendor in entity.VendorLists on purchaseReq.VendorId equals vendor.VendorId
                                        where purchaseReq.IsActive && purchaseReq.IsApproved == false && vendor.IsActive
                                        select new EmployeeModel
                                        {
                                            ReqId = purchaseReq.PurchaseRequestId,                                           
                                            ModelName = purchaseReq.ModelName,
                                            AssetName = purchaseReq.AssetName,
                                            VendorName = vendor.VendorName,
                                            PurchaseDate = purchaseReq.RequestedDate
                                        }).ToList();
            }
            return purchaseAssetDetails;
        }

        public bool IsAssetPurchased(int reqId)
        {
            using (var entity = new AssetManagementEntities())
            {
                var assetPurchase = (from userReq in entity.PurchaseRequests
                                     where userReq.PurchaseRequestId == reqId && userReq.IsActive
                                     select userReq).FirstOrDefault();
                assetPurchase.IsApproved = true;
                entity.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// Method to add the employee details
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="userRoleId"></param>
        /// <param name="locationId"></param>
        /// <param name="teamName"></param>
        /// <param name="reportingPerson"></param>
        /// <param name="assetCount"></param>
        public void AddEmployeeDetails( string userName, string userEmail, int userRoleId, int locationId, string teamName, string reportingPerson, int assetCount)
        {            
            AssetManagementEntities entity = new AssetManagementEntities();
            
            User addEmployeeDetails = new User()
            {                
                Name = userName,
                Email = userEmail,
                RoleId = userRoleId,
                LocationId = locationId,
                CreatedDate = DateTime.Now,
                IsActive = true,
                TeamName = teamName,
                ReportingPerson = reportingPerson,
                AssetCount = assetCount
            };
            entity.Users.Add(addEmployeeDetails);          
            entity.SaveChanges();            
        }

        /// <summary>
        /// Method to edit employee details 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="userRoleId"></param>
        /// <param name="locationId"></param>
        /// <param name="teamName"></param>
        /// <param name="reportingPerson"></param>
        /// <param name="assetCount"></param>
        public void EditEmployeeDetails(string userName, string userEmail, int userRoleId, int locationId, string teamName, string reportingPerson, int assetCount)
        {
            AssetManagementEntities entity = new AssetManagementEntities();
            User updateUserDetails = new User()
            {
                Name = userName,
                Email = userEmail,
                RoleId = userRoleId,
                LocationId = locationId,
                CreatedDate = DateTime.Now,
                IsActive = true,
                TeamName = teamName,
                ReportingPerson = reportingPerson,
                AssetCount = assetCount
            };
            entity.Users.Add(updateUserDetails);
            entity.SaveChanges();
        }

        /// <summary>
        /// Method to delete employee details
        /// </summary>
        /// <param name="userId"></param>
        public static void DeleteEmployeeDetails(int userId)
        {
            using (var context = new AssetManagementEntities())
            {
                var requestedItem = (from data in context.Users
                                     where data.UserId == userId
                                     select data).FirstOrDefault();
                if (requestedItem != null)
                {
                    context.Users.Remove(requestedItem);
                    context.SaveChanges();
                }
            }
        }
    }

    public class AssetModel
    {
        public int AsserId { get; set; }
        public string ModelName { get; set; }
        public DateTime DateOfPurChase { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public string AssetTypeName { get; set; }

        public List<AssetModel> GetAssetList(DataManager dataManager)
        {
            var assetDetails = new List<AssetModel>();
            using (var entity = new AssetManagementEntities())
            {
                assetDetails = (from asset in entity.Assets
                                join assetType in entity.AssetTypes on asset.AssetTypeId equals assetType.TypeId
                                where asset.IsActive
                                select new AssetModel
                                {
                                    AsserId = asset.Id,
                                    ModelName = asset.ModelName,
                                    AssetTypeName = assetType.AssetTypeName,
                                    DateOfPurChase = asset.DateOfPurchase,
                                    WarrantyExpiryDate = asset.WarrantyExpiryDate
                                }).ToList();
            }
            return assetDetails;
        }

        /// <summary>
        /// Method to add asset details 
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="assetModelName"></param>
        /// <param name="assetTypeId"></param>
        /// <param name="assetSerialNumber"></param>
        public void AddAssetDetails(string assetId, string assetModelName, int assetTypeId, string assetSerialNumber)
        {
            AssetManagementEntities entity = new AssetManagementEntities();

            Asset addAssetDetails = new Asset()
            {

                AssetId = assetId,
                ModelName = assetModelName,
                DateOfPurchase = DateTime.Now,
                WarrantyExpiryDate = DateTime.Now.AddYears(3),
                AssetTypeId= assetTypeId,
                SerialNo= assetSerialNumber,
                IsActive = true
            };
            entity.Assets.Add(addAssetDetails);
            entity.SaveChanges();
        }

        /// <summary>
        /// Method to Edit asset details 
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="assetModelName"></param>
        /// <param name="assetTypeId"></param>
        /// <param name="assetSerialNumber"></param>
        public void EditAssetDetails(string assetId, string assetModelName, int assetTypeId, string assetSerialNumber)
        {
            AssetManagementEntities entity = new AssetManagementEntities();

            Asset editAssetDetails = new Asset()
            {

                AssetId = assetId,
                ModelName = assetModelName,
                DateOfPurchase = DateTime.Now,
                WarrantyExpiryDate = DateTime.Now.AddYears(3),
                AssetTypeId = assetTypeId,
                SerialNo = assetSerialNumber,
                IsActive = true
            };
            entity.Assets.Add(editAssetDetails);
            entity.SaveChanges();
        }

        /// <summary>
        /// Method to delete asset details
        /// </summary>
        /// <param name="userId"></param>
        public static void DeleteAssetDetails(int id)
        {
            using (var context = new AssetManagementEntities())
            {
                var requestedItem = (from data in context.Assets
                                     where data.Id == id
                                     select data).FirstOrDefault();
                if (requestedItem != null)
                {
                    context.Assets.Remove(requestedItem);
                    context.SaveChanges();
                }
            }
        }


    }

    public class VendorModel
    {
        public int Id { get; set; }
        public string vendorName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<VendorModel> GetVendorList(DataManager dataManager)
        {
            var vendorDetails = new List<VendorModel>();
            using (var entity = new AssetManagementEntities())
            {
                vendorDetails = (from vendor in entity.VendorLists
                                where vendor.IsActive
                                select new VendorModel
                                {
                                    Id = vendor.VendorId,
                                    vendorName = vendor.VendorName,
                                    Email = vendor.Email,
                                    PhoneNumber = vendor.Phone
                                }).ToList();
            }
            return vendorDetails;
        }
    }
}
