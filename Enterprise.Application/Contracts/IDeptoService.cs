using System;
using System.Threading.Tasks;
using AutoMapper;
using Enterprise.Domain;
using Enterprise.Application.Dtos;
using Enterprise.Persistence.Contracts;
using Enterprise.Application.Contracts;

namespace Enterprise.Application.Contracts
{
    public interface IDeptoService
    {
        Task<DeptoDto> AddDeptos(DeptoDto model);
        Task<DeptoDto> UpdateDepto(int deptoId, DeptoDto model);
        Task<bool> DeleteDepto(int deptoId);
        Task<DeptoDto[]> GetAllDeptos(bool includeFuncionarios = false);
        Task<DeptoDto> GetDeptoById(int deptoId, bool includeFuncionarios = false);
        Task<DeptoDto> GetDeptoByNome(string nome, bool includeFuncionarios = false);
        Task<DeptoDto> GetDeptoBySigla(string sigla, bool includeFuncionarios = false);
    }
}