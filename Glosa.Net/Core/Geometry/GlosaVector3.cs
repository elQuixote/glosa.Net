using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Geometry
{
    public struct GlosaVector3 : IVector<GlosaVector3>, ILength<GlosaVector3>, IEquals<GlosaVector3>, IString<GlosaVector3>, ICompare<GlosaVector3>,
        IClear<GlosaVector3>, IDimension<GlosaVector3>, IHash<GlosaVector3>, ICopy<GlosaVector3>
    {
    }
}
