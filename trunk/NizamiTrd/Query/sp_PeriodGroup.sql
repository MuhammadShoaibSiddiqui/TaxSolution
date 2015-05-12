

--/*
ALTER PROCEDURE [dbo].[sp_PeriodGroup]
	@pDoc_Fiscal_ID int,
	@pac_id INT, 
	@pFromDate VARCHAR(10), 
	@pToDate VARCHAR(10)
AS 
--*/

/*
DECLARE @pFromDate VARCHAR(10), @pToDate VARCHAR(10)
DECLARE @pac_id INT, @pDoc_Fiscal_ID INT --, @p_ac_strid VARCHAR(30), @p_ac_strtruncated VARCHAR(30), 

SET @pDoc_Fiscal_ID=1
SET @pac_id=226
SET @pFromDate='2012-09-01'
SET @pToDate = '2013-03-28' 
*/

SET NOCOUNT ON 

DECLARE @ac_id INT, @ac_strid VARCHAR(30), @ac_strtruncated VARCHAR(30)
DECLARE @ac_title VARCHAR(200), @ac_st VARCHAR(15), @ac_level INT, 
	@ac_stridParent VARCHAR(30), @ac_titleParent VARCHAR(100)

DECLARE @OpRunBal MONEY, @Op_DEBIT MONEY, @Op_CREDIT MONEY, @DEBIT MONEY, @CREDIT MONEY, 
    @Balance MONEY, @SERIAL_NO BIGINT

SET @SERIAL_NO=1
DECLARE @strac_get AS VARCHAR(30)

CREATE TABLE #tmpTable
(
	ac_stridParent VARCHAR(20), 
	ac_titleParent VARCHAR(60),
    AC_ID bigint, 
    ac_strid VARCHAR(20),
    ac_title VARCHAR(200),
    OpRunBal MONEY,
    Op_DEBIT MONEY, 
    Op_CREDIT MONEY, 
    DEBIT MONEY, 
    CREDIT MONEY, 
    Bal_Debit MONEY,
    Bal_Credit MONEY,
    Balance MONEY, 
    SERIAL_NO BIGINT
)

SELECT @ac_id=ac_id, @ac_strid=ac_strid, @ac_stridParent=ac_strid, 
	@ac_titleParent=ac_title, @ac_level=ac_level
  FROM gl_ac WHERE ac_id=@pac_id

--@ac_strtruncated=ac_strtruncated,
SELECT @ac_strtruncated= CASE WHEN Right(@ac_strid,12)='0-00-00-0000' THEN Left(@ac_strid,1) 
	WHEN  Right(@ac_strid,10)='00-00-0000' THEN Left(@ac_strid,3) 
	WHEN  Right(@ac_strid,7)='00-0000' THEN Left(@ac_strid,6)
	WHEN  Right(@ac_strid,4)='0000' THEN Left(@ac_strid,9)
	ELSE '' END 
	
PRINT @ac_strtruncated

SET @strac_get = LEFT(@ac_strid, LEN(@ac_strtruncated))
PRINT @strac_get

DECLARE cur_gl_ac CURSOR FOR 
SELECT g.ac_id, g.ac_title + ' ' + g.ac_st + ' ' + c.city_title AS Ac_Title, g.ac_st, g.ac_strid
  FROM gl_ac g INNER JOIN geo_city c ON g.ac_city_id=c.city_id 
WHERE LEFT(g.ac_strid, LEN(@ac_strtruncated))=@strac_get
	AND g.istran=1
ORDER BY g.ac_strid 

OPEN cur_gl_ac

FETCH NEXT FROM cur_gl_ac INTO @ac_id, @ac_title, @ac_st, @ac_strid
WHILE @@FETCH_STATUS=0
BEGIN
	
	SET @OpRunBal=0
	SET @DEBIT=0
	SET @CREDIT=0
	
	SELECT @OpRunBal = (SELECT ISNULL(Sum(isNull(td.DEBIT,0)- ISNULL(td.CREDIT,0)),0) 
	FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
		AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
	WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID
		AND td.AC_ID=@Ac_ID
		AND t.doc_date < @pFromDate) 

	SELECT @DEBIT= isNull(Sum(isNull(td.DEBIT,0)),0), @CREDIT= isNull(Sum(ISNULL(td.CREDIT,0)),0)
	FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
		AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
	WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID
		AND td.AC_ID=@Ac_ID
		AND t.doc_date BETWEEN @pFromDate AND @pToDate 

	--SET @Balance=0

	INSERT INTO #tmpTable
		(ac_strIDParent, ac_titleParent, AC_ID, ac_strid, ac_title, 
		OpRunBal, Op_DEBIT, Op_CREDIT, DEBIT, CREDIT, 
		Bal_Debit, Bal_Credit, Balance, SERIAL_NO)
	VALUES (@ac_stridParent, @ac_titleParent, @ac_id, @ac_strid, @ac_title, 
		@OpRunBal, 
		CASE WHEN @OpRunBal>=0 THEN @OpRunBal ELSE 0 END, 
		CASE WHEN @OpRunBal<0 THEN Abs(@OpRunBal) ELSE 0 END, 
		@DEBIT, @CREDIT, 
		CASE WHEN (@OpRunBal + @DEBIT - @CREDIT)>0 
			THEN @OpRunBal + @DEBIT - @CREDIT ELSE 0 END,
		CASE WHEN (@OpRunBal + @DEBIT - @CREDIT)<0 
			THEN abs(@OpRunBal + @DEBIT - @CREDIT) ELSE 0 END,
		@OpRunBal + @DEBIT - @CREDIT, @SERIAL_NO)	
	
	FETCH NEXT FROM cur_gl_ac INTO @ac_id, @ac_title, @ac_st, @ac_strid
	
	SET @SERIAL_NO=@SERIAL_NO+1
END 

CLOSE cur_gl_ac
DEALLOCATE cur_gl_ac

SELECT * FROM #tmpTable WHERE Bal_Debit>0 OR Bal_Credit>0
DROP TABLE #tmpTable

--Second Image Table Get
select ID, Name, Photo from Photos where id=28;
SET NOCOUNT OFF

--SELECT * FROM gl_ac ORDER BY ac_strid


GO


