//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RichDataControls
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReferenceTime
    {
        public int ID { get; set; }
        public int OverallPos { get; set; }
        public System.TimeSpan OverallTime { get; set; }
        public int SwimPos { get; set; }
        public System.TimeSpan SwimTime { get; set; }
        public int CyclePos { get; set; }
        public System.TimeSpan CycleTime { get; set; }
        public int RunPos { get; set; }
        public System.TimeSpan RunTime { get; set; }
        public string Type { get; set; }
    
        public virtual EventType EventType { get; set; }
    }
}
