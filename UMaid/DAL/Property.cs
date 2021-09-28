//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            this.Listings = new HashSet<Listing>();
            this.Pictures = new HashSet<Picture>();
        }
    
        public int PropertyID { get; set; }
        public int userID { get; set; }
        public Nullable<double> priceLight { get; set; }
        public Nullable<double> priceMedium { get; set; }
        public Nullable<double> priceHeavy { get; set; }
        public int AddressID { get; set; }
        public Nullable<double> latitude { get; set; }
        public Nullable<double> longitude { get; set; }
        public Nullable<int> numBedrooms { get; set; }
        public Nullable<int> numBathrooms { get; set; }
        public Nullable<int> size { get; set; }
        public Nullable<int> isVacant { get; set; }
        public Nullable<int> hasPets { get; set; }
        public string description { get; set; }
    
        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Listing> Listings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual User User { get; set; }
    }
}