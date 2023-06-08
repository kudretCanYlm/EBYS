using EBYS.BusinessLayer.Mapper;
using EBYS.DataAccesLayer.UnitOfWork;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EBYS.BusinessLayer
{
	public static class Extension
	{
		public static void AddBusinessLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(DtoAndEntityProfile));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			var serviceInterfaces = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.IsInterface && x.Name.EndsWith("Service")).ToList();
			var serviceClasses = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.IsClass && x.Name.EndsWith("Manager")).ToList();

			foreach (var serviceInterface in serviceInterfaces)
			{
				var serviceClass = serviceClasses.Find(x => x.Name.StartsWith(serviceInterface.Name.Substring(1).Split("Service")[0]));

				services.AddScoped(serviceInterface, serviceClass);

			}

		}

	}
}
