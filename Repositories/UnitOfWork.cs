using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Repositories;


namespace BulkyWeb.Repositories
{
	public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
	{
		private ICategoryRepository? _categoryRepository;
		public ICategoryRepository CategoryRepository
		{
			get
			{
				// if null then create a new instance
				_categoryRepository ??= new CategoryRepository(context);
				return _categoryRepository;
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
