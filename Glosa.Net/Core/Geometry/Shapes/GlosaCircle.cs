using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Glosa.Net.Core.Interfaces;
using Glosa.Net.Core.Helpers;
using Glosa.Net.Core.Helpers.Json;

namespace Glosa.Net.Core.Geometry.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    public class GlosaCircle : GlosaObject
    {
        /// <summary>
        /// 
        /// </summary>
        public double radius;
        /// <summary>
        /// 
        /// </summary>
        public IVector center;
        private int dimension;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="rad"></param>
        public GlosaCircle(IVector v, double rad)
        {
            this.radius = rad;
            this.center = v;
            this.dimension = v.Dimension();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        public GlosaCircle(double x, double y, double rad)
        {
            this.radius = rad;
            this.center = new GlosaVector2(x, y);
            this.dimension = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="rad"></param>
        public GlosaCircle(double x, double y, double z, double rad)
        {
            this.radius = rad;
            this.center = new GlosaVector3(x, y, z);
            this.dimension = 3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        public GlosaCircle(IVector vector1, IVector vector2)
        {
            switch (vector1.Dimension())
            {
                case 0:
                    throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
                case 1:
                    throw new System.ArgumentException("Circle cannot have GlosaVectors of dimension 1", "dimension");
                case 2:
                    if(vector2.Dimension() != 2) { throw new System.ArgumentException("Cannot create circle with 2 GlosaVectors of different dimensions"); }
                    GlosaVector2 gv = GlosaVector2.InterpolateNew((GlosaVector2)vector1, (GlosaVector2)vector2, 0.5);
                    this.center = gv;
                    this.radius = gv.DistanceTo((GlosaVector2)vector2);
                    break;
                case 3:
                    if (vector2.Dimension() != 2) { throw new System.ArgumentException("Cannot create circle with 2 GlosaVectors of different dimensions"); }
                    GlosaVector3 gv3 = GlosaVector3.InterpolateNew((GlosaVector3)vector1, (GlosaVector3)vector2, 0.5);
                    this.center = gv3;
                    this.radius = gv3.DistanceTo((GlosaVector3)vector2);
                    break;
                case 4:
                    if (vector2.Dimension() != 2) { throw new System.ArgumentException("Cannot create circle with 2 GlosaVectors of different dimensions"); }
                    GlosaVector4 gv4 = GlosaVector4.InterpolateNew((GlosaVector4)vector1, (GlosaVector4)vector2, 0.5);
                    this.center = gv4;
                    this.radius = gv4.DistanceTo((GlosaVector4)vector2);
                    break;
                default: throw new System.ArgumentException("Circle has an unvalid dimension", "dimension");
            }
        }
    }
}
