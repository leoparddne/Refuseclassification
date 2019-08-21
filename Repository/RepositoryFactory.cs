using Microsoft.Extensions.DependencyInjection;
using Repository.IRepository;
using System;
using System.Reflection;

namespace Repository
{
    public class RepositoryFactory
    {
        private static RepositoryFactory data;

        public static RepositoryFactory Instance = data ?? (data=new RepositoryFactory());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="types"></param>
        public void DIRepositories(IServiceCollection service, Type types)
        {
            //TODO 根据type类型加载不同仓储
            //注册仓储
            foreach (Type type in Assembly.Load(GetType().Assembly.GetName()).GetTypes())
            {
                if (typeof(IRepository.IRepository).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    var interfaces = type.GetInterfaces();
                    foreach (var i in interfaces)
                    {
                        if (!i.IsGenericType && i != typeof(IRepository.IRepository) && i.Name != typeof(IRepository.IRepository).Name)
                        {
                            service.AddScoped(i, type);
                        }
                    }
                }
            }
        }
    }
}
