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
        private static extern Vector2 cross(Vector2 vector, Vector2 vector2);
        [DllImport("vector.dll")]
        private static extern Vector2 dot(Vector2 vector, Vector2 vector2);
    }
}
