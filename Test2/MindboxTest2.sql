SELECT COUNT(T.[customerid]), S.[productid]
FROM [dbo].[Sales]	S
LEFT JOIN 
	(SELECT 
		  MIN([datetime]) minDT
		 ,[customerid]
	FROM [dbo].[Sales]
	GROUP BY  [customerid]) T
ON  S.customerid = T.customerid 
AND S.[datetime] = T.minDT 
GROUP BY S.[productid]