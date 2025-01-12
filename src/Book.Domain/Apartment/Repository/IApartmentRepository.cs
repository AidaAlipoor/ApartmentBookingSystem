namespace Book.Domain.Apartment.Repository
{
    public interface IApartmentRepository
    {
        Task<Apartment> GetByIdAsync(Guid id , CancellationToken cancellationToken = default);
    }
}
