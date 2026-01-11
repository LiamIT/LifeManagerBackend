using System;
using LifeManagerBackend.Models;
using LifeManagerBackend;
using LifeManagerBackend.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LifeManagerBackend;

public class BaseClass
{
    public async Task<User> CreateNewUser(string pstrUsername, string pstrEmail, AppDbContext db)
    {
        //Takes in Username and Email and creates a user account if:
        // 1. The username doesnt exist
        // 2. The Email isnt in use
        // otherwise it grabs the user account ID and returns it.
        // Will always return a user ID
        User user;
        var ExistingUser = await db.tblusers
        .FirstOrDefaultAsync(p => p.fstrusername == pstrUsername && p.fstremail == pstrEmail);

        if(ExistingUser is not null)
        {
            return ExistingUser;
            
        }
        user = new User { fstrusername = pstrUsername, fstremail = pstrEmail, fintid = CreateNewUserID(db: db), fdtmcreated = DateTime.Now};
        db.tblusers.Add(user);
        await db.SaveChangesAsync();
        return user;
    }
    public int CreateNewUserID(AppDbContext db)
    {
        var lstUsers = db.tblusers.ToList();
        var HighestId = lstUsers.Any() ? lstUsers.Max(x => x.fintid) : 0;

        return HighestId++;
    }
    public void AddItem()
    {
        //Take in Item details and insert it into the database
    }
    public void CompleteItem()
    {
        //Take in Item key and mark it as complete in the Database
    }
    public void DeleteItem()
    {
        //Take in Item key and delete from the database
    }
}
