using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosa.Net.Core.Interfaces
{
    public interface IMatrix<T>
    {
        T TransposeNew(T matrix);
        void TransposeSelf(T matrix);
        double Determinant(T matrix);
        T InvertNew(T matrix);
        void InvertSelf(T matrix);
        void Set(double n);
    }
}
