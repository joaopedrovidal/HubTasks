using HubTasksCommunication.Responses;

namespace HubTasksAplication.UseCase.Tarefa.ObterPorId;

public class ObterTarefaPorIdUseCase
{
    public ResponseTarefaJson Execute(Guid id)
    {
        var listaDeTerafs = TarefaRepository.TarefaRepository.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

        return listaDeTerafs;
    }
}
