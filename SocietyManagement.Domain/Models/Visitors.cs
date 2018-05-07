using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Models
{
    public class Visitors
    {
        public int VisitorId { get; set; }
        public string VisitorFullName { get; set; }
        public string MobileNumber { get; set; }
        public string ReasonToVisit { get; set; }
        public int Idproof { get; set; }
        public int VisitFlatNumber { get; set; }
        public string ImageData { get; set; }
        public int ImageId { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime OutDateTime { get; set; }
        public bool CheckInStatus { get; set; }
        public int SocietyFlatId { get; set; }
        public bool IsBarcode { get; set; }
    }
}
