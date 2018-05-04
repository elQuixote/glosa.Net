﻿using Glosa.Net.Core.Interfaces;
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
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 addNew_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 addSelf_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 subtractNew_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 subtractSelf_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 divideNew_v2(GlosaVector2 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 divideSelf_v2(GlosaVector2 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 multiplyNew_v2(GlosaVector2 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 multiplySelf_v2(GlosaVector2 v, float f);
        [DllImport("vectors.dll")]
        private static extern float cross_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern float dot_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 inverseNew_v2(GlosaVector2 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 inverseSelf_v2(GlosaVector2 v);
        [DllImport("vectors.dll")]
        private static extern float heading_v2(GlosaVector2 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 reflectNew_v2(GlosaVector2 v, GlosaVector2 n);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 reflectSelf_v2(GlosaVector2 v, GlosaVector2 n);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 refractNew_v2(GlosaVector2 v, GlosaVector2 n, float eta);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 refractSelf_v2(GlosaVector2 v, GlosaVector2 n, float eta);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 normalizeNew_v2(GlosaVector2 v, float m = 1.0f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 normalizeSelf_v2(GlosaVector2 v, float m = 1.0f);
        [DllImport("vectors.dll")]
        private static extern float angleBetween_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 clear_v2(GlosaVector2 v);
        [DllImport("vectors.dll")]
        private static extern int dimension_v2(GlosaVector2 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector2 copy_v2(GlosaVector2 v);
        #endregion
        private float m_x, m_y;

        /// <summary>
        /// Gets or sets the X (first) component of this vector.
        /// </summary>
        public float x { get { return m_x; } set { m_x = value; } }

        /// <summary>
        /// Gets or sets the Y (second) component of this vector.
        /// </summary>
        public float y { get { return m_y; } set { m_y = value; } }

        /// <summary>
        /// Initializes a new instance of the vector based on two, X and Y, components.
        /// </summary>
        /// <param name="x">The X (first) component.</param>
        /// <param name="y">The Y (second) component.</param>
        public GlosaVector2(float x, float y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        /// <summary>
        /// Initializes a new instance of the vector from a Rhino Vector2d.
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector2d</param>
        public GlosaVector2(Rhino.Geometry.Vector2d rhinoVector)
        {
            this.m_x = (float)rhinoVector.Y;
            this.m_y = (float)rhinoVector.Y;
        }

        /// <summary>
        /// Initializes a new instance of the vector from a Rhino Vector2f.
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector2f</param>
        public GlosaVector2(Rhino.Geometry.Vector2f rhinoVector)
        {
            this.m_x = rhinoVector.Y;
            this.m_y = rhinoVector.Y;
        }

        #region Conversions
        /// <summary>
        /// Creates a GlosaVector2 from a Rhino Vector2d
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector2d</param>
        /// <returns>A new GlosaVector2 with the two, X and Y, components from the Rhino Vector2d</returns>
        public static GlosaVector2 ToGlosaVector2(Rhino.Geometry.Vector2d rhinoVector)
        {
            return new GlosaVector2(rhinoVector);
        }

        /// <summary>
        /// Creates a GlosaVector2 from a Rhino Vector2f
        /// </summary>
        /// <param name="rhinoVector">The Rhino Vector2f</param>
        /// <returns>A new GlosaVector2 with the two, X and Y, components from the Rhino Vector2f</returns>
        public static GlosaVector2 ToGlosaVector2(Rhino.Geometry.Vector2f rhinoVector)
        {
            return new GlosaVector2(rhinoVector);
        }

        /// <summary>
        /// Creates a RhinoVector2d from a GlosaVector2
        /// </summary>
        /// <returns>A new Rhino Vector2d with the two, X and Y, components from the GlosaVector2</returns>
        public Rhino.Geometry.Vector2d ToVector2d()
        {
            return new Rhino.Geometry.Vector2d(this.x, this.y);
        }

        /// <summary>
        /// Creates a RhinoVector2f from a GlosaVector2
        /// </summary>
        /// <returns>A new Rhino Vector2f with the two, X and Y, components from the GlosaVector2</returns>
        public Rhino.Geometry.Vector2f ToVector2f()
        {
            Rhino.Geometry.Vector2f rv = new Rhino.Geometry.Vector2f();
            rv.X = this.m_x;
            rv.Y = this.m_y;
            return rv;
        }
        #endregion
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
        public static GlosaVector2 DivideNew(GlosaVector2 vector, float f)
        {
            return divideNew_v2(vector, f);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector2 that is componentwise divided by f</returns>
        public GlosaVector2 DivideNew(float f)
        {
            return divideNew_v2(this, f);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to divide by</param>
        public void DivideSelf(float f)
        {
            this = divideSelf_v2(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to multiply</param>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector2 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector2 MultiplyNew(GlosaVector2 vector, float f)
        {
            return multiplyNew_v2(vector, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        /// <returns>A new GlosaVector2 that is the original vector coordinatewise multiplied by f.</returns>
        public GlosaVector2 MultiplyNew(float f)
        {
            return multiplyNew_v2(this, f);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it, and overrides coordinates with result.
        /// </summary>
        /// <param name="f">The number to multiply by</param>
        public void MultiplySelf(float f)
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
        public static float Cross(GlosaVector2 vector, GlosaVector2 vector2)
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
        public float Cross(GlosaVector2 vector)
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
        public static float Dot(GlosaVector2 vector, GlosaVector2 vector2)
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
        public float Dot(GlosaVector2 vector)
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
        public float Heading()
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
        public GlosaVector2 RefractNew(GlosaVector2 vector, float f)
        {
            return refractNew_v2(this, vector, f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        public void RefractSelf(GlosaVector2 vector, float f)
        {
            this = refractSelf_v2(this, vector, f);
        }

        /// <summary>
        /// Normalizes the GlosaVector2 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>A new normalized GlosaVector</returns>
        public GlosaVector2 NormalizeNew(float value)
        {
            return normalizeNew_v2(this, value);
        }

        /// <summary>
        /// Normalizes the GlosaVector2 so that its magnitude is = value
        /// </summary>
        /// <param name="value">The value to normalize to</param>
        /// <returns>Itself</returns>
        public void NormalizeSelf(float value)
        {
            this = normalizeSelf_v2(this, value);
        }

        /// <summary>
        /// Computes the length of the GlosaVector2
        /// </summary>
        /// <returns>The length</returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        /// <summary>
        /// Returns the string representation of the current GlosaVector2, in the form X,Y.
        /// </summary>
        /// <returns>A string with the current location of the GlosaVector2.</returns>
        public string Stringify()
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0},{1}", m_x, m_y);
        }

        /// <summary>
        /// Compute the angle between two GlosaVector2.
        /// </summary>
        /// <param name="vector">The first vector</param>
        /// <param name="vector2">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public static float AngleBetween(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return angleBetween_v2(vector, vector2);
        }

        /// <summary>
        /// Compute the angle between two GlosaVector2.
        /// </summary>
        /// <param name="vector">The second vector</param>
        /// <returns>The angle (in radians) between this and vector</returns>
        public float AngleBetween(GlosaVector2 vector)
        {
            return angleBetween_v2(this, vector);
        }

        /// <summary>
        /// Gets the Length of the GlosaVector2
        /// </summary>
        /// <returns>The length</returns>
        public float Length()
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
            return a.m_x == b.m_x && a.m_y == b.m_y;
        }

        /// <summary>
        /// Determines whether two GlosaVector2 have different values.
        /// </summary>
        /// <param name="a">The first GlosaVector2</param>
        /// <param name="b">The second GlosaVector2</param>
        /// <returns>True if any component of the two vectors is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaVector2 a, GlosaVector2 b)
        {
            return a.m_x != b.m_x || a.m_y != b.m_y;
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
            return (a.m_x < b.m_x) || (a.m_x == b.m_x && a.m_y < b.m_y);
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
            return (a.m_x < b.m_x) || (a.m_x == b.m_x && a.m_y <= b.m_y);
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
            return (a.m_x > b.m_x) || (a.m_x == b.m_x && a.m_y > b.m_y);
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
            return (a.m_x > b.m_x) || (a.m_x == b.m_x && a.m_y >= b.m_y);
        }

        /// <summary>
        /// Multiplies a GlosaVector2 by a number, having the effect of scaling it.
        /// </summary>
        /// <param name="vector">The GlosaVector2 to multiply</param>
        /// <param name="f">The value to multiply by</param>
        /// <returns>A new GlosaVector2 that is the original vector coordinatewise multiplied by f.</returns>
        public static GlosaVector2 operator *(GlosaVector2 vector, float f)
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
        public static float operator *(GlosaVector2 vector, GlosaVector2 vector2)
        {
            return dot_v2(vector, vector2);
        }

        /// <summary>
        /// Divides a GlosaVector2 by a number, having the effect of shrinking it
        /// </summary>
        /// <param name="vector">The GlosaVector2 to divide</param>
        /// <param name="f">The number to divide by</param>
        /// <returns>A new GlosaVector2 that is componentwise divided by f</returns>
        public static GlosaVector2 operator /(GlosaVector2 vector, float f)
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
            return m_x.GetHashCode() ^ m_y.GetHashCode();
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
        public void Set(float x, float y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        /// <summary>
        /// Sets the GlosaVector components, X and Y, to the specified value.
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(float n)
        {
            this.m_x = n;
            this.m_y = n;
        }
    }
}
