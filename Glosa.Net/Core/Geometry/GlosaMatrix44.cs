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
    /// Implements a simple row-major 3d matrix (4x4) matrix struct
    ///[ m00(0,0) m01(0,1) m02(0,2) m03(0,3) ]
    ///[ m10(1,0) m11(1,1) m12(1,2) m13(1,3) ]
    ///[ m20(2,0) m21(2,1) m22(2,2) m23(2,3) ]
    ///[ m30(3,0) m31(3,1) m32(3,2) m33(3,3) ]
    /// </summary>
    public struct GlosaMatrix44 : IMatrix<GlosaMatrix44>, IEquals<GlosaMatrix44>, IString<GlosaMatrix44>, IClear<GlosaMatrix44>,
        IDimension<GlosaMatrix44>, IHash<GlosaMatrix44>, ICopy<GlosaMatrix44>
    {
        #region C Reference Procs
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 clear_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 idMatrix_44();
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 set_44(GlosaMatrix44 m, double n);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 copy_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern bool equals_44(GlosaMatrix44 m, GlosaMatrix44 m2);
        [DllImport("wrapper_matrix.dll")]
        private static extern int hash_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stringify_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 transposeSelf_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 transposeNew_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern double determinant_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 invertSelf_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 invertNew_44(GlosaMatrix44 m);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 fromQuaternion_44(GlosaQuaternion q);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 rotateMatrixX_44(double theta);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 rotateMatrixY_44(double theta);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 rotateMatrixZ_44(double theta);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 scaleMatrix_44(double s);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 scaleMatrix2_44(double sx, double sy, double sz);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 shearMatrixX_44(double sy, double sz);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 shearMatrixY_44(double sx, double sz);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 shearMatrixZ_44(double sx, double sy);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 shearUniformMatrix_X_44(double sh);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 shearUniformMatrix_Y_44(double sh);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 shearUniformMatrix_Z_44(double sh);
        [DllImport("wrapper_matrix.dll")]
        private static extern GlosaMatrix44 fromVector4(GlosaVector4 v1, GlosaVector4 v2, GlosaVector4 v3, GlosaVector4 v4); 
        [DllImport("wrapper_matrix.dll")]
        private static extern void toArray_44(GlosaMatrix44 m, double[,] array);
        #endregion
        private double m_00, m_01, m_02, m_03, m_10, m_11, m_12, m_13, m_20, m_21, m_22, m_23, m_30, m_31, m_32, m_33;
        
        #region Properties
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
        /// Gets or sets the 0,3 component of this matrix.
        /// </summary>
        public double m03 { get { return m_03; } set { m_03 = value; } }
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
        /// Gets or sets the 1,1 component of this matrix.
        /// </summary>
        public double m13 { get { return m_13; } set { m_13 = value; } }
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
        /// Gets or sets the 2,3 component of this matrix.
        /// </summary>
        public double m23 { get { return m_23; } set { m_23 = value; } }
        /// <summary>
        /// Gets or sets the 3,0 component of this matrix.
        /// </summary>
        public double m30 { get { return m_30; } set { m_30 = value; } }
        /// <summary>
        /// Gets or sets the 3,1 component of this matrix.
        /// </summary>
        public double m31 { get { return m_31; } set { m_31 = value; } }
        /// <summary>
        /// Gets or sets the 3,2 component of this matrix.
        /// </summary>
        public double m32 { get { return m_32; } set { m_32 = value; } }
        /// <summary>
        /// Gets or sets the 3,3 component of this matrix.
        /// </summary>
        public double m33 { get { return m_33; } set { m_33 = value; } }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GlosaMatrix44
        /// </summary>
        /// <param name="m00">0,0 component of this matrix</param>
        /// <param name="m01">0,1 component of this matrix</param>
        /// <param name="m02">0,2 component of this matrix</param>
        /// <param name="m03">0,3 component of this matrix</param>
        /// <param name="m10">1,0 component of this matrix</param>
        /// <param name="m11">1,1 component of this matrix</param>
        /// <param name="m12">1,2 component of this matrix</param>
        /// <param name="m13">1,3 component of this matrix</param>
        /// <param name="m20">2,0 component of this matrix</param>
        /// <param name="m21">2,1 component of this matrix</param>
        /// <param name="m22">2,2 component of this matrix</param>
        /// <param name="m23">2,3 component of this matrix</param>
        /// <param name="m30">3,0 component of this matrix</param>
        /// <param name="m31">3,1 component of this matrix</param>
        /// <param name="m32">3,2 component of this matrix</param>
        /// <param name="m33">3,2 component of this matrix</param>
        public GlosaMatrix44(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33)
        {
            this.m_00 = m00;
            this.m_01 = m01;
            this.m_02 = m02;
            this.m_03 = m03;
            this.m_10 = m10;
            this.m_11 = m11;
            this.m_12 = m12;
            this.m_13 = m13;
            this.m_20 = m20;
            this.m_21 = m21;
            this.m_22 = m22;
            this.m_23 = m23;
            this.m_30 = m30;
            this.m_31 = m31;
            this.m_32 = m32;
            this.m_33 = m33;
        }

        /// <summary>
        /// Initializes a new instance of the GlosaMatrix44 from a two dimensional array
        /// </summary>
        /// <param name="array">The two dimensional array</param>
        public GlosaMatrix44(double[,] array)
        {
            if (array.GetUpperBound(0) != 3 && array.GetUpperBound(1) != 3) { throw new System.ArgumentException("array must be fixed two dimensional array [4,4] for GlosaMatrix44", "array"); }
            this.m_00 = array[0, 0];
            this.m_01 = array[0, 1];
            this.m_02 = array[0, 2];
            this.m_03 = array[0, 3];
            this.m_10 = array[1, 0];
            this.m_11 = array[1, 1];
            this.m_12 = array[1, 2];
            this.m_13 = array[1, 3];
            this.m_20 = array[2, 0];
            this.m_21 = array[2, 1];
            this.m_22 = array[2, 2];
            this.m_23 = array[2, 3];
            this.m_30 = array[3, 0];
            this.m_31 = array[3, 1];
            this.m_32 = array[3, 2];
            this.m_33 = array[3, 3];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets all GlosaMatrix44 components to 0.
        /// </summary>
        public void Clear()
        {
            this = clear_44(this);
        }

        /// <summary>
        /// Quick access to an identity matrix
        /// [1 0 0 0]
        /// [0 1 0 0]
        /// [0 0 1 0]
        /// [0 0 0 1]
        /// </summary>
        /// <returns>The identity matrix</returns>
        public static GlosaMatrix44 IDMatrix()
        {
            return idMatrix_44();
        }

        /// <summary>
        /// Sets the GlosaMatrix44 components to the specified value.
        /// [n n n n]
        /// [n n n n]
        /// [n n n n]
        /// [n n n n]
        /// </summary>
        /// <param name="n">The value</param>
        public void Set(double n)
        {
            this = set_44(this, n);
        }

        /// <summary>
        /// Copies a GlosaMatrix44 
        /// </summary>
        /// <returns>A new copy of that GlosaMatrix44</returns>
        public GlosaMatrix44 Copy()
        {
            return copy_44(this);
        }

        /// <summary>
        /// Copies a GlosaMatrix44 
        /// </summary>
        /// <param name="vector">The GlosaMatrix44 to copy</param>
        /// <returns>A new copy of that GlosaMatrix44</returns>
        public static GlosaMatrix44 CopyNew(GlosaMatrix44 m)
        {
            return copy_44(m);
        }

        /// <summary>
        /// Determines whether two GlosaMatrix44 have equal values.
        /// </summary>
        /// <param name="a">The first GlosaMatrix44</param>
        /// <param name="b">The second GlosaMatrix44</param>
        /// <returns>True if components of the two GlosaMatrix44 are pairwise equal; otherwise false.</returns>
        public static bool operator ==(GlosaMatrix44 a, GlosaMatrix44 b)
        {
            return equals_44(a, b);
        }

        /// <summary>
        /// Determines whether two GlosaMatrix44 have different values.
        /// </summary>
        /// <param name="a">The first GlosaMatrix44</param>
        /// <param name="b">The second GlosaMatrix44</param>
        /// <returns>True if any component of the two GlosaMatrix44 is pairwise different; otherwise false.</returns>
        public static bool operator !=(GlosaMatrix44 a, GlosaMatrix44 b)
        {
            return !equals_44(a, b);
        }

        /// <summary>
        /// Determines whether the specified GlosaMatrix44 has the same value as the present GlosaMatrix44.
        /// </summary>
        /// <param name="vector">The other GlosaMatrix44 to compare</param>
        /// <returns>The result</returns>
        public bool Equals(GlosaMatrix44 m)
        {
            return this == m;
        }

        /// <summary>
        /// Determines whether the specified System.Object is a GlosaMatrix44 and has the same values as the present GlosaMatrix44.
        /// </summary>
        /// <param name="obj">THe specified object</param>
        /// <returns>true if obj is a GlosaMatrix44 and has the same components as this; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GlosaMatrix44 && this == (GlosaMatrix44)obj);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaMatrix44.
        /// </summary>
        /// <returns>A non-unique number based on GlosaMatrix44 components.</returns>
        public int Hash()
        {
            return hash_44(this);
        }

        /// <summary>
        /// Provides a hashing value for the present GlosaMatrix44.
        /// </summary>
        /// <returns>A non-unique number based on GlosaMatrix44 components.</returns>
        public override int GetHashCode()
        {
            return hash_44(this);
        }

        /// <summary>
        /// Returns the string representation of the current GlosaMatrix44, in the form of
        ///[ m00(0,0) m01(0,1) m02(0,2) m03(0,3) ]
        ///[ m10(1,0) m11(1,1) m12(1,2) m13(1,3) ]
        ///[ m20(2,0) m21(2,1) m22(2,2) m23(2,3) ]
        ///[ m30(3,0) m31(3,1) m32(3,2) m33(3,3) ]
        /// </summary>
        /// <returns>A string</returns>
        public string Stringify()
        {
            IntPtr pStr = stringify_44(this);
            string rs = Marshal.PtrToStringAnsi(pStr);
            return rs ?? String.Empty;
        }

        /// <summary>
        /// Modifies this GlosaMatrix44 to be its transpose. This is like swapping rows with columns.
        /// </summary>
        public void TransposeSelf()
        {
            this = transposeSelf_44(this);
        }

        /// <summary>
        /// Creates a new transposed GlosaMatrix44. This is like swapping rows with columns.
        /// </summary>
        /// <returns>The new transposed GlosaMatrix44</returns>
        public GlosaMatrix44 Transpose()
        {
            return transposeNew_44(this);
        }

        /// <summary>
        /// Creates a new transposed GlosaMatrix44. This is like swapping rows with columns.
        /// </summary>
        /// <param name="m">The GlosaMatrix44 to transpose</param>
        /// <returns>The new transposed GlosaMatrix44</returns>
        public static GlosaMatrix44 Transpose(GlosaMatrix44 m)
        {
            return transposeNew_44(m);
        }

        /// <summary>
        /// Computes the determinant of the GlosaMatrix44.
        /// </summary>
        /// <returns>The determinant</returns>
        public double Determinant()
        {
            return determinant_44(this);
        }

        /// <summary>
        /// Computes the determinant of the GlosaMatrix44.
        /// </summary>
        /// <param name="m">The GlosaMatrix44 whose determinant we want to compute</param>
        /// <returns>The determinant</returns>
        public static double Determinant(GlosaMatrix44 m)
        {
            return determinant_44(m);
        }

        /// <summary>
        /// Modifies the current GlosaMatrix44 to be its inverse
        /// If the GlosaMatrix44 is not invertible (determinant = 0) an division by zero exception will be thrown
        /// </summary>
        public void InvertSelf()
        {
            this = invertSelf_44(this);
        }

        /// <summary>
        /// Returns a new GlosaMatrix44, which is the inverse of the GlosaMatrix44
        /// If the GlosaMatrix44 is not invertible (determinant = 0) an division by zero exception will be thrown
        /// </summary>
        public GlosaMatrix44 Invert()
        {
            return invertNew_44(this);
        }

        /// <summary>
        /// Returns a new GlosaMatrix44, which is the inverse of the GlosaMatrix44
        /// </summary>
        /// <param name="m">The GlosaMatrix44 to invert</param>
        /// <returns>A new inverted GlosaMatrix44</returns>
        public static GlosaMatrix44 Invert(GlosaMatrix44 m)
        {
            return invertNew_44(m);
        }

        /// <summary>
        /// Returns a new rotation matrix which represents a rotation by 'rad' radians
        /// [1  0  0  0]
        /// [0  c  s  0]
        /// [0 -s  c  0]
        /// [0  0  0  1]
        /// </summary>
        /// <param name="theta">The rotation value in radians</param>
        /// <returns>The rotation matrix</returns>
        public static GlosaMatrix44 RotateX(double theta)
        {
            return rotateMatrixX_44(theta);
        }

        /// <summary>
        /// Returns a new rotation matrix which represents a rotation by 'rad' radians
        /// [c  0 -s  0]
        /// [0  1  0  0]
        /// [s  0  c  0]
        /// [0  0  0  1]
        /// </summary>
        /// <param name="theta">The rotation value in radians</param>
        /// <returns>The rotation matrix</returns>
        public static GlosaMatrix44 RotateY(double theta)
        {
            return rotateMatrixY_44(theta);
        }

        /// <summary>
        /// Returns a new rotation matrix which represents a rotation by 'rad' radians
        /// [ c  s  0  0]
        /// [-s  c  0  0]
        /// [ s  0  1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="theta">The rotation value in radians</param>
        /// <returns>The rotation matrix</returns>
        public static GlosaMatrix44 RotateZ(double theta)
        {
            return rotateMatrixZ_44(theta);
        }

        /// <summary>
        /// Returns a new scale matrix
        /// [ s  0  0  0]
        /// [ 0  s  0  0]
        /// [ s  0  s  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="s">The scale value</param>
        /// <returns>The scale matrix</returns>
        public static GlosaMatrix44 Scale(double s)
        {
            return scaleMatrix_44(s);
        }

        /// <summary>
        /// Returns new a stretch matrix, which is a scale matrix with non uniform scale in x and y.
        /// [ sx 0  0  0]
        /// [ 0  sy 0  0]
        /// [ s  0  sz 0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sx">The scale value for x</param>
        /// <param name="sy">The scale value for y</param>
        /// <param name="sz">The scale value for z</param>
        /// <returns>A new stretch matrix</returns>
        public static GlosaMatrix44 Stretch(double sx, double sy, double sz)
        {
            return scaleMatrix2_44(sx, sy, sz);
        }

        /// <summary>
        /// Returns a new X-Direction Shear Matrix
        /// [ 1 sy sz  0]
        /// [ 0  1  0  0]
        /// [ 0  0  1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sy">The shear y value</param>
        /// <param name="sz">The shear z value</param>
        /// <returns>A new shear matrix</returns>
        public static GlosaMatrix44 ShearX(double sy, double sz)
        {
            return shearMatrixX_44(sy, sz);
        }

        /// <summary>
        /// Returns a new X-Direction Shear Matrix
        /// [ 1 sh sh  0]
        /// [ 0  1  0  0]
        /// [ 0  0  1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sh">The shear value</param>
        /// <returns>A new shear matrix</returns>
        public static GlosaMatrix44 ShearX(double sh)
        {
            return shearUniformMatrix_X_44(sh);
        }

        /// <summary>
        /// Returns a new Y-Direction Shear Matrix
        /// [ 1  0  0  0]
        /// [ sx 1  sz 0]
        /// [ 0  0  1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sx">The shear x value</param>
        /// <param name="sz">The shear z value</param>
        /// <returns>A new shear matrix</returns>
        public static GlosaMatrix44 ShearY(double sx, double sz)
        {
            return shearMatrixY_44(sx, sz);
        }

        /// <summary>
        /// Returns a new Y-Direction Shear Matrix
        /// [ 1  0  0  0]
        /// [ sh 1  sh 0]
        /// [ 0  0  1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sh">The shear value</param>
        /// <returns>A new shear matrix</returns>
        public static GlosaMatrix44 ShearY(double sh)
        {
            return shearUniformMatrix_Y_44(sh);
        }

        /// <summary>
        /// Returns a new Z-Direction Shear Matrix
        /// [ 1  0  0  0]
        /// [ 0  1  0  0]
        /// [ sx sy 1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sx">The shear x value</param>
        /// <param name="sy">The shear y value</param>
        /// <returns>A new shear matrix</returns>
        public static GlosaMatrix44 ShearZ(double sx, double sy)
        {
            return shearMatrixZ_44(sx, sy);
        }

        /// <summary>
        /// Returns a new Z-Direction Shear Matrix
        /// [ 1  0  0  0]
        /// [ 0  1  0  0]
        /// [ sh sh 1  0]
        /// [ 0  0  0  1]
        /// </summary>
        /// <param name="sh">The shear value</param>
        /// <returns>A new shear matrix</returns>
        public static GlosaMatrix44 ShearZ(double sh)
        {
            return shearUniformMatrix_Z_44(sh);
        }

        /// <summary>
        /// Returns a new GlosaMatrix44 created from 4 GlosaVector4
        /// [v1.x v2.x v3.x v4.x]
        /// [v1.y v2.y v3.y v4.y]
        /// [v1.z v2.z v3.z v4.z]
        /// [v1.w v2.w v3.w v4.w]
        /// </summary>
        /// <param name="v1">The first GlosaVector4</param>
        /// <param name="v2">The second GlosaVector4</param>
        /// <param name="v3">The third GlosaVector4</param>
        /// <param name="v4">The fourth GlosaVector4</param>
        /// <returns>A new GlosaMatrix44</returns>
        public GlosaMatrix44 FromVector4(GlosaVector4 v1, GlosaVector4 v2, GlosaVector4 v3, GlosaVector4 v4)
        {
            return fromVector4(v1, v2, v3, v4);
        }

        /// <summary>
        /// Returns an array with the GlosaMatrix44 components.
        /// [ m00(0,0) m01(0,1) m02(0,2) m03(0,3) ]
        /// [ m10(1,0) m11(1,1) m12(1,2) m13(1,3) ]
        /// [ m20(2,0) m21(2,1) m22(2,2) m23(2,3) ]
        /// [ m30(3,0) m31(3,1) m32(3,2) m33(3,3) ]
        /// </summary>
        /// <param name="array">The fixed two dimensional array to modify</param>
        /// <returns>The modified two dimensional array</returns>
        public double[,] ToArray(double[,] array)
        {
            if (array.GetUpperBound(0) != 3 && array.GetUpperBound(1) != 3) { throw new System.ArgumentException("array must be fixed two dimensional array [4,4] for GlosaMatrix44", "array"); }
            toArray_44(this, array);
            return array;
        }

        /// <summary>
        /// Gets the GlosaMatrix44 Dimension
        /// </summary>
        /// <returns>The dimension, for GlosaMatrix44 the result should be 3</returns>
        public int Dimension()
        {
            return 3;
        }

        /// <summary>
        /// Creates a new GlosaMatrix44 from a GlosaQuaternion
        /// </summary>
        /// <param name="q">The GlosaQuaternion</param>
        /// <returns>A new GlosaMatrix44</returns>
        public static GlosaMatrix44 FromQuaternion(GlosaQuaternion q)
        {
            return fromQuaternion_44(q);
        }
        #endregion
    }
}
