using System.Collections.Generic;
using System.Linq;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.UnitTests.Mocks
{
    internal class MockDataContext : DataContext
    {
        public MockDataContext()
            : base(false)
        {
        }

        public void SetFaces(IEnumerable<Face> faces)
        {
            this.Faces = faces.ToList();
        }
    }
}