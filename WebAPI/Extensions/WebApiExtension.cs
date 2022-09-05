namespace WebAPI.Extensions
{
    public static class WebApiExtension
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services) 
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
