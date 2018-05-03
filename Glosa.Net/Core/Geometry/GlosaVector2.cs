using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Glosa.Net.Structs;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaVector2 : IVector<GlosaVector2>, ILength<GlosaVector2>, IEquals<GlosaVector2>, IString<GlosaVector2>, ICompare<GlosaVector2>
    {
        #region C Reference Procs
        [DllImport("vector.dll")]
        private static extern GlosaVector2 addNew_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 addSelf_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 subtractNew_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 subtractSelf_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 divideNew_v2(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 divideSelf_v2(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 multiplyNew_v2(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 multiplySelf_v2(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern float cross_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern float dot_v2(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 inverseNew_v2(GlosaVector2 v);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 inverseSelf_v2(GlosaVector2 v);
        [DllImport("vector.dll")]
        private static extern float heading_v2(GlosaVector2 v);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 reflectNew_v2(GlosaVector2 v, GlosaVector2 n);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 reflectSelf_v2(GlosaVector2 v, GlosaVector2 n);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 refractNew_v2(GlosaVector2 v, GlosaVector2 n, float eta);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 refractSelf_v2(GlosaVector2 v, GlosaVector2 n, float eta);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 normalizeNew_v2(GlosaVector2 v, float m = 1.0f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 normalizeSelf_v2(GlosaVector2 v, float m = 1.0f);
        [DllImport("vector.dll")]
        private static extern float angleBetween_v2(GlosaVector2 v1, GlosaVector2 v2);
        #endregion
        private double m_x, m_y;
        public double x { get { return m_x; } set { m_x = value; } }
        public double y { get { return m_y; } set { m_y = value; } }

        public GlosaVector2(double x, double y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        public GlosaVector2 AddNew(GlosaVector2 vector)
        {
            return addNew(this, vector);
        }

        public void AddSelf(GlosaVector2 vector)
        {
            this = addSelf(this, vector);
        }

        public GlosaVector2 SubtractNew(GlosaVector2 vector)
        {
            return subtractNew(this, vector);
        }

        public void SubtractSelf(GlosaVector2 vector)
        {
            this= subtractSelf(this, vector);
        }

        public GlosaVector2 DivideNew(float f)
        {
            return divideNew(this, f);
        }

        public void DivideSelf(float f)
        {
            this = divideSelf(this, f);
        }

        public GlosaVector2 MultiplyNew(float f)
        {
            return multiplyNew(this, f);
        }

        public void MultiplySelf(float f)
        {
            this = multiplySelf(this, f);
        }

        public float Cross(GlosaVector2 vector)
        {
            return cross(this, vector);
        }

        public float Dot(GlosaVector2 vector)
        {
            return dot(this, vector);
        }

        public GlosaVector2 InverseNew()
        {
            return inverseNew(this);
        }

        public void InverseSelf()
        {
            this = inverseSelf(this);
        }

        public float Heading()
        {
            return headingXY(this);
        }

        public GlosaVector2 ReflectNew(GlosaVector2 vector)
        {
            return reflectNew(this, vector);
        }

        public void ReflectSelf(GlosaVector2 vector)
        {
            this = reflectSelf(this, vector);
        }

        public GlosaVector2 RefractNew(GlosaVector2 vector, float f)
        {
            return refractNew(this, vector, f);
        }

        public void RefractSelf(GlosaVector2 vector, float f)
        {
            this = refractSelf(this, vector, f);
        }

        public GlosaVector2 NormalizeNew()
        {
            return normalizeNew(this);
        }

        public void NormalizeSelf()
        {
            this = normalizeSelf(this);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public string Stringify()
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0},{1}", m_x, m_y);
        }

        public float AngleBetween(GlosaVector2 vector)
        {
            return angleBetween(this, vector);
        }

        public float Length()
        {
            return this.Magnitude();
        }

        public bool Equals(GlosaVector2 vector)
        {
            return this == vector;
        }
        #region Operators
        public static bool operator ==(GlosaVector2 a, GlosaVector2 b)
        {
            return a.m_x == b.m_x && a.m_y == b.m_y;
        }
        public static bool operator !=(GlosaVector2 a, GlosaVector2 b)
        {
            return a.m_x != b.m_x || a.m_y != b.m_y;
        }
        public static bool operator <(GlosaVector2 a, GlosaVector2 b)
        {
            return (a.m_x < b.m_x) || (a.m_x == b.m_x && a.m_y < b.m_y);
        }
        public static bool operator <=(GlosaVector2 a, GlosaVector2 b)
        {
            return (a.m_x < b.m_x) || (a.m_x == b.m_x && a.m_y <= b.m_y);
        }
        public static bool operator >(GlosaVector2 a, GlosaVector2 b)
        {
            return (a.m_x > b.m_x) || (a.m_x == b.m_x && a.m_y > b.m_y);
        }
        public static bool operator >=(GlosaVector2 a, GlosaVector2 b)
        {
            return (a.m_x > b.m_x) || (a.m_x == b.m_x && a.m_y >= b.m_y);
        }
        #endregion
        public override bool Equals(object obj)
        {
            return (obj is GlosaVector2 && this == (GlosaVector2)obj);
        }

        public override int GetHashCode()
        {
            return m_x.GetHashCode() ^ m_y.GetHashCode();
        }

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
    }
}
