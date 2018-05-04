using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaVector3 : IVector<GlosaVector2>, ILength<GlosaVector2>, IEquals<GlosaVector2>, IString<GlosaVector2>, ICompare<GlosaVector2>,
        IClear<GlosaVector2>, IDimension<GlosaVector2>, IHash<GlosaVector2>, ICopy<GlosaVector2>
    {
    }
}
