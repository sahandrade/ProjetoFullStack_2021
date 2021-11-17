using System;
using System.Threading.Tasks;
using AutoMapper;
using Enterprise.Domain;
using Enterprise.Application.Dtos;
using Enterprise.Persistence.Contracts;
using Enterprise.Application.Contracts;

namespace Enterprise.Application
{
    public class DeptoService : IDeptoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IDeptoPersist _deptoPersist;
        private readonly IMapper _mapper;

        public DeptoService(IGeralPersist geralPersist, IDeptoPersist deptoPersist, IMapper mapper )
        {
            _geralPersist = geralPersist;
            _deptoPersist = deptoPersist;
            _mapper = mapper;
        }

        public async Task<DeptoDto> AddDeptos(DeptoDto model)
        {
            try
            {
                var depto = _mapper.Map<Depto>(model);

                _geralPersist.Add<Depto>(depto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var deptoRetorno = await _deptoPersist.GetDeptoById(depto.DeptoId, false);

                    return _mapper.Map<DeptoDto>(deptoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeptoDto> UpdateDepto(int deptoId, DeptoDto model)
        {
            try
            {
                var depto = await _deptoPersist.GetDeptoById(deptoId);
                if (depto == null) return null;

                model.DeptoId = depto.DeptoId;

                _mapper.Map(model, depto);

                _geralPersist.Update<Depto>(depto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var deptoRetorno = await _deptoPersist.GetDeptoById(depto.DeptoId);

                    return _mapper.Map<DeptoDto>(deptoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteDepto(int deptoId)
        {
            try
            {
                var depto = await _deptoPersist.GetDeptoById(deptoId);
                if (depto == null) throw new Exception("Depto para delete não encontrado.");

                _geralPersist.Delete<Depto>(depto);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeptoDto[]> GetAllDeptos(bool includeFuncionarios = false)
        {
            try
            {
                var deptos = await _deptoPersist.GetAllDeptos(includeFuncionarios);
                if (deptos == null) return null;

                var resultado = _mapper.Map<DeptoDto[]>(deptos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeptoDto> GetDeptoById(int deptoId, bool includeFuncionarios = false)
        {
            try
            {
                var depto = await _deptoPersist.GetDeptoById(deptoId, includeFuncionarios);
                if (depto == null) return null;

                var resultado = _mapper.Map<DeptoDto>(depto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<DeptoDto> GetDeptoByNome(string nome, bool includeFuncionarios = false)
        {
            try
            {
                var deptos = await _deptoPersist.GetDeptoByNome(nome, includeFuncionarios);
                if (deptos == null) return null;

                var resultado = _mapper.Map<DeptoDto>(deptos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<DeptoDto> GetDeptoBySigla(string sigla, bool includeFuncionarios = false)
        {
            try
            {
                var deptos = await _deptoPersist.GetDeptoBySigla(sigla, includeFuncionarios);
                if (deptos == null) return null;

                var resultado = _mapper.Map<DeptoDto>(deptos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}