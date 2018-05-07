using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Entities
{
    public class FlatMemberType
    {
        public int FlatMemberId { get; set; }
        public string FlatMemberTypeName { get; set; }

        public virtual ICollection<Members> Memberses { get; set; }
    }
}
