# Dotnet8WebAPIMongoDBCQRS

## 專案描述
本專案為一個基於 .NET 8、MongoDB 與 CQRS 架構設計的 Web API，旨在提供高效能、可擴展的產品資料存取與管理服務。專案結合 Command Query Responsibility Segregation（命令查詢責任分離）模式，提升系統維護性與可測試性。

## 安裝說明
請於專案根目錄下執行以下指令以還原所有相依套件：

```bash
dotnet restore Dotnet8WebAPIMongoDBCQRS.sln
```

## 執行方式
1. 建置專案：
    ```bash
    dotnet build Dotnet8WebAPIMongoDBCQRS.sln
    ```
2. 啟動 API 專案：
    ```bash
    dotnet run --project src/Dotnet8WebAPIMongoDBCQRS.API/Dotnet8WebAPIMongoDBCQRS.API.csproj
    ```
3. 服務啟動後，可透過下列網址存取 API（依據 [`launchSettings.json`](src/Dotnet8WebAPIMongoDBCQRS.API/Properties/launchSettings.json:1) 設定）：
    - http://localhost:5207
    - https://localhost:7284

如需進一步設定或測試，請參考專案內其他說明文件。