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
    public class GlosaPolyline : GlosaObject, ICopy<GlosaPolyline>, IDimension<GlosaPolyline>, IHash<GlosaPolyline>, IEquals<GlosaPolyline>, IString<GlosaPolyline>,
        ITransform<GlosaPolyline>, IClosest<GlosaPolyline>, IVertices<GlosaPolyline>
    {
        #region C Reference Procs
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool areClosed_v2_segment(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool areClosed_v3_segment(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool areClosed_v4_segment(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool areClosed_v2_vertices(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool areClosed_v3_vertices(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool areClosed_v4_vertices(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isClosed_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isClosed_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool isClosed_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr reverse_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr reverse_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr reverse_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool contains_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool contains_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool contains_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool containsPoint_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool containsPoint_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool containsPoint_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool equals_v2_polyline(string s1, string s2);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool equals_v3_polyline(string s1, string s2);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool equals_v4_polyline(string s1, string s2);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int hash_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int hash_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int hash_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dimension_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dimension_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dimension_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr copy_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr copy_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr copy_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector2 average_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector3 average_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector4 average_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector2 closestVertex_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector3 closestVertex_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector4 closestVertex_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr toPolygon_v2_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr toPolygon_v3_polyline(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr toPolygon_v4_polyline(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector2 closestPoint_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector3 closestPoint_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GlosaVector4 closestPoint_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rotate_v2_polyline(string s, double theta);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rotate_v3_polyline(string s, GlosaVector3 axis, double theta);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr rotate_v4_polyline(string s, GlosaVector4 b1, GlosaVector4 b2, double theta, GlosaVector4 b3, GlosaVector4 b4, double phi);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr scale_v2_polyline(string s, double sx, double sy);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr scale_v3_polyline(string s, double sx, double sy, double sz);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr scale_v4_polyline(string s, double sx, double sy, double sw);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr translate_v2_polyline(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr translate_v3_polyline(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr translate_v4_polyline(string s, GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr transform_v2_polyline(string s, GlosaMatrix33 m);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr transform_v3_polyline(string s, GlosaMatrix44 m);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr transform_v4_polyline(string s, GlosaMatrix44 m);
        #endregion

        public IVector[] vertices;
        public GlosaLineSegment[] segments;
        public bool closed;

        private int dimension;

        public GlosaPolyline(){}

        public GlosaPolyline(IVector[] verts, bool closed)
        {
            this.vertices = verts;
            this.closed = closed;
            this.dimension = verts[0].Dimension();
            GenerateSegmentsFromVertices(verts);
        }

        public GlosaPolyline(GlosaLineSegment[] segments)
        {
            this.segments = segments;
            this.dimension = segments[0].startVertex.Dimension();
            GenerateVerticesFromSegments(segments);
        }

        public IVector[] GetVertices()
        {
            return this.vertices;
        }

        public void SetVertices(IVector[] verts)
        {
            this.vertices = verts;
        }

        public GlosaLineSegment[] GetSegments()
        {
            return this.segments;
        }

        public void SetSegments(GlosaLineSegment[] segs)
        {
            this.segments = segs;
        }

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

        public static GlosaPolyline DeserializeFromVertexData(string data)
        {
            List<string> dataList = Utilities.parseData(data, "vertices.*");
            int number = dataList.Count;
            List<string> dataX2 = Utilities.parseData(data, "vertices.*.*");
            int totalNumber = dataX2.Count;
            int componentValue = totalNumber / number;
            List<string> dataClosed = Utilities.parseData(data, "closed");          
            return new GlosaPolyline(ParseVertices(data, componentValue).ToArray(), Convert.ToBoolean(dataClosed[0]));
        }

        public static GlosaPolyline DeserializeFromSegmentData(string data)
        {
            List<string> dataList = Utilities.parseData(data, "vertices.*");
            int number = dataList.Count;
            List<string> dataX2 = Utilities.parseData(data, "vertices.*.*");
            int totalNumber = dataX2.Count;
            int componentValue = totalNumber / number;
            return new GlosaPolyline(ParseSegments(data, componentValue).ToArray());
        }

        private static List<IVector> ParseVertices(string data, int type)
        {
            List<List<string>> vertList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    break;
                case 1:
                    break;
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
                        break;
                    case 1:
                        break;
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

        private static List<GlosaLineSegment> ParseSegments(string data, int type)
        {
            List<List<string>> spList = new List<List<string>>();
            List<List<string>> epList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    break;
                case 1:
                    break;
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
                        break;
                    case 1:
                        break;
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

        public bool AreSegmentsClosed()
        {
            bool closed = false;
            if(this.dimension == 2) { closed = areClosed_v2_segment(this.Serialize()); }
            else if(this.dimension == 3) { closed = areClosed_v3_segment(this.Serialize()); }
            else if(this.dimension == 4) { closed = areClosed_v3_segment(this.Serialize()); }
            else{ throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
            return closed;
        }

        public bool AreVerticesClosed()
        {
            bool closed = false;
            if (this.dimension == 2) { closed = areClosed_v2_vertices(this.Serialize()); }
            else if (this.dimension == 3) { closed = areClosed_v3_vertices(this.Serialize()); }
            else if (this.dimension == 4) { closed = areClosed_v4_vertices(this.Serialize()); }
            else { throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
            return closed;
        }

        public bool IsClosed()
        {
            bool closed = false;
            if (this.dimension == 2) { closed = isClosed_v2_polyline(this.Serialize()); }
            else if (this.dimension == 3) { closed = isClosed_v3_polyline(this.Serialize()); }
            else if (this.dimension == 4) { closed = isClosed_v4_polyline(this.Serialize()); }
            else { throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
            return closed;
        }

        public static GlosaPolyline Reverse(GlosaPolyline p)
        {
            if (p.dimension == 2)
            {
                IntPtr pStr = reverse_v2_polyline(p.Serialize());
                return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
            }
            else if (p.dimension == 3)
            {
                IntPtr pStr = reverse_v3_polyline(p.Serialize());
                return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
            }
            else if (p.dimension == 4)
            {
                IntPtr pStr = reverse_v4_polyline(p.Serialize());
                return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
            }
            else { throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
        }

        public void Reverse()
        {
            if (this.dimension == 2) {
                IntPtr pStr = reverse_v2_polyline(this.Serialize());
                GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                this.vertices = p.vertices;
                this.segments = p.segments;
            }
            else if (this.dimension == 3) {
                IntPtr pStr = reverse_v3_polyline(this.Serialize());
                GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                this.vertices = p.vertices;
                this.segments = p.segments;
            }
            else if (this.dimension == 4) {
                IntPtr pStr = reverse_v4_polyline(this.Serialize());
                GlosaPolyline p = DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr));
                this.vertices = p.vertices;
                this.segments = p.segments;
            }
            else { throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension"); }
        }

        public GlosaPolyline Copy()
        {
            throw new NotImplementedException();
        }

        public int Dimension()
        {
            return this.dimension;
        }

        public int Hash()
        {
            throw new NotImplementedException();
        }

        public bool Equals(GlosaPolyline other)
        {
            throw new NotImplementedException();
        }

        public string Stringify()
        {
            throw new NotImplementedException();
        }

        public GlosaPolyline ScaleNew(double s)
        {
            throw new NotImplementedException();
        }

        public void ScaleSelf(double s)
        {
            throw new NotImplementedException();
        }

        public GlosaPolyline ScaleNew(double sx, double sy, double sz, double sw)
        {
            throw new NotImplementedException();
        }

        public void ScaleSelf(double sx, double sy, double sz, double sw)
        {
            throw new NotImplementedException();
        }

        public GlosaPolyline RotateNew(float theta, int component)
        {
            throw new NotImplementedException();
        }

        public void RotateSelf(float theta, int component)
        {
            throw new NotImplementedException();
        }

        public void Translate(GlosaPolyline vector)
        {
            throw new NotImplementedException();
        }

        public GlosaPolyline TransformNew(IMatrixes matrix)
        {
            throw new NotImplementedException();
        }

        public void TransformSelf(IMatrixes matrix)
        {
            throw new NotImplementedException();
        }

        public IVector ClosestPoint(IVector v)
        {
            throw new NotImplementedException();
        }

        public IVector ClosestVertex(IVector v)
        {
            throw new NotImplementedException();
        }

        public GlosaPolyline ToPolyline(GlosaPolyline obj)
        {
            throw new NotImplementedException();
        }
    }
}
