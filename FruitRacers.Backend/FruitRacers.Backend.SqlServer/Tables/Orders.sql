CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Notes] NVARCHAR(1000) NULL, 
    [DeliveryDate] DATE NULL, 
    [Timestamp] DATETIME NULL, 
    [OrderState] INT NOT NULL, 
    [TimeSlotId] INT NULL, 
    [UserId] INT NOT NULL, 
    [AddressId] INT NULL, 
    CONSTRAINT [FK_Orders_TimeSlots] FOREIGN KEY ([TimeSlotId]) REFERENCES [TimeSlots]([TimeSlotId]), 
	CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
	CONSTRAINT [FK_Orders_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([AddressId])

)
