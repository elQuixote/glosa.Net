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
        T DivideNew(double f);
        void DivideSelf(double f);
        T MultiplyNew(double f);
        void MultiplySelf(double f);
        //float Cross(T vector); //vector2 returns float and 3 returns vector, do we need float?
        double Dot(T vector);
        T InverseNew();
        void InverseSelf();
        double Heading();
        T ReflectNew(T vector);
        void ReflectSelf(T vector);
        T RefractNew(T vector, double f);
        void RefractSelf(T vector, double f);
        T NormalizeNew(double v);
        void NormalizeSelf(double v);
        double Magnitude();
        double AngleBetween(T vector);
        void Set(double n);
        float DistanceTo(T vector);
        T Interpolate(T vector);
        T Min(T[] vectors);
        T Max(T[] vectors);
        T FromArray(double[] array);
    }
}
