using HubTasksCommunication.Enums;

namespace HubTasksCommunication.Requests;

public class RequestCadastrarTarefaJson
{
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; } = string.Empty;
    public PrioridadeEnum Prioridade { get; set; }
    public DateTime DataConclusao { get; set; }
    public StatusEnum Status { get; set; }
}
