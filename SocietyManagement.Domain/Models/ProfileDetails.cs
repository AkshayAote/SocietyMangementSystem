using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Models
{
    public class ProfileDetails
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public List<string> SubMembers { get; set; }
        public string FlatName{ get; set; }
        public int FlatNumber { get; set; }

    }
}
