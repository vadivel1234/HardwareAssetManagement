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
    
    public partial class UserRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRequest()
        {
            this.UserRequestAssetMappers = new HashSet<UserRequestAssetMapper>();
        }
    
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int AssetType { get; set; }
        public int StatusId { get; set; }
        public System.DateTime RequestedDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    
        public virtual AssetType AssetType1 { get; set; }
        public virtual RequestStatu RequestStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRequestAssetMapper> UserRequestAssetMappers { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual UserRole UserRole1 { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
    }
}