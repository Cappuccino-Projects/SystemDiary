namespace WebAPI.Extensions
{
    public static class WebApiMiddlewareExceptions
    {
        public static WebApplication UseWebApi(this WebApplication application) 
        {
            application.UseAuthorization();

            if (application.Environment.IsDevelopment()) 
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }

            application.UseHttpsRedirection();

            application.UseRouting();
            application.UseAuthentication();
            application.UseAuthorization();

            application.MapControllers();

            return application;
        }
    }
}
