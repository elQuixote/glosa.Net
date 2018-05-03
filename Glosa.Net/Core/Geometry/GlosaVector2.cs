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
        private static extern GlosaVector2 addNew(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 addSelf(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 subtractNew(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 subtractSelf(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 divideNew(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 divideSelf(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 multiplyNew(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 multiplySelf(GlosaVector2 v, float f);
        [DllImport("vector.dll")]
        private static extern float cross(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern float dot(GlosaVector2 v1, GlosaVector2 v2);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 inverseNew(GlosaVector2 v);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 inverseSelf(GlosaVector2 v);
        [DllImport("vector.dll")]
        private static extern float headingXY(GlosaVector2 v);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 reflectNew(GlosaVector2 v, GlosaVector2 n);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 reflectSelf(GlosaVector2 v, GlosaVector2 n);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 refractNew(GlosaVector2 v, GlosaVector2 n, float eta);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 refractSelf(GlosaVector2 v, GlosaVector2 n, float eta);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 normalizeNew(GlosaVector2 v, float m = 1.0f);
        [DllImport("vector.dll")]
        private static extern GlosaVector2 normalizeSelf(GlosaVector2 v, float m = 1.0f);
        [DllImport("vector.dll")]
        private static extern float angleBetween(GlosaVector2 v1, GlosaVector2 v2);
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
            Vector2 vector2 = subtractNew(this.vector, vector.vector);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void SubtractSelf(GlosaVector2 vector)
        {
            this.vector = subtractSelf(this.vector, vector.vector);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public GlosaVector2 DivideNew(float f)
        {
            Vector2 vector2 = divideNew(this.vector, f);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void DivideSelf(float f)
        {
            this.vector = divideSelf(this.vector, f);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public GlosaVector2 MultiplyNew(float f)
        {
            Vector2 vector2 = multiplyNew(this.vector, f);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void MultiplySelf(float f)
        {
            this.vector = multiplySelf(this.vector, f);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public float Cross(GlosaVector2 vector)
        {
            return cross(this.vector, vector.vector);
        }

        public float Dot(GlosaVector2 vector)
        {
            return dot(this.vector, vector.vector);
        }

        public GlosaVector2 InverseNew()
        {
            Vector2 vector2 = inverseNew(this.vector);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void InverseSelf()
        {
            this.vector = inverseSelf(this.vector);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public float Heading()
        {
            return headingXY(this.vector);
        }

        public GlosaVector2 ReflectNew(GlosaVector2 vector)
        {
            Vector2 vector2 = reflectNew(this.vector, vector.vector);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void ReflectSelf(GlosaVector2 vector)
        {
            this.vector = reflectSelf(this.vector, vector.vector);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public GlosaVector2 RefractNew(GlosaVector2 vector, float f)
        {
            Vector2 vector2 = refractNew(this.vector, vector.vector, f);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void RefractSelf(GlosaVector2 vector, float f)
        {
            this.vector = refractSelf(this.vector, vector.vector, f);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public GlosaVector2 NormalizeNew()
        {
            Vector2 vector2 = normalizeNew(this.vector);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void NormalizeSelf()
        {
            this.vector = normalizeSelf(this.vector);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(this.vector.x * this.vector.x + this.vector.y * this.vector.y);
        }

        public string Stringify()
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0},{1}", m_x, m_y);
        }

        public float AngleBetween(GlosaVector2 vector)
        {
            return angleBetween(this.vector, vector.vector);
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
