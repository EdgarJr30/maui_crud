using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UNAD.Entity;

namespace UNAD.DAL;

// All the code in this file is included in all platforms.
public class Context : DbContext
{
    public Context()
    {
        if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.MacCatalyst)
        {
            SQLitePCL.Batteries_V2.Init();
        }

        this.Database.EnsureCreated();
        this.Database.Migrate();
    }

    public DbSet<clsPaisesBE> clsPaisesBE { set; get; }
    public DbSet<clsProvinciasBE> clsProvinciasBE { set; get; }
    public DbSet<clsCiudadesBE> clsCiudadesBE { set; get; }


    protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
    {
        modelBuilder.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "unad.db3")}");
    }

}

