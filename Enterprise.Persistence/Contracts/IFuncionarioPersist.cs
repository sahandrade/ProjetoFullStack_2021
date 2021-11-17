using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enterprise.Domain;

namespace Enterprise.Persistence.Contracts
{
    public interface IFuncionarioPersist
    {
        Task<Funcionario[]> GetAllFuncionarios();
        Task<Funcionario> GetFuncionarioById(int deptoId, int id);
        Task<Funcionario[]> GetAllFuncionariosByDepto(int deptoId);
        Task<Funcionario> GetFuncionarioId(int id);
    }
}