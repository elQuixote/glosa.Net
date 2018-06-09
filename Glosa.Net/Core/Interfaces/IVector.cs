namespace Glosa.Net.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVector<T> : IVector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        T AddNew(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        void AddSelf(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        T SubtractNew(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        void SubtractSelf(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        T DivideNew(double f);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void DivideSelf(double f);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        T MultiplyNew(double f);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void MultiplySelf(double f);
        //float Cross(T vector); //vector2 returns float and 3 returns vector, do we need float?

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        double Dot(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T InverseNew();

        /// <summary>
        /// 
        /// </summary>
        void InverseSelf();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double Heading();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        T ReflectNew(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        void ReflectSelf(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        T RefractNew(T vector, double f);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        void RefractSelf(T vector, double f);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        T NormalizeNew(double v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        void NormalizeSelf(double v);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double Magnitude();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        double AngleBetween(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        void Set(double n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        double DistanceTo(T vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        T Interpolate(T vector, double f);
    }
}
