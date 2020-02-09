using System;
using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL
{
    public class DataContext
    {
        public IList<Face> Faces { get; set; }
        public IList<Campaign> Campaigns { get; set; }

        public DataContext()
        {
            Faces = new List<Face>();
            Campaigns = new List<Campaign>();
            
            InitializeData();
        }

        private void InitializeData()
        {
            var firstFace = new Face()
            {
                Id = Guid.NewGuid(),
                Name = "First face"
            };
            
            Faces.Add(firstFace);
            
            Campaigns.Add(new Campaign
            {
                Id = Guid.NewGuid(),
                Name = "First Campaign",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 12, 31),
                Faces = new List<Face> { firstFace }
            });
        }
    }
}