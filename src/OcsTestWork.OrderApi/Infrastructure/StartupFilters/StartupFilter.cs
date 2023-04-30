﻿namespace OcsTestWork.OrderApi.Infrastructure.StartupFilters;

public class SwaggerStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        };
    }
}