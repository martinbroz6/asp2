using InsuranceCorp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InsCorpDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", () => "OK");

app.MapGet("/person/{id:int}", (int id, InsCorpDbContext db) =>
{
    db.Persons.Find(id);
});

app.MapGet("/person/list", (int start, int take,InsCorpDbContext db) =>
    db.Persons.Skip(start).Take(take)
);

// https://localhost:7114/person/list?start=1000&take=3

app.Run();
