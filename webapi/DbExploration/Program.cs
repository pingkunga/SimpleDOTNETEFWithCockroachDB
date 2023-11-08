using DbExploration.Data;
using DbExploration.DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//https://stackoverflow.com/questions/62917136/addentityframework-was-called-on-the-service-provider-but-useinternalservic
// builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDbContext>(opt =>
//         opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection")));


builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Welcome to Notes API!");

// Create Note
app.MapPost("/notes/", async(NoteDTO n, ApiDbContext db)=> {
    db.Notes.Add(n);
    await db.SaveChangesAsync();

    return Results.Created($"/notes/{n.Id}", n);
});

// Read Note by id
app.MapGet("/notes/{id:int}", async(int id, ApiDbContext db)=> 
{
    return await db.Notes.FindAsync(id)
            is NoteDTO n
                ? Results.Ok(n)
                : Results.NotFound();
});

// Read all Notes
app.MapGet("/notes", async (ApiDbContext db) => await db.Notes.ToListAsync());

// Update a Note by id
app.MapPut("/notes/{id:int}", async(int id, NoteDTO n, ApiDbContext db)=>
{
    if (n.Id != id)
    {
        return Results.BadRequest();
    }

    var note = await db.Notes.FindAsync(id);
    
    if (note is null) return Results.NotFound();

    //found, so update with incoming note n.
    note.Title = n.Title;
    note.Content = n.Content;
    await db.SaveChangesAsync();
    return Results.Ok(note);
});

// Delete a Note by id
app.MapDelete("/notes/{id:int}", async(int id, ApiDbContext db)=>{

    var note = await db.Notes.FindAsync(id);
    if (note is not null){
        db.Notes.Remove(note);
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
