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
    public class FuncionarioPersist : IFuncionarioPersist
    {
        private readonly EnterpriseContext _context;

        public FuncionarioPersist(EnterpriseContext context)
        {
            _context = context;
        }

        public async Task<Funcionario[]> GetAllFuncionarios()
        {
            IQueryable<Funcionario> query = _context.Funcionarios;      

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioById(int deptoId, int id)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                         .Where(f => f.DeptoId == deptoId
                            && f.FuncionarioId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario[]> GetAllFuncionariosByDepto(int deptoId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;  
                query = query.AsNoTracking()
                            .Where(f=> f.DeptoId == deptoId);

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioId(int id)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                         .Where(f => f.FuncionarioId == id);

            return await query.FirstOrDefaultAsync();
        }
        
    }
}