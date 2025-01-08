using BulkyWeb.Models;

namespace BulkyWeb.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		ICategoryRepository CategoryRepository { get; }

		Task SaveChangesAsync();
	}
}
