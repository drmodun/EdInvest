using Domain.Mappers;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BaseService<TEntity, TMapper, TReadRepo, TWriteRepo, 
        TCreateRequest, TUpdateRequest, TGetRequest, TGetAllRequest, TId,
        TCreateResponse, TUpdateResponse, TGetResponse, TGetAllResponse, TList, TItem
        > 
        : IBaseService<TEntity, TMapper, TReadRepo> where TEntity : class 
        where TMapper : IMapper<TEntity, TGetResponse, TCreateRequest, TUpdateRequest> 
        where TWriteRepo : IWriteRepo<TEntity, TId>
        where TReadRepo : IReadRepo<TEntity, TId, TGetAllRequest, TList>
        where TCreateRequest : class
        where TUpdateRequest : class
        where TGetRequest : class
        where TGetAllRequest : class
       where TId : struct
        where TList : List<TEntity>
        where TGetResponse : class
        where TGetAllResponse : List<TGetResponse>
    {
        private readonly TMapper _mapper;
        private readonly TReadRepo _readRepo;
        private readonly TWriteRepo _writeRepo;

        public BaseService(TMapper mapper, TReadRepo readRepo, TWriteRepo writeRepo)
        {

            _mapper = mapper;
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }
        public async Task<TGetResponse?> Create(TCreateRequest request, CancellationToken cancellationToken)
        {
            var newEntity = _mapper.ToEntity(request);
            //add validator
            var addAsync = await _writeRepo.AddAsync(newEntity, cancellationToken);
            if (!addAsync)
                return null;
            return _mapper.ToDTO(newEntity);
        }
        public async Task<TGetResponse?> Update(TCreateRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = _mapper.ToEntity(request);
            //add validator
            var addAsync = await _writeRepo.UpdateAsync(updatedEntity, cancellationToken);
            if (!addAsync)
                return null;
            return _mapper.ToDTO(updatedEntity);
        }
        public async Task<bool?> Delete(TId deleteRequest, CancellationToken cancellationToken)
        {
            var deletion = await _writeRepo.DeleteAsync(deleteRequest, cancellationToken);
            if (!deletion) return false;
            return true;
        }
        public async Task<TGetResponse> GetById(TId id)
        {
            var item = await _readRepo.GetById(id);
            if (item == null)
                return null;
            return _mapper.ToDTO(item);
        }
        public async Task<List<TGetResponse>> GetAll(TGetAllRequest options)
        {
            var items = await _readRepo.GetAll(options);
            return items.Select(_mapper.ToDTO).ToList();
        }






    }
}
