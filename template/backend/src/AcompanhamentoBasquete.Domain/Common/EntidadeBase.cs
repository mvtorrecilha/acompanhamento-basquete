namespace AcompanhamentoBasquete.Domain.Common;

public abstract class EntidadeBase
{
    protected EntidadeBase(Guid id)
    {
        Id = id;
    }

    protected EntidadeBase()
    {
    }

    public Guid Id { get; init; }
}