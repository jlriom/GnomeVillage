CREATE TABLE [dbo].[Habitant] (
    [Id]          INT             IDENTITY (1000, 1) NOT NULL,
    [Name]        NVARCHAR (200)  NOT NULL,
    [Thumbnail]   NVARCHAR (2000) NOT NULL,
    [Age]         INT             NOT NULL,
    [Weight]      DECIMAL (5, 2)  CONSTRAINT [DF_Habitant_Weight] DEFAULT ((0)) NOT NULL,
    [Height]      DECIMAL (5, 2)  CONSTRAINT [DF_Habitant_Height] DEFAULT ((0)) NOT NULL,
    [HairColorId] NVARCHAR (200)  NOT NULL,
    CONSTRAINT [PK_Habitant] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Habitant_HairColors] FOREIGN KEY ([HairColorId]) REFERENCES [dbo].[HairColor] ([Name])
);

