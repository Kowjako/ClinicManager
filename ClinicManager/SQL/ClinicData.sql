DBCC CHECKIDENT ('Clinics', RESEED, 1)  -- wyzerowanie autoinkrementowanego ID
DBCC CHECKIDENT ('Costs', RESEED, 1)
DBCC CHECKIDENT ('Data', RESEED, 1)
DBCC CHECKIDENT ('Drugs', RESEED, 1)
DBCC CHECKIDENT ('Employees', RESEED, 1)
DBCC CHECKIDENT ('Localizations', RESEED, 1)
DBCC CHECKIDENT ('Operations', RESEED, 1)
DBCC CHECKIDENT ('Opinions', RESEED, 1)
DBCC CHECKIDENT ('Patients', RESEED, 1)
DBCC CHECKIDENT ('Producents', RESEED, 1)
DBCC CHECKIDENT ('Registrations', RESEED, 1)
DBCC CHECKIDENT ('Tools', RESEED, 1)

SET IDENTITY_INSERT Localizations ON
GO
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (1, 'Bulgaria', 'Svoge', 'Muir', 19, 26, '2287');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (2, 'France', 'Nancy', 'Tony', 54, 56, '54021');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (3, 'Philippines', 'Llanera', 'High Crossing', 89, 30, '3126');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (4, 'Angola', 'Mbanza Congo', 'Bellgrove', 47, 61, '11292');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (5, 'Croatia', 'Gračec', 'Talisman', 39, 17, '10370');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (6, 'China', 'Doushan', 'Stuart', 71, 99, '11-234');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (7, 'France', 'Vernon', 'Mccormick', 95, 24, '27204');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (8, 'Ireland', 'Castlebellingham', 'Spaight', 74, 12, 'Y34');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (9, 'Canada', 'Nakusp', 'Shopko', 11, 2, 'H9A');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (10, 'Russia', 'Salavat', 'Briar Crest', 87, 13, '453259');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (11, 'Poland', 'Lutowiska', 'Lawn', 78, 2, '38-713');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (12, 'China', 'Didian', 'Knutson', 43, 12, '56789');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (13, 'Mexico', 'San Francisco', 'Macpherson', 59, 32, '46175');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (14, 'China', 'Baihe', 'Brickson Park', 7, 18, 'AB9123');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (15, 'Portugal', 'Outeiro', 'Susan', 85, 86, '4540-379');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (16, 'China', 'Gaoyi', 'Homewood', 57, 96, 'B12345');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (17, 'Canada', 'Iqaluit', 'Reinke', 95, 100, 'K6K');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (18, 'Indonesia', 'Krajan Karangwage', 'Corry', 14, 75, 'XX1234');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (19, 'Brazil', 'Senador Canedo', 'Village', 21, 30, '75250-000');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (20, 'France', 'Le Havre', 'Basil', 72, 14, '76059');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (21, 'Bolivia', 'Guayaramerín', 'Westerfield', 66, 46, 'BC1234');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (22, 'Indonesia', 'Paritjunus', 'Claremont', 68, 75, '12444');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (23, 'Indonesia', 'Busalangga', 'Merchant', 49, 44, '77777');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (24, 'Costa Rica', 'Alajuela', 'Ryan', 68, 19, '20101');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (25, 'Indonesia', 'Siderejo', 'Hoard', 27, 86, '77-88');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (26, 'Argentina', 'Arraga', 'Russell', 16, 86, '4206');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (27, 'Poland', 'Pieńsk', 'Fairview', 52, 21, '59-930');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (28, 'Ukraine', 'Nyzhni Petrivtsi', 'Vidon', 50, 2, '255-101');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (29, 'Kazakhstan', 'Karatau', 'Morningstar', 99, 18, '791-201');
INSERT INTO Localizations (id, Country, City, Street, House, Flat, PostalCode) VALUES (30, 'Hungary', 'Pécs', 'Grayhawk', 93, 78, '7631');
SET IDENTITY_INSERT Localizations OFF
GO

