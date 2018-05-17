using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Interfaces
{
    public interface IMatrix<T>
    {
        T Transpose();
        void TransposeSelf();
        double Determinant();
        T Invert();
        void InvertSelf();
        void Set(double n);
        double[,] ToArray(T matrix);
    }
}
