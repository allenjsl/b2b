GO
/****** Object:  View [dbo].[View_PayRemind_GetList]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PayRemind_GetList]'))
DROP VIEW [dbo].[View_PayRemind_GetList]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenShangPin_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenShangPin_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenShangPin_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanChuPiao_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_GetGuanLianKongWeiXianLu]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_GetGuanLianKongWeiXianLu]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_GetGuanLianKongWeiXianLu]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_SetStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_SetStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanDiJie_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrderHotel_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_SheZhiZhuangTai]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_SheZhiZhuangTai]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_SheZhiZhuangTai]
GO
/****** Object:  View [dbo].[view_Fin_TuanDuiJieSuan]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_TuanDuiJieSuan]'))
DROP VIEW [dbo].[view_Fin_TuanDuiJieSuan]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenDingDan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_XianLuDingDan_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_XianLuDingDan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_XianLuDingDan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrder_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrder_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_XiaoZhang]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_XiaoZhang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_DengZhang_XiaoZhang]
GO
/****** Object:  View [dbo].[view_Fin_YiXiaoZhang]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YiXiaoZhang]'))
DROP VIEW [dbo].[view_Fin_YiXiaoZhang]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_YongHu_JiFen_Handler]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_YongHu_JiFen_Handler]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_YongHu_JiFen_Handler]
GO
/****** Object:  StoredProcedure [dbo].[SQLPlan_Tour]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLPlan_Tour]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SQLPlan_Tour]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_KongWeiCode]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_KongWeiCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_KongWeiCode]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_PiaoCode]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PiaoCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_PiaoCode]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_UpdateStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_UpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_UpdateStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TourOrderHotelCode]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_TourOrderHotelCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_TourOrderHotelCode]
GO
/****** Object:  View [dbo].[view_News]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_News]'))
DROP VIEW [dbo].[view_News]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ValidUserLevDepartManagers]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_ValidUserLevDepartManagers]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_ValidUserLevDepartManagers]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TourCode]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_TourCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_TourCode]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_HotelJiaoYiHao]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_HotelJiaoYiHao]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_HotelJiaoYiHao]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenShangPin_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenShangPin_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenShangPin_D]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Pt_CreateJiFenShangPinBianMa]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Pt_CreateJiFenShangPinBianMa]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Pt_CreateJiFenShangPinBianMa]
GO
/****** Object:  StoredProcedure [dbo].[proc_AttendanceInfo_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_AttendanceInfo_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_AttendanceInfo_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_AttendanceInfo_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_AttendanceInfo_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_AttendanceInfo_Insert]
GO
/****** Object:  View [dbo].[View_AttendanceInfo]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_AttendanceInfo]'))
DROP VIEW [dbo].[View_AttendanceInfo]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkExchange_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkExchange_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkExchange_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkExchange_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkExchange_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkExchange_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_UpdateMxs]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_UpdateMxs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_FaPiao_UpdateMxs]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_FaPiao_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_FaPiao_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Check]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Check]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Check]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhanDian_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhanDian_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhanDian_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanDiJie_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_GongZi_SetStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_GongZi_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_GongZi_SetStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanChuPiao_Update]
GO
/****** Object:  View [dbo].[view_PlanDiJie]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_PlanDiJie]'))
DROP VIEW [dbo].[view_PlanDiJie]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_SetOrderJinE]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_SetOrderJinE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_SetOrderJinE]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWeiYajin]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWeiYajin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWeiYajin]
GO
/****** Object:  View [dbo].[view_Fin_YaJin]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YaJin]'))
DROP VIEW [dbo].[view_Fin_YaJin]
GO
/****** Object:  View [dbo].[view_Pt_KongWeiXianLu]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_KongWeiXianLu]'))
DROP VIEW [dbo].[view_Pt_KongWeiXianLu]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_ChongDi]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_ChongDi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_DengZhang_ChongDi]
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLeave_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_UserLeave_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_UserLeave_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLeave_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_UserLeave_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_UserLeave_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianLeiBie_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianLeiBie_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianLeiBie_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhanDian_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhanDian_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhanDian_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianLeiBie_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianLeiBie_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianLeiBie_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_RiJiZhang_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_RiJiZhang_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_RiJiZhang_Insert]
GO
/****** Object:  View [dbo].[view_KongWeiYajin]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_KongWeiYajin]'))
DROP VIEW [dbo].[view_KongWeiYajin]
GO
/****** Object:  View [dbo].[view_Fin_YingFuJiaoTong]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuJiaoTong]'))
DROP VIEW [dbo].[view_Fin_YingFuJiaoTong]
GO
/****** Object:  View [dbo].[view_Fin_YingFuDiJie]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuDiJie]'))
DROP VIEW [dbo].[view_Fin_YingFuDiJie]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Sys_Create]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Sys_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Sys_Create]
GO
/****** Object:  StoredProcedure [dbo].[proc_Wage_Set]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Wage_Set]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Wage_Set]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanDiJie_Update]
GO
/****** Object:  View [dbo].[view_Fin_KongWeiZhiChu]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_KongWeiZhiChu]'))
DROP VIEW [dbo].[view_Fin_KongWeiZhiChu]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrderHotel_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_D]
GO
/****** Object:  StoredProcedure [dbo].[SQLPlan_TourOrderSaveSeat]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLPlan_TourOrderSaveSeat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SQLPlan_TourOrderSaveSeat]
GO
/****** Object:  StoredProcedure [dbo].[proc_WeiHuKongWeiStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WeiHuKongWeiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WeiHuKongWeiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Route_Delete]
GO
/****** Object:  View [dbo].[view_Fin_YingFuJiuDian]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuJiuDian]'))
DROP VIEW [dbo].[view_Fin_YingFuJiuDian]
GO
/****** Object:  View [dbo].[view_TongJi_JiFenFaFangMingXi]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TongJi_JiFenFaFangMingXi]'))
DROP VIEW [dbo].[view_TongJi_JiFenFaFangMingXi]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkReport_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkReport_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkReport_Add]
GO
/****** Object:  View [dbo].[view_Pt_KongWei]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_KongWei]'))
DROP VIEW [dbo].[view_Pt_KongWei]
GO
/****** Object:  View [dbo].[view_TongJi_JiFenShouFuKuanMingXi]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TongJi_JiFenShouFuKuanMingXi]'))
DROP VIEW [dbo].[view_TongJi_JiFenShouFuKuanMingXi]
GO
/****** Object:  View [dbo].[view_Pt_JiFenDingDan]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_JiFenDingDan]'))
DROP VIEW [dbo].[view_Pt_JiFenDingDan]
GO
/****** Object:  View [dbo].[view_YongHu_JiFenMingXi]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_YongHu_JiFenMingXi]'))
DROP VIEW [dbo].[view_YongHu_JiFenMingXi]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]
GO
/****** Object:  StoredProcedure [dbo].[proc_XiaoXi_GetKeHuXiaoXi]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_XiaoXi_GetKeHuXiaoXi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_XiaoXi_GetKeHuXiaoXi]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_YuanGong_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_YuanGong_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_YuanGong_CU]
GO
/****** Object:  View [dbo].[view_Pt_YongHu]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_YongHu]'))
DROP VIEW [dbo].[view_Pt_YongHu]
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_RouteZhengCe_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_RouteZhengCe_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_RouteZhengCe_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_BaoXiao_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_BaoXiao_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_SetStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_BaoXiao_SetStatus]
GO
/****** Object:  View [dbo].[view_Fin_TuiPiao]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_TuiPiao]'))
DROP VIEW [dbo].[view_Fin_TuiPiao]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanChuPiao_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_JieKuan_SetStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_JieKuan_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_JieKuan_SetStatus]
GO
/****** Object:  View [dbo].[view_Fin_QiTaZhiChu]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaZhiChu]'))
DROP VIEW [dbo].[view_Fin_QiTaZhiChu]
GO
/****** Object:  View [dbo].[view_Fin_KongWeiShouRu]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_KongWeiShouRu]'))
DROP VIEW [dbo].[view_Fin_KongWeiShouRu]
GO
/****** Object:  View [dbo].[view_TourOrder]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TourOrder]'))
DROP VIEW [dbo].[view_TourOrder]
GO
/****** Object:  View [dbo].[view_TourOrderHotel]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TourOrderHotel]'))
DROP VIEW [dbo].[view_TourOrderHotel]
GO
/****** Object:  View [dbo].[view_Fin_YinHangMingXi]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YinHangMingXi]'))
DROP VIEW [dbo].[view_Fin_YinHangMingXi]
GO
/****** Object:  View [dbo].[view_Fin_QiTaShouRu]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaShouRu]'))
DROP VIEW [dbo].[view_Fin_QiTaShouRu]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHuLxr_YongHu_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHuLxr_YongHu_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHuLxr_YongHu_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHuLxr_YongHu_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHuLxr_YongHu_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHuLxr_YongHu_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHu_CU]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHu_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHu_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHu_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHu_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHu_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_KeHu_ZhuCe]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_KeHu_ZhuCe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_KeHu_ZhuCe]
GO
/****** Object:  View [dbo].[view_Pt_DingDan]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_DingDan]'))
DROP VIEW [dbo].[view_Pt_DingDan]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_KeHu_U]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_KeHu_U]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_KeHu_U]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_YuanGong_D]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_YuanGong_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_YuanGong_D]
GO
/****** Object:  View [dbo].[view_Fin_QiTaShouZhi]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaShouZhi]'))
DROP VIEW [dbo].[view_Fin_QiTaShouZhi]
GO
/****** Object:  View [dbo].[view_Fin_FuKuanShenPi]    Script Date: 09/29/2014 16:30:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_FuKuanShenPi]'))
DROP VIEW [dbo].[view_Fin_FuKuanShenPi]
GO
/****** Object:  StoredProcedure [dbo].[proc_XiaoXi_GetZxsXiaoXi]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_XiaoXi_GetZxsXiaoXi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_XiaoXi_GetZxsXiaoXi]
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Route_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Route_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanTuiPiao_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_SheZhiDingDanStatus]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_SheZhiDingDanStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrder_SheZhiDingDanStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanTuiPiao_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Add]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanTuiPiao_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrderHotel_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_YinHangHeDui_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_YinHangHeDui_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_YinHangHeDui_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_YinHangHeDui_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_YinHangHeDui_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_YinHangHeDui_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_BianGeng]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_BianGeng]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_BianGeng]
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Delete]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TrainPlan_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Update]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TrainPlan_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Insert]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TrainPlan_Insert]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_split]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_PadLeft]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PadLeft]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_PadLeft]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_OrderCode]    Script Date: 09/29/2014 16:30:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_OrderCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_OrderCode]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pading]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pading]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pading]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pading_BySqlTable]    Script Date: 09/29/2014 16:30:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pading_BySqlTable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pading_BySqlTable]
GO

DROP VIEW view_KongWeiYajin_
DROP VIEW View_ReceiptRemind_GetList
GO

DROP PROC proc_BianGeng_
DROP PROC proc_KongWeiYajin_
GO
