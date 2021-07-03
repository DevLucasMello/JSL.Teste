using JSL.Motorista.Application.Services;
using JSL.Motorista.Application.ViewModels;
using JSL.Viagem.Application.Services;
using JSL.Viagem.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSL.WebApp.API.Controllers
{
    [Route("v1/motorista")]
    public class MotoristaController : ControllerBase
    {
        public readonly IMotoristaAppService _motoristaAppService;
        public readonly IViagemAppService _viagemAppService;

        public MotoristaController(IMotoristaAppService motoristaAppService, IViagemAppService viagemAppService)
        {
            _motoristaAppService = motoristaAppService;
            _viagemAppService = viagemAppService;
        }

        [HttpGet]
        [Route("obterTodos")]        
        public async Task<IEnumerable<MotoristaViewModel>> Get()
        {
            var motoristas = await _motoristaAppService.ObterListaDeMotoristas();
            return motoristas;
        }

        [HttpGet]
        [Route("obterPorId/{id:guid}")]
        public async Task<ActionResult<MotoristaViewModel>> GetById(Guid id)
        {
            var motorista = await _motoristaAppService.ObterPorId(id);

            if (motorista == null) return NotFound("Não foi possível localizar o motorista");

            return motorista;
        }

        [HttpGet]
        [Route("viagens/obterPorMotoristaId/{id:guid}")]
        public async Task<IEnumerable<ViagemViewModel>> GetByMotoristaId(Guid id)
        {
            var viagens = await _viagemAppService.ObterViagensPorMotorista(id);

            if (viagens == null) return (IEnumerable<ViagemViewModel>)NotFound("Não foi possível localizar as viagens do motorista informado");

            return viagens;
        }

        [HttpPost]
        [Route("adicionarMotorista")]        
        public async Task<ActionResult<MotoristaViewModel>> Post(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");
            
            await _motoristaAppService.AdicionarMotorista(motoristaViewModel);

            return motoristaViewModel;
        }

        [HttpPut]
        [Route("atualizarMotorista")]        
        public async Task<ActionResult<MotoristaViewModel>> Put(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var motorista = await _motoristaAppService.ObterPorId(motoristaViewModel.Id);

            if (motorista == null) return NotFound("Não foi possível localizar o motorista");

            await _motoristaAppService.AtualizarMotorista(motoristaViewModel);            

            return motoristaViewModel;
        }

        [HttpDelete]
        [Route("excluirMotorista/{id:guid}")]
        public async Task<ActionResult<MotoristaViewModel>> Delete(Guid id)
        {
            var motorista = await _motoristaAppService.ObterPorId(id);            

            if (motorista == null) return NotFound("Não foi possível localizar o motorista");

            var viagens = await _viagemAppService.ObterViagensPorMotorista(id);            

            if (viagens.Count() != 0)
            {
                return BadRequest("O Motorista possui viagens cadastradas!");
            }

            await _motoristaAppService.ExcluirMotorista(motorista);
            
            return motorista;
        }
    }
}
