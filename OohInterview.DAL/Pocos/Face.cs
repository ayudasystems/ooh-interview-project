using System;

namespace OohInterview.DAL.Pocos
{
    public class Face
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Face()
        {
            Name = string.Empty;
        }
    }
}