using JSL.Viagem.Application.Services;
using JSL.Viagem.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.WebApp.API.Controllers
{
    [Route("v1/viagem")]
    public class ViagemController : ControllerBase
    {
        public readonly IViagemAppService _viagemAppService;

        public ViagemController(IViagemAppService viagemAppService)
        {
            _viagemAppService = viagemAppService;
        }

        [HttpGet]
        [Route("obterTodos")]
        public async Task<IEnumerable<ViagemViewModel>> Get()
        {
            var viagens = await _viagemAppService.ObterListaDeViagens();
            return viagens;
        }

        [HttpGet]
        [Route("obterPorId/{id:guid}")]
        public async Task<ActionResult<ViagemViewModel>> GetById(Guid id)
        {
            var viagem = await _viagemAppService.ObterPorId(id);

            if (viagem == null) return NotFound("Não foi possível localizar a viagem");

            return viagem;
        }

        [HttpPost]
        [Route("adicionarViagem")]
        public async Task<ActionResult<ViagemViewModel>> Post(ViagemViewModel viagemViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            await _viagemAppService.AdicionarViagem(viagemViewModel);

            return viagemViewModel;
        }

        [HttpPut]
        [Route("atualizarViagem")]
        public async Task<ActionResult<ViagemViewModel>> Put(ViagemViewModel viagemViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("O formulário possui dados inválidos");

            var viagem = await _viagemAppService.ObterPorId(viagemViewModel.Id);

            if (viagem == null) return BadRequest("Não foi possível localizar a viagem");

            await _viagemAppService.AtualizarViagem(viagemViewModel);

            return viagemViewModel;
        }

        [HttpDelete]
        [Route("excluirMotorista/{id:guid}")]
        public async Task<ActionResult<ViagemViewModel>> Delete(Guid id)
        {
            var viagem = await _viagemAppService.ObterPorId(id);

            if (viagem == null) return NotFound("Não foi possível localizar a viagem");

            await _viagemAppService.ExcluirViagem(viagem);

            return viagem;
        }
    }
}
