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

CREATE TRIGGER Employees_Insert
ON Employees
AFTER INSERT
AS
UPDATE Employees SET OperationCount = 0
WHERE Id = (SELECT Id FROM INSERTED)
GO

CREATE TRIGGER Visits_Insert
ON Registrations
AFTER INSERT
AS
UPDATE Employees SET OperationCount = OperationCount + 1
WHERE Id = (SELECT EmployeeId FROM INSERTED)
GO

CREATE TRIGGER Opinions_Insert
ON Opinions
AFTER INSERT
AS
UPDATE Clinics SET Usermark = 
(SELECT AVG(CAST(Mark AS DECIMAL(3,1))) FROM Opinions WHERE ClinicId = (SELECT ClinicId FROM INSERTED)) 
WHERE Id = (SELECT ClinicId FROM INSERTED)
GO



