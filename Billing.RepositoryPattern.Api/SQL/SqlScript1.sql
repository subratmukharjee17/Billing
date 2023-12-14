USE [BillingApi]
GO

/****** Object:  StoredProcedure [dbo].[USP_GetBillDetails]    Script Date: 14-12-2023 19:44:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[USP_GetBillDetails] @billingid int
  as
  begin
  select sd.BillingId 
  ,sd.SaleDate
  ,bi.PaymentType
  ,p.ProductName
  ,sd.Quantity
  ,sd.Amount
  ,bi.Price
  from BillingApi.Product.SalesDetails sd join BillingApi.Product.BillingInfo bi on sd.BillingId=bi.BillingId
  join [BillingApi].[Product].[Products] p on p.ProductId=sd.ProductId where sd.BillingId=@billingid
  end
GO


