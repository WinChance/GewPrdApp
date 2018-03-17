CREATE TABLE [dbo].[PrdAbandonYarn]
(
[Iden] [int] NOT NULL IDENTITY(1, 1),
[Department] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[Process] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[WorkerClass] [varchar] (2) COLLATE Chinese_PRC_CI_AS NULL,
[Type] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[Weight] [decimal] (18, 2) NULL,
[Operator] [nvarchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[YieldDate] [date] NULL,
[InputTime] [datetime] NOT NULL CONSTRAINT [DF_PrdAppAbandonYarn_OperateTime] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PrdAbandonYarn] ADD CONSTRAINT [PK_PrdAppAbandonYarn] PRIMARY KEY CLUSTERED  ([Iden]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'׼��PY��ɴ��', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Department'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Process'
GO
EXEC sp_addextendedproperty N'MS_Description', N'���', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'WorkerClass'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Type'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ɴ��', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Weight'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Operator'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'YieldDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'InputTime'
GO
