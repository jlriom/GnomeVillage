CREATE TABLE [dbo].[Habitant] (
    [Id]          INT          NOT NULL,
    [Name]        NCHAR (200)  NOT NULL,
    [Thumbnail]   NCHAR (2000) NOT NULL,
    [Age]         INT          NOT NULL,
    [Weight]      INT          NOT NULL,
    [HairColorId] NCHAR (200)  NOT NULL,
    CONSTRAINT [PK_Habitant] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Habitant_HairColors] FOREIGN KEY ([HairColorId]) REFERENCES [dbo].[HairColors] ([Name])
);

