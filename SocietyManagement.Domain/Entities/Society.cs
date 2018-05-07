using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Entities
{
    public class Society
    {
        public int SocietyId { get; set; }
        public string SocietyName { get; set; }
        public string Notice { get; set; }

        public virtual SocietyFlat SocietyFlat { get; set; }
    }
}
