using System;
using System.ComponentModel;

namespace Domain.Models.EntitityOldVersion
{
    [Serializable]
    public enum PublishingSourceEnum
    {
        [Description("Partner")]
        Partner=1,

        [Description("Certification")]
        Certification=2,

        [Description("Close")]
        Close=3,

        [Description("Compliance")]
        Compliance=4,

        [Description("Completion")]
        Completion=5
    }
}
