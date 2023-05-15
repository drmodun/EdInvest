using Shared.Contracts.Requests.Field;
using Shared.Contracts.Responses.Field;
using Shared.Models;

namespace Domain.Mappers
{
    public class FieldMapper
    {

        public GetFieldResponse ToDTO(Field field)
        {
            var response = new GetFieldResponse()
            {
                Id = field.Id,
                Name = field.Name,
            };
            return response;
        }
        public Field ToEntity(CreateFieldRequest request)
        {
            var newField = new Field
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            return newField;
        }
        public Field ToUpdatedEntity(UpdateFieldRequest request)
        {
            var updatedField = new Field
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            return updatedField;
        }
    }
}
