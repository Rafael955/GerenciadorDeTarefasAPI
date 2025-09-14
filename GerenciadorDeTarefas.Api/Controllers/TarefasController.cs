using GerenciadorDeTarefas.Application.Dtos.Request;
using GerenciadorDeTarefas.Application.Dtos.Response;
using GerenciadorDeTarefas.Application.Interfaces.Services;
using GerenciadorDeTarefas.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;

namespace GerenciadorDeTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController(ITarefasAppService tarefasAppService) : ControllerBase
    {
        [HttpPost("criar-tarefa")]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(TarefaRequestDto request)
        {
            try
            {
                var response = tarefasAppService.CriarTarefa(request);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpPut("alterar-tarefa/{id}")]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status200OK)]
        public IActionResult Put(int id, TarefaRequestDto request)
        {
            try
            {
                var response = tarefasAppService.AlterarTarefa(id, request);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpDelete("excluir-tarefa/{id}")]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = tarefasAppService.ExcluirTarefa(id);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpGet("obter-tarefa/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = tarefasAppService.ObterTarefaPorId(id);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpGet("listar-tarefas")]
        public IActionResult GetAll()
        {
            try
            {
                var response = tarefasAppService.ListarTarefas();

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpGet("listar-status-tarefas")]
        public IActionResult GetAllStatusTasks()
        {
            var response = Enum.GetValues(typeof(StatusTarefa))
                .Cast<StatusTarefa>()
                .Select(status => new StatusTarefaResponseDto
                {
                    Codigo = (int)status,
                    Descricao = status.GetType()
                    .GetField(status.ToString())?
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description ?? status.ToString()
                })
                .ToList();

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
