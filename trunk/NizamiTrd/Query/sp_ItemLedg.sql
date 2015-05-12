
DECLARE @pDoc_Fiscal_ID int,
	@pFromDate Varchar(10), 
	@pToDate Varchar(10),
	@pItem_ID INT,
	@pItemGroup INT,
	@pAccountID INT,
	@pCountry INT,
	@pProvince INT, 
	@pCity INT 
	
	
set @pDoc_Fiscal_ID=1
set @pFromDate= '2012-07-01'
set @pToDate = '2013-12-30'
SET @pItem_ID=0
SET @pItemGroup=0
SET @pAccountID=0
SET @pCountry=0
SET @pProvince=0
SET @pCity=0

EXEC sp_ItemUnitLedgerShopItemCity @pDoc_Fiscal_ID, @pFromDate, @pToDate, @pItem_ID, 
	@pItemGroup, @pAccountID, @pCountry, @pProvince, @pCity

SELECT @pFromDate AS doc_date, 'Opening Balance' as doc_strid, 
	ga.ac_title, c.city_title, gp.province_title, gc.country_title,

	0 as ItemID, 'Opening Balance' as goodsitem_title, '' as goodsitem_st, 
	'Opening Balance' as Group_Title, '' AS Group_St,
	--gg.Group_title, gg.Group_st,
	g.Godown_title, ga.ac_strid AS Godown_ac_strID, Sum(isNull(td.Qty_In,0))-Sum(ISNULL(td.Qty_Out,0)) AS OpBalance, 
	Case when Sum(isNull(td.Qty_In,0))-Sum(ISNULL(td.Qty_Out,0))>=0 
		THEN Sum(isNull(td.Qty_In,0))-Sum(ISNULL(td.Qty_Out,0)) ELSE 0 END Qty_In,
	Case when Sum(isNull(td.Qty_In,0))-Sum(ISNULL(td.Qty_Out,0))<0 
		THEN Sum(isNull(td.Qty_In,0))-Sum(ISNULL(td.Qty_Out,0)) ELSE 0 END Qty_Out,
	--0 AS Qty_In, 0 AS Qty_Out, 
	0 AS Balance, u.goodsuom_st, 
	0 AS MeshTotal, 0 AS Bundle, 'Opening Balance' AS Narration, 0 AS SERIAL_NO, 
	'' as ItemNameDetail, '' as ItemQtyDetail, '' as ItemDescription
FROM inv_tran t INNER JOIN inv_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
	INNER JOIN gds_item gi ON gi.goodsitem_id=td.ItemID
	INNER JOIN gds_Group gg ON gg.Group_id=gi.Group_id
	INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id
	INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id
	INNER JOIN gl_ac ga ON g.Godown_ac_id=ga.ac_id
	
	left outer join gl_ac a on t.GLID=a.ac_id
	left outer join gl_ac a2 on t.GLID_Cr=a2.ac_id
	LEFT OUTER JOIN geo_city c ON c.city_id=a.ac_city_id
	LEFT OUTER JOIN geo_province gp ON gp.province_id=c.city_pid
	LEFT OUTER JOIN geo_country gc ON gc.country_id=gp.province_pid

	LEFT OUTER JOIN geo_city c2 ON c2.city_id=a2.ac_city_id
	LEFT OUTER JOIN geo_province gp2 ON gp2.province_id=c2.city_pid
	LEFT OUTER JOIN geo_country gc2 ON gc2.country_id=gp2.province_pid

	LEFT OUTER JOIN ALCP_ValidationDescription avd ON t.doc_vt_id=avd.DescID AND avd.ValidationId=69
	
WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID 
	AND t.doc_date < @pFromDate  
	AND (@pItemGroup>0 AND gi.Group_id=@pItemGroup OR @pItemGroup=0)
	AND (@pCountry>0 AND (gc.country_id=@pCountry OR gc2.country_id=@pCountry) OR @pCountry=0)
	AND (@pProvince>0 AND (gp.province_id=@pProvince OR gp2.province_id=@pProvince) OR @pProvince=0)
	AND (@pCity>0 AND (c.city_id=@pCity OR c2.city_id=@pCity) OR @pCity=0) 
	AND (@pAccountID>0 AND (t.GLID=@pAccountID OR t.GLID_Cr=@pAccountID) OR @pAccountID=0)
	AND (@pItem_ID>0 AND td.ItemID=@pItem_ID OR @pItem_ID=0)

GROUP BY --td.ItemID, gi.goodsitem_title, gi.goodsitem_st, gg.Group_title, gg.Group_st, OR @pGodown=0
	ga.ac_strid, g.Godown_title,u.goodsuom_st
--UNION 


SELECT t.doc_vt_id, t.doc_date, avd.Name + '-' + t.doc_strid AS Doc_StrID, 
	ga.ac_title, c.city_title, gp.province_title, gc.country_title,
	td.ItemID, gi.goodsitem_title, gi.goodsitem_st, gg.Group_title, 
	gg.Group_st + ' ' + gi.goodsitem_st as Group_st,
	td.GodownID, g.Godown_title, ga.ac_strid AS Godown_ac_strID, 
	0 AS OpBalance, td.Qty_In, td.Qty_Out, 0 AS Balance, 
	--isNull(td.Qty_In,0)- ISNULL(td.Qty_Out,0) AS Balance, 
	--Sum(isNull(td.Qty_In,0)) AS Qty_In,
	--Sum(ISNULL(td.Qty_Out,0)) AS Qty_Out, 0 AS Balance, 
	u.goodsuom_st, td.MeshTotal, td.Bundle, 
	CASE WHEN isNull(t.GLID,0)=0 AND isNull(t.GLID_Cr,0)=0 THEN td.Narration
		WHEN  isNull(t.GLID,0)>0 AND isNull(t.GLID_Cr,0)=0 THEN a.ac_title + ' ' + c.city_title
		WHEN  isNull(t.GLID,0)>0 AND isNull(t.GLID_Cr,0)>0 AND isNull(td.Qty_In,0)>0 
			THEN a.ac_title + ' ' + c.city_title
		WHEN  isNull(t.GLID,0)>0 AND isNull(t.GLID_Cr,0)>0 AND isNull(td.Qty_Out,0)>0 
			THEN a2.ac_title + ' ' + c2.city_title 
	END AS Narration, td.SERIAL_NO,
	 
	gg.Group_st + '' + gi.goodsitem_st as ItemNameDetail, 

	CASE WHEN td.isBundle=1 THEN ' Q=' + Cast(td.Bundle AS VARCHAR(12)) + u.goodsuom_st
	WHEN td.isMesh=1 THEN ' B=' + Cast(td.Bundle AS VARCHAR(12))
		+ ' x L=' + Cast((td.Length + (td.LenDec*0.0833)) AS VARCHAR(14)) 
		+ ' x W=' + CAST((td.Width + (td.WidDec*0.0833)) AS VARCHAR(14))
		+ ' Q= ' + CAST(td.Bundle * ((td.Width + (td.WidDec*0.0833)) * (td.Length + (td.LenDec*0.0833)))  
		AS VARCHAR(14)) + u.goodsuom_st
	ELSE CASE WHEN isNull(td.Bundle,0)>0 THEN ' B=' + Cast(td.Bundle AS VARCHAR(12)) ELSE '' END  
		+ ' Q=' + Cast(isNull(td.Qty_Out,0) AS VARCHAR(12)) + u.goodsuom_st
	END as ItemQtyDetail, 

	CASE WHEN td.isBundle=1 THEN gg.Group_st + '' + gi.goodsitem_st 
		--+ ' Q=' + Cast(td.Bundle AS VARCHAR(12)) + u.goodsuom_st
	WHEN td.isMesh=1 THEN  gg.Group_st + ' ' + gi.goodsitem_st + ' B=' + Cast(td.Bundle AS VARCHAR(12))
		+ ' x L=' + Cast((td.Length + (td.LenDec*0.0833)) AS VARCHAR(14)) 
		+ ' x W=' + CAST((td.Width + (td.WidDec*0.0833)) AS VARCHAR(14))
		+ ' = ' + CAST(td.Bundle * ((td.Width + (td.WidDec*0.0833)) * (td.Length + (td.LenDec*0.0833)))  
		AS VARCHAR(14)) + u.goodsuom_st
	ELSE gg.Group_st + ' ' + gi.goodsitem_st 
		--+ CASE WHEN isNull(td.Bundle,0)>0 THEN ' B=' + Cast(td.Bundle AS VARCHAR(12)) ELSE '' END  
		--+ ' Q=' + Cast(isNull(td.Qty_Out,0) AS VARCHAR(12)) + u.goodsuom_st
	END as ItemDescription 
