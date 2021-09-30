CREATE DATABASE ClinicData
GO

USE ClinicData

CREATE TABLE Localizations (
	Id INT IDENTITY(1,1) NOT NULL,
	Country NVARCHAR(255) NOT NULL,
	City NVARCHAR(255) NOT NULL,
	Street NVARCHAR(255) NOT NULL,
	House TINYINT NOT NULL,
	Flat TINYINT NOT NULL,
	PostalCode NVARCHAR(255) NOT NULL,
	CONSTRAINT PK__Localizations_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Localizations_House CHECK (House > 0),
	CONSTRAINT CK__Localizations_Flat CHECK (Flat > 0),
);
GO

CREATE TABLE Drugs (
	Id INT IDENTITY(1,1),
	Name NVARCHAR(255) NOT NULL,
	Percentage TINYINT,
	ProductionDate DATETIME NOT NULL,
	ExpireDate DATETIME NOT NULL,
	IsPsychotropic BIT NOT NULL,
	AvailableAmount TINYINT NOT NULL,
	Unit NVARCHAR(10) NOT NULL,
	CONSTRAINT PK__Drugs_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Drugs_Percentage CHECK (Percentage > 0),
	CONSTRAINT CK__Drugs_AvailableAmount CHECK (AvailableAmount >= 0),
);
GO

CREATE TABLE Tools (
	Id INT IDENTITY(1,1),
	Name NVARCHAR(255) NOT NULL,
	AvailableCount TINYINT NOT NULL,
	ProductionDate DATETIME NOT NULL,
	ExpireDate DATETIME NOT NULL,
	Description NVARCHAR(255),
	CONSTRAINT PK__Tools_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Tools_AvailableCount CHECK (AvailableCount >= 0)
);
GO

CREATE TABLE Data (
	Id INT IDENTITY(1,1),
	Name NVARCHAR(255) NOT NULL,
	Surname NVARCHAR(255) NOT NULL,
	BirthDate DATETIME NOT NULL,
	Gender NVARCHAR(1),
	Phone NVARCHAR(255),
	Email NVARCHAR(255),
	CONSTRAINT PK__Data_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Data_Gender CHECK (Gender IN ('M', 'K'))
);
GO

CREATE TABLE Operations (
	Id INT IDENTITY(1,1),
	Name NVARCHAR(255) NOT NULL,
	Type NVARCHAR(255) NOT NULL,
	IsAnesthesia BIT NOT NULL,
	ToolId INT,
	DrugId INT,
	Description NVARCHAR(255),
	CONSTRAINT PK__Operations_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK__Operations_ToolId FOREIGN KEY (ToolId) REFERENCES Tools(Id) ON DELETE SET NULL,
	CONSTRAINT FK__Operations_DrugId FOREIGN KEY (DrugId) REFERENCES Drugs(Id) ON DELETE SET NULL
);
GO

