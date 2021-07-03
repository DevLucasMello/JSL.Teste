using JSL.Motorista.Application.Services;
using JSL.Motorista.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.WebApp.API.Controllers
{
    [Route("v1/motorista")]
    public class MotoristaController : ControllerBase
    {
        public readonly IMotoristaAppService _motoristaAppService;

        public MotoristaController(IMotoristaAppService motoristaAppService)
        {
            _motoristaAppService = motoristaAppService;
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

            if (motorista == null) return NotFound();

            return motorista;
        }

        [HttpPost]
        [Route("adicionarMotorista")]        
        public async Task<ActionResult<MotoristaViewModel>> Post(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            await _motoristaAppService.AdicionarMotorista(motoristaViewModel);

            return motoristaViewModel;
        }

        [HttpPut]
        [Route("atualizarMotorista")]        
        public async Task<ActionResult<MotoristaViewModel>> Put(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var motorista = await _motoristaAppService.ObterPorId(motoristaViewModel.Id);

            if (motorista == null) return BadRequest();

            await _motoristaAppService.AtualizarMotorista(motoristaViewModel);            

            return motoristaViewModel;
        }

        [HttpDelete]
        [Route("excluirMotorista/{id:guid}")]
        public async Task<ActionResult<MotoristaViewModel>> Delete(Guid id)
        {
            var motorista = await _motoristaAppService.ObterPorId(id);            

            if (motorista == null) return NotFound();

            await _motoristaAppService.ExcluirMotorista(motorista);
            
            return motorista;
        }
    }
}
