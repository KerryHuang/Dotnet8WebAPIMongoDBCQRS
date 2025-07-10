# Dotnet8WebAPIMongoDBCQRS

## 專案簡介
本專案是一個基於 .NET 8、MongoDB 與 CQRS 架構設計的 Web API，提供高效能且可擴展的產品資料存取與管理服務。專案結合 Command Query Responsibility Segregation（命令查詢責任分離）模式，提升系統維護性與可測試性。

- **.NET 8**：最新 LTS 版本，提供現代化開發體驗。
- **WebAPI**：RESTful API 端點。
- **CQRS**：以 MediatR 實現，將 Command 與 Query 分離。
- **MongoDB**：官方 MongoDB.Driver。
- **分層架構**：Domain、Application、Infrastructure、API。

## 專案結構
- `src/Dotnet8WebAPIMongoDBCQRS.Domain/`：核心業務實體
- `src/Dotnet8WebAPIMongoDBCQRS.Application/`：DTO、CQRS Command/Query、介面
- `src/Dotnet8WebAPIMongoDBCQRS.Infrastructure/`：MongoDB 實作、Repository
- `src/Dotnet8WebAPIMongoDBCQRS.API/`：Web API 專案

## 安裝與執行
1. 還原相依套件：
   ```powershell
   dotnet restore Dotnet8WebAPIMongoDBCQRS.sln
   ```
2. 建置專案：
   ```powershell
   dotnet build Dotnet8WebAPIMongoDBCQRS.sln
   ```
3. 啟動 API：
   ```powershell
   dotnet run --project src/Dotnet8WebAPIMongoDBCQRS.API
   ```
4. 依據 `launchSettings.json` 設定，預設 API 端點為：
   - http://localhost:5207

## 主要功能
- 產品 CRUD API
- CQRS 架構 (MediatR)
- MongoDB 資料存取

## 相關文件
- `.doc/Dotnet8WebAPIMongoDBCQRS/README_Dotnet8WebAPIMongoDBCQRS.md`：詳細說明
- `.doc/Dotnet8WebAPIMongoDBCQRS/Dotnet8WebAPIMongoDBCQRS_規格書.md`：規格書

## 聯絡方式
如有問題請聯絡專案維護者。
