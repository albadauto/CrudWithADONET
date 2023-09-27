USE TREINO3
GO

IF EXISTS(SELECT * FROM SYS.OBJECTS WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.SP_TESTINSERT'))
BEGIN
	DROP PROCEDURE SP_TESTINSERT
END
GO
CREATE PROCEDURE SP_TESTINSERT @NAME VARCHAR(100), @AGE INT, @EMAIL VARCHAR(100)
AS
BEGIN
	INSERT INTO [USER] VALUES (@NAME, @EMAIL, @AGE) 
END

