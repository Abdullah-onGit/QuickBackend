using QuickBackend.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;


namespace QuickBackend.Services
{
    public class DefaultService : IQuickService
    {
        private DefaultDBContext _context;

        public DefaultService()
        {
            _context = new DefaultDBContext();
        }
        public string Get()
        {
            string records = "";
            try
            {
                var data = _context.DefaultModel.ToList();
                records = JsonSerializer.Serialize(data);
            }
            catch (Exception ex)
            {

            }
            return records;
        }

        public string Get(int id)
        {
            string record = "";
            try
            {
                var data = _context.DefaultModel.FirstOrDefault(x=>x.DefaultModelAutoId==id);
                record = JsonSerializer.Serialize(data);
            }
            catch (Exception ex)
            {

            }
            return record;
        }

        public string Post(string record)
        {
            throw new NotImplementedException();
        }

        public void Put(int id,string record)
        {
            throw new NotImplementedException();
        }
        public string Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
