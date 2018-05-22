using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaLineSegment
    {
        [DllImport("wrapper_path.dll")]
        private static extern GlosaLineSegment segmentFromVectors(GlosaVector3 v1, GlosaVector3 v2);

        public GlosaVector3 sp, ep;

        public GlosaLineSegment(IVector startVertex, IVector endVertex)
        {
            this.sp = (GlosaVector3)startVertex;
            this.ep = (GlosaVector3)endVertex;
        }

        public static GlosaLineSegment SegmentFromVectors(IVector startVertex, IVector endVertex)
        {
            return segmentFromVectors((GlosaVector3)startVertex, (GlosaVector3)endVertex);
        }
        /*
        public static GlosaLineSegment SegmentFromVectors_B(IVector startVertex, IVector endVertex)
        {        
            //IntPtr p = segmentFromVectors(startVertex, endVertex);
            //GlosaLineSegment obj = (GlosaLineSegment)Marshal.PtrToStructure(p, typeof(GlosaLineSegment));
            //return obj;
            //return segmentFromVectors(startVertex, endVertex);
        }
        */
    }
}
