//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Athlete { get; set; }
        public string Type { get; set; }
        public System.TimeSpan SwimTime { get; set; }
        public System.TimeSpan CycleTime { get; set; }
        public System.TimeSpan RunTime { get; set; }
        public System.TimeSpan OverallTime { get; set; }
    
        public virtual Athlete Athlete1 { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
