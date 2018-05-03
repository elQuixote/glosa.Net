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
    public class GlosaVector2 : IVector<GlosaVector2>
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
    }
}
