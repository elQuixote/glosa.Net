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
    /// Represents the four components of a vector in four-dimensional space
    /// </summary>
    public struct GlosaVector4 : IVector<GlosaVector4>, ILength<GlosaVector4>, IEquals<GlosaVector4>, IString<GlosaVector4>, ICompare<GlosaVector4>,
        IClear<GlosaVector4>, IDimension<GlosaVector4>, IHash<GlosaVector4>, ICopy<GlosaVector4>, ITransform<GlosaVector4>
    {
        #region C Reference Procs
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 addNew_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 addSelf_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 subtractNew_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 subtractSelf_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 divideNew_v4(GlosaVector4 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 divideSelf_v4(GlosaVector4 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 multiplyNew_v4(GlosaVector4 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 multiplySelf_v4(GlosaVector4 v, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 cross_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern double dot_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 inverseNew_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 inverseSelf_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingXY_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingXZ_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingXW_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingYZ_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingYW_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double headingZW_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 reflectNew_v4(GlosaVector4 v, GlosaVector4 n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 reflectSelf_v4(GlosaVector4 v, GlosaVector4 n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 refractNew_v4(GlosaVector4 v, GlosaVector4 n, double eta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 refractSelf_v4(GlosaVector4 v, GlosaVector4 n, double eta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 normalizeNew_v4(GlosaVector4 v, double m = 1.0);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 normalizeSelf_v4(GlosaVector4 v, double m = 1.0);
        [DllImport("wrapper_vector.dll")]
        private static extern double angleBetween_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 clear_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern int dimension_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 copy_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 set_v4(GlosaVector4 v, double n);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 set2_v4(GlosaVector4 v, double x, double y, double z, double w);
        [DllImport("wrapper_vector.dll")]
        private static extern double magnitude_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern double magnitudeSquared_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern bool greaterThan_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool greaterThanEqual_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool lessThan_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool lessThanEqual_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool equals_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern bool notEqual_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern int hash_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern void toArray_v4(GlosaVector4 v, double[] array);
        [DllImport("wrapper_vector.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr stringify_v4(GlosaVector4 v);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 fromArray_v4(double[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern double distanceToSquared_v4(GlosaVector4 v1, GlosaVector4 v2);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 interpolateTo_v4(GlosaVector4 v1, GlosaVector4 v2, double f);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 min_v4(GlosaVector4[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 max_v4(GlosaVector4[] array);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector2 toVector2(GlosaVector4 vector);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector3 toVector3(GlosaVector4 vector);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 fromSpherical_v4(double r, double theta, double phi, double psi);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 transformNew_v4(GlosaVector4 vector, GlosaMatrix44 matrix);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 transformSelf_v4(GlosaVector4 vector, GlosaMatrix44 matrix);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 translate_v4(GlosaVector4 vector, GlosaVector4 translation);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateAxis_v4(GlosaVector4 vector, GlosaVector4 b1, GlosaVector4 b2, double theta, GlosaVector4 b3, GlosaVector4 b4, double phi);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateXYSelf_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateXZSelf_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateXWSelf_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateYZSelf_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateYWSelf_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateZWSelf_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateXYNew_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateXZNew_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateXWNew_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateYZNew_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateYWNew_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 rotateZWNew_v4(GlosaVector4 vector, double theta);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 scaleSelf_v4(GlosaVector4 vector, double s);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 scaleNew_v4(GlosaVector4 vector, double s);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 scaleSelfComponent_v4(GlosaVector4 vector, double sx, double sy, double sz, double sw);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 scaleNewComponent_v4(GlosaVector4 vector, double sx, double sy, double sz, double sw);
        [DllImport("wrapper_vector.dll")]
        private static extern GlosaVector4 calculatePlane_v4(GlosaVector3 v1, GlosaVector3 v2, GlosaVector3 v3);
        #endregion
        private double m_x, m_y, m_z, m_w;

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
        /// Gets or sets the Z (third) component of this vector.
        /// </summary>
        public double w { get { return m_w; } set { m_w = value; } }

        /// <summary>
        /// Initializes a new instance of the GlosaVector4 based on three, X Y Z and W, components.
        /// </summary>
        /// <param name="x">The X (first) component.</param>
        /// <param name="y">The Y (second) component.</param>
        /// <param name="z">The Z (third) component.</param>
        /// <param name="w">The W (fourth) component.</param>
        public GlosaVector4(double x, double y, double z, double w)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_z = z;
            this.m_w = w;
        }

        /// <summary>
        /// Sums up two GlosaVector4.
        /// </summary>
        /// <param name="vector">The first GlosaVector4</param>
        /// <param name="vector2">The second GlosaVector4</param>
        /// <returns>A new GlosaVector4 that results from the componentwise addition of the two vectors.</returns>
        public static GlosaVector4 AddNew(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return addNew_v4(vector, vector2);
        }
        /// <summary>
        /// Sums up two GlosaVector4.
        /// </summary>
        /// <param name="vector">The GlosaVector4 to add</param>
        /// <returns>A new GlosaVector4 that results from the componentwise addition of the two vectors.</returns>
        public GlosaVector4 AddNew(GlosaVector4 vector)
        {
            return addNew_v4(this, vector);
        }

        /// <summary>
        /// Adds GlosaVector4 and overrides coordinates with result.
        /// </summary>
        /// <param name="vector">The GlosaVector4 to add</param>
        public void AddSelf(GlosaVector4 vector)
        {
            this = addSelf_v4(this, vector);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The first GlosaVector4</param>
        /// <param name="vector2">The second GlosaVector4</param>
        /// <returns>A new GlosaVector4 that results from the componentwise difference of vector1 - vector2.</returns>
        public static GlosaVector4 SubtractNew(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return subtractNew_v4(vector, vector2);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The GlosaVector4 to add</param>
        /// <returns>A new GlosaVector4 that results from the componentwise difference of vector1 - vector2.</returns>
        public GlosaVector4 SubtractNew(GlosaVector4 vector)
        {
            return subtractNew_v4(this, vector);
        }

        /// <summary>
        /// Subtracts GlosaVector4 and overrides coordinates with result.
        /// </summary>
        /// <param name="vector">The GlosaVector4 to subtract</param>
        public void SubtractSelf(GlosaVector4 vector)
        {
            this = subtractSelf_v4(this, vector);
        }

        /// <summary>
        /// Divides a GlosaVector4 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector4 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector4 that is componentwise divided by f</returns>
        public static GlosaVector4 DivideNew(GlosaVector4 vector, double f)
        {
            return divideNew_v4(vector, f);
        }

        /// <summary>
        /// Divides a GlosaVector4 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector4 that is componentwise divided by f</returns>
        public GlosaVector4 DivideNew(double f)
        {
            return divideNew_v4(this, f);
        }

        /// <summary>
        /// Divides a GlosaVector4 by a number, having the effect of shrinking it and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to divide by</param>
        public void DivideSelf(double f)
        {
            this = divideSelf_v4(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector4 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector4 to multiply</param>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector4 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector4 MultiplyNew(GlosaVector4 vector, double f)
        {
            return multiplyNew_v4(vector, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector4 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector4 that is the original vector coordinatewise multiplied by f.</returns>
        public GlosaVector4 MultiplyNew(double f)
        {
            return multiplyNew_v4(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector4 by a number, having the effect of scaling it, and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        public void MultiplySelf(double f)
        {
            this = multiplySelf_v4(this, f);
        }

        /// <summary>
        /// Multiplies two GlosaVector4 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The first GlosaVector4</param>
        /// <param name="vector2">The second GlosaVector4</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z + v1.W*v2.W.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public static double Dot(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return dot_v4(vector, vector2);
        }

        /// <summary>
        /// Multiplies two GlosaVector4 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The GlosaVector4 to multiply by</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z + v1.W*v2.W.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public double Dot(GlosaVector4 vector)
        {
            return dot_v4(this, vector);
        }

        /// <summary>
        /// Computes the additive inverse of all coordinates in the GlosaVector4, and returns the new GlosaVector4.
        /// </summary>
        /// <returns>The new GlosaVector4</returns>
        public GlosaVector4 InverseNew()
        {
            return inverseNew_v4(this);
        }

        /// <summary>
        /// Computes the additive inverse of all coordinates in the GlosaVector4, and overrides coordinates with result.
        /// </summary>
        /// <returns>Itself</returns>
        public void InverseSelf()
        {
            this = inverseSelf_v4(this);
        }

        /// <summary>
        /// Computes the GlosaVector4's direction in the XY plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double Heading()
        {
            return headingXY_v4(this);
        }

        /// <summary>
        /// Computes the GlosaVector4's direction in the XZ plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingXZ()
        {
            return headingXZ_v4(this);
        }

        /// <summary>
        /// Computes the GlosaVector4's direction in the XW plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingXW()
        {
            return headingXW_v4(this);
        }

        /// <summary>
        /// Computes the GlosaVector4's direction in the YZ plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingYZ()
        {
            return headingYZ_v4(this);
        }

        /// <summary>
        /// Computes the GlosaVector4's direction in the YW plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingYW()
        {
            return headingYW_v4(this);
        }

        /// <summary>
        /// Computes the GlosaVector4's direction in the ZW plane
        /// </summary>
        /// <returns>The rotation angle</returns>
        public double HeadingZW()
        {
            return headingZW_v4(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public GlosaVector4 ReflectNew(GlosaVector4 vector)
        {
            return reflectNew_v4(this, vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public void ReflectSelf(GlosaVector4 vector)
        {
            this = reflectSelf_v4(this, vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public GlosaVector4 RefractNew(GlosaVector4 vector, double f)
        {
            return refractNew_v4(this, vector, f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        public void RefractSelf(GlosaVector4 vector, double f)
        {
            this = refractSelf_v4(this, vector, f);
        }

        /// <summary>
        /// Normalizes the GlosaVector4 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>A new normalized GlosaVector4</returns>
        public GlosaVector4 NormalizeNew(double value)
        {
            return normalizeNew_v4(this, value);
        }

        /// <summary>
        /// Normalizes the GlosaVector4 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>Itself</returns>
        public void NormalizeSelf(double value)
        {
            this = normalizeSelf_v4(this, value);
        }

        /// <summary>
        /// Computes the length of the GlosaVector4
        /// </summary>
        /// <returns>The length</returns>
        public double Magnitude()
        {
            return magnitude_v4(this);
        }

        /// <summary>
        /// Computes the length of the GlosaVector4 (Computationally less expensive)
        /// </summary>
        /// <returns>The length</returns>
        public double MagnitudeSquared()
        {
            return magnitudeSquared_v4(this);
        }

        /// <summary>
        /// Returns the string representation of the current GlosaVector4, in the form X,Y,Z,W.
        /// </summary>
        /// <returns>A string with the current location of the GlosaVector4.</returns>
        public string Stringify()
        {
            IntPtr pStr = stringify_v4(this);
            string rs = Marshal.PtrToStringAnsi(pStr);
            return rs ?? String.Empty;
        }

        /// <summary>
        /// Compute the angle between two GlosaVector4.
        /// </summary>
        /// <param name="vector">The first vector</param>
        /// <param name="vector2">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public static double AngleBetween(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return angleBetween_v4(vector, vector2);
        }

        /// <summary>
        /// Compute the angle between two GlosaVector4.
        /// </summary>
        /// <param name="vector">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public double AngleBetween(GlosaVector4 vector)
        {
            return angleBetween_v4(this, vector);
        }

        /// <summary>
        /// Gets the Length of the GlosaVector4
        /// </summary>
        /// <returns>The length</returns>
        public double Length()
        {
            return this.Magnitude();
        }

        /// <summary>
        /// Determines whether the specified GlosaVector4 has the same value as the present GlosaVector4.
        /// </summary>
        /// <param name="vector">The other GlosaVector4 to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaVector4 vector)
        {
            return this == vector;
        }
        #region Operators

        /// <summary>
        /// Determines whether two GlosaVector4 have equal values.
        /// </summary>
        /// <param name="a">The first GlosaVector4</param>
        /// <param name="b">The second GlosaVector4</param>
        /// <returns>True if components of the two GlosaVector4 are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaVector4 a, GlosaVector4 b)
        {
            return equals_v4(a, b);
        }

        /// <summary>
        /// Determines whether two GlosaVector4 have different values.
        /// </summary>
        /// <param name="a">The first GlosaVector4</param>
        /// <param name="b">The second GlosaVector4</param>
        /// <returns>True if any component of the two GlosaVector4 is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaVector4 a, GlosaVector4 b)
        {
            return notEqual_v4(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector4 comes before
        /// (has inferior sorting value than) the second GlosaVector4.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z, then W.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector4</param>
        /// <param name="b">The second GlosaVector4</param>
        /// <returns>true if a.X is smaller than b.X,
        /// or a.X == b.X and a.Y is smaller than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z is smaller than b.Z;
        /// or a.X == b.X and a.Y == b.Y and a.Z == b.Z and a.W is smaller than b.W;
        /// otherwise, false.</returns>
        public static bool operator <(GlosaVector4 a, GlosaVector4 b)
        {
            return lessThan_v4(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector4 comes before
        /// (has inferior sorting value than) the second GlosaVector4, or it is equal to it.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z, then W.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector4</param>
        /// <param name="b">The second GlosaVector4</param>
        /// <returns>true if a.X is smaller than b.X,
        /// or a.X == b.X and a.Y is smaller than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z &lt;= b.Z;
        /// or a.X == b.X and a.Y == b.Y and a.Z == b.Z and a.W &lt;= b.W;
        /// otherwise, false.</returns>
        public static bool operator <=(GlosaVector4 a, GlosaVector4 b)
        {
            return lessThanEqual_v4(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector4 comes after
        /// (has superior sorting value than) the second GlosaVector4.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z, then W.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector4</param>
        /// <param name="b">The second GlosaVector4</param>
        /// <returns>true if a.X is larger than b.X,
        /// or a.X == b.X and a.Y is larger than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z is larger than b.Z;
        /// or a.X == b.X and a.Y == b.Y and a.Z == b.Z and a.W is larger than b.W;
        /// otherwise, false.</returns>
        public static bool operator >(GlosaVector4 a, GlosaVector4 b)
        {
            return greaterThan_v4(a, b);
        }

        /// <summary>
        /// Determines whether the first specified GlosaVector4 comes after
        /// (has superior sorting value than) the second GlosaVector4, or it is equal to it.
        /// <para>Components have decreasing evaluation priority: first X, then Y, then Z, then W.</para>
        /// </summary>
        /// <param name="a">The first GlosaVector4</param>
        /// <param name="b">The second GlosaVector4</param>
        /// <returns>true if a.X is larger than b.X,
        /// or a.X == b.X and a.Y is larger than b.Y,
        /// or a.X == b.X and a.Y == b.Y and a.Z &gt;= b.Z;
        /// or a.X == b.X and a.Y == b.Y and a.Z == b.Z and a.W &gt;= b.W;
        /// otherwise, false.</returns>
        public static bool operator >=(GlosaVector4 a, GlosaVector4 b)
        {
            return greaterThanEqual_v4(a, b);
        }

        /// <summary>
        /// Multiplies a GlosaVector4 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector4 to multiply</param>
        /// <param name="f">The value to multiply by</param>
        /// <returns>A new GlosaVector4 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector4 operator *(GlosaVector4 vector, float f)
        {
            return multiplyNew_v4(vector, f);
        }

        /// <summary>
        /// Multiplies two GlosaVector4 together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="vector">The GlosaVector4</param>
        /// <param name="vector2">The second GlosaVector4 to multiply by</param>
        /// <returns>
        /// A value that results from the evaluation of v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z + v1.W*v2.W.
        /// <para>This value equals v1.Length * v2.Length * cos(alpha), where alpha is the angle between vectors.</para>
        /// </returns>
        public static double operator *(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return dot_v4(vector, vector2);
        }

        /// <summary>
        /// Divides a GlosaVector4 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector4 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector4 that is componentwise divided by f</returns>
        public static GlosaVector4 operator /(GlosaVector4 vector, double f)
        {
            return divideNew_v4(vector, f);
        }

        /// <summary>
        /// Sums up two GlosaVector4.
        /// </summary>
        /// <param name="vector">The GlosaVector4</param>
        /// <param name="vector2">The second GlosaVector4</param>
        /// <returns>A new GlosaVector4 that results from the componentwise addition of the two vectors.</returns>
        public static GlosaVector4 operator +(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return addNew_v4(vector, vector2);
        }

        /// <summary>
        /// Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="vector">The GlosaVector4</param>
        /// <param name="vector2">The second GlosaVector4</param>
        /// <returns>A new GlosaVector4 that results from the componentwise difference of vector1 - vector2.</returns>
        public static GlosaVector4 operator -(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return subtractNew_v4(vector, vector2);
        }
        #endregion
        /// <summary>
        /// Determines whether the specified System.Object is a GlosaVector4 and has the same values as the present GlosaVector4.
        /// </summary>
        /// <param name="obj">The specified object</param>
        /// <returns>true if obj is a GlosaVector4 and has the same coordinates as this; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GlosaVector4 && this == (GlosaVector4)obj);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaVector4.
        /// </summary>
        /// <returns>A non-unique number based on GlosaVector4 components.</returns>
        public override int GetHashCode()
        {
            return m_x.GetHashCode() ^ m_y.GetHashCode() ^ m_z.GetHashCode();
        }

        /// <summary>
        /// Compares this GlosaVector4 with another, Component evaluation priority is first X, then Y, then Z, then W.
        /// </summary>
        /// <param name="other">The other GlosaVector4</param>
        /// <returns>
        /// <para> 0: if this is identical to other</para>
        /// <para>-1: if this.X &lt; other.X</para>
        /// <para>-1: if this.X == other.X and this.Y &lt; other.Y</para>
        /// <para>-1: if this.X == other.X and this.Y == other.Y and this.Z &lt; other.Z</para>
        /// <para>-1: if this.X == other.X and this.Y == other.Y and this.Z == other.Z and this.W &lt; other.W</para>
        /// <para>+1: otherwise.</para>
        /// </returns>
        public int CompareTo(GlosaVector4 other)
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
            if (m_w < other.m_w)
                return -1;
            if (m_w > other.m_w)
                return 1;
            return 0;
        }

        /// <summary>
        /// Sets all GlosaVector4 components to 0.
        /// </summary>
        public void Clear()
        {
            this = clear_v4(this);
        }

        /// <summary>
        /// Gets the GlosaVector4 Dimension
        /// </summary>
        /// <returns>The dimension, for GlosaVector4 the result should be 4</returns>
        public int Dimension()
        {
            return dimension_v4(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaVector4.
        /// </summary>
        /// <returns>A non-unique number based on GlosaVector4 components.</returns>
        public int Hash()
        {
            return hash_v4(this);
        }

        /// <summary>
        /// Copies a GlosaVector4 
        /// </summary>
        /// <param name="vector">The GlosaVector4 to copy</param>
        /// <returns>A new copy of that GlosaVector4</returns>
        public static GlosaVector4 CopyNew(GlosaVector4 vector)
        {
            return copy_v4(vector);
        }

        /// <summary>
        /// Copies a GlosaVector4 
        /// </summary>
        /// <returns>A new copy of that GlosaVector4</returns>
        public GlosaVector4 Copy()
        {
            return copy_v4(this);
        }

        /// <summary>
        /// Sets the GlosaVector4 components, X Y Z and W, to the specified values.
        /// </summary>
        /// <param name="x">The x value</param>
        /// <param name="y">The y value</param>
        /// <param name="z">The z value</param>
        /// <param name="w">The w value</param>
        public void Set(double x, double y, double z, double w)
        {
            this = set2_v4(this, x, y, z, w);
        }

        /// <summary>
        /// Sets the GlosaVector4 components, X Y Z and W, to the specified value.
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(double n)
        {
            this = set_v4(this, n);
        }

        /// <summary>
        /// Returns an array with the GlosaVector4 components, X Y Z and W,
        /// </summary>
        /// <param name="array">The fixed array to modify</param>
        /// <returns>The modified array</returns>
        public double[] ToArray(double[] array)
        {
            if (array.Length != 4) { throw new System.ArgumentException("array must be fixed array with length of 4 for GlosaVector4", "array"); }
            toArray_v4(this, array);
            return array;
        }

        /// <summary>
        /// Returns an GlosaVector4 with the components, X Y Z and W from the array
        /// </summary>
        /// <param name="array">The fixed array to create a GlosaVector from</param>
        /// <returns>The GlosaVector4</returns>
        public static GlosaVector4 FromArray(double[] array)
        {
            if (array.Length != 4) { throw new System.ArgumentException("array must be fixed array with length of 4 for GlosaVector4", "array"); }
            return fromArray_v4(array);
        }

        /// <summary>
        /// Computes the distance between two points.
        /// </summary>
        /// <param name="vector">Other GlosaVector for distance measurement</param>
        /// <returns>The distance between 2 GlosaVectors</returns>
        public double DistanceTo(GlosaVector4 vector)
        {
            return distanceToSquared_v4(this, vector);
        }

        /// <summary>
        /// Computes the distance between two points.
        /// </summary>
        /// <param name="vector">First GlosaVector for distance measurement</param>
        /// <param name="vector2">Other GlosaVector for distance measurement</param>
        /// <returns>The distance between 2 GlosaVectors</returns>
        public static double DistanceTo(GlosaVector4 vector, GlosaVector4 vector2)
        {
            return distanceToSquared_v4(vector, vector2);
        }

        /// <summary>
        /// Interpolates between two vectors using an interpolation value (0.5 will return vector between the two vectors)
        /// </summary>
        /// <param name="vector">The second GlosaVector</param>
        /// <param name="f">The Interpolation factor (should be in the range 0..1)</param>
        /// <returns>The interpolated vector</returns>
        public GlosaVector4 Interpolate(GlosaVector4 vector, double f)
        {
            if (f < 0 || f > 1) { throw new System.ArgumentException("Interpolation value must be between 0 and 1"); }
            return interpolateTo_v4(this, vector, f);
        }

        /// <summary>
        /// Interpolates between two vectors using an interpolation value (0.5 will return vector between the two vectors)
        /// </summary>
        /// <param name="vector">The second GlosaVector</param>
        /// <param name="f">The Interpolation factor (should be in the range 0..1)</param>
        /// <returns>The interpolated vector</returns>
        public static GlosaVector4 InterpolateNew(GlosaVector4 vector, GlosaVector4 vector2, double f)
        {
            if (f < 0 || f > 1) { throw new System.ArgumentException("Interpolation value must be between 0 and 1"); }
            return interpolateTo_v4(vector, vector2, f);
        }

        /// <summary>
        /// Batch compares an array of GlosaVectors
        /// </summary>
        /// <param name="vectors">The GlosaVectors to compare</param>
        /// <returns>The min GlosaVector</returns>
        public static GlosaVector4 Min(GlosaVector4[] vectors)
        {
            return min_v4(vectors);
        }

        /// <summary>
        /// Batch compares an array of GlosaVectors
        /// </summary>
        /// <param name="vectors">The GlosaVectors to compare</param>
        /// <returns>The max GlosaVector</returns>
        public static GlosaVector4 Max(GlosaVector4[] vectors)
        {
            return max_v4(vectors);
        }

        /// <summary>
        /// Converts a GlosaVector4 into a GlosaVector2
        /// </summary>
        /// <returns>The GlosaVector2</returns>
        public GlosaVector2 ToVector2()
        {
            return toVector2(this);
        }

        /// <summary>
        /// Converts a GlosaVector4 into a GlosaVector3
        /// </summary>
        /// <returns>The GlosaVector3</returns>
        public GlosaVector3 ToVector3()
        {
            return toVector3(this);
        }

        /// <summary>
        /// Creates a GlosaVector4 from N-Spherical Coordinates
        /// </summary>
        /// <param name="r"></param>
        /// <param name="theta"></param>
        /// <param name="phi"></param>
        /// <param name="psi"></param>
        /// <returns></returns>
        public GlosaVector4 FromSpherical(double r, double theta, double phi, double psi)
        {
            return fromSpherical_v4(r, theta, phi, psi);
        }

        public GlosaVector4 ScaleNew(double s)
        {
            return scaleNew_v4(this, s);
        }

        public void ScaleSelf(double s)
        {
            this = scaleSelf_v4(this, s);
        }

        public GlosaVector4 ScaleNew(double sx, double sy, double sz, double sw = 0)
        {
            return scaleNewComponent_v4(this, sx, sy, sz, sw);
        }

        public void ScaleSelf(double sx, double sy, double sz, double sw = 0)
        {
            this = scaleSelfComponent_v4(this, sx, sy, sz, sw);
        }

        public GlosaVector4 RotateNew(float theta, int component = 0)
        {
            if (component == 0) { return rotateXYNew_v4(this, theta); }
            else if (component == 1) { return rotateXZNew_v4(this, theta); }
            else if (component == 2) { return rotateXWNew_v4(this, theta); }
            else if (component == 3) { return rotateYZNew_v4(this, theta); }
            else if (component == 4) { return rotateYWNew_v4(this, theta); }
            else if (component == 5) { return rotateZWNew_v4(this, theta); }
            else { throw new System.ArgumentException("Component value must be between 0 and 2 representing x, y, z"); }
        }

        public void RotateSelf(float theta, int component = 0)
        {
            if (component == 0) { this = rotateXYSelf_v4(this, theta); }
            else if (component == 1) { this = rotateXZSelf_v4(this, theta); }
            else if (component == 2) { this = rotateXWSelf_v4(this, theta); }
            else if (component == 3) { this = rotateYZSelf_v4(this, theta); }
            else if (component == 4) { this = rotateYWSelf_v4(this, theta); }
            else if (component == 5) { this = rotateZWSelf_v4(this, theta); }
            else { throw new System.ArgumentException("Component value must be between 0 and 2 representing x, y, z"); }
        }

        public void Translate(GlosaVector4 vector)
        {
            this = translate_v4(this, vector);
        }

        public GlosaVector4 TransformNew(IMatrixes matrix)
        {
            return transformNew_v4(this, (GlosaMatrix44)matrix);
        }

        public void TransformSelf(IMatrixes matrix)
        {
            this = transformSelf_v4(this, (GlosaMatrix44)matrix);
        }

        public void RotateAxis(GlosaVector4 b1, GlosaVector4 b2, double theta, GlosaVector4 b3, GlosaVector4 b4, double phi)
        {
            this = rotateAxis_v4(this, b1, b2, theta, b3, b4, phi);
        }

        public static GlosaVector4 CalculatePlane(GlosaVector3 v1, GlosaVector3 v2, GlosaVector3 v3)
        {
            return calculatePlane_v4(v1, v2, v3);
        }
    }
}
