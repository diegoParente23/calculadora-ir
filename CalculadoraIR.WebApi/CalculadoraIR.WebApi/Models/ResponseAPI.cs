using System.Net;

namespace CalculadoraIR.WebApi.Models
{
    public class ResponseAPI
    {
        public HttpStatusCode Status { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }
    }
}