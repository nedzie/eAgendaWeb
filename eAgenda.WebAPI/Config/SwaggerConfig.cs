﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;

namespace eAgenda.WebAPI.Config
{
    public static class SwaggerConfig
    {
        public static void ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.MapType(typeof(TimeSpan), () => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eAgenda.WebAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Favor, informe o token [ Padrão: Bearer {token} ]",
                    Name = "Authorization", // Aqui vai o Value do Header
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
