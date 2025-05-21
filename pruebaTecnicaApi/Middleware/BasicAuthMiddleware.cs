using System.Net.Http.Headers;
using System.Text;
using DTO.Common;
using NEGOCIO.Interfaces;

namespace pruebaTecnicaApi.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISesionService userService)
        {
            try
            {
                var endpoint = context.GetEndpoint();
                if (endpoint?.Metadata?.GetMetadata<Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute>() != null)
                {
                    await _next(context);
                    return;
                }
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];
                HttpResponseDto response = await userService.Login(username, password);
                if (response.Status)
                {
                    context.Items["User"] = response.Data;
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { message = "Unauthorized" });
                    return;
                }
            }
            catch (FormatException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = "Invalid authentication header" });
                return;
            }
            catch (ArgumentNullException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = "Invalid authentication header" });
                return;
            }
            catch (IndexOutOfRangeException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = "Invalid authentication header" });
                return;
            }
            catch (InvalidOperationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = "Invalid authentication header" });
                return;
            }
            catch (ArgumentException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = "Invalid authentication header" });
                return;
            }
            await _next(context);
        }
    }
}
