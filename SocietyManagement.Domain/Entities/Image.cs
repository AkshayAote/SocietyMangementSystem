using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public virtual ICollection<Members> Memberses { get; set; }
    }
}

