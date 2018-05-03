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
        private static extern Vector2 AddNew(Vector2 vector);
        [DllImport("vector.dll")]
        private static extern Vector2 AddSelf(Vector2 vector);
        [DllImport("vector.dll")]
        private static extern Vector2 SubtractNew(Vector2 vector);
        [DllImport("vector.dll")]
        private static extern Vector2 SubtractSelf(Vector2 vector);
        [DllImport("vector.dll")]
        private static extern Vector2 DivideNew(Vector2 vector, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 DivideSelf(Vector2 vector, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 MultiplyNew(Vector2 vector, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 MultiplySelf(Vector2 vector, float f);
        [DllImport("vector.dll")]
        private static extern Vector2 cross(Vector2 vector, Vector2 vector2);
    }
}
