using HubTasksCommunication.Enums;

namespace HubTasksCommunication.Responses;

public class ResponseTarefaJson
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; } = string.Empty;
    public PrioridadeEnum Prioridade { get; set; }
    public DateTime DataConclusao { get; set; }
    public StatusEnum Status { get; set; }
}
