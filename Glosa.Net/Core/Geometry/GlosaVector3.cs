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
        IClear<GlosaVector3>, IDimension<GlosaVector3>, IHash<GlosaVector3>, ICopy<GlosaVector3>
    {
        #region C Reference Procs
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 addNew_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 addSelf_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 subtractNew_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 subtractSelf_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 divideNew_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 divideSelf_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 multiplyNew_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 multiplySelf_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 cross_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern float dot_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 inverseNew_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 inverseSelf_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern float heading_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 reflectNew_v3(GlosaVector3 v, GlosaVector3 n);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 reflectSelf_v3(GlosaVector3 v, GlosaVector3 n);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 refractNew_v3(GlosaVector3 v, GlosaVector3 n, float eta);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 refractSelf_v3(GlosaVector3 v, GlosaVector3 n, float eta);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 normalizeNew_v3(GlosaVector3 v, float m = 1.0f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 normalizeSelf_v3(GlosaVector3 v, float m = 1.0f);
        [DllImport("vectors.dll")]
        private static extern float angleBetween_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 clear_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern int dimension_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 copy_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 set_v3(GlosaVector3 v, float n);
        #endregion
        private float m_x, m_y, m_z;

        /// <summary>
        /// Gets or sets the X (first) component of this vector.
        /// </summary>
        public float x { get { return m_x; } set { m_x = value; } }

        /// <summary>
        /// Gets or sets the Y (second) component of this vector.
        /// </summary>
        public float y { get { return m_y; } set { m_y = value; } }

        /// <summary>
        /// Gets or sets the Z (third) component of this vector.
        /// </summary>
        public float z { get { return m_z; } set { m_z = value; } }

        /// <summary>
        /// Initializes a new instance of the GlosaVector3 based on three, X and Y and Z, components.
        /// </summary>
        /// <param name="x">The X (first) component.</param>
        /// <param name="y">The Y (second) component.</param>
        /// <param name="z">The Z (third) component.</param>
        public GlosaVector3(float x, float y, float z)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_z = z;
        }

        /// <summary>
        /// Initializes a new instance of the GlosaVector3 from a Rhino Vector3d.
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector3d</param>
        public GlosaVector3(Rhino.Geometry.Vector3d rhinoVector)
        {
            this.m_x = (float)rhinoVector.Y;
            this.m_y = (float)rhinoVector.Y;
            this.m_z = (float)rhinoVector.Z;
        }

        /// <summary>
        /// Initializes a new instance of the GlosaVector3 from a Rhino Vector3f.
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector3f</param>
        public GlosaVector3(Rhino.Geometry.Vector3f rhinoVector)
        {
            this.m_x = rhinoVector.Y;
            this.m_y = rhinoVector.Y;
            this.m_z = rhinoVector.Z;
        }
        #region Conversions
        /// <summary>
        /// Creates a GlosaVector3 from a Rhino Vector3d
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector3d</param>
        /// <returns>A new GlosaVector3 with the three, X and Y and Z, components from the Rhino Vector3d</returns>
        public static GlosaVector3 ToGlosaVector3(Rhino.Geometry.Vector3d rhinoVector)
        {
            return new GlosaVector3(rhinoVector);
        }

        /// <summary>
        /// Creates a GlosaVector3 from a Rhino Vector3f
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector3f</param>
        /// <returns>A new GlosaVector2 with the three, X and Y and Z, components from the Rhino Vector3f</returns>
        public static GlosaVector3 ToGlosaVector2(Rhino.Geometry.Vector3f rhinoVector)
        {
            return new GlosaVector3(rhinoVector);
        }

        /// <summary>
        /// Creates a RhinoVector3d from a GlosaVector3
        /// </summary>
        /// <returns>A new Rhino Vector3d with the three, X and Y and Z, components from the GlosaVector3</returns>
        public Rhino.Geometry.Vector3d ToVector3d()
        {
            return new Rhino.Geometry.Vector3d(this.x, this.y, this.z);
        }

        /// <summary>
        /// Creates a RhinoVector3f from a GlosaVector3
        /// </summary>
        /// <returns>A new Rhino Vector3f with the three, X and Y and Z, components from the GlosaVector3</returns>
        public Rhino.Geometry.Vector3f ToVector3f()
        {
            Rhino.Geometry.Vector3f rv = new Rhino.Geometry.Vector3f();
            rv.X = this.m_x;
            rv.Y = this.m_y;
            rv.Z = this.m_z;
            return rv;
        }
        #endregion
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
        public static GlosaVector3 DivideNew(GlosaVector3 vector, float f)
        {
            return divideNew_v3(vector, f);
        }

        /// <summary>
        /// Divides a GlosaVector3 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector3 that is componentwise divided by f</returns>
        public GlosaVector3 DivideNew(float f)
        {
            return divideNew_v3(this, f);
        }

        /// <summary>
        /// Divides a GlosaVector3 by a number, having the effect of shrinking it and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to divide by</param>
        public void DivideSelf(float f)
        {
            this = divideSelf_v3(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector3 to multiply</param>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector3 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector3 MultiplyNew(GlosaVector3 vector, float f)
        {
            return multiplyNew_v3(vector, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector3 that is the original vector coordinatewise multiplied by f.</returns>
        public GlosaVector3 MultiplyNew(float f)
        {
            return multiplyNew_v3(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector3 by a number, having the effect of scaling it, and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        public void MultiplySelf(float f)
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
        public static float Dot(GlosaVector3 vector, GlosaVector3 vector2)
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
        public float Dot(GlosaVector3 vector)
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
        public float HeadingXY()
        {
            return heading_v3(this);
        }

        //NOTE - NEED TO ADD HEADING XZ AND HEADING YZ (WRAP NIM METHODS FIRST)

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
        public GlosaVector3 RefractNew(GlosaVector3 vector, float f)
        {
            return refractNew_v3(this, vector, f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        public void RefractSelf(GlosaVector3 vector, float f)
        {
            this = refractSelf_v3(this, vector, f);
        }

        /// <summary>
        /// Normalizes the GlosaVector3 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>A new normalized GlosaVector3</returns>
        public GlosaVector3 NormalizeNew(float value)
        {
            return normalizeNew_v3(this, value);
        }

        /// <summary>
        /// Normalizes the GlosaVector3 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>Itself</returns>
        public void NormalizeSelf(float value)
        {
            this = normalizeSelf_v3(this, value);
        }

        /// <summary>
        /// Computes the length of the GlosaVector3
        /// </summary>
        /// <returns>The length</returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(this.m_x * this.m_x + this.m_y * this.m_y + this.m_z * this.m_z);
        }
    }
}
