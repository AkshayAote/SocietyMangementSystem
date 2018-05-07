using SocietyManagement.Domain.Models;
using SocietyManagement.Interface.Repository;
using SocietyManagement.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyManagement.Service
{
    public class VisitorService: IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        public VisitorService(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
                
        }

        public bool RecordVisitor(Visitors visitor)
        {
            var visitorEntity = new Domain.Entities.Visitors()
            {
                CheckInStatus = visitor.CheckInStatus,
                Idproof = 1,
                InDateTime = DateTime.Now,
                MobileNumber = visitor.MobileNumber,
                Name = visitor.VisitorFullName,
                OutDateTime = DateTime.Now,
                ReasonToVisit = visitor.ReasonToVisit,
                SocietyFlatId = visitor.VisitFlatNumber,

            };

            visitorEntity.ImageId = visitor.ImageId == 0 && visitor.ImageData != null ? AddImage(visitor.ImageData) : visitor.ImageId;
            
            return _visitorRepository.RecordVisitor(visitorEntity);
        }

        public int AddImage(string imageData)
        {
            if (imageData != null)
            {
                var imageDataString = imageData.Split(',')[1];
                byte[] imageBase64ConvertedData = Convert.FromBase64String(imageDataString);

                var imageObj = new Domain.Entities.Image()
                {
                    ImageData = imageBase64ConvertedData
                };

                var imageId = _visitorRepository.AddImageOfIdProof(imageObj);
                return imageId;
            }
            return 0;

        }

    }


}
