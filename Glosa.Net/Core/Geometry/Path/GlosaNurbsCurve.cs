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
        //, ICopy<GlosaNurbsCurve>, IDimension<GlosaNurbsCurve>, IHash<GlosaNurbsCurve>, IEquals<GlosaNurbsCurve>, IString<GlosaNurbsCurve>,
        //IClosest<GlosaNurbsCurve>
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
        private static extern IntPtr homogenizeArray_v1_curve(string s1, string s2);
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
            this.controlPoints = ParseControlPoints(incomingData, points[0].Dimension(), "controlPoints").ToArray();
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

        private static string GenerateJsonFromPoints(IVector[] points, int degree)
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

        private static string GenerateJsonFromArray(double[] values)
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

        private static List<double> ParseNurbsComponents(string data, string key)
        {
            return Utilities.parseData(data, key + ".*").Select(x => double.Parse(x)).ToList();
        }

        private static List<double> ParseArray(string data, string key)
        {
            return Utilities.parseData(data, key + ".*").Select(x => double.Parse(x)).ToList();
        }

        private static List<IVector> ParseControlPoints(string data, int type, string key)
        {
            List<List<string>> vertList = new List<List<string>>();
            switch (type)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public GlosaVector3 Homogenize(GlosaVector2 vector, double weight)
        {
            try { return homogenize_v2_curve(vector, weight); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public GlosaVector4 Homogenize(GlosaVector3 vector, double weight)
        {
            try { return homogenize_v3_curve(vector, weight); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static List<GlosaVector3> Homogenize(GlosaVector2[] points, double[] weights)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = homogenizeArray_v2_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3), GenerateJsonFromArray(weights));
                return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() + 1, "points").Select(x => ((GlosaVector3)x)).ToList();
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static List<GlosaVector4> Homogenize(GlosaVector3[] points, double[] weights)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = homogenizeArray_v3_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3), GenerateJsonFromArray(weights));
                return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() + 1, "points").Select(x => ((GlosaVector4)x)).ToList();
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static List<IVector> Homogenize(IVector[] points, double[] weights)
        {
            switch (points[0].Dimension())
            {
                case 0:
                    throw new System.ArgumentException("Cannot homogenize a set of Vector0s", "dimension");
                case 1:
                    try
                    {
                        IntPtr pStr = homogenizeArray_v1_curve(GenerateJsonFromPoints(points, 3), GenerateJsonFromArray(weights));
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() + 1, "points");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 2:
                    try
                    {
                        IntPtr pStr = homogenizeArray_v2_curve(GenerateJsonFromPoints(points, 3), GenerateJsonFromArray(weights));
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() + 1, "points");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = homogenizeArray_v3_curve(GenerateJsonFromPoints(points, 3), GenerateJsonFromArray(weights));
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() + 1, "points");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot homogenize a set of Vector4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public GlosaVector2 Dehomogenize(GlosaVector3 vector)
        {
            try { return dehomogenize_v2_curve(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public GlosaVector3 Dehomogenize(GlosaVector4 vector)
        {
            try { return dehomogenize_v3_curve(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static List<GlosaVector2> Dehomogenize(GlosaVector3[] points)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = dehomogenizeArray_v3_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3));
                return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() - 1, "points").Select(x => ((GlosaVector2)x)).ToList();
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static List<GlosaVector3> Dehomogenize(GlosaVector4[] points)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = dehomogenizeArray_v4_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3));
                return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() - 1, "points").Select(x => ((GlosaVector3)x)).ToList();
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static List<IVector> Dehomogenize(IVector[] points)
        {
            switch (points[0].Dimension())
            {
                case 0:
                    throw new System.ArgumentException("Cannot dehomogenize a set of Vector0s", "dimension");
                case 1:
                    throw new System.ArgumentException("Cannot dehomogenize a set of Vector1s", "dimension");
                case 2:
                    throw new System.ArgumentException("Cannot dehomogenize a set of Vector2s", "dimension");
                case 3:
                    try
                    {
                        IntPtr pStr = dehomogenizeArray_v3_curve(GenerateJsonFromPoints(points, 3));
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() - 1, "points");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try
                    {
                        IntPtr pStr = dehomogenizeArray_v4_curve(GenerateJsonFromPoints(points, 3));
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), points[0].Dimension() - 1, "points");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Weight(GlosaVector2 vector)
        {
            try { return weight_v2_curve(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Weight(GlosaVector3 vector)
        {
            try { return weight_v3_curve(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public double Weight(GlosaVector4 vector)
        {
            try { return weight_v4_curve(vector); }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public List<double> Weights(GlosaVector2[] points)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = weights_v2_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3));
                return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public List<double> Weights(GlosaVector3[] points)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = weights_v3_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3));
                return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public List<double> Weights(GlosaVector4[] points)
        {
            try
            {
                List<IVector> ivecArray = points.Select(x => ((IVector)x)).ToList();
                IntPtr pStr = weights_v4_curve(GenerateJsonFromPoints(ivecArray.ToArray(), 3));
                return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
            }
            catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static List<double> Weights(IVector[] points)
        {
            switch (points[0].Dimension())
            {
                case 0:
                    throw new System.ArgumentException("Cannot generate weights of Vector0s", "dimension");
                case 1:
                    throw new System.ArgumentException("Cannot generate weights of Vector1s", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = weights_v2_curve(GenerateJsonFromPoints(points, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = weights_v3_curve(GenerateJsonFromPoints(points, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try
                    {
                        IntPtr pStr = weights_v4_curve(GenerateJsonFromPoints(points, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <returns></returns>
        public static List<double> Weights(GlosaNurbsCurve nc)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Cannot generate weights of Vector0s", "dimension");
                case 1:
                    throw new System.ArgumentException("Cannot generate weights of Vector1s", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = weights_v2_curve(GenerateJsonFromPoints(nc.controlPoints, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = weights_v3_curve(GenerateJsonFromPoints(nc.controlPoints, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try
                    {
                        IntPtr pStr = weights_v4_curve(GenerateJsonFromPoints(nc.controlPoints, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<double> Weights()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Cannot generate weights of Vector0s", "dimension");
                case 1:
                    throw new System.ArgumentException("Cannot generate weights of Vector1s", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = weights_v2_curve(GenerateJsonFromPoints(this.controlPoints, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = weights_v3_curve(GenerateJsonFromPoints(this.controlPoints, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try
                    {
                        IntPtr pStr = weights_v4_curve(GenerateJsonFromPoints(this.controlPoints, 3));
                        return ParseArray(Marshal.PtrToStringAnsi(pStr), "data");
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Determines whether the specified GlosaNurbsCurve has the same value as the present GlosaNurbsCurve.
        /// </summary>
        /// <param name="curve">The other GlosaNurbsCurve to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaNurbsCurve curve)
        {
            return this == curve;
        }

        /// <summary>
        /// Determines whether two GlosaNurbsCurve have equal values.
        /// </summary>
        /// <param name="a">The first GlosaNurbsCurve</param>
        /// <param name="b">The second GlosaNurbsCurve</param>
        /// <returns>True if components of the two GlosaNurbsCurve are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaNurbsCurve a, GlosaNurbsCurve b)
        {
            switch (a.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (b.dimension != 2) { return false; }
                    try { return equals_v2_curve(a.Serialize(), b.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (b.dimension != 3) { return false; }
                    try { return equals_v3_curve(a.Serialize(), b.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Equals is not set up for NurbsCurve made up of GlosaVectors of dimension 4", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Determines whether two GlosaNurbsCurve have different values.
        /// </summary>
        /// <param name="a">The first GlosaNurbsCurve</param>
        /// <param name="b">The second GlosaNurbsCurve</param>
        /// <returns>True if any component of the two GlosaNurbsCurve is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaNurbsCurve a, GlosaNurbsCurve b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <returns></returns>
        public static List<IVector> WeightedControlPoints(GlosaNurbsCurve nc)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = weightedControlPoints_v2_curve(nc.Serialize());
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = weightedControlPoints_v3_curve(nc.Serialize());
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get weighted control points for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IVector> WeightedControlPoints()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = weightedControlPoints_v2_curve(this.Serialize());
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = weightedControlPoints_v3_curve(this.Serialize());
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get weighted control points for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public IVector RationalSample(double u)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return rationalSample_v2_curve(this.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return rationalSample_v3_curve(this.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static IVector RationalSample(GlosaNurbsCurve nc, double u)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return rationalSample_v2_curve(nc.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return rationalSample_v3_curve(nc.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<IVector> RationalSample(GlosaNurbsCurve nc, int n)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rationalRegularSample_v2_curve(nc.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = rationalRegularSample_v3_curve(nc.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IVector> RationalSample(int n)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rationalRegularSample_v2_curve(this.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = rationalRegularSample_v3_curve(this.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Rational Sample Derrivatives
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="u"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<IVector> RationalSample(GlosaNurbsCurve nc, double u, int n)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rationalSampleDerrivatives_v2_curve(nc.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = rationalSampleDerrivatives_v3_curve(nc.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Rational Sample Derrivatives
        /// </summary>
        /// <param name="u"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<IVector> RationalSample(double u, int n)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rationalSampleDerrivatives_v2_curve(this.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = rationalSampleDerrivatives_v3_curve(this.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension + 1, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public IVector Sample(double u)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return sample_v2_curve(this.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return sample_v3_curve(this.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get Sample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static IVector Sample(GlosaNurbsCurve nc, double u)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return sample_v2_curve(nc.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return sample_v3_curve(nc.Serialize(), u); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get Sample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Regular Sample
        /// </summary>
        /// <param name="uStart"></param>
        /// <param name="uEnd"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<IVector> Sample(double uStart, double uEnd, int n)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = regularSample_v2_curve(this.Serialize(), uStart, uEnd, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = regularSample_v3_curve(this.Serialize(), uStart, uEnd, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RegularSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Regular Sample
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="uStart"></param>
        /// <param name="uEnd"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<IVector> Sample(GlosaNurbsCurve nc, double uStart, double uEnd, int n)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = regularSample_v2_curve(nc.Serialize(), uStart, uEnd, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = regularSample_v3_curve(nc.Serialize(), uStart, uEnd, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RegularSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Regular Sample 2
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<IVector> Sample(int n)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = regularSample2_v2_curve(this.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = regularSample2_v3_curve(this.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RegularSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Regular Sample 2
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<IVector> Sample(GlosaNurbsCurve nc, int n)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = regularSample2_v2_curve(nc.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = regularSample2_v3_curve(nc.Serialize(), n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RegularSample for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Sample Derrivatives
        /// </summary>
        /// <param name="u"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<IVector> Sample(double u, int n)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = sampleDerivatives_v2_curve(this.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = sampleDerivatives_v3_curve(this.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), this.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get Sample Derrivatives for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Sample Derrivatives
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="u"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<IVector> Sample(GlosaNurbsCurve nc, double u, int n)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = sampleDerivatives_v2_curve(nc.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = sampleDerivatives_v3_curve(nc.Serialize(), u, n);
                        return ParseControlPoints(Marshal.PtrToStringAnsi(pStr), nc.dimension, "points").ToList();
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get Sample Derrivatives for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double RationalClosestParameter(IVector v)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to get ClosestParameter", "IVector");
                    try { return rationalClosestParameter_v2_curve(this.Serialize(), (GlosaVector2)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to get ClosestParameter", "IVector");
                    try { return rationalClosestParameter_v3_curve(this.Serialize(), (GlosaVector3)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalClosestParameter for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static double RationalClosestParameter(GlosaNurbsCurve nc, IVector v)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to get ClosestParameter", "IVector");
                    try { return rationalClosestParameter_v2_curve(nc.Serialize(), (GlosaVector2)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to get ClosestParameter", "IVector");
                    try { return rationalClosestParameter_v3_curve(nc.Serialize(), (GlosaVector3)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get RationalClosestParameter for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double ClosestParameter(IVector v)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to get ClosestParameter", "IVector");
                    try { return closestParameter_v2_curve(this.Serialize(), (GlosaVector2)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to get ClosestParameter", "IVector");
                    try { return closestParameter_v3_curve(this.Serialize(), (GlosaVector3)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestParameter for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static double ClosestParameter(GlosaNurbsCurve nc, IVector v)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to get ClosestParameter", "IVector");
                    try { return closestParameter_v2_curve(nc.Serialize(), (GlosaVector2)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to get ClosestParameter", "IVector");
                    try { return closestParameter_v3_curve(nc.Serialize(), (GlosaVector3)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestParameter for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IVector ClosestPoint(IVector v)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to get ClosestPoint", "IVector");
                    try { return closestPoint_v2_curve(this.Serialize(), (GlosaVector2)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to get ClosestPoint", "IVector");
                    try { return closestPoint_v3_curve(this.Serialize(), (GlosaVector3)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestPoint for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static IVector ClosestPoint(GlosaNurbsCurve nc, IVector v)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to get ClosestPoint", "IVector");
                    try { return closestPoint_v2_curve(nc.Serialize(), (GlosaVector2)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to get ClosestPoint", "IVector");
                    try { return closestPoint_v3_curve(nc.Serialize(), (GlosaVector3)v); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestPoint for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This NurbsCurve is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "matrix");
                    }
                    try
                    {
                        IntPtr pStr = transform_v2_curve(this.Serialize(), (GlosaMatrix33)matrix);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This NurbsCurve is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "matrix");
                    }
                    try
                    {
                        IntPtr pStr = transform_v3_curve(this.Serialize(), (GlosaMatrix44)matrix);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestPoint for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public GlosaNurbsCurve TransformNew(IMatrixes matrix)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This NurbsCurve is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "matrix");
                    }
                    try
                    {
                        IntPtr pStr = transform_v2_curve(this.Serialize(), (GlosaMatrix33)matrix);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        return new GlosaNurbsCurve(ParseControlPoints(data, this.dimension, "controlPoints").ToArray(),
                            ParseNurbsComponents(data, "weights").ToArray(), ParseNurbsComponents(data, "knots").ToArray(),
                            Convert.ToInt32(Utilities.parseData(data, "degree.")[0]));
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This NurbsCurve is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "matrix");
                    }
                    try
                    {
                        IntPtr pStr = transform_v3_curve(this.Serialize(), (GlosaMatrix44)matrix);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        return new GlosaNurbsCurve(ParseControlPoints(data, this.dimension, "controlPoints").ToArray(),
                            ParseNurbsComponents(data, "weights").ToArray(), ParseNurbsComponents(data, "knots").ToArray(),
                            Convert.ToInt32(Utilities.parseData(data, "degree.")[0]));
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestPoint for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static GlosaNurbsCurve Transform(GlosaNurbsCurve nc, IMatrixes matrix)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This NurbsCurve is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "matrix");
                    }
                    try
                    {
                        IntPtr pStr = transform_v2_curve(nc.Serialize(), (GlosaMatrix33)matrix);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        return new GlosaNurbsCurve(ParseControlPoints(data, nc.dimension, "controlPoints").ToArray(),
                            ParseNurbsComponents(data, "weights").ToArray(), ParseNurbsComponents(data, "knots").ToArray(),
                            Convert.ToInt32(Utilities.parseData(data, "degree.")[0]));
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This NurbsCurve is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "matrix");
                    }
                    try
                    {
                        IntPtr pStr = transform_v3_curve(nc.Serialize(), (GlosaMatrix44)matrix);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        return new GlosaNurbsCurve(ParseControlPoints(data, nc.dimension, "controlPoints").ToArray(),
                            ParseNurbsComponents(data, "weights").ToArray(), ParseNurbsComponents(data, "knots").ToArray(),
                            Convert.ToInt32(Utilities.parseData(data, "degree.")[0]));
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot get ClosestPoint for Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        public void RotateSelf(double theta)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rotate_v2_curve(this.Serialize(), theta);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 3:
                    throw new System.ArgumentException("This is a 3 Dimensional Nurbs Curve please use Rotate Axis method", "dimension");
                case 4:
                    throw new System.ArgumentException("Cannot Rotate Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static GlosaNurbsCurve Rotate(GlosaNurbsCurve nc, double theta)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rotate_v2_curve(nc.Serialize(), theta);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        nc.controlPoints = ParseControlPoints(data, nc.dimension, "controlPoints").ToArray();
                        nc.weights = ParseNurbsComponents(data, "weights").ToArray();
                        nc.knots = ParseNurbsComponents(data, "knots").ToArray();
                        nc.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                        return nc;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    throw new System.ArgumentException("This is a 3 Dimensional Nurbs Curve please use Rotate Axis method", "dimension");
                case 4:
                    throw new System.ArgumentException("Cannot Rotate Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="theta"></param>
        public void RotateAxisSelf(GlosaVector3 axis, double theta)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    throw new System.ArgumentException("This is a 2 Dimensional Nurbs Curve please use Rotate method", "dimension");
                case 3:
                    try
                    {
                        IntPtr pStr = rotate_v3_curve(this.Serialize(), axis, theta);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 4:
                    throw new System.ArgumentException("Cannot Rotate Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="axis"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static GlosaNurbsCurve RotateAxis(GlosaNurbsCurve nc, GlosaVector3 axis, double theta)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    throw new System.ArgumentException("This is a 2 Dimensional Nurbs Curve please use Rotate method", "dimension");
                case 3:
                    try
                    {
                        IntPtr pStr = rotate_v3_curve(nc.Serialize(), axis, theta);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        nc.controlPoints = ParseControlPoints(data, nc.dimension, "controlPoints").ToArray();
                        nc.weights = ParseNurbsComponents(data, "weights").ToArray();
                        nc.knots = ParseNurbsComponents(data, "knots").ToArray();
                        nc.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                        return nc;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot Rotate Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        public void ScaleSelf(double sx, double sy, double sz = 1)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = scale_v2_curve(this.Serialize(), sx, sy);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 3:
                    try
                    {
                        IntPtr pStr = scale_v3_curve(this.Serialize(), sx, sy, sz);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 4:
                    throw new System.ArgumentException("Cannot Scale Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        public static GlosaNurbsCurve ScaleNew(GlosaNurbsCurve nc, double sx, double sy, double sz = 1)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = scale_v2_curve(nc.Serialize(), sx, sy);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        nc.controlPoints = ParseControlPoints(data, nc.dimension, "controlPoints").ToArray();
                        nc.weights = ParseNurbsComponents(data, "weights").ToArray();
                        nc.knots = ParseNurbsComponents(data, "knots").ToArray();
                        nc.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                        return nc;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = scale_v3_curve(nc.Serialize(), sx, sy, sz);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        nc.controlPoints = ParseControlPoints(data, nc.dimension, "controlPoints").ToArray();
                        nc.weights = ParseNurbsComponents(data, "weights").ToArray();
                        nc.knots = ParseNurbsComponents(data, "knots").ToArray();
                        nc.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                        return nc;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot Scale Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public void TranslateSelf(IVector v)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to use for Translate", "IVector");
                    try
                    {
                        IntPtr pStr = translate_v2_curve(this.Serialize(), (GlosaVector2)v);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to use for Translate", "IVector");
                    try
                    {
                        IntPtr pStr = translate_v3_curve(this.Serialize(), (GlosaVector3)v);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        this.controlPoints = ParseControlPoints(data, this.dimension, "controlPoints").ToArray();
                        this.weights = ParseNurbsComponents(data, "weights").ToArray();
                        this.knots = ParseNurbsComponents(data, "knots").ToArray();
                        this.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                    break;
                case 4:
                    throw new System.ArgumentException("Cannot Translate Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static GlosaNurbsCurve Translate(GlosaNurbsCurve nc, IVector v)
        {
            switch (nc.dimension)
            {
                case 0:
                    throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (v.Dimension() != 2) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector2s please input GlosaVector2 to use for Translate", "IVector");
                    try
                    {
                        IntPtr pStr = translate_v2_curve(nc.Serialize(), (GlosaVector2)v);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        nc.controlPoints = ParseControlPoints(data, nc.dimension, "controlPoints").ToArray();
                        nc.weights = ParseNurbsComponents(data, "weights").ToArray();
                        nc.knots = ParseNurbsComponents(data, "knots").ToArray();
                        nc.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                        return nc;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (v.Dimension() != 3) throw new System.ArgumentException("NurbsCurve is made up of GlosaVector3s please input GlosaVector3 to use for Translate", "IVector");
                    try
                    {
                        IntPtr pStr = translate_v3_curve(nc.Serialize(), (GlosaVector3)v);
                        string data = Marshal.PtrToStringAnsi(pStr);
                        nc.controlPoints = ParseControlPoints(data, nc.dimension, "controlPoints").ToArray();
                        nc.weights = ParseNurbsComponents(data, "weights").ToArray();
                        nc.knots = ParseNurbsComponents(data, "knots").ToArray();
                        nc.degree = Convert.ToInt32(Utilities.parseData(data, "degree.")[0]);
                        return nc;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    throw new System.ArgumentException("Cannot Translate Nurbs Curve made up of GlosaVector 4s", "dimension");
                default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
            }
        }
    }
}
