SELECT DISTINCT a.usercode,b.name,c.text,c.code AS code,d.Audit, d.factory INTO #TempTb FROM [dbo].[peAppWvUserMenu] AS a INNER JOIN [dbo].[peAppWvUser] AS b ON a.usercode=b.code INNER JOIN [dbo].[peAppWvMenu] AS c ON a.menucode=c.code  INNER JOIN [dbo].[peAppWvWorker] AS d ON a.usercode=d.cardno --ORDER BY d.factory,b.name,c.code

SELECT * FROM #TempTb ORDER BY factory,Audit,name,code

SELECT  DISTINCT A.Audit AS '�Ƿ������Ȩ�ޣ�Y:��,N:��',a.usercode AS 'Ա����',a.name AS '����'
      ,STUFF((SELECT DISTINCT ','+ text FROM [dbo].#TempTb WHERE usercode = A.usercode FOR XML PATH('')

                        )
                        ,1,1,''

                  )AS 'Ȩ��',a.factory AS '����'

  FROM [dbo].#TempTb AS A ORDER BY A.factory,A.Audit,A.name

DROP TABLE #TempTb



select top * from 