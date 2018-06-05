USE [OnlineBus]
GO

/******Script Date: 04-Jun-18 9:17:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--CREATE TABLE SCRIPT
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'BookingTicket' )
BEGIN	
CREATE TABLE [dbo].[BookingTicket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeatName] [nvarchar](50) NOT NULL,
	[DateWiseTripId] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
	[IsTempLocked] [bit] NULL,
	[IsBooked] [bit] NULL,
	[IsActive] [int] NULL,
	[IsDeleted] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_BookingTicket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'BusOperator' )
BEGIN
CREATE TABLE [dbo].[BusOperator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_BusOperator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'DateWiseTrip' )
BEGIN
CREATE TABLE [dbo].[DateWiseTrip](
	[Id] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[TripBaseId] [int] NOT NULL,
	[NoOfSeat] [int] NOT NULL,
	[Fare] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_DateWiseTrip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'IntermediateRoute' )
BEGIN
CREATE TABLE [dbo].[IntermediateRoute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BoardingTime] [time](7) NOT NULL,
	[RouteId] [int] NOT NULL,
	[RoutePointId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_IntermediateRoute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END


GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'OperatorRouteMap' )
BEGIN
CREATE TABLE [dbo].[OperatorRouteMap](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusOperatorId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_OperatorRouteMap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'Route' )
BEGIN
CREATE TABLE [dbo].[Route](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[From] [nvarchar](50) NOT NULL,
	[To] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'RoutePoint' )
BEGIN
CREATE TABLE [dbo].[RoutePoint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_RoutePoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'SeatBase' )
BEGIN
CREATE TABLE [dbo].[SeatBase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeatName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_SeatBase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'Ticket' )
BEGIN
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CellNo] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[TotalFare] [nvarchar](50) NOT NULL,
	[Seats] [nvarchar](50) NOT NULL,
	[TicketPIN] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'TripBase' )
BEGIN
CREATE TABLE [dbo].[TripBase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[BusType] [nvarchar](50) NOT NULL,
	[BusOperatorId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_TripBase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'User' )
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

--ALTER TABLES
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.columns WHERE table_name = 'Route' AND column_name = 'BusOperatorId')
	ALTER TABLE dbo.Route ADD BusOperatorId INT NOT NULL

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.columns WHERE table_name = 'DateWiseTrip' AND column_name = 'BusOperatorId')
	ALTER TABLE dbo.DateWiseTrip ADD BusOperatorId INT NOT NULL

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.columns WHERE table_name = 'BookingTicket' AND column_name = 'BusOperatorId')
	ALTER TABLE dbo.BookingTicket ADD BusOperatorId INT NOT NULL

GO


/*ALTER TABLE [dbo].[BookingTicket]  WITH CHECK ADD  CONSTRAINT [FK_BookingTicket_DateWiseTrip] FOREIGN KEY([DateWiseTripId])
REFERENCES [dbo].[DateWiseTrip] ([Id])
GO

ALTER TABLE [dbo].[BookingTicket] CHECK CONSTRAINT [FK_BookingTicket_DateWiseTrip]
GO

ALTER TABLE [dbo].[BookingTicket]  WITH CHECK ADD  CONSTRAINT [FK_BookingTicket_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([Id])
GO

ALTER TABLE [dbo].[BookingTicket] CHECK CONSTRAINT [FK_BookingTicket_Ticket]
GO
ALTER TABLE [dbo].[TripBase]  WITH CHECK ADD  CONSTRAINT [FK_TripBase_BusOperator] FOREIGN KEY([BusOperatorId])
REFERENCES [dbo].[BusOperator] ([Id])
GO

ALTER TABLE [dbo].[TripBase] CHECK CONSTRAINT [FK_TripBase_BusOperator]
GO

ALTER TABLE [dbo].[TripBase]  WITH CHECK ADD  CONSTRAINT [FK_TripBase_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO

ALTER TABLE [dbo].[TripBase] CHECK CONSTRAINT [FK_TripBase_Route]
GO
ALTER TABLE [dbo].[OperatorRouteMap]  WITH CHECK ADD  CONSTRAINT [FK_OperatorRouteMap_BusOperator] FOREIGN KEY([BusOperatorId])
REFERENCES [dbo].[BusOperator] ([Id])
GO

ALTER TABLE [dbo].[OperatorRouteMap] CHECK CONSTRAINT [FK_OperatorRouteMap_BusOperator]
GO

ALTER TABLE [dbo].[OperatorRouteMap]  WITH CHECK ADD  CONSTRAINT [FK_OperatorRouteMap_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO

ALTER TABLE [dbo].[OperatorRouteMap] CHECK CONSTRAINT [FK_OperatorRouteMap_Route]
GO
ALTER TABLE [dbo].[DateWiseTrip]  WITH CHECK ADD  CONSTRAINT [FK_DateWiseTrip_TripBase] FOREIGN KEY([TripBaseId])
REFERENCES [dbo].[TripBase] ([Id])
GO

ALTER TABLE [dbo].[DateWiseTrip] CHECK CONSTRAINT [FK_DateWiseTrip_TripBase]
GO
ALTER TABLE [dbo].[IntermediateRoute]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateRoute_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO

ALTER TABLE [dbo].[IntermediateRoute] CHECK CONSTRAINT [FK_IntermediateRoute_Route]
GO

ALTER TABLE [dbo].[IntermediateRoute]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateRoute_RoutePoint] FOREIGN KEY([RoutePointId])
REFERENCES [dbo].[RoutePoint] ([Id])
GO

ALTER TABLE [dbo].[IntermediateRoute] CHECK CONSTRAINT [FK_IntermediateRoute_RoutePoint]
GO*/