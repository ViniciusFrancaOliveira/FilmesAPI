using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using System;
using System.Linq;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null) return null;

            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return sessaoDto;

        }

        internal ReadSessaoDto AdicionaSessao(CreateSessaoDto createDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(createDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }
    }
}
