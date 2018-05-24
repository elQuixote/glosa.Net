using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Glosa.Net.Core.Interfaces;
using Glosa.Net.Core.Helpers;

namespace Glosa.Net.Core.Geometry
{
    public class GlosaPolyline : GlosaObject
    {
        public IVector[] vertices;
        public GlosaLineSegment[] segments;
        public bool closed;

        public GlosaPolyline()
        {

        }
        public GlosaPolyline(IVector[] verts, bool closed)
        {
            this.vertices = verts;
            this.closed = closed;
            GenerateSegmentsFromVertices(verts);
        }

        public GlosaPolyline(GlosaLineSegment[] segments)
        {
            this.segments = segments;
            GenerateVerticesFromSegments(segments);
        }

        private void GenerateVerticesFromSegments(GlosaLineSegment[] segments)
        {
            this.vertices = new IVector[this.segments.Length];
            int count = 0;
            foreach (GlosaLineSegment l in segments)
            {
                this.vertices[count] = l.startVertex;
                this.vertices[count] = l.endVertex;
                count++;
            }
        }

        private void GenerateSegmentsFromVertices(IVector[] vertices)
        {
            this.segments = new GlosaLineSegment[this.vertices.Length];
            int count = 0;
            for(int i = 0; i < vertices.Length -1; i++)
            {
                this.segments[count] = (new GlosaLineSegment(vertices[count], vertices[count + 1]));
                if (this.closed)
                {
                    this.segments[count+1] = (new GlosaLineSegment(vertices[vertices.Length-1], vertices[0]));
                }
                count++;
            }
        }
    }
}
