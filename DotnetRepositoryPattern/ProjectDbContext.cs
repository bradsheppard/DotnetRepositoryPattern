using Microsoft.EntityFrameworkCore;

namespace DotnetRepositoryPattern {
    
    public class ProjectDbContext : DbContext {
        
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) { }
        
        
        public DbSet<SampleModel> SampleModels { get; set; }
    }
}