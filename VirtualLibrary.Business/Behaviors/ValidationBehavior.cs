﻿
using FluentValidation;
using MediatR;
using VirtualLibrary.Domain.Common;

namespace VirtualLibrary.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count > 0)
            {
                var errors = failures.Select(f => f.ErrorMessage).ToList();
                var resultType = typeof(TResponse);

                var failureResult = typeof(Result<>)
                    .MakeGenericType(resultType.GetGenericArguments()[0])
                    .GetMethod(nameof(Result<object>.Failure), new[] { typeof(List<string>) })
                    .Invoke(null, new object[] { errors });

                return (TResponse)failureResult;
            }

            return await next();
        }
    }

}
