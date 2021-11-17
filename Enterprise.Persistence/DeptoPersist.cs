using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enterprise.Domain;
using Enterprise.Persistence.Data;
using Enterprise.Persistence.Contracts;

namespace Enterprise.Persistence
{
    public class DeptoPersist : IDeptoPersist
    {
        private readonly EnterpriseContext _context;

        public DeptoPersist(EnterpriseContext context)
        {
            _context = context;
        }

        public async Task<Depto[]> GetAllDeptos(bool includeFuncionarios = false)
        {
            IQueryable<Depto> query = _context.Deptos;

            if (includeFuncionarios)
            {
                query = query
                    .Include(e => e.Funcionarios);
            }      
            return await query.ToArrayAsync();
        }

        public async Task<Depto> GetDeptoByNome(string nome, bool includeFuncionarios = false)
        {
            IQueryable<Depto> query = _context.Deptos;
            if(includeFuncionarios)
            {
                query = query
                        .Include(e => e.Funcionarios);
            }
            query = query.AsNoTracking()
                         .Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Depto> GetDeptoBySigla(string sigla, bool includeFuncionarios = false)
        {
            IQueryable<Depto> query = _context.Deptos;
            if(includeFuncionarios)
            {
                query = query
                        .Include(e => e.Funcionarios);
            }

            query = query.AsNoTracking()
                         .Where(e => e.Sigla.ToLower().Contains(sigla.ToLower()));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Depto> GetDeptoById(int id, bool includeFuncionarios = false)
        {
            IQueryable<Depto> query = _context.Deptos;

            if(includeFuncionarios)
            {
                query = query
                        .Include(e => e.Funcionarios);
            }

            query = query.AsNoTracking()
                         .Where(f => f.DeptoId == id);

            return await query.FirstOrDefaultAsync();
        }
        
    }
}