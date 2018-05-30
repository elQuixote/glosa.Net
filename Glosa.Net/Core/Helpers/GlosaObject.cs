﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Glosa.Net.Core.Helpers
{
    /// <summary>
    /// The abstract Object Data Class
    /// </summary>
    public abstract class GlosaObject
    {
        /// <summary>
        /// Serializes the object into a Json formatted string
        /// </summary>
        /// <returns>The serialized string</returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
