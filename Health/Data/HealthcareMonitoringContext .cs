using Microsoft.EntityFrameworkCore;
using Health.Models;  // Make sure this is correct

namespace HealthcareMonitoring.Data
{
    public class HealthcareMonitoringContext : DbContext
    {
        public HealthcareMonitoringContext(DbContextOptions<HealthcareMonitoringContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<HealthData> HealthData { get; set; }
    }
}
