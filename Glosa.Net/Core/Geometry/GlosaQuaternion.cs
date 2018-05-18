using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Interfaces;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaQuaternion : ILength<GlosaQuaternion>, IEquals<GlosaQuaternion>
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
        private static extern GlosaQuaternion mulitplySelf_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion mulitplySelf2_quat(GlosaQuaternion q1, double f);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion normalizeNew_quat(GlosaQuaternion q1, double m = 1.0);
        [DllImport("wrapper_quaternion.dll")]
        private static extern GlosaQuaternion normalizeSelf_quat(GlosaQuaternion q1, double m = 1.0);
        [DllImport("wrapper_quaternion.dll")]
        private static extern double dot_quat(GlosaQuaternion q1, GlosaQuaternion q2);
        [DllImport("wrapper_quaternion.dll")]
        private static extern double conjugateSelf_quat(GlosaQuaternion q);
        [DllImport("wrapper_quaternion.dll")]
        private static extern double conjugateNew_quat(GlosaQuaternion q);
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

        /// <summary>
        /// Computes the length of the GlosaQuaternion
        /// </summary>
        /// <returns>The length</returns>
        public double Length()
        {
            return length_quat(this);
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
    }
}
