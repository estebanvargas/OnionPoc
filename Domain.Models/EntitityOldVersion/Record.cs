namespace Domain.Models.EntitityOldVersion
{
    /// <summary>
    /// Have to use properties, can't use accessors otherwise serialization does not work correctly
    /// </summary>
    public class Record : BaseDTO
    {
        public int Id;

        public PublishingSourceEnum PublishingSource;

        public string CallbackUrl;

        public string CallbackParams;

        public RecordStatusEnum RecordStatus = RecordStatusEnum.Active;
    }
}