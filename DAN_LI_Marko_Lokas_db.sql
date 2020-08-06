IF DB_ID('MedicalInstitution') IS NULL
CREATE DATABASE MedicalInstitution
GO

USE MedicalInstitution

ALTER DATABASE MedicalInstitution COLLATE Croatian_CI_AS;
GO

-- Drop Foreign Keys
IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT FK_Patient_Doctor;
--===================================================================

-- Drop Primary Keys 
IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT PK_Patient;
IF OBJECT_ID('tblSickLeave', 'U') IS NOT NULL 
	ALTER TABLE tblSickLeave DROP CONSTRAINT PK_SickLeave;
IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT PK_Doctor;
--===================================================================

-- Drop UNUQUE
IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT UC_JMBGd;
IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT UC_JMBGp;
IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT UC_AccountNumber;
IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT UC_HealthInsuranceCardNumber;
--===================================================================

-- Drop tables
IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	DROP TABLE tblPatient;
IF OBJECT_ID('tblSickLeave', 'U') IS NOT NULL 
	DROP TABLE tblSickLeave;
IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	DROP TABLE tblDoctor;
--===================================================================

-- Create tables
CREATE TABLE tblPatient(
	PatientID						int identity(1,1) NOT NULL,
	PatientNameSurname				nvarchar (70) NOT NULL,
	JMBG							char(13) NOT NULL,
	HealthInsuranceCardNumber		nvarchar(12) NOT NULL,
	UsernameLogin					nvarchar(50) NOT NULL,
	PasswordLogin					nvarchar(50) NOT NULL,
	Doctor							int
	)

CREATE TABLE tblSickLeave(
	SickLeaveID			int identity(1,1) NOT NULL,
	SendingSLRequest		date NOT NULL,
	Reason				nvarchar(250) NOT NULL,
	CompanyName			nvarchar(100),
	EmergencySL			char(5) NOT NULL
	)

CREATE TABLE tblDoctor(
	DoctorID			int identity(1,1) NOT NULL,
	DoctorName			nvarchar (70) NOT NULL,
	DoctorSurname		nvarchar (70) NOT NULL,
	JMBG				char(13) NOT NULL,
	AccountNumber		nvarchar(20) NOT NULL,
	UsernameLogin		nvarchar(50) NOT NULL,
	PasswordLogin		nvarchar(50) NOT NULL
	)
--===================================================================

-- Add contraints for PK
ALTER TABLE tblPatient
	ADD CONSTRAINT PK_Patient
	PRIMARY KEY (PatientID)
ALTER TABLE tblSickLeave
	ADD CONSTRAINT PK_SickLeave
	PRIMARY KEY (SickLeaveID)
ALTER TABLE tblDoctor
	ADD CONSTRAINT PK_Doctor
	PRIMARY KEY (DoctorID)
--===================================================================

-- Add contraints for UNIQUE
ALTER TABLE tblDoctor
	ADD CONSTRAINT UC_JMBGd
	UNIQUE (JMBG)
ALTER TABLE tblPatient
	ADD CONSTRAINT UC_JMBGp
	UNIQUE (JMBG)
ALTER TABLE tblDoctor
	ADD CONSTRAINT UC_AccountNumber
	UNIQUE (AccountNumber)
ALTER TABLE tblPatient
	ADD CONSTRAINT UC_HealthInsuranceCardNumber
	UNIQUE (HealthInsuranceCardNumber)
--===================================================================

-- Add contraints for FK
ALTER TABLE tblPatient 
	ADD CONSTRAINT FK_Patient_Doctor
	FOREIGN KEY (Doctor) 
	REFERENCES tblDoctor (DoctorID)
--===================================================================

-- Add CHECK contraints

-- JMBG - Must have 13 characters and all characters is number,
ALTER TABLE tblDoctor
	ADD CONSTRAINT CK_JMBGd 
	CHECK(LEN(JMBG) = 13 AND JMBG LIKE ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
ALTER TABLE tblPatient
	ADD CONSTRAINT CK_JMBGp
	CHECK(LEN(JMBG) = 13 AND JMBG LIKE ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))

