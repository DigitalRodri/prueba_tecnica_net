CREATE TRIGGER [marketParties].[UpdateDateTimeRetailer]
ON [marketParties].[Retailer]
FOR UPDATE 
AS 
BEGIN 
    IF NOT UPDATE(UTCUpdatedDateTime) 
        UPDATE [marketParties].[Retailer] SET UTCUpdatedDateTime = GETDATE() 
        WHERE ReId IN (SELECT ReId FROM inserted);
END 
GO