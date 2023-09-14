# Uark_Exam

## orgs Table

| Column Name  | Data Type    | Nullable | Primary Key | Foreign Key |
| ------------ | ------------ | -------- | ----------- | ----------- |
| id           | INT          | No       | Yes         |             |
| title        | NVARCHAR(255)| No       | No          |             |
| org_no       | INT          | No       | No          |             |
| created_at   | DATETIME     | No       | No          |             |
| updated_at   | DATETIME     | No       | No          |             |


## Users Table

| Column Name  | Data Type       | Nullable | Primary Key | Foreign Key |
| ------------ | --------------- | -------- | ----------- | ----------- |
| id           | uniqueidentifier| No       | Yes         |             |
| org_id       | uniqueidentifier| No       | No          |Orgs.id      |
| name         | NVARCHAR(100)   | No       | No          |             |
| birthday     | DATE            | Yes      | No          |             |
| email        | NVARCHAR(255)   | Yes      | No          |             |
| account      | NVARCHAR(50)    | No       | No          |             |
| password     | NVARCHAR(255)   | No       | No          |             |
| status       | VARCHAR(20)     | No       | No          |             |
| created_at   | DATETIME        | No       | No          |             |
| updated_at   | DATETIME        | No       | No          |             |

## Apply_File Table

| Column Name  | Data Type      | Nullable | Primary Key | Foreign Key |
| ------------ | ------------   | -------- | ----------- | ----------- |
| id           |uniqueidentifier| No       | Yes         |             |
| user_id      |uniqueidentifier| No       | No          | Users.id    |
| file_path    | NVARCHAR(255)  | No       | No          |             |
| created_at   | DATETIME       | No       | No          |             |
| updated_at   | DATETIME       | No       | No          |             |

## Syslog Table

| Column Name  | Data Type      | Nullable | Primary Key |
| ------------ | ------------   | -------- | ----------- |
| seq_no       |uniqueidentifier| No       | Yes         |  
| account      | NVARCHAR(50)   | No       | No          |
| ipaddress    | VARCHAR(15)    | No       | No          |
| login_at     | DATETIME       | No       | No          |
| created_at   | DATETIME       | No       | No          |


