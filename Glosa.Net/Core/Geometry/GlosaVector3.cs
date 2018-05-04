using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaVector3 : IVector<GlosaVector3>, ILength<GlosaVector3>, IEquals<GlosaVector3>, IString<GlosaVector3>, ICompare<GlosaVector3>,
        IClear<GlosaVector3>, IDimension<GlosaVector3>, IHash<GlosaVector3>, ICopy<GlosaVector3>
    {
        #region C Reference Procs
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 addNew_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 addSelf_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 subtractNew_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 subtractSelf_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 divideNew_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 divideSelf_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 multiplyNew_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 multiplySelf_v3(GlosaVector3 v, float f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 cross_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern float dot_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 inverseNew_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 inverseSelf_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern float heading_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 reflectNew_v3(GlosaVector3 v, GlosaVector3 n);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 reflectSelf_v3(GlosaVector3 v, GlosaVector3 n);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 refractNew_v3(GlosaVector3 v, GlosaVector3 n, float eta);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 refractSelf_v3(GlosaVector3 v, GlosaVector3 n, float eta);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 normalizeNew_v3(GlosaVector3 v, float m = 1.0f);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 normalizeSelf_v3(GlosaVector3 v, float m = 1.0f);
        [DllImport("vectors.dll")]
        private static extern float angleBetween_v3(GlosaVector3 v1, GlosaVector3 v2);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 clear_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern int dimension_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 copy_v3(GlosaVector3 v);
        [DllImport("vectors.dll")]
        private static extern GlosaVector3 set_v3(GlosaVector3 v, float n);
        #endregion
    }
}
