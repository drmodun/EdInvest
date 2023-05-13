﻿namespace Shared.Contracts.Response
{

    public class ValidationFailureResponse
    {
        public IEnumerable<ValidationResponse> Errors { get; init; }
    }

    public class ValidationResponse
    {
        public string PropertyName { get; init; }
        public string Message { get; init; }
    }
}