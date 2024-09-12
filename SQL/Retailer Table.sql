DROP TABLE [marketParties].[Retailer]

CREATE TABLE [marketParties].[Retailer](
	[ReId] [int] IDENTITY(1,1) NOT NULL,
	[ReName] [varchar](100) NOT NULL,
	[Country] [varchar](2) NOT NULL,
	[CodingScheme] [varchar](3) NOT NULL,
	[ReCode] [varchar](20) NOT NULL,
	[UTCCreatedDateTime] [datetime2] DEFAULT getdate() NOT NULL,
	[UTCUpdatedDateTime] [datetime2] DEFAULT getdate() NOT NULL)
