﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotnetRepositoryPattern {
    
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>{
        
        public ProjectDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("Server=tcp:bradtestserver.database.windows.net,1433;Initial Catalog=bradtestdatabase;Persist Security Info=False;User ID=brad;Password=SQLPass7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ProjectDbContext(optionsBuilder.Options);
        }
    }
}