using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enterprise.Domain;

namespace Enterprise.Persistence.Contracts
{
    public interface IDeptoPersist
    {
        Task<Depto[]> GetAllDeptos(bool includeFuncionarios = false);
        Task<Depto> GetDeptoByNome(string nome, bool includeFuncionarios = false);
        Task<Depto> GetDeptoBySigla(string sigla, bool includeFuncionarios = false);
        Task<Depto> GetDeptoById(int id, bool includeFuncionarios = false);
    }
}