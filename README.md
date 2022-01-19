# MSQL專案、長/短連結練習

## MSSQL專案

* ReportCard.DataBase: MSQL專案建置，可以參考[此篇](https://zongu.github.io/2022/01/12/VS2019%E5%BB%BA%E7%AB%8BSQL%E5%B0%88%E6%A1%88/)簡介

## 領域層

* ReportCard.Domain: 各專案共同參考介面、類別

## 持久層

* ReportCard.Persistent: .net調用MSSQL實作
* ReportCard.Persistent.Tests: .net調用MSSQL實作

## 類型A-直接存取持久層

* ReportCard: 主控台調用持久層
* ReportCard.Tests: 主控台調用持久層

## 類型B-Client透過Web Api跟Server存取持久層

* ReportCard.Api.Client: Web api Client主程式
* ReportCard.Api.Client.Tests: Web api Client主程式商業邏輯單元測試
* ReportCard.Api.Server: Web api Server主程式
* ReportCard.Api.Server.Tests: Web api Server主程式單元測試

## 類型C-Client透過Signalr跟Server存取持久層

* ReportCard.Signalr.Client: Signalr Client主程式
* ReportCard.Signalr.Client.Tests: Signalr Client主程式商業邏輯單元測試
* ReportCard.Signalr.Server: Signalr Server主程式
* ReportCard.Signalr.Server.Tests: Signalr Server主程式商業邏輯單元測試
