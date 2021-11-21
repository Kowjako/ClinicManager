CREATE PROCEDURE GetHighestMarkForClinic
@Id int,
@Mark decimal(2,1) output
AS
SELECT @Mark = MAX(Mark) FROM Opinions o WHERE o.ClinicId = @Id
