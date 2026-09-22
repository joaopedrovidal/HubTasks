using HubTasksAplication.Entities;
using HubTasksAplication.UseCase.Tarefa.Atualizar;
using HubTasksAplication.UseCase.Tarefa.Cadastrar;
using HubTasksAplication.UseCase.Tarefa.Excluir;
using HubTasksAplication.UseCase.Tarefa.Listar;
using HubTasksAplication.UseCase.Tarefa.ObterPorId;
using HubTasksCommunication.Requests;
using HubTasksCommunication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HubTasksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TaskController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult CadastrarTarefa(RequestCadastrarTarefaJson request)
    {
        try
        {
            var useCase = new CadastrarTarefaUseCase();
            var response = useCase.Execute(request);


            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseTarefaJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult ObterTarefas()
    {
        try
        {
            var useCase = new ListarTarefasUseCase();

            var response = useCase.Execute();

            if (response.Any())
            {
                return Ok(response);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<ResponseErrorJson>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ObterTarefaPorId([FromRoute] Guid id)
    {
        try
        {
            var useCase = new ObterTarefaPorIdUseCase();
            var response = useCase.Execute(id);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<ResponseErrorJson>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Atualizar([FromRoute] Guid id, [FromBody] RequestCadastrarTarefaJson request)
    {
        try
        {
            var useCase = new AtualizarTarefaUseCase();
            var response = useCase.Execute(id, request);

            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(List<ResponseErrorJson>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Excluir([FromRoute] Guid id)
    {
        try
        {
            var useCase = new ExcluirTarefaUseCase();

            useCase.Executar(id);

            return NoContent();
        }
        catch(ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}
