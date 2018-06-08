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
    public class GlosaNurbsCurve : GlosaObject
    {
        #region C Reference Procs
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr interpolateCurve_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr interpolateCurve_v3_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 homogenize_v2_curve(GlosaVector2 v, double weight);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 homogenize_v3_curve(GlosaVector3 v, double weight);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr homogenizeArray_v2_curve(string s1, string s2);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr homogenizeArray_v3_curve(string s1, string s2);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 dehomogenize_v2_curve(GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 dehomogenize_v3_curve(GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr dehomogenizeArray_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr dehomogenizeArray_v3_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr dehomogenizeArray_v4_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double weight_v2_curve(GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double weight_v3_curve(GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double weight_v4_curve(GlosaVector4 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr weights_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr weights_v3_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr weights_v4_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v2_curve(string s1, string s2);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v3_curve(string s1, string s2);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr weightedControlPoints_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr weightedControlPoints_v3_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 rationalSample_v2_curve(string s, double u);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 rationalSample_v3_curve(string s, double u);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rationalRegularSample_v2_curve(string s, int n);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rationalRegularSample_v3_curve(string s, int n);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rationalSampleDerrivatives_v2_curve(string s, double u, int n);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rationalSampleDerrivatives_v3_curve(string s, double u, int n);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 sample_v2_curve(string s, double u);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 sample_v3_curve(string s, double u);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr regularSample_v2_curve(string s, double uStart, double uEnd, int n);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr regularSample_v3_curve(string s, double uStart, double uEnd, int n);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr regularSample2_v2_curve(string s, int n);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr regularSample2_v3_curve(string s, int n);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr sampleDerivatives_v2_curve(string s, double u, int n);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr sampleDerivatives_v3_curve(string s, double u, int n);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double rationalClosestParameter_v2_curve(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double rationalClosestParameter_v3_curve(string s, GlosaVector3 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double closestParameter_v2_curve(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double closestParameter_v3_curve(string s, GlosaVector3 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 closestPoint_v2_curve(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 closestPoint_v3_curve(string s, GlosaVector3 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v2_curve(string s, GlosaMatrix33 m);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v3_curve(string s, GlosaMatrix44 m);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v2_curve(string s, double theta);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v3_curve(string s, GlosaVector3 axis, double theta);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v2_curve(string s, double sx, double sy);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v3_curve(string s, double sx, double sy, double sz);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v2_curve(string s, GlosaVector2 v);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v3_curve(string s, GlosaVector3 v);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v3_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v3_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v3_curve(string s);

        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v2_curve(string s);
        [DllImport("wrapper_path.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v3_curve(string s);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public int degree;

        /// <summary>
        /// 
        /// </summary>
        public IVector[] controlPoints;

        /// <summary>
        /// 
        /// </summary>
        public double[] weights;

        /// <summary>
        /// 
        /// </summary>
        public double[] knots;
        private int dimension;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="degree"></param>
        public GlosaNurbsCurve(IVector[] points, int degree = 3)
        {
            string incomingData = InterpolateCurve(GenerateJsonFromPoints(points, degree));
            this.controlPoints = ParseControlPoints(incomingData, points[0].Dimension()).ToArray();
            this.weights = ParseNurbsComponents(incomingData, "weights").ToArray();
            this.knots = ParseNurbsComponents(incomingData, "knots").ToArray();
            this.degree = degree;
            this.dimension = this.controlPoints[0].Dimension();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="weights"></param>
        /// <param name="knots"></param>
        /// <param name="degree"></param>
        public GlosaNurbsCurve(IVector[] controlPoints, double[] weights, double[] knots, int degree = 3)
        {
            this.controlPoints = controlPoints;
            this.weights = weights;
            this.knots = knots;
            this.degree = degree;
            this.dimension = controlPoints[0].Dimension();
        }

        private string GenerateJsonFromPoints(IVector[] points, int degree)
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

        private static List<double> ParseNurbsComponents(string data, string key)
        {
            return Utilities.parseData(data, key + ".*").Select(x => double.Parse(x)).ToList();
        }

        private static List<double> ParseArray(string data, string key)
        {
            return Utilities.parseData(data, key + ".*").Select(x => double.Parse(x)).ToList();
        }

        private static List<IVector> ParseControlPoints(string data, int type)
        {
            List<List<string>> vertList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.x"));
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.y"));
                    break;
                case 3:
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.x"));
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.y"));
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.z"));
                    break;
                case 4:
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.x"));
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.y"));
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.z"));
                    vertList.Add(Utilities.parseData(data, "controlPoints.*.w"));
                    break;
            }
            int count = 0;
            List<IVector> gverts = new List<IVector>();
            foreach (string str in vertList[0])
            {
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
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

        private string InterpolateCurve(string s)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = interpolateCurve_v2_curve(s); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = interpolateCurve_v3_curve(s); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 4", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }
    }
}
