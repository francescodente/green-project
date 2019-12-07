CREATE TABLE [dbo].[TimeSlots]
(
	[TimeSlotId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Weekday] INT NOT NULL, 
    [StartTime] TIME(0) NOT NULL, 
    [FinishTime] TIME(0) NOT NULL, 
    [SlotCapacity] INT NOT NULL DEFAULT 0
)
