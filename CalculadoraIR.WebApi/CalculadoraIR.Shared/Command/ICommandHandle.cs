namespace CalculadoraIR.Shared.Command
{
    public interface ICommandHandle<TInput, TResult> 
        where TInput : ICommandInput
        where TResult : ICommandResult
    {
        TResult Handle(TInput input);
    }
}
