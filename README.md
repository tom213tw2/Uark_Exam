# Uark_Exam

# What to Do 
* 使用者登入頁
  - 提供帳號、密碼登入=> 登入後，待審狀態的帳號，將跳出提示訊息
  - 「此帳號待審核開通」
     - 系統登入記錄功能
* 建立帳號
  - org_no 查詢系統是否有該單位，無該單位，即提供建立
  - 使用者填寫姓名(必填)、生日(非必填)、Email(必填)、帳號(必填)
  - 密碼(必填)、申請資格附檔上傳(必填)
    - 上述欄位條件請做出對應限制
    - 使用者送出後，狀態為待審
* 管理者審核頁面
  - 提供查詢欄位，依條件篩選出帳號申請列表
    - 列表分頁功能
    - 篩選資料匯出 Excel 功能
  - 點選資料查看帳號申請資料並審核(狀態:待審>>核可)，上傳附檔需可下載
    - 核可後可自動發送 Email 到申請者信箱
    - Email 附上連結網址，點擊可自動啓用帳號(狀態:核可>>啓用)
       
  
# Table schema
## Orgs Table

| Column Name  | Data Type       | Nullable | Primary Key | Foreign Key |
| ------------ | ------------    | -------- | ----------- | ----------- |
| id           | uniqueidentifier| No       | Yes         |             |
| title        | NVARCHAR(255)   | No       | No          |             |
| org_no       | INT             | No       | No          |             |
| created_at   | DATETIME        | No       | No          |             |
| updated_at   | DATETIME        | No       | No          |             |


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
| login_at     | DATETIME       | Yes       | No          |
| created_at   | DATETIME       | No       | No          |

## vUsers
| Column Name| Data Type        |
|------------|------------------|
| id         | uniqueidentifier |
| name       | NVARCHAR(100)    |
| account    | NVARCHAR(50)     |
| status     | VARCHAR(20)      |
| org_no     | INT              |
| title      | NVARCHAR(255)    |
| ipaddress  | VARCHAR(15)      |
| login_at   | DATETIME         |
| created_at | DATETIME         |



