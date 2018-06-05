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

namespace Glosa.Net.Core.Geometry.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    public class GlosaCircle : GlosaObject
    {
        #region C Reference Procs
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v2_circle(string s, GlosaVector2 v);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v3_circle(string s, GlosaVector3 v);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool contains_v4_circle(string s, GlosaVector4 v);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double area_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double area_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double area_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double perimeter_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double perimeter_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double perimeter_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double circumference_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double circumference_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double circumference_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 centroid_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 centroid_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 centroid_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 average_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 average_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 average_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector2 closestPoint_v2_circle(string s, GlosaVector2 v);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector3 closestPoint_v3_circle(string s, GlosaVector3 v);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern GlosaVector4 closestPoint_v4_circle(string s, GlosaVector4 v);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v2_circle(string s1, string s2);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v3_circle(string s1, string s2);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool equals_v4_circle(string s1, string s2);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int hash_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int dimension_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr copy_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr clear_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr clear_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr clear_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v2_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v3_circle(string s);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v4_circle(string s);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rotate_v2_circle(string s, double theta);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v2_circle(string s, double f);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v3_circle(string s, double f);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr scale_v4_circle(string s, double f);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v2_circle(string s, double t);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v3_circle(string s, double t);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr translate_v4_circle(string s, double t);

        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v2_circle(string s, GlosaMatrix33 m);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v3_circle(string s, GlosaMatrix44 m);
        [DllImport("wrapper_shape.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr transform_v4_circle(string s, GlosaMatrix44 m);
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public double radius;
        /// <summary>
        /// 
        /// </summary>
        public IVector center;
        private int dimension;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="rad"></param>
        public GlosaCircle(IVector v, double rad)
        {
            this.radius = rad;
            this.center = v;
            this.dimension = v.Dimension();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        public GlosaCircle(double x, double y, double rad)
        {
            this.radius = rad;
            this.center = new GlosaVector2(x, y);
            this.dimension = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="rad"></param>
        public GlosaCircle(double x, double y, double z, double rad)
        {
            this.radius = rad;
            this.center = new GlosaVector3(x, y, z);
            this.dimension = 3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        public GlosaCircle(IVector vector1, IVector vector2)
        {
            switch (vector1.Dimension())
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if(vector2.Dimension() != 2) { throw new System.ArgumentException("Cannot create circle with 2 GlosaVectors of different dimensions"); }
                    GlosaVector2 gv = GlosaVector2.InterpolateNew((GlosaVector2)vector1, (GlosaVector2)vector2, 0.5);
                    this.center = gv;
                    this.radius = gv.DistanceTo((GlosaVector2)vector2);
                    break;
                case 3:
                    if (vector2.Dimension() != 2) { throw new System.ArgumentException("Cannot create circle with 2 GlosaVectors of different dimensions"); }
                    GlosaVector3 gv3 = GlosaVector3.InterpolateNew((GlosaVector3)vector1, (GlosaVector3)vector2, 0.5);
                    this.center = gv3;
                    this.radius = gv3.DistanceTo((GlosaVector3)vector2);
                    break;
                case 4:
                    if (vector2.Dimension() != 2) { throw new System.ArgumentException("Cannot create circle with 2 GlosaVectors of different dimensions"); }
                    GlosaVector4 gv4 = GlosaVector4.InterpolateNew((GlosaVector4)vector1, (GlosaVector4)vector2, 0.5);
                    this.center = gv4;
                    this.radius = gv4.DistanceTo((GlosaVector4)vector2);
                    break;
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static GlosaCircle Deserialize(string data)
        {
            List<string> vectorData = Utilities.parseData(data, "center.*");
            List<string> radiusData = Utilities.parseData(data, "radius.");
            return new GlosaCircle(ParseCircleData(data, vectorData.Count), Convert.ToDouble(radiusData[0]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IVector ParseCircleData(string data, int type)
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    return contains_v2_circle(this.Serialize(), (GlosaVector2)vector);
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    return contains_v3_circle(this.Serialize(), (GlosaVector3)vector);
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    return contains_v4_circle(this.Serialize(), (GlosaVector4)vector);
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }
    }
}
