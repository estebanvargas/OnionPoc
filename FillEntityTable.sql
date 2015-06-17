
DECLARE @IdNumber INT
SET @IdNumber = 151458
DECLARE @father INT
SET @father = 151447
DECLARE @rowQuantity INT
SET @rowQuantity = 20
DECLARE @count INT
SET @count = 1

WHILE @count <= @rowQuantity

	BEGIN
		insert into entity (Id,Name,ClosePeriodId,ParentId,DefinitionId,PublishingSourceId,CallbackUrl,CallbackParams,RecordStatus,CreatedDate,RowVersion,Number,TaskTreeId)
		values
		(@IdNumber, 'Test Row Number' + Convert(varchar,@IdNumber), 1279,@father,1926,3,null,null,'Active',getdate(),default,'E04_605_1000',0)

		SET @count = @count +1;
		SET @IdNumber = @IdNumber +1;
	END

--@rowQuantity: Quantity of rows you wish to insert.
--@rowNumber: Last id inserted plus one.
--@father: father row for the new rows being inserted.
--@count: Quantity of rows flag, starts always from one.