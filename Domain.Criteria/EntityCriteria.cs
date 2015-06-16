using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
