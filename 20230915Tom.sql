CREATE TABLE dbo.Users
(
	id UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL PRIMARY KEY,
	org_id UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Orgs(id),
	name NVARCHAR(100) NOT NULL ,
	birthday DATE ,
	email NVARCHAR(255),
	account NVARCHAR(50) NOT NULL,
	password NVARCHAR(255) NOT NULL,
	status VARCHAR(200) DEFAULT 'Pending Approval',
	created_at DATETIME DEFAULT GETDATE(),
	updated_at DATETIME	DEFAULT GETDATE()
)
GO

CREATE TABLE dbo.Apply_File
(
	id UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL PRIMARY KEY,
	user_id UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Users(id),
	file_path NVARCHAR(255) NOT NULL,
	created_at DATETIME DEFAULT GETDATE(),
	updated_at DATETIME	DEFAULT GETDATE()
)
GO

CREATE TABLE dbo.SysLog
(
	seq_no UNIQUEIDENTIFIER  DEFAULT NEWID() NOT NULL PRIMARY KEY,
	account NVARCHAR(50) NOT NULL,
	ipaddress VARCHAR(15) NOT NULL,
	login_at DATETIME DEFAULT GETDATE() ,
	created_at DATETIME DEFAULT GETDATE() NOT NULL
)
GO

CREATE TABLE dbo.Orgs
(
	id UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL PRIMARY KEY,
	title NVARCHAR(255) NOT NULL,
	org_no INT NOT NULL,
	created_at DATETIME NOT NULL,
	updated_at DATETIME
)
GO

CREATE VIEW [dbo].[vUsers]
AS
SELECT          u.id, u.name, u.account, u.status, o.org_no, o.title, sl.ipaddress, sl.login_at, u.created_at
FROM              dbo.Users AS u LEFT OUTER JOIN
                            dbo.Orgs AS o ON u.org_id = o.id LEFT OUTER JOIN
                            dbo.SysLog AS sl ON u.account = sl.account
GO
