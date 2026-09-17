using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GamingStoreApi.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=ep-muddy-tree-b1ia3y7u-pooler.c-5.eu-central-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Sp6HPMR2jkyG;SSL Mode=Require;Channel Binding=Require;Pooling=true"
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}