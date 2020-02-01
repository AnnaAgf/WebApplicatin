using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WebApplicatin.Infrastructure
{
    //Здесь создается метод расширения для типа IApplicationBuilder. 
    //И этот метод встраивает компонент TokenMiddleware в конвейер обработки запроса. 
    //Как правило, подобные методы возвращают объект IApplicationBuilder.
    public static class TokenExtensions
    { 
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
