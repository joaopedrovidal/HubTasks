using HubTasksCommunication.Responses;

namespace HubTasksAplication.UseCase.Tarefa.Listar;

public class ListarTarefasUseCase
{
    public List<ResponseTarefaJson> Execute()
    {
        return TarefaRepository.TarefaRepository.Tarefas.ToList();
    }
}
