USE [IceBreakerMiniProject]
GO
INSERT [dbo].[IBMPBom] ([ManufacPartID], [ComponentID], [Qty], [LineNbr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (1, 6, 1, 1, CAST(N'2022-02-22T05:41:31.797' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', CAST(N'2022-02-22T05:41:31.797' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', N'8327d70f-a293-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPBom] ([ManufacPartID], [ComponentID], [Qty], [LineNbr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (1, 7, 2, 3, CAST(N'2022-02-22T15:45:19.313' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', CAST(N'2022-02-22T15:45:19.313' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', N'489e4061-f693-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPBom] ([ManufacPartID], [ComponentID], [Qty], [LineNbr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (1, 9, 1, 2, CAST(N'2022-02-22T15:44:27.493' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', CAST(N'2022-02-22T15:44:27.493' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', N'1085fc49-f693-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPBom] ([ManufacPartID], [ComponentID], [Qty], [LineNbr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (2, 7, 2, 2, CAST(N'2022-02-22T05:40:53.920' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', CAST(N'2022-02-22T05:40:53.920' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', N'4c1adbf9-a193-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPBom] ([ManufacPartID], [ComponentID], [Qty], [LineNbr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (2, 9, 1, 1, CAST(N'2022-02-22T05:40:39.740' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', CAST(N'2022-02-22T05:40:39.740' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', N'922a56f1-a193-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPCustomer] ON
GO
INSERT [dbo].[IBMPCustomer] ([CustomerID], [CustomerCD], [Name], [Address], [Contact], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (3, N'CUS0001', N'Saman Kumara', N'Galle', N'0771110052', CAST(N'2022-02-22T06:32:47.270' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB207000', CAST(N'2022-02-22T15:11:53.353' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB207000', N'05689e3b-a993-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPCustomer] ([CustomerID], [CustomerCD], [Name], [Address], [Contact], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (4, N'CUS0002', N'Nimal Perera', N'Matara', N'0773952431', CAST(N'2022-02-22T15:12:08.653' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB207000', CAST(N'2022-02-22T15:12:08.653' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB207000', N'89672dc5-f193-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPCustomer] ([CustomerID], [CustomerCD], [Name], [Address], [Contact], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (5, N'CUS003', N'Sunil Silva', N'Colombo', N'0778855124', CAST(N'2022-02-22T15:12:33.167' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB207000', CAST(N'2022-02-22T15:12:33.167' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB207000', N'd0eaefcc-f193-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[IBMPInventory] ON
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (1, N'LUM001', N'Lumala Bike Type A', CAST(20000.000000 AS Decimal(19, 6)), N'MANUFACTURED   ', N'STOCK', 3, CAST(N'2014-06-17T13:20:58.780' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'SM206036', CAST(N'2022-02-22T15:49:55.430' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'7c5ec13a-c7ea-e511-82af-000c2909c111')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (2, N'LUM002', N'Lumala Bike Type B', CAST(25000.000000 AS Decimal(19, 6)), N'MANUFACTURED', N'STOCK', 2, CAST(N'2014-06-17T13:20:58.780' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'SM206036', CAST(N'2022-02-22T05:40:53.923' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB206000', N'7c5ec13a-c7ea-e511-82af-000c2909c111')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (5, N'REP001', N'Handle Repair - Repair the handle ', CAST(500.000000 AS Decimal(19, 6)), N'NOPART', N'NONSTOCK', 0, CAST(N'2022-02-15T04:17:44.420' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-17T04:10:51.020' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'7aae1c30-168e-ec11-ae83-747827801fad')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (6, N'HAND01', N'Handle Type A', CAST(1000.000000 AS Decimal(19, 6)), N'PURCHASED      ', N'STOCK', 0, CAST(N'2022-02-15T04:17:44.420' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-22T15:49:41.023' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'7aae1c30-168e-ec11-ae83-747827801fad')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (7, N'TYRE001', N'Tyre Type 01', CAST(1500.000000 AS Decimal(19, 6)), N'PURCHASED', N'STOCK', 0, CAST(N'2022-02-15T04:17:44.420' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-15T04:17:44.420' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'7aae1c30-168e-ec11-ae83-747827801fad')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (8, N'SERV01', N'Full Service Bike', CAST(2500.000000 AS Decimal(19, 6)), N'NOPART', N'NONSTOCK', 0, CAST(N'2022-02-15T04:17:44.420' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-15T04:17:44.420' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'7aae1c30-168e-ec11-ae83-747827801fad')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (9, N'SEAT001', N'Seat type A for Lumala Bikes', CAST(250.000000 AS Decimal(19, 6)), N'PURCHASED      ', N'STOCK', 0, CAST(N'2022-02-21T20:02:19.127' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-21T20:02:19.127' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'a37ae30f-5193-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPInventory] ([InventoryID], [InventoryCD], [Description], [Price], [PartType], [InventoryType], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (10, N'BRK001', N'Break Handle Left', CAST(500.000000 AS Decimal(19, 6)), N'PURCHASED      ', N'STOCK', 0, CAST(N'2022-02-22T15:13:26.930' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-22T15:49:25.887' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'4b1c37f0-f193-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPInventory] OFF
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (11, 5, 10, 2, CAST(N'2014-06-17T13:20:58.780' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'SM206036', CAST(N'2022-02-14T08:16:45.773' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'43103b2c-d87f-e411-beca-00b56d0561c2')
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (13, 5, 9, 5, CAST(N'2022-02-17T04:10:51.013' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-17T04:10:51.013' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'5dfd458e-a78f-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (17, 5, 6, 5, CAST(N'2022-02-17T04:08:56.713' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-17T04:08:56.713' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'608be94a-a78f-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (20, 6, 5, 10, CAST(N'2022-02-22T15:49:41.017' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-22T15:49:41.017' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'bdaad505-f793-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (20, 10, 2, 5, CAST(N'2022-02-22T15:49:19.113' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-22T15:49:19.113' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'3a195efe-f693-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (21, 1, 5, 12, CAST(N'2022-02-22T15:49:55.423' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-22T15:49:55.423' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'8a7c9a13-f793-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPLocationInventory] ([LocationID], [InventoryID], [QtyHand], [QtyReserved], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (22, 10, 2, 6, CAST(N'2022-02-22T15:49:25.880' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', CAST(N'2022-02-22T15:49:25.880' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB202000', N'3d195efe-f693-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPSalesOrder] ON
GO
INSERT [dbo].[IBMPSalesOrder] ([SalesOrderID], [SalesOrderCD], [CustomerID], [OrderDate], [RequiredDate], [DeliveryAddress], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID], [Status], [SumPrice]) VALUES (7, N'SO00001', 1, CAST(N'2022-05-22T00:00:00.000' AS DateTime), CAST(N'2022-01-08T00:00:00.000' AS DateTime), N'Galle', 5, CAST(N'2022-02-21T20:41:18.847' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T15:51:48.393' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'3fc13991-5693-ec11-a49e-f09e4a254edb', N'PLANNED   ', CAST(57750 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[IBMPSalesOrder] ON
INSERT [dbo].[IBMPSalesOrder] ([SalesOrderID], [SalesOrderCD], [CustomerID], [OrderDate], [RequiredDate], [DeliveryAddress], [LineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID], [Status], [SumPrice])VALUES (8, N'SO00002', 1, CAST(N'2022-12-05T00:00:00.000' AS DateTime), CAST(N'2022-12-09T00:00:00.000' AS DateTime), N'Galle', 2, CAST(N'2022-02-22T04:55:52.370' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T04:56:34.863' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'0b8f38af-9b93-ec11-a49e-f09e4a254edb', N'PLANNED   ', CAST(22500 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[IBMPSalesOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[IBMPSalesOrder] OFF
GO
INSERT [dbo].[IBMPSalesOrderLine] ([SalesOrderID], [LineNbr], [PartID], [Qty], [Price], [Status], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (7, 2, 1, 1, CAST(20000.000000 AS Decimal(19, 6)), N'REQUIRED', CAST(N'2022-02-22T04:54:57.967' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T04:54:57.967' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'2340748e-9b93-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPSalesOrderLine] ([SalesOrderID], [LineNbr], [PartID], [Qty], [Price], [Status], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (7, 3, 8, 5, CAST(2500.000000 AS Decimal(19, 6)), N'REQUIRED', CAST(N'2022-02-22T04:55:11.063' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T04:55:11.063' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'7cc36a94-9b93-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPSalesOrderLine] ([SalesOrderID], [LineNbr], [PartID], [Qty], [Price], [Status], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (7, 4, 2, 1, CAST(25000.000000 AS Decimal(19, 6)), N'REQUIRED', CAST(N'2022-02-22T04:55:28.067' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T04:55:28.067' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'31d801a2-9b93-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPSalesOrderLine] ([SalesOrderID], [LineNbr], [PartID], [Qty], [Price], [Status], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (7, 5, 9, 1, CAST(250.000000 AS Decimal(19, 6)), N'REQUIRED', CAST(N'2022-02-22T15:51:48.387' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T15:51:48.387' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'1d93454f-f793-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPSalesOrderLine] ([SalesOrderID], [LineNbr], [PartID], [Qty], [Price], [Status], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (8, 1, 1, 1, CAST(20000.000000 AS Decimal(19, 6)), N'REQUIRED', CAST(N'2022-02-22T04:56:02.517' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T04:56:02.517' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'45a652b5-9b93-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPSalesOrderLine] ([SalesOrderID], [LineNbr], [PartID], [Qty], [Price], [Status], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (8, 2, 8, 1, CAST(2500.000000 AS Decimal(19, 6)), N'REQUIRED', CAST(N'2022-02-22T04:56:34.860' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', CAST(N'2022-02-22T04:56:34.860' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB204000', N'003313c7-9b93-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPWarehouse] ON
GO
INSERT [dbo].[IBMPWarehouse] ([WarehouseID], [WarehouseCD], [Name], [LocationLineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (15, N'WH00001', N'Retail Warehouse', 3, CAST(N'2022-02-22T05:45:44.507' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:48:07.177' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'5fc359a9-a293-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPWarehouse] ON
INSERT [dbo].[IBMPWarehouse] ([WarehouseID], [WarehouseCD], [Name], [LocationLineCntr], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID])VALUES (17, N'WH00002', N'Wholesale', 2, CAST(N'2022-02-22T06:03:55.630' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:18:39.540' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'2e4f8332-a593-ec11-a49e-f09e4a254edb')
SET IDENTITY_INSERT [dbo].[IBMPWarehouse] OFF
GO
SET IDENTITY_INSERT [dbo].[IBMPWarehouse] OFF
GO
SET IDENTITY_INSERT [dbo].[IBMPWarehouseLocation] ON
GO
INSERT [dbo].[IBMPWarehouseLocation] ([LocationID], [WarehouseID], [LocationCD], [Description], [LineNbr], [Address], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (19, 15, N'GAL001', N'Galle Retails', 1, N'Wackwella, Galle', CAST(N'2022-02-22T15:16:01.447' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:16:58.883' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'd63dae57-f293-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPWarehouseLocation] ([LocationID], [WarehouseID], [LocationCD], [Description], [LineNbr], [Address], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (20, 15, N'MAT001', N'Matara Retails', 2, N'Matara', CAST(N'2022-02-22T15:16:58.877' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:16:58.877' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'52b08a73-f293-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPWarehouseLocation] ([LocationID], [WarehouseID], [LocationCD], [Description], [LineNbr], [Address], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (23, 15, N'COL001', N'Colombo Retails', 3, N'Colombo 03', CAST(N'2022-02-22T15:48:07.170' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:48:07.170' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'bc107fd3-f693-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPWarehouseLocation] ([LocationID], [WarehouseID], [LocationCD], [Description], [LineNbr], [Address], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (21, 17, N'GAL002', N'Galle Wholesale', 1, N'Hapugala, Galle', CAST(N'2022-02-22T15:18:39.537' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:18:39.537' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'137a199e-f293-ec11-a49e-f09e4a254edb')
GO
INSERT [dbo].[IBMPWarehouseLocation] ([LocationID], [WarehouseID], [LocationCD], [Description], [LineNbr], [Address], [CreatedDateTime], [CreatedByID], [CreatedByScreenID], [LastModifiedDateTime], [LastModifiedByID], [LastModifiedByScreenID], [NoteID]) VALUES (22, 17, N'GAL003', N'Galle Wholesale', 2, N'Wackwella, Galle', CAST(N'2022-02-22T15:18:39.540' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', CAST(N'2022-02-22T15:18:39.540' AS DateTime), N'b5344897-037e-4d58-b5c3-1bdfd0f47bf9', N'IB201000', N'd2ebb3b5-f293-ec11-a49e-f09e4a254edb')
GO
SET IDENTITY_INSERT [dbo].[IBMPWarehouseLocation] OFF
GO
