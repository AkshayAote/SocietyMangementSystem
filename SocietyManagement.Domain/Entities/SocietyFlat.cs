using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Entities
{
    public class SocietyFlat
    {
        public int SocietyFlatId { get; set; }
        public int FlatNumber { get; set; }
        public int SocietyId { get; set; }

        public virtual ICollection<Members> Memberses { get; set; }
        public virtual Society Society { get; set; }

        public virtual ICollection<Visitors> Visitorses { get; set; }


    }
}
