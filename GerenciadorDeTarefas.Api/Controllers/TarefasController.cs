using Azure.Core;
using GerenciadorDeTarefas.Domain.Dtos.Requests;
using GerenciadorDeTarefas.Domain.Dtos.Responses;
using GerenciadorDeTarefas.Domain.Interfaces.Services;
using GerenciadorDeTarefas.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController (ITarefasDomainService tarefasDomainService) : ControllerBase
    {
        [HttpPost("criar-tarefa")]
        [ProducesResponseType(typeof(TarefaResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(TarefaRequestDto request)
        {
            try
            {
                var response = tarefasDomainService.CriarTarefa(request);

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
                var response = tarefasDomainService.AlterarTarefa(id, request);

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
                var response = tarefasDomainService.ExcluirTarefa(id);

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

        [HttpGet("obter-tarefas/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = tarefasDomainService.ObterTarefaPorId(id);

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
                var response = tarefasDomainService.ListarTarefas();

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
    }
}
