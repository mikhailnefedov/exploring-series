using Microsoft.EntityFrameworkCore;

namespace exploring_graphql.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor)
            where TDbContext : DbContext
        {
            return descriptor.UseScopedService<TDbContext>(
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext());
        }

        public static IObjectFieldDescriptor UseUpperCase(
            this IObjectFieldDescriptor descriptor)
        {
            return descriptor.Use(next => async context =>
            {
                await next(context);

                if (context.Result is string s)
                {
                    context.Result = s.ToUpperInvariant();
                }
            });
        }
    }

}
