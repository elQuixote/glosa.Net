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
    }
}
