# Dotnet8 WebAPI MongoDB CQRS 專案

這是一個使用 .NET 8 WebAPI、CQRS (命令查詢責任分離) 模式和 MongoDB 建立的 CRUD (建立、讀取、更新、刪除) 應用程式範例。

## 專案描述

本專案旨在展示如何使用現代 .NET 技術棧，結合清晰的架構模式，來建構一個可維護、可擴展的後端服務。

*   **.NET 8:** 使用最新的 .NET 長期支援版本。
*   **WebAPI:** 提供 RESTful API 端點。
*   **CQRS 模式:** 使用 MediatR 函式庫實現，將寫入操作 (Commands) 和讀取操作 (Queries) 分離，使系統職責更清晰。
*   **MongoDB:** 使用官方的 `MongoDB.Driver`，以文件型資料庫儲存資料。
*   **分層架構:**
    *   **Domain:** 包含核心業務實體。
    *   **Application:** 包含業務邏輯、CQRS 命令/查詢和 DTOs。
    *   **Infrastructure:** 包含資料庫存取等外部服務的具體實現。
    *   **API:** 負責接收 HTTP 請求並與使用者互動。

## 安裝與需求

1.  **.NET 8 SDK:** [下載並安裝](https://dotnet.microsoft.com/download/dotnet/8.0)
2.  **MongoDB:** 需要一個正在運行的 MongoDB 實例。您可以使用 [MongoDB Community Server](https://www.mongodb.com/try/download/community) 或 [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) 雲端服務。

## 執行方式

1.  **Clone 專案庫:**
    ```bash
    git clone <your-repository-url>
    cd <your-repository-directory>
    ```

2.  **設定資料庫連線:**
    開啟 `src/Dotnet8WebAPIMongoDBCQRS.API/appsettings.json` 檔案，並修改 `MongoDbSettings` 區段以符合您的 MongoDB 設定。
    ```json
    "MongoDbSettings": {
      "ConnectionString": "mongodb://localhost:27017",
      "DatabaseName": "ProductDb"
    },
    ```

3.  **還原相依套件:**
    在專案根目錄 (包含 `.sln` 檔案) 開啟終端機，並執行：
    ```bash
    dotnet restore
    ```

4.  **建置專案:**
    ```bash
    dotnet build
    ```

5.  **執行專案:**
    ```bash
    dotnet run --project src/Dotnet8WebAPIMongoDBCQRS.API/Dotnet8WebAPIMongoDBCQRS.API.csproj
    ```

6.  **瀏覽 API:**
    應用程式啟動後，您可以在終端機中看到其監聽的 URL (例如 `https://localhost:7123`)。
    您可以透過以下方式與 API 互動：
    *   **Swagger UI:** 在瀏覽器中開啟 `https://localhost:7123/swagger`，您將看到一個互動式的 API 文件頁面，可直接在此測試所有端點。
    *   **HTTP 工具:** 使用 Postman、Insomnia 或 VS Code 的 .http 檔案來發送請求到 `/api/products` 端點。