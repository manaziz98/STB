
using Core.Entities;

namespace DAL
{
    public interface IDbContextFactory
    {
        ArchiveDbContext DbContext { get; }
    }
}
