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
    public struct GlosaMatrix33 : IMatrix<GlosaMatrix33>, IEquals<GlosaMatrix33>, IString<GlosaMatrix33>, ICompare<GlosaMatrix33>,
        IClear<GlosaMatrix33>, IDimension<GlosaMatrix33>, IHash<GlosaMatrix33>, ICopy<GlosaMatrix33>
    {
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
    }
}
