using Microsoft.EntityFrameworkCore;

namespace BST
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BSTDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            // Do not dare fuck with shit under here. - raine
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetService<BSTDbContext>();
            context!.Database.Migrate();
        }
    }
}