using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Domain.Entities
{
    public class Members
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentCity { get; set; }
        public string HomeTown { get; set; }
        public string OccupationType { get; set; }
        public string CompanyName { get; set; }
        public string MobileNumber { get; set; }
        public int FlatMemberTypeId { get; set; }
        //public int Id { get; set; }
        public int SocietyFlatId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual FlatMemberType FlatMemberType { get; set; }
        public virtual Image Image { get; set; }
        public virtual SocietyFlat SocietyFlat { get; set; }

        public virtual Role  Role{ get; set; }


    }
}
