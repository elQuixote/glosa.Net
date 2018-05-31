using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Glosa.Net.Core.Interfaces;
using Glosa.Net.Core.Helpers;
using Glosa.Net.Core.Helpers.Json;

namespace Glosa.Net.Core.Geometry
{
    public class GlosaPolygon : GlosaObject
    {

        public GlosaPolyline polyline;

        public GlosaPolygon(IVector[] verts)
        {

        }

        public GlosaPolygon(GlosaLineSegment[] segments)
        {

        }

        public GlosaPolygon(GlosaPolyline polyline)
        {
            this.polyline = polyline;
        }
    }
}
