// Program.cs
using LifeManagerBackend.Data;
using LifeManagerBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string not found.");

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseNpgsql(connectionString)
    .Options;

await using var db = new AppDbContext(options);

// Ensure database exists and is up-to-date
await db.Database.MigrateAsync();   // creates DB + runs all migrations

Console.WriteLine("Database ready! Starting your logic...");

// Your playground starts here — no web, no controllers, just pure C#
// Example:
await DemoSomeLogic(db);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

// -----------------------------------------------------------------
static async Task DemoSomeLogic(AppDbContext db)
{
    // This is where you write and test all your backend logic
    Console.WriteLine("Running demo logic...");


    //create a test user
    var UserID = createNewUser();
    var user = new User { Username = "test", Email = "test@example.com" };
    db.Users.Add(user);
    await db.SaveChangesAsync();
    Console.WriteLine($"Created user with Id {user.Id}");
}