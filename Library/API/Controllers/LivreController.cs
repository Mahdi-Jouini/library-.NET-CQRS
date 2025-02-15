using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Commands;
using Domain.Models;
using Domain.DTOs;
using Domain.Queries;
using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public PrixController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllLivres")]
        public IEnumerable<LivreDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Livre>()).Result.Select(l => _mapper.Map<LivreDTO>(l));


        }

        /*[HttpGet("getLivreById")]
        public async Task<LivreDTO> GetLivre(Guid? id)
        {
            var livre = _mediator.Send(new GetByIDGeneric<Livre>(condition: c => c.Id == id)).Result;
            return _mapper.Map<LivreDTO>(livre);
        }*/

        [HttpPost("PostLivre")]
        public async Task<string> AddLivre(Livre livre)
        {

            return await _mediator.Send(new PostGeneric<Livre>(livre));
        }

        [HttpPut("PutLivre")]
        public async Task<string> PutLivre(Livre livre)
        {

            return await _mediator.Send(new PutGeneric<Livre>(livre));
        }

        [HttpDelete("DeleteLivre")]
        public async Task<string> DeleteLivre(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Livre>(id));
        }
    }
}