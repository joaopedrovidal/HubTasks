using HubTasksCommunication.Enums;
using HubTasksCommunication.Requests;
using HubTasksCommunication.Responses;

namespace HubTasksAplication.UseCase.Tarefa.Cadastrar;

public class CadastrarTarefaUseCase
{
    public ResponseTarefaJson Execute(RequestCadastrarTarefaJson request)
    {

        var tarefa = new ResponseTarefaJson
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome.Trim(),
            Descricao = request.Descricao.Trim(),
            Prioridade = request.Prioridade,
            DataConclusao = request.DataConclusao,
            Status = request.Status
        };

        if (string.IsNullOrEmpty(tarefa.Nome) || tarefa.Nome.Length > 100)
        {
            throw new ArgumentException("A o nome da tarefa deve possuir entre 1 a 100 caracteres.");
        }

        if (tarefa.Descricao.Length > 500)
        {
            throw new ArgumentException("A tarefa deve possuir no máximo 500 caracteres.");
        }

        if (!Enum.IsDefined(typeof(StatusEnum), tarefa.Status)){
            throw new ArgumentException("O Status informado é inválido.");
        }

        if (!Enum.IsDefined(typeof(PrioridadeEnum), tarefa.Prioridade)){
            throw new ArgumentException("A Prioridade informada é inválida.");
        }

        if (tarefa.DataConclusao < DateTime.Today)
        {
            throw new ArgumentException("A data de conclusão precisa ser maior ou igual a data de hoje");
        }

        TarefaRepository.TarefaRepository.Tarefas.Add(tarefa);
        return tarefa;
    }
}
