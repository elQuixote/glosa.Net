using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Interfaces
{
    public interface IVector<T>
    {
        T AddNew(T vector);
        void AddSelf(T vector);
        T SubtractNew(T vector);
        void SubtractSelf(T vector);
        T DivideNew(float f);
        void DivideSelf(float f);
        T MultiplyNew(float f);
        void MultiplySelf(float f);
        float Cross(T vector);
        float Dot(T vector);
        T Inverse(T vector);
        void InverseSelf();
        float Heading(T vector);
        T Reflect(T vector, T vector2);
        T Refract(T vector, T vector2, float f);
        T Normalize(T vector);
        float Magnitude(T vector);
        string Stringify(T vector);
        float AngleBetween(T vector, T vector2);
    }
}
