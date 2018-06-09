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

namespace Glosa.Net.Core.Geometry.Path
{
    /// <summary>
    /// 
    /// </summary>
    public class GlosaPolyline : GlosaObject, ICopy<GlosaPolyline>, IDimension<GlosaPolyline>, IHash<GlosaPolyline>, IEquals<GlosaPolyline>, IString<GlosaPolyline>,
        ITransform<GlosaPolyline>, IClosest<GlosaPolyline>, IVertices<GlosaPolyline>
    {
        #region C Reference Procs
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool areClosed_v2_segment(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool areClosed_v3_segment(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool areClosed_v4_segment(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool areClosed_v2_vertices(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool areClosed_v3_vertices(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool areClosed_v4_vertices(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isClosed_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isClosed_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isClosed_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr reverse_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr reverse_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr reverse_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool containsPoint_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool containsPoint_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool containsPoint_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v2_polyline(string s1, string s2);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v3_polyline(string s1, string s2);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v4_polyline(string s1, string s2);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 average_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 average_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 average_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 closestVertex_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 closestVertex_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 closestVertex_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toPolygon_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toPolygon_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toPolygon_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 closestPoint_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 closestPoint_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 closestPoint_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v2_polyline(string s, double theta);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v3_polyline(string s, GlosaVector3 axis, double theta);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v4_polyline(string s, GlosaVector4 b1, GlosaVector4 b2, double theta, GlosaVector4 b3, GlosaVector4 b4, double phi);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v2_polyline(string s, double sx, double sy);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v3_polyline(string s, double sx, double sy, double sz);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v4_polyline(string s, double sx, double sy, double sz, double sw);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v2_polyline(string s, GlosaMatrix33 m);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v3_polyline(string s, GlosaMatrix44 m);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v4_polyline(string s, GlosaMatrix44 m);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public IVector[] vertices;

        /// <summary>
        /// 
        /// </summary>
        public GlosaLineSegment[] segments;

        /// <summary>
        /// 
        /// </summary>
        public bool closed;
        private int dimension;

        /// <summary>
        /// 
        /// </summary>
        public GlosaPolyline(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="verts"></param>
        /// <param name="closed"></param>
        public GlosaPolyline(IVector[] verts, bool closed)
        {
            this.vertices = verts;
            this.closed = closed;
            this.dimension = verts[0].Dimension();
            GenerateSegmentsFromVertices(verts);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments"></param>
        public GlosaPolyline(GlosaLineSegment[] segments)
        {
            this.segments = segments;
            this.dimension = segments[0].startVertex.Dimension();
            GenerateVerticesFromSegments(segments);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IVector[] GetVertices()
        {
            return this.vertices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="verts"></param>
        public void SetVertices(IVector[] verts)
        {
            this.vertices = verts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaLineSegment[] GetSegments()
        {
            return this.segments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segs"></param>
        public void SetSegments(GlosaLineSegment[] segs)
        {
            this.segments = segs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments"></param>
        private void GenerateVerticesFromSegments(GlosaLineSegment[] segments)
        {
            if (segments.Length < 1)
            {
                throw new System.ArgumentException("polyline needs at least 1 segment", "array");
            }

            if (segments[0].startVertex.Dimension() == 2)
            {
                if ((GlosaVector2)segments[0].startVertex == (GlosaVector2)segments[segments.Length - 1].endVertex) { this.closed = true; }
            }
            else if (segments[0].startVertex.Dimension() == 3)
            {
                if ((GlosaVector3)segments[0].startVertex == (GlosaVector3)segments[segments.Length - 1].endVertex) { this.closed = true; }
            }
            else if (segments[0].startVertex.Dimension() == 4)
            {
                if ((GlosaVector4)segments[0].startVertex == (GlosaVector4)segments[segments.Length - 1].endVertex) { this.closed = true; }
            }

            List<IVector> IVectorList = new List<IVector>();
            int count = 0;
            foreach (GlosaLineSegment l in segments)
            {
                IVectorList.Add(l.startVertex);
                count++;
            }
            if (!this.closed)
            {
                IVectorList.Add(segments[segments.Length-1].endVertex);
            }
            this.vertices = IVectorList.ToArray();          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices"></param>
        private void GenerateSegmentsFromVertices(IVector[] vertices)
        {
            this.segments = new GlosaLineSegment[this.vertices.Length];
            if (vertices.Length < 2)
            {
                throw new System.ArgumentException("vertex count must be at least 2", "array");
            }
            for(int i = 0; i < vertices.Length -1; i++)
            {
                this.segments[i] = (new GlosaLineSegment(vertices[i], vertices[i + 1]));
                if (this.closed)
                {
                    this.segments[i+1] = (new GlosaLineSegment(vertices[vertices.Length-1], vertices[0]));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static GlosaPolyline DeserializeFromVertexData(string data)
        {
            List<string> dataList = Utilities.parseData(data, "vertices.*");
            List<string> dataX2 = Utilities.parseData(data, "vertices.*.*");
            List<string> dataClosed = Utilities.parseData(data, "closed");          
            return new GlosaPolyline(ParseVertices(data, (dataX2.Count / dataList.Count)).ToArray(), Convert.ToBoolean(dataClosed[0]));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static GlosaPolyline DeserializeFromSegmentData(string data)
        {
            List<string> dataList = Utilities.parseData(data, "vertices.*");
            List<string> dataX2 = Utilities.parseData(data, "vertices.*.*");
            return new GlosaPolyline(ParseSegments(data, (dataX2.Count / dataList.Count)).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static List<IVector> ParseVertices(string data, int type)
        {
            List<List<string>> vertList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    vertList.Add(Utilities.parseData(data, "vertices.*.x"));
                    vertList.Add(Utilities.parseData(data, "vertices.*.y"));
                    break;
                case 3:
                    vertList.Add(Utilities.parseData(data, "vertices.*.x"));
                    vertList.Add(Utilities.parseData(data, "vertices.*.y"));
                    vertList.Add(Utilities.parseData(data, "vertices.*.z"));
                    break;
                case 4:
                    vertList.Add(Utilities.parseData(data, "vertices.*.x"));
                    vertList.Add(Utilities.parseData(data, "vertices.*.y"));
                    vertList.Add(Utilities.parseData(data, "vertices.*.z"));
                    vertList.Add(Utilities.parseData(data, "vertices.*.w"));
                    break;
            }
            int count = 0;
            List<IVector> gverts = new List<IVector>();
            foreach (string str in vertList[0])
            {
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                    case 2:
                        gverts.Add(new GlosaVector2(Convert.ToDouble(str), Convert.ToDouble(vertList[1][count])));
                        break;
                    case 3:
                        gverts.Add(new GlosaVector3(Convert.ToDouble(str), Convert.ToDouble(vertList[1][count]), Convert.ToDouble(vertList[2][count])));
                        break;
                    case 4:
                        gverts.Add(new GlosaVector4(Convert.ToDouble(str), Convert.ToDouble(vertList[1][count]), Convert.ToDouble(vertList[2][count]), Convert.ToDouble(vertList[3][count])));
                        break;
                }
                count++;
            }
            return gverts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static List<GlosaLineSegment> ParseSegments(string data, int type)
        {
            List<List<string>> spList = new List<List<string>>();
            List<List<string>> epList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.x"));
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.y"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.x"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.y"));
                    break;
                case 3:
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.x"));
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.y"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.x"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.y"));
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.z"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.z"));
                    break;
                case 4:
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.x"));
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.y"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.x"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.y"));
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.z"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.z"));
                    spList.Add(Utilities.parseData(data, "segments.*.startVertex.w"));
                    epList.Add(Utilities.parseData(data, "segments.*.endVertex.w"));
                    break;
            }
            int count = 0;
            List<GlosaLineSegment> gls = new List<GlosaLineSegment>();
            foreach (string str in spList[0])
            {
                IVector gvs;
                IVector gvs2;
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                    case 2:
                        gvs = new GlosaVector2(Convert.ToDouble(str), Convert.ToDouble(spList[1][count]));
                        gvs2 = new GlosaVector2(Convert.ToDouble(epList[0][count]), Convert.ToDouble(epList[1][count]));
                        gls.Add(new GlosaLineSegment(gvs, gvs2));
                        break;
                    case 3:
                        gvs = new GlosaVector3(Convert.ToDouble(str), Convert.ToDouble(spList[1][count]), Convert.ToDouble(spList[2][count]));
                        gvs2 = new GlosaVector3(Convert.ToDouble(epList[0][count]), Convert.ToDouble(epList[1][count]), Convert.ToDouble(epList[2][count]));
                        gls.Add(new GlosaLineSegment(gvs, gvs2));
                        break;
                    case 4:
                        gvs = new GlosaVector4(Convert.ToDouble(str), Convert.ToDouble(spList[1][count]), Convert.ToDouble(spList[2][count]), Convert.ToDouble(spList[3][count]));
                        gvs2 = new GlosaVector4(Convert.ToDouble(epList[0][count]), Convert.ToDouble(epList[1][count]), Convert.ToDouble(epList[2][count]), Convert.ToDouble(epList[3][count]));
                        gls.Add(new GlosaLineSegment(gvs, gvs2));
                        break;
                }
                count++;
            }
            return gls;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AreSegmentsClosed()
        {
            bool closed = false;
            if(this.dimension == 2) { closed = areClosed_v2_segment(this.Serialize()); }
            else if(this.dimension == 3) { closed = areClosed_v3_segment(this.Serialize()); }
            else if(this.dimension == 4) { closed = areClosed_v3_segment(this.Serialize()); }
            else{ throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
            return closed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AreVerticesClosed()
        {
            bool closed = false;
            if (this.dimension == 2) { closed = areClosed_v2_vertices(this.Serialize()); }
            else if (this.dimension == 3) { closed = areClosed_v3_vertices(this.Serialize()); }
            else if (this.dimension == 4) { closed = areClosed_v4_vertices(this.Serialize()); }
            else { throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
            return closed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsClosed()
        {
            bool closed = false;
            if (this.dimension == 2) { closed = isClosed_v2_polyline(this.Serialize()); }
            else if (this.dimension == 3) { closed = isClosed_v3_polyline(this.Serialize()); }
            else if (this.dimension == 4) { closed = isClosed_v4_polyline(this.Serialize()); }
            else { throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
            return closed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static GlosaPolyline Reverse(GlosaPolyline p)
        {
            switch (p.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = reverse_v2_polyline(p.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    pStr = reverse_v3_polyline(p.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    pStr = reverse_v4_polyline(p.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reverse()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = reverse_v2_polyline(this.Serialize());
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 3:
                    pStr = reverse_v3_polyline(this.Serialize());
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 4:
                    pStr = reverse_v4_polyline(this.Serialize());
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool ContainsVertex(IVector vector)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    return contains_v2_polyline(this.Serialize(), (GlosaVector2)vector);
                case 3:
                    if(vector.GetType() != typeof(GlosaVector3)) {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    return contains_v3_polyline(this.Serialize(), (GlosaVector3)vector);
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    return contains_v4_polyline(this.Serialize(), (GlosaVector4)vector);
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool ContainsPoint(IVector vector)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    return containsPoint_v2_polyline(this.Serialize(), (GlosaVector2)vector);
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    return containsPoint_v3_polyline(this.Serialize(), (GlosaVector3)vector);
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    return containsPoint_v4_polyline(this.Serialize(), (GlosaVector4)vector);
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Determines whether the specified GlosaPolyline has the same value as the present GlosaPolyline.
        /// </summary>
        /// <param name="polyline">The other GlosaPolyline to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaPolyline polyline)
        {
            return this == polyline;
        }

        /// <summary>
        /// Determines whether two GlosaPolyline have equal values.
        /// </summary>
        /// <param name="a">The first GlosaPolyline</param>
        /// <param name="b">The second GlosaPolyline</param>
        /// <returns>True if components of the two GlosaPolyline are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaPolyline a, GlosaPolyline b)
        {
            switch (a.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (b.vertices[0].GetType() != typeof(GlosaVector2)) {return false; }
                    return equals_v2_polyline(a.Serialize(), b.Serialize());
                case 3:
                    if (b.vertices[0].GetType() != typeof(GlosaVector3)) { return false; }
                    return equals_v3_polyline(a.Serialize(), b.Serialize());
                case 4:
                    if (b.vertices[0].GetType() != typeof(GlosaVector4)) { return false; }
                    return equals_v4_polyline(a.Serialize(), b.Serialize());
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }        
        }

        /// <summary>
        /// Determines whether two GlosaPolyline have different values.
        /// </summary>
        /// <param name="a">The first GlosaPolyline</param>
        /// <param name="b">The second GlosaPolyline</param>
        /// <returns>True if any component of the two GlosaPolyline is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaPolyline a, GlosaPolyline b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Hash()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    return hash_v2_polyline(this.Serialize());
                case 3:
                    return hash_v3_polyline(this.Serialize());
                case 4:
                    return hash_v4_polyline(this.Serialize());
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Dimension()
        {
            return this.dimension;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaPolyline Copy()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = copy_v2_polyline(this.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    pStr = copy_v3_polyline(this.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    pStr = copy_v4_polyline(this.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static GlosaPolyline Copy(GlosaPolyline p)
        {
            switch (p.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = copy_v2_polyline(p.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    pStr = copy_v3_polyline(p.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    pStr = copy_v4_polyline(p.Serialize());
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Stringify()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = stringify_v2_polyline(this.Serialize());
                    return Marshal.PtrToStringAnsi(pStr);
                case 3:
                    pStr = stringify_v3_polyline(this.Serialize());
                    return Marshal.PtrToStringAnsi(pStr);
                case 4:
                    pStr = stringify_v4_polyline(this.Serialize());
                    return Marshal.PtrToStringAnsi(pStr);
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public GlosaPolyline ScaleNew(double s)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = scale_v2_polyline(this.Serialize(), s, s);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    pStr = scale_v3_polyline(this.Serialize(), s, s, s);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    pStr = scale_v4_polyline(this.Serialize(), s, s, s, s);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void ScaleSelf(double s)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = scale_v2_polyline(this.Serialize(), s, s);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 3:
                    pStr = scale_v3_polyline(this.Serialize(), s, s, s);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 4:
                    pStr = scale_v4_polyline(this.Serialize(), s, s, s, s);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <param name="sw"></param>
        /// <returns></returns>
        public GlosaPolyline ScaleNew(double sx, double sy, double sz = 0, double sw = 0)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = scale_v2_polyline(this.Serialize(), sx, sy);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    pStr = scale_v3_polyline(this.Serialize(), sx, sy, sz);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    pStr = scale_v4_polyline(this.Serialize(), sx, sy, sz, sw);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <param name="sw"></param>
        public void ScaleSelf(double sx, double sy, double sz, double sw = 0)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = scale_v2_polyline(this.Serialize(), sx, sy);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 3:
                    pStr = scale_v3_polyline(this.Serialize(), sx, sy, sz);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 4:
                    pStr = scale_v4_polyline(this.Serialize(), sx, sy, sz, sw);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public GlosaPolyline RotateNew(float theta, int component = 0)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = rotate_v2_polyline(this.Serialize(), theta);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector2, please use RotateAxis methods", "dimension");
                case 4:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector2, please use RotateAxis methods", "dimension");
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="component"></param>
        public void RotateSelf(float theta, int component = 0)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    IntPtr pStr = rotate_v2_polyline(this.Serialize(), theta);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 3:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector2, please use RotateAxis methods", "dimension");
                case 4:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector2, please use RotateAxis methods", "dimension");
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        public GlosaPolyline RotateAxis(GlosaVector3 axis, float theta)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector3, please use Rotate methods", "dimension");
                case 3:
                    IntPtr pStr = rotate_v3_polyline(this.Serialize(), axis, theta);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector3, please use overloaded RotateAxis method", "dimension");
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="theta"></param>
        public void RotateAxisSelf(GlosaVector3 axis, float theta)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector3, please use Rotate methods", "dimension");
                case 3:
                    IntPtr pStr = rotate_v3_polyline(this.Serialize(), axis, theta);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 4:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector3, please use overloaded RotateAxis method", "dimension");
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <param name="theta"></param>
        /// <param name="b3"></param>
        /// <param name="b4"></param>
        /// <param name="phi"></param>
        /// <returns></returns>
        public GlosaPolyline RotateAxis(GlosaVector4 b1, GlosaVector4 b2, float theta, GlosaVector4 b3, GlosaVector4 b4, float phi)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector4, please use Rotate methods", "dimension");
                case 3:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector4, please use overloaded RotateAxis method", "dimension");
                case 4:
                    IntPtr pStr = rotate_v4_polyline(this.Serialize(), b1, b2, theta, b3, b4, phi);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <param name="theta"></param>
        /// <param name="b3"></param>
        /// <param name="b4"></param>
        /// <param name="phi"></param>
        public void RotateAxisSelf(GlosaVector4 b1, GlosaVector4 b2, float theta, GlosaVector4 b3, GlosaVector4 b4, float phi)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector3, please use Rotate methods", "dimension");
                case 3:
                    throw new System.ArgumentException("Rotate new only works on polylines are made up of GlosaVector3, please use overloaded RotateAxis method", "dimension");
                case 4:
                    IntPtr pStr = rotate_v4_polyline(this.Serialize(), b1, b2, theta, b3, b4, phi);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IVector Average()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    return average_v2_polyline(this.Serialize());
                case 3:
                    return average_v3_polyline(this.Serialize());
                case 4:
                    return average_v4_polyline(this.Serialize());
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IVector Average(GlosaPolyline p)
        {
            switch (p.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    return average_v2_polyline(p.Serialize());
                case 3:
                    return average_v3_polyline(p.Serialize());
                case 4:
                    return average_v4_polyline(p.Serialize());
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public void Translate(IVector vector)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    IntPtr pStr = translate_v2_polyline(this.Serialize(), (GlosaVector2)vector);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    pStr = translate_v3_polyline(this.Serialize(), (GlosaVector3)vector);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    pStr = translate_v4_polyline(this.Serialize(), (GlosaVector4)vector);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public GlosaPolyline TransformNew(IMatrixes matrix)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "vector");
                    }
                    IntPtr pStr = transform_v2_polyline(this.Serialize(), (GlosaMatrix33)matrix);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    pStr = transform_v3_polyline(this.Serialize(), (GlosaMatrix44)matrix);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                case 4:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    pStr = transform_v4_polyline(this.Serialize(), (GlosaMatrix44)matrix);
                    return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void TransformSelf(IMatrixes matrix)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "vector");
                    }
                    IntPtr pStr = transform_v2_polyline(this.Serialize(), (GlosaMatrix33)matrix);
                    GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    pStr = transform_v3_polyline(this.Serialize(), (GlosaMatrix44)matrix);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
                case 4:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    pStr = transform_v4_polyline(this.Serialize(), (GlosaMatrix44)matrix);
                    p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                    this.vertices = p.vertices;
                    this.segments = p.segments;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public IVector ClosestPoint(IVector vector)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    return closestPoint_v2_polyline(this.Serialize(), (GlosaVector2)vector);
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    return closestPoint_v3_polyline(this.Serialize(), (GlosaVector3)vector);
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    return closestPoint_v4_polyline(this.Serialize(), (GlosaVector4)vector);
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public IVector ClosestVertex(IVector vector)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polyline cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    return closestVertex_v2_polyline(this.Serialize(), (GlosaVector2)vector);
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    return closestVertex_v3_polyline(this.Serialize(), (GlosaVector3)vector);
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Polyline is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    return closestVertex_v4_polyline(this.Serialize(), (GlosaVector4)vector);
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public GlosaPolyline ToPolyline()
        {
            //seems trivial
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public GlosaPolygon ToPolygon()
        {
            return new GlosaPolygon(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polyline"></param>
        /// <returns></returns>
        public static GlosaPolygon ToPolygon(GlosaPolyline polyline)
        {
            return new GlosaPolygon(polyline);
        }
    }
}
