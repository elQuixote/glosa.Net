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

namespace Glosa.Net.Core.Geometry.Path
{
    /// <summary>
    /// 
    /// </summary>
    public class GlosaNurbsCurve : GlosaObject
    {
        /// <summary>
        /// 
        /// </summary>
        public int degree;

        /// <summary>
        /// 
        /// </summary>
        public IVector[] points;

        /// <summary>
        /// 
        /// </summary>
        public double[] weights;

        /// <summary>
        /// 
        /// </summary>
        public double[] knots;
        private int dimension;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="degree"></param>
        public GlosaNurbsCurve(IVector[] points, int degree = 3)
        {
            this.points = points;
            this.degree = degree;
            this.dimension = points[0].Dimension();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="weights"></param>
        /// <param name="knots"></param>
        /// <param name="degree"></param>
        public GlosaNurbsCurve(IVector[] controlPoints, double[] weights, double[] knots, int degree = 3)
        {
            this.points = controlPoints;
            this.weights = weights;
            this.knots = knots;
            this.degree = degree;
            this.dimension = controlPoints[0].Dimension();
        }

        private string GenerateJsonFromPoints(IVector[] points, int degree)
        {
            string s = "";
            s += @"{""degree"":" + degree.ToString() + "," + @"""points"":[";
            int type = points[0].Dimension();
            int count = 0;
            foreach (IVector p in points)
            {
                switch (type)
                {
                    case 0:
                        throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                    case 1:
                        throw new System.ArgumentException("NurbsCurve cannot have GlosaVectors of dimension 1", "dimension");
                    case 2:
                        GlosaVector2 gv2 = (GlosaVector2)p;
                        if (count == 0) { s += @"{""x"":" + gv2.x.ToString() + "," + @"""y"":" + gv2.y.ToString() + "}"; }
                        else { s += @",{""x"":" + gv2.x.ToString() + @",""y"":" + gv2.y.ToString() + "}"; }
                        break;
                    case 3:
                        GlosaVector3 gv3 = (GlosaVector3)p;
                        if (count == 0) { s += @"{""x"":" + gv3.x.ToString() + "," + @"""y"":" + gv3.y.ToString() + "," + @"""z"":" + gv3.z.ToString() + "}"; }
                        else { s += @",{""x"":" + gv3.x.ToString() + @",""y"":" + gv3.y.ToString() + @",""z"":" + gv3.z.ToString() + "}"; }
                        break;
                    case 4:
                        GlosaVector4 gv4 = (GlosaVector4)p;
                        if (count == 0)
                        {
                            s += @"{""x"":" + gv4.x.ToString() + "," + @"""y"":" + gv4.y.ToString() + "," + @"""z"":" + 
                                gv4.z.ToString() + "," + @"""w"":" + gv4.w.ToString() + "}";
                        }
                        else
                        {
                            s += @",{""x"":" + gv4.x.ToString() + @",""y"":" + gv4.y.ToString() + @",""z"":" + 
                                gv4.z.ToString() + @",""w"":" + gv4.w.ToString() + "}";
                        }
                        break;
                    default: throw new System.ArgumentException("NurbsCurve has an unvalid dimension", "dimension");
                }
                count++;
            }
            s += "]}";
            return s;
        }
    }
}
