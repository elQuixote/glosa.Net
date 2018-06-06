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

        public GlosaNurbsCurve(IVector[] points, int degree = 3)
        {
            this.points = points;
            this.degree = degree;
            this.dimension = points[0].Dimension();
        }

        public GlosaNurbsCurve(IVector[] controlPoints, double[] weights, double[] knots, int degree = 3)
        {
            this.points = controlPoints;
            this.weights = weights;
            this.knots = knots;
            this.degree = degree;
            this.dimension = controlPoints[0].Dimension();
        }


    }
}
