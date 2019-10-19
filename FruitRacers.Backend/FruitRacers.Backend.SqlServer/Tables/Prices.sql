CREATE TABLE [dbo].[Prices]
(
	[Type] NCHAR NOT NULL, 
    [Value] MONEY NOT NULL, 
    [UnitMultiplier] DECIMAL(8, 4) NOT NULL, 
    [Minimum] INT NOT NULL DEFAULT 0, 
    [UnitName] NVARCHAR(5) NOT NULL, 
    [ProductID] INT NOT NULL, 
    CONSTRAINT [FK_Prices_MeasurementUnits] FOREIGN KEY ([UnitName]) REFERENCES [MeasurementUnits]([UnitName]), 
    CONSTRAINT [PK_Prices] PRIMARY KEY ([Type], [ProductID]) 
)
