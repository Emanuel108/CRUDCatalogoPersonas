using Ardalis.Specification;

namespace CRUDCatalogoPersonas.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
