﻿using System;
using Trintech.Cadency.DataAccess.DataEntities;

namespace Infrastructure.Data.Entities
{
    [Serializable]
    public class Entity : TableWithLongId
    {
        public DateTime CreatedDate { get; set; }
        public int ClosePeriodId { get; set; }
        public int DefinitionId { get; set; }
        public int ParentId { get; set; }
        public int PublishingSourceId { get; set; }
        public int TaskTreeId { get; set; }
        public string CallbackParams { get; set; }
        public string CallbackUrl { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string RecordStatus { get; set; }
        public string RowVersion { get; set; }
    }
}
