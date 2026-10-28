using Microsoft.Extensions.DependencyInjection;
using Senac.ADS.PPFA.SenacEduca.Repositories;
using Senac.ADS.PPFA.SenacEduca_;

namespace Senac.ADS.PPFA.SenacEduca.WinForms
{
    static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            var MainForm = ServiceProvider.GetRequiredService<Form1>();
            Application.Run(MainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(opt => opt.GetService<SenacEducaContextFactory>()!.CreateDbContext());
            services.AddTransient<Form1>();
        }
    }
}
