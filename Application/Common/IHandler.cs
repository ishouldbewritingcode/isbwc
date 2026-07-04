namespace isbwc.Application.Common;

public interface IHandler<in TRequest, TResponse>
{
	Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}
