using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Interfaces;
using Glosa.Net.Core.Helpers;
using Glosa.Net.Core.Helpers.Json;
using Glosa.Net.Core.Geometry.Path;
using Glosa.Net.Core.Geometry.Vector;
using Glosa.Net.Core.Geometry.Matrix;
using Glosa.Net.Core.Geometry.Shape;

namespace Glosa.Net.Core.Geometry.Polygon
{
    /// <summary>
    /// 
    /// </summary>
    public class GlosaPolygon : GlosaObject, ICopy<GlosaPolygon>, IDimension<GlosaPolygon>, IHash<GlosaPolygon>, IEquals<GlosaPolygon>, IString<GlosaPolygon>,
        ITransform<GlosaPolygon>, IClosest<GlosaPolygon>, IVertices<GlosaPolygon>, IShape2<GlosaPolygon>
    {
        #region C Reference Procs
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr reverse_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr reverse_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr reverse_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v2_polygon(string s, GlosaVector2 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v3_polygon(string s, GlosaVector3 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v4_polygon(string s, GlosaVector4 v);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool containsPoint_v2_polygon(string s, GlosaVector2 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool containsPoint_v3_polygon(string s, GlosaVector3 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool containsPoint_v4_polygon(string s, GlosaVector4 v);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v2_polygon(string s1, string s2);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v3_polygon(string s1, string s2);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v4_polygon(string s1, string s2);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double area_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double area_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double area_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double perimeter_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double perimeter_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double perimeter_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 centroid_v2_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 closestVertex_v2_polygon(string s, GlosaVector2 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 closestVertex_v3_polygon(string s, GlosaVector3 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 closestVertex_v4_polygon(string s, GlosaVector4 v);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toPolyline_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toPolyline_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toPolyline_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 closestPoint_v2_polygon(string s, GlosaVector2 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 closestPoint_v3_polygon(string s, GlosaVector3 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 closestPoint_v4_polygon(string s, GlosaVector4 v);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isClockwise_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isClockwise_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isClockwise_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v2_polygon(string s, double theta);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v3_polygon(string s, GlosaVector3 axis, double theta);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v4_polygon(string s, GlosaVector4 b1, GlosaVector4 b2, double theta, GlosaVector4 b3, GlosaVector4 b4, double phi);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v2_polygon(string s, double sx, double sy);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v3_polygon(string s, double sx, double sy, double sz);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v4_polygon(string s, double sx, double sy, double sz, double sw);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v2_polygon(string s, GlosaVector2 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v3_polygon(string s, GlosaVector3 v);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v4_polygon(string s, GlosaVector4 v);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v2_polygon(string s, GlosaMatrix33 m);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v3_polygon(string s, GlosaMatrix44 m);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v4_polygon(string s, GlosaMatrix44 m);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isPlanarVertices_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isPlanarVertices_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isPlanarVertices_v4_polygon(string s);

        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isSegmentsClosed_v2_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isSegmentsClosed_v3_polygon(string s);
        [DllImport("wrapper_polygon.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool isSegmentsClosed_v4_polygon(string s);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public GlosaPolyline polyline;
        private int dimension;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="verts"></param>
        /// <param name="closed"></param>
        public GlosaPolygon(IVector[] verts, bool closed = true)
        {
            this.polyline = new GlosaPolyline(verts, closed);
            this.dimension = this.polyline.Dimension();
            if (!IsPlanar()) { throw new System.ArgumentException("Polygon polyline is not planar", "dimension"); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments"></param>
        public GlosaPolygon(GlosaLineSegment[] segments)
        {
            this.polyline = new GlosaPolyline(segments);
            this.dimension = this.polyline.Dimension();
            if (!IsClosed()) { throw new System.ArgumentException("Polygon polyline is not closed"); }
            if (!IsPlanar()) { throw new System.ArgumentException("Polygon polyline is not planar", "dimension"); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polyline"></param>
        public GlosaPolygon(GlosaPolyline polyline)
        {
            this.dimension = polyline.Dimension();
            this.polyline = polyline;
            if (!IsClosed()) { throw new System.ArgumentException("Polygon polyline is not closed"); }
            if (!IsPlanar()) { throw new System.ArgumentException("Polygon polyline is not planar"); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsPlanar()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return isPlanarVertices_v2_polygon(this.Serialize()); }
                    catch(Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return isPlanarVertices_v3_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return isPlanarVertices_v4_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsClosed()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return isSegmentsClosed_v2_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return isSegmentsClosed_v3_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return isSegmentsClosed_v4_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static GlosaPolygon DeserializeFromVertexData(string data)
        {
            List<string> dataList = Utilities.parseData(data, "polyline.vertices.*");
            List<string> dataX2 = Utilities.parseData(data, "polyline.vertices.*.*");
            List<string> dataClosed = Utilities.parseData(data, "polyline.closed");
            return new GlosaPolygon(new GlosaPolyline(ParseVertices(data, (dataX2.Count / dataList.Count)).ToArray(), Convert.ToBoolean(dataClosed[0])));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static GlosaPolygon DeserializeFromSegmentData(string data)
        {
            List<string> dataList = Utilities.parseData(data, "polyline.vertices.*");
            List<string> dataX2 = Utilities.parseData(data, "polyline.vertices.*.*");
            return new GlosaPolygon(new GlosaPolyline(ParseSegments(data, (dataX2.Count / dataList.Count)).ToArray()));
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
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.x"));
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.y"));
                    break;
                case 3:
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.x"));
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.y"));
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.z"));
                    break;
                case 4:
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.x"));
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.y"));
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.z"));
                    vertList.Add(Utilities.parseData(data, "polyline.vertices.*.w"));
                    break;
            }
            int count = 0;
            List<IVector> gverts = new List<IVector>();
            foreach (string str in vertList[0])
            {
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
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
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.x"));
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.y"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.x"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.y"));
                    break;
                case 3:
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.x"));
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.y"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.x"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.y"));
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.z"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.z"));
                    break;
                case 4:
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.x"));
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.y"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.x"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.y"));
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.z"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.z"));
                    spList.Add(Utilities.parseData(data, "polyline.segments.*.startVertex.w"));
                    epList.Add(Utilities.parseData(data, "polyline.segments.*.endVertex.w"));
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
                        throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
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
        /// <param name="p"></param>
        /// <returns></returns>
        public static GlosaPolygon Reverse(GlosaPolygon p)
        {
            switch (p.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = reverse_v2_polygon(p.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = reverse_v3_polygon(p.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = reverse_v4_polygon(p.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reverse()
        {
            try
            {
                this.polyline.Reverse();
            }
            catch(Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ContainsVertex(IVector vector)
        {
            try
            {
                return this.polyline.ContainsVertex(vector);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ContainsPoint(IVector vector)
        {
            try
            {
                return this.polyline.ContainsPoint(vector);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }
        }

        /// <summary>
        /// Determines whether the specified GlosaPolygon has the same value as the present GlosaPolygon.
        /// </summary>
        /// <param name="polygon">The other GlosaPolygon to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaPolygon polygon)
        {
            return this == polygon;
        }

        /// <summary>
        /// Determines whether two GlosaPolygon have equal values.
        /// </summary>
        /// <param name="a">The first GlosaPolygon</param>
        /// <param name="b">The second GlosaPolygon</param>
        /// <returns>True if components of the two GlosaPolygon are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaPolygon a, GlosaPolygon b)
        {
            try
            {
                return a.polyline == b.polyline;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }
        }

        /// <summary>
        /// Determines whether two GlosaPolygon have different values.
        /// </summary>
        /// <param name="a">The first GlosaPolygon</param>
        /// <param name="b">The second GlosaPolygon</param>
        /// <returns>True if any component of the two GlosaPolygon is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaPolygon a, GlosaPolygon b)
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
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return hash_v2_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return hash_v3_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return hash_v4_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
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
        /// <param name="p"></param>
        /// <returns></returns>
        public static GlosaPolygon Copy(GlosaPolygon p)
        {
            switch (p.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = copy_v2_polygon(p.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = copy_v3_polygon(p.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = copy_v4_polygon(p.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaPolygon Copy()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = copy_v2_polygon(this.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = copy_v3_polygon(this.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = copy_v4_polygon(this.Serialize()); return DeserializeFromVertexData(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
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
                    try { IntPtr pStr = stringify_v2_polygon(this.Serialize()); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = stringify_v3_polygon(this.Serialize()); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = stringify_v4_polygon(this.Serialize()); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polyline has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return area_v2_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return area_v3_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return area_v4_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Perimeter()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return perimeter_v2_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return perimeter_v3_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return perimeter_v4_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaVector2 Centroid()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return centroid_v2_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    throw new System.ArgumentException("Centroid is currently not enabled for Polygons made up of GlosaVector3s");
                case 4:
                    throw new System.ArgumentException("Centroid is currently not enabled for Polygons made up of GlosaVector4s");
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsClockwise()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Polygon cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return isClockwise_v2_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return isClockwise_v3_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return isClockwise_v4_polygon(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Polygon has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public GlosaPolygon ScaleNew(double s)
        {
            try { return new GlosaPolygon(this.polyline.ScaleNew(s)); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public void ScaleSelf(double s)
        {
            try { this.polyline.ScaleNew(s); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <param name="sw"></param>
        /// <returns></returns>
        public GlosaPolygon ScaleNew(double sx, double sy, double sz = 0, double sw = 0)
        {
            try { return new GlosaPolygon(this.polyline.ScaleNew(sx, sy, sz, sw)); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <param name="sw"></param>
        public void ScaleSelf(double sx, double sy, double sz = 0, double sw = 0)
        {
            try { this.polyline.ScaleNew(sx, sy, sz, sw); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public GlosaPolygon RotateNew(float theta, int component = 0)
        {
            try { return new GlosaPolygon(this.polyline.RotateNew(theta)); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="component"></param>
        public void RotateSelf(float theta, int component = 0)
        {
            try { this.polyline.RotateNew(theta); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        public GlosaPolygon RotateAxis(GlosaVector3 axis, float theta)
        {
            try { return new GlosaPolygon(this.polyline.RotateAxis(axis, theta)); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="theta"></param>
        public void RotateAxisSelf(GlosaVector3 axis, float theta)
        {
            try { this.polyline.RotateAxis(axis, theta); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
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
        public GlosaPolygon RotateAxis(GlosaVector4 b1, GlosaVector4 b2, float theta, GlosaVector4 b3, GlosaVector4 b4, float phi)
        {
            try { return new GlosaPolygon(this.polyline.RotateAxis(b1, b2, theta, b3, b4, phi)); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
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
            try { this.polyline.RotateAxis(b1, b2, theta, b3, b4, phi); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public void Translate(IVector vector)
        {
            try { this.polyline.Translate(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public GlosaPolygon TransformNew(IMatrixes matrix)
        {
            try { return new GlosaPolygon(this.polyline.TransformNew(matrix)); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void TransformSelf(IMatrixes matrix)
        {
            try { this.polyline.TransformNew(matrix); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public IVector ClosestVertex(IVector vector)
        {
            try { return this.polyline.ClosestVertex(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public IVector ClosestPoint(IVector vector)
        {
            try { return this.polyline.ClosestPoint(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaPolyline ToPolyline()
        {
            return this.polyline;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public static GlosaPolyline ToPolyline(GlosaPolygon polygon)
        {
            return polygon.polyline;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaPolygon ToPolygon()
        {
            return this;
        }
    }
}
