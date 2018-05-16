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
    /// </summary>
    public struct Matrix33 : IEquals<GlosaVector2>, IString<GlosaVector2>, ICompare<GlosaVector2>,
        IClear<GlosaVector2>, IDimension<GlosaVector2>, IHash<GlosaVector2>, ICopy<GlosaVector2>
    {

    }
}
