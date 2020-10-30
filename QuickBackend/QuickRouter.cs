using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QuickBackend
{
    class QuickRouter
    {
        public string Route(HttpListenerRequest request)
        {
            string output = "";
            string HttpMethod = request.HttpMethod.ToUpper();
            string RouteParameter = request.RawUrl.TrimStart('/');
            int RouteId = 0;
            if (HttpMethod == HttpVerbs.GET && RouteParameter != "")
            {
                try
                {
                    RouteId = int.Parse(RouteParameter);
                    HttpMethod += "/ID";
                }
                catch
                {
                    return BadResquest();
                }
            }
            output = MethodSelection(HttpMethod, RouteId);
            return output;
        }
        private string MethodSelection(string HttpMethod, int RouteId)
        {
            string output = "";
            switch (HttpMethod)
            {
                case HttpVerbs.GET: output = Get(); break;
                case HttpVerbs.GET_ID: output = Get(RouteId); break;
                case HttpVerbs.POST: output = Post(); break;
                case HttpVerbs.PUT: output = Put(); break;
                case HttpVerbs.DELETE: output = Delete(); break;
                default: output = BadResquest(); break;
            }
            return output;
        }
        private string Get()
        {
            return "Get";
        }
        private string Get(int id)
        {
            return "Get " + id;
        }
        private string Post()
        {
            return "Post";
        }
        private string Put()
        {
            return "Put";
        }
        private string Delete()
        {
            return "Delete";
        }
        private string BadResquest()
        {
            return "BadResquest";
        }
    }
}
