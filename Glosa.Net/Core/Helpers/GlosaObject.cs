using System;
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
        /// Populates the object from Json formatted string
        /// </summary>
        /// <param name="data"></param>
        public void PopulateData(string data)
        {
            JsonConvert.PopulateObject(data, this);
        }
        /// <summary>
        /// Serializes the object into a Json formatted string
        /// </summary>
        /// <returns>The serialized string</returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        private string AddBody(string current_string)
        {
            return "{ \"body\": " + current_string + " }";
        }
    }
}
