using System.Linq;

namespace DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(SmartMedicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Medications.Any())
            {
                return;   // DB has been seeded
            }


        }
    }
}
