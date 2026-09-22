using HubTasksAplication.Entities;
using HubTasksAplication.UseCase.Tarefa.ObterPorId;
using HubTasksCommunication.Enums;
using HubTasksCommunication.Requests;
using HubTasksCommunication.Responses;

namespace HubTasksAplication.UseCase.Tarefa.Atualizar;

public class AtualizarTarefaUseCase
{
    public ResponseTarefaJson Execute(Guid id, RequestCadastrarTarefaJson request) {
        var useCase = new ObterTarefaPorIdUseCase();
        var response = useCase.Execute(id);

        response = new ResponseTarefaJson
        {
            Id = response.Id,
            Descricao = request.Descricao,
            DataConclusao = request.DataConclusao,
            Nome = request.Nome,
            Prioridade = request.Prioridade,
            Status = request.Status
        };

        if (string.IsNullOrEmpty(response.Nome) || response.Nome.Length > 100)
        {
            throw new ArgumentException("A o nome da tarefa deve possuir entre 1 a 100 caracteres.");
        }

        if (response.Descricao.Length > 500)
        {
            throw new ArgumentException("A tarefa deve possuir no máximo 500 caracteres.");
        }

        if (!Enum.IsDefined(typeof(StatusEnum), response.Status))
        {
            throw new ArgumentException("O Status informado é inválido.");
        }

        if (!Enum.IsDefined(typeof(PrioridadeEnum), response.Prioridade))
        {
            throw new ArgumentException("A Prioridade informada é inválida.");
        }

        if (response.DataConclusao < DateTime.Today)
        {
            throw new ArgumentException("A data de conclusão precisa ser maior ou igual a data de hoje");
        }

        return response;
    }
}
