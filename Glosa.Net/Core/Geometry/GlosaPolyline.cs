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
    }
}
