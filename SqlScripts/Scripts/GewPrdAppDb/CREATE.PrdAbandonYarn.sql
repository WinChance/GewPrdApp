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
EXEC sp_addextendedproperty N'MS_Description', N'准备PY废纱表', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'部门', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Department'
GO
EXEC sp_addextendedproperty N'MS_Description', N'工序', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Process'
GO
EXEC sp_addextendedproperty N'MS_Description', N'班别', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'WorkerClass'
GO
EXEC sp_addextendedproperty N'MS_Description', N'类型', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Type'
GO
EXEC sp_addextendedproperty N'MS_Description', N'废纱重', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Weight'
GO
EXEC sp_addextendedproperty N'MS_Description', N'操作工', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'Operator'
GO
EXEC sp_addextendedproperty N'MS_Description', N'日期', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'YieldDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'操作时间', 'SCHEMA', N'dbo', 'TABLE', N'PrdAbandonYarn', 'COLUMN', N'InputTime'
GO
