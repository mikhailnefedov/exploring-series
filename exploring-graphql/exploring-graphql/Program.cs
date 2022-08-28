using exploring_graphql.Data;
using exploring_graphql.DataLoader;
using exploring_graphql.Sessions;
using exploring_graphql.Speakers;
using exploring_graphql.Tracks;
using exploring_graphql.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddTypeExtension<SpeakerQueries>()
        .AddTypeExtension<SessionQueries>()
        .AddTypeExtension<TrackQueries>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddTypeExtension<SessionMutations>()
        .AddTypeExtension<SpeakerMutations>()
        .AddTypeExtension<TrackMutations>()
    .AddType<SpeakerType>()
    .AddType<AttendeeType>()
    .AddType<SessionType>()
    .AddType<TrackType>()
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>()
    .AddGlobalObjectIdentification();

builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=conferences.db"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
