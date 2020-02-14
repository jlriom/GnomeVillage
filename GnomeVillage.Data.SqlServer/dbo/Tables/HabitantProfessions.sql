CREATE TABLE [dbo].[HabitantProfessions] (
    [Id]           UNIQUEIDENTIFIER CONSTRAINT [DF_HabitantProfessions_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [HabitantId]   INT              NOT NULL,
    [ProfessionId] NVARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_HabitantProfessions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HabitantProfessions_Habitant] FOREIGN KEY ([HabitantId]) REFERENCES [dbo].[Habitant] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_HabitantProfessions_Professions] FOREIGN KEY ([ProfessionId]) REFERENCES [dbo].[Profession] ([Name]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HabitantProfessions]
    ON [dbo].[HabitantProfessions]([HabitantId] ASC, [ProfessionId] ASC);