--Sum(isNull(td.MeshTotal,0)) AS MeshTotal, Sum(ISNULL(td.Bundle,0)) AS Bundle
FROM inv_tran t INNER JOIN inv_trandtl td ON t.doc_vt_id=td.doc_vt_id
	AND t.doc_fiscal_id=td.doc_fiscal_id AND t.doc_id=td.doc_id
	INNER JOIN gds_item gi ON gi.goodsitem_id=td.ItemID
	INNER JOIN gds_Group gg ON gg.Group_id=gi.Group_id
	INNER JOIN gds_uom u ON td.UOMID=u.goodsuom_id
	INNER JOIN cmn_Godown g ON td.GodownID=g.Godown_id
	INNER JOIN gl_ac ga ON g.Godown_ac_id=ga.ac_id
	left outer join gl_ac a on t.GLID=a.ac_id
	left outer join gl_ac a2 on t.GLID_Cr=a2.ac_id
	LEFT OUTER JOIN geo_city c ON c.city_id=a.ac_city_id
	LEFT OUTER JOIN geo_province gp ON gp.province_id=c.city_pid
	LEFT OUTER JOIN geo_country gc ON gc.country_id=gp.province_pid

	LEFT OUTER JOIN geo_city c2 ON c2.city_id=a2.ac_city_id
	LEFT OUTER JOIN geo_province gp2 ON gp2.province_id=c2.city_pid
	LEFT OUTER JOIN geo_country gc2 ON gc2.country_id=gp2.province_pid

	LEFT OUTER JOIN ALCP_ValidationDescription avd ON t.doc_vt_id=avd.DescID AND avd.ValidationId=69

WHERE t.doc_fiscal_id=@pDoc_Fiscal_ID 
	AND t.doc_date BETWEEN @pFromDate AND @pToDate
	AND (@pItemGroup>0 AND gi.Group_id=@pItemGroup OR @pItemGroup=0)
	AND (@pCountry>0 AND (gc.country_id=@pCountry OR gc2.country_id=@pCountry) OR @pCountry=0)
	AND (@pProvince>0 AND (gp.province_id=@pProvince OR gp2.province_id=@pProvince) OR @pProvince=0)
	AND (@pCity>0 AND (c.city_id=@pCity OR c2.city_id=@pCity) OR @pCity=0) 
	AND (@pAccountID>0 AND (t.GLID=@pAccountID OR t.GLID_Cr=@pAccountID) OR @pAccountID=0)
	AND (@pItem_ID>0 AND td.ItemID=@pItem_ID OR @pItem_ID=0)
	AND t.doc_vt_id<>283 
	and (t.doc_vt_id=285 AND td.GodownID=1 OR t.doc_vt_id<>285)

/*	
SELECT * FROM geo_city 
SELECT * FROM geo_province 
SELECT * FROM geo_country 
*/