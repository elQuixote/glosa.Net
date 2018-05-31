using Glosa.Net.Core.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Interfaces
{
    public interface IVertices<T>
    {
        IVector ClosestVertex(IVector v);
        GlosaPolyline ToPolyline(T obj);
    }
}
