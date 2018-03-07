SELECT DISTINCT a.usercode,b.name,c.text,c.code AS code,d.Audit, d.factory INTO #TempTb FROM [dbo].[peAppWvUserMenu] AS a INNER JOIN [dbo].[peAppWvUser] AS b ON a.usercode=b.code INNER JOIN [dbo].[peAppWvMenu] AS c ON a.menucode=c.code  INNER JOIN [dbo].[peAppWvWorker] AS d ON a.usercode=d.cardno --ORDER BY d.factory,b.name,c.code

SELECT * FROM #TempTb ORDER BY factory,Audit,name,code

SELECT  DISTINCT A.Audit AS '是否有审核权限（Y:是,N:否）',a.usercode AS '员工号',a.name AS '姓名'
      ,STUFF((SELECT DISTINCT ','+ text FROM [dbo].#TempTb WHERE usercode = A.usercode FOR XML PATH('')

                        )
                        ,1,1,''

                  )AS '权限',a.factory AS '工厂'

  FROM [dbo].#TempTb AS A ORDER BY A.factory,A.Audit,A.name

DROP TABLE #TempTb



select top * from 