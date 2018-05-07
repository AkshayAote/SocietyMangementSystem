using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Entities
{
    public class Visitors
    {
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string ReasonToVisit { get; set; }
        public int Idproof { get; set; }
        public int SocietyFlatId { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime OutDateTime { get; set; }
        public bool CheckInStatus { get; set; }
        public int? ImageId { get; set; }

        public virtual SocietyFlat SocietyFlat { get; set; }

        public static implicit operator Domain.Models.Visitors(Domain.Entities.Visitors visitor)
        {
            return new Domain.Models.Visitors
            {
                VisitFlatNumber = visitor.SocietyFlatId,
                MobileNumber = visitor.MobileNumber,
                VisitorFullName = visitor.Name,
                ReasonToVisit = visitor.ReasonToVisit,
                VisitorId = visitor.VisitorId,
                InDateTime = visitor.InDateTime,
                OutDateTime = visitor.OutDateTime,
                CheckInStatus = visitor.CheckInStatus
            };
        }
    }
}
