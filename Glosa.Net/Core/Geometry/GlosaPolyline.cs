using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaPolyline
    {
        [DllImport("wrapper_path.dll")]
        private static extern GlosaPolyline createPolyline(List<GlosaLineSegment> segments);

        public List<GlosaVector3> vertices;
        public List<GlosaLineSegment> segments;

        public GlosaPolyline(List<GlosaVector3> verts, List<GlosaLineSegment> segments)
        {
            this.vertices = verts;
            this.segments = segments;
        } 

        public static GlosaPolyline CreatePolyline(List<GlosaLineSegment> segs)
        {
            return createPolyline(segs);
        }
    }
}
