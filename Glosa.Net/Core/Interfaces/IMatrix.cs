namespace Glosa.Net.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMatrix<T> : IMatrixes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Transpose();

        /// <summary>
        /// 
        /// </summary>
        void TransposeSelf();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double Determinant();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Invert();

        /// <summary>
        /// 
        /// </summary>
        void InvertSelf();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        void Set(double n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        double[,] ToArray(double[,] array);
    }
}
