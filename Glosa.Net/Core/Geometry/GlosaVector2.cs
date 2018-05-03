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
    public struct GlosaVector2 : IVector<GlosaVector2>
    {
        [DllImport("vector.dll")]
        private static extern Vector2 vector2(double x, double y);
        [DllImport("vector.dll")]
        private static extern Vector2 addNew(Vector2 v1, Vector2 v2);
        [DllImport("vector.dll")]
        private static extern Vector2 addSelf(Vector2 v1, Vector2 v2);
        [DllImport("vector.dll")]
        private static extern Vector2 subtractNew(Vector2 v1, Vector2 v2);
        [DllImport("vector.dll")]
        private static extern Vector2 subtractSelf(Vector2 v1, Vector2 v2);
        [DllImport("vector.dll")]
        private static extern Vector2 divideNew(Vector2 v, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 divideSelf(Vector2 v, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 multiplyNew(Vector2 v, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 multiplySelf(Vector2 v, float f);
        [DllImport("vector.dll")]
        private static extern float cross(Vector2 v1, Vector2 v2);
        [DllImport("vector.dll")]
        private static extern float dot(Vector2 v1, Vector2 v2);
        [DllImport("vector.dll")]
        private static extern Vector2 inverseNew(Vector2 v);
        [DllImport("vector.dll")]
        private static extern Vector2 inverseSelf(Vector2 v);
        [DllImport("vector.dll")]
        private static extern float headingXY(Vector2 v);
        [DllImport("vector.dll")]
        private static extern Vector2 reflectNew(Vector2 v, Vector2 n);
        [DllImport("vector.dll")]
        private static extern Vector2 reflectSelf(Vector2 v, Vector2 n);
        [DllImport("vector.dll")]
        private static extern Vector2 refractNew(Vector2 v, Vector2 n, float eta);
        [DllImport("vector.dll")]
        private static extern Vector2 refractSelf(Vector2 v, Vector2 n, float eta);
        [DllImport("vector.dll")]
        private static extern Vector2 normalizeNew(Vector2 v, float m = 1.0f);
        [DllImport("vector.dll")]
        private static extern Vector2 normalizeSelf(Vector2 v, float m = 1.0f);
        [DllImport("vector.dll")]
        private static extern float angleBetween(Vector2 v1, Vector2 v2);

        private Vector2 vector { get; set; }
        private double m_x, m_y;
        public double x { get { return m_x; } set { m_x = value; } }
        public double y { get { return m_y; } set { m_y = value; } }

        public GlosaVector2(double x, double y)
        {
            this.m_x = x;
            this.m_y = y;
            this.vector = vector2(x, y);
        }

        public GlosaVector2 AddNew(GlosaVector2 vector)
        {
            Vector2 vector2 = addNew(this.vector, vector.vector);
            return new GlosaVector2(vector2.x, vector2.y);
        }

        public void AddSelf(GlosaVector2 vector)
        {
            this.vector = addSelf(this.vector, vector.vector);
            this.m_x = this.vector.x;
            this.m_y = this.vector.y;
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
            return this.vector.ToString();
        }
        public float AngleBetween(GlosaVector2 vector)
        {
            return angleBetween(this.vector, vector.vector);
        }
    }
}
