using System.Text.Json;

namespace ProProsecco.Models
{
    public class ErrorDetailsModel
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
