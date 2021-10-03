CREATE TRIGGER Orders_Insert
ON Orders
AFTER INSERT
AS
UPDATE Drugs 
SET AvailableAmount = AvailableAmount + (SELECT Amount FROM inserted)
WHERE Drugs.Id = (SELECT DrugId FROM inserted) AND Drugs.Unit = (SELECT Unit FROM inserted)
GO

CREATE TRIGGER OrdersTools_Insert
ON OrdersTools
AFTER INSERT
AS
UPDATE Tools
SET AvailableCount = AvailableCount + (SELECT Amount FROM inserted)
WHERE Tools.Id = (SELECT ToolId FROM inserted)
GO

