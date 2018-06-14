using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Interfaces;
using Glosa.Net.Core.Helpers;
using Glosa.Net.Core.Helpers.Json;
using Glosa.Net.Core.Geometry.Vector;
using Glosa.Net.Core.Geometry.Matrix;

namespace Glosa.Net.Core.Geometry.Shape
{
    /// <summary>
    /// 
    /// </summary>
    public class GlosaCircle : GlosaObject, ICopy<GlosaCircle>, IDimension<GlosaCircle>, IHash<GlosaCircle>, IEquals<GlosaCircle>, IString<GlosaCircle>,
        IClosest<GlosaCircle>, IShape2<GlosaCircle>
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
            return new GlosaCircle(Utilities.ParseCircleData(data, vectorData.Count), Convert.ToDouble(radiusData[0]));
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
                    try { return contains_v2_circle(this.Serialize(), (GlosaVector2)vector); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }               
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    try { return contains_v3_circle(this.Serialize(), (GlosaVector3)vector); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    try { return contains_v4_circle(this.Serialize(), (GlosaVector4)vector); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return area_v2_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return area_v3_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return area_v4_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return perimeter_v2_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return perimeter_v3_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return perimeter_v4_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Circumference()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return circumference_v2_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return circumference_v3_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return circumference_v4_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IVector Centroid()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return centroid_v2_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return centroid_v3_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return centroid_v4_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return average_v2_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }               
                case 3:
                    try { return average_v3_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return average_v4_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (vector.GetType() != typeof(GlosaVector2))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector2's, please pass a GlosaVector2 to test", "vector");
                    }
                    try { return closestPoint_v2_circle(this.Serialize(), (GlosaVector2)vector); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }                
                case 3:
                    if (vector.GetType() != typeof(GlosaVector3))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector3's, please pass a GlosaVector3 to test", "vector");
                    }
                    try { return closestPoint_v3_circle(this.Serialize(), (GlosaVector3)vector); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    if (vector.GetType() != typeof(GlosaVector4))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector4's, please pass a GlosaVector4 to test", "vector");
                    }
                    try { return closestPoint_v4_circle(this.Serialize(), (GlosaVector4)vector); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Determines whether the specified GlosaCircle has the same value as the present GlosaCircle.
        /// </summary>
        /// <param name="circle">The other GlosaCircle to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaCircle circle)
        {
            return this == circle;
        }

        /// <summary>
        /// Determines whether two GlosaCircle have equal values.
        /// </summary>
        /// <param name="a">The first GlosaCircle</param>
        /// <param name="b">The second GlosaCircle</param>
        /// <returns>True if components of the two GlosaCircle are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaCircle a, GlosaCircle b)
        {
            switch (a.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (b.center.GetType() != typeof(GlosaVector2)) { return false; }
                    try { return equals_v2_circle(a.Serialize(), b.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (b.center.GetType() != typeof(GlosaVector3)) { return false; }
                    try { return equals_v3_circle(a.Serialize(), b.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    if (b.center.GetType() != typeof(GlosaVector4)) { return false; }
                    try { return equals_v4_circle(a.Serialize(), b.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// Determines whether two GlosaCircle have different values.
        /// </summary>
        /// <param name="a">The first GlosaCircle</param>
        /// <param name="b">The second GlosaCircle</param>
        /// <returns>True if any component of the two GlosaCircle is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaCircle a, GlosaCircle b)
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { return hash_v2_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { return hash_v3_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { return hash_v4_circle(this.Serialize()); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
        public GlosaCircle Copy()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = copy_v2_circle(this.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = copy_v3_circle(this.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = copy_v4_circle(this.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static GlosaCircle Copy(GlosaCircle c)
        {
            switch (c.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = copy_v2_circle(c.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = copy_v3_circle(c.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = copy_v4_circle(c.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GlosaCircle Clear()
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = clear_v2_circle(this.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = clear_v3_circle(this.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = clear_v4_circle(this.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static GlosaCircle Clear(GlosaCircle c)
        {
            switch (c.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = clear_v2_circle(c.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = clear_v3_circle(c.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = clear_v4_circle(c.Serialize()); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = stringify_v2_circle(this.Serialize()); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = stringify_v3_circle(this.Serialize()); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = stringify_v4_circle(this.Serialize()); return Marshal.PtrToStringAnsi(pStr); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <returns></returns>
        public GlosaCircle RotateNew(float theta)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = rotate_v2_circle(this.Serialize(), theta); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    throw new System.ArgumentException("Rotate is currently not enabled for Circle made up of GlosaVector3s");
                case 4:
                    throw new System.ArgumentException("Rotate is currently not enabled for Circle made up of GlosaVector4s");
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        public void RotateSelf(float theta)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = rotate_v2_circle(this.Serialize(), theta);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    throw new System.ArgumentException("Rotate is currently not enabled for Circle made up of GlosaVector3s");
                case 4:
                    throw new System.ArgumentException("Rotate is currently not enabled for Circle made up of GlosaVector4s");
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public GlosaCircle ScaleNew(double s)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = scale_v2_circle(this.Serialize(), s); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = scale_v3_circle(this.Serialize(), s); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = scale_v4_circle(this.Serialize(), s); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = scale_v2_circle(this.Serialize(), s);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = scale_v3_circle(this.Serialize(), s);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try
                    {
                        IntPtr pStr = scale_v4_circle(this.Serialize(), s);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public GlosaCircle TranslateNew(double t)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try { IntPtr pStr = translate_v2_circle(this.Serialize(), t); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try { IntPtr pStr = translate_v3_circle(this.Serialize(), t); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try { IntPtr pStr = translate_v4_circle(this.Serialize(), t); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public void TranslateSelf(double t)
        {
            switch (this.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    try
                    {
                        IntPtr pStr = translate_v2_circle(this.Serialize(), t);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    try
                    {
                        IntPtr pStr = translate_v3_circle(this.Serialize(), t);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    try
                    {
                        IntPtr pStr = translate_v4_circle(this.Serialize(), t);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public GlosaCircle TransformNew(GlosaCircle c, IMatrixes matrix)
        {
            switch (c.dimension)
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "vector");
                    }
                    try { IntPtr pStr = transform_v2_circle(c.Serialize(), (GlosaMatrix33)matrix); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    try { IntPtr pStr = transform_v3_circle(c.Serialize(), (GlosaMatrix44)matrix); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector4's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    try { IntPtr pStr = transform_v4_circle(c.Serialize(), (GlosaMatrix44)matrix); return Deserialize(Marshal.PtrToStringAnsi(pStr)); }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
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
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if (matrix.GetType() != typeof(GlosaMatrix33))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector2's, please pass a GlosaMatrix33 to use for transforms", "vector");
                    }
                    try
                    {
                        IntPtr pStr = transform_v2_circle(this.Serialize(), (GlosaMatrix33)matrix);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 3:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector3's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    try
                    {
                        IntPtr pStr = transform_v3_circle(this.Serialize(), (GlosaMatrix44)matrix);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                case 4:
                    if (matrix.GetType() != typeof(GlosaMatrix44))
                    {
                        throw new System.ArgumentException("This Circle is made up of GlosaVector4's, please pass a GlosaMatrix44 to use for transforms", "vector");
                    }
                    try
                    {
                        IntPtr pStr = transform_v4_circle(this.Serialize(), (GlosaMatrix44)matrix);
                        GlosaCircle circl = Deserialize(Marshal.PtrToStringAnsi(pStr));
                        this.center = circl.center;
                        this.radius = circl.radius;
                        break;
                    }
                    catch (Exception e) { throw new System.ArgumentException(e.Message.ToString()); }
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }
    }
}
