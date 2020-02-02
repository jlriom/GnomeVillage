CREATE TABLE [dbo].[HabitantFriends] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [HabitantId] INT              NOT NULL,
    [FriendId]   INT              NOT NULL,
    CONSTRAINT [PK_HabitantFriends] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HabitantFriends_Habitant] FOREIGN KEY ([HabitantId]) REFERENCES [dbo].[Habitant] ([Id]),
    CONSTRAINT [FK_HabitantFriends_Habitant1] FOREIGN KEY ([FriendId]) REFERENCES [dbo].[Habitant] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HabitantFriends]
    ON [dbo].[HabitantFriends]([HabitantId] ASC, [FriendId] ASC);

