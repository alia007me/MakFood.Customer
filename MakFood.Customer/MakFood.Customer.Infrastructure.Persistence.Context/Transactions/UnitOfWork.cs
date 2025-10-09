namespace MakFood.Customer.Infrastructure.Persistence.Context.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Commit(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
