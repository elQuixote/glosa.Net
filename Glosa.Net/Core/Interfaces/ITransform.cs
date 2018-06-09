namespace Glosa.Net.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITransform<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        T ScaleNew(double s);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        void ScaleSelf(double s);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <param name="sw"></param>
        /// <returns></returns>
        T ScaleNew(double sx, double sy, double sz, double sw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="sz"></param>
        /// <param name="sw"></param>
        void ScaleSelf(double sx, double sy, double sz, double sw);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        T RotateNew(float theta, int component);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="component"></param>
        void RotateSelf(float theta, int component);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        void Translate(IVector vector);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        T TransformNew(IMatrixes matrix);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        void TransformSelf(IMatrixes matrix);
    }
}
