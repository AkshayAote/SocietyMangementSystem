using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Interface.Repository;
using SocietyManagement.Infrastructure.Data.DatabaseContext;
using SocietyManagement.Domain.Models;

namespace SocietyManagement.Infrastructure.Data.Repository
{
    public class SocietyMangementRepository : ISocietyMangementRepository
    {
        private readonly SocietyManagementDBContext _societyManagementDbContext;

        public SocietyMangementRepository(SocietyManagementDBContext societyManagementDbContext)
        {
            _societyManagementDbContext = societyManagementDbContext;
        }

        public List<Members> GetAllMembers()
        {
            var test = _societyManagementDbContext.Members.ToList();
            return test;
        }

        public void AddFlatMember(Members member)
        {
            try
            {
                if (member != null)
                {

                    _societyManagementDbContext.Members.Add(member);
                    _societyManagementDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

        }
        public IEnumerable<Domain.Models.Visitors> GetVisitors(int flatId)
        {
            var visitorsList = _societyManagementDbContext.Visitorses.
                                Join(_societyManagementDbContext.SocietyFlats, sfwv => sfwv.SocietyFlatId, sf => sf.SocietyFlatId, (sfwv, sf) => new { SFWV = sfwv, SF = sf })
                                .Where(x => x.SF.FlatNumber == flatId).ToList();



            var newDomainvisitorList = new List<Domain.Models.Visitors>();
            foreach (var vl in visitorsList)
            {
                var visitor = new Domain.Models.Visitors
                {
                    Idproof = vl.SFWV.Idproof,
                    MobileNumber = vl.SFWV.MobileNumber,
                    VisitorFullName = vl.SFWV.Name,
                    ReasonToVisit = vl.SFWV.ReasonToVisit,
                    VisitorId = vl.SFWV.VisitorId,
                    VisitFlatNumber = vl.SF.FlatNumber,
                    InDateTime = vl.SFWV.InDateTime,
                    OutDateTime = vl.SFWV.OutDateTime,
                    CheckInStatus = vl.SFWV.CheckInStatus,
                    ImageData = vl.SFWV.ImageId != null ?GetImageString(vl.SFWV.ImageId.Value):""
                };

                newDomainvisitorList.Add(visitor);
            }

            return newDomainvisitorList;
        }

        private string GetImageString(int imageId)
        {
            var imageObj = _societyManagementDbContext.Images.SingleOrDefault(x => x.Id == imageId);
            var imageDataString = Convert.ToBase64String(imageObj.ImageData);
            return imageDataString;
        }


        public IEnumerable<Domain.Models.Society> GetSocietyList()
        {
            var societyList = _societyManagementDbContext.Societies.ToList();

            if(societyList.Count > 0)
            {
                return societyList.Select(itm => new Domain.Models.Society
                {
                    SocietyId = itm.SocietyId,
                    SocietyName = itm.SocietyName
                });
            }

            return new List<Domain.Models.Society>();
        }

        public IEnumerable<Domain.Models.SocietyFlat> GetFlatsBySociety(int societyId)
        {
            var flatList = _societyManagementDbContext.SocietyFlats.Where(x => x.SocietyId == societyId).ToList();
            if(flatList.Count > 0)
            {
                return flatList.Select(itm => new Domain.Models.SocietyFlat
                {
                    FlatNumber = itm.FlatNumber,
                    SocietyFlatId = itm.SocietyFlatId,
                    SocietyId = itm.SocietyId
                }).ToList();
            }

            return new List<Domain.Models.SocietyFlat>();
        }

        public Domain.Models.ProfileDetails GetProfileDetails(string userName,string password)
        {
            var profileDetails = new ProfileDetails();
            var loggedInUser = _societyManagementDbContext.Members.Join(_societyManagementDbContext.SocietyFlats, sfwm => sfwm.SocietyFlatId, sf => sf.SocietyFlatId, (sfwm, sf) => new { SFWM = sfwm, SF = sf })
                                .Join(_societyManagementDbContext.Societies, sfws => sfws.SF.SocietyId, s => s.SocietyId, (sfws, s) => new { SFWS = sfws, S = s }).SingleOrDefault(x => x.SFWS.SFWM.UserName.Equals(userName) && x.SFWS.SFWM.Password.Equals(password));
            if(loggedInUser != null)
            {
                profileDetails.FullName = loggedInUser.SFWS.SFWM.FirstName + " "+ loggedInUser.SFWS.SFWM.LastName;
                profileDetails.SubMembers = _societyManagementDbContext.Members.Where(x => x.SocietyFlatId == loggedInUser.SFWS.SFWM.SocietyFlatId && !x.UserName.Equals(userName)).Select(itm=>itm.FirstName+" "+itm.LastName).ToList();
                profileDetails.FlatName = loggedInUser.S.SocietyName;
                profileDetails.FlatNumber = loggedInUser.SFWS.SF.FlatNumber;
                profileDetails.MemberId = loggedInUser.SFWS.SFWM.MemberId;
            }

            return profileDetails;

        }

        public void AddFamilyMember(Domain.Models.Member member)
        {
            var loggedInMember = _societyManagementDbContext.Members.SingleOrDefault(x => x.MemberId == member.MemberId);

            if (loggedInMember != null)
            {
                var memberObj = new Domain.Models.Member
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    FlatMemberTypeId = member.FlatMemberTypeId,
                    SocietyFlatId = loggedInMember.SocietyFlatId,
                    RoleId = (int)Domain.Enums.Role.Normal,
                    
                };
                _societyManagementDbContext.Add(memberObj);
            }

        }

    }
}
