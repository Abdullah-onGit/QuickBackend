using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QuickBackend.Services
{
    interface IQuickService
    {
        string Get();
        string Get(int id);
        string Post(string record);
        void Put(int id,string record);
        string Delete(int id);
    }
}
