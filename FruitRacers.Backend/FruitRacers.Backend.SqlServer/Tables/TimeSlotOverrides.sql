CREATE TABLE [dbo].[TimeSlotOverrides]
(
	[Date] DATE NOT NULL, 
    [TimeSlotId] INT NOT NULL, 
    [Offset] INT NOT NULL, 
    CONSTRAINT [FK_TimeSlotOverrides_TimeSlots] FOREIGN KEY ([TimeSlotId]) REFERENCES [TimeSlots]([TimeSlotId]), 
    CONSTRAINT [PK_TimeSlotOverrides] PRIMARY KEY ([Date], [TimeSlotId])
)
