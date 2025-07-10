# Dotnet8WebAPIMongoDBCQRS 開發任務清單

本文件旨在將 `Dotnet8WebAPIMongoDBCQRS` 專案的開發工作分解為具體、可追蹤的任務。開發人員應遵循此清單，並在完成每項任務後進行標記。

## Phase 1: 專案初始化與結構建立

-   [ ] 1.1. 使用 `dotnet new sln` 建立解決方案檔案 `Dotnet8WebAPIMongoDBCQRS.sln`。
-   [ ] 1.2. 建立四個核心專案：
    -   [ ] 1.2.1. `dotnet new webapi -n Dotnet8WebAPIMongoDBCQRS.API`
    -   [ ] 1.2.2. `dotnet new classlib -n Dotnet8WebAPIMongoDBCQRS.Application`
    -   [ ] 1.2.3. `dotnet new classlib -n Dotnet8WebAPIMongoDBCQRS.Domain`
    -   [ ] 1.2.4. `dotnet new classlib -n Dotnet8WebAPIMongoDBCQRS.Infrastructure`
-   [ ] 1.3. 將所有專案加入解決方案。
-   [ ] 1.4. 設定專案參考：
    -   [ ] 1.4.1. `API` -> `Application`
    -   [ ] 1.4.2. `Application` -> `Domain`
    -   [ ] 1.4.3. `Infrastructure` -> `Application`
    -   [ ] 1.4.4. `Infrastructure` -> `Domain`

## Phase 2: 核心套件與組態設定

-   [ ] 2.1. 在 `API` 專案中安裝 NuGet 套件：
    -   [ ] 2.1.1. `MediatR`
    -   [ ] 2.1.2. `MongoDB.Driver`
-   [ ] 2.2. 在 `Application` 專案中安裝 NuGet 套件：
    -   [ ] 2.2.1. `MediatR`
-   [ ] 2.3. 在 `Infrastructure` 專案中安裝 NuGet 套件：
    -   [ ] 2.3.1. `MongoDB.Driver`
-   [ ] 2.4. 在 `appsettings.json` 中設定 MongoDB 連線字串。
-   [ ] 2.5. 在 `API` 專案的 `Program.cs` 中註冊 `MediatR` 和 `MongoDB` 相關服務。

## Phase 3: Domain 層開發

-   [ ] 3.1. 建立 `Product` 實體 (`Entities/Product.cs`)，包含 Id, Name, Description, Price, Stock, CreatedAt, UpdatedAt 等屬性。
-   [ ] 3.2. 使用 BSON 屬性標註 `Product` 實體，以對應 MongoDB 的欄位。

## Phase 4: Application 層開發 (CQRS)

-   [ ] 4.1. **Commands (寫入操作):**
    -   [ ] 4.1.1. 建立 `CreateProduct` Command (`Features/Products/Commands/CreateProduct/`)
        -   [ ] `CreateProductCommand.cs`
        -   [ ] `CreateProductCommandHandler.cs`
    -   [ ] 4.1.2. 建立 `UpdateProduct` Command (`Features/Products/Commands/UpdateProduct/`)
        -   [ ] `UpdateProductCommand.cs`
        -   [ ] `UpdateProductCommandHandler.cs`
    -   [ ] 4.1.3. 建立 `DeleteProduct` Command (`Features/Products/Commands/DeleteProduct/`)
        -   [ ] `DeleteProductCommand.cs`
        -   [ ] `DeleteProductCommandHandler.cs`
-   [ ] 4.2. **Queries (讀取操作):**
    -   [ ] 4.2.1. 建立 `GetProductById` Query (`Features/Products/Queries/GetProductById/`)
        -   [ ] `GetProductByIdQuery.cs`
        -   [ ] `GetProductByIdQueryHandler.cs`
    -   [ ] 4.2.2. 建立 `GetAllProducts` Query (`Features/Products/Queries/GetAllProducts/`)
        -   [ ] `GetAllProductsQuery.cs`
        -   [ ] `GetAllProductsQueryHandler.cs`
-   [ ] 4.3. 建立 `ProductDto.cs` 作為資料傳輸物件。
-   [ ] 4.4. 定義 `IProductRepository` 介面 (`Interfaces/IProductRepository.cs`)。

## Phase 5: Infrastructure 層開發

-   [ ] 5.1. 建立 `MongoDbContext.cs` 來管理對 MongoDB 的連線和 `IMongoCollection` 的存取。
-   [ ] 5.2. 實現 `ProductRepository.cs` (`Repositories/ProductRepository.cs`)，實作 `IProductRepository` 介面中的方法。
-   [ ] 5.3. 在 `ProductRepository` 中實現 CRUD 的異步資料庫操作。

## Phase 6: API 層開發

-   [ ] 6.1. 建立 `ProductsController.cs`。
-   [ ] 6.2. 在 `ProductsController` 中注入 `IMediator`。
-   [ ] 6.3. 為每個 CRUD 操作建立對應的 API 端點，並透過 `mediator.Send()` 傳送對應的 Command 或 Query。
-   [ ] 6.4. 處理 API 的回應 (HTTP 狀態碼和回傳資料)。
-   [ ] 6.5. 新增全域錯誤處理中介軟體。

## Phase 7: 測試與文件

-   [ ] 7.1. 建立單元測試專案。
-   [ ] 7.2. 針對 Application 層的 Handlers 撰寫單元測試。
-   [ ] 7.3. 使用 Postman 或 .http 檔案進行 API 端點的整合測試。
-   [ ] 7.4. 撰寫 `README.md`，說明專案的建置與執行方式。