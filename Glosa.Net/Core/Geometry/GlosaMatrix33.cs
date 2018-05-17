using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Glosa.Net.Core.Interfaces;

namespace Glosa.Net.Core.Geometry
{
    /// <summary>
    /// Implements a simple row-major 2d matrix (3x3) matrix struct
    /// [ m00(0,0) m01(0,1) m02(0,2) ]
    /// [ m10(1,0) m11(1,1) m12(1,2) ]
    /// [ m20(2,0) m21(2,1) m22(2,2) ]
    /// </summary>
    public struct GlosaMatrix33 : IMatrix<GlosaMatrix33>, IEquals<GlosaMatrix33>, IString<GlosaMatrix33>, IClear<GlosaMatrix33>,
        IDimension<GlosaMatrix33>, IHash<GlosaMatrix33>, ICopy<GlosaMatrix33>
    {
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 clear_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 idMatrix_33();
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 set_33(GlosaMatrix33 m, double n);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 copy_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern bool equals_33(GlosaMatrix33 m, GlosaMatrix33 m2);
        [DllImport("wrapper_matrix.dll")]
        private static extern int hash_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 transposeSelf_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 transposeNew_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern double determinant_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 invertSelf_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 invertNew_33(GlosaMatrix33 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 rotateMatrix_33(double theta);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 scaleMatrix_33(double s);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 scaleMatrix2_33(double sx, double sy);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 shearMatrixX_33(double sx);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 shearMatrixY_33(double sy);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix33 fromVector3(GlosaVector3 v1, GlosaVector3 v2, GlosaVector3 v3);
        [DllImport("wrapper_matrix.dll")]
        private static extern void toArray_33(GlosaMatrix33 m, double[,] array);

        private double m_00, m_01, m_02, m_10, m_11, m_12, m_20, m_21, m_22;
        /// <summary>
        /// Gets or sets the 0,0 component of this matrix.
        /// </summary>
        public double m00 { get { return m_00; } set { m_00 = value; } }
        /// <summary>
        /// Gets or sets the 0,1 component of this matrix.
        /// </summary>
        public double m01 { get { return m_01; } set { m_01 = value; } }
        /// <summary>
        /// Gets or sets the 0,2 component of this matrix.
        /// </summary>
        public double m02 { get { return m_02; } set { m_02 = value; } }
        /// <summary>
        /// Gets or sets the 1,0 component of this matrix.
        /// </summary>
        public double m10 { get { return m_10; } set { m_10 = value; } }
        /// <summary>
        /// Gets or sets the 1,1 component of this matrix.
        /// </summary>
        public double m11 { get { return m_11; } set { m_11 = value; } }
        /// <summary>
        /// Gets or sets the 1,2 component of this matrix.
        /// </summary>
        public double m12 { get { return m_12; } set { m_12 = value; } }
        /// <summary>
        /// Gets or sets the 2,0 component of this matrix.
        /// </summary>
        public double m20 { get { return m_20; } set { m_20 = value; } }
        /// <summary>
        /// Gets or sets the 2,1 component of this matrix.
        /// </summary>
        public double m21 { get { return m_21; } set { m_21 = value; } }
        /// <summary>
        /// Gets or sets the 2,2 component of this matrix.
        /// </summary>
        public double m22 { get { return m_22; } set { m_22 = value; } }

        /// <summary>
        /// Initializes a new instance of the GlosaMatrix33
        /// </summary>
        /// <param name="m00">0,0 component of this matrix</param>
        /// <param name="m01">0,1 component of this matrix</param>
        /// <param name="m02">0,2 component of this matrix</param>
        /// <param name="m10">1,0 component of this matrix</param>
        /// <param name="m11">1,1 component of this matrix</param>
        /// <param name="m12">1,2 component of this matrix</param>
        /// <param name="m20">2,0 component of this matrix</param>
        /// <param name="m21">2,1 component of this matrix</param>
        /// <param name="m22">2,2 component of this matrix</param>
        public GlosaMatrix33(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
        {
            this.m_00 = m00;
            this.m_01 = m01;
            this.m_02 = m02;
            this.m_10 = m10;
            this.m_11 = m11;
            this.m_12 = m12;
            this.m_20 = m20;
            this.m_21 = m21;
            this.m_22 = m22;
        }

        public void Clear()
        {
            this = clear_33(this);
        }

        public static GlosaMatrix33 IDMatrix()
        {
            return idMatrix_33();
        }

        public void Set(double n)
        {
            this = set_33(this, n);
        }

        public GlosaMatrix33 Copy()
        {
            return copy_33(this);
        }

        public static GlosaMatrix33 CopyNew(GlosaMatrix33 m)
        {
            return copy_33(m);
        }

        public static bool operator ==(GlosaMatrix33 a, GlosaMatrix33 b)
        {
            return equals_33(a, b);
        }

        public static bool operator !=(GlosaMatrix33 a, GlosaMatrix33 b)
        {
            return !equals_33(a, b);
        }

        public bool Equals(GlosaMatrix33 m)
        {
            return this == m;
        }

        /// <summary>
        /// Determines whether the specified System.Object is a GlosaMatrix33 and has the same values as the present GlosaMatrix33.
        /// </summary>
        /// <param name="obj">THe specified object</param>
        /// <returns>true if obj is a GlosaMatrix33 and has the same components as this; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GlosaMatrix33 && this == (GlosaMatrix33)obj);
        }

        public int Hash()
        {
            return hash_33(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaMatrix33.
        /// </summary>
        /// <returns>A non-unique number based on GlosaMatrix33 components.</returns>
        public override int GetHashCode()
        {
            return hash_33(this);
        }

        public string Stringify()
        {
            IntPtr pStr = stringify_33(this);
            string rs = Marshal.PtrToStringAnsi(pStr);
            return rs ?? String.Empty;
        }

        public void TransposeSelf()
        {
            this = transposeSelf_33(this);
        }

        public GlosaMatrix33 Transpose()
        {
            return transposeNew_33(this);
        }

        public static GlosaMatrix33 Transpose(GlosaMatrix33 m)
        {
            return transposeNew_33(m);
        }

        public double Determinant()
        {
            return determinant_33(this);
        }

        public static double Determinant(GlosaMatrix33 m)
        {
            return determinant_33(m);
        }

        public void InvertSelf()
        {
            this = invertSelf_33(this);
        }

        public GlosaMatrix33 Invert()
        {
            return invertNew_33(this);
        }

        public static GlosaMatrix33 Invert(GlosaMatrix33 m)
        {
            return invertNew_33(m);
        }

        public static GlosaMatrix33 Rotate(double theta)
        {
            return rotateMatrix_33(theta);
        }

        public static GlosaMatrix33 ScaleUniform(double s)
        {
            return scaleMatrix_33(s);
        }

        public static GlosaMatrix33 Scale(double sx, double sy)
        {
            return scaleMatrix2_33(sx, sy);
        }

        public static GlosaMatrix33 ShearX(double sx)
        {
            return shearMatrixX_33(sx);
        }

        public static GlosaMatrix33 ShearY(double sy)
        {
            return shearMatrixY_33(sy);
        }

        public GlosaMatrix33 FromVector3(GlosaVector3 v1, GlosaVector3 v2, GlosaVector3 v3)
        {
            return fromVector3(v1, v2, v3);
        }

        /// <summary>
        /// Returns an array with the GlosaMatrix33 components.
        /// [ m00(0,0) m01(0,1) m02(0,2) ]
        /// [ m10(1,0) m11(1,1) m12(1,2) ]
        /// [ m20(2,0) m21(2,1) m22(2,2) ]
        /// </summary>
        /// <param name="array">The fixed two dimensional array to modify</param>
        /// <returns>The modified two dimensional array</returns>
        public double[,] ToArray(double[,] array)
        {
            if (array.GetUpperBound(0) != 2 && array.GetUpperBound(1) != 2) { throw new System.ArgumentException("array must be fixed two dimensional array [3,3] for GlosaMatrix33", "array"); }
            toArray_33(this, array);
            return array;
        }

        public int Dimension()
        {
            return 2;
        }
    }
}