CREATE TABLE Producents (
	Id INT IDENTITY(1,1),
	Name NVARCHAR(255) NOT NULL,
	OpenDate DATETIME NOT NULL,
	LocalizationId INT NOT NULL,
	DataId INT NOT NULL,
	Email NVARCHAR(255),
	CONSTRAINT PK__Producents_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ__Producents_LocalizationID UNIQUE (LocalizationId),
	CONSTRAINT FK__Producents_LocalizationID FOREIGN KEY (LocalizationId) REFERENCES Localizations(Id) ON DELETE CASCADE,
	CONSTRAINT UQ__Producents_DataId UNIQUE (DataId),
	CONSTRAINT FK__Producents_DataId FOREIGN KEY (DataId) REFERENCES Data(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Costs (
	Id INT IDENTITY(1,1),
	ProducentId INT NOT NULL,
	DrugId INT NOT NULL,
	MinPrice INT,
	MaxPrice INT,
	TransportDays TINYINT,
	CONSTRAINT PK__Costs_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Costs_MinPrice CHECK (MinPrice >= 0),
	CONSTRAINT CK__Costs_MaxPrice CHECK (MaxPrice >= 0),
	CONSTRAINT CK__Costs_TransportDays CHECK (TransportDays > 0),
	CONSTRAINT FK__Costs_ProducentId FOREIGN KEY (ProducentId) REFERENCES Producents(Id) ON DELETE CASCADE,
	CONSTRAINT FK__Costs_DrugId FOREIGN KEY (DrugId) REFERENCES Drugs(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Patients (
	Id INT IDENTITY(1,1),
	DataId INT NOT NULL,
	OperationId INT NOT NULL,
	Priority TINYINT,
	OperationDate DATETIME NOT NULL,
	Description NVARCHAR(255),
	CONSTRAINT PK__Patients_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Patients_Priority CHECK (Priority >= 0),
	CONSTRAINT UQ__Patients_DataId UNIQUE (DataId),
	CONSTRAINT FK__Patients_DataId FOREIGN KEY (DataId) REFERENCES Data(Id) ON DELETE CASCADE,
	CONSTRAINT FK__Patients_OperationId FOREIGN KEY (OperationId) REFERENCES Operations(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Clinics (
	Id INT IDENTITY(1,1),
	Name NVARCHAR(255) NOT NULL,
	OpenDate DATETIME NOT NULL,
	IsPrivate BIT NOT NULL,
	EmployeeId INT,
	LocalizationId INT NOT NULL,
	Usermark DECIMAL(2,1) NOT NULL,
	CONSTRAINT PK__Clinics_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ__Clinics_LocalizationId UNIQUE (LocalizationId),
	CONSTRAINT CK__Clinics_Usermark CHECK (Usermark >= 0),
	CONSTRAINT FK__Clinics_LocalizationId FOREIGN KEY (LocalizationId) REFERENCES Localizations(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Employees (
	Id INT IDENTITY(1,1),
	OperationCount TINYINT,
	OperationId INT NOT NULL,
	ClinicId INT,
	DataId INT NOT NULL,
	Rank NVARCHAR(255) NOT NULL,
	Cost INT NOT NULL,
	CONSTRAINT PK__Employees_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Employees_Cost CHECK (Cost > 0),
	CONSTRAINT UQ__Employees_DataId UNIQUE (DataId),
	CONSTRAINT FK__Employees_OperationId FOREIGN KEY (OperationId) REFERENCES Operations(Id) ON DELETE CASCADE
);
GO

ALTER TABLE Clinics 
ADD CONSTRAINT FK__Clinics_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ON DELETE SET NULL
GO

ALTER TABLE Employees  
ADD CONSTRAINT FK__Employees_ClinicId FOREIGN KEY (ClinicId) REFERENCES Clinics(Id) ON DELETE SET NULL
GO

CREATE TABLE Opinions (
	Id INT IDENTITY(1,1),
	ClinicId INT NOT NULL,
	DataId INT NOT NULL,
	Mark TINYINT NOT NULL,
	CONSTRAINT PK__Opinions_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT CK__Opinions_Mark CHECK (Mark > 0),
	CONSTRAINT FK__Opinions_ClinicId FOREIGN KEY (ClinicId) REFERENCES Clinics(Id) ON DELETE CASCADE,
	CONSTRAINT FK__Opinions_DataId FOREIGN KEY (DataId) REFERENCES Data(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Registrations (
	Id INT IDENTITY(1,1),
	Date DATETIME NOT NULL,
	Time NVARCHAR(255) NOT NULL,
	EmployeeId INT NOT NULL,
	PatientId INT NOT NULL,
	CONSTRAINT PK__Registrations_Id PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT FK__Registrations_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ON DELETE CASCADE,
	CONSTRAINT FK__Registrations_PatientId FOREIGN KEY (PatientId ) REFERENCES Patients(Id) ON DELETE NO ACTION
);
GO

--DataRow - nie ma sensu - bo nie b?dzie dost?pu do tej bazy

CREATE VIEW ClinicRow AS
SELECT c.Id 'Id', c.Name 'Nazwa', c.OpenDate 'Data otwarcia', c.IsPrivate 'Prywatna', c.Usermark 'Ocena', l.Country + '/' + l.City + '/' + CAST(l.House as NVARCHAR) 'Lokalizacja', d.Name + ' ' + d.Surname 'Kierownik'
FROM Clinics c
JOIN Localizations l ON (c.LocalizationId = l.Id) 
LEFT JOIN Employees e ON (c.EmployeeId = e.Id)
LEFT JOIN Data d ON (e.DataId = d.Id)
GO

CREATE VIEW OperationRow AS
SELECT o.Id 'Id', o.Name 'Nazwa', o.Type 'Typ', o.IsAnesthesia 'Znieczulenie', t.Name 'Narzedzie', d.Name 'Lek'
FROM Operations o
JOIN Tools t ON (o.ToolId = t.Id)
JOIN Drugs d ON (o.DrugId = d.Id)
GO

CREATE VIEW PatientRow AS
SELECT p.Id 'Id', d.Name + ' ' + d.Surname 'Pacjent', o.Name 'Operacja', p.OperationDate 'Planowana data', p.Priority 'Priorytet' 
FROM Patients p
JOIN Operations o ON (p.OperationId = o.Id)
JOIN Data d ON (p.DataId = d.Id)
GO

CREATE VIEW RegistrationRow AS
SELECT r.Id 'Id',
(SELECT Name + ' ' + Surname FROM Data WHERE Id = (SELECT DataId FROM Patients p WHERE p.Id = r.PatientId)) 'Pacjent',
(SELECT Name + ' ' + Surname FROM Data WHERE Id = (SELECT DataId FROM Employees e WHERE e.Id = r.EmployeeId)) 'Lekarz',
r.Date 'Data operacji', r.Time 'Czas rozpoczecia' 
FROM Registrations r
GO

CREATE VIEW EmployeeRow AS
SELECT e.Id 'Id', d.Name + ' ' + d.Surname 'Lekarz', c.Name 'Miejsce pracy', o.Name 'Specjalizacja', e.Cost 'Koszt operacji', e.Rank 'Stanowisko'
FROM Employees e
JOIN Operations o ON (e.OperationId = o.Id)
JOIN Data d ON (e.DataId = d.Id)
LEFT JOIN Clinics c ON (e.ClinicId = c.Id)
GO

CREATE VIEW CostRow AS
SELECT c.Id 'Id', d.Name 'Nazwa leku', c.MinPrice 'Minimalna cena', c.MaxPrice 'Maksymalna cena', c.TransportDays 'Czas dostawy dni', p.Name 'Producent'
FROM Costs c
JOIN Drugs d ON (c.DrugId = d.Id)
JOIN Producents p ON (c.ProducentId = p.Id)
GO

CREATE VIEW ProducentRow AS
SELECT p.Id 'Id', p.Name 'Nazwa producenta', p.Email 'Email', l.Country + '/' + l.City + '/' + CAST(l.House as NVARCHAR) 'Siedziba firmy', d.Name + ' ' + d.Surname 'Kierownik'
FROM Producents p
JOIN Localizations l ON (p.LocalizationId = l.Id)
JOIN Data d ON (p.DataId = d.Id)
GO

CREATE VIEW OpinionRow AS
SELECT o.Id 'Id', o.Mark 'Ocena', d.Name + ' ' + d.Surname 'Wystawiajacy', c.Name 'Przychodnia'
FROM Opinions o
JOIN Data d ON (o.DataId = d.Id)
JOIN Clinics c ON (o.ClinicId = c.Id)
GO

CREATE VIEW LocalizationRow AS
SELECT l.Id 'Id', l.Country + '/' + l.City + '/' + l.Street + '/' + CAST(l.House as NVARCHAR) + '/' + CAST(l.Flat as NVARCHAR) + ' -> ' + l.PostalCode 'Adres'
FROM Localizations l
GO

CREATE VIEW ToolRow AS
SELECT t.Id 'Id', t.Name 'Nazwa', t.AvailableCount 'Ilosc dostepna', t.ProductionDate 'Data produkcji', t.ExpireDate 'Data waznosci', t.Description 'Opis'
FROM Tools t
GO

CREATE VIEW DrugRow AS
SELECT d.Id 'Id', d.Name 'Nazwa', d.Percentage 'Dawka', d.ProductionDate 'Data produkcji', d.ExpireDate 'Data waznosci',
d.IsPsychotropic 'Psychotropowe', d.AvailableAmount 'Ilosc dostepna', d.Unit 'Jednostka'
FROM Drugs d
GO


--Rozszerzalnosc istniejacych modulow
ALTER TABLE Registrations
ADD Status NVARCHAR(20)
GO

ALTER VIEW RegistrationRow AS
SELECT r.Id 'Id',
(SELECT Name + ' ' + Surname FROM Data WHERE Id = (SELECT DataId FROM Patients p WHERE p.Id = r.PatientId)) 'Pacjent',
(SELECT Name + ' ' + Surname FROM Data WHERE Id = (SELECT DataId FROM Employees e WHERE e.Id = r.EmployeeId)) 'Lekarz',
r.Date 'Data operacji', r.Time 'Czas rozpoczecia',
r.Status 'Status'
FROM Registrations r
GO

CREATE TABLE Orders (
	Id INT IDENTITY(1,1),
	DrugId INT NOT NULL,
	ClinicId INT NOT NULL,
	ProducentId INT NOT NULL,
	Amount TINYINT,
	Unit NVARCHAR(20),
	CONSTRAINT PK__Orders_Id PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT FK__Orders_DrugId FOREIGN KEY (DrugId) REFERENCES Drugs(Id) ON DELETE CASCADE,
	CONSTRAINT FK__Orders_ClinicId FOREIGN KEY (ClinicId) REFERENCES Clinics(Id) ON DELETE CASCADE,
	CONSTRAINT FK__Orders_ProducentId FOREIGN KEY (ProducentId) REFERENCES Producents(Id) ON DELETE NO ACTION
);

GO

CREATE VIEW OrderRow AS
SELECT o.Id 'Id', o.Amount 'Ilosc', o.Unit 'Jednostka', c.Name 'Przychodnia', d.Name 'Lek', p.Name 'Producent'
FROM Orders o
JOIN Clinics c ON o.ClinicId = c.Id
JOIN Drugs d ON o.DrugId = d.Id
JOIN Producents p ON o.ProducentId = p.Id
GO

ALTER TABLE Tools 
	ADD ProducentId INT
GO

ALTER TABLE Tools
	ADD CONSTRAINT FK__Tools_ProducentId FOREIGN KEY (ProducentId) REFERENCES Producents(Id) ON DELETE SET NULL
GO