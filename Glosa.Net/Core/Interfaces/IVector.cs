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
        //float Cross(T vector); //vector2 returns float and 3 returns vector, do we need float?
        float Dot(T vector);
        T InverseNew();
        void InverseSelf();
        float Heading();
        T ReflectNew(T vector);
        void ReflectSelf(T vector);
        T RefractNew(T vector, float f);
        void RefractSelf(T vector, float f);
        T NormalizeNew(float v);
        void NormalizeSelf(float v);
        float Magnitude();
        float AngleBetween(T vector);
        void Set(float n);
    }
}
