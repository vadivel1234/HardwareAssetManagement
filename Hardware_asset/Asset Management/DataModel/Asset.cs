//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asset_Management.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset()
        {
            this.InvoiceAssetMappers = new HashSet<InvoiceAssetMapper>();
            this.UserRequestAssetMappers = new HashSet<UserRequestAssetMapper>();
        }
    
        public int Id { get; set; }
        public string AssetId { get; set; }
        public string ModelName { get; set; }
        public System.DateTime DateOfPurchase { get; set; }
        public System.DateTime WarrantyExpiryDate { get; set; }
        public int AssetTypeId { get; set; }
        public string SerialNo { get; set; }
        public bool IsActive { get; set; }
    
        public virtual AssetType AssetType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceAssetMapper> InvoiceAssetMappers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRequestAssetMapper> UserRequestAssetMappers { get; set; }
    }
}