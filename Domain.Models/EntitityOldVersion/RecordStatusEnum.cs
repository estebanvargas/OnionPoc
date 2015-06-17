using System;
using System.ComponentModel;

namespace Domain.Models.EntitityOldVersion
{
    [Serializable]
    public enum RecordStatusEnum
    {
        [Description("Active")]
        Active=1,

        [Description("Delete")]
        Deleted=2,

        [Description("Archived")]
        Archived=3
    }
}
