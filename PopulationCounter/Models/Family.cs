//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PopulationCounter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Family
    {
        public int houseNo { get; set; }
        public int totalPerson { get; set; }
        public int totalMale { get; set; }
        public int totalFemale { get; set; }
        public int totalChild { get; set; }
        public string street { get; set; }
        public string village { get; set; }
        public string taluka { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pincode { get; set; }
    }
}
