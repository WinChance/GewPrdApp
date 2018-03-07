-- =============================================
-- Author:		HuangYoC
-- Create date: 17-04-28
-- Description:	通用方式，返回下拉列表数据
-- =============================================
ALTER PROCEDURE [dbo].[usp_peAppDropDownListGet]
	(@param1 NVARCHAR(20)='',@param2 NVARCHAR(20) ='',@param3 NVARCHAR(20)='',@param4 NVARCHAR(20)='',@param5 NVARCHAR(20)='',@rtn INT OUTPUT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @rtnDropDownList TABLE
                    (
					  id INT IDENTITY,
                      picurl NVARCHAR(20),  
					  code NVARCHAR(20),
					  text NVARCHAR(30),
					  dest1 NVARCHAR(20),
					  dest2 NVARCHAR(20),
					  dest3 NVARCHAR(20)
                    );			
	IF(@param1='班别')
	BEGIN

		INSERT INTO @rtnDropDownList(
	          picurl ,
	          code ,
	          text ,
	          dest1 ,
	          dest2 ,
	          dest3
	        ) SELECT  '','',a.No,'','','' FROM  GewPrdAppDB.Dbo.UDF_ConvertStrToTable('A1,A2,B1,B2,C1,C2,D',',') AS a 
	END
	ELSE IF(@param1='姓名')
	BEGIN
	-- 织布返回姓名+员工号，以处理重名的情况
	IF(@param4='织布')
    BEGIN
    	INSERT INTO @rtnDropDownList(
	          picurl ,
	          code ,
	          text ,
	          dest1 ,
	          dest2 ,
	          dest3
	        ) SELECT  '',a.cardno,a.name+' '+a.cardno,'','','' FROM dbo.peAppWvWorker AS a WHERE a.factory=@param2 AND a.class LIKE '%'+@param3+'%' AND a.WorkerType =@param4  ORDER BY a.name
    END
	ELSE
    BEGIN
    	INSERT INTO @rtnDropDownList(
	          picurl ,
	          code ,
	          text ,
	          dest1 ,
	          dest2 ,
	          dest3
	        ) SELECT   '',a.cardno,a.name,'','','' FROM dbo.peAppWvWorker AS a WHERE a.factory=@param2 AND a.class LIKE '%'+@param3+'%' AND a.WorkerType =@param4 ORDER BY a.name
    END
		
	END
	ELSE IF(@param1='原因')
	BEGIN

		INSERT INTO @rtnDropDownList( 
	          picurl ,
	          code ,
	          text ,
	          dest1 ,
	          dest2 ,
	          dest3
	        ) SELECT '',a.code,a.type+' - '+a.itemname,a.value1,a.value2,a.type FROM dbo.peAppWvRule  AS a WHERE a.WorkerType=@param4 ORDER BY a.type,a.itemname ASC
	END
	SET @rtn=1;
	SELECT * FROM @rtnDropDownList ORDER BY id --,dest3

	DELETE @rtnDropDownList

	
END









