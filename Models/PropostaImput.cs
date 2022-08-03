namespace POC_WEB.Models;
using System.ComponentModel.DataAnnotations;

public class PropostaImput
{
    [Required()]
    public string Proposta { get; set; }
    
    [RegularExpression(@"^88209d8937d7351ef62018803e699df4$", ErrorMessage ="Chave de autenticação inválida")]
    public string Chave { get; set; }
    
}

public class DocumentosProposta
{
    public int Id { get; set; }
    public int IdProposta { get; set; }
    public int TipoDocumento { get; set; }
    public string? Extensao { get; set; }
    public string? DocumentoBase64 { get; set; }
}
