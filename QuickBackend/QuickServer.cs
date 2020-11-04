using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace QuickBackend
{
    public class QuickServer
    {
        private HttpListener listener;
        private static int AllowedRequestCount = 0;
        private static int RequestCount = 0;
        public QuickServer()
        {
            listener = new HttpListener();
            AllowedRequestCount = 10;
        }
        public static bool IsSupported
        {
            get
            {
                return HttpListener.IsSupported;
            }
        }
        public void DefalutConfiguration()
        {
            listener.Prefixes.Add("http://localhost:1234/");
        }
        public void Start()
        {
            try
            {
                listener.Start();
                Console.WriteLine("Listening...");
                while (true)
                {
                    if (RequestCount >= AllowedRequestCount)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        RequestCount++;
                        listener.BeginGetContext(new AsyncCallback(RequestHandler), listener);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void RequestHandler(IAsyncResult result)
        {
            try
            {
                HttpListener listener = (HttpListener)result.AsyncState;
                // Call EndGetContext to complete the asynchronous operation.
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                QuickRouter router = new QuickRouter();
                string str = router.Route(request);
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                response.AddHeader("Access-Control-Allow-Origin", "*");
                // Construct a response.
                string responseString = str;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
                RequestCount--;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
