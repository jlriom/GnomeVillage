CREATE TABLE [dbo].[HabitantProfessions] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [HabitantId]   INT              NOT NULL,
    [ProfessionId] NCHAR (200)      NOT NULL,
    CONSTRAINT [PK_HabitantProfessions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HabitantProfessions_Habitant] FOREIGN KEY ([HabitantId]) REFERENCES [dbo].[Habitant] ([Id]),
    CONSTRAINT [FK_HabitantProfessions_Professions] FOREIGN KEY ([ProfessionId]) REFERENCES [dbo].[Professions] ([Name])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HabitantProfessions]
    ON [dbo].[HabitantProfessions]([HabitantId] ASC, [ProfessionId] ASC);

