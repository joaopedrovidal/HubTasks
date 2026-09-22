using HubTasksAplication.Entities;
using HubTasksAplication.UseCase.Tarefa.ObterPorId;

namespace HubTasksAplication.UseCase.Tarefa.Excluir;

public class ExcluirTarefaUseCase
{
    public void Executar(Guid id)
    {
        var useCase = new ObterTarefaPorIdUseCase();
        var response = useCase.Execute(id);

        if (response is null)
        {
            throw new ArgumentException("Tarefa não encontrada.");
        }


        var listaDeTarefas = TarefaRepository.TarefaRepository.Tarefas;

        listaDeTarefas.Remove(response);
    }
}
