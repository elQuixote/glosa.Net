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

        public GlosaPolygon(IVector[] verts, bool closed = true)
        {
            this.polyline = new GlosaPolyline(verts, closed);
        }

        public GlosaPolygon(GlosaLineSegment[] segments)
        {
            this.polyline = new GlosaPolyline(segments);
        }

        public GlosaPolygon(GlosaPolyline polyline)
        {
            this.polyline = polyline;
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
    }
}
