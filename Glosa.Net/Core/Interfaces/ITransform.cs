using Glosa.Net.Core.Geometry;
using Glosa.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Interfaces
{
    public interface ITransform<T>
    {
        T ScaleNew(double s);
        void ScaleSelf(double s);
        T ScaleNew(double sx, double sy, double sz, double sw);
        void ScaleSelf(double sx, double sy, double sz, double sw);
        T RotateNew(float theta, int component);
        void RotateSelf(float theta, int component);
        void Translate(IVector vector);
        T TransformNew(IMatrixes matrix);
        void TransformSelf(IMatrixes matrix);
    }
}
