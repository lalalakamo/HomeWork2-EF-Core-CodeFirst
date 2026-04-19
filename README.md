# Gemeni 針對EF Core CodeFisrㄔ基本操作(建立資料表、Controller基本Function讀取) 出一份實作功課

## 功能開發要求

### 第一階段：建立模型 (Model)
* 請在你的專案 Models 資料夾下，新增一個 Book.cs 類別，並包含以下欄位：
  * Id: 整數 (自動跳號的主鍵)。
  * Title: 字串 (書名，限制最大長度 100，必填)。
  * Author: 字串 (作者，必填)。
  * Price: 整數 (價格)。
  * PublishDate: 日期 (出版日期，預設值為目前時間)。

### 第二階段：配置 Context
* 請修改你的 WebContext.cs：
  * 1.加入 public DbSet<Book> Books { get; set; }。
  * 2.在 OnModelCreating 裡，使用 Fluent API 設定 Title 的最大長度為 100。
  * 3.設定 PublishDate 的預設值為 SQL 的 getdate()。

### 第三階段：資料庫遷移 (Migration)
* 請開啟套件管理主控台，執行以下操作：
  * 1.下指令產生名為 AddBookTable 的遷移檔案。
  * 2.將變更更新至 SQL Server。
  * 3.檢查點： 打開 SSMS，確認 Books 資料表是否已經出現，且欄位長度與預設值是否正確。
 
### 第四階段：撰寫 API 控制器 (Controller)
* 建立一個 BooksController.cs，並實作以下 LINQ 功能：
  * 1.查詢全部：GET /api/Books。
  * 2.條件查詢：GET /api/Books/expensive (使用 LINQ 找出價格大於 500 的所有書籍)。
  * 3.關鍵字搜尋：GET /api/Books/search?name=xxx (使用 LINQ 的 .Where() 與 .Contains() 找出書名包含關鍵字的書籍)。

 ### 實作小提醒
 * 練習 LINQ：在第四階段中，盡量不要只回傳全部，試著練習昨天學的 Where 和 OrderBy。
 * 觀察 SQL：如果你有開啟 Visual Studio 的「輸出」視窗，你可以觀察當你呼叫 API 時，EF Core 產生的 SQL 長什麼樣子。

## 實作心得報告
### EF Core CodeFirst實作部分觀念補充
* API專案必須先安裝對應資料庫的EF Core以及EF Core.Tools NuGet套件
* Models目錄中各class目的
  * Book.cs: 定義實體（Entity）欄位(欄位名稱、資料型態)
  * WebContext.cs: 繼承 DbContext(EF Core的資料處理能力) 作為資料庫窗口、透過 OnModelCreating 設定資料庫約束（如長度、預設值）。
* Program.cs: 將Context註冊到DI容器中
* appsetting: 設定連線字串、帳號、密碼等可能會變動的參數，方便不同環境（開發/正式）切換。
* Add-Migration: 紀錄C#與資料庫監的結構變更歷史紀錄，並產生施工腳本(Migration Files)
* Update-Database: 讀取 Migration 施工腳本，透過 Program.cs 提供的連線資訊，將變更正式套用到 SQL Server 中。
  

