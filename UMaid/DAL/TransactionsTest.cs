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
    
    public partial class TransactionsTest
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int ListingID { get; set; }
        public int BidID { get; set; }
        public Nullable<double> MaidRating { get; set; }
        public Nullable<double> CustomerRating { get; set; }
    
        public virtual BidsTest BidsTest { get; set; }
        public virtual ListingsTest ListingsTest { get; set; }
        public virtual UsersTest UsersTest { get; set; }
    }
}