SET IDENTITY_INSERT Drugs ON
GO
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (1, 'Apis Aconitum', 26, '04/02/2020', '03/02/2021', 0, 79, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (2, 'Veal', 59, '08/07/2020', '04/04/2021', 0, 29, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (3, 'Diazepam', 32, '12/04/2020', '08/11/2021', 0, 57, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (4, 'Lyrica', 86, '07/21/2021', '12/07/2020', 0, 48, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (5, 'Ketorolac Tromethamine', 60, '12/23/2019', '06/08/2021', 1, 85, 'krem');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (6, 'Bupropion Hydrochloride', 46, '08/30/2019', '09/11/2021', 0, 84, 'krem');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (7, 'Pain Relief Aspirin', 56, '07/05/2019', '10/05/2020', 1, 68, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (8, 'Spironolactone', 34, '01/26/2020', '03/29/2021', 0, 67, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (9, 'MK Alcohol Swabstick Sterile', 16, '08/30/2020', '04/29/2021', 0, 28, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (10, 'BBCREAM', 41, '07/18/2021', '11/12/2020', 1, 85, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (11, 'Sertraline Hydrochloride', 83, '04/21/2020', '12/13/2020', 0, 56, 'butelka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (12, 'Olay Acne Control Face Wash', 89, '10/27/2020', '02/10/2021', 1, 37, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (13, 'Virazole', 46, '01/10/2020', '07/11/2021', 0, 90, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (14, 'IOPE SUPER VITAL', 1, '08/22/2019', '11/20/2020', 1, 97, 'butelka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (15, 'Denta 5000 Plus', 59, '08/11/2019', '05/26/2021', 1, 99, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (16, 'HAND AND NATURE SANITIZER', 97, '09/15/2019', '04/10/2021', 0, 81, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (17, 'Isosorbide Sublingual', 55, '08/14/2021', '05/29/2021', 1, 50, 'krem');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (18, 'Vitamin C Daily Moisturizer', 52, '12/06/2020', '01/25/2021', 1, 8, 'krem');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (19, 'Neutrogena Healthy Skin Face', 54, '07/08/2020', '06/03/2021', 1, 95, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (20, 'PERFECTION LUMIERE', 72, '10/27/2020', '08/16/2021', 0, 27, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (21, 'Doxycycline Hyclate', 29, '09/05/2021', '11/10/2020', 1, 33, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (22, 'Lovastatin', 91, '03/19/2021', '04/16/2021', 1, 17, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (23, 'Amoxicillin', 18, '06/08/2021', '08/24/2021', 0, 4, 'opakowanie');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (24, 'Cough', 81, '03/21/2021', '07/06/2021', 1, 43, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (25, 'tizanidine', 10, '08/18/2019', '10/29/2020', 1, 14, 'butelka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (26, 'Morphine Sulfate', 24, '11/13/2019', '03/02/2021', 1, 88, 'butelka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (27, 'Count Down', 90, '01/04/2021', '01/10/2021', 1, 3, 'tabletka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (28, 'Potassium Chloride in Dextrose', 62, '07/06/2019', '01/10/2021', 1, 24, 'krem');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (29, 'Hydralazine Hydrochloride', 78, '02/25/2021', '08/01/2021', 1, 16, 'butelka');
insert into Drugs (id, Name, Percentage, ProductionDate, ExpireDate, IsPsychotropic, AvailableAmount, Unit) values (30, 'Laura Mercier Tinted Moisturizer SPF 20 BISQUE', 9, '12/11/2019', '03/22/2021', 1, 36, 'opakowanie');
SET IDENTITY_INSERT Drugs OFF
GO

SET IDENTITY_INSERT Tools ON
GO
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (1, 'Koncentrator', 48, '04/16/2021', '09/05/2021', 'Quisque ut erat.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (2, 'Autoklaw', 77, '09/08/2020', '01/23/2021', 'Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (3, 'Generator tlenu', 95, '02/27/2021', '03/19/2021', 'Ut tellus.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (4, 'Asystor medyczny', 67, '08/21/2021', '07/12/2021', 'Etiam faucibus cursus urna.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (5, 'Koszetka', 61, '08/26/2019', '06/20/2021', 'Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (6, 'Ssak medyczny', 78, '06/20/2020', '03/13/2021', 'Sed accumsan felis.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (7, 'Audiometr', 48, '10/24/2020', '12/30/2020', 'Vivamus tortor.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (8, 'Negatoskop', 29, '10/10/2020', '11/03/2020', 'Nam tristique tortor eu pede.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (9, 'Palestezjometr', 4, '08/22/2021', '04/08/2021', 'Duis aliquam convallis nunc.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (10, 'Pas brzuszny', 45, '06/15/2020', '03/27/2021', 'In quis justo.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (11, 'Pinceta', 59, '02/09/2020', '03/31/2021', 'Nullam sit amet turpis elementum ligula vehicula consequat.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (12, 'Pessarium', 30, '04/14/2021', '01/17/2021', 'Vivamus vestibulum sagittis sapien.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (13, 'Glukometr', 68, '02/29/2020', '12/09/2020', 'Vivamus vel nulla eget eros elementum pellentesque.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (14, 'Respimat', 7, '03/10/2021', '05/15/2021', 'Cras pellentesque volutpat dui.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (15, 'Rurka intubacyjna', 64, '11/25/2019', '11/11/2020', 'Morbi non quam nec dui luctus rutrum.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (16, 'Rurka krtaniowa', 57, '09/30/2020', '04/05/2021', 'Vestibulum ac est lacinia nisi venenatis tristique.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (17, 'Rurka tracheotomijna', 56, '04/13/2020', '04/27/2021', 'Etiam faucibus cursus urna.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (18, 'Spirometr', 1, '04/20/2021', '09/14/2021', 'Duis mattis egestas metus.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (19, 'Stetoskop', 91, '08/23/2019', '11/05/2020', 'Sed vel enim sit amet nunc viverra dapibus.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (20, 'Strzykawka', 26, '08/07/2019', '01/03/2021', 'Aliquam sit amet diam in magna bibendum imperdiet.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (21, 'Tupfer', 33, '07/26/2020', '06/02/2021', 'Etiam vel augue.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (22, 'Talerze amputacyjne', 11, '11/05/2020', '03/17/2021', 'Nulla nisl.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (23, 'Unguator', 15, '12/02/2020', '03/07/2021', 'Mauris sit amet eros.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (24, 'Komora dekompresyjna', 6, '05/04/2021', '06/12/2021', 'Quisque id justo sit amet sapien dignissim vestibulum.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (25, 'Kleszczyki chirurgiczne', 72, '05/03/2021', '05/13/2021', 'Nulla nisl.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (26, 'Keratometr', 47, '08/25/2019', '09/07/2021', 'Donec ut mauris eget massa tempor convallis.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (27, 'Kaniula tętnicza', 50, '08/22/2021', '12/16/2020', 'In eleifend quam a odio.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (28, 'Irygator', 81, '11/04/2020', '09/22/2020', 'Maecenas tincidunt lacus at velit.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (29, 'Lampa Wooda', 21, '09/01/2019', '11/14/2020', 'Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue.');
insert into Tools (id, Name, AvailableCount, ProductionDate, ExpireDate, Description) values (30, 'Maska krtaniowa', 77, '01/19/2020', '10/27/2020', 'Aenean fermentum.');
SET IDENTITY_INSERT Tools OFF
GO

SET IDENTITY_INSERT Data ON
GO
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (1, 'Neile', 'Makepeace', '05/13/1992', 'M', '651-532-8042', 'nmakepeace0@ning.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (2, 'Tabby', 'Vasyaev', '12/24/1957', 'M', '215-774-4621', 'tvasyaev1@nyu.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (3, 'Cointon', 'Custance', '04/22/1972', 'M', '312-160-3925', 'ccustance2@issuu.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (4, 'Alexa', 'Searson', '12/01/1951', 'K', '760-262-5270', 'asearson3@nytimes.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (5, 'Sheila', 'Falconer', '11/20/1969', 'K', '825-846-6700', 'sfalconer4@behance.net');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (6, 'Geno', 'Holbarrow', '01/22/1978', 'M', '764-689-1152', 'gholbarrow5@tiny.cc');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (7, 'Teirtza', 'Dudbridge', '10/21/1971', 'K', '848-561-9218', 'tdudbridge6@sun.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (8, 'Audie', 'Mair', '07/14/1972', 'K', '531-678-2317', 'amair7@fda.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (9, 'Gisela', 'Ebbutt', '04/25/1999', 'K', '116-387-8086', 'gebbutt8@yelp.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (10, 'Marys', 'Maypowder', '05/04/1969', 'K', '187-568-4756', 'mmaypowder9@buzzfeed.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (11, 'Merrie', 'McCloy', '04/21/1972', 'K', '400-233-1809', 'mmccloya@networkadvertising.org');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (12, 'Teressa', 'Plose', '10/18/1975', 'K', '704-613-5087', 'tploseb@apple.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (13, 'Courtnay', 'Darragh', '04/17/1969', 'M', '306-183-0965', 'cdarraghc@yale.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (14, 'Bonnie', 'Selkirk', '12/28/1953', 'M', '124-828-7923', 'bselkirkd@4shared.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (15, 'Enrico', 'Volette', '04/29/1956', 'M', '697-434-9638', 'evolettee@jigsy.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (16, 'Nicky', 'Lardge', '10/16/1954', 'K', '877-483-8988', 'nlardgef@cbslocal.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (17, 'Keely', 'Hekkert', '05/04/1962', 'M', '176-362-4335', 'khekkertg@imageshack.us');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (18, 'Anthony', 'Ashbridge', '08/08/1952', 'K', '743-755-2237', 'aashbridgeh@webs.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (19, 'Junina', 'Winwood', '05/04/1987', 'K', '803-197-2839', 'jwinwoodi@hao123.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (20, 'Kennan', 'Schiementz', '07/07/1981', 'M', '574-685-2475', 'kschiementzj@icio.us');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (21, 'Dee', 'Impett', '05/22/1982', 'M', '701-500-5978', 'dimpettk@independent.co.uk');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (22, 'Kerwin', 'Molineaux', '09/02/1981', 'M', '633-857-2738', 'kmolineauxl@senate.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (23, 'Florette', 'Rubinfeld', '08/15/1989', 'K', '997-414-9650', 'frubinfeldm@spotify.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (24, 'Jarred', 'Obbard', '03/17/1953', 'M', '412-260-7875', 'jobbardn@engadget.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (25, 'Agata', 'Davenhill', '05/23/1985', 'K', '819-604-4128', 'adavenhillo@prlog.org');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (26, 'Casandra', 'Braksper', '05/27/1972', 'K', '310-144-8429', 'cbraksperp@unblog.fr');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (27, 'Alfonso', 'Conachy', '02/08/1982', 'M', '779-640-1764', 'aconachyq@google.com.hk');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (28, 'Evvie', 'Chalker', '09/10/1981', 'M', '183-130-3129', 'echalkerr@photobucket.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (29, 'Minor', 'Jagson', '01/27/1971', 'M', '758-470-2800', 'mjagsons@ted.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (30, 'Zachary', 'Kemery', '01/10/1976', 'M', '538-965-4121', 'zkemeryt@psu.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (31, 'Margeaux', 'Hugnet', '7/13/1992', 'K', '264-926-4217', 'mhugnet0@nationalgeographic.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (32, 'Roldan', 'Drinkel', '5/3/1995', 'M', '803-254-3353', 'rdrinkel1@linkedin.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (33, 'Kellyann', 'Kilgrove', '8/22/1965', 'K', '579-542-1622', 'kkilgrove2@yahoo.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (34, 'Muffin', 'Rosnau', '4/16/1961', 'M', '881-969-8669', 'mrosnau3@marriott.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (35, 'Mechelle', 'Urquhart', '12/4/1989', 'K', '431-947-2050', 'murquhart4@prnewswire.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (36, 'Rozanne', 'Oleksiak', '11/29/1985', 'K', '264-288-4713', 'roleksiak5@bravesites.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (37, 'Katharyn', 'Matveichev', '5/8/1983', 'K', '593-850-4478', 'kmatveichev6@ed.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (38, 'Belinda', 'Claris', '11/14/1966', 'K', '477-511-0633', 'bclaris7@vistaprint.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (39, 'Pippo', 'Laxen', '10/3/1986', 'M', '419-258-1394', 'plaxen8@chicagotribune.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (40, 'Launce', 'Klausen', '7/16/1952', 'M', '580-447-3533', 'lklausen9@walmart.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (41, 'Clemmie', 'Lie', '12/4/1963', 'M', '377-190-2831', 'cliea@google.fr');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (42, 'Demeter', 'Brodeau', '12/19/1993', 'K', '709-224-0811', 'dbrodeaub@intel.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (43, 'Kalie', 'Eiler', '9/21/1967', 'K', '825-327-9150', 'keilerc@tiny.cc');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (44, 'Arni', 'Potts', '5/7/1994', 'M', '776-823-2361', 'apottsd@purevolume.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (45, 'Joyan', 'Avramovitz', '7/30/1988', 'K', '813-627-3381', 'javramovitze@miibeian.gov.cn');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (46, 'Jeddy', 'Surman', '10/21/1986', 'M', '277-299-4446', 'jsurmanf@disqus.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (47, 'Ana', 'Skiplorne', '6/10/1964', 'K', '342-925-9377', 'askiplorneg@smugmug.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (48, 'Merrel', 'Schubert', '10/25/1955', 'M', '628-443-5583', 'mschuberth@miitbeian.gov.cn');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (49, 'Ericha', 'Raigatt', '10/3/1984', 'K', '566-716-5083', 'eraigatti@forbes.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (50, 'Vina', 'Pressdee', '6/12/1972', 'K', '363-190-9170', 'vpressdeej@biblegateway.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (51, 'Arlen', 'Weale', '5/21/1957', 'M', '813-389-3389', 'awealek@whitehouse.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (52, 'Meridith', 'Normadell', '1/31/1987', 'K', '861-110-0184', 'mnormadelll@4shared.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (53, 'Heath', 'Kenewell', '12/9/1983', 'M', '107-766-0706', 'hkenewellm@instagram.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (54, 'Carolann', 'Jaher', '11/30/1952', 'K', '121-447-6145', 'cjahern@e-recht24.de');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (55, 'Ingunna', 'Maltster', '7/10/1960', 'K', '586-443-2417', 'imaltstero@oaic.gov.au');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (56, 'Raymund', 'Matschke', '10/10/1990', 'M', '403-839-8748', 'rmatschkep@whitehouse.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (57, 'Lutero', 'Sprull', '5/5/1966', 'M', '396-169-5920', 'lsprullq@utexas.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (58, 'Wileen', 'Crisford', '11/16/1959', 'K', '382-454-5972', 'wcrisfordr@sun.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (59, 'Zabrina', 'Vescovo', '9/5/1967', 'K', '670-905-2614', 'zvescovos@delicious.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (60, 'Arlyne', 'Savins', '6/28/1952', 'K', '946-312-7005', 'asavinst@mozilla.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (61, 'Adora', 'Greenlees', '9/18/1975', 'K', '775-488-7009', 'agreenleesu@nifty.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (62, 'Caye', 'O''Beirne', '5/6/1979', 'K', '105-569-6368', 'cobeirnev@berkeley.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (63, 'Tyler', 'Horick', '2/8/1994', 'M', '548-743-9526', 'thorickw@shop-pro.jp');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (64, 'Kaia', 'Todeo', '7/6/1993', 'K', '921-505-5315', 'ktodeox@arizona.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (65, 'Dodie', 'Arpur', '1/21/1953', 'K', '513-709-7473', 'darpury@nyu.edu');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (66, 'Grove', 'Paramor', '8/13/1981', 'M', '853-521-1472', 'gparamorz@parallels.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (67, 'Letta', 'Mattusov', '1/8/1996', 'K', '815-744-8623', 'lmattusov10@goo.gl');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (68, 'Tito', 'Falla', '7/7/1979', 'M', '687-123-5821', 'tfalla11@theatlantic.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (69, 'Jerrine', 'Ferrari', '4/28/1968', 'K', '611-710-1777', 'jferrari12@github.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (70, 'Sylvester', 'Ravenscroft', '8/2/1955', 'M', '492-977-6723', 'sravenscroft13@samsung.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (71, 'Boigie', 'Grancher', '8/3/1981', 'M', '420-906-6975', 'bgrancher14@xrea.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (72, 'Analise', 'de Savery', '2/25/1980', 'K', '664-553-8586', 'adesavery15@sphinn.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (73, 'Dominga', 'Santora', '8/27/1984', 'K', '574-301-9219', 'dsantora16@epa.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (74, 'Alyosha', 'Darlasson', '4/15/1998', 'M', '848-984-1292', 'adarlasson17@spiegel.de');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (75, 'Elenore', 'Brammar', '12/5/1971', 'K', '262-943-4835', 'ebrammar18@skyrock.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (76, 'Adrea', 'Gasnell', '8/27/1963', 'K', '909-580-3100', 'agasnell19@army.mil');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (77, 'Edith', 'Claye', '7/7/1977', 'K', '774-765-5985', 'eclaye1a@dot.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (78, 'Hartley', 'Cropper', '12/19/1966', 'M', '750-438-8245', 'hcropper1b@zimbio.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (79, 'Leslie', 'Gatiss', '4/19/1996', 'K', '161-603-9571', 'lgatiss1c@over-blog.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (80, 'Jen', 'Ondrich', '10/29/1952', 'K', '172-529-2545', 'jondrich1d@deviantart.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (81, 'Dasya', 'Castanos', '10/3/1971', 'K', '748-106-4246', 'dcastanos1e@ebay.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (82, 'Abbey', 'Hainey', '1/19/1991', 'K', '758-619-6238', 'ahainey1f@163.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (83, 'Lorene', 'Hayles', '12/30/1991', 'K', '304-919-2769', 'lhayles1g@bloomberg.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (84, 'Ansley', 'Linton', '9/4/1953', 'K', '466-287-7487', 'alinton1h@thetimes.co.uk');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (85, 'Gray', 'Cluckie', '8/3/1953', 'M', '442-678-2690', 'gcluckie1i@shareasale.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (86, 'Adel', 'McInility', '7/11/1962', 'K', '767-532-6236', 'amcinility1j@mediafire.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (87, 'Shelley', 'Szapiro', '1/21/1974', 'K', '909-502-2435', 'sszapiro1k@marriott.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (88, 'Winne', 'Danilewicz', '8/28/1982', 'K', '519-856-6906', 'wdanilewicz1l@github.io');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (89, 'Aindrea', 'Gimert', '12/24/1966', 'K', '345-317-9359', 'agimert1m@t.co');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (90, 'Beatrisa', 'Phaup', '7/26/1963', 'K', '435-235-9343', 'bphaup1n@cdc.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (91, 'Mack', 'Sisnett', '2/6/1994', 'M', '926-979-1676', 'msisnett1o@alibaba.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (92, 'Myrtie', 'Vaines', '7/16/1999', 'K', '426-211-6633', 'mvaines1p@alexa.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (93, 'Catharina', 'Ripping', '4/20/1954', 'K', '321-666-0603', 'cripping1q@japanpost.jp');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (94, 'Shandeigh', 'Jimmison', '3/28/1967', 'K', '713-294-9964', 'sjimmison1r@army.mil');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (95, 'Vin', 'Hunnaball', '3/3/1974', 'M', '129-308-2363', 'vhunnaball1s@state.tx.us');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (96, 'Jeffy', 'Whitbread', '1/20/1963', 'M', '548-939-1517', 'jwhitbread1t@technorati.com');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (97, 'Silvain', 'Stoller', '8/31/1979', 'M', '780-610-5954', 'sstoller1u@plala.or.jp');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (98, 'Alard', 'Kettley', '1/7/1977', 'M', '925-599-2391', 'akettley1v@house.gov');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (99, 'Wynny', 'Peaple', '7/22/1971', 'K', '971-922-2650', 'wpeaple1w@spiegel.de');
insert into Data (id, Name, Surname, BirthDate, Gender, Phone, Email) values (100, 'Tamqrah', 'Ivankovic', '2/5/1951', 'K', '399-473-5900', 'tivankovic1x@nps.gov');
SET IDENTITY_INSERT Data OFF
GO

SET IDENTITY_INSERT Producents ON
GO
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (1, 'Bryant Ranch Prepack', '06/20/1968', 1, 1, 'aalcott0@dmoz.org');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (2, 'TIME CAP LABS', '05/03/1954', 2, 2, 'lnajafian1@wired.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (3, 'CVS Pharmacy', '06/24/1972', 3, 3, 'crewbottom2@reddit.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (4, 'Allergy Laboratories, Inc.', '12/26/1968', 4, 4, 'lshew3@hubpages.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (5, 'Pfizer Laboratories Div Pfizer Inc', '08/25/1990', 5, 5, 'atanti4@hugedomains.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (6, 'International Labs, Inc.', '03/06/1954', 6, 6, 'agerrans5@bluehost.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (7, 'DOLGENCORP, LLC', '08/31/1957',7, 7, 'gkigelman6@flavors.me');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (8, 'Lupin Pharmaceuticals, Inc.', '03/24/1974',8, 8, 'fcantle7@mapy.cz');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (9, 'Rebel Distributors Corp', '09/12/1973', 9, 9, 'nsutterfield8@oakley.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (10, 'The Hain Celestial Group, Inc.', '04/29/1999', 10, 10, 'opiatti9@sbwire.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (11, 'Indiana Botanic Gardens', '06/22/1968', 11, 11, 'aginnallya@deviantart.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (12, 'Allermed Laboratories, Inc.', '10/11/1969', 12, 12, 'rserchwellb@mtv.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (13, 'Ascend Laboratories, LLC', '12/11/1957', 13, 13, 'gmanginc@businesswire.com');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (14, 'AstraZeneca Pharmaceuticals LP', '04/04/1975', 14, 14, 'kwhyardd@g.co');
insert into Producents (id, Name, OpenDate, LocalizationId, DataId, Email) values (15, 'Rite Aid Corporation', '12/19/1981', 15, 15, 'dstaire@vistaprint.com');
SET IDENTITY_INSERT Producents OFF
GO


SET IDENTITY_INSERT Operations ON
GO
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (1, 'Operacja Billrotha', 'Chirurgia', 1, 1, 1, 'Phasellus id sapien in sapien iaculis congue.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (2, 'Usunięcie tarczycy', 'Chirurgia', 1, 2, 2, 'In quis justo.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (3, 'Chirurgia onkologiczna', 'Chirurgia', 1, 3, 3, 'Pellentesque at nulla.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (4, 'Kardiowersja elektryczna', 'Kardiologia', 1, 4, 4, 'Curabitur convallis.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (5, 'Badanie elektrofizjologiczne serca', 'Kardiologia', 1, 5, 5, 'Maecenas tincidunt lacus at velit.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (6, 'Operacje tętniaka aorty', 'Kardiochirurgia', 1, 6, 6, 'Curabitur gravida nisi at nibh.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (7, 'Leczenie zatorowości płucnej', 'Kardiochirurgia', 1, 7, 7, 'Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (8, 'Wertebroplastyka', 'Neurochirurgia', 0, 9, 8, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (9, 'Kifoplastyka', 'Neurochirurgia', 1, 9, 9, 'In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (10, 'Endoskopowa operacja zatok przynosowych', 'Laryngologia', 0, 10, 10, 'Aenean lectus.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (11, 'Korekcja małżowin nosowych', 'Laryngologia', 1, 11, 11, 'Nulla nisl.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (12, 'Usunięcie ropnia lub krwiaka nosa', 'Laryngologia', 0, 12, 12, 'Nam tristique tortor eu pede.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (13, 'Usunięcie migdałka gardłowego', 'Laryngologia', 0, 13, 13, 'Vestibulum rutrum rutrum neque.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (14, 'Alloplastyka stawów', 'Ortopedia', 0, 14, 14, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio.');
insert into Operations (id, Name, Type, IsAnesthesia, ToolId, DrugId, Description) values (15, 'Artroskopia barku', 'Ortopedia', 1, 15, 15, 'Aliquam quis turpis eget elit sodales scelerisque.');
SET IDENTITY_INSERT Operations OFF
GO

SET IDENTITY_INSERT Costs ON
GO
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (1, 1, 1, 49, 96, 19);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (2, 2, 2, 35, 60, 18);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (3, 3, 3, 57, 54, 10);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (4, 4, 4, 46, 95, 6);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (5, 5, 5, 31, 89, 17);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (6, 6, 6, 41, 96, 12);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (7, 7, 7, 45, 74, 18);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (8, 8, 8, 40, 88, 1);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (9, 9, 9, 69, 77, 13);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (10, 10, 10, 55, 72, 9);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (11, 11, 11, 31, 70, 10);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (12, 12, 12, 41, 71, 9);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (13, 13, 13, 43, 90, 19);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (14, 14, 14, 34, 82, 15);
insert into Costs (id, ProducentId, DrugId, MinPrice, MaxPrice, TransportDays) values (15, 15, 15, 47, 70, 20);
SET IDENTITY_INSERT Costs OFF
GO

SET IDENTITY_INSERT Clinics ON
GO
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (1, 'Synexus Polska Sp. z o.o.', '02/19/1988', 0, null, 1, 1.95);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (2, 'PRIMA-MED', '03/02/1962', 1, null, 2, 1.23);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (3, 'Medical Center Artemed', '04/07/1977', 0, null, 3, 2.7);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (4, 'Artes NZOZ', '05/16/1962', 1, null, 4, 1.86);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (5, 'Eskulap Przychodnia lekarska', '03/28/1997', 1, null, 5, 4.96);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (6, 'Amicus Sp. z o.o. Centrum medyczne', '10/09/1977', 1, null, 6, 3.1);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (7, 'CMC-Cracow Medical Center NZOZ ', '04/29/1953', 1, null, 7, 4.1);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (8, 'Fam-Medica sp. z o.o.', '01/01/1972', 1, null, 8, 3.85);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (9, 'J.J. Capricorn sp. z o.o.', '11/25/1994', 0, null, 9, 3.02);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (10, 'Medica Sp. z o.o.', '03/17/1981', 0, null, 10, 2.88);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (11, 'Med-park Sp. z o.o.', '08/07/1991', 0, null, 11, 3.94);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (12, 'Jarmed s.c. NZOZ', '07/04/1956', 1, null, 12, 3.75);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (13, 'Mikmed Grzegorz Mikuła', '12/07/1975', 1, null, 13, 4.55);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (14, 'Manor-House Małgorzata Siemiątkowska', '07/29/1956', 1, null, 14, 3.23);
insert into Clinics (id, Name, OpenDate, IsPrivate, EmployeeId, LocalizationId, UserMark) values (15, 'Praktimed. Sp. z o.o. NZOZ. Profilaktyka', '12/18/1967', 0, null, 15, 2.18);
SET IDENTITY_INSERT Clinics OFF
GO


SET IDENTITY_INSERT Employees ON
GO
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (1, 6, 1, 1, 16, 'Glowny lekarz', 470);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (2, 8, 2, 2, 17, 'Glowny lekarz', 260);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (3, 3, 3, 3, 18, 'Glowny lekarz', 300);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (4, 1, 4, 4, 19, 'Glowny lekarz', 460);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (5, 11, 5, 5, 20, 'Lekarz', 445);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (6, 10, 6, 6, 21, 'Lekarz', 290);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (7, 15, 7, 7, 22, 'Lekarz', 310);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (8, 3, 8, 8, 23, 'Lekarz', 312);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (9, 3, 9, 9, 24, 'Lekarz', 460);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (10, 4, 10, 10, 25, 'Lekarz', 230);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (11, 3, 11, 11, 26, 'Lekarz', 410);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (12, 4, 12, 12, 27, 'Mlodszy lekarz', 200);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (13, 12, 13, 13, 28, 'Mlodszy lekarz', 390);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (14, 12, 14, 14, 29, 'Mlodszy lekarz', 370);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (15, 12, 15, 15, 30, 'Mlodszy lekarz', 468);

insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (16, 2, 5, 1, 61, 'Kierownik przychodni', 287);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (17, 13, 13, 2, 62, 'Kierownik przychodni', 587);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (18, 15, 5, 3, 63, 'Kierownik przychodni', 494);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (19, 11, 15, 4, 64, 'Kierownik przychodni', 356);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (20, 3, 12, 5, 65, 'Kierownik przychodni', 224);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (21, 2, 13, 6, 66, 'Kierownik przychodni', 273);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (22, 3, 2, 7, 67, 'Kierownik przychodni', 282);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (23, 15, 7, 8, 68, 'Kierownik przychodni', 231);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (24, 9, 15, 9, 69, 'Kierownik przychodni', 244);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (25, 7, 1, 10, 70, 'Kierownik przychodni', 563);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (26, 12, 7,11, 71, 'Kierownik przychodni', 504);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (27, 7, 9, 12, 72, 'Kierownik przychodni', 590);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (28, 8, 1, 13, 73, 'Kierownik przychodni', 550);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (29, 12, 11, 14, 74, 'Kierownik przychodni', 432);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (30, 7, 13, 15, 75,'Kierownik przychodni', 344);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (31, 6, 11, 9, 76, 'Mlodszy lekarz', 227);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (32, 12, 8, 15, 77, 'Mlodszy lekarz', 386);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (33, 6, 3, 4, 78, 'Mlodszy lekarz', 377);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (34, 13, 8, 14, 79, 'Mlodszy lekarz', 320);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (35, 15, 2, 13, 80, 'Mlodszy lekarz', 268);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (36, 3, 1, 12, 81, 'Mlodszy lekarz', 226);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (37, 15, 1, 12, 82, 'Lekarz', 305);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (38, 9, 5, 9, 83, 'Lekarz', 372);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (39, 8, 11, 15, 84, 'Lekarz', 533);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (40, 10, 7, 3, 85, 'Lekarz', 512);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (41, 5, 3, 15, 86,'Lekarz', 231);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (42, 7, 9, 3, 87, 'Lekarz', 512);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (43, 13, 3, 7, 88, 'Lekarz', 580);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (44, 7, 7, 5, 89, 'Lekarz', 297);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (45, 9, 6, 3, 90, 'Lekarz', 252);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (46, 5, 6, 13, 91, 'Lekarz', 271);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (47, 7, 10, 4, 92, 'Lekarz', 493);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (48, 13, 7, 7, 93, 'Lekarz', 444);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (49, 8, 6, 1, 94, 'Lekarz', 265);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (50, 10, 8, 8, 95, 'Lekarz', 579);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (51, 13, 12, 3, 96, 'Glowny lekarz', 267);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (52, 3, 6, 11, 97, 'Glowny lekarz', 298);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (53, 6, 5, 2, 98, 'Glowny lekarz', 487);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (54, 15, 14, 12, 99, 'Glowny lekarz', 336);
insert into Employees (id, OperationCount, OperationId, ClinicId, DataId, Rank, Cost) values (55, 11, 9, 3, 100, 'Glowny lekarz', 481);

SET IDENTITY_INSERT Employees OFF
GO

SET IDENTITY_INSERT Patients ON
GO
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (1, 31, 15, 'Maecenas tincidunt lacus at velit.', 1, '6/19/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (2, 32, 7, 'Vivamus vel nulla eget eros elementum pellentesque.', 4, '7/5/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (3, 33, 13, 'Pellentesque eget nunc.', 1, '12/22/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (4, 34, 15, 'Nulla suscipit ligula in lacus.', 4, '10/27/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (5, 35, 3, 'Praesent blandit lacinia erat.', 3, '6/21/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (6, 36, 12, 'Quisque id justo sit amet sapien dignissim vestibulum.', 1, '10/7/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (7, 37, 4, 'Praesent blandit.', 3, '1/13/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (8, 38, 12, 'Vestibulum sed magna at nunc commodo placerat.', 3, '2/26/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (9, 39, 12, 'Integer a nibh.', 5, '8/23/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (10, 40, 8, 'Maecenas pulvinar lobortis est.', 4, '6/18/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (11, 41, 7, 'Morbi vel lectus in quam fringilla rhoncus.', 4, '6/5/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (12, 42, 5, 'Etiam justo.', 2, '11/10/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (13, 43, 15, 'Donec semper sapien a libero.', 4, '5/8/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (14, 44, 3, 'Aenean auctor gravida sem.', 1, '11/15/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (15, 45, 10, 'Proin risus.', 2, '2/5/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (16, 46, 2, 'Nulla nisl.', 5, '2/16/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (17, 47, 9, 'Etiam pretium iaculis justo.', 3, '5/10/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (18, 48, 1, 'Nullam porttitor lacus at turpis.', 2, '12/16/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (19, 49, 8, 'Suspendisse accumsan tortor quis turpis.', 3, '6/3/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (20, 50, 1, 'Ut at dolor quis odio consequat varius.', 3, '11/9/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (21, 51, 4, 'Ut tellus.', 4, '8/27/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (22, 52, 4, 'Maecenas tincidunt lacus at velit.', 1, '5/15/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (23, 53, 13, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.', 4, '3/5/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (24, 54, 3, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', 5, '11/16/2020');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (25, 55, 13, 'Sed ante.', 4, '5/27/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (26, 56, 7, 'Vestibulum rutrum rutrum neque.', 5, '5/11/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (27, 57, 1, 'Fusce consequat.', 5, '5/5/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (28, 58, 15, 'Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo.', 3, '5/30/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (29, 59, 11, 'Fusce consequat.', 4, '2/2/2021');
insert into Patients (id, DataId, OperationId, Description, Priority, OperationDate) values (30, 60, 13, 'Aliquam non mauris.', 4, '4/12/2021');
SET IDENTITY_INSERT Patients OFF
GO

SET IDENTITY_INSERT Registrations ON
GO
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (1, '10/19/2020', '4:08', 11, 1);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (2, '1/31/2021', '19:42', 11, 2);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (3, '8/3/2021', '8:26', 7, 3);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (4, '12/2/2020', '12:41', 4, 4);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (5, '2/16/2021', '1:44', 13, 5);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (6, '10/15/2020', '16:01', 11, 6);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (7, '11/6/2020', '9:35', 7, 7);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (8, '10/21/2020', '2:35', 14, 8);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (9, '11/8/2020', '2:21', 14, 9);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (10, '7/9/2021', '17:37', 6, 10);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (11, '9/28/2020', '23:19', 14, 11);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (12, '9/30/2020', '15:42', 6, 12);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (13, '11/11/2020', '20:10', 4, 13);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (14, '8/28/2021', '9:26', 13, 14);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (15, '7/31/2021', '20:36', 2, 15);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (16, '5/15/2021', '21:22', 8, 16);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (17, '6/8/2021', '1:22', 5, 17);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (18, '3/7/2021', '2:44', 3, 18);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (19, '4/14/2021', '10:11', 14, 19);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (20, '6/22/2021', '13:56', 13, 20);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (21, '4/14/2021', '13:11', 15, 21);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (22, '7/10/2021', '14:33', 11, 22);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (23, '10/14/2020', '0:29', 3, 23);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (24, '3/24/2021', '18:10', 14, 24);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (25, '7/7/2021', '9:20', 1, 25);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (26, '8/28/2021', '17:20', 7, 26);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (27, '2/27/2021', '4:33', 11, 27);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (28, '8/25/2021', '16:42', 1, 28);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (29, '2/5/2021', '5:05', 6, 29);
insert into Registrations (id, Date, Time, EmployeeId, PatientId) values (30, '12/17/2020', '16:33', 10, 30);
SET IDENTITY_INSERT Registrations OFF
GO

SET IDENTITY_INSERT Opinions ON
insert into Opinions (id, ClinicId, DataId, Mark) values (1, 6, 62, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (2, 5, 10, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (3, 8, 41, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (4, 1, 64, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (5, 13, 44, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (6, 12, 72, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (7, 7, 73, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (8, 4, 81, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (9, 11, 65, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (10, 11, 73, 3);
insert into Opinions (id, ClinicId, DataId, Mark) values (11, 8, 80, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (12, 14, 77, 3);
insert into Opinions (id, ClinicId, DataId, Mark) values (13, 12, 91, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (14, 5, 69, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (15, 12, 81, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (16, 15, 58, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (17, 12, 44, 3);
insert into Opinions (id, ClinicId, DataId, Mark) values (18, 12, 48, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (19, 14, 65, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (20, 9, 25, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (21, 3, 13, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (22, 10, 16, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (23, 14, 6, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (24, 10, 21, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (25, 6, 99, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (26, 12, 54, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (27, 4, 69, 3);
insert into Opinions (id, ClinicId, DataId, Mark) values (28, 15, 72, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (29, 15, 38, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (30, 12, 88, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (31, 4, 93, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (32, 6, 28, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (33, 3, 34, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (34, 15, 31, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (35, 7, 55, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (36, 15, 92, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (37, 1, 87, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (38, 12, 22, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (39, 5, 56, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (40, 13, 23, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (41, 8, 1, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (42, 3, 22, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (43, 10, 61, 2);
insert into Opinions (id, ClinicId, DataId, Mark) values (44, 7, 7, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (45, 2, 100, 3);
insert into Opinions (id, ClinicId, DataId, Mark) values (46, 12, 85, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (47, 14, 54, 4);
insert into Opinions (id, ClinicId, DataId, Mark) values (48, 1, 70, 5);
insert into Opinions (id, ClinicId, DataId, Mark) values (49, 15, 60, 1);
insert into Opinions (id, ClinicId, DataId, Mark) values (50, 7, 36, 2);
SET IDENTITY_INSERT Opinions OFF
GO

UPDATE Clinics SET EmployeeId = 16 WHERE Id = 1;
UPDATE Clinics SET EmployeeId = 17 WHERE Id = 2;
UPDATE Clinics SET EmployeeId = 18 WHERE Id = 3;
UPDATE Clinics SET EmployeeId = 19 WHERE Id = 4;
UPDATE Clinics SET EmployeeId = 20 WHERE Id = 5;
UPDATE Clinics SET EmployeeId = 21 WHERE Id = 6;
UPDATE Clinics SET EmployeeId = 22 WHERE Id = 7;
UPDATE Clinics SET EmployeeId = 23 WHERE Id = 8;
UPDATE Clinics SET EmployeeId = 24 WHERE Id = 9;
UPDATE Clinics SET EmployeeId = 25 WHERE Id = 10;
UPDATE Clinics SET EmployeeId = 26 WHERE Id = 11;
UPDATE Clinics SET EmployeeId = 27 WHERE Id = 12;
UPDATE Clinics SET EmployeeId = 28 WHERE Id = 13;
UPDATE Clinics SET EmployeeId = 29 WHERE Id = 14;
UPDATE Clinics SET EmployeeId = 30 WHERE Id = 15;
