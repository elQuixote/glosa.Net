using Glosa.Net.Core.Interfaces;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Geometry.Vector;

namespace Glosa.Net.Core.Geometry.Shape
{
    /// <summary>
    /// 
    /// </summary>
    public struct GlosaLineSegment
    {
        #region C Reference Functions
        [DllImport("wrapper_path.dll")]
        private static extern GlosaLineSegment segmentFromVectors(GlosaVector3 v1, GlosaVector3 v2);
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public IVector startVertex, endVertex;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startVertex"></param>
        /// <param name="endVertex"></param>
        public GlosaLineSegment(IVector startVertex, IVector endVertex)
        {
            this.startVertex = startVertex;
            this.endVertex = endVertex;
        }
        #endregion

        #region Methods
        /*
        public static GlosaLineSegment SegmentFromVectors(IVector startVertex, IVector endVertex)
        {
            return segmentFromVectors((GlosaVector3)startVertex, (GlosaVector3)endVertex);
        }
        */
        /*
        public static GlosaLineSegment SegmentFromVectors_B(IVector startVertex, IVector endVertex)
        {        
            //IntPtr p = segmentFromVectors(startVertex, endVertex);
            //GlosaLineSegment obj = (GlosaLineSegment)Marshal.PtrToStructure(p, typeof(GlosaLineSegment));
            //return obj;
            //return segmentFromVectors(startVertex, endVertex);
        }
        */
        #endregion
    }
}
