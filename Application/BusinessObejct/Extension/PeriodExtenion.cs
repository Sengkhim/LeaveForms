
using Domain.Entites;

namespace Application.BusinessObejct
{
    public static class PeriodExtenion
    {
        public static bool IsValid(this Period period)
        {
            DateTimeOffset? beginning = period.BeginDate ?? DateTimeOffset.MinValue;
            DateTimeOffset? ending = period.EndDate ?? DateTimeOffset.MaxValue;
            return beginning <= ending;
        }

        public static bool IsDatesEquals(this Period period, DateTimeOffset? beginning, DateTimeOffset? ending)
        {
            if (period.IsValid() == false) return false;
            beginning ??= DateTimeOffset.MinValue;
            ending ??= DateTimeOffset.MaxValue;
            DateTimeOffset? periodBeginning = period.BeginDate ?? DateTimeOffset.MinValue;
            DateTimeOffset? periodEnding = period.EndDate ?? DateTimeOffset.MaxValue;
            return periodBeginning == beginning && periodEnding == ending;
        }
        public static bool IsDatesEquals(this Period period, Period other)
        {
            if (other == null) return false;
            if (!period.IsValid() || !other.IsValid()) return false;
            return period.IsDatesEquals(other.BeginDate, other.EndDate);
        }

        public static bool IsCover(this Period period, DateTimeOffset? actingDate)
        {
            if (actingDate == null) return false;
            if (!period.IsValid()) return false;
            DateTimeOffset? beginning = period.BeginDate ?? DateTimeOffset.MinValue;
            DateTimeOffset? ending = period.EndDate ?? DateTimeOffset.MaxValue;
            return beginning <= actingDate && actingDate <= ending;
        }
        public static bool IsCover(this Period period, DateTimeOffset? beginning, DateTimeOffset? ending)
        {
            if (!period.IsValid()) return false;
            beginning ??= DateTimeOffset.MinValue;
            ending ??= DateTimeOffset.MaxValue;
            DateTimeOffset? periodBeginning = period.BeginDate ?? DateTimeOffset.MinValue;
            DateTimeOffset? periodEnding = period.EndDate ?? DateTimeOffset.MaxValue;
            return periodBeginning <= beginning && ending <= periodEnding;
        }
    }
}
