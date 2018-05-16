using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Glosa.Net.Core.Geometry
{
    /// <summary>
    /// Represents the two components of a vector in two-dimensional space
    /// </summary>
    public struct GlosaVector2 : IVector<GlosaVector2>, ILength<GlosaVector2>, IEquals<GlosaVector2>, IString<GlosaVector2>, ICompare<GlosaVector2>,
        IClear<GlosaVector2>, IDimension<GlosaVector2>, IHash<GlosaVector2>, ICopy<GlosaVector2>
    {
        #region C Reference Procs
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 addNew_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 addSelf_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 subtractNew_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 subtractSelf_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 divideNew_v2(GlosaVector2 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 divideSelf_v2(GlosaVector2 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 multiplyNew_v2(GlosaVector2 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 multiplySelf_v2(GlosaVector2 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern double cross_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern double dot_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 inverseNew_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 inverseSelf_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double heading_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 reflectNew_v2(GlosaVector2 v, GlosaVector2 n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 reflectSelf_v2(GlosaVector2 v, GlosaVector2 n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 refractNew_v2(GlosaVector2 v, GlosaVector2 n, double eta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 refractSelf_v2(GlosaVector2 v, GlosaVector2 n, double eta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 normalizeNew_v2(GlosaVector2 v, double m = 1.0);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 normalizeSelf_v2(GlosaVector2 v, double m = 1.0);
        [DllImport("wrapper_vector.dll")]
        private static extern float angleBetween_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 clear_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern int dimension_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 copy_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 set_v2(GlosaVector2 v, double n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 set2_v2(GlosaVector2 v, double x, double y);
        [DllImport("wrapper_vector.dll")]
        private static extern double magnitude_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double magnitudeSquared_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern bool greaterThan_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool greaterThanEqual_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool lessThan_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool lessThanEqual_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool equals_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool notEqual_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern int hash_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern void toArray_v2(GlosaVector2 v, double[] array);
        [DllImport("wrapper_vector.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_v2(GlosaVector2 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 fromArray_v2(double[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern double distanceToSquared_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 interpolateTo_v2(GlosaVector2 v1, GlosaVector2 v2, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 min_v2(GlosaVector2[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 max_v2(GlosaVector2[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 toVector3(GlosaVector2 vector);
        #endregion
        private double m_x, m_y;

        /// <summary>
        /// Gets or sets the X (first) component of this vector.
        /// </summary>
        public double x { get { return m_x; } set { m_x = value; } }

        /// <summary>
        /// Gets or sets the Y (second) component of this vector.
        /// </summary>
        public double y { get { return m_y; } set { m_y = value; } }

        /// <summary>
        /// Initializes a new instance of the vector based on two, X and Y, components.
        /// </summary>
        /// <param name="x">The X (first) component.</param>
        /// <param name="y">The Y (second) component.</param>
        public GlosaVector2(double x, double y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        /// <summary>
        /// Sums up two GlosaVector2.
        /// </summary>
        /// <param name="vector">The first GlosaVector2</param>
        /// <param name="vector2">The second GlosaVector2</param>
        /// <returns>A new GlosaVector2 that results from the componentwise addition of the two vectors.</returns>
        public static GlosaVector2 AddNew(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return addNew_v2(vector, vector2);
        }
        /// <summary>
        /// Sums up two GlosaVector2.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to add</param>
        /// <returns>A new GlosaVector2 that results from the componentwise addition of the two vectors.</returns>
        public GlosaVector2 AddNew(GlosaVector2 vector)
        {
            return addNew_v2(this, vector);
        }

        /// <summary>
        /// Adds GlosaVector2 and overrides coordinates with result.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to add</param>
        public void AddSelf(GlosaVector2 vector)
        {
            this = addSelf_v2(this, vector);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The first GlosaVector2</param>
        /// <param name="vector2">The second GlosaVector2</param>
        /// <returns>A new GlosaVector2 that results from the componentwise difference of vector1 - vector2.</returns>
        public static GlosaVector2 SubtractNew(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return subtractNew_v2(vector, vector2);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to add</param>
        /// <returns>A new GlosaVector2 that results from the componentwise difference of vector1 - vector2.</returns>
        public GlosaVector2 SubtractNew(GlosaVector2 vector)
        {
            return subtractNew_v2(this, vector);
        }

        /// <summary>
        /// Subtracts GlosaVector2 and overrides coordinates with result.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to subtract</param>
        public void SubtractSelf(GlosaVector2 vector)
        {
            this= subtractSelf_v2(this, vector);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector2 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector2 that is componentwise divided by f</returns>
        public static GlosaVector2 DivideNew(GlosaVector2 vector, double f)
        {
            return divideNew_v2(vector, f);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector2 that is componentwise divided by f</returns>
        public GlosaVector2 DivideNew(double f)
        {
            return divideNew_v2(this, f);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to divide by</param>
        public void DivideSelf(double f)
        {
            this = divideSelf_v2(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to multiply</param>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector2 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector2 MultiplyNew(GlosaVector2 vector, double f)
        {
            return multiplyNew_v2(vector, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector2 that is the original vector coordinatewise multiplied by f.</returns>
        public GlosaVector2 MultiplyNew(double f)
        {
            return multiplyNew_v2(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it, and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        public void MultiplySelf(double f)
        {
            this = multiplySelf_v2(this, f);
        }

        /// <summary>
        /// Computes the cross product (or vector product, or exterior product) of two GlosaVector2s.
        /// </summary>
        /// <param name="vector">The first GlosaVector2</param>
        /// <param name="vector2">The second GlosaVector2</param>
        /// <returns>A new vector that is perpendicular to both this instance and vector,
        /// <para>has Length == this.Length * vector.Length and</para>
        /// <para>with a result that is oriented following the right hand rule.</para>
        /// </returns>
        public static double Cross(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return cross_v2(vector, vector2);
        }

        /// <summary>
        /// Computes the cross product (or vector product, or exterior product) of two GlosaVector2s.
        /// </summary>
        /// <param name="vector">The second GlosaVector2 to compute</param>
        /// <returns>A new vector that is perpendicular to both this instance and vector,
        /// <para>has Length == this.Length * vector.Length and</para>
        /// <para>with a result that is oriented following the right hand rule.</para>
        /// </returns>
        public double Cross(GlosaVector2 vector)
        {
            return cross_v2(this, vector);
        }

        /// <summary>
        /// Multiplies two GlosaVector2 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The first GlosaVector2</param>
        /// <param name="vector2">The second GlosaVector2</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public static double Dot(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return dot_v2(vector, vector2);
        }

        /// <summary>
        /// Multiplies two GlosaVector2 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The GlosaVector to multiply by</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public double Dot(GlosaVector2 vector)
        {
            return dot_v2(this, vector);
        }

        /// <summary>
        /// Computes the additive inverse of all coordinates in the GlosaVector2, and returns the new GlosaVector2.
        /// </summary>
        /// <returns>The new GlosaVector2</returns>
        public GlosaVector2 InverseNew()
        {
            return inverseNew_v2(this);
        }

        /// <summary>
        /// Computes the additive inverse of all coordinates in the GlosaVector2, and overrides coordinates with result.
        /// </summary>
        /// <returns>Itself</returns>
        public void InverseSelf()
        {
            this = inverseSelf_v2(this);
        }

        /// <summary>
        /// Computes the GlosaVector2's direction in the XY plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double Heading()
        {
            return heading_v2(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public GlosaVector2 ReflectNew(GlosaVector2 vector)
        {
            return reflectNew_v2(this, vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public void ReflectSelf(GlosaVector2 vector)
        {
            this = reflectSelf_v2(this, vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public GlosaVector2 RefractNew(GlosaVector2 vector, double f)
        {
            return refractNew_v2(this, vector, f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        public void RefractSelf(GlosaVector2 vector, double f)
        {
            this = refractSelf_v2(this, vector, f);
        }

        /// <summary>
        /// Normalizes the GlosaVector2 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>A new normalized GlosaVector</returns>
        public GlosaVector2 NormalizeNew(double value)
        {
            return normalizeNew_v2(this, value);
        }

        /// <summary>
        /// Normalizes the GlosaVector2 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>Itself</returns>
        public void NormalizeSelf(double value)
        {
            this = normalizeSelf_v2(this, value);
        }

        /// <summary>
        /// Computes the length of the GlosaVector2
        /// </summary>
        /// <returns>The length</returns>
        public double Magnitude()
        {
            return magnitude_v2(this);
        }

        /// <summary>
        /// Computes the length of the GlosaVector2 (Computationally less expensive)
        /// </summary>
        /// <returns>The length</returns>
        public double MagnitudeSquared()
        {
            return magnitudeSquared_v2(this);
        }

        /// <summary>
        /// Returns the string representation of the current GlosaVector2, in the form X,Y.
        /// </summary>
        /// <returns>A string with the current location of the GlosaVector2.</returns>
        public string Stringify()
        {
            IntPtr pStr = stringify_v2(this);
            string rs = Marshal.PtrToStringAnsi(pStr);
            return rs ?? String.Empty;
        }

        /// <summary>
        /// Compute the angle between two GlosaVector2.
        /// </summary>
        /// <param name="vector">The first vector</param>
        /// <param name="vector2">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public static double AngleBetween(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return angleBetween_v2(vector, vector2);
        }

        /// <summary>
        /// Compute the angle between two GlosaVector2.
        /// </summary>
        /// <param name="vector">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public double AngleBetween(GlosaVector2 vector)
        {
            return angleBetween_v2(this, vector);
        }

        /// <summary>
        /// Gets the Length of the GlosaVector2
        /// </summary>
        /// <returns>The length</returns>
        public double Length()
        {
            return this.Magnitude();
        }

        /// <summary>
        /// Determines whether the specified GlosaVector2 has the same value as the present GlosaVector2.
        /// </summary>
        /// <param name="vector">The other GlosaVector2 to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaVector2 vector)
        {
            return this == vector;
        }
        #region Operators

        /// <summary>
        /// Determines whether two GlosaVector2 have equal values.
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if components of the two GlosaVector2 are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaVector2 a, GlosaVector2 b)
        {
            return equals_v2(a, b);
        }

        /// <summary>
        /// Determines whether two GlosaVector2 have different values.
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if any component of the two vectors is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaVector2 a, GlosaVector2 b)
        {
            return notEqual_v2(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector2 comes before
        /// (has inferior sorting value than) the second GlosaVector2.
        /// <para>Components have decreasing evaluation priority: first X, then Y.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if a.X is smaller than b.X, or a.X == b.X and a.Y is smaller than b.Y; otherwise, false</returns>
        public static bool operator <(GlosaVector2 a, GlosaVector2 b)
        {
            return lessThan_v2(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector2 comes before
        /// (has inferior sorting value than) the second GlosaVector2, or it is equal to it.
        /// <para>Components have decreasing evaluation priority: first X, then Y.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if a.X is smaller than b.X, or a.X == b.X and a.Y &lt;= b.Y; otherwise, false.</returns>
        public static bool operator <=(GlosaVector2 a, GlosaVector2 b)
        {
            return lessThanEqual_v2(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector2 comes after
        /// (has superior sorting value than) the second GlosaVector2.
        /// <para>Components have decreasing evaluation priority: first X, then Y.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if a.X is larger than b.X, or a.X == b.X and a.Y is larger than b.Y; otherwise, false.</returns>
        public static bool operator >(GlosaVector2 a, GlosaVector2 b)
        {
            return greaterThan_v2(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector2 comes after
        /// (has superior sorting value than) the second GlosaVector2, or it is equal to it.
        /// <para>Components have decreasing evaluation priority: first X, then Y.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if a.X is larger than b.X, or a.X == b.X and a.Y &gt;= b.Y; otherwise, false.</returns>
        public static bool operator >=(GlosaVector2 a, GlosaVector2 b)
        {
            return greaterThanEqual_v2(a, b);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to multiply</param>
        /// <param name="f">The value to multiply by</param>
        /// <returns>A new GlosaVector2 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector2 operator *(GlosaVector2 vector, double f)
        {
            return multiplyNew_v2(vector, f);
        }

        /// <summary>
        /// Multiplies two GlosaVector2 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The GlosaVector</param>
        /// <param name="vector2">The second GlosaVector to multiply by</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public static double operator *(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return dot_v2(vector, vector2);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector2 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector2 that is componentwise divided by f</returns>
        public static GlosaVector2 operator /(GlosaVector2 vector, double f)
        {
            return divideNew_v2(vector, f);
        }

        /// <summary>
        /// Sums up two GlosaVector2.
        /// </summary>
        /// <param name="vector">The GlosaVector2</param>
        /// <param name="vector2">The second GlosaVector2</param>
        /// <returns>A new GlosaVector2 that results from the componentwise addition of the two vectors.</returns>
        public static GlosaVector2 operator +(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return addNew_v2(vector, vector2);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The GlosaVector2</param>
        /// <param name="vector2">The second GlosaVector2</param>
        /// <returns>A new GlosaVector2 that results from the componentwise difference of vector1 - vector2.</returns>
        public static GlosaVector2 operator -(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return subtractNew_v2(vector, vector2);
        }
        #endregion
        /// <summary>
        /// Determines whether the specified System.Object is a GlosaVector2 and has the same values as the present GlosaVector2.
        /// </summary>
        /// <param name="obj">THe specified object</param>
        /// <returns>true if obj is a GlosaVector2 and has the same coordinates as this; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GlosaVector2 && this == (GlosaVector2)obj);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaVector2.
        /// </summary>
        /// <returns>A non-unique number based on GlosaVector2 components.</returns>
        public override int GetHashCode()
        {
            return m_x.GetHashCode() ^ m_y.GetHashCode();
        }

        /// <summary>
        /// Compares this GlosaVector2 with another, Component evaluation priority is first X, then Y.
        /// </summary>
        /// <param name="other">The other GlosaVector2</param>
        /// <returns>
        /// <para> 0: if this is identical to other</para>
        /// <para>-1: if this.X &lt; other.X</para>
        /// <para>-1: if this.X == other.X and this.Y &lt; other.Y</para>
        /// <para>+1: otherwise.</para>
        /// </returns>
        public int CompareTo(GlosaVector2 other)
        {
            if (m_x < other.m_x)
                return -1;
            if (m_x > other.m_x)
                return 1;
            if (m_y < other.m_y)
                return -1;
            if (m_y > other.m_y)
                return 1;
            return 0;
        }

        /// <summary>
        /// Sets all GlosaVector2 components to 0.
        /// </summary>
        public void Clear()
        {
            this = clear_v2(this);
        }

        /// <summary>
        /// Gets the GlosaVector2 Dimension
        /// </summary>
        /// <returns>The dimension, for GlosaVector2 the result should be 2</returns>
        public int Dimension()
        {
            return dimension_v2(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaVector2.
        /// </summary>
        /// <returns>A non-unique number based on GlosaVector2 components.</returns>
        public int Hash()
        {
            return hash_v2(this);
        }

        /// <summary>
        /// Copies a GlosaVector 
        /// </summary>
        /// <param name="vector">The GlosaVector2 to copy</param>
        /// <returns>A new copy of that GlosaVector2</returns>
        public static GlosaVector2 CopyNew(GlosaVector2 vector)
        {
            return copy_v2(vector);
        }

        /// <summary>
        /// Copies a GlosaVector 
        /// </summary>
        /// <param name="vector">The GlosaVector2 to copy</param>
        /// <returns>A new copy of that GlosaVector2</returns>
        public GlosaVector2 Copy(GlosaVector2 vector)
        {
            return copy_v2(vector);
        }

        /// <summary>
        /// Sets the GlosaVector components, X and Y, to the specified values.
        /// </summary>
        /// <param name="x">The x value</param>
        /// <param name="y">The y value</param>
        public void Set(double x, double y)
        {
            this = set2_v2(this, x, y);
        }

        /// <summary>
        /// Sets the GlosaVector components, X and Y, to the specified value.
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(double n)
        {
            this = set_v2(this, n);
        }

        /// <summary>
        /// Returns an array with the GlosaVector2 components, X Y.
        /// </summary>
        /// <param name="array">The fixed array to modify</param>
        /// <returns>The modified array</returns>
        public double[] ToArray(double[] array)
        {
            if (array.Length != 2) { throw new System.ArgumentException("array must be fixed array with length of 2 for GlosaVector2", "array"); }
            toArray_v2(this, array);
            return array;
        }

        /// <summary>
        /// Returns an GlosaVector3 with the components, X Y and Z from the array
        /// </summary>
        /// <param name="array">The fixed array to create a GlosaVector from</param>
        /// <returns>The GlosaVector3</returns>
        public GlosaVector2 FromArray(double[] array)
        {
            if (array.Length != 2) { throw new System.ArgumentException("array must be fixed array with length of 2 for GlosaVector2", "array"); }
            return fromArray_v2(array);
        }

        /// <summary>
        /// Computes the distance between two points.
        /// </summary>
        /// <param name="vector">Other GlosaVector for distance measurement</param>
        /// <returns>The distance between 2 GlosaVectors</returns>
        public double DistanceTo(GlosaVector2 vector)
        {
            return distanceToSquared_v2(this, vector);
        }

        /// <summary>
        /// Computes the distance between two points.
        /// </summary>
        /// <param name="vector">Other GlosaVector for distance measurement</param>
        /// <returns>The distance between 2 GlosaVectors</returns>
        public static double DistanceTo(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return distanceToSquared_v2(vector, vector2);
        }

        /// <summary>
        /// Interpolates between two vectors using an interpolation value (0.5 will return vector between the two vectors)
        /// </summary>
        /// <param name="vector">The second GlosaVector</param>
        /// <param name="f">The Interpolation factor (should be in the range 0..1)</param>
        /// <returns>The interpolated vector</returns>
        public GlosaVector2 Interpolate(GlosaVector2 vector, double f)
        {
            if (f < 0 || f > 1) { throw new System.ArgumentException("Interpolation value must be between 0 and 1"); }
            return interpolateTo_v2(this, vector, f);
        }

        /// <summary>
        /// Interpolates between two vectors using an interpolation value (0.5 will return vector between the two vectors)
        /// </summary>
        /// <param name="vector">The second GlosaVector</param>
        /// <param name="f">The Interpolation factor (should be in the range 0..1)</param>
        /// <returns>The interpolated vector</returns>
        public static GlosaVector2 InterpolateNew(GlosaVector2 vector, GlosaVector2 vector2, double f)
        {
            if (f < 0 || f > 1) { throw new System.ArgumentException("Interpolation value must be between 0 and 1"); }
            return interpolateTo_v2(vector, vector2, f);
        }

        /// <summary>
        /// Batch compares an array of GlosaVectors
        /// </summary>
        /// <param name="vectors">The GlosaVectors to compare</param>
        /// <returns>The min GlosaVector</returns>
        public static GlosaVector2 Min(GlosaVector2[] vectors)
        {
            return min_v2(vectors);
        }

        /// <summary>
        /// Batch compares an array of GlosaVectors
        /// </summary>
        /// <param name="vectors">The GlosaVectors to compare</param>
        /// <returns>The max GlosaVector</returns>
        public static GlosaVector2 Max(GlosaVector2[] vectors)
        {
            return max_v2(vectors);
        }

        /// <summary>
        /// Converts a GlosaVector2 into a GlosaVector3
        /// </summary>
        /// <returns>The GlosaVector3</returns>
        public GlosaVector3 ToVector3()
        {
            return toVector3(this);
        }
    }
}
