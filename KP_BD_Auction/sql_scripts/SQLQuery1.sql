USE tempdb  
CREATE TABLE T (IntCol int, XmlCol xml);  
GO  

INSERT INTO T(XmlCol)  
SELECT * FROM OPENROWSET(  
   BULK 'c:/P.xml',  
   SINGLE_BLOB) AS x; 
   
   SELECT * FROM T  
UPDATE T  
SET XmlCol =(  
SELECT * FROM OPENROWSET(  
   BULK 'c:/P.xml',  
           SINGLE_BLOB  
) AS x  
)  
WHERE IntCol = 1;  
GO  