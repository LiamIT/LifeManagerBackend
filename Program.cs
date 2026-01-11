// Program.cs
using LifeManagerBackend;
using LifeManagerBackend.Data;
using LifeManagerBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string not found.");

// (debug logging removed)

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
    BaseClass mb = new();

    Console.WriteLine("Please Enter Your desired Username");
    var strUsername = Console.ReadLine();

    Console.WriteLine("Please Enter your Email");
    var strEmail = Console.ReadLine();

    if(strUsername.Length < 7)
        throw new Exception("Username is too short");
    if(!strEmail.Contains('@'))
        throw new Exception("Not a valid email");

    //create a test user
    var User = mb.CreateNewUser(pstrUsername: strUsername, 
                                pstrEmail: strEmail,
                                db: db);


}