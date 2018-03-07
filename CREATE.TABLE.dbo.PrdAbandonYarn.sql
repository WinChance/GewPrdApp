USE [WVMDB]
GO

/****** Object:  Table [dbo].[PrdAbandonYarn]    Script Date: 2017-09-21 16:21:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PrdAbandonYarn](
	[Iden] [INT] IDENTITY(1,1) NOT NULL,
	[Department] [VARCHAR](10) NULL,
	[Process] [VARCHAR](10) NULL,
	[WorkerClass] [VARCHAR](2) NULL,
	[Type] [VARCHAR](10) NULL,
	[Weight] [DECIMAL](18, 2) NULL,
	[Operator] [NVARCHAR](10) NULL,
	[OperateDate] [DATE] NULL,
	[OperateTime] [DATETIME] NOT NULL,
 CONSTRAINT [PK_PrdAppAbandonYarn] PRIMARY KEY CLUSTERED 
(
	[Iden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PrdAbandonYarn] ADD  CONSTRAINT [DF_PrdAppAbandonYarn_OperateTime]  DEFAULT (GETDATE()) FOR [OperateTime]
GO

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'׼��PY��ɴ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn'

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'Department' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'Process' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'WorkerClass' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'Type' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɴ��' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'Weight' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'Operator' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'OperateDate' 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' ,  
@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PrdAbandonYarn',
@level2type=N'COLUMN',@level2name=N'OperateTime' 