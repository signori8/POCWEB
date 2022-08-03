using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POC_WEB.Pages
{    
    
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookParceiro : ControllerBase
    {
        public static string IdPropostaNot { get; set; }
        public static DateTime DataNotificacao { get; set; }


        [HttpPut]
        public ActionResult NotProposta(string IdProposta)
        {

            IdPropostaNot = IdProposta;
            DataNotificacao = DateTime.Now;
            return NoContent();
        }
    }
}
