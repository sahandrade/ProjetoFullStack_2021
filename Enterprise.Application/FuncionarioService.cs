using System;
using System.Threading.Tasks;
using AutoMapper;
using Enterprise.Domain;
using Enterprise.Application.Dtos;
using Enterprise.Persistence.Contracts;
using Enterprise.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Enterprise.Application
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IFuncionarioPersist _funcionarioPersist;
        private readonly IMapper _mapper;

        public FuncionarioService(IGeralPersist geralPersist, IFuncionarioPersist funcionarioPersist, IMapper mapper )
        {
            _geralPersist = geralPersist;
            _funcionarioPersist = funcionarioPersist;
            _mapper = mapper;
        }

        // public async Task<FuncionarioDto[]> saveFuncionarios(int deptoId, FuncionarioDto[] models)
        // {
        //     try
        //     {
        //         var funcionarios = await _funcionarioPersist.GetAllFuncionariosByDepto(deptoId);
        //         if (funcionarios == null) return null;

        //         foreach (var model in models)
        //         {
        //             if (model.FuncionarioId == 0)
        //                 await AddFuncionario(model);
        //             }
        //             else
        //             {
        //                 var funcionario = funcionarios.FirstOrDefault(f => f.FuncionarioId == model.FuncionarioId);
        //                 model.DeptoId = deptoId;

        //                 _mapper.Map(model, funcionario);

        //                 _geralPersist.Update<Funcionario>(funcionario);

        //                 await _geralPersist.SaveChangesAsync();
        //             }
        //         }

        //         var funcionarioRetorno = await _funcionarioPersist.GetAllFuncionariosByDepto(deptoId);

        //         return _mapper.Map<FuncionarioDto[]>(funcionarioRetorno);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        // }


         public async Task<FuncionarioDto> AddFuncionario(FuncionarioDto model)
        {
            try
            {
                var funcionario = _mapper.Map<Funcionario>(model);

                _geralPersist.Add<Funcionario>(funcionario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var funcionarioRetorno = await _funcionarioPersist.GetFuncionarioId(funcionario.FuncionarioId);

                    return _mapper.Map<FuncionarioDto>(funcionarioRetorno); 
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncionarioDto> UpdateFuncionario(int id, FuncionarioDto model)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioId(id);
                if (funcionario == null) return null;

                model.FuncionarioId = funcionario.FuncionarioId;

                _mapper.Map(model, funcionario);

                _geralPersist.Update<Funcionario>(funcionario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var funcionarioRetorno = await _funcionarioPersist.GetFuncionarioId(funcionario.FuncionarioId);

                    return _mapper.Map<FuncionarioDto>(funcionarioRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFuncionario(int deptoId, int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioById(deptoId, funcionarioId);
                if (funcionario == null) throw new Exception("Funcionario para delete não encontrado.");

                _geralPersist.Delete<Funcionario>(funcionario);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncionarioDto[]> GetAllFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioPersist.GetAllFuncionarios();
                if (funcionarios == null) return null;

                var resultado = _mapper.Map<FuncionarioDto[]>(funcionarios);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncionarioDto> GetFuncionarioById(int deptoId, int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioById(deptoId, funcionarioId);
                if (funcionario == null) return null;

                var resultado = _mapper.Map<FuncionarioDto>(funcionario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<FuncionarioDto> GetFuncionarioId(int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioId(funcionarioId);
                if (funcionario == null) return null;

                var resultado = _mapper.Map<FuncionarioDto>(funcionario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


         public async Task<FuncionarioDto[]> GetAllFuncionariosByDepto(int deptoId)
        {
            try
            {
                var Funcionarios = await _funcionarioPersist.GetAllFuncionariosByDepto(deptoId);
                if (Funcionarios == null) return null;

                var resultado = _mapper.Map<FuncionarioDto[]>(Funcionarios);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}