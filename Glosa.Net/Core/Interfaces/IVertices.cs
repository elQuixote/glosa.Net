using Glosa.Net.Core.Geometry.Path;
using Glosa.Net.Core.Geometry.Polygon;

namespace Glosa.Net.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVertices<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        IVector ClosestVertex(IVector v);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        GlosaPolyline ToPolyline();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        GlosaPolygon ToPolygon();
    }
}
