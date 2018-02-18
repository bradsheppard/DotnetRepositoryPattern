using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotnetRepositoryPattern.Repositories {
    
    public static class DbContextHelper {
        
        public static void DetachAll(this DbContext dbContext) {
            
            foreach (EntityEntry dbEntityEntry in dbContext.ChangeTracker.Entries().ToList()) {
                if (dbEntityEntry.Entity != null)
                    dbEntityEntry.State = EntityState.Detached;
            }
        }
    }
}