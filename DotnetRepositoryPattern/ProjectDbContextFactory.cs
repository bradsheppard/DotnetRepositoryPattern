using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotnetRepositoryPattern {
    
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>{
        
        public ProjectDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("{connection_string}");

            return new ProjectDbContext(optionsBuilder.Options);
        }
    }
}