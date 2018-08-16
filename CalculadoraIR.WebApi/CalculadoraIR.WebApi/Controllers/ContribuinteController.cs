using CalculadoraIR.Domain.Services;
using CalculadoraIR.Domain.Services.Input;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculadoraIR.WebApi.Controllers
{
    [RoutePrefix("contribuinte")]
    public class ContribuinteController : ApiController
    {
        private readonly ContribuinteService _contribuinteService;

        public ContribuinteController(ContribuinteService contribuinteService)
        {
            _contribuinteService = contribuinteService;
        }

        [Route("api/v1/add-contribuinte")]
        [HttpPost]
        public HttpResponseMessage PostContribuinte([FromBody]CadastrarContribuinteInput cadastroDoContribuinte)
        {
            try
            {
                var resultado = _contribuinteService.Handle(cadastroDoContribuinte);

                if (_contribuinteService.IsValid())
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);

                return Request.CreateResponse(HttpStatusCode.BadRequest, _contribuinteService.Notifications);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }

        [Route("api/v1/calcular-imposto/{salarioMinimo}")]
        [HttpGet]
        public HttpResponseMessage GetImpostoCalculado(decimal salarioMinimo)
        {
            CalcularIRInput calculo = new CalcularIRInput();
            calculo.SalarioMinimo = salarioMinimo;

            try
            {
                var resultado = _contribuinteService.Handle(calculo);

                if (_contribuinteService.IsValid())
                    return Request.CreateResponse(HttpStatusCode.OK, resultado);

                return Request.CreateResponse(HttpStatusCode.BadRequest, _contribuinteService.Notifications);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message, ex);
            }
        }
    }
}
