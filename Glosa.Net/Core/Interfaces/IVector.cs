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
        T DivideNew(T vector, float f);
        void DivideSelf(T vector, float f);
        T MultiplyNew(T vector, float f);
        void MultiplySelf(T vector, float f);
        float Dot(T vector, T vector2);
        T Inverse(T vector);
        float Heading(T vector);
        T Reflect(T vector, T vector2);
        T Refract(T vector, T vector2, float f);
        T Normalize(T vector);
        float Magnitude(T vector);
        string Stringify(T vector);
        float AngleBetween(T vector, T vector2);
    }
}
