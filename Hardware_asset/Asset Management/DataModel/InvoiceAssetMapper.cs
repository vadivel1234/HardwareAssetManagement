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
    
    public partial class InvoiceAssetMapper
    {
        public int InvoiceAssetMapperId { get; set; }
        public int AssetId { get; set; }
        public int InvoiceId { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
