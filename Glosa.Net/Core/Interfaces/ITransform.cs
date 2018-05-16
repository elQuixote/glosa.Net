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
        T RotateNew(T vector, float theta);
        void RotateSelf(float theta);
        T Translate(T vector1, T vector2);
        //Need to add Matrix33 and Matrix44 structs before adding transformNew & Self
    }
}
