using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaPolyline
    {
        public List<GlosaVector3> vertices;
        public List<GlosaLineSegment> segments;

        public GlosaPolyline(List<GlosaVector3> verts, List<GlosaLineSegment> segments)
        {
            this.vertices = verts;
            this.segments = segments;
        } 
    }
}
