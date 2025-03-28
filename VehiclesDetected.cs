//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FidelParkingManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehiclesDetected
    {
        public int TicketNumber { get; set; }
        public string Operation { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public System.DateTime EntryDate { get; set; }
        public System.TimeSpan EntryTime { get; set; }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public Nullable<System.TimeSpan> ExitTime { get; set; }
        public string Duration { get; set; }
        public Nullable<int> PaymentId { get; set; }
        public Nullable<int> MediaId { get; set; }
    
        public virtual Medium Medium { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
