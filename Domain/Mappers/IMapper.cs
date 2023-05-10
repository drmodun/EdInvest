using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public interface IMapper<TEntity, TDTO, TCreate, TUpdate>
    {
        public TDTO ToDTO(TEntity entity);
        public TEntity ToEntity(TCreate request);

        public TEntity ToUpdatedEntity(TUpdate request);

    }
}
