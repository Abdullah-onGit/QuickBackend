using System.ComponentModel.DataAnnotations;

namespace QuickBackend.DAL
{
    public class DefaultModel
    {
        [Key]
        public int DefaultModelAutoId { get; set; }
        public string ResponseData { get; set; }
    }
}
