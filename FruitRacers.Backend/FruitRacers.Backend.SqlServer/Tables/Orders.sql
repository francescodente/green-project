CREATE TABLE [dbo].[Orders]
(
	[OrderID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Notes] NVARCHAR(1000) NULL, 
    [DeliveryDate] DATE NULL, 
    [Timestamp] TIMESTAMP NULL, 
    [OrderStateID] INT NOT NULL, 
    [TimeSlotID] INT NULL, 
    [UserID] INT NOT NULL, 
    [AddressID] INT NULL, 
    CONSTRAINT [FK_Orders_OrderStates] FOREIGN KEY ([OrderStateID]) REFERENCES [OrderStates]([OrderStateID]),
    CONSTRAINT [FK_Orders_TimeSlots] FOREIGN KEY ([TimeSlotID]) REFERENCES [TimeSlots]([TimeSlotID]), 
	CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID]), 
	CONSTRAINT [FK_Orders_Addresses] FOREIGN KEY ([AddressID]) REFERENCES [Addresses]([AddressID])

)
