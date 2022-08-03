using Newtonsoft.Json;
using POC_WEB.Models;
using System.Net.Http.Headers;
using System.Text;

namespace POC_WEB.Services;

public class ImputPropostaService
{
    public static int IdProposta;
    public int EnviarProposta(PropostaImput proposta)
    {
        string endpoint = "https://poc20220730145337.azurewebsites.net/Proposta";
        

        HttpClient client = new HttpClient();
        
        client.DefaultRequestHeaders.Add("KeySecret", proposta.Chave);       
       
        var data = new System.Net.Http.StringContent(proposta.Proposta, Encoding.UTF8, "application/json");
        var response = client.PostAsync(endpoint, data);
        var ret = response.Result.Content.ReadAsStringAsync().Result;

        Proposta Retorno = JsonConvert.DeserializeObject<Proposta>(ret);

        IdProposta = Retorno.Id;

        return IdProposta;

    }

    public string EnviarDocumento(PropostaImput proposta, string base64, string fileName)
    {
        string endpoint = "https://poc20220730145337.azurewebsites.net/Proposta/" + IdProposta.ToString()+"/Documento";

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("KeySecret", proposta.Chave);

        Documento documento = new Documento();
        documento.Id = 1;
        documento.Extensao = fileName;
        documento.TipoDocumento = 1;
        documento.IdProposta = IdProposta;
        documento.DocumentoBase64 = base64;
        
        var response = client.PutAsJsonAsync(endpoint, documento);
        var ret = response.Result.Content.ReadAsStringAsync().Result;

        return ret;
    }
    
}
