using Database.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe
{
    /// <summary>
    /// Each HTTP reminder can have multiple conditions, this class is one condition and will return either true or false through Validate()
    /// </summary>
    public class HttpCondition
    {
        private object compareValue = null;
        private object apiValue = null;
        private JObject response;
        private HttpRequestCondition req;
        public HttpCondition(HttpRequestCondition req, JObject response)
        {
            this.req = req;
            this.response = response;
            switch (req.DataType)
            {
                case "string":
                    apiValue = response.SelectTokens(req.Property).Select(t => t.Value<string>()).ToList()[0];
                    compareValue = req.Value;
                    break;
                case "double":
                    apiValue = response.SelectTokens(req.Property).Select(t => t.Value<double>()).ToList()[0];
                    compareValue = double.Parse(req.Value.Replace(".",","));
                    break;
                case "bool":
                    apiValue = response.SelectTokens(req.Property).Select(t => t.Value<bool>()).ToList()[0];
                    compareValue = bool.Parse(req.Operator);
                    break;
            }
        }

        /// <summary>
        /// Validate this condition. It compares the value of the HttpRequest versus the response from the API with the appropriate operator and datatype
        /// </summary>
        /// <returns></returns>
        public bool Evaluate()
        {
            
            switch(req.DataType)
            {
                case "string": return EvaluateString();
                case "double": return EvaluateDouble();
                case "bool": return EvaluateBoolean();
                default:return false;
            }
            
        }
        private bool EvaluateString()
        {
            string apiVal = (string)apiValue;            
            switch (req.Operator)
            {
                case "==": return apiVal == req.Value;
                case "!=": return apiVal != req.Value;
                case "startsWith": return apiVal.StartsWith(req.Value);
                case "endsWith": return apiVal.EndsWith(req.Value);
                case "contains": return apiVal.Contains(req.Value);

                case "length ==": return apiVal.Length == Double.Parse(compareValue.ToString());
                case "length !=": return apiVal.Length != Double.Parse(compareValue.ToString());
                case "length >": return apiVal.Length > Double.Parse(compareValue.ToString());
                case "length <": return apiVal.Length < Double.Parse(compareValue.ToString());
                case "length >=": return apiVal.Length >= Double.Parse(compareValue.ToString());
                case "length <=": return apiVal.Length <= Double.Parse(compareValue.ToString());

                default: return false;
            }
        }
        private bool EvaluateDouble()
        {
            double apiVal = (double)apiValue;
            switch (req.Operator)
            {                
                case "==": return apiVal == (double)compareValue;
                case "!=": return apiVal != (double)compareValue;
                case ">": return apiVal > (double)compareValue; 
                case "<": return apiVal < (double)compareValue;
                case ">=": return apiVal >= (double)compareValue;
                case "<=": return apiVal <= (double)compareValue;

                default: return false;
            }
        }
        private bool EvaluateBoolean()
        {
            bool apiVal = (bool)apiValue;
            return apiVal == Boolean.Parse(req.Operator);
        }
    }
}
