/*
ALTER PROCEDURE sp_MfgSum
	@pDoc_Fiscal_ID int,
	@pFromDate Varchar(10), 
	@pToDate Varchar(10), 
	@pAc_ID INT, 
	@pDoc_Vt_ID_Ext INT, 
	@pDoc_Vt_ID_Mfg int  
AS 
*/
--/*
DECLARE @pDoc_Fiscal_ID int,
	@pFromDate Varchar(10), 
	@pToDate Varchar(10), 
	@pAc_ID INT, 
	@pDoc_Vt_ID_Ext INT, 
	@pDoc_Vt_ID_Mfg int  
 
	set @pDoc_Fiscal_ID=1
	set @pFromDate='2012-10-01'
	set @pToDate = '2012-10-31'
	SET @pAc_ID =141
	SET @pDoc_Vt_ID_Ext = 288
	SET @pDoc_Vt_ID_Mfg = 286
--*/
DECLARE @OpeningDebit FLOAT, @OpeningCredit FLOAT, @OpeningBalance FLOAT,
	@WholeDebit FLOAT, @WholeCredit FLOAT, @WholeBalance FLOAT,
	@ExtraDebit FLOAT, @ExtraCredit FLOAT, @ExtraBalance FLOAT,
	@MfgDebit FLOAT, @MfgCredit FLOAT, @MfgBalance FLOAT,
	@WasteDebit FLOAT, @WasteCredit FLOAT, @WasteBalance FLOAT

SELECT @OpeningDebit = Sum(isNull(td.DEBIT,0)), @OpeningCredit= Sum(ISNULL(td.CREDIT,0)),
       @OpeningBalance = Sum(isNull(td.DEBIT,0)) - Sum(ISNULL(td.CREDIT,0))  
FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID 
	AND td.AC_ID=@pAc_ID
	AND t.doc_date < @pFromDate  

SELECT @WholeDebit= Sum(isNull(td.DEBIT,0)), @WholeCredit = Sum(ISNULL(td.CREDIT,0)),
       @WholeBalance = Sum(isNull(td.DEBIT,0)) - Sum(ISNULL(td.CREDIT,0))   
FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID 
	AND td.AC_ID=@pAc_ID
	AND t.doc_date BETWEEN @pFromDate AND @pToDate 

SELECT @ExtraDebit = ISNULL(Sum(isNull(td.DEBIT,0)),0), 
	@ExtraCredit = IsNull(Sum(ISNULL(td.CREDIT,0)),0),
    @ExtraBalance = ISNULL(Sum(isNull(td.DEBIT,0)) - Sum(ISNULL(td.CREDIT,0)),0)  
FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID AND t.doc_vt_id=@pDoc_Vt_ID_Ext
	AND td.AC_ID=@pAc_ID
	AND t.doc_date BETWEEN @pFromDate AND @pToDate 

SELECT @MfgDebit = Sum(isNull(td.DEBIT,0)), @MfgCredit = Sum(ISNULL(td.CREDIT,0)),
       @MfgBalance = Sum(isNull(td.DEBIT,0)) - Sum(ISNULL(td.CREDIT,0))   
FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID AND t.doc_vt_id=@pDoc_Vt_ID_Mfg
	AND td.AC_ID=@pAc_ID AND Left(td.NARRATION,5) <> 'Waste'
	AND t.doc_date BETWEEN @pFromDate AND @pToDate 

SELECT @WasteDebit = Sum(isNull(td.DEBIT,0)), @WasteCredit = Sum(ISNULL(td.CREDIT,0)),
       @WasteBalance = Sum(isNull(td.DEBIT,0)) - Sum(ISNULL(td.CREDIT,0))   
FROM gl_tran t INNER JOIN gl_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID AND t.doc_vt_id=@pDoc_Vt_ID_Mfg
	AND td.AC_ID=@pAc_ID AND Left(td.NARRATION,5) = 'Waste'
	AND t.doc_date BETWEEN @pFromDate AND @pToDate 

SELECT @OpeningDebit AS OpeningDebit, @OpeningCredit AS OpeningCredit, 
	@OpeningBalance AS OpeningBalance,
	@MfgDebit AS MfgDebit, @MfgCredit AS MfgCredit, @MfgBalance AS MfgBalance,
	@ExtraDebit AS ExtraDebit, @ExtraCredit AS ExtraCredit, 
	@ExtraBalance AS ExtraBalance,
	@OpeningBalance + @MfgBalance + @ExtraBalance AS SubTotal,
	@WasteDebit AS WasteDebit, @WasteCredit AS WasteCredit, 
	@WasteBalance AS WasteBalance, 
	(@OpeningBalance + @MfgBalance + @ExtraBalance) - @WasteBalance AS TotalAmount,
	@WholeBalance - (@MfgBalance + @WasteBalance) AS PaidAmount,
	@WholeDebit AS WholeDebit, @WholeCredit AS WholeCredit, 
	@WholeBalance AS WholeBalance

