using EBYS.DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EBYS.DataAccesLayer
{
	public static class Extension
	{
		public static void AddDataAccesLayer(this IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptions)
		{
			services.AddDbContext<EBYSContext>(dbContextOptions);

			var repositoryInterfaces=Assembly.GetExecutingAssembly().DefinedTypes.Where(x=>x.IsInterface && x.Name.EndsWith("Repository")  ).ToList();
			var repositoryClasses = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.IsClass && x.Name.EndsWith("Repository") && !x.IsGenericType).ToList();

			foreach (var repositoryInterface in repositoryInterfaces)
			{
				var repositoryClass=repositoryClasses.First(x=>x.Name.EndsWith(repositoryInterface.Name.Substring(1)));

				services.AddScoped(repositoryInterface,repositoryClass);
			}
		}
	}
}
