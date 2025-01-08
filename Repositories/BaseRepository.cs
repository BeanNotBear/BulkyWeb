using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var result = await _context.Set<T>().ToListAsync();
			return result;
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			var result = await _context.Set<T>().FindAsync(id);
			return result;
		}

		public T Update(T entity)
		{
			_context.Set<T>().Update(entity);
			return entity;
		}
	}
}
