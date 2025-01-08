using BulkyWeb.Data;
using BulkyWeb.Models;

namespace BulkyWeb.Repositories
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
		}

		public void Test()
		{
			Console.WriteLine("Test OK");
		}
	}
}
