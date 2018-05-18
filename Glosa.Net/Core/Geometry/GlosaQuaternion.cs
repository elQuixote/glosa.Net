using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Interfaces;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaQuaternion
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
        private static extern GlosaQuaternion equals_quat(GlosaQuaternion q1, GlosaQuaternion q2);
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
    }
}
