using System;

namespace Domain.Criteria
{
    public class EntityCriteria
    {
        public string UserName;
        public int ClosePeriodId;
        public int CloseDayMapId;
        public DateTime? PeriodEndDate;

        public EntityCriteria()
        {
            UserName = String.Empty;
            ClosePeriodId = -1;
            CloseDayMapId = -1;
            PeriodEndDate = null;
        }
    }
}
