CREATE TABLE [dbo].[TimeSlotOverrides]
(
	[Date] DATE NOT NULL, 
    [TimeSlotID] INT NOT NULL, 
    [Offset] INT NOT NULL, 
    CONSTRAINT [FK_TimeSlotOverrides_TimeSlots] FOREIGN KEY ([TimeSlotID]) REFERENCES [TimeSlots]([TimeSlotID]), 
    CONSTRAINT [PK_TimeSlotOverrides] PRIMARY KEY ([Date], [TimeSlotID])
)
