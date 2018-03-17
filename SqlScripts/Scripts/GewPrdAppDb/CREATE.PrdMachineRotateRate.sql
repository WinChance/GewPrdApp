USE WVMDB

CREATE TABLE [dbo].[PrdMachineRotateRate]
(
[Iden] [int] NOT NULL IDENTITY(1, 1),
[Department] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[Process] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[WorkerClass] [varchar] (2) COLLATE Chinese_PRC_CI_AS NULL,
[Machine] [varchar] (5) COLLATE Chinese_PRC_CI_AS NULL,
[Begin] [int] NOT NULL,
[End] [int] NOT NULL,
[RotateDuration] [int] NOT NULL,
[Operator] [nvarchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[YieldDate] [date] NULL,
[InputTime] [datetime] NOT NULL CONSTRAINT [DF_PrdMachineRotateRate_OperateTime] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PrdMachineRotateRate] ADD CONSTRAINT [PK_PrdMachineRotateRate] PRIMARY KEY CLUSTERED  ([Iden]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'׼����̨�����ʼ�¼��', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'Department'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'Process'
GO
EXEC sp_addextendedproperty N'MS_Description', N'���', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'WorkerClass'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��̨��', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'Machine'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʼ����', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'Begin'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��������', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'End'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ת��������', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'RotateDuration'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'Operator'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'YieldDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'PrdMachineRotateRate', 'COLUMN', N'InputTime'
GO