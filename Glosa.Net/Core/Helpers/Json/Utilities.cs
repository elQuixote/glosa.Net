using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonPath;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net.Http;
using Glosa.Net.Core.Interfaces;
using Glosa.Net.Core.Geometry.Vector;
using Glosa.Net.Core.Geometry.Shape;

namespace Glosa.Net.Core.Helpers.Json
{
    /// <summary>
    /// The Utilities Class deals with JSON data parsing
    /// </summary>
    public static class Utilities
    {
        private static readonly JsonPathContext FParser = new JsonPathContext { ValueSystem = new JsonNetValueSystem() };
        /// <summary>
        /// Returns the list of data parsed from a string key
        /// </summary>
        /// <param name="incomingData">The json formatted string</param>
        /// <param name="queryData">The property key</param>
        /// <returns>The list of data</returns>
        public static List<string> parseData(string incomingData, string queryData)
        {
            var jsonObject = JObject.Parse(incomingData);
            return getMetaDataList(jsonObject, queryData);
        }
        /// <summary>
        /// Returns the filtered json data as a list
        /// </summary>
        /// <param name="jsonObject">the json object to parse</param>
        /// <param name="data">the data to filter by</param>
        /// <returns></returns>
        public static List<String> getMetaDataList(JObject jsonObject, string data)
        {
            String textValues = data + ".";
            List<String> val = FParser.SelectNodes(jsonObject, textValues).Select(node => node.Value.ToString()).ToList();
            return val;
        }
        /// <summary>
        /// Gets the parsed data as a list of strings
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<List<String>> getParsedData(JObject jsonObject, String[] values)
        {
            List<String> value;
            List<List<String>> tempStringList = new List<List<String>>();
            foreach (String st in values)
            {
                value = FParser.SelectNodes(jsonObject, st).Select(node => node.Value.ToString()).ToList();
                tempStringList.Add(value);
            }
            return tempStringList;
        }
        /// <summary>
        /// Creates the input values dictionary
        /// </summary>
        /// <param name="stringKeys">the keys</param>
        /// <param name="stringValues">the values</param>
        /// <returns></returns>
        public static Dictionary<string,string> createInputDictionary(string[] stringKeys, string[] stringValues)
        {
            Dictionary<string, string> inputDictionary = new Dictionary<string, string>();
            int count = 0;
            if (stringKeys.Length == stringValues.Length)
            {
                foreach (string s in stringKeys)
                {
                    inputDictionary.Add(s, stringValues[count]);
                    count++;
                }
            }
            return inputDictionary; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static string GenerateJsonFromPoints(IVector[] points, int degree)
        {
            string s = "";
            s += @"{""degree"":" + degree.ToString() + "," + @"""points"":[";
            int type = points[0].Dimension();
            int count = 0;
            foreach (IVector p in points)
            {
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                    case 2:
                        GlosaVector2 gv2 = (GlosaVector2)p;
                        if (count == 0) { s += @"{""x"":" + gv2.x.ToString() + "," + @"""y"":" + gv2.y.ToString() + "}"; }
                        else { s += @",{""x"":" + gv2.x.ToString() + @",""y"":" + gv2.y.ToString() + "}"; }
                        break;
                    case 3:
                        GlosaVector3 gv3 = (GlosaVector3)p;
                        if (count == 0) { s += @"{""x"":" + gv3.x.ToString() + "," + @"""y"":" + gv3.y.ToString() + "," + @"""z"":" + gv3.z.ToString() + "}"; }
                        else { s += @",{""x"":" + gv3.x.ToString() + @",""y"":" + gv3.y.ToString() + @",""z"":" + gv3.z.ToString() + "}"; }
                        break;
                    case 4:
                        GlosaVector4 gv4 = (GlosaVector4)p;
                        if (count == 0)
                        {
                            s += @"{""x"":" + gv4.x.ToString() + "," + @"""y"":" + gv4.y.ToString() + "," + @"""z"":" +
                                gv4.z.ToString() + "," + @"""w"":" + gv4.w.ToString() + "}";
                        }
                        else
                        {
                            s += @",{""x"":" + gv4.x.ToString() + @",""y"":" + gv4.y.ToString() + @",""z"":" +
                                gv4.z.ToString() + @",""w"":" + gv4.w.ToString() + "}";
                        }
                        break;
                    default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                }
                count++;
            }
            s += "]}";
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string GenerateJsonFromArray(double[] values)
        {
            string s = "";
            s += @"{""data"":[";
            int count = 0;
            foreach (double d in values)
            {
                if (count == 0)
                {
                    s += d.ToString();
                }
                else
                {
                    s += ", " + d.ToString();
                }
                count++;
            }
            s += "]}";
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<double> ParseNurbsComponents(string data, string key)
        {
            return Utilities.parseData(data, key + ".*").Select(x => double.Parse(x)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<double> ParseArray(string data, string key)
        {
            return Utilities.parseData(data, key + ".*").Select(x => double.Parse(x)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<IVector> ParsePoints(string data, int type, string key)
        {
            List<List<string>> vertList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    throw new System.ArgumentException("Object has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Object cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    vertList.Add(Utilities.parseData(data, key + ".*.x"));
                    vertList.Add(Utilities.parseData(data, key + ".*.y"));
                    break;
                case 3:
                    vertList.Add(Utilities.parseData(data, key + ".*.x"));
                    vertList.Add(Utilities.parseData(data, key + ".*.y"));
                    vertList.Add(Utilities.parseData(data, key + ".*.z"));
                    break;
                case 4:
                    vertList.Add(Utilities.parseData(data, key + ".*.x"));
                    vertList.Add(Utilities.parseData(data, key + ".*.y"));
                    vertList.Add(Utilities.parseData(data, key + ".*.z"));
                    vertList.Add(Utilities.parseData(data, key + ".*.w"));
                    break;
            }
            int count = 0;
            List<IVector> gverts = new List<IVector>();
            foreach (string str in vertList[0])
            {
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("Object has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("Object cannot have GlosaVectors of dimension 1", "dimension");
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
        public static List<GlosaLineSegment> ParseSegments(string data, int type)
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
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IVector ParseCircleData(string data, int type)
        {
            List<string> vectorData = Utilities.parseData(data, "center.*");
            switch (type)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    return new GlosaVector2(Convert.ToDouble(vectorData[0]), Convert.ToDouble(vectorData[1]));
                case 3:
                    return new GlosaVector3(Convert.ToDouble(vectorData[0]), Convert.ToDouble(vectorData[1]), Convert.ToDouble(vectorData[2]));
                case 4:
                    return new GlosaVector4(Convert.ToDouble(vectorData[0]), Convert.ToDouble(vectorData[1]), Convert.ToDouble(vectorData[2]), Convert.ToDouble(vectorData[3]));
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }
    }
}
