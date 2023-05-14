namespace Shared.Contracts.Responses.Field
{
    public class UpdateFieldResponse
    {
        public GetFieldResponse Field { get; set; }

        public bool Success { get; set; }
    }
}
