namespace MalawiMeta.Api.UseCases;

public interface IUseCase<in TUseCaseArgs, TUseCaseResponse>
{
    public Task<TUseCaseResponse> ExecuteAsync(TUseCaseArgs? args);
}
