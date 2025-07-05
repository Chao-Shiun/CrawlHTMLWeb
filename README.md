# HTML 網頁內容抓取專案

這是一個前後端分離的專案，用於抓取指定 URL 的 HTML 內容。

## 功能

-   **前端**: 使用 Vue.js 建立一個簡單的介面，包含一個輸入框和一個按鈕。
-   **後端**: 使用 .NET 8 Web API 建立一個端點，接收前端傳來的 URL。
-   **核心邏輯**: 後端抓取 URL 的 HTML 內容，並將其回傳給前端顯示。

## 專案結構

```
/
├── backend/         # .NET 8 Web API 後端專案
└── frontend/        # Vue.js 前端專案
```

## 環境需求

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [Node.js](https://nodejs.org/) (包含 npm)

## 如何執行

您需要開啟兩個終端機視窗來分別執行後端和前端服務。

### 1. 執行後端 (.NET API)

```bash
# 進入後端專案目錄
cd backend

# 執行專案
dotnet run
```

服務將會啟動在 `http://localhost:5107`。

### 2. 執行前端 (Vue App)

```bash
# 進入前端專案目錄
cd frontend

# 安裝依賴套件 (僅需在第一次執行時)
npm install

# 啟動開發伺服器
npm run dev
```

服務將會啟動在 `http://localhost:5173` (或終端機顯示的其他 port)。您可以在瀏覽器中開啟此 URL 來使用本應用程式。
