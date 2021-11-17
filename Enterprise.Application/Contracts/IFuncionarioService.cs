using System;
using System.Threading.Tasks;
using AutoMapper;
using Enterprise.Domain;
using Enterprise.Application.Dtos;
using Enterprise.Persistence.Contracts;
using Enterprise.Application.Contracts;

namespace Enterprise.Application.Contracts
{
    public interface IFuncionarioService
    {
        Task<FuncionarioDto> AddFuncionario(FuncionarioDto model);
        //Task<FuncionarioDto[]> saveFuncionarios(int eventoId, FuncionarioDto[] models);
        Task<FuncionarioDto> UpdateFuncionario(int id, FuncionarioDto model);
        Task<bool> DeleteFuncionario(int deptoId, int funcionarioId);
        Task<FuncionarioDto[]> GetAllFuncionarios();
        Task<FuncionarioDto> GetFuncionarioId(int funcionarioId);
        Task<FuncionarioDto> GetFuncionarioById(int deptoId, int funcionarioId);
        Task<FuncionarioDto[]> GetAllFuncionariosByDepto(int eventoId);
    }
}