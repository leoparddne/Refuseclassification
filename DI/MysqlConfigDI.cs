using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.DbContexts;
using Repository.IRepository;
using Repository.Repository;
using Microsoft.Extensions.Configuration;

namespace DI
{
    public class MysqlConfigDI
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var setting = SettingUtility.Get<CommonSetting>("CommonSetting.json");
            
            //自定义仓储配置注入
            RepositoryFactory.Instance.DIRepositories(services, typeof(IRepositoryBase<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //mysql
            services.AddDbContext<CommonContext>(options => options.UseMySQL(setting.Mysql));
        }
    }
}
