using System;
using System.Collections.Generic;

namespace OohInterview.DAL.Pocos
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public IEnumerable<Face> Faces { get; set; }

        public Campaign()
        {
            Name = string.Empty;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            
            Faces = new List<Face>();
        }
    }
}