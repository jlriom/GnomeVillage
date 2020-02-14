CREATE TABLE [dbo].[HabitantFriends] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_HabitantFriends_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [HabitantId] INT              NOT NULL,
    [FriendId]   INT              NOT NULL,
    CONSTRAINT [PK_HabitantFriends] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HabitantFriends_Habitant] FOREIGN KEY ([HabitantId]) REFERENCES [dbo].[Habitant] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_HabitantFriends_Habitant1] FOREIGN KEY ([FriendId]) REFERENCES [dbo].[Habitant] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HabitantFriends]
    ON [dbo].[HabitantFriends]([HabitantId] ASC, [FriendId] ASC);

