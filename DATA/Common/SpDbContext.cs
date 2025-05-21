using CONTANTS;
using Microsoft.EntityFrameworkCore;

namespace DATA.ModelData
{
    public partial class SpDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(Variable.STRINGCONNECTION,
                    sqlServerOptionsAction: sqlOption =>
                    {
                        sqlOption.EnableRetryOnFailure();
                    });
            }
        }
    }
}
