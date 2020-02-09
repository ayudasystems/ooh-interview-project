using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace OohInterview.Queries.Faces.List
{
    public class ListFacesResult
    {
        public IReadOnlyCollection<Face> Faces { get; }

        public ListFacesResult(IEnumerable<Face> faces)
        {
            Faces = faces.ToImmutableList();
        }

        public class Face
        {
            public Guid Id { get; }
            public string Name { get; }

            public Face(Guid id, string name)
            {
                if (id == Guid.Empty)
                    throw new ArgumentException($"{nameof(Face)} {nameof(Id)}");

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException($"{nameof(Face)} {nameof(Name)}");

                Id = id;
                Name = name;
            }
        }
    }
}