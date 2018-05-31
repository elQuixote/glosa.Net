using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonPath;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net.Http;

namespace Glosa.Net.Core.Helpers.Json
{
    /// <summary>
    /// The Utilities Class deals with JSON data parsing
    /// </summary>
    public static class Utilities
    {
        private static readonly JsonPathContext FParser = new JsonPathContext { ValueSystem = new JsonNetValueSystem() };
        /// <summary>
        /// Returns the list of data parsed from a string key
        /// </summary>
        /// <param name="incomingData">The json formatted string</param>
        /// <param name="queryData">The property key</param>
        /// <returns>The list of data</returns>
        public static List<string> parseData(string incomingData, string queryData)
        {
            var jsonObject = JObject.Parse(incomingData);
            return getMetaDataList(jsonObject, queryData);
        }
        /// <summary>
        /// Returns the filtered json data as a list
        /// </summary>
        /// <param name="jsonObject">the json object to parse</param>
        /// <param name="data">the data to filter by</param>
        /// <returns></returns>
        public static List<String> getMetaDataList(JObject jsonObject, string data)
        {
            String textValues = data + ".";
            List<String> val = FParser.SelectNodes(jsonObject, textValues).Select(node => node.Value.ToString()).ToList();
            return val;
        }
        /// <summary>
        /// Gets the parsed data as a list of strings
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<List<String>> getParsedData(JObject jsonObject, String[] values)
        {
            List<String> value;
            List<List<String>> tempStringList = new List<List<String>>();
            foreach (String st in values)
            {
                value = FParser.SelectNodes(jsonObject, st).Select(node => node.Value.ToString()).ToList();
                tempStringList.Add(value);
            }
            return tempStringList;
        }
        /// <summary>
        /// Creates the input values dictionary
        /// </summary>
        /// <param name="stringKeys">the keys</param>
        /// <param name="stringValues">the values</param>
        /// <returns></returns>
        public static Dictionary<string,string> createInputDictionary(string[] stringKeys, string[] stringValues)
        {
            Dictionary<string, string> inputDictionary = new Dictionary<string, string>();
            int count = 0;
            if (stringKeys.Length == stringValues.Length)
            {
                foreach (string s in stringKeys)
                {
                    inputDictionary.Add(s, stringValues[count]);
                    count++;
                }
            }
            return inputDictionary; 
        }
    }
}
