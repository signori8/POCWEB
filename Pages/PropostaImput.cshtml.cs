using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using POC_WEB.Models;

using POC_WEB.Services;

namespace POC_WEB.Pages
{
    public class PropostaImputModel : PageModel
    {
        public string Message { get; set; }
        public string Message2 { get; set; }

        public string Message3 { get; set; }
        public void OnGet()
        {
            if (WebhookParceiro.IdPropostaNot != null)
            { 
                Message3 = "Notificação chegou! Código da proposta: "+ WebhookParceiro.IdPropostaNot.ToString()+ "-- Notificado em "+WebhookParceiro.DataNotificacao.ToString();
            }

            proposta.Proposta = "{\"data\":\"2022-06-30T00:25:32.685Z\",\"parceiro\":\"Lojista 01\",\"estabelecimento\":\"Loja 222\",\"produto\":600,"+
                "\"valorSolicitado\":2000,\"prazo\":12,\"primeiroVencimento\":\"2022-08-30T00:25:32.685Z\",\"cpf\":\"99999999999\",\"nome\":\"Nome do cliente\","+
                "\"dataNascimento\":\"2000-06-30T00:25:32.685Z\",\"cep\":\"99999999\",\"cidade\":\"Cidade do Cliente\",\"endereco\":\"Rua 1\",\"numero\":\"666\","+
                "\"complemento\":\"\",\"telefone\":\"99999999999\",\"email\":\"emailcliente@dom.com\",\"nomeMae\":\"Nome da mãe do cliente\",\"profissao\":\"Analista de QA\",\"renda\":5000}";
        }

        public void OnPost()
        {
            //if (!ModelState.IsValid)
           // {
            //    return Page();
           // }

            ImputPropostaService propostaService = new();

            int IdProposta = propostaService.EnviarProposta(proposta);
            this.Message = "Proposta enviada! Número gerado: "+ IdProposta.ToString();
            //return RedirectToAction("Get");

        }

        public void OnPostUpload(IFormFile File01)
        {
            byte[] bytes;
            var memoryStream = new MemoryStream();
            File01.OpenReadStream().CopyTo(memoryStream);
            
            bytes = memoryStream.ToArray(); ;
            var base64 = Convert.ToBase64String(bytes);
            
            ImputPropostaService propostaService = new();

            string link = propostaService.EnviarDocumento(proposta, base64, File01.FileName);

            this.Message2 = "Documento enviado! Link do Azure Blob Storage: "+link;
        }

        [BindProperty]
        public PropostaImput proposta { get; set; } = new();
     
    }
}

