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
    /// Represents the three components of a vector in three-dimensional space
    /// </summary>
    public struct GlosaVector3 : IVector<GlosaVector3>, ILength<GlosaVector3>, IEquals<GlosaVector3>, IString<GlosaVector3>, ICompare<GlosaVector3>,
        IClear<GlosaVector3>, IDimension<GlosaVector3>, IHash<GlosaVector3>, ICopy<GlosaVector3>, ITransform<GlosaVector3>
    {
        #region C Reference Procs
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 addNew_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 addSelf_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 subtractNew_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 subtractSelf_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 divideNew_v3(GlosaVector3 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 divideSelf_v3(GlosaVector3 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 multiplyNew_v3(GlosaVector3 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 multiplySelf_v3(GlosaVector3 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 cross_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern double dot_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 inverseNew_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 inverseSelf_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingXY_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingXZ_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingYZ_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 reflectNew_v3(GlosaVector3 v, GlosaVector3 n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 reflectSelf_v3(GlosaVector3 v, GlosaVector3 n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 refractNew_v3(GlosaVector3 v, GlosaVector3 n, double eta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 refractSelf_v3(GlosaVector3 v, GlosaVector3 n, double eta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 normalizeNew_v3(GlosaVector3 v, double m = 1.0);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 normalizeSelf_v3(GlosaVector3 v, double m = 1.0);
        [DllImport("wrapper_vector.dll")]
        private static extern double angleBetween_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 clear_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern int dimension_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 copy_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 set_v3(GlosaVector3 v, double n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 set2_v3(GlosaVector3 v, double x, double y, double z);
        [DllImport("wrapper_vector.dll")]
        private static extern double magnitude_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern bool greaterThan_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool greaterThanEqual_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool lessThan_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool lessThanEqual_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool equals_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool notEqual_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern int hash_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern void toArray_v3(GlosaVector3 v, double[] array);
        [DllImport("wrapper_vector.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_v3(GlosaVector3 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 fromArray_v3(double[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern double distanceToSquared_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 interpolateTo_v3(GlosaVector3 v1, GlosaVector3 v2, double f);
        #endregion
        private double m_x, m_y, m_z;

        /// <summary>
        /// Gets or sets the X (first) component of this vector.
        /// </summary>
        public double x { get { return m_x; } set { m_x = value; } }

        /// <summary>
        /// Gets or sets the Y (second) component of this vector.
        /// </summary>
        public double y { get { return m_y; } set { m_y = value; } }

        /// <summary>
        /// Gets or sets the Z (third) component of this vector.
        /// </summary>
        public double z { get { return m_z; } set { m_z = value; } }

        /// <summary>
        /// Initializes a new instance of the GlosaVector3 based on three, X and Y and Z, components.
        /// </summary>
        /// <param name="x">The X (first) component.</param>
        /// <param name="y">The Y (second) component.</param>
        /// <param name="z">The Z (third) component.</param>
        public GlosaVector3(double x, double y, double z)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_z = z;
        }

        /// <summary>
        /// Sums up two GlosaVector3.
        /// </summary>
        /// <param name="vector">The first GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3</param>
        /// <returns>A new GlosaVector3 that results from the componentwise addition of the two vectors.</returns>
        public static GlosaVector3 AddNew(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return addNew_v3(vector, vector2);
        }
        /// <summary>
        /// Sums up two GlosaVector3.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to add</param>
        /// <returns>A new GlosaVector3 that results from the componentwise addition of the two vectors.</returns>
        public GlosaVector3 AddNew(GlosaVector3 vector)
        {
            return addNew_v3(this, vector);
        }

        /// <summary>
        /// Adds GlosaVector3 and overrides coordinates with result.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to add</param>
        public void AddSelf(GlosaVector3 vector)
        {
            this = addSelf_v3(this, vector);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The first GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3</param>
        /// <returns>A new GlosaVector3 that results from the componentwise difference of vector1 - vector2.</returns>
        public static GlosaVector3 SubtractNew(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return subtractNew_v3(vector, vector2);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to add</param>
        /// <returns>A new GlosaVector3 that results from the componentwise difference of vector1 - vector2.</returns>
        public GlosaVector3 SubtractNew(GlosaVector3 vector)
        {
            return subtractNew_v3(this, vector);
        }

        /// <summary>
        /// Subtracts GlosaVector3 and overrides coordinates with result.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to subtract</param>
        public void SubtractSelf(GlosaVector3 vector)
        {
            this = subtractSelf_v3(this, vector);
        }

        /// <summary>
        /// Divides a GlosaVector3 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector3 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector3 that is componentwise divided by f</returns>
        public static GlosaVector3 DivideNew(GlosaVector3 vector, double f)
        {
            return divideNew_v3(vector, f);
        }

        /// <summary>
        /// Divides a GlosaVector3 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector3 that is componentwise divided by f</returns>
        public GlosaVector3 DivideNew(double f)
        {
            return divideNew_v3(this, f);
        }

        /// <summary>
        /// Divides a GlosaVector3 by a number, having the effect of shrinking it and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to divide by</param>
        public void DivideSelf(double f)
        {
            this = divideSelf_v3(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to multiply</param>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector3 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector3 MultiplyNew(GlosaVector3 vector, double f)
        {
            return multiplyNew_v3(vector, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector3 that is the original vector coordinatewise multiplied by f.</returns>
        public GlosaVector3 MultiplyNew(double f)
        {
            return multiplyNew_v3(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it, and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        public void MultiplySelf(double f)
        {
            this = multiplySelf_v3(this, f);
        }

        /// <summary>
        /// Computes the cross product (or vector product, or exterior product) of two GlosaVector3.
        /// </summary>
        /// <param name="vector">The first GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3</param>
        /// <returns>A new GlosaVector3 that is perpendicular to both this instance and vector,
        /// <para>has Length == this.Length * vector.Length and</para>
        /// <para>with a result that is oriented following the right hand rule.</para>
        /// </returns>
        public static GlosaVector3 Cross(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return cross_v3(vector, vector2);
        }

        /// <summary>
        /// Computes the cross product (or vector product, or exterior product) of two GlosaVector3.
        /// </summary>
        /// <param name="vector">The second GlosaVector3 to compute</param>
        /// <returns>A new vector that is perpendicular to both this instance and vector,
        /// <para>has Length == this.Length * vector.Length and</para>
        /// <para>with a result that is oriented following the right hand rule.</para>
        /// </returns>
        public GlosaVector3 Cross(GlosaVector3 vector)
        {
            return cross_v3(this, vector);
        }

        /// <summary>
        /// Multiplies two GlosaVector3 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The first GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public static double Dot(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return dot_v3(vector, vector2);
        }

        /// <summary>
        /// Multiplies two GlosaVector3 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The GlosaVector3 to multiply by</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public double Dot(GlosaVector3 vector)
        {
            return dot_v3(this, vector);
        }

        /// <summary>
        /// Computes the additive inverse of all coordinates in the GlosaVector3, and returns the new GlosaVector3.
        /// </summary>
        /// <returns>The new GlosaVector3</returns>
        public GlosaVector3 InverseNew()
        {
            return inverseNew_v3(this);
        }

        /// <summary>
        /// Computes the additive inverse of all coordinates in the GlosaVector3, and overrides coordinates with result.
        /// </summary>
        /// <returns>Itself</returns>
        public void InverseSelf()
        {
            this = inverseSelf_v3(this);
        }

        /// <summary>
        /// Computes the GlosaVector3's direction in the XY plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double Heading()
        {
            return headingXY_v3(this);
        }

        /// <summary>
        /// Computes the GlosaVector3's direction in the XZ plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingXZ()
        {
            return headingXZ_v3(this);
        }

        /// <summary>
        /// Computes the GlosaVector3's direction in the YZ plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingYZ()
        {
            return headingYZ_v3(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public GlosaVector3 ReflectNew(GlosaVector3 vector)
        {
            return reflectNew_v3(this, vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public void ReflectSelf(GlosaVector3 vector)
        {
            this = reflectSelf_v3(this, vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public GlosaVector3 RefractNew(GlosaVector3 vector, double f)
        {
            return refractNew_v3(this, vector, f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        public void RefractSelf(GlosaVector3 vector, double f)
        {
            this = refractSelf_v3(this, vector, f);
        }

        /// <summary>
        /// Normalizes the GlosaVector3 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>A new normalized GlosaVector3</returns>
        public GlosaVector3 NormalizeNew(double value)
        {
            return normalizeNew_v3(this, value);
        }

        /// <summary>
        /// Normalizes the GlosaVector3 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>Itself</returns>
        public void NormalizeSelf(double value)
        {
            this = normalizeSelf_v3(this, value);
        }

        /// <summary>
        /// Computes the length of the GlosaVector3
        /// </summary>
        /// <returns>The length</returns>
        public double Magnitude()
        {
            return magnitude_v3(this);
        }

        /// <summary>
        /// Returns the string representation of the current GlosaVector3, in the form X,Y,Z.
        /// </summary>
        /// <returns>A string with the current location of the GlosaVector3.</returns>
        public string Stringify()
        {
            IntPtr pStr = stringify_v3(this);
            string rs = Marshal.PtrToStringAnsi(pStr);
            return rs ?? String.Empty;
        }

        /// <summary>
        /// Compute the angle between two GlosaVector3.
        /// </summary>
        /// <param name="vector">The first vector</param>
        /// <param name="vector2">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public static double AngleBetween(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return angleBetween_v3(vector, vector2);
        }

        /// <summary>
        /// Compute the angle between two GlosaVector3.
        /// </summary>
        /// <param name="vector">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public double AngleBetween(GlosaVector3 vector)
        {
            return angleBetween_v3(this, vector);
        }

        /// <summary>
        /// Gets the Length of the GlosaVector3
        /// </summary>
        /// <returns>The length</returns>
        public double Length()
        {
            return this.Magnitude();
        }

        /// <summary>
        /// Determines whether the specified GlosaVector3 has the same value as the present GlosaVector3.
        /// </summary>
        /// <param name="vector">The other GlosaVector3 to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaVector3 vector)
        {
            return this == vector;
        }
        #region Operators

        /// <summary>
        /// Determines whether two GlosaVector3 have equal values.
        /// </summary>
        /// <param name="a">The first GlosaVector3</param>
        /// <param name="b">The second GlosaVector3</param>
        /// <returns>True if components of the two GlosaVector3 are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaVector3 a, GlosaVector3 b)
        {
            return equals_v3(a, b);
        }

        /// <summary>
        /// Determines whether two GlosaVector3 have different values.
        /// </summary>
        /// <param name="a">The first GlosaVector3</param>
        /// <param name="b">The second GlosaVector3</param>
        /// <returns>True if any component of the two GlosaVector3 is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaVector3 a, GlosaVector3 b)
        {
            return notEqual_v3(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector3 comes before
        /// (has inferior sorting value than) the second GlosaVector3.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector3</param>
        /// <param name="b">The second GlosaVector3</param>
        /// <returns>true if a.X is smaller than b.X,
        /// or a.X == b.X and a.Y is smaller than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z is smaller than b.Z;
        /// otherwise, false.</returns>
        public static bool operator <(GlosaVector3 a, GlosaVector3 b)
        {
            return lessThan_v3(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector3 comes before
        /// (has inferior sorting value than) the second GlosaVector3, or it is equal to it.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector3</param>
        /// <param name="b">The second GlosaVector3</param>
        /// <returns>true if a.X is smaller than b.X,
        /// or a.X == b.X and a.Y is smaller than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z &lt;= b.Z;
        /// otherwise, false.</returns>
        public static bool operator <=(GlosaVector3 a, GlosaVector3 b)
        {
            return lessThanEqual_v3(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector3 comes after
        /// (has superior sorting value than) the second GlosaVector3.
        /// <para>Components have decreasing evaluation priority: first X, then Y.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector3</param>
        /// <param name="b">The second GlosaVector3</param>
        /// <returns>true if a.X is larger than b.X,
        /// or a.X == b.X and a.Y is larger than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z is larger than b.Z;
        /// otherwise, false.</returns>
        public static bool operator >(GlosaVector3 a, GlosaVector3 b)
        {
            return greaterThan_v3(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector3 comes after
        /// (has superior sorting value than) the second GlosaVector3, or it is equal to it.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector3</param>
        /// <param name="b">The second GlosaVector3</param>
        /// <returns>true if a.X is larger than b.X,
        /// or a.X == b.X and a.Y is larger than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z &gt;= b.Z;
        /// otherwise, false.</returns>
        public static bool operator >=(GlosaVector3 a, GlosaVector3 b)
        {
            return greaterThanEqual_v3(a, b);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to multiply</param>
        /// <param name="f">The value to multiply by</param>
        /// <returns>A new GlosaVector3 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector3 operator *(GlosaVector3 vector, float f)
        {
            return multiplyNew_v3(vector, f);
        }

        /// <summary>
        /// Multiplies two GlosaVector3 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3 to multiply by</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public static double operator *(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return dot_v3(vector, vector2);
        }

        /// <summary>
        /// Divides a GlosaVector3 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector3 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector3 that is componentwise divided by f</returns>
        public static GlosaVector3 operator /(GlosaVector3 vector, double f)
        {
            return divideNew_v3(vector, f);
        }

        /// <summary>
        /// Sums up two GlosaVector3.
        /// </summary>
        /// <param name="vector">The GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3</param>
        /// <returns>A new GlosaVector3 that results from the componentwise addition of the two vectors.</returns>
        public static GlosaVector3 operator +(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return addNew_v3(vector, vector2);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The GlosaVector3</param>
        /// <param name="vector2">The second GlosaVector3</param>
        /// <returns>A new GlosaVector3 that results from the componentwise difference of vector1 - vector2.</returns>
        public static GlosaVector3 operator -(GlosaVector3 vector, GlosaVector3 vector2)
        {
            return subtractNew_v3(vector, vector2);
        }
        #endregion
        /// <summary>
        /// Determines whether the specified System.Object is a GlosaVector3 and has the same values as the present GlosaVector3.
        /// </summary>
        /// <param name="obj">THe specified object</param>
        /// <returns>true if obj is a GlosaVector3 and has the same coordinates as this; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GlosaVector3 && this == (GlosaVector3)obj);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaVector3.
        /// </summary>
        /// <returns>A non-unique number based on GlosaVector3 components.</returns>
        public override int GetHashCode()
        {
            return m_x.GetHashCode() ^ m_y.GetHashCode() ^ m_z.GetHashCode();
        }

        /// <summary>
        /// Compares this GlosaVector3 with another, Component evaluation priority is first X, then Y, then Z.
        /// </summary>
        /// <param name="other">The other GlosaVector3</param>
        /// <returns>
        /// <para> 0: if this is identical to other</para>
        /// <para>-1: if this.X &lt; other.X</para>
        /// <para>-1: if this.X == other.X and this.Y &lt; other.Y</para>
        /// <para>-1: if this.X == other.X and this.Y == other.Y and this.Z &lt; other.Z</para>
        /// <para>+1: otherwise.</para>
        /// </returns>
        public int CompareTo(GlosaVector3 other)
        {
            if (m_x < other.m_x)
                return -1;
            if (m_x > other.m_x)
                return 1;
            if (m_y < other.m_y)
                return -1;
            if (m_y > other.m_y)
                return 1;
            if (m_z < other.m_z)
                return -1;
            if (m_z > other.m_z)
                return 1;
            return 0;
        }

        /// <summary>
        /// Sets all GlosaVector3 components to 0.
        /// </summary>
        public void Clear()
        {
            this = clear_v3(this);
        }

        /// <summary>
        /// Gets the GlosaVector3 Dimension
        /// </summary>
        /// <returns>The dimension, for GlosaVector3 the result should be 3</returns>
        public int Dimension()
        {
            return dimension_v3(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaVector3.
        /// </summary>
        /// <returns>A non-unique number based on GlosaVector3 components.</returns>
        public int Hash()
        {
            return hash_v3(this);
        }

        /// <summary>
        /// Copies a GlosaVector3 
        /// </summary>
        /// <param name="vector">The GlosaVector3 to copy</param>
        /// <returns>A new copy of that GlosaVector3</returns>
        public static GlosaVector3 CopyNew(GlosaVector3 vector)
        {
            return copy_v3(vector);
        }

        /// <summary>
        /// Copies a GlosaVector3 
        /// </summary>
        /// <param name="vector">The GlosaVector3 to copy</param>
        /// <returns>A new copy of that GlosaVector3</returns>
        public GlosaVector3 Copy(GlosaVector3 vector)
        {
            return copy_v3(vector);
        }

        /// <summary>
        /// Sets the GlosaVector3 components, X Y and Z, to the specified values.
        /// </summary>
        /// <param name="x">The x value</param>
        /// <param name="y">The y value</param>
        /// <param name="z">The z value</param>
        public void Set(double x, double y, double z)
        {
            this = set2_v3(this, x, y, z);
        }

        /// <summary>
        /// Sets the GlosaVector3 components, X Y and Z, to the specified value.
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(double n)
        {
            this = set_v3(this, n);
        }

        /// <summary>
        /// Returns an array with the GlosaVector3 components, X Y and Z,
        /// </summary>
        /// <param name="array">The fixed array to modify</param>
        /// <returns>The modified array</returns>
        public double[] ToArray(double[] array)
        {
            if(array.Length != 3) { throw new System.ArgumentException("array must be fixed array with length of 3 for GlosaVector3", "array"); }
            toArray_v3(this, array);
            return array;
        }

        /// <summary>
        /// Returns an GlosaVector3 with the components, X Y and Z from the array
        /// </summary>
        /// <param name="array">The fixed array to create a GlosaVector from</param>
        /// <returns>The GlosaVector3</returns>
        public GlosaVector3 FromArray(double[] array)
        {
            if (array.Length != 3) { throw new System.ArgumentException("array must be fixed array with length of 3 for GlosaVector3", "array"); }       
            return fromArray_v3(array); 
        }

        /// <summary>
        /// Computes the distance between two points.
        /// </summary>
        /// <param name="vector">Other GlosaVector for distance measurement</param>
        /// <returns>The distance between 2 GlosaVectors</returns>
        public double DistanceTo(GlosaVector3 vector)
        {
            return distanceToSquared_v3(this, vector);
        }

        /// <summary>
        /// Interpolates between two vectors using an interpolation value (0.5 will return vector between the two vectors)
        /// </summary>
        /// <param name="vector">The second GlosaVector</param>
        /// <param name="f">The Interpolation factor (should be in the range 0..1)</param>
        /// <returns>The interpolated vector</returns>
        public GlosaVector3 Interpolate(GlosaVector3 vector, double f)
        {
            if (f < 0 || f > 1) { throw new System.ArgumentException("Interpolation value must be between 0 and 1"); }
            return interpolateTo_v3(this, vector, f);
        }
    }
}
