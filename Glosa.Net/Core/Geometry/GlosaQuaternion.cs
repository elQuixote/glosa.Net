using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Interfaces;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaQuaternion : ILength<GlosaQuaternion>, IEquals<GlosaQuaternion>, IString<GlosaQuaternion>,
        IClear<GlosaQuaternion>, IHash<GlosaQuaternion>, ICopy<GlosaQuaternion>
    {
        #region C Reference Procs
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion copy_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion set_quat(GlosaQuaternion q, double n);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion clear_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion inverseNew_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion inverseSelf_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion invertNew_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion invertSelf_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern bool equals_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern int hash_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern double magnitudeSquared_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern double length_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion addNew_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion addNew2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion addSelf_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion addSelf2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion subtractNew_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion subtractNew2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion subtractSelf_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion subtractSelf2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion divideNew_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion divideNew2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion divideSelf_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion divideSelf2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion multiplyNew_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion multiplyNew2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion multiplySelf_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion multiplySelf2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion normalizeNew_quat(GlosaQuaternion q1, double m = 1.0);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion normalizeSelf_quat(GlosaQuaternion q1, double m = 1.0);
        [DllImport("wrapper_quaternion.dll")]
        private static extern double dot_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion conjugateSelf_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion conjugateNew_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion fromMatrix_quat(GlosaMatrix44 m);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion fromAxisAngle_quat(GlosaVector3 v, double a);
        [DllImport("wrapper_quaternion.dll")]
        private static extern void toArray_quat(GlosaQuaternion q, double[] array);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion fromVector3_quat(double w, GlosaVector3 v);
        #endregion
        private double m_x, m_y, m_z, m_w;

        /// <summary>
        /// Gets or sets the X (first) component of this quaternion.
        /// </summary>
        public double x { get { return m_x; } set { m_x = value; } }

        /// <summary>
        /// Gets or sets the Y (second) component of this quaternion.
        /// </summary>
        public double y { get { return m_y; } set { m_y = value; } }

        /// <summary>
        /// Gets or sets the Z (third) component of this quaternion.
        /// </summary>
        public double z { get { return m_z; } set { m_z = value; } }

        /// <summary>
        /// Gets or sets the W (fourth) component of this quaternion.
        /// </summary>
        public double w { get { return m_w; } set { m_w = value; } }

        /// <summary>
        /// Initializes a new instance of the GlosaQuaternion based on four, X and Y and Z and W, components.
        /// </summary>
        /// <param name="x">The X (first) component.</param>
        /// <param name="y">The Y (second) component.</param>
        /// <param name="z">The Z (third) component.</param>
        /// <param name="w">The W (fourth) component.</param>
        public GlosaQuaternion(double x, double y, double z, double w)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_z = z;
            this.m_w = w;
        }

        /// <summary>
        /// Initializes a new instance of the GlosaQuaternion based on a GlosaVector3 specifying the X,Y,Z components and W from double
        /// </summary>
        /// <param name="v">The GlosaVector3</param>
        /// <param name="w">The W value</param>
        public GlosaQuaternion(GlosaVector3 v, double w)
        {
            this.m_x = v.x;
            this.m_y = v.y;
            this.m_z = v.z;
            this.m_w = w;
        }

        public GlosaQuaternion(GlosaMatrix44 m)
        {
            this = fromMatrix_quat(m);
        }

        /// <summary>
        /// Computes the length of the GlosaQuaternion
        /// </summary>
        /// <returns>The length</returns>
        public double Length()
        {
            return length_quat(this);
        }

        public double MagnitudeSquared()
        {
            return magnitudeSquared_quat(this);
        }

        /// <summary>
        /// Determines whether the specified GlosaQuaternion has the same value as the present GlosaQuaternion.
        /// </summary>
        /// <param name="quaternion">The other GlosaQuaternion to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaQuaternion quaternion)
        {
            return this == quaternion;
        }

        /// <summary>
        /// Determines whether the specified System.Object is a GlosaQuaternion and has the same values as the present GlosaQuaternion.
        /// </summary>
        /// <param name="obj">THe specified object</param>
        /// <returns>true if obj is a GlosaQuaternion and has the same coordinates as this; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GlosaQuaternion && this == (GlosaQuaternion)obj);
        }

        /// <summary>
        /// Determines whether two GlosaQuaternion have equal values.
        /// </summary>
        /// <param name="a">The first GlosaQuaternion</param>
        /// <param name="b">The second GlosaQuaternion</param>
        /// <returns>True if components of the two GlosaQuaternion are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaQuaternion a, GlosaQuaternion b)
        {
            return equals_quat(a, b);
        }

        /// <summary>
        /// Determines whether two GlosaQuaternion have different values.
        /// </summary>
        /// <param name="a">The first GlosaQuaternion</param>
        /// <param name="b">The second GlosaQuaternion</param>
        /// <returns>True if any component of the two GlosaQuaternion is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaQuaternion a, GlosaQuaternion b)
        {
            return !equals_quat(a, b);
        }

        /// <summary>
        /// Returns the string representation of the current GlosaQuaternion, in the form X,Y,Z,W.
        /// </summary>
        /// <returns>A string representing the GlosaQuaternion.</returns>
        public string Stringify()
        {
            IntPtr pStr = stringify_quat(this);
            string rs = Marshal.PtrToStringAnsi(pStr);
            return rs ?? String.Empty;
        }

        /// <summary>
        /// Sets all GlosaQuaternion components to 0.
        /// </summary>
        public void Clear()
        {
            this = clear_quat(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaQuaternion.
        /// </summary>
        /// <returns>A non-unique number based on GlosaQuaternion components.</returns>
        public override int GetHashCode()
        {
            return hash_quat(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaQuaternion.
        /// </summary>
        /// <returns>A non-unique number based on GlosaQuaternion components.</returns>
        public int Hash()
        {
            return hash_quat(this);
        }

        /// <summary>
        /// Copies a GlosaQuaternion 
        /// </summary>
        /// <returns>A new copy of that GlosaQuaternion</returns>
        public GlosaQuaternion Copy()
        {
            return copy_quat(this);
        }

        /// <summary>
        /// Copies a GlosaQuaternion 
        /// </summary>
        /// <param name="quaternion">The GlosaQuaternion to copy</param>
        /// <returns>A new copy of that GlosaQuaternion</returns>
        public static GlosaQuaternion CopyNew(GlosaQuaternion quaternion)
        {
            return copy_quat(quaternion);
        }

        /// <summary>
        /// Sets all coefficients of the GlosaQuaternion to n.
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(double n)
        {
            this = set_quat(this, n);
        }

        /// <summary>
        /// Sets all coefficients of the GlosaQuaternion to n.
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(double x, double y, double z, double w)
        {
            this = new GlosaQuaternion(x, y, z, w);
        }

        public void InverseSelf()
        {
            this = inverseSelf_quat(this);
        }

        public GlosaQuaternion InverseNew()
        {
            return inverseNew_quat(this);
        }

        public static GlosaQuaternion InverseNew(GlosaQuaternion q)
        {
            return inverseNew_quat(q);
        }

        public void InvertSelf()
        {
            this = invertSelf_quat(this);
        }

        public GlosaQuaternion InvertNew()
        {
            return invertNew_quat(this);
        }

        public static GlosaQuaternion InvertNew(GlosaQuaternion q)
        {
            return invertNew_quat(q);
        }

        public void AddSelf(GlosaQuaternion q)
        {
            this = addSelf_quat(this, q);
        }

        public void AddSelf(double f)
        {
            this = addSelf2_quat(this, f);
        }

        public GlosaQuaternion AddNew(GlosaQuaternion q)
        {
            return addNew_quat(this, q);
        }

        public GlosaQuaternion AddNew(double f)
        {
            return addNew2_quat(this, f);
        }

        public static GlosaQuaternion Add(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return addNew_quat(q1, q2);
        }

        public static GlosaQuaternion Add(GlosaQuaternion q1, double f)
        {
            return addNew2_quat(q1, f);
        }

        public void SubtractSelf(GlosaQuaternion q)
        {
            this = subtractSelf_quat(this, q);
        }

        public void SubtractSelf(double f)
        {
            this = subtractSelf2_quat(this, f);
        }

        public GlosaQuaternion SubtractNew(GlosaQuaternion q)
        {
            return subtractNew_quat(this, q);
        }

        public GlosaQuaternion SubtractNew(double f)
        {
            return subtractNew2_quat(this, f);
        }

        public static GlosaQuaternion Subtract(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return subtractNew_quat(q1, q2);
        }

        public static GlosaQuaternion Subtract(GlosaQuaternion q1, double f)
        {
            return subtractNew2_quat(q1, f);
        }

        public void MultiplySelf(GlosaQuaternion q)
        {
            this = multiplySelf_quat(this, q);
        }

        public void MultiplySelf(double f)
        {
            this = multiplySelf2_quat(this, f);
        }

        public GlosaQuaternion MultiplyNew(GlosaQuaternion q)
        {
            return multiplyNew_quat(this, q);
        }

        public GlosaQuaternion MultiplyNew(double f)
        {
            return multiplyNew2_quat(this, f);
        }

        public static GlosaQuaternion Multiply(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return multiplyNew_quat(q1, q2);
        }

        public static GlosaQuaternion Multiply(GlosaQuaternion q1, double f)
        {
            return multiplyNew2_quat(q1, f);
        }

        public void DivideSelf(GlosaQuaternion q)
        {
            this = divideSelf_quat(this, q);
        }

        public void DivideSelf(double f)
        {
            this = divideSelf2_quat(this, f);
        }

        public GlosaQuaternion DivideNew(GlosaQuaternion q)
        {
            return divideNew_quat(this, q);
        }

        public GlosaQuaternion DivideNew(double f)
        {
            return divideNew2_quat(this, f);
        }

        public static GlosaQuaternion Divide(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return divideNew_quat(q1, q2);
        }

        public static GlosaQuaternion Divide(GlosaQuaternion q1, double f)
        {
            return divideNew2_quat(q1, f);
        }

        /// <summary>
        /// Sums up two GlosaQuaternion.
        /// </summary>
        /// <param name="q1">The GlosaQuaternion</param>
        /// <param name="q2">The second GlosaQuaternion</param>
        /// <returns>A new GlosaQuaternion that results from the componentwise addition of the two GlosaQuaternion.</returns>
        public static GlosaQuaternion operator +(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return addNew_quat(q1, q2);
        }

        /// <summary>
        /// Adds value to each component of the GlosaQuaternion
        /// </summary>
        /// <param name="q1">The GlosaQuaternion</param>
        /// <param name="f">The value to add</param>
        /// <returns>A new GlosaQuaternion that results from the componentwise addition of the GlosaQuaternion and f</returns>
        public static GlosaQuaternion operator +(GlosaQuaternion q1, double f)
        {
            return addNew2_quat(q1, f);
        }

        /// <summary>
        /// Subtracts a GlosaQuaternion from another one.
        /// <para>This computes the difference of each GlosaQuaternion coefficient with its
        /// correspondant and returns a new result GlosaQuaternion.</para>
        /// </summary>
        /// <param name="q1">A quaternion.</param>
        /// <param name="q2">Another GlosaQuaternion.</param>
        /// <returns>A new GlosaQuaternion.</returns>
        public static GlosaQuaternion operator -(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return subtractNew_quat(q1, q2);
        }

        /// <summary>
        /// Subtracts all GlosaQuaternion coefficients by a factor and returns a new GlosaQuaternion with the result.
        /// </summary>
        /// <param name="q1">The GlosaQuaternion</param>
        /// <param name="f">The value to subtract</param>
        /// <returns>A new GlosaQuaternion that results from the componentwise subtraction of the GlosaQuaternion and f</returns>
        public static GlosaQuaternion operator -(GlosaQuaternion q1, double f)
        {
            return subtractNew2_quat(q1, f);
        }

        /// <summary>
        /// Multiplies a GlosaQuaternion by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaQuaternion to multiply</param>
        /// <param name="f">The value to multiply by</param>
        /// <returns>A new GlosaQuaternion that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaQuaternion operator *(GlosaQuaternion q, float f)
        {
            return multiplyNew2_quat(q, f);
        }

        /// <summary>
        /// Multiplies a GlosaQuaternion with another one.
        /// <para>Quaternion multiplication (Hamilton product) is not commutative.</para>
        /// </summary>
        /// <param name="q1">The first term.</param>
        /// <param name="q2">The second term.</param>
        /// <returns>A new GlosaQuaternion.</returns>
        public static GlosaQuaternion operator *(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return multiplyNew_quat(q1, q2);
        }

        /// <summary>
        /// Divides all GlosaQuaternion coefficients by a factor and returns a new GlosaQuaternion with the result.
        /// </summary>
        /// <param name="q">A GlosaQuaternion.</param>
        /// <param name="y">A number.</param>
        /// <returns>A new GlosaQuaternion.</returns>
        public static GlosaQuaternion operator /(GlosaQuaternion q, double f)
        {
            return divideNew2_quat(q, f);
        }

        /// <summary>
        /// Divides a GlosaQuaternion with another one.
        /// </summary>
        /// <param name="q">A GlosaQuaternion.</param>
        /// <param name="y">A number.</param>
        /// <returns>A new GlosaQuaternion.</returns>
        public static GlosaQuaternion operator /(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return divideNew_quat(q1, q2);
        }

        /// <summary>
        /// Normalizes the GlosaQuaternion so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>A new normalized GlosaQuaternion</returns>
        public GlosaQuaternion NormalizeNew(double value)
        {
            return normalizeNew_quat(this, value);
        }

        /// <summary>
        /// Normalizes the GlosaQuaternion so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to GlosaQuaternion to</param>
        /// <returns>Itself</returns>
        public void NormalizeSelf(double value)
        {
            this = normalizeSelf_quat(this, value);
        }

        /// <summary>
        /// Multiplies two GlosaQuaternion together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="q1">The GlosaQuaternion</param>
        /// <param name="q2">The second GlosaQuaternion to multiply by</param>
        /// <returns>The dot product</returns>
        public static double Dot(GlosaQuaternion q1, GlosaQuaternion q2)
        {
            return dot_quat(q1, q2);
        }

        /// <summary>
        /// Multiplies two GlosaQuaternion together, returning the dot product (or inner product).
        /// </summary>
        /// <param name="q">The GlosaQuaternion to multiply by</param>
        /// <returns>The dot product</returns>
        public double Dot(GlosaQuaternion q)
        {
            return dot_quat(this, q);
        }

        /// <summary>
        /// Gets a new quaternion that is the conjugate of this quaternion.
        /// <para>This is (x,-y,-z,-w)</para>
        /// </summary>
        public void ConjugateSelf()
        {
            this = conjugateSelf_quat(this);
        }

        /// <summary>
        /// Gets a new quaternion that is the conjugate of this quaternion.
        /// <para>This is (x,-y,-z,-w)</para>
        /// </summary>
        /// <returns>A new conjugated GlosaQuaternion</returns>
        public GlosaQuaternion ConjugateNew()
        {
            return conjugateNew_quat(this);
        }

        /// <summary>
        /// Gets a new quaternion that is the conjugate of this quaternion.
        /// <param name="q">The GlosaQuaternion to conjugate</param>
        /// <para>This is (x,-y,-z,-w)</para>
        /// </summary>/// <returns>A new conjugated GlosaQuaternion</returns>
        public static GlosaQuaternion Conjugate(GlosaQuaternion q)
        {
            return conjugateNew_quat(q);
        }

        public GlosaQuaternion FromMatrix(GlosaMatrix44 m)
        {
            return fromMatrix_quat(m);
        }

        public static GlosaQuaternion FromAxisAngle(GlosaVector3 axis, double angle)
        {
            return fromAxisAngle_quat(axis, angle);
        }

        /// <summary>
        /// Returns an array with the GlosaQuaternion components, X Y Z and W,
        /// </summary>
        /// <param name="array">The fixed array to modify</param>
        /// <returns>The modified array</returns>
        public double[] ToArray(double[] array)
        {
            if (array.Length != 4) { throw new System.ArgumentException("array must be fixed array with length of 4 for GlosaQuaternion", "array"); }
            toArray_quat(this, array);
            return array;
        }
    }
}
