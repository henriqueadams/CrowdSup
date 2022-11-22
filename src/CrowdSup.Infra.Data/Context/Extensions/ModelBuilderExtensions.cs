using Microsoft.EntityFrameworkCore;

namespace CrowdSup.Infra.Data.Context.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RegisterSequence(this ModelBuilder modelBuilder, string sequenceName)
        {
            modelBuilder
                .HasSequence<long>(sequenceName)
                .StartsAt(1)
                .IncrementsBy(1);

            return modelBuilder;
        }
    }
}