using exploring_graphql.Data;
using exploring_graphql.DataLoader;
using exploring_graphql.Operations;
using exploring_graphql.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<SpeakerType>()
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>();

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=conferences.db"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
