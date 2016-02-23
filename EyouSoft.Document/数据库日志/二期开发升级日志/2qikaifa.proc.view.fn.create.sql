GO
/****** Object:  View [dbo].[View_PayRemind_GetList]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PayRemind_GetList]'))
DROP VIEW [dbo].[View_PayRemind_GetList]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenShangPin_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenShangPin_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenShangPin_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanChuPiao_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_GetGuanLianKongWeiXianLu]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_GetGuanLianKongWeiXianLu]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_GetGuanLianKongWeiXianLu]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_SetStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanDiJie_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrderHotel_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_SheZhiZhuangTai]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_SheZhiZhuangTai]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_SheZhiZhuangTai]
GO
/****** Object:  View [dbo].[view_Fin_TuanDuiJieSuan]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_TuanDuiJieSuan]'))
DROP VIEW [dbo].[view_Fin_TuanDuiJieSuan]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenDingDan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_XianLuDingDan_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_XianLuDingDan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_XianLuDingDan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrder_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrder_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_XiaoZhang]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_XiaoZhang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_DengZhang_XiaoZhang]
GO
/****** Object:  View [dbo].[view_Fin_YiXiaoZhang]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YiXiaoZhang]'))
DROP VIEW [dbo].[view_Fin_YiXiaoZhang]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_YongHu_JiFen_Handler]    Script Date: 09/29/2014 16:26:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_YongHu_JiFen_Handler]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_YongHu_JiFen_Handler]
GO
/****** Object:  StoredProcedure [dbo].[SQLPlan_Tour]    Script Date: 09/29/2014 16:26:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLPlan_Tour]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SQLPlan_Tour]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_KongWeiCode]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_KongWeiCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_KongWeiCode]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_PiaoCode]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PiaoCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_PiaoCode]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_UpdateStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_UpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_UpdateStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TourOrderHotelCode]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_TourOrderHotelCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_TourOrderHotelCode]
GO
/****** Object:  View [dbo].[view_News]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_News]'))
DROP VIEW [dbo].[view_News]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ValidUserLevDepartManagers]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_ValidUserLevDepartManagers]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_ValidUserLevDepartManagers]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TourCode]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_TourCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_TourCode]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_HotelJiaoYiHao]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_HotelJiaoYiHao]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_HotelJiaoYiHao]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenShangPin_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenShangPin_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_JiFenShangPin_D]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Pt_CreateJiFenShangPinBianMa]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Pt_CreateJiFenShangPinBianMa]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Pt_CreateJiFenShangPinBianMa]
GO
/****** Object:  StoredProcedure [dbo].[proc_AttendanceInfo_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_AttendanceInfo_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_AttendanceInfo_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_AttendanceInfo_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_AttendanceInfo_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_AttendanceInfo_Insert]
GO
/****** Object:  View [dbo].[View_AttendanceInfo]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_AttendanceInfo]'))
DROP VIEW [dbo].[View_AttendanceInfo]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkExchange_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkExchange_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkExchange_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkExchange_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkExchange_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkExchange_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_UpdateMxs]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_UpdateMxs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_FaPiao_UpdateMxs]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_FaPiao_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_FaPiao_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Check]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Check]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Check]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhanDian_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhanDian_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhanDian_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanDiJie_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_GongZi_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_GongZi_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_GongZi_SetStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanChuPiao_Update]
GO
/****** Object:  View [dbo].[view_PlanDiJie]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_PlanDiJie]'))
DROP VIEW [dbo].[view_PlanDiJie]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_SetOrderJinE]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_SetOrderJinE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_SetOrderJinE]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWeiYajin]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWeiYajin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWeiYajin]
GO
/****** Object:  View [dbo].[view_Fin_YaJin]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YaJin]'))
DROP VIEW [dbo].[view_Fin_YaJin]
GO
/****** Object:  View [dbo].[view_Pt_KongWeiXianLu]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_KongWeiXianLu]'))
DROP VIEW [dbo].[view_Pt_KongWeiXianLu]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_ChongDi]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_ChongDi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_DengZhang_ChongDi]
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLeave_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_UserLeave_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_UserLeave_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLeave_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_UserLeave_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_UserLeave_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianLeiBie_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianLeiBie_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianLeiBie_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhanDian_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhanDian_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhanDian_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianLeiBie_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianLeiBie_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianLeiBie_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_RiJiZhang_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_RiJiZhang_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_RiJiZhang_Insert]
GO
/****** Object:  View [dbo].[view_KongWeiYajin]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_KongWeiYajin]'))
DROP VIEW [dbo].[view_KongWeiYajin]
GO
/****** Object:  View [dbo].[view_Fin_YingFuJiaoTong]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuJiaoTong]'))
DROP VIEW [dbo].[view_Fin_YingFuJiaoTong]
GO
/****** Object:  View [dbo].[view_Fin_YingFuDiJie]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuDiJie]'))
DROP VIEW [dbo].[view_Fin_YingFuDiJie]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkPlan_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Sys_Create]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Sys_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Sys_Create]
GO
/****** Object:  StoredProcedure [dbo].[proc_Wage_Set]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Wage_Set]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Wage_Set]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanDiJie_Update]
GO
/****** Object:  View [dbo].[view_Fin_KongWeiZhiChu]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_KongWeiZhiChu]'))
DROP VIEW [dbo].[view_Fin_KongWeiZhiChu]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrderHotel_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_D]
GO
/****** Object:  StoredProcedure [dbo].[SQLPlan_TourOrderSaveSeat]    Script Date: 09/29/2014 16:26:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLPlan_TourOrderSaveSeat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SQLPlan_TourOrderSaveSeat]
GO
/****** Object:  StoredProcedure [dbo].[proc_WeiHuKongWeiStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WeiHuKongWeiStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WeiHuKongWeiStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KongWei_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Route_Delete]
GO
/****** Object:  View [dbo].[view_Fin_YingFuJiuDian]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuJiuDian]'))
DROP VIEW [dbo].[view_Fin_YingFuJiuDian]
GO
/****** Object:  View [dbo].[view_TongJi_JiFenFaFangMingXi]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TongJi_JiFenFaFangMingXi]'))
DROP VIEW [dbo].[view_TongJi_JiFenFaFangMingXi]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkReport_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkReport_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_WorkReport_Add]
GO
/****** Object:  View [dbo].[view_Pt_KongWei]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_KongWei]'))
DROP VIEW [dbo].[view_Pt_KongWei]
GO
/****** Object:  View [dbo].[view_TongJi_JiFenShouFuKuanMingXi]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TongJi_JiFenShouFuKuanMingXi]'))
DROP VIEW [dbo].[view_TongJi_JiFenShouFuKuanMingXi]
GO
/****** Object:  View [dbo].[view_Pt_JiFenDingDan]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_JiFenDingDan]'))
DROP VIEW [dbo].[view_Pt_JiFenDingDan]
GO
/****** Object:  View [dbo].[view_YongHu_JiFenMingXi]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_YongHu_JiFenMingXi]'))
DROP VIEW [dbo].[view_YongHu_JiFenMingXi]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]
GO
/****** Object:  StoredProcedure [dbo].[proc_XiaoXi_GetKeHuXiaoXi]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_XiaoXi_GetKeHuXiaoXi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_XiaoXi_GetKeHuXiaoXi]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_YuanGong_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_YuanGong_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_YuanGong_CU]
GO
/****** Object:  View [dbo].[view_Pt_YongHu]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_YongHu]'))
DROP VIEW [dbo].[view_Pt_YongHu]
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_RouteZhengCe_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_RouteZhengCe_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_RouteZhengCe_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_BaoXiao_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_BaoXiao_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_BaoXiao_SetStatus]
GO
/****** Object:  View [dbo].[view_Fin_TuiPiao]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_TuiPiao]'))
DROP VIEW [dbo].[view_Fin_TuiPiao]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanChuPiao_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_JieKuan_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_JieKuan_SetStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_JieKuan_SetStatus]
GO
/****** Object:  View [dbo].[view_Fin_QiTaZhiChu]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaZhiChu]'))
DROP VIEW [dbo].[view_Fin_QiTaZhiChu]
GO
/****** Object:  View [dbo].[view_Fin_KongWeiShouRu]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_KongWeiShouRu]'))
DROP VIEW [dbo].[view_Fin_KongWeiShouRu]
GO
/****** Object:  View [dbo].[view_TourOrder]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TourOrder]'))
DROP VIEW [dbo].[view_TourOrder]
GO
/****** Object:  View [dbo].[view_TourOrderHotel]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TourOrderHotel]'))
DROP VIEW [dbo].[view_TourOrderHotel]
GO
/****** Object:  View [dbo].[view_Fin_YinHangMingXi]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YinHangMingXi]'))
DROP VIEW [dbo].[view_Fin_YinHangMingXi]
GO
/****** Object:  View [dbo].[view_Fin_QiTaShouRu]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaShouRu]'))
DROP VIEW [dbo].[view_Fin_QiTaShouRu]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHuLxr_YongHu_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHuLxr_YongHu_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHuLxr_YongHu_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHuLxr_YongHu_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHuLxr_YongHu_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHuLxr_YongHu_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHu_CU]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHu_CU]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHu_CU]
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHu_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHu_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_KeHu_D]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_KeHu_ZhuCe]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_KeHu_ZhuCe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_KeHu_ZhuCe]
GO
/****** Object:  View [dbo].[view_Pt_DingDan]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_DingDan]'))
DROP VIEW [dbo].[view_Pt_DingDan]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_KeHu_U]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_KeHu_U]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_KeHu_U]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_YuanGong_D]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_YuanGong_D]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pt_YuanGong_D]
GO
/****** Object:  View [dbo].[view_Fin_QiTaShouZhi]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaShouZhi]'))
DROP VIEW [dbo].[view_Fin_QiTaShouZhi]
GO
/****** Object:  View [dbo].[view_Fin_FuKuanShenPi]    Script Date: 09/29/2014 16:26:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_FuKuanShenPi]'))
DROP VIEW [dbo].[view_Fin_FuKuanShenPi]
GO
/****** Object:  StoredProcedure [dbo].[proc_XiaoXi_GetZxsXiaoXi]    Script Date: 09/29/2014 16:26:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_XiaoXi_GetZxsXiaoXi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_XiaoXi_GetZxsXiaoXi]
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Route_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Route_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanTuiPiao_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_SheZhiDingDanStatus]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_SheZhiDingDanStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrder_SheZhiDingDanStatus]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanTuiPiao_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Add]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_PlanTuiPiao_Add]
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TourOrderHotel_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_YinHangHeDui_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_YinHangHeDui_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_YinHangHeDui_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_YinHangHeDui_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_YinHangHeDui_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Fin_YinHangHeDui_Insert]
GO
/****** Object:  StoredProcedure [dbo].[proc_BianGeng]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_BianGeng]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_BianGeng]
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Delete]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TrainPlan_Delete]
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Update]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TrainPlan_Update]
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Insert]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_TrainPlan_Insert]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_split]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_PadLeft]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PadLeft]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_PadLeft]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_OrderCode]    Script Date: 09/29/2014 16:26:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_OrderCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_OrderCode]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pading]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pading]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pading]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pading_BySqlTable]    Script Date: 09/29/2014 16:26:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pading_BySqlTable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[proc_Pading_BySqlTable]
GO
/****** Object:  StoredProcedure [dbo].[proc_Pading_BySqlTable]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pading_BySqlTable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2012-05-16
-- Description:	�洢���̷�ҳ,SQLTABLE
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pading_BySqlTable]
     @PageSize INT = 10-- ҳ�ߴ�
    ,@PageIndex INT = 1-- ҳ��
    ,@Table NVARCHAR(MAX)-- ��ѡ,��ѯ�����
    ,@Fields NVARCHAR(MAX)=''*'' --��ѡ,����
    ,@Query NVARCHAR(MAX) ='''' -- ��ѯ����(��Ҫ��WHERE),��ѯ��������Բ�ѯ��������ɵĸ���
    ,@OrderBy NVARCHAR(MAX)=''''-- ��ѡ,����(��Ҫ��ORDER BY),��������Բ�ѯ��������ɵĸ���
    ,@GroupBy NVARCHAR(MAX)=''''-- ����(��Ҫ��GROUP BY),��������Բ�ѯ��������ɵĸ���
	,@SumString NVARCHAR(MAX)=''''--�ϼ�,(SUM(FIELD) AS FIELD,SUM(FIELD1) AS FIELD1),�ϼ�����Բ�ѯ������ĸ���
AS
BEGIN
	DECLARE @RecordCount INT--��¼����[����]
	DECLARE @MinIndex INT--���ؽ������һ����¼����
	DECLARE @MaxIndex INT--���ؽ�������һ����¼����
	DECLARE @tmpsql NVARCHAR(MAX)--��ʱ����
	DECLARE @sumsql NVARCHAR(MAX)
	DECLARE @PageCount INT

	IF(@PageSize<1) SET @PageSize=1
	IF(@PageIndex<1) SET @PageIndex=1

	--��������
	IF(LEN(@OrderBy)>0)--�Ƿ���ڲ�ѯ����
	BEGIN
		SET @OrderBy = '' ORDER BY '' + @OrderBy
	END
	ELSE
	BEGIN
		SET @OrderBy = ''''
	END

	--��������
	IF(LEN(@GroupBy)>0)
	BEGIN
		SET @GroupBy = '' GROUP BY '' + @GroupBy
	END
	ELSE
	BEGIN
		SET @GroupBy = ''''
	END

	--��ѯ����
	IF(LEN(@Query)>0)
	BEGIN
		SET @Query='' WHERE ''+@Query
	END
	ELSE
	BEGIN
		SET @Query=''''
	END

	--�ܼ�¼��
	SET @tmpsql=''SELECT @RecordCount=COUNT(*) FROM (SELECT ''+@Fields+'' FROM (''+@Table+'') AS t129 '' + @Query + @GroupBy +'' ) AS t120 ''
	PRINT @tmpsql
	EXECUTE sp_executesql  @tmpsql,N''@RecordCount INT OUTPUT'',@RecordCount OUTPUT

	SET @PageCount=CEILING(@RecordCount*1.0/@PageSize)
	IF(@PageIndex >@PageCount) SET @PageIndex = @PageCount

	SET @MinIndex=(@PageIndex-1)* @PageSize +1
	SET @MaxIndex = @MinIndex + @PageSize -1

	--��ҳ�����SQL
	SET @tmpsql = ''SELECT t120.* FROM ( SELECT * ,ROW_NUMBER() OVER('' + @OrderBy + '') AS RowNumber FROM (SELECT '' + @Fields + '' FROM ('' + @Table + '') AS t129 '' + @Query + @GroupBy + '' ) t121 ) AS t120 WHERE RowNumber BETWEEN '' + CAST(@MinIndex AS NVARCHAR) + '' AND '' + CAST(@MaxIndex AS NVARCHAR) + '' ORDER BY RowNumber ASC ''

	--PRINT @tmpsql

	--�ϼƽ����SQL
	IF(LEN(@SumString)>0)
	BEGIN
		SET @sumsql=''SELECT ''+@SumString+'' FROM ( SELECT  '' + @Fields + '' FROM ('' + @Table + '') AS t129 '' + @Query + @GroupBy + '' ) AS t120''
	END
	ELSE
	BEGIN
		SET @sumsql=''SELECT NULL AS ''''NULL''''''
	END	
	
	--PRINT 	@sumsql
	SELECT @RecordCount AS RecordCount
	EXECUTE sp_executesql @tmpsql
	EXECUTE sp_executesql @sumsql
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pading]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pading]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2012-05-16
-- Description:	�洢���̷�ҳ,TABLE,VIEW
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pading]
     @PageSize int = 10-- ҳ�ߴ�
    ,@PageIndex int = 1 -- ҳ��
    ,@TableName NVARCHAR(MAX)-- ����    
    ,@Fields NVARCHAR(MAX) --����
    ,@Query NVARCHAR(MAX) = ''''-- ��ѯ���� (ע��: ��Ҫ�� where)
    ,@OrderBy NVARCHAR(MAX)=''''--��ѡ,����(��Ҫ��ORDER BY),��������Բ�ѯ��������ɵĸ���
    ,@GroupBy NVARCHAR(MAX)=''''--����(��Ҫ��GROUP BY),��������Բ�ѯ��������ɵĸ���
	,@SumString NVARCHAR(max)=''''--�ϼ�,(SUM(FIELD) AS FIELD,SUM(FIELD1) AS FIELD1),�ϼ�����Բ�ѯ������ĸ���
AS
BEGIN
	DECLARE @RecordCount int--��¼����[����]
	DECLARE @PageCount int
	DECLARE @tmpsql NVARCHAR(MAX)--��ʱ���
	DECLARE @sumsql NVARCHAR(MAX)
	DECLARE @MinIndex INT--���ؽ������һ����¼����
	DECLARE @MaxIndex INT--���ؽ�������һ����¼����
	SET @PageCount = 0

	IF(@OrderBy IS NOT NULL AND LEN(@OrderBy)>0)
	BEGIN
		SET @OrderBy = ''ORDER BY ''+@OrderBy
	END
	ELSE
	BEGIN
		SET @OrderBy = ''''
	END

	IF(@Query IS NOT NULL AND LEN(@Query) >0)
	BEGIN
		SET @Query='' WHERE ''+@Query
	END
	ELSE
	BEGIN
		SET @Query=''''
	END

	SET @tmpsql=''SELECT @RecordCount=COUNT(*) FROM ['' + @TableName + '']''+@Query

	EXECUTE sp_executesql  @tmpsql,N''@RecordCount INT OUTPUT'',@RecordCount OUTPUT

	SET @PageCount=CEILING(@RecordCount*1.0/@PageSize)
	IF(@PageIndex >@PageCount) SET @PageIndex = @PageCount

	SET @MinIndex=(@PageIndex-1)* @PageSize +1
	SET @MaxIndex = @MinIndex + @PageSize -1

	SET @tmpsql = ''SELECT t120.* FROM ( SELECT  '' + @Fields + '',ROW_NUMBER() OVER('' + @OrderBy + '') AS RowNumber FROM ['' + @TableName + ''] '' + @Query + '' ) AS t120 WHERE RowNumber BETWEEN '' + CAST(@MinIndex AS NVARCHAR(10)) + '' AND '' + CAST(@MaxIndex AS NVARCHAR(10))+'' ORDER BY RowNumber ASC''

	--�ϼƽ����SQL
	IF(LEN(@SumString)>0)
	BEGIN
		SET @sumsql=''SELECT ''+@SumString+'' FROM ( SELECT  '' + @Fields + '' FROM [''+@TableName+''] '' + @Query + '' ) AS t120''
	END
	ELSE
	BEGIN
		SET @sumsql=''SELECT NULL AS ''''NULL''''''
	END	

	SELECT @RecordCount AS RecordCount
	EXECUTE sp_executesql @tmpsql
	EXECUTE sp_executesql @sumsql

END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_OrderCode]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_OrderCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-21>
-- Description:	<���ɶ�����>
-- Result :���������ϵͳ�Զ����ݿ�λ�����ɶ����ţ�������=��λ��+��λ������ˮ��
-- =============================================
CREATE function [dbo].[fn_OrderCode]
(
	@KongWeiId char(36)
)
returns nvarchar(100)
begin
	declare @OrderCode nvarchar(100)
	
	declare @KongWeiCode varchar(100)
	select @KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@KongWeiId
	
	declare @index int
	select @index=count(1)+1 from tbl_TourOrder where TourId=@KongWeiId
	if(@index>=1 and @index<=9)
	begin
		set @OrderCode=@KongWeiCode+''0''+cast(@index as varchar(10))
	end
	else
	begin
		set @OrderCode=@KongWeiCode+cast(@index as varchar(10))
	end
	return @OrderCode
end







' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_PadLeft]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PadLeft]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2010-05-25
-- Description:	�Ҷ����ַ����������ָ�����ַ�����Դﵽָ�����ܳ��ȡ�
-- =============================================
CREATE FUNCTION [dbo].[fn_PadLeft]
(
	--������ַ���
	@Input NVARCHAR(50),
	--����ַ�
	@PaddingChar CHAR(1),
	--����ַ����е��ַ���������ԭʼ�ַ��������κ���������ַ���
	@TotalWidth INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @tmp varchar(50)
	SELECT @tmp = ISNULL(REPLICATE(@PaddingChar,@TotalWidth - LEN(ISNULL(@Input ,0))), '''') + @Input
	RETURN @tmp
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:   
-- Create date:
-- Description: �ָ��ַ���
-- =============================================
Create FUNCTION [dbo].[fn_split] (
	--�����ַ���
	@InputString NVARCHAR(MAX),
	--�ָ�����
	@Seprator NVARCHAR(10)
)
RETURNS @tempTable TABLE ([value] NVARCHAR(MAX),Id INT IDENTITY)
AS
BEGIN
	DECLARE @index int
	DECLARE @value NVARCHAR(MAX)
	--�ָ�����@Seprator�������ַ���@InputString�еĿ�ʼλ��
	SET @index=CHARINDEX(@Seprator, @InputString)

	WHILE @index>0
	BEGIN
		--���������ַ���(@InputString)��߿�ʼָ������(@index-1)���ַ�
		SET @value=LEFT(@InputString,@index-1)
		--��������
		INSERT @tempTable VALUES(@value)
		--�������������ַ��� ��ȡ�����ַ����������ַ���@index+LEN(@Seprator)����ʼ�ҳ���ΪLEN(@InputString)
		SET @InputString = SUBSTRING(@InputString, @index+LEN(@Seprator), LEN(@InputString))
		--�ָ�����@Seprator�������ַ���@InputString�еĿ�ʼλ��
		SET @index=CHARINDEX(@Seprator, @InputString)
	END

	INSERT @tempTable VALUES(@InputString)

	RETURN
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		luofx
-- Create date: 2011-01-20
-- Description:	��ѵ�ƻ�����
-- =============================================
CREATE PROCEDURE  [dbo].[proc_TrainPlan_Insert]
	  @CompanyId INT,             --��˾���
      @PlanTitle NVARCHAR(255),   --����
      @PlanContent NVARCHAR(MAX), --����
      @TrainPlanFile NVARCHAR(255),--��ѵ�ƻ�����
      @OperatorId INT,             --�����˱��  
      @OperatorName NVARCHAR(50),  --����������
      @TrainPlanAcceptXML NVARCHAR(MAX),--��ѵ�ƻ�������XML:<ROOT><TrainPlanAccept AcceptId=="" AcceptType="" TrainPlanId="" /></ROOT>
	  @Result int output -- ���ز���	
AS
BEGIN
	DECLARE @TrainPlanId INT
	DECLARE @ErrorCount INT --��֤����
	DECLARE @hdoc INT       --XMLʹ�ò���
	SET @ErrorCount=0
	BEGIN TRANSACTION TrainPlan_Insert
		--������ѵ�ƻ�
		INSERT INTO [tbl_TrainPlan] (CompanyId,PlanTitle,PlanContent,TrainPlanFile,OperatorId,OperatorName) 
			VALUES(@CompanyId,@PlanTitle,@PlanContent,@TrainPlanFile,@OperatorId,@OperatorName)
		SET @ErrorCount = @ErrorCount + @@ERROR
		--ȡ�øղ������ѵ�ƻ����
		SELECT @TrainPlanId=@@IDENTITY FROM [tbl_TrainPlan]
		IF @ErrorCount > 0 
			BEGIN
				SET @Result=0
				ROLLBACK TRANSACTION TrainPlan_Insert 
			END	
		IF(@TrainPlanAcceptXML<>'''')
			BEGIN
				--������ѵ�ƻ���������Ϣ
				EXEC sp_xml_preparedocument @hdoc OUTPUT, @TrainPlanAcceptXML
					INSERT INTO [tbl_TrainPlanAccepts](TrainPlanId,AcceptType,AcceptId)
					SELECT TrainPlanId=@TrainPlanId,AcceptType,AcceptId FROM 
						OPENXML(@hdoc,N''/ROOT/TrainPlanAccept'') 
							WITH(TrainPlanId INT,AcceptType INT,AcceptId INT)
					SET @ErrorCount = @ErrorCount + @@ERROR
				EXEC sp_xml_removedocument @hdoc
			END 
		IF @ErrorCount > 0 
			BEGIN
				SET @Result=0
				ROLLBACK TRANSACTION TrainPlan_Insert 
			END	
	COMMIT TRANSACTION TrainPlan_Insert
	SET @Result=1
	RETURN @Result
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		luofx
-- Create date: 2011-01-20
-- Description:	��ѵ�ƻ��޸�
-- =============================================
CREATE PROCEDURE  [dbo].[proc_TrainPlan_Update]
	  @TrainPlanId INT,                --��ѵ�ƻ����
	  @CompanyId INT,                  --��˾���
      @PlanTitle NVARCHAR(255),        --����
      @PlanContent NVARCHAR(MAX),      --����
      @TrainPlanFile NVARCHAR(255),    --��ѵ�ƻ�����
      @OperatorId INT,                 --�����˱��  
      @OperatorName NVARCHAR(50),      --����������
	  @IssueTime DATETIME,             --���ʱ��
      @TrainPlanAcceptXML NVARCHAR(MAX),--��ѵ�ƻ�������XML:<ROOT><TrainPlanAccept AcceptId=="" AcceptType="" TrainPlanId="" /></ROOT>
	  @Result int output -- ���ز���	
AS
BEGIN
	DECLARE @ErrorCount int --��֤����
	DECLARE @hdoc int       --XMLʹ�ò���
	SET @ErrorCount=0
	BEGIN TRANSACTION TrainPlan_Update
		--�޸���ѵ�ƻ���Ϣ
		UPDATE [tbl_TrainPlan] SET PlanTitle=@PlanTitle,TrainPlanFile=@TrainPlanFile,
				OperatorId=@OperatorId,OperatorName=@OperatorName,PlanContent=@PlanContent,IssueTime=@IssueTime
			    WHERE [ID]=@TrainPlanId AND CompanyId=@CompanyId
			SET @ErrorCount = @ErrorCount + @@ERROR
		IF(@ErrorCount = 0 )
			BEGIN
				--ɾ����ѵ�ƻ����������Ϣ
				DELETE FROM [tbl_TrainPlanAccepts] WHERE [TrainPlanId]=@TrainPlanId
				SET @ErrorCount = @ErrorCount + @@ERROR				
			END
		IF(@TrainPlanAcceptXML<>'''')
			BEGIN
				--������ѵ�ƻ����������Ϣ
				EXEC sp_xml_preparedocument @hdoc OUTPUT, @TrainPlanAcceptXML
					INSERT INTO [tbl_TrainPlanAccepts](TrainPlanId,AcceptType,AcceptId)
					SELECT TrainPlanId=@TrainPlanId,AcceptType,AcceptId FROM 
						OPENXML(@hdoc,N''/ROOT/TrainPlanAccept'') 
							WITH(TrainPlanId INT,AcceptType INT,AcceptId INT)
					SET @ErrorCount = @ErrorCount + @@ERROR
				EXEC sp_xml_removedocument @hdoc
			END
		IF @ErrorCount > 0 
			BEGIN
				SET @Result=0
				ROLLBACK TRANSACTION TrainPlan_Update 
			END	
	COMMIT TRANSACTION TrainPlan_Update
	SET @Result=1
	RETURN @Result
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TrainPlan_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TrainPlan_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		luofx
-- Create date: 2011-01-20
-- Description:	��ѵ�ƻ�ɾ��
-- =============================================
CREATE PROCEDURE  [dbo].[proc_TrainPlan_Delete]
	  @TrainPlanId INT,     --��ѵ�ƻ����
	  @CompanyId INT,       --��˾���
	  @Result INT OUTPUT    -- ���ز���	
AS
BEGIN
	DECLARE @ErrorCount int --��֤����
	DECLARE @hdoc int       --XMLʹ�ò���
	BEGIN TRANSACTION TrainPlan_Delete
		--ɾ����ѵ�ƻ���������Ϣ
		DELETE FROM [tbl_TrainPlanAccepts] WHERE [TrainPlanId]=@TrainPlanId
		SET @ErrorCount = @ErrorCount + @@ERROR		
		IF(@ErrorCount = 0 )
			BEGIN
				--ɾ����ѵ�ƻ�
				Delete FROM [tbl_TrainPlan] WHERE [ID]=@TrainPlanId AND CompanyId=@CompanyId
				SET @ErrorCount = @ErrorCount + @@ERROR
			END
		--�Ƿ�ع�		
		IF @ErrorCount > 0 
			BEGIN
				SET @Result=0
				ROLLBACK TRANSACTION TrainPlan_Delete 
			END	
	COMMIT TRANSACTION TrainPlan_Delete
	SET @Result=1
	RETURN @Result
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BianGeng]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_BianGeng]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<����>
-- Create date: <2012-11-23>
-- Description:	<��ӱ����Ϣ>
-- Return��1��ʧ�� 0���ɹ�
-- =============================================
CREATE proc [dbo].[proc_BianGeng]
@CompanyId int=0,
@BianId char(36),
@OperatorId int,
@BianType tinyint,
@IssueTime datetime=null,
@Url nvarchar(max),
@Result int output
as
begin
	declare @error int
	set @error=0
	INSERT INTO tbl_BianGeng
           (Id,BianId,OperatorId,BianType,IssueTime,Url)
     VALUES(newid(),@BianId,@OperatorId,@BianType,getdate(),@Url)
	 set @error=@error+@@error
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	return @Result
end



' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_YinHangHeDui_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_YinHangHeDui_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-22
-- Description:д�����к˶���Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_YinHangHeDui_Insert]
	 @HeDuiId CHAR(36)--�˶Ա��
	,@CompanyId INT--��˾���
	,@YeWuRiQi DATETIME--ҵ������
	,@JieFangZongE MONEY--�跽�ܶ�(ҵ������)
	,@DaiFangZongE MONEY--�����ܶ�(ҵ������)
	,@LiuShuiZongE MONEY--��ˮ�ܶ�(ҵ������)
	,@YinHangZongE MONEY--�����ܶ�(ҵ������ǰһ��)
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@Status TINYINT--״̬
	,@ZhangHuXml NVARCHAR(MAX)--�����˻���ϢXML:<root><info ZhangHuId="�����˻����" YuE="���(ҵ������ǰһ��)" JieFangJinE="�跽���(ҵ������)" DaiFangJinE="�������(ҵ������)" /></root>
	,@RetCode INT OUTPUT
	,@ZxsId CHAR(36)
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	SET @errorcount=0

	IF EXISTS(SELECT 1 FROM [tbl_FinYinHangHeDui] WHERE [YeWuRiQi]=@YeWuRiQi)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	BEGIN TRAN

	INSERT INTO [tbl_FinYinHangHeDui]([HeDuiId],[CompanyId],[YeWuRiQi],[Status]
		,[YinHangZongE],[JieFangZongE],[DaiFangZongE],[LiuShuiZongE]
		,[OperatorId],[IssueTime],[SheHeOperatorId],[ShenHeTime]
		,[ZxsId])
	VALUES(@HeDuiId,@CompanyId,@YeWuRiQi,@Status
		,@YinHangZongE,@JieFangZongE,@DaiFangZongE,@LiuShuiZongE
		,@OperatorId,@IssueTime,NULL,NULL
		,@ZxsID)
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @ZhangHuXml IS NOT NULL AND LEN(@ZhangHuXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@ZhangHuXml

		INSERT INTO [tbl_FinYinHangHeDuiMx]([HeDuiId],[ZhangHuId],[YuE],[JieFangJinE]
			,[DaiFangJinE])
		SELECT @HeDuiId,A.ZhangHuId,A.YuE,A.JieFangJinE
			,A.DaiFangJinE
		FROM OPENXML(@hdoc,''/root/info'') 
		WITH(ZhangHuId CHAR(36),YuE MONEY,JieFangJinE MONEY,DaiFangJinE MONEY) AS A			
		SET @errorcount=@errorcount+@@ERROR

		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_YinHangHeDui_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_YinHangHeDui_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-22
-- Description:�޸����к˶���Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_YinHangHeDui_Update]
	 @HeDuiId CHAR(36)--�˶Ա��
	,@YeWuRiQi DATETIME--ҵ������
	,@JieFangZongE MONEY--�跽�ܶ�(ҵ������)
	,@DaiFangZongE MONEY--�����ܶ�(ҵ������)
	,@LiuShuiZongE MONEY--��ˮ�ܶ�(ҵ������)
	,@YinHangZongE MONEY--�����ܶ�(ҵ������ǰһ��)
	,@ZhangHuXml NVARCHAR(MAX)--�����˻���ϢXML:<root><info ZhangHuId="�����˻����" YuE="���(ҵ������ǰһ��)" JieFangJinE="�跽���(ҵ������)" DaiFangJinE="�������(ҵ������)" /></root>
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	SET @errorcount=0

	IF EXISTS(SELECT 1 FROM [tbl_FinYinHangHeDui] WHERE [YeWuRiQi]=@YeWuRiQi AND [HeDuiId]<>@HeDuiId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinYinHangHeDui] WHERE [HeDuiId]=@HeDuiId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN

	UPDATE [tbl_FinYinHangHeDui] SET [YeWuRiQi]=@YeWuRiQi,[YinHangZongE]=@YinHangZongE
		,[JieFangZongE]=@JieFangZongE,[DaiFangZongE]=@DaiFangZongE
		,[LiuShuiZongE]=@LiuShuiZongE
	WHERE [HeDuiId]=@HeDuiId
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @ZhangHuXml IS NOT NULL AND LEN(@ZhangHuXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@ZhangHuXml
		DELETE FROM [tbl_FinYinHangHeDuiMx] WHERE [HeDuiId]=@HeDuiId
		INSERT INTO [tbl_FinYinHangHeDuiMx]([HeDuiId],[ZhangHuId],[YuE],[JieFangJinE]
			,[DaiFangJinE])
		SELECT @HeDuiId,A.ZhangHuId,A.YuE,A.JieFangJinE
			,A.DaiFangJinE
		FROM OPENXML(@hdoc,''/root/info'') 
		WITH(ZhangHuId CHAR(36),YuE MONEY,JieFangJinE MONEY,DaiFangJinE MONEY) AS A			
		SET @errorcount=@errorcount+@@ERROR

		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-15>
-- Description:	<�޸Ĵ����Ƶ�>
-- History:
-- 1.����־ 2013-01-22 ����@PlanHotelMxXML
-- 2.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���
-- =============================================
CREATE proc [dbo].[proc_TourOrderHotel_Update]
	@KongWeiId char(36)--��λ���
	,@CompanyId int--��˾���
	,@OrderId char(36)--�������
	,@QuDate datetime--��������
	,@Adults int--������
	,@Childs int--��ͯ��
	,@BuyCompanyId char(36)--�ͻ���λ
	,@BuyOperatorId int--�Է�������
	,@PriceDetials varchar(max)--�۸���ϸ
	,@SumPrice MONEY--�ϼƽ��
	,@PriceRemark varchar(max)--�۸�ע
	,@SpecialAskRemark varchar(max)--����Ҫ��
	,@OperatoRemark varchar(max)--������ע
	,@OperatorId int--����Ա
	,@YouKeXml NVARCHAR(MAX)--�����ο�XML
	,@JiuDianAnPaiXml NVARCHAR(MAX)--�����Ƶ갲��XML
	,@Result int output
	,@PlanHotelMxXML NVARCHAR(MAX)--�Ƶ갲����ϸ��ϢXML:<root><info KognWeiId="" OrderId="" AnPaiId="" RuZhuTime="" TuiFangTime="" FangXing="" YaoQiuBeiZhu="" JianYe="" QuFangFangShi="" JiuDianName="" /></root>
	,@LatestOperatorId INT
	,@LatestTime DATETIME		
as
begin
	declare @error int
	set @error=0	
	DECLARE @hdoc INT
	DECLARE @KongWeiCode NVARCHAR(50)

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	SELECT @KongWeiCode=KongWeiCode FROM tbl_KongWei WHERE KongWeiId=@KongWeiId 
	
	begin transaction

	UPDATE tbl_KongWei SET ShuLiang=@Adults+@Childs,QuDate=@QuDate,LatestTime=getdate()
	where KongWeiId=@KongWeiId

	UPDATE tbl_TourOrder SET Adults=@Adults,Childs=@Childs,Accounts=@Adults+@Childs
		,BuyCompanyId=@BuyCompanyId,BuyOperatorId=@BuyOperatorId
		,PriceDetials=@PriceDetials,SumPrice=@SumPrice,PriceRemark=@PriceRemark
		,SpecialAskRemark=@SpecialAskRemark,OperatoRemark=@OperatoRemark
		,LatestTime=@LatestTime,LatestOperatorId=@LatestOperatorId
	Where OrderId=@OrderId
	set @error=@error+@@error
	
	DECLARE @TEMP1 TABLE(TravellerId char(36),TravellerName nvarchar(50)
		,TravellerType tinyint,CardType tinyint,CardNumber nvarchar(50)
		,Gender tinyint,Contact nvarchar(255),Status tinyint
		,TicketType tinyint,T1 CHAR(1))
		
	IF(@YouKeXml IS NOT NULL AND LEN(@YouKeXml)>0)
	BEGIN
		exec sp_xml_preparedocument @hdoc output,@YouKeXml
		INSERT INTO @TEMP1(TravellerId,TravellerName
			,TravellerType,CardType,CardNumber
			,Gender,Contact,Status
			,TicketType,T1)
		SELECT TravellerId,TravellerName
			,TravellerType,CardType,CardNumber
			,Gender,Contact,Status
			,TicketType,''C''		
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(TravellerId char(36),TravellerName nvarchar(50)
			,TravellerType tinyint,CardType tinyint,CardNumber nvarchar(50)
			,Gender tinyint,Contact nvarchar(255),Status tinyint
			,TicketType tinyint)
		exec sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP1 SET T1=''U'' WHERE TravellerId IN(SELECT [TravellerId] FROM [tbl_TourOrderTraveller] WHERE OrderId=@OrderId)
	
	--�����ο�
	INSERT INTO [tbl_TourOrderTraveller]([TravellerId],[OrderId],[TourId]
		,[TravellerName],[TravellerType],[CardType]
		,[CardNumber],[Gender],[Contact]
		,[Status],[TicketType])
	SELECT TravellerId,@OrderId,@KongWeiId
		,TravellerName,TravellerType,CardType
		,CardNumber,Gender,Contact
		,Status,TicketType
	FROM @TEMP1 WHERE T1=''C''
	
	--�޸��ο�
	UPDATE tbl_TourOrderTraveller SET [TravellerName]=B.[TravellerName]
		,[TravellerType]=B.[TravellerType],[CardType]=B.[CardType]
		,[CardNumber]=B.[CardNumber],[Gender]=B.[Gender]
		,[Contact]=B.[Contact],[Status]=B.Status
	FROM tbl_TourOrderTraveller AS A INNER JOIN @TEMP1 AS B
	ON A.[TravellerId]=B.[TravellerId] AND B.T1=''U''
	WHERE A.OrderId=@OrderId
	
	--ɾ���ο�
	DELETE FROM tbl_TourOrderTraveller WHERE OrderId=@OrderId
	AND TravellerId NOT IN(SELECT TravellerId FROM @TEMP1)
	AND Status=0 AND TicketType=0
	
	--�������ο�״̬��Ϊ��δ��Ʊ
	UPDATE  tbl_TourOrderTraveller SET TicketType=0 WHERE orderId=@OrderId

	--ά���ѳ�Ʊ״̬
	Update tbl_TourOrderTraveller set TicketType=1 
	where TravellerId in(select YouKeId from tbl_PlanChuPiaoYouKe where OrderId=@OrderId)

	--ά������Ʊ״̬
	Update tbl_TourOrderTraveller set TicketType=2
	where TravellerId in(select YouKeId from tbl_PlanTuiPiaoYouKe where OrderId=@OrderId)
	
	--�Ƶ갲�Ŵ���
	DECLARE @TEMP2 TABLE(Id char(36),CheckInDate datetime,CheckOutDate datetime
		,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
		,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
		,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
		,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100)
		,IDENTITYID INT IDENTITY,T1 CHAR(1))
		
	IF(@JiuDianAnPaiXml IS NOT NULL AND LEN(@JiuDianAnPaiXml)>0)
	BEGIN
		exec sp_xml_preparedocument @hdoc output,@JiuDianAnPaiXml
		INSERT INTO @TEMP2(Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
			,T1)
		SELECT Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
			,''C''
		FROM openxml(@hdoc,''/root/info'',3)
		with(Id char(36),CheckInDate datetime,CheckOutDate datetime
			,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
			,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
			,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
			,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100))		
		exec sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP2 SEt T1=''U'' WHERE Id IN(SELECT Id FROM tbl_TourOrderHotelPlan WHERE OrderId=@OrderId)
	
	--�����Ƶ갲��
	INSERT INTO tbl_TourOrderHotelPlan(Id,OrderId,TourId
		,CompanyId,CheckInDate,CheckOutDate
		,Room,Remark,RoomNights
		,HumorWas,HotelName,GYSId
		,SideOperatorId,SettleDetail,SettleAmount
        ,PlanRemark,PlanDetail,FileInfo)
	SELECT Id,@OrderId,@KongWeiId
		,@CompanyId,CheckInDate,CheckOutDate
		,Room,Remark,RoomNights
		,HumorWas,HotelName,GYSId
		,SideOperatorId,SettleDetail,SettleAmount
		,PlanRemark,PlanDetail,FileInfo
	FROM @TEMP2 WHERE T1=''C'' ORDER BY IdentityId ASC
	
	--�޸ľƵ갲��
	UPDATE tbl_TourOrderHotelPlan SET CheckInDate=B.CheckInDate
		,CheckOutDate=B.CheckOutDate,Room=B.Room
		,Remark=B.Remark,RoomNights=B.RoomNights
		,HumorWas=B.HumorWas,HotelName=B.HotelName
		,GYSId=B.GYSId,SideOperatorId=B.SideOperatorId
		,SettleDetail=B.SettleDetail,SettleAmount=B.SettleAmount
		,PlanRemark=B.PlanRemark,PlanDetail=B.PlanDetail
		,FileInfo=B.FileInfo
	FROM tbl_TourOrderHotelPlan AS A INNER JOIN @Temp2 AS B
	ON A.Id=B.Id AND B.T1=''U''
	WHERE A.OrderId=@OrderId
	
	--ɾ���Ƶ갲��
	UPDATE tbl_TourOrderHotelPlan SET IsDelete=''1'' WHERE OrderId=@OrderId
	AND Id NOT IN(SELECT Id FROM @TEMP2)
	AND NOT EXISTS(SELECT 1 FROM tbl_FinCope AS A1 WHERE A1.CollectionId=tbl_TourOrderHotelPlan.Id)
	
	--���Ž��׺Ŵ���
	DECLARE @count INT
	DECLARE @i INT
	SELECT @count=COUNT(*) FROM @TEMP2
	SET @i=1
	
	WHILE(@i<=@count)
	BEGIN
		DECLARE @TempId CHAR(36)
		DECLARE @T1 CHAR(1)
		SELECT @TempId=Id,@T1=T1 FROM @TEMP2 WHERE IdentityId=@i
		
		SET @i=@i+1
		IF(@T1=''U'')
		BEGIN
			PRINT ''CONTINUE''
			CONTINUE
		END
		
		DECLARE @JiaoYiHao nvarchar(50)
		DECLARE @index INT
		
		SELECT @index=COUNT(*)+1 FROM tbl_TourOrderHotelPlan WHERE OrderId=@OrderId AND JiaoYiHao IS NOT NULL AND LEN(JiaoYiHao)>0
		
		SET @JiaoYiHao= @KongWeiCode+''D''+dbo.fn_PadLeft(@index,0,2)
		update tbl_TourOrderHotelPlan set JiaoYiHao=@JiaoYiHao
		where Id=@TempId		
	END

	--�Ƶ갲����ϸ��Ϣ����
	IF(@error=0)
	BEGIN
		UPDATE [tbl_PlanHotelMX] SET [IsDelete]=''1'' WHERE KongWeiId=@KongWeiId AND OrderId=@OrderId
		SET @error=@error+@@ERROR
	END
	
	IF(@error=0 AND LEN(@PlanHotelMxXml)>13)
	BEGIN		
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@PlanHotelMxXml
		INSERT INTO [tbl_PlanHotelMX]([AnPaiId],[KongWeiId],[OrderId],[RuZhuTime]
			,[TuiFangTime],[FangXing],[YaoQiuBeiZhu],[JianYe]
			,[QuFangFangShi],[JiuDianName],[IssueTime],[IsDelete])
		SELECT A.AnPaiId,A.KongWeiId,A.OrderId,A.RuZhuTime
			,A.TuiFangTime,A.FangXing,A.YaoQiuBeiZhu,A.JianYe
			,A.QuFangFangShi,A.JiuDianName,@LatestTime,''0''
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(KongWeiId CHAR(36),OrderId CHAR(36),AnPaiId CHAR(36),RuZhuTime DATETIME,TuiFangTime DATETIME,FangXing NVARCHAR(255),YaoQiuBeiZhu NVARCHAR(255),JianYe NVARCHAR(255),QuFangFangShi NVARCHAR(255),JiuDianName NVARCHAR(255)) AS A		

		EXECUTE sp_xml_removedocument @hdoc
		set @error=@error+@@error
	END
	
	IF(@error<>0)
	BEGIN
		set @Result=0
		rollback transaction
		RETURN @Result
	END

	set @Result=1
	commit transaction

	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-20>
-- Description:	<����Ʊ�񡪡������Ʊ>
-- Result :-1:���ڲ���������Ʊ���ο�
--		   -2:��ӳɹ�
--		   -3:���ʧ��	
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���			
-- =============================================
CREATE proc [dbo].[proc_PlanTuiPiao_Add]
@TuiId char(36),
@PlanId char(36),
@KongWeiId char(36),
@OrderId char(36),
@ShuLiang int,
@TuiTime datetime,
@SunShiMX nvarchar(255),
@SunShiAmount money,
@ChengDanFang nvarchar(255),
@TuiAmount money,
@Remark nvarchar(255),
@OperatorId int,
@Traveller xml,		--�ο���Ϣ<Root><Traveller TuiId=\"{0}\" YouKeId=\"{1}\" OrderId=\"{2}\" /></Root>
@Result int output
as 
begin
	declare @error int
	set @error=0

	if(@Traveller is null)
	begin
		set @Result=-3
	end
	
	declare @idoc int	
	exec sp_xml_preparedocument @idoc output,@Traveller
	set @error=@error+@@error

	--�ж���Ʊ���ο��Ƿ����οͱ���ɾ��
	if exists(select 1 from openxml(@idoc,''/Root/Traveller'')with(YouKeId char(36)) as t
			 where YouKeId not in 
			(select TravellerId from tbl_TourOrderTraveller where TourId=@KongWeiId))
	begin
		set @Result=-1 --���ڲ���������Ʊ���ο�
		RETURN @Result
	end

	--�ж���Ʊ�ο��Ƿ��ڵ�ǰ�ѳ�Ʊ����Ϣ����
	if exists(select 1 from openxml(@idoc,''/Root/Traveller'') with(YouKeId char(36)) as t
			  where not exists (select 1 from tbl_PlanChuPiaoYouKe 
										 where YouKeId=t.YouKeId and PlanId=@PlanId))
	begin
		set @Result=-1 --���ڲ���������Ʊ���ο�
		RETURN @Result
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	begin transaction 

	INSERT INTO tbl_PlanTuiPiao
           (TuiId,PlanId,KongWeiId,OrderId,ShuLiang,TuiTime,SunShiMX,
           SunShiAmount,ChengDanFang,TuiAmount,Remark,OperatorId)
     VALUES
           (@TuiId,@PlanId,@KongWeiId,@OrderId,@ShuLiang,@TuiTime,@SunShiMX,
            @SunShiAmount,@ChengDanFang,@TuiAmount,@Remark,@OperatorId)
	set @error=@error+@@error
	
	INSERT INTO tbl_PlanTuiPiaoYouKe(TuiId,YouKeId,OrderId)
	SELECT @TuiId,YouKeId,OrderId from openxml(@idoc,''/Root/Traveller'')
	with(YouKeId char(36),OrderId char(36))
	set @error=@error+@@error

	--���οͳ�Ʊ״̬��Ϊδ��Ʊstatus:���� = 0,���� = 1	
	--TicketType:δ��Ʊ = 0,�ѳ�Ʊ = 1,����Ʊ = 2

	--���ο�״̬Ϊ����Ʊ״̬
	UPDATE tbl_TourOrderTraveller SET TicketType=2 
	WHERE TravellerId in (select YouKeId from openxml(@idoc,''/Root/Traveller'')
						  with(YouKeId char(36))
						 )
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=-2
		commit transaction
	end
	else
	begin
		set @Result=-3
		rollback transaction
	end
	return @Result
	
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-20>
-- Description:	<����Ʊ�񡪡��޸���Ʊ>
-- Result :-1:���ڲ���������Ʊ���ο�
--		   -2:��ӳɹ�
--		   -3:���ʧ��		
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���		
-- =============================================
CREATE proc [dbo].[proc_PlanTuiPiao_Update]
@TuiId char(36),
@PlanId char(36),
@KongWeiId char(36),
@OrderId char(36),
@ShuLiang int,
@TuiTime datetime,
@SunShiMX nvarchar(255),
@SunShiAmount money,
@ChengDanFang nvarchar(255),
@TuiAmount money,
@Remark nvarchar(255),
@OperatorId int,
@Traveller xml,		--�ο���Ϣ<Root><Traveller TuiId=\"{0}\" YouKeId=\"{1}\" OrderId=\"{2}\" /></Root>
@Result int output
as 
begin
	declare @error int
	set @error=0

	if(@Traveller is null)
	begin
		set @Result=-3
		RETURN @Result
	end
	
	declare @idoc int
	exec sp_xml_preparedocument @idoc output,@Traveller
	
	--����ӵ���Ʊ�ο�  ������ʱ��#temp
	select TuiId,YouKeId,OrderId into #temp from openxml(@idoc,''/Root/Traveller'')
	with(TuiId char(36),YouKeId char(36),OrderId char(36)) as traveller
	where not exists(select 1 from tbl_PlanTuiPiaoYouKe where TuiId=@TuiId and YouKeId=traveller.YouKeId)
	set @error=@error+@@error

	--�ж���Ʊ���ο��Ƿ����οͱ���ɾ��
	if exists(select 1 from #temp where YouKeId not in (select TravellerId from tbl_TourOrderTraveller where TourId=@KongWeiId))
	begin
		set @Result=-1 --���ڲ���������Ʊ���ο�
		RETURN @Result
	end

	--�ж���Ʊ�ο��Ƿ��ڵ�ǰ�ѳ�Ʊ����Ϣ����
	if exists(select 1 from #temp 	where YouKeId not in (select YouKeId from tbl_PlanChuPiaoYouKe  where PlanId=@PlanId))
	begin
		set @Result=-1 --���ڲ���������Ʊ���ο�
		RETURN @Result
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	--ɾ�����ο�
	select * into #temp1 from tbl_PlanTuiPiaoYouKe where TuiId=@TuiId 
	and YouKeId not in (select YouKeId from openxml(@idoc,''/Root/Traveller'') with(YouKeId char(36))) 

	begin transaction
	UPDATE tbl_PlanTuiPiao SET ShuLiang=@ShuLiang,TuiTime = @TuiTime,SunShiMX = @SunShiMX,
	SunShiAmount = @SunShiAmount,ChengDanFang = @ChengDanFang,
	TuiAmount = @TuiAmount,Remark = @Remark
	WHERE TuiId = @TuiId
	set @error=@error+@@error

	--���ο�״̬��Ϊ�ѳ�Ʊ״̬ TicketType: 
	--δ��Ʊ = 0,�ѳ�Ʊ = 1,����Ʊ = 2

	--����������Ʊ�ο�״̬��Ϊ����Ʊ
	UPDATE tbl_TourOrderTraveller SET TicketType=2
	Where TravellerId in (select YouKeId from #temp)
	set @error=@error+@@error

	--��ԭʼɾ������Ʊ�ο͸�Ϊ�ѳ�Ʊ״̬
	UPDATE tbl_TourOrderTraveller SET TicketType=1
	Where TravellerId in (select YouKeId from #temp1)
	set @error=@error+@@error
	
	--ɾ��������Ʊ�ο�
	DELETE FROM tbl_PlanTuiPiaoYouKe WHERE TuiId=@TuiId
	set @error=@error+@@error
	
	--���µ��ο���Ʊ��Ϣ���
	INSERT INTO tbl_PlanTuiPiaoYouKe(TuiId,YouKeId,OrderId)
	select @TuiId,YouKeId,OrderId  from openxml(@idoc,''/Root/Traveller'')
	with(TuiId char(36),YouKeId char(36),OrderId char(36))
	set @error=@error+@@error

	drop table #temp
	set @error=@error+@@error

	drop table #temp1
	set @error=@error+@@error

	exec sp_xml_removedocument @idoc
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=-2
		commit transaction
	end
	else
	begin
		set @Result=-3
		rollback transaction
	end
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_SheZhiDingDanStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_SheZhiDingDanStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-01
-- Description:	���ö���״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_TourOrder_SheZhiDingDanStatus]
	@DingDanId CHAR(36)--�������
	,@YuanYin NVARCHAR(MAX)--ԭ��
	,@Status TINYINT--״̬
	,@CaoZuoRenId INT--�����˱��
	,@RetCode INT OUTPUT
	,@CaoZuoShiJian DATETIME--����ʱ��
AS
BEGIN
	SET @RetCode=0
	DECLARE @YuanStatus TINYINT--����ԭ״̬
	DECLARE @DingDanZhanWeiRenShu INT--����ռλ����
	DECLARE @KongWeiId CHAR(36)--��λ���
	DECLARE @KongWeiShuLiang INT--��λ����
	DECLARE @ZongZaiWeiShuLiang INT--��ռλ����
	DECLARE @ShiJiChuPiaoShuLiang INT--ʵ�ʳ�Ʊ����
	DECLARE @KongWeiZhuangTai TINYINT
	
	IF NOT EXISTS(SELECT 1 FROM tbl_TourOrder WHERE OrderId=@DingDanId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @YuanStatus=OrderStatus,@DingDanZhanWeiRenShu=Accounts,@KongWeiId=TourId FROM tbl_TourOrder WHERE OrderId=@DingDanId
	SELECT @ZongZaiWeiShuLiang=ISNULL(SUM(Accounts),0) FROM tbl_TourOrder 
	WHERE IsDelete=''0'' AND TourId=@KongWeiId AND OrderId<>@DingDanId AND OrderStatus IN (0,1,4,5)	
	SELECT @ShiJiChuPiaoShuLiang=ISNULL(SUM(A.ShuLiang),0) FROM tbl_PlanChuPiao AS A WHERE A.KongWeiId=@KongWeiId
	SELECT @KongWeiShuLiang=ShuLiang,@KongWeiZhuangTai=KongWeiZhuangTai FROM tbl_KongWei WHERE KongWeiId=@KongWeiId	
	
	IF (@KongWeiZhuangTai=1)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF(@Status IN(3,7))
	BEGIN
		IF EXISTS(SELECT 1 FROM tbl_PlanDiJIeOrder WHERE OrderId=@DingDanId)
		BEGIN
			SET @RetCode=-97--���������ؽӰ��� ������ȡ�����ܾ�
			RETURN @RetCode
		END
		
		IF EXISTS(SELECT 1 FROM tbl_PlanChuPiaoYouKe WHERE OrderId=@DingDanId) OR EXISTS(SELECT 1 FROM tbl_PlanTuiPiaoYouKe WHERE OrderId=@DingDanId)
		BEGIN
			SET @RetCode=-96 --��������Ʊ���� ������ȡ�����ܾ�
			RETURN @RetCode
		END

		IF EXISTS(SELECT 1 FROM tbl_FinCope WHERE CollectionId=@DingDanId)
		BEGIN
			SET @RetCode=-95--�����������˿�Ǽ�  ������ȡ��
			RETURN @RetCode
		END
		
		IF EXISTS(SELECT 1 FROM tbl_TourOrderHotelPlan AS A WHERE A.OrderId=@DingDanId AND EXISTS(SELECT 1 FROM tbl_FinCope AS B WHERE B.CollectionId=A.Id))
		BEGIN
			SET @RetCode=-94 --�������ھƵ갲�����еǼ�֧������
			RETURN @RetCode
		END	
	END
	
	IF(@Status=3)--ȡ��
	BEGIN
		UPDATE tbl_TourOrder SET YuanYin1=@YuanYin,OrderStatus=@Status,LatestOperatorId=@CaoZuoRenId,LatestTime=@CaoZuoShiJian WHERE OrderId=@DingDanId
		SET @RetCode=1
		RETURN @RetCode
	END
	
	IF(@Status=7)--�ܾ�
	BEGIN
		UPDATE tbl_TourOrder SET YuanYin2=@YuanYin,OrderStatus=@Status,LatestOperatorId=@CaoZuoRenId,LatestTime=@CaoZuoShiJian WHERE OrderId=@DingDanId
		SET @RetCode=1
		RETURN @RetCode
	END	
	
		
	IF(@ZongZaiWeiShuLiang<@ShiJiChuPiaoShuLiang) SET @ZongZaiWeiShuLiang=@ShiJiChuPiaoShuLiang
	
	IF(@KongWeiShuLiang<@ZongZaiWeiShuLiang+@DingDanZhanWeiRenShu)--������λ����
	BEGIN
		SET @Status=6--������
	END
	
	UPDATE tbl_TourOrder SET OrderStatus=@Status,LatestOperatorId=@CaoZuoRenId,LatestTime=@CaoZuoShiJian WHERE OrderId=@DingDanId
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanTuiPiao_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanTuiPiao_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-20>
-- Description:	<����Ʊ�񡪡�ɾ����Ʊ>
-- Result :-1:�Ѿ������տ�Ǽǵ���Ʊ�������ɾ��
--		   -2:ɾ���ɹ�
--		   -3:ɾ��ʧ��		
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���		
-- =============================================
CREATE proc [dbo].[proc_PlanTuiPiao_Delete]
@TuiId char(36),
@Result int output
as
begin
	declare @error int
	set @error=0
	
	--�Ѿ������տ�Ǽǵ���Ʊ�������ɾ��.CollectionItem:Ʊ���˿� = 3,
	if exists(select 1 from tbl_FinCope where CollectionItem=3 and CollectionId=@TuiId)
	begin
		set @Result=-1
		return @Result
	end

	DECLARE @KongWeiId CHAR(36)
	SELECT @KongWeiId=KongWeiid FROM tbl_PlanTuiPiao WHERE TuiId=@TuiId
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	BEGIN TRAN
	--�޸��ο�״̬
	UPDATE tbl_TourOrderTraveller SET TicketType=1
	WHERE  TravellerId in (SELECT YouKeId FROM tbl_PlanTuiPiaoYouKe WHERE TuiId=@TuiId)
	set @error=@error+@@error
		
	--ɾ���ο���Ϣ
	DELETE FROM tbl_PlanTuiPiaoYouKe WHERE TuiId=@TuiId
	set @error=@error+@@error
	
	--ɾ����Ʊ������Ʊ��Ϣ
	DELETE FROM tbl_PlanTuiPiao WHERE TuiId=@TuiId
	set @error=@error+@@error
	

	if(@error=0)
	begin
		set @Result=-2
		commit transaction
	end
	else
	begin
		set @Result=-3
		rollback transaction
	end
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�����·>
-- Result :0:���ʧ�� 1:��ӳɹ�
-- History:
-- 1.2013-01-28 ����־ ����@Status
-- =============================================
CREATE proc [dbo].[proc_Route_Add]
	@RouteId char(36)--��·��Ʒ���
	,@CompanyId int--��˾���
	,@RouteName nvarchar(255)--��·����
	,@AreaId int--��·������
	,@RouteHeader nvarchar(255)--��·ҳü
	,@AreaDesc nvarchar(max)--��·����
	,@Days int--����
	,@RoutePic nvarchar(255)--��·ͼƬ
	,@TrafficStandard nvarchar(max)--��ͨ��׼
	,@StayStandard nvarchar(max)--ס�ޱ�ע
	,@DiningStandard nvarchar(max)--������׼
	,@AttractionsStandard nvarchar(max)--�����׼
	,@GuideStandard nvarchar(max)--���α�׼
	,@ShoppingStandard nvarchar(max)-- �����׼
	,@ChildStandard nvarchar(max)--��ͯ��׼
	,@InsuranceDesc nvarchar(max)--����˵��
	,@ExpenseRecommend nvarchar(max)-- �Է��Ƽ�
	,@Tips nvarchar(max)--��ܰ��ʾ
	,@InsideInfo nvarchar(max)--�ڲ���Ϣ
	,@RegistrationNotes nvarchar(max)--������֪
	,@OperatorId char(36)--����Ա���
	,@RoutePlan xml--��·�г̰���<Root><RoutePlan RouteId=\"{0}\" Days=\"{1}\" Content=\"{2}\" FilePath=\"{3}\" /></Root>
	,@Result int output
	,@Status TINYINT --��·״̬
	,@LeiXing tinyint
	,@GuoQiShiJian datetime
	,@ZhanDianId int
	,@ZxlbId int
	,@BiaoZhun tinyint
	,@JiHeDiDian nvarchar(max)
	,@JiHeShiJian nvarchar(max)
	,@SongTuanXinXi nvarchar(max)
	,@MuDiDiJieTuanFangShi nvarchar(max)
	,@FengMian NVARCHAR(255)
	,@ZxsId char(36)
	,@FuJianXml NVARCHAR(MAX)
as
begin
	declare @error int
	set @error=0
	DECLARE @hdoc INT
	
	begin transaction
	INSERT INTO tbl_Route(RouteId,CompanyId,RouteName,AreaId,RouteHeader
		,AreaDesc,Days,RoutePic,TrafficStandard,StayStandard
		,DiningStandard,AttractionsStandard,GuideStandard
		,ShoppingStandard,ChildStandard,InsuranceDesc
		,ExpenseRecommend,Tips,InsideInfo,RegistrationNotes
		,OperatorId,IssueTime,[Status]
		,[LeiXing],[GuoQiShiJian],[ZhanDianId]
		,[ZxlbId],[BiaoZhun],[JiHeDiDian]
		,[JiHeShiJian],[SongTuanXinXi],[MuDiDiJieTuanFangShi]
		,[ZxsId],[FengMian])
     VALUES(@RouteId,@CompanyId,@RouteName,@AreaId,@RouteHeader 
		,@AreaDesc,@Days,@RoutePic,@TrafficStandard,@StayStandard  
		,@DiningStandard,@AttractionsStandard,@GuideStandard 
		,@ShoppingStandard,@ChildStandard,@InsuranceDesc 
		,@ExpenseRecommend,@Tips,@InsideInfo,@RegistrationNotes  
		,@OperatorId,getdate(),@Status
		,@LeiXing,@GuoQiShiJian,@ZhanDianId
		,@ZxlbId,@BiaoZhun,@JiHeDiDian
		,@JiHeShiJian,@SongTuanXinXi,@MuDiDiJieTuanFangShi
		,@ZxsId,@FengMian)
	set @error=@error+@@error
	
	if(@RoutePlan is not null)
	begin
		declare @idoc int
		exec sp_xml_preparedocument @idoc output,@RoutePlan
		INSERT INTO tbl_RoutePlan(RouteId,Days,[Content],FilePath)
		select @RouteId,Days,[Content],FilePath
		from openxml(@idoc,''/Root/RoutePlan'')
		with(Days int,[Content] nvarchar(max),FilePath varchar(255))
		set @error=@error+@@error
	end
	
	DELETE FROM [tbl_Pt_RouteFuJian] WHERE RouteId=@RouteId
	IF(LEN(@FuJianXml)>8)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@FuJianXml
		INSERT INTO [tbl_Pt_RouteFuJian]([RouteId],[LeiXing],[Filepath],[MiaoShu])
		SELECT @RouteId,[LeiXing],[Filepath],[MiaoShu] FROM OPENXML(@hdoc,''/root/info'',3)
		WITH([LeiXing] INT,[Filepath] NVARCHAR(255),[MiaoShu] NVARCHAR(255))
		EXEC sp_xml_removedocument @hdoc
	END
	
	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�޸���·>
-- Result :0:�޸�ʧ�� 1:�޸ĳɹ�
-- History:
-- 1.2013-01-28 ����־ ����@Status
-- =============================================
CREATE proc [dbo].[proc_Route_Update]
	@RouteId char(36)--��·��Ʒ���
	,@CompanyId int--��˾���
	,@RouteName nvarchar(255)--��·����
	,@AreaId int--��·������
	,@RouteHeader nvarchar(255)--��·ҳü
	,@AreaDesc nvarchar(max)--��·����
	,@Days int--����
	,@RoutePic nvarchar(255)--��·ͼƬ
	,@TrafficStandard nvarchar(max)--��ͨ��׼
	,@StayStandard nvarchar(max)--ס�ޱ�ע
	,@DiningStandard nvarchar(max)--������׼
	,@AttractionsStandard nvarchar(max)--�����׼
	,@GuideStandard nvarchar(max)--���α�׼
	,@ShoppingStandard nvarchar(max)-- �����׼
	,@ChildStandard nvarchar(max)--��ͯ��׼
	,@InsuranceDesc nvarchar(max)--����˵��
	,@ExpenseRecommend nvarchar(max)-- �Է��Ƽ�
	,@Tips nvarchar(max)--��ܰ��ʾ
	,@InsideInfo nvarchar(max)--�ڲ���Ϣ
	,@RegistrationNotes nvarchar(max)--������֪
	,@OperatorId char(36)--����Ա���
	,@RoutePlan xml--��·�г̰���<Root><RoutePlan RouteId=\"{0}\" Days=\"{1}\" Content=\"{2}\" FilePath=\"{3}\" /></Root>
	,@Result int output
	,@Status TINYINT --��·״̬
	,@LeiXing tinyint
	,@GuoQiShiJian datetime
	,@ZhanDianId int
	,@ZxlbId int
	,@BiaoZhun tinyint
	,@JiHeDiDian nvarchar(max)
	,@JiHeShiJian nvarchar(max)
	,@SongTuanXinXi nvarchar(max)
	,@MuDiDiJieTuanFangShi nvarchar(max)
	,@ZxsId char(36)
	,@FengMian NVARCHAR(MAX)
	,@FuJianXml NVARCHAR(MAX)
as
begin
	declare @error int
	set @error=0
	DECLARE @hdoc INT
	
	begin transaction
	UPDATE tbl_Route SET RouteName = @RouteName
		,AreaId = @AreaId,RouteHeader = @RouteHeader
		,AreaDesc = @AreaDesc,Days = @Days,RoutePic = @RoutePic
		,TrafficStandard = @TrafficStandard,StayStandard = @StayStandard
		,DiningStandard = @DiningStandard,AttractionsStandard = @AttractionsStandard
		,GuideStandard = @GuideStandard,ShoppingStandard = @ShoppingStandard
		,ChildStandard = @ChildStandard,InsuranceDesc = @InsuranceDesc
		,ExpenseRecommend = @ExpenseRecommend,Tips = @Tips
		,InsideInfo = @InsideInfo,RegistrationNotes = @RegistrationNotes
		,[Status]=@Status
		,LeiXing=@LeiXing,GuoQiShiJian=@GuoQiShiJian
		,ZhanDianId=@ZhanDianId,ZxlbId=@ZxlbId
		,BiaoZhun=@BiaoZhun,JiHeDiDian=@JiHeDiDian
		,JiHeShiJian=@JiHeShiJian,SongTuanXinXi=@SongTuanXinXi
		,MuDiDiJieTuanFangShi=@MuDiDiJieTuanFangShi,ZxsId=@ZxsId
		,FengMian=@FengMian
	WHERE RouteId=@RouteId
	set @error=@error+@@error
	
	delete from tbl_RoutePlan where RouteId=@RouteId
	set @error=@error+@@error
	
	if(@RoutePlan is not null)
	begin
		declare @idoc int
		exec sp_xml_preparedocument @idoc output,@RoutePlan
		INSERT INTO tbl_RoutePlan(RouteId,Days,[Content],FilePath)
		select @RouteId,Days,[Content],FilePath
		from openxml(@idoc,''/Root/RoutePlan'')
		with(Days int,[Content] nvarchar(max),FilePath varchar(255))
		set @error=@error+@@error
	end
	
	DELETE FROM [tbl_Pt_RouteFuJian] WHERE RouteId=@RouteId
	IF(LEN(@FuJianXml)>8)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@FuJianXml
		INSERT INTO [tbl_Pt_RouteFuJian]([RouteId],[LeiXing],[Filepath],[MiaoShu])
		SELECT @RouteId,[LeiXing],[Filepath],[MiaoShu] FROM OPENXML(@hdoc,''/root/info'',3)
		WITH([LeiXing] INT,[Filepath] NVARCHAR(255),[MiaoShu] NVARCHAR(255))
		EXEC sp_xml_removedocument @hdoc
	END
	
	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_XiaoXi_GetZxsXiaoXi]    Script Date: 09/29/2014 16:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_XiaoXi_GetZxsXiaoXi]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-22
-- Description:	��ȡ��Ϣ-ר���̺�̨
-- =============================================
CREATE PROCEDURE [dbo].[proc_XiaoXi_GetZxsXiaoXi]
	@CompanyId INT--��˾���
	,@ZxsId CHAR(36)--ר���̱��
	,@YongHuId INT--��¼�û����
AS
BEGIN
	DECLARE @TEMP TABLE(LeiXing TINYINT,ShuLiang INT,IdentityId INT IDENTITY)
	--LeiXing:EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing
	DECLARE @ShuLiang INT
	
	--δȷ�϶���
	SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId AND IsDelete=''0'' AND OrderStatus=4
	INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(0,@ShuLiang)
    --�����ж���
    SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId AND IsDelete=''0'' AND OrderStatus=6
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(1,@ShuLiang)
    --������ȫ����
    SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId AND IsDelete=''0'' AND OrderStatus=5
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(2,@ShuLiang)
    --Ԥ������
    SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId AND IsDelete=''0'' AND OrderStatus=0
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(3,@ShuLiang)
    --δ����һ�����
    SELECT @ShuLiang=COUNT(*) FROM tbl_Pt_JiFenDingDan WHERE CompanyId=@CompanyId AND [Status]=0
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(4,@ShuLiang)
    --δ���ע���û�    
    SELECT @ShuLiang=COUNT(*) FROM tbl_Customer WHERE CompanyId=@CompanyId AND ShenHeStatus=0
	INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(5,@ShuLiang)
	
	SELECT * FROM @TEMP ORDER BY IdentityId ASC
END
' 
END
GO
/****** Object:  View [dbo].[view_Fin_FuKuanShenPi]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_FuKuanShenPi]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:�������-��������
-- =============================================
CREATE VIEW [dbo].[view_Fin_FuKuanShenPi]
AS
--�ؽ�֧������
SELECT A.*,B.JiaoYiHao
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,(CASE A.Status WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 2 THEN 2 END) AS SortId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_PlanDiJie] AS B
ON A.CollectionId=B.PlanId
WHERE A.CollectionItem=102
UNION ALL
--Ʊ��Ѻ�𸶿�
SELECT A.*,B.GysOrderCode AS JiaoYiHao
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,(CASE A.Status WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 2 THEN 2 END) AS SortId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_KongWeiDaiLi] AS B
ON A.CollectionId=B.DaiLiId
WHERE A.CollectionItem=103
UNION ALL
--Ʊ���Ÿ���
SELECT A.*,B.JiaoYiHao
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,(CASE A.Status WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 2 THEN 2 END) AS SortId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_PlanChuPiao] AS B
ON A.CollectionId=B.PlanId
WHERE A.CollectionItem=104
UNION ALL
--�Ƶ갲�Ÿ���
SELECT A.*,B.JIaoYiHao
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,(CASE A.Status WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 2 THEN 2 END) AS SortId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_TourOrderHotelPlan] AS B
ON A.CollectionId=B.Id
WHERE A.CollectionItem=105
UNION ALL
--����֧������
SELECT A.*,'''' AS JiaoYiHao
	,(SELECT C.Name FROM tbl_Customer AS C WHERE C.Id=B.CustromCId) AS WangLaiDanWeiName
	,(CASE A.Status WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 2 THEN 2 END) AS SortId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinOther] AS B
ON A.CollectionId=B.Id AND B.CustromType=0
WHERE A.CollectionItem=108
UNION ALL
--����֧������
SELECT A.*,'''' AS JiaoYiHao
	,(SELECT D.UnitName FROM [tbl_CompanySupplier] AS D WHERE D.Id=B.CustromCId) AS WangLaiDanWeiName
	,(CASE A.Status WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 2 THEN 2 END) AS SortId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinOther] AS B
ON A.CollectionId=B.Id AND B.CustromType=1
WHERE A.CollectionItem=108

'
GO
/****** Object:  View [dbo].[view_Fin_QiTaShouZhi]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaShouZhi]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:�������-������֧
-- History:
-- 1.2013-08-08 ����־ ��ṹ�޸ĸ�����ͼ
-- =============================================
CREATE VIEW [dbo].[view_Fin_QiTaShouZhi]
AS
SELECT A.*,B.Name AS KeHuName
FROM tbl_FinOther AS A INNER JOIN tbl_Customer AS B
ON A.CustromCId=B.Id
WHERE A.CustromType=0  
UNION ALL
SELECT A.*,B.UnitName AS KeHuName
FROM tbl_FinOther AS A INNER JOIN tbl_CompanySupplier AS B
ON A.CustromCId=B.Id
WHERE A.CustromType=1

'
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_YuanGong_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_YuanGong_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-04
-- Description:	ƽ̨-Ա��ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_YuanGong_D]
	@KeHuId CHAR(36)
	,@KeHuLxrId INT
	,@YongHuId INT
	,@CompanyId INT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @KeHuLxrStatus TINYINT
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Customer WHERE Id=@KeHuId AND IsDelete=''0'' AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CustomerContactInfo WHERE ID=@KeHuLxrId AND CustomerId=@KeHuId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF (@YongHuId>0 AND NOT EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE Id=@YongHuId AND KeHuId=@KeHuId AND CompanyId=@CompanyId))
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF (@YongHuId>0 AND EXISTS(SELECT 1 FROM tbl_TourOrder WHERE OperatorId=@YongHuId))
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END	
	
	IF EXISTS(SELECT 1 FROM tbl_TourOrder WHERE BuyOperatorId=@KeHuLxrId)
	BEGIN
		SET @RetCode=-95
		RETURN @RetCode
	END
	
	SELECT @KeHuLxrStatus=[Status] FROM tbl_CustomerContactInfo WHERE Id=@KeHuLxrId
	
	IF(@KeHuLxrStatus<>0)
	BEGIN
		SET @RetCode=-94
		RETURN @RetCode
	END
	
	IF(@YongHuId>0)
	BEGIN
		UPDATE tbl_CompanyUser SET IsDelete=''1'' WHERE Id=@YongHuId AND KeHuId=@KeHuId
	END
	
	DELETE FROM tbl_CustomerContactInfo WHERE Id=@KeHuLxrId AND CustomerId=@KeHuId
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_KeHu_U]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_KeHu_U]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-03
-- Description:	ƽ̨-�ͻ�������Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_KeHu_U]
	@KeHuId CHAR(36)
	,@ShengFenId int
	,@ChengShiId int
	,@KeHuName nvarchar(255)
	,@XuKeZhengHao NVARCHAR(255)
	,@YingYeZhiZhaoHao NVARCHAR(255)
	,@DiZhi nvarchar(255)
	,@CompanyId int
	,@LxrName nvarchar(255)
	,@LxrDianHua nvarchar(255)
	,@LxrShouJi nvarchar(255)
	,@OperatorId int
	,@IssueTime datetime
	,@FaRenName nvarchar(50)
	,@LxrQQ nvarchar(50)
	,@LxrEmail nvarchar(50)
	,@GongSiDianHua nvarchar(50)
	,@GongSiFax nvarchar(50)
	,@LogoFilepath nvarchar(255)
	,@JieShao NVARCHAR(MAX)
	,@DanJuDaYinMoBan NVARCHAR(255)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	IF NOT EXISTS(SELECT 1 FROM tbl_Customer WHERE Id=@KeHuId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	UPDATE tbl_Customer SET [ProviceId]=@ShengFenId,[CityId]=@ChengShiId
		,Adress=@DiZhi,GongSiDianHua=@GongSiDianHua
		,GongSiFax=@GongSiFax,ContactName=@LxrName
		,Phone=@LxrDianHua,Mobile=@LxrShouJi
		,LxrQQ=@LxrQQ,LxrEmail=@LxrEmail
		,Logo=@LogoFilepath,JieShao=@JieShao
		,DanJuDaYinMoBan=@DanJuDaYinMoBan	
	WHERE Id=@KeHuId
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  View [dbo].[view_Pt_DingDan]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_DingDan]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-01
-- Description: ƽ̨-��λ
-- =============================================
CREATE VIEW [dbo].[view_Pt_DingDan]
AS
SELECT A.OrderId
	,A.OrderCode
	,A.CompanyId
	,A.TourId
	,A.BusinessType
	,A.Adults
	,A.Childs
	,A.YingErRenShu
	,A.BuZhanWeiRenShu
	,A.Bears
	,A.Accounts
	,A.BuyCompanyId
	,A.BuyOperatorId
	,A.RouteId
	,A.SumPrice
	,A.OperatorId
	,A.OrderStatus
	,A.IssueTime
	,A.CheckMoney
	,A.ReturnMoney
	,A.ZxsId
	,A.LatestOperatorId
	,A.LatestTime
	,A.XiaDanLeiXing
	,A.XianLuId
	,A.JiFen1
	,A.JiFen2
	,A.YuanYin1
	,A.YuanYin2
	,B.Name AS KeHuName
	,C.QuDate
	,(SELECT A1.Name FROM tbl_CustomerContactInfo AS A1 WHERE A1.Id=A.BuyOperatorId) AS KeHuLxrName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS XiaDanRenName
	,(SELECT A1.MingCheng FROM tbl_Pt_ZhuanXianShang AS A1 WHERE A1.ZxsId=A.ZxsId) AS ZxsName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.LatestOperatorId) AS LatestOperatorName
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName	
FROM tbl_TourOrder AS A INNER JOIN tbl_Customer AS B
ON A.BuyCompanyId=B.Id INNER JOIN tbl_KongWei AS C
ON A.TourId=C.KongWeiID AND C.IsDelete=''0''
WHERE A.IsDelete=''0''
'
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_KeHu_ZhuCe]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_KeHu_ZhuCe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-26
-- Description:	�ͻ�ע��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_KeHu_ZhuCe]
	@CompanyId INT--��˾���
	,@KeHuId CHAR(36)--�ͻ����
	,@KeHuName NVARCHAR(255)--�ͻ�����
	,@KeHuShengFenId INT--�ͻ�����ʡ�ݱ��
	,@KeHuChengShiId INT--�ͻ����ڳ��б��
	,@KeHuDiZhi NVARCHAR(255)--�ͻ���ַ
	,@KeHuDianHua NVARCHAR(255)--�ͻ��绰
	,@KeHuFax NVARCHAR(255)--�ͻ�����
	,@YongHuMing NVARCHAR(255)--�û�����
	,@YongHuYouXiang NVARCHAR(255)--�û�����
	,@YongHuXingMing NVARCHAR(255)--�û�����
	,@YongHuDianHua NVARCHAR(255)--�û��绰
	,@YongHuShouJi NVARCHAR(255)--�û��ֻ�
	,@YongHuMiMa NVARCHAR(255)--�û�����
	,@YongHuMiMaMd5 NVARCHAR(255)--�û�����MD5
	,@ShenHeStatus TINYINT--�ͻ����״̬
	,@LaiYuan TINYINT--�ͻ���Դ
	,@LeiXing TINYINT--�ͻ�����
	,@ZhuCeShiJian DATETIME--ע��ʱ��
	,@RetCode INT OUTPUT
AS
BEGIN	
	DECLARE @errorcount INT	
	DECLARE @LxrId INT
	DECLARE @YongHuId INT
	
	SET @RetCode=0
	SET @LxrId=0
	SET @YongHuId=0
	SET @errorcount=0
	
	--�ͻ����Ƽ��
	IF EXISTS(SELECT 1 FROM tbl_Customer WHERE CompanyId=@CompanyId AND Name=@KeHuName AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	--�û������
	IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId  AND Username=@YongHuMing)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END	
	
	--�û�������
	IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND ContactEmail=@YongHuYouXiang)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	BEGIN TRAN
	
	INSERT INTO [tbl_Customer]([Id],[ProviceId],[CityId]
		,[Type],[Name],[Licence]
		,[Adress],[PostalCode],[FilePath]
		,[SaleId],[CompanyId],[IsEnable]
		,[ContactName],[Phone],[Mobile]
		,[Fax],[Remark],[OperatorId]
		,[IssueTime],[IsDelete],[WZID]
		,[ZxsId],[LaiYuan],[ShenHeStatus]
		,[ShenHeOperatorId],[ShenHeTime],[YingYeZhiZhaoHao]
		,[FaRenName],[LxrQQ],[LxrEmail]
		,[GongSiDianHua],[GongSiFax],[JianMa]
		,[JieShao],[Logo],[LatestOperatorId]
		,[LatestTime])
	VALUES(@KeHuId,@KeHuShengFenId,@KeHuChengShiId
		,@LeiXing,@KeHuName,''''
		,@KeHuDiZhi,'''',''''
		,0,@CompanyId,''1''
		,@YongHuXingMing,@YongHuDianHua,@YongHuShouJi
		,@KeHuFax,'''',0
		,@ZhuCeShiJian,''0'',''''
		,'''',@LaiYuan,@ShenHeStatus
		,0,@ZhuCeShiJian,''''
		,@YongHuXingMing,'''',@YongHuYouXiang
		,@KeHuDianHua,@KeHuFax,''''
		,'''','''',0
		,@ZhuCeShiJian)
	SET @errorcount=@errorcount+@@ERROR
	
	INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password]
		,[MD5Password],[ContactName],[ContactSex]
		,[ContactTel],[ContactFax],[ContactMobile]
		,[ContactEmail],[QQ],[MSN]
		,[JobName],[LastLoginIP],[LastLoginTime]
		,[RoleID],[PermissionList],[PeopProfile]
		,[Remark],[IsDelete],[UserStatus]
		,[IsAdmin],[IssueTime],[DepartId]
		,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
		,[LeiXing],[ZxsId],[KeHuId]
		,[KeHuLxrId])
	VALUES(@CompanyId,@YongHuMing,@YongHuMiMa
		,@YongHuMiMaMd5,@YongHuXingMing,''0''
		,@YongHuDianHua,@KeHuFax,@YongHuShouJi
		,@YongHuYouXiang,'''',''''
		,'''','''',GETDATE()
		,0,'''',''''
		,'''',''0'',1
		,''0'',GETDATE(),0
		,0,0,''''
		,1,'''',@KeHuId
		,@LxrId)
	SET @errorcount=@errorcount+@@ERROR
	SET @YongHuId=SCOPE_IDENTITY()	
	
	INSERT INTO [tbl_CustomerContactInfo]([CustomerId],[CompanyId],[JobId]
		,[DepartmentId],[Sex],[Name]
		,[Tel],[Mobile],[qq]
		,[BirthDay],[Email],[Spetialty]
		,[Hobby],[Remark],[Fax]
		,[YongHuId],[Status])
	VALUES( @KeHuId,@CompanyId,''''
		,'''',''0'',@YongHuXingMing
		,@YongHuDianHua,@YongHuShouJi,''''
		,NULL,@YongHuYouXiang,''''
		,'''','''',@KeHuFax
		,@YongHuId,0)
	SET @errorcount=@errorcount+@@ERROR
	SET @LxrId=SCOPE_IDENTITY()	
	
	UPDATE [tbl_CompanyUser] SET [KeHuLxrId]=@LxrId WHERE Id=@YongHuId
	SET @errorcount=@errorcount+@@ERROR
	
	UPDATE [tbl_Customer] SET LatestOperatorId=@YongHuId WHERE Id=@KeHuId
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHu_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHu_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-22
-- Description: �ͻ�����ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_KeHu_D]
	@CompanyId INT--��˾���
	,@ZxsId CHAR(36)--��ǰ����ԱZxsId
	,@KeHuId CHAR(36)--�ͻ����
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @KeHuZxsId CHAR(36)
	DECLARE @LaiYuan TINYINT
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Customer WHERE Id=@KeHuId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @KeHuZxsId=ZxsId,@LaiYuan=LaiYuan FROM tbl_Customer WHERE Id=@KeHuId
	
	IF(@LaiYuan=0 AND @KeHuZxsId<>@ZxsId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_TourOrder WHERE BuyCompanyId=@KeHuId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_CustomerContactInfo WHERE CustomerId=@KeHuId AND YongHuId>0)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	UPDATE tbl_Customer SET IsDelete=''1'' WHERE Id=@KeHuId
	
	SET @RetCode=1
	RETURN @RetCode
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHu_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHu_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-21
-- Description:	�ͻ�����-�������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_KeHu_CU]
	@KeHuId char(36)
	,@ProviceId int
	,@CityId int
	,@Type tinyint
	,@Name nvarchar(250)
	,@Licence nvarchar(250)
	,@Adress nvarchar(250)
	,@PostalCode nvarchar(250)
	,@FilePath nvarchar(255)
	,@SaleId int
	,@CompanyId int
	,@IsEnable char(1)
	,@ContactName nvarchar(255)
	,@Phone nvarchar(250)
	,@Mobile nvarchar(250)
	,@Fax nvarchar(200)
	,@Remark nvarchar(max)
	,@OperatorId int
	,@IssueTime datetime
	,@ZxsId char(36)
	,@LaiYuan tinyint
	,@ShenHeStatus tinyint
	,@ShenHeOperatorId int
	,@ShenHeTime datetime
	,@YingYeZhiZhaoHao nvarchar(50)
	,@FaRenName nvarchar(50)
	,@LxrQQ nvarchar(50)
	,@LxrEmail nvarchar(50)
	,@GongSiDianHua nvarchar(50)
	,@GongSiFax nvarchar(50)
	,@JianMa nvarchar(50)
	,@LxrXml NVARCHAR(MAX)
	,@YinHangZhangHuXml NVARCHAR(MAX)
	,@FuJianXml NVARCHAR(MAX)
	,@RetCode INT OUTPUT	
AS
BEGIN
	DECLARE @hdoc INT
	DECLARE @errorcount INT
	DECLARE @FS NVARCHAR(50)
	SET @FS=''INSERT''
	SET @errorcount=0
	SET @RetCode=0
	
	IF EXISTS(SELECT 1 FROM tbl_Customer WHERE Id=@KeHuId)
	BEGIN
		SET @FS=''UPDATE''
	END
	
	--�ͻ����Ƽ��
	IF EXISTS(SELECT 1 FROM tbl_Customer WHERE Id<>@KeHuId AND Name=@Name AND CompanyId=@CompanyId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	BEGIN TRAN
	
	IF(@FS=''INSERT'')
	BEGIN
		INSERT INTO [tbl_Customer]([Id],[ProviceId],[CityId]
			,[Type],[Name],[Licence]
			,[Adress],[PostalCode],[FilePath]
			,[SaleId],[CompanyId],[IsEnable]
			,[ContactName],[Phone],[Mobile]
			,[Fax],[Remark],[OperatorId]
			,[IssueTime],[IsDelete],[WZID]
			,[ZxsId],[LaiYuan],[ShenHeStatus]
			,[ShenHeOperatorId],[ShenHeTime],[YingYeZhiZhaoHao]
			,[FaRenName],[LxrQQ],[LxrEmail]
			,[GongSiDianHua],[GongSiFax],[JianMa]
			,[JieShao],[Logo],[LatestOperatorId]
			,[LatestTime])
		VALUES(@KeHuId,@ProviceId,@CityId
			,@Type,@Name,@Licence
			,@Adress,@PostalCode,@FilePath
			,@SaleId,@CompanyId,@IsEnable
			,@ContactName,@Phone,@Mobile
			,@Fax,@Remark,@OperatorId
			,@IssueTime,''0'',''''
			,@ZxsId,@LaiYuan,@ShenHeStatus
			,@ShenHeOperatorId,@ShenHeTime,@YingYeZhiZhaoHao
			,@FaRenName,@LxrQQ,@LxrEmail
			,@GongSiDianHua,@GongSiFax,@JianMa
			,'''','''',@OperatorId
			,@IssueTime)
		SET @errorcount=@@ERROR
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		UPDATE [tbl_Customer] SET [ProviceId]=@ProviceId,[CityId]=@CityId
			,[Type]=@Type,[Name]=@Name
			,[Licence]=@Licence,[Adress]=@Adress
			,[PostalCode]=@PostalCode,[FilePath]=@FilePath
			,[SaleId]=@SaleId,[ContactName]=@ContactName
			,[Phone]=@Phone,[Mobile]=@Mobile
			,[Fax]=@Fax,[Remark]=@Remark
			,[YingYeZhiZhaoHao]=@YingYeZhiZhaoHao,[FaRenName]=@FaRenName
			,[LxrQQ]=@LxrQQ,[LxrEmail]=@LxrEmail
			,[GongSiDianHua]=@GongSiDianHua,[GongSiFax]=@GongSiFax
			,[JianMa]=@JianMa,[LatestOperatorId]=@OperatorId
			,[LatestTime]=@IssueTime
		WHERE [Id]=@KeHuId
		SET @errorcount=@@ERROR
	END
	
	--�ͻ������˻�
	DELETE FROM tbl_CustomerAccount WHERE Id=@KeHuId
	SET @errorcount=@@ERROR
	
	IF(@YinHangZhangHuXml IS NOT NULL AND LEN(@YinHangZhangHuXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@YinHangZhangHuXml
		INSERT INTO [tbl_CustomerAccount]([Id],[AccountName],[BankName],[BankNo])
		SELECT @KeHuId,[AccountName],[BankName],[BankNo]
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH([AccountName] NVARCHAR(50),[BankName] NVARCHAR(50),[BankNo] NVARCHAR(50))
		SET @errorcount=@@ERROR
		EXEC sp_xml_removedocument @hdoc
	END
	
	--��ϵ��
	DECLARE @TEMP1 TABLE(LxrId INT,ZhiWu NVARCHAR(50),BuMen NVARCHAR(50)
		,XingBie CHAR(1),XingMing NVARCHAR(50),DianHua NVARCHAR(50)
		,ShouJi NVARCHAR(50),QQ NVARCHAR(50),ShengRi DATETIME
		,Email NVARCHAR(50),Fax NVARCHAR(50),[Status] TINYINT
		,T1 CHAR(1)--C:���� U:�޸�
		,T2 INT--�û����
		,WeiXinHao NVARCHAR(50)
	)
	
	IF(@LxrXml IS NOT NULL AND LEN(@LxrXml)>0)
	BEGIN
	EXEC sp_xml_preparedocument @hdoc OUTPUT,@LxrXml
		INSERT INTO @TEMP1(LxrId,ZhiWu,BuMen
			,XingBie,XingMing,DianHua
			,ShouJi,QQ,ShengRi
			,Email,Fax,[Status]
			,T1,T2,WeiXinHao)
		SELECT LxrId,ZhiWu,BuMen
			,XingBie,XingMing,DianHua
			,ShouJi,QQ,ShengRi
			,Email,Fax,[Status]
			,''C'',0,WeiXinHao
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(LxrId INT,ZhiWu NVARCHAR(50),BuMen NVARCHAR(50)
			,XingBie CHAR(1),XingMing NVARCHAR(50),DianHua NVARCHAR(50)
			,ShouJi NVARCHAR(50),QQ NVARCHAR(50),ShengRi DATETIME
			,Email NVARCHAR(50),Fax NVARCHAR(50),[Status] TINYINT
			,WeiXinHao NVARCHAR(50))	
		EXEC sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP1 SET T1=''U'' WHERE LxrId>0
	UPDATE @TEMP1 SET T2=B.YongHuId
	FROM @TEMP1 AS A INNER JOIN tbl_CustomerContactInfo AS B ON A.LxrId=B.Id
	WHERE A.T1=''U''
	
	DELETE FROM [tbl_CustomerContactInfo] WHERE CustomerId=@KeHuId 
		AND Id NOT IN(SELECT LxrId FROM @TEMP1)
		AND YongHuId=0 
		AND NOT EXISTS(SELECT 1 FROM tbl_TourOrder WHERE BuyOperatorId=[tbl_CustomerContactInfo].Id AND BuyCompanyId=@KeHuId)
	SET @errorcount=@@ERROR	
	
	UPDATE tbl_CustomerContactInfo SET JobId=B.ZhiWu
		,DepartmentId=B.BuMen,Sex=B.XingBie
		,Name=B.XingMing,Tel=B.DianHua
		,Mobile=B.ShouJi,qq=B.QQ
		,BirthDay=B.ShengRi
		,Fax=B.Fax,[Status]=B.[Status]
		,WeiXinHao=B.WeiXinHao		
	FROM tbl_CustomerContactInfo AS A INNER JOIN @TEMP1 AS B 
	ON A.Id=B.LxrId AND B.T1=''U''
	WHERE A.CustomerId=@KeHuId
	SET @errorcount=@@ERROR
	
	--ͬ���û���Ϣ
	UPDATE tbl_CompanyUser SET ContactName=B.XingMing,ContactTel=B.DianHua
		,ContactFax=B.Fax,ContactMobile=B.ShouJi
		,QQ=B.QQ,WeiXinHao=B.WeiXinHao
	FROM tbl_CompanyUser AS A INNER JOIN @TEMP1 AS B
	ON A.Id=B.T2 AND B.T1=''U''
	WHERE A.KeHuId=@KeHuId	
	
	INSERT INTO [tbl_CustomerContactInfo]([CustomerId],[CompanyId],[JobId]
		,[DepartmentId],[Sex],[Name]
		,[Tel],[Mobile],[qq]
		,[BirthDay],[Email],[Spetialty]
		,[Hobby],[Remark],[Fax]
		,[YongHuId],[Status],[WeiXinHao])
	SELECT @KeHuId,@CompanyId,ZhiWu
		,BuMen,XingBie,XingMing
		,DianHua,Email,QQ
		,ShengRi,Email,''''
		,'''','''',@Fax
		,0,[Status],WeiXinHao
	FROM @TEMP1 WHERE T1=''C''
	SET @errorcount=@@ERROR
	
	--����
	DELETE FROM [tbl_ComapnyFile] WHERE CompanyId=@CompanyId AND ItemType=1 AND ItemId=@KeHuId
	SET @errorcount=@@ERROR	
	
	IF(@FuJianXml IS NOT NULL AND LEN(@FuJianXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@FuJianXml
		INSERT INTO [tbl_ComapnyFile]([FileId],[CompanyId],[FilePath]
			,[IssueTime],[ItemType],[ItemId])
		SELECT FileId,@CompanyId,Filepath
			,GETDATE(),ItemType,@KeHuId
		FROM OPENXML(@hdoc,''/root/info'')
		WITH(FileId CHAR(36),Filepath NVARCHAR(255),ItemType TINYINT)
		SET @errorcount=@@ERROR
		EXEC sp_xml_removedocument @hdoc	
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	COMMIT TRAN
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHuLxr_YongHu_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHuLxr_YongHu_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-26
-- Description:	�ͻ���ϵ���˺��������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_KeHuLxr_YongHu_CU]
	@KeHuId CHAR(36)
	,@LxrId INT
	,@YongHuMing NVARCHAR(255)
	,@MiMa NVARCHAR(255)
	,@Md5MiMa NVARCHAR(255)
	,@YouXiang NVARCHAR(255)
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @YongHuId INT
	DECLARE @CompanyId INT
	
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Customer WHERE Id=@KeHuId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CustomerContactInfo WHERE ID=@LxrId AND CustomerId=@KeHuId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	SELECT @CompanyId=CompanyId FROM tbl_Customer WHERE Id=@KeHuId
	SELECT @YongHuId=YongHuId FROM tbl_CustomerContactInfo WHERE ID=@LxrId
	
	IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND ID<>@YongHuId AND Username=@YongHuMing)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END	
	
	IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND ID<>@YongHuId AND ContactEmail=@YouXiang)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	
	IF(@YongHuId=0)
	BEGIN
		INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password]
			,[MD5Password],[ContactName],[ContactSex]
			,[ContactTel],[ContactFax],[ContactMobile]
			,[ContactEmail],[QQ],[MSN]
			,[JobName],[LastLoginIP],[LastLoginTime]
			,[RoleID],[PermissionList],[PeopProfile]
			,[Remark],[IsDelete],[UserStatus]
			,[IsAdmin],[IssueTime],[DepartId]
			,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
			,[LeiXing],[ZxsId],[KeHuId]
			,[KeHuLxrId])
		SELECT @CompanyId,@YongHuMing,@MiMa
			,@Md5MiMa,A.Name,A.Sex
			,A.Tel,A.Fax,A.Mobile
			,@YouXiang,A.QQ,''''
			,'''','''',GETDATE()
			,0,'''',''''
			,'''',''0'',1
			,''0'',GETDATE(),0
			,0,0,''''
			,1,'''',@KeHuid
			,@LxrId
		FROM tbl_CustomerContactInfo AS A
		WHERE A.Id=@LxrId
		SET @YongHuId=SCOPE_IDENTITY()
		
		UPDATE tbl_CustomerContactInfo SET YongHuId=@YongHuId,Email=@YouXiang WHERE Id=@LxrId
	END
	ELSE
	BEGIN
		IF(LEN(@MiMa)>0 AND LEN(@Md5MiMa)>0)
		BEGIN
			UPDATE [tbl_CompanyUser] SET [Password]=@MiMa,[MD5Password]=@Md5MiMa WHERE Id=@YongHuId
		END
		
		UPDATE [tbl_CompanyUser] SET [ContactEmail]=@YouXiang WHERE Id=@YongHuId
		UPDATE tbl_CustomerContactInfo SET YongHuId=@YongHuId,Email=@YouXiang WHERE Id=@LxrId
	END
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KeHuLxr_YongHu_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KeHuLxr_YongHu_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-26
-- Description:	�ͻ���ϵ���˺�ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_KeHuLxr_YongHu_D]
	@KeHuId CHAR(36)
	,@LxrId INT
	,@YongHuId INT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Customer WHERE Id=@KeHuId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CustomerContactInfo WHERE ID=@LxrId AND CustomerId=@KeHuId AND YongHuId=@YongHuId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE Id=@YongHuId AND KeHuId=@KeHuId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_TourOrder WHERE OperatorId=@YongHuId)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END	
	
	UPDATE tbl_CompanyUser SET IsDelete=''1'' WHERE Id=@YongHuId AND KeHuId=@KeHuId
	UPDATE tbl_CustomerContactInfo SET YongHuId=0 WHERE Id=@LxrId AND CustomerId=@KeHuId
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  View [dbo].[view_Fin_QiTaShouRu]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaShouRu]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2013-02-19
-- Description:�������-��������
-- History:
-- 1.2013-08-08 ����־ ��ṹ�޸ĸ�����ͼ
-- =============================================
CREATE VIEW [dbo].[view_Fin_QiTaShouRu]
AS
SELECT A.*,B.Name AS KeHuName
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=1 AND A1.CollectionItem=4),0) AS YiShenPiJinE
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=0 AND A1.CollectionItem=4),0) AS WeiShenPiJinE
	,C.QuDate
	,C.KongWeiCode	
FROM tbl_FinOther AS A INNER JOIN tbl_Customer AS B
ON A.CustromCId=B.Id LEFT OUTER JOIN tbl_KongWei AS C
ON C.KongWeiId=A.TourId
WHERE A.CustromType=0  
UNION ALL
SELECT A.*,B.UnitName AS KeHuName
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=1 AND A1.CollectionItem=4),0) AS YiShenPiJinE
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=0 AND A1.CollectionItem=4),0) AS WeiShenPiJinE
	,C.QuDate
	,C.KongWeiCode		
FROM tbl_FinOther AS A INNER JOIN tbl_CompanySupplier AS B
ON A.CustromCId=B.Id
LEFT OUTER JOIN tbl_KongWei AS C
ON C.KongWeiId=A.TourId
WHERE A.CustromType=1


'
GO
/****** Object:  View [dbo].[view_Fin_YinHangMingXi]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YinHangMingXi]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:	������ϸ��
-- History:
-- 1.2013-08-05 ����־ ���ӹ���֧��
-- =============================================
CREATE VIEW [dbo].[view_Fin_YinHangMingXi]
AS
--������-�����տ�
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.Name FROM tbl_Customer AS C WHERE C.Id=B.BuyCompanyId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_TourOrder] AS B
ON A.CollectionId=B.OrderId
WHERE A.CollectionItem=0 AND A.Status=1
UNION ALL
--������-���黹
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.ContactName FROM [tbl_CompanyUser] AS C WHERE C.Id=B.LoanerId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinLoan] AS B
ON A.CollectionId=B.Id
WHERE A.CollectionItem=1 AND A.Status=1
--������-Ʊ��Ѻ���˻�
UNION ALL
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_KongWeiDaiLi] AS B
ON A.CollectionId=B.DaiLiId
WHERE A.CollectionItem=2 AND A.Status=1
UNION ALL
--������-Ʊ���˿�
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT D.UnitName FROM [tbl_CompanySupplier] AS D WHERE D.Id=C.GysId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_PlanTuiPiao] AS B
ON A.CollectionId=B.TuiId INNER JOIN [tbl_PlanChuPiao] AS C
ON B.PlanId=C.PlanId
WHERE A.CollectionItem=3 AND A.Status=1
UNION ALL
--������-���������տ�
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.Name FROM tbl_Customer AS C WHERE C.Id=B.CustromCId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinOther] AS B
ON A.CollectionId=B.Id AND B.CustromType=0
WHERE A.CollectionItem=4 AND A.Status=1
UNION ALL
--������-���������տ�
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT D.UnitName FROM [tbl_CompanySupplier] AS D WHERE D.Id=B.CustromCId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinOther] AS B
ON A.CollectionId=B.Id AND B.CustromType=1
WHERE A.CollectionItem=4 AND A.Status=1
UNION ALL
--֧����-�����˿�
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.Name FROM tbl_Customer AS C WHERE C.Id=B.BuyCompanyId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_TourOrder] AS B
ON A.CollectionId=B.OrderId
WHERE A.CollectionItem=101 AND A.Status=2
UNION ALL
--֧����-�ؽ�֧������
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_PlanDiJie] AS B
ON A.CollectionId=B.PlanId
WHERE A.CollectionItem=102 AND A.Status=2
UNION ALL
--֧����-Ʊ��Ѻ�𸶿�
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_KongWeiDaiLi] AS B
ON A.CollectionId=B.DaiLiId
WHERE A.CollectionItem=103 AND A.Status=2
UNION ALL
--֧����-Ʊ���Ÿ���
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_PlanChuPiao] AS B
ON A.CollectionId=B.PlanId
WHERE A.CollectionItem=104 AND A.Status=2
UNION ALL
--֧����-�Ƶ갲�Ÿ���
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.UnitName FROM [tbl_CompanySupplier] AS C WHERE C.Id=B.GysId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_TourOrderHotelPlan] AS B
ON A.CollectionId=B.Id
WHERE A.CollectionItem=105 AND A.Status=2
UNION ALL
--֧����-���֧��
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.ContactName FROM [tbl_CompanyUser] AS C WHERE C.Id=B.LoanerId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinLoan] AS B
ON A.CollectionId=B.Id
WHERE A.CollectionItem=106 AND A.Status=2
UNION ALL
--֧����-����֧��
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.ContactName FROM [tbl_CompanyUser] AS C WHERE C.Id=B.ApplyerId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinApply] AS B
ON A.CollectionId=B.Id
WHERE A.CollectionItem=107 AND A.Status=2
UNION ALL
--֧����-����֧������
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.Name FROM tbl_Customer AS C WHERE C.Id=B.CustromCId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinOther] AS B
ON A.CollectionId=B.Id AND B.CustromType=0
WHERE A.CollectionItem=108 AND A.Status=2
UNION ALL
--֧����-����֧������
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT D.UnitName FROM [tbl_CompanySupplier] AS D WHERE D.Id=B.CustromCId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinOther] AS B
ON A.CollectionId=B.Id AND B.CustromType=1
WHERE A.CollectionItem=108 AND A.Status=2
UNION ALL
--������-���ɵ���
SELECT A.CompanyId,A.CollectionRefundAmount AS JieFangJinE
	,0 AS DaiFangJinE	,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,''���ɵ���'' AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A 
WHERE A.CollectionItem=5 AND A.Status=1
UNION ALL
--֧����-����֧��
SELECT A.CompanyId,0 AS JieFangJinE
	,A.CollectionRefundAmount AS DaiFangJinE,A.BankId
	,A.CollectionId AS XiangMuId,A.CollectionItem As KuanXiangType
	,A.BankDate,A.ApproveRemark AS BeiZhu
	,(SELECT C.ContactName FROM [tbl_CompanyUser] AS C WHERE C.Id=B.YuanGongId) AS WangLaiDanWeiName
	,A.IsXiaoZhang,A.ZxsId
FROM [tbl_FinCope] AS A INNER JOIN [tbl_FinGongZi] AS B
ON A.CollectionId=B.GongZiId
WHERE A.CollectionItem=109 AND A.Status=2

'
GO
/****** Object:  View [dbo].[view_TourOrderHotel]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TourOrderHotel]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		
-- Create date: 
-- Description:
-- History:
-- 1.2013-01-28 ����־ ����IssueTime
-- 2.2013-08-20 ����־ ����TourOrderHotelPlan.IsShouZhi
-- =============================================
CREATE VIEW  [dbo].[view_TourOrderHotel]
AS
SELECT
	(SELECT QuDate FROM tbl_KongWei WHERE KongWeiId=tbl_TourOrder.TourId) AS QuDate
	,OrderId,OrderCode,CompanyId,TourId,BusinessType,Adults,Childs
	,Accounts,BuyCompanyId
	,(SELECT c.Name FROM tbl_Customer c WHERE c.Id = tbl_TourOrder.BuyCompanyId) AS BuyCompanyName
	,BuyOperatorId
	,(SELECT cci.Name FROM tbl_CustomerContactInfo cci WHERE cci.ID = tbl_TourOrder.BuyOperatorId) AS BuyOperatorName
	,PriceDetials,SumPrice,PriceRemark,SpecialAskRemark
	,OperatoRemark,OperatorId
	,(SELECT TravellerId,OrderId,TourId,TravellerName,TravellerType,CardType,CardNumber,Gender,Contact,Status,TicketType FROM tbl_TourOrderTraveller WHERE OrderId=tbl_TourOrder.OrderId order by SortId  for xml raw,root(''Root'')) AS TourOrderTraveller
	,(SELECT Id,TourId,OrderId,CompanyId,JiaoYiHao,CheckInDate,CheckOutDate,Room,Remark,RoomNights,HumorWas,HotelName,GYSId,SideOperatorId,SettleDetail,SettleAmount,PlanRemark,PlanDetail,FileInfo,(select UnitName from tbl_CompanySupplier AS C WHERE Id=tbl_TourOrderHotelPlan.GYSId) as GYSName,(CASE WHEN EXISTS(SELECT 1 FROM tbl_FinCope WHERE CollectionId=tbl_TourOrderHotelPlan.Id) THEN 1 ELSE 0 END) AS IsShouZhi FROM tbl_TourOrderHotelPlan WHERE OrderId=tbl_TourOrder.OrderId and IsDelete=''0'' order by SortId  for xml raw,root(''Root'')) as TourOrderHotelPlan
	,IssueTime
	,ZxsId
FROM tbl_TourOrder
'
GO
/****** Object:  View [dbo].[view_TourOrder]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TourOrder]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:	����	
-- Create date: 2012-11-15
-- Description:	������Ϣ��ͼ
-- History:
-- 1.2013-01-30 ����־ ����[KongWeiShuLiang],[ShiJiChuPiaoShuLiang]
-- 2.2013-03-05 ����־ ����[BiaoShiYanSe]
-- =============================================
CREATE VIEW [dbo].[view_TourOrder]
AS
SELECT A.OrderId,A.OrderCode,A.CompanyId
	,A.TourId,A.BusinessType,A.BusinessNature
	,A.Adults,A.Childs,A.Bears
	,A.Accounts,A.BuyCompanyId
	,C.Name AS BuyCompanyName
	,A.BuyOperatorId
	,(SELECT B.Name FROM tbl_CustomerContactInfo AS B WHERE B.Id=A.BuyOperatorId) AS BuyOperatorName
	,RouteId
	,(SELECT B.RouteName FROM tbl_Route AS B WHERE B.RouteId=A.RouteId) AS RouteName
	,A.PriceDetials,A.SumPrice,A.PriceRemark
	,A.CongregationPlace,A.CongregationTime,A.SendTourInfo
	,A.WelcomeWay,A.SpecialAskRemark,A.GroundRemark
	,A.OperatoRemark,A.OperatorId
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,A.OrderStatus,A.SaveSeatDate,A.IssueTime
	,A.CheckMoney--������տ�
	,A.ReturnMoney--������˿�
	,A.ReceivedMoney--�ѵǼ��տ�
	,A.RefundMoney--�ѵǼǸ���
	/*,(SELECT B.TravellerId,B.OrderId,B.TourId,B.TravellerName,B.TravellerType,B.CardType,B.CardNumber,B.Gender,B.Contact,B.[Status],B.TicketType FROM tbl_TourOrderTraveller AS B WHERE B.OrderId=A.OrderId ORDER BY B.SortId  FOR XML RAW,ROOT(''Root'')) AS TourOrderTraveller
	,(SELECT B.Id,B.OrderId,B.TourId,B.CompanyId,B.JiaoYiHao,B.CheckInDate,B.CheckOutDate,B.Room,B.Remark,B.RoomNights,B.HumorWas,B.HotelName,B.GYSId,(select UnitName from tbl_CompanySupplier as C where B.GYSId=C.Id) as GYSName,B.SideOperatorId,B.SettleDetail,B.SettleAmount,B.PlanRemark,B.PlanDetail,B.FileInfo,
	 (case when exists(select 1 from tbl_FinCope where CollectionId=B.Id) then 1 else 0 end) as IsShouZhi --�Ƶ�Ԥ���Ƿ������֧
	 FROM tbl_TourOrderHotelPlan AS B WHERE B.OrderId=A.OrderId and B.IsDelete=''0'' ORDER BY B.SortId  FOR XML RAW,ROOT(''Root'')) AS TourOrderHotelPlan*/
	,C.ProviceId AS KeHuProvinceId
	,C.CityId AS KeHuCityId
	,D.KongWeiType--��λ����
	,D.KongWeiCode--��λ��
	,D.QuDate--��������
	,(D.ShuLiang-(select isnull(sum(Accounts),0) from tbl_TourOrder where IsDelete=''0'' and TourId=A.TourId and OrderStatus in (0,1))) as KongWeiShengYuShuLiang --��λʣ������
	,(SELECT TOP 1 TravellerName FROM tbl_TourOrderTraveller AS B WHERE B.OrderId=A.OrderId ORDER BY B.SortId) AS YouKeName
	--,D.ShuLiang AS KongWeiShuLiang
	--,(SELECT ISNULL(SUM(A1.ShuLiang),0) FROM tbl_PlanChuPiao AS A1 WHERE A1.KongWeiId=D.KongWeiId) AS ShiJiChuPiaoShuLiang--ʵ�ʳ�Ʊ����
	,A.[BiaoShiYanSe]
	,A.ZxsId--ר���̱��
	,A.[LatestOperatorId]
	,A.[LatestTime]
	,A.[XiaDanLeiXing]
	,A.[XianLuId]
	,A.[YingErRenShu]
	,A.[BuZhanWeiRenShu]
	,A.[ChengRenJiaGe]
	,A.[ErTongJiaGe]
	,A.[QuanPeiJiaGe]
	,A.[YingErJiaGe]
	,A.[JiaJinE]
	,A.[JianJinE]
	,A.[JiaBeiZhu]
	,A.[JianBeiZhu]
	,A.[BuFangChaRenShu]
	,A.[TuiFangChaRenShu]
	,A.[BuFangChaJiaGe]
	,A.[TuiFangChaJiaGe]
	,A.[DingDanJinE]
	,A.[JiFen1]
	,A.[JiFen2]
	,A.[XiaDanBeiZhu]
	,A.[YuanYin1]
	,A.[YuanYin2]
	,A.JiaGeMingXi
	,A.DingDanLxrXingMing
	,A.DingDanLxrShouJi
	,A.DingDanLxrDianHua
	,A.DingDanLxrFax
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.LatestOperatorId) AS LatestOperatorName
	,D.AreaId
	,D.QuJiaoTongId	
FROM tbl_TourOrder AS A INNER JOIN tbl_Customer AS C
ON A.BuyCompanyId=C.Id INNER JOIN tbl_KongWei AS D
ON A.TourId=D.KongWeiId AND D.IsDelete=''0''
WHERE A.IsDelete=''0''

'
GO
/****** Object:  View [dbo].[view_Fin_KongWeiShouRu]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_KongWeiShouRu]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-12-05
-- Description:��λ������ͼ
-- =============================================
CREATE VIEW [dbo].[view_Fin_KongWeiShouRu]
AS
--��������
SELECT A.OrderId AS XiangMuId
	,(SELECT A1.Name FROM tbl_Customer AS A1 WHERE A1.Id=A.BuyCompanyId) AS KeHuName
	,0 AS KuanXiangType
	,A.OrderCode
	,A.PriceDetials AS JiaGeMingXi
	,A.SumPrice AS JinE
	,A.TourId AS KongWeiId
	,A.IssueTime
	,A.JiaGeMingXi AS JiaGeMingXi1
FROM tbl_TourOrder AS A 
WHERE A.IsDelete=''0'' AND A.OrderStatus=1

UNION ALL
--��Ʊ������
SELECT A.TuiId AS XingMuId
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=B.GysId) AS KeHuName
	,3 AS KuanXiangType
	,''��Ʊ��(��Ʊ���׺�''+B.JiaoYiHao+'')'' AS OrderCode
	,''��Ʊ��'' AS JiaGeMingXi
	,A.TuiAmount AS JinE
	,A.KongWeiId
	,A.IssueTime
	,'''' AS JiaGeMingXi1
FROM tbl_PlanTuiPiao AS A INNER JOIN tbl_PlanChuPiao AS B
ON A.PlanId=B.PlanId /*INNER JOIN tbl_CompanySupplier AS C
ON B.GysId=C.Id INNER JOIN tbl_KongWeiDaiLi AS D
ON B.DaiLiId=B.DaiLiId*/

'
GO
/****** Object:  View [dbo].[view_Fin_QiTaZhiChu]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_QiTaZhiChu]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2013-01-29
-- Description:�������-����֧��
-- History:
-- 1.2013-08-08 ����־ ��ṹ�޸ĸ�����ͼ
-- =============================================
CREATE VIEW [dbo].[view_Fin_QiTaZhiChu]
AS
SELECT A.*
	,B.Name AS KeHuName
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=2 AND A1.CollectionItem=108),0) AS YiZhiFuJinE
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=1 AND A1.CollectionItem=108),0) AS YiShenPiJinE
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=0 AND A1.CollectionItem=108),0) AS WeiShenPiJinE
FROM tbl_FinOther AS A INNER JOIN tbl_Customer AS B
ON A.CustromCId=B.Id
WHERE A.CostType=1 AND A.CustromType=0
UNION ALL
SELECT A.*
	,B.UnitName AS KeHuName
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=2 AND A1.CollectionItem=108),0) AS YiZhiFuJinE
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=1 AND A1.CollectionItem=108),0) AS YiShenPiJinE
	,ISNULL((SELECT SUM(A1.CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.Status=0 AND A1.CollectionItem=108),0) AS WeiShenPiJinE
FROM tbl_FinOther AS A INNER JOIN tbl_CompanySupplier AS B
ON A.CustromCId=B.Id
WHERE A.CostType=1 AND A.CustromType=1 

'
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_JieKuan_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_JieKuan_SetStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:���ý��״̬
-- History:
-- 1.2013-02-04 ����־ ����״̬�Ļع�����
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_JieKuan_SetStatus]
	 @JieKuanId CHAR(36)--�����
	,@OperatorId INT--�����˱��
	,@OperatorTime DATETIME--����ʱ��
	,@BeiZhu NVARCHAR(255)--������ע
	,@Status TINYINT--���״̬
	,@ZhangHuId CHAR(36)=NULL--֧���˺�
	,@BankDate DATETIME=NULL--����ʵ��ҵ������
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @OperatorName NVARCHAR(36)--����������
	DECLARE @ZxsId CHAR(36)

	SET @errorcount=0
	
	IF(@Status NOT IN(0,1,2,3,4))
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinLoan] WHERE [Id]=@JieKuanId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	DECLARE @IStatus TINYINT
	SELECT @IStatus=[Status],@ZxsId=[ZxsId] FROM [tbl_FinLoan] WHERE [Id]=@JieKuanId

	BEGIN TRAN

	IF(@IStatus=0 AND @Status IN(1,2))--����
	BEGIN
		UPDATE [tbl_FinLoan] SET [ApproverId]=@OperatorId,[ApproveRemark]=@BeiZhu,[ApproveTime]=@OperatorTime
			,[Status]=@Status
		WHERE [Id]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@IStatus=2 AND @Status=3)--֧��
	BEGIN
		UPDATE [tbl_FinLoan] SET [PayId]=@OperatorId,[PayRemark]=@BeiZhu,[PayTime]=@OperatorTime
			,[Status]=@Status,[PayBankId]=@ZhangHuId,[PayBankDate]=@BankDate
		WHERE [Id]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR

		--д������ϸ
		SELECT @OperatorName=[ContactName] FROM [tbl_CompanyUser] WHERE [Id]=@OperatorId
		
		INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem]
			,[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount]
			,[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate]
			,[Status],[ApproverId],[ApproveTime],[ApproveRemark]
			,[PayId],[PayTime],[PayRemark],[OperatorId]
			,[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId])
		SELECT NEWID(),A.CompanyId,@JieKuanId,106
			,@OperatorTime,@OperatorName,@OperatorId,A.JinE
			,0,@BeiZhu,@ZhangHuId,@BankDate
			,2,@OperatorId,@OperatorTime,@BeiZhu
			,@OperatorId,@OperatorTime,@BeiZhu,@OperatorId
			,@OperatorTime,''0'',NULL,@ZxsId
		FROM [tbl_FinLoan] AS A WHERE A.Id=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR
	END	

	IF(@IStatus=3 AND @Status=4)--�黹
	BEGIN
		UPDATE [tbl_FinLoan] SET [ReturnId]=@OperatorId,[ReturnRemark]=@BeiZhu,[ReturnTime]=@OperatorTime
			,[Status]=@Status,[ReturnBankId]=@ZhangHuId,[ReturnBankDate]=@BankDate
			,[ReturnAmount]=[JinE]
		WHERE [Id]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR

		--д������ϸ
		SELECT @OperatorName=ContactName FROM tbl_CompanyUser WHERE Id=@OperatorId
		
		INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem]
			,[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount]
			,[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate]
			,[Status],[ApproverId],[ApproveTime],[ApproveRemark]
			,[PayId],[PayTime],[PayRemark],[OperatorId]
			,[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId])
		SELECT NEWID(),A.CompanyId,@JieKuanId,1
			,@OperatorTime,@OperatorName,@OperatorId,A.JinE
			,0,@BeiZhu,@ZhangHuId,@BankDate
			,1,@OperatorId,@OperatorTime,@BeiZhu
			,@OperatorId,@OperatorTime,@BeiZhu,@OperatorId
			,@OperatorTime,''0'',NULL,@ZxsId
		FROM [tbl_FinLoan] AS A WHERE A.Id=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR
	END	

	IF(@IStatus=4 AND @Status=3)--ȡ���黹
	BEGIN
		DELETE FROM [tbl_FinCope] WHERE [CollectionItem]=1 AND [CollectionId]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR

		UPDATE [tbl_FinLoan] SET [ReturnId]=0,[ReturnRemark]='''',[ReturnTime]=NULL
			,[Status]=@Status,[ReturnBankId]='''',[ReturnBankDate]=NULL
			,[ReturnAmount]=0
		WHERE [Id]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@IStatus=3 AND @Status=2)--ȡ��֧��
	BEGIN
		DELETE FROM [tbl_FinCope] WHERE [CollectionItem]=106 AND [CollectionId]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR

		UPDATE [tbl_FinLoan] SET [PayId]=0,[PayRemark]='''',[PayTime]=NULL
			,[Status]=@Status,[PayBankId]='''',[PayBankDate]=NULL
		WHERE [Id]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@IStatus IN(1,2) AND @Status=0)--ȡ������
	BEGIN
		UPDATE [tbl_FinLoan] SET [ApproverId]=0,[ApproveRemark]='''',[ApproveTime]=NULL
			,[Status]=@Status
		WHERE [Id]=@JieKuanId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	ר�����������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_CU]
	@ZxsId char(36)
	,@CompanyId int
	,@MingCheng nvarchar(255)
	,@ZhuCeHao nvarchar(255)
	,@ShuiWuHao nvarchar(255)
	,@XuKeZhengHao nvarchar(255)
	,@FaRenName nvarchar(255)
	,@LxrName nvarchar(255)
	,@LxrDianHua nvarchar(255)
	,@LxrShouJi nvarchar(255)
	,@LxrQQ nvarchar(255)
	,@Fax nvarchar(255)
	,@ProvinceId int
	,@CityId int
	,@DiZhi nvarchar(255)
	,@Logo nvarchar(255)	
	,@LianXiFangShi nvarchar(max)
	,@YinHangZhangHao nvarchar(max)
	,@JieShao nvarchar(max)
	,@Status tinyint
	,@JiFenStatus tinyint
	,@OperatorId int
	,@IssueTime datetime
	,@ZhanDianXml NVARCHAR(MAX)
	,@QQXml NVARCHAR(MAX)
	,@Username NVARCHAR(255)
	,@NoEncryptPassword NVARCHAR(255)
	,@MD5Password NVARCHAR(255)
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @hdoc INT
	DECLARE @FS NVARCHAR(50)
	DECLARE @DeptId INT	--���ű��
	DECLARE @RoleId INT --��ɫ���
	DECLARE @errorcount INT
	
	SET @RetCode=0
	SET @FS=''INSERT''
	SET @errorcount=0
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShang WHERE CompanyId=@CompanyId AND ZxsId=@ZxsId)
	BEGIN
		SET @FS=''UPDATE''
	END
	
	IF(@FS=''INSERT'')
	BEGIN
		IF EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE Username=@Username AND CompanyId=@CompanyId)
		BEGIN
			SET @RetCode=-99
			RETURN @RetCode
		END
	END
	
	BEGIN TRAN
	IF(@FS=''INSERT'')
	BEGIN
		INSERT INTO [tbl_Pt_ZhuanXianShang]([ZxsId],[CompanyId],[MingCheng]
			,[ZhuCeHao],[ShuiWuHao],[XuKeZhengHao]
			,[FaRenName],[LxrName],[LxrDianHua]
			,[LxrShouJi],[LxrQQ],[Fax]
			,[ProvinceId],[CityId],[DiZhi]
			,[Logo],[LianXiFangShi],[YinHangZhangHao]
			,[JieShao],[Status],[JiFenStatus]
			,[Privs1],[Privs2],[Privs3]
			,[OperatorId],[IssueTime],[IsDelete]
			,[T1])
		VALUES(@ZxsId,@CompanyId,@MingCheng
			,@ZhuCeHao,@ShuiWuHao,@XuKeZhengHao
			,@FaRenName,@LxrName,@LxrDianHua
			,@LxrShouJi,@LxrQQ,@Fax
			,@ProvinceId,@CityId,@DiZhi
			,@Logo,@LianXiFangShi,@YinHangZhangHao
			,@JieShao,@Status,@JiFenStatus
			,'''','''',''''
			,@OperatorId,@IssueTime,''0''
			,0)
		SET @errorcount=@errorcount+@@ERROR
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		UPDATE [tbl_Pt_ZhuanXianShang] SET [MingCheng]=@MingCheng,[ZhuCeHao]=@ZhuCeHao
			,[ShuiWuHao]=@ShuiWuHao,[XuKeZhengHao]=@XuKeZhengHao
			,[FaRenName]=@FaRenName,[LxrName]=@Lxrname
			,[LxrDianHua]=@LxrDianHua,[LxrShouJi]=@LxrShouJi
			,[LxrQQ]=@LxrQQ,[Fax]=@Fax
			,[ProvinceId]=@ProvinceId,[CityId]=@CityId
			,[DiZhi]=@DiZhi,[Logo]=@Logo
			,[LianXiFangShi]=@LianXiFangShi
			,[YinHangZhangHao]=@YinHangZhangHao,[JieShao]=@JieShao
		WHERE [ZxsId]=@ZxsId
		SET @errorcount=@errorcount+@@ERROR	
	END
	
	DELETE FROM tbl_Pt_ZhuanXaingShangZhanDian WHERE ZxsId=@ZxsId
	SET @errorcount=@errorcount+@@ERROR
	IF(LEN(@ZhanDianXml)>8)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@ZhanDianXml
		INSERT INTO [tbl_Pt_ZhuanXaingShangZhanDian]([ZxsId],[ZhanDianId],[ZxlbId])
		SELECT @ZxsId,[ZhanDianId],[ZxlbId] FROM OPENXML(@hdoc,''/root/info'')
		WITH([ZhanDianId] INT,[ZxlbId] INT)
		SET @errorcount=@errorcount+@@ERROR
		EXEC sp_xml_removedocument @hdoc
	END	
	
	DELETE FROM tbl_Pt_ZhuanXianShangQQ WHERE ZxsId=@ZxsId
	SET @errorcount=@errorcount+@@ERROR
	IF(LEN(@QQXml)>8)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@QQXml
		INSERT INTO tbl_Pt_ZhuanXianShangQQ([ZxsId],[MiaoShu],[QQ])
		SELECT @ZxsId,[MiaoShu],[QQ] FROM OPENXML(@hdoc,''/root/info'',3)
		WITH([MiaoShu] NVARCHAR(255),[QQ] NVARCHAR(255))
		SET @errorcount=@errorcount+@@ERROR
		EXEC sp_xml_removedocument @hdoc
	END	
	
	IF(@FS=''INSERT'')
	BEGIN
		INSERT INTO [tbl_CompanyDepartment]([DepartName],[PrevDepartId],[DepartManger]
			,[ContactTel],[ContactFax],[Remark]
			,[CompanyId],[OperatorId],[IssueTime]
			,[ZxsId])
		VALUES(''�ܲ�'',0,0
			,'''','''',''''
			,@CompanyId,0,@IssueTime
			,@ZxsId)
		SET @errorcount=@errorcount+@@ERROR
		SET @DeptId = SCOPE_IDENTITY()
		
		INSERT INTO [tbl_SysRoleManage]([RoleName],[RoleChilds],[CompanyId],[IsDelete],[ZxsId])
		VALUES(''����Ա'','''',@CompanyId,''0'',@ZxsId)
		SET @errorcount=@errorcount+@@ERROR
		SET @RoleId = SCOPE_IDENTITY()
		
		INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password],[MD5Password]
			,[ContactName],[ContactSex],[ContactTel],[ContactFax]
			,[ContactMobile],[ContactEmail],[QQ],[MSN]
			,[JobName],[LastLoginIP],[LastLoginTime],[RoleID]
			,[PermissionList],[PeopProfile],[Remark],[IsDelete]
			,[UserStatus],[IsAdmin],[IssueTime],[DepartId]
			,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
			,[LeiXing],[ZxsId],[KeHuId]
			,[KeHuLxrId])
		VALUES(@CompanyId,@Username,@NoEncryptPassword,@MD5Password
			,@LxrName,0,@LxrDianHua,''''
			,@LxrShouJi,'''','''',''''
			,'''','''',NULL,@RoleId
			,'''','''','''',''0''
			,1,''1'',@IssueTime,@DeptId
			,0,0,''00000000-0000-0000-0000-000000000000''
			,0,@ZxsId,''''
			,0)
		SET @errorcount=@errorcount+@@ERROR
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		IF(@NoEncryptPassword IS NOT NULL)
		BEGIN
			UPDATE [tbl_CompanyUser] SET [Password]=@NoEncryptPassword,[MD5Password]=@MD5Password
			WHERE ZxsId=@ZxsId AND [IsAdmin]=''1''
			SET @errorcount=@errorcount+@@ERROR
		END
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	COMMIT TRAN	
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-19>
-- Description:	<ɾ������Ʊ��>
-- Result :-1:�Ѵ��ڸ���Ǽǵĳ�Ʊ���ţ�����ɾ����
--		   -2:ɾ���ɹ�
--		   -3:ɾ��ʧ��	
--			-4��������Ʊ���ţ�����ɾ��	
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���	
-- =============================================
CREATE proc [dbo].[proc_PlanChuPiao_Delete]
@PlanId char(36),				--�ƻ����
@Result int output
as
begin
	declare @error int
	set @error=0
	

	--�Ѵ��ڸ���Ǽǵĳ�Ʊ���ţ�����ɾ���� ,Ʊ���Ÿ��� = 104
	if  exists(select 1 from tbl_FinCope where CollectionId=@PlanId and CollectionItem=104)
	begin	
		set @Result=-1
		return @Result
	end
	--������Ʊ���ţ�����ɾ��
	if exists(select 1 from tbl_PlanTuiPiao where PlanId=@PlanId)
	begin
		set @Result=-4
		return @Result
	end

	DECLARE @KongWeiId CHAR(36)
	SELECT @KongWeiId=KongWeiid FROM tbl_PlanChuPiao WHERE PlanId=@PlanId
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	begin transaction	
	--���οͳ�Ʊ״̬��Ϊδ��Ʊstatus:���� = 0,���� = 1	
	--TicketType:δ��Ʊ = 0,�ѳ�Ʊ = 1,����Ʊ = 2
	UPDATE tbl_TourOrderTraveller SET TicketType = 0 
	WHERE TravellerId in (select YouKeId from tbl_PlanChuPiaoYouKe where PlanId=@PlanId) 
	set @error=@error+@@error

	--ɾ����Ʊ�����ο�
	DELETE FROM tbl_PlanChuPiaoYouKe WHERE PlanId=@PlanId
	set @error=@error+@@error

	--ɾ����Ʊ
	DELETE FROM tbl_PlanChuPiao WHERE PlanId=@PlanId
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=-2
		commit transaction
	end
	else
	begin
		set @Result=-3
		rollback transaction
	end
	return @Result

end
' 
END
GO
/****** Object:  View [dbo].[view_Fin_TuiPiao]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_TuiPiao]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:�������-��Ʊ�ǼǱ�
-- =============================================
CREATE VIEW [dbo].[view_Fin_TuiPiao]
AS
SELECT A.TuiId,A.PlanId,A.KongWeiId
	,A.TuiTime,A.SunShiMX,A.SunShiAmount
	,A.ChengDanFang,A.TuiAmount,A.OperatorId
	,A.ShuLiang
	,B.GysId
	,D.QuDate,D.KongWeiCode
	,C.OrderCode
	,E.GysOrderCode
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=B.GysId) AS GysName--��Ӧ������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.TuiId AND A1.CollectionItem=3 AND A1.Status=0),0) AS WeiShenPiJinE--�˻�δ�������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.TuiId AND A1.CollectionItem=3 AND A1.Status=1),0) AS YiShenPiJinE--�˻����������
	,D.CompanyId
	,B.JiaoYiHao
	,D.QuTime
	,C.OrderId
	,D.ZxsId
FROM tbl_PlanTuiPiao AS A INNER JOIN tbl_PlanChuPiao AS B
ON A.PlanId=B.PlanId INNER JOIN tbl_TourOrder AS C
ON A.OrderId=C.OrderId INNER JOIN tbl_KongWei AS D
ON A.KongWeiId=D.KongWeiId INNER JOIN tbl_KongWeiDaiLi AS E
ON E.DaiLiId=B.DaiLiId
'
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_SetStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:���ñ���״̬
-- History:
-- 1.2013-02-01 ����־ ����״̬�ع�����
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_BaoXiao_SetStatus]
	 @BaoXiaoId CHAR(36)--�������
	,@OperatorId INT--�����˱��
	,@OperatorTime DATETIME--����ʱ��
	,@BeiZhu NVARCHAR(255)--������ע
	,@Status TINYINT--����״̬
	,@ZhangHuId CHAR(36)=NULL--֧���˺�
	,@BankDate DATETIME=NULL--����ʵ��ҵ������
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @ZxsId CHAR(36)

	SET @errorcount=0
	
	IF(@Status NOT IN(0,1,2,3))
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinApply] WHERE [Id]=@BaoXiaoId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	DECLARE @IStatus TINYINT--��ǰ״̬
	SELECT @IStatus=[State],@ZxsId=[ZxsId] FROM [tbl_FinApply] WHERE [Id]=@BaoXiaoId

	BEGIN TRAN

	IF(@IStatus=0 AND @Status IN(1,2))--����
	BEGIN
		UPDATE [tbl_FinApply] SET [ApproverId]=@OperatorId,[ApproveRemark]=@BeiZhu
			,[ApproveTime]=@OperatorTime ,[State]=@Status
		WHERE [Id]=@BaoXiaoId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@IStatus=2 AND @Status=3)--֧��
	BEGIN
		UPDATE [tbl_FinApply] SET [PayId]=@OperatorId,[PayRemark]=@BeiZhu
			,[PayTime]=@OperatorTime,[State]=@Status 
			,[BankId]=@ZhangHuId,[BankDate]=@BankDate
		WHERE [Id]=@BaoXiaoId
		SET @errorcount=@errorcount+@@ERROR

		DECLARE @FuKuanRenName NVARCHAR(36)
		SELECT @FuKuanRenName=ContactName FROM tbl_CompanyUser WHERE Id=@OperatorId
		--д������ϸ
		INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem]
			,[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount]
			,[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate]
			,[Status],[ApproverId],[ApproveTime],[ApproveRemark]
			,[PayId],[PayTime],[PayRemark],[OperatorId]
			,[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId])
		SELECT NEWID(),A.CompanyId,@BaoXiaoId,107
			,@OperatorTime,@FuKuanRenName,@OperatorId,A.ApplyAmount
			,0,@BeiZhu,@ZhangHuId,@BankDate
			,2,@OperatorId,@OperatorTime,@BeiZhu
			,@OperatorId,@OperatorTime,@BeiZhu,@OperatorId
			,@OperatorTime,''0'',NULL,@ZxsId
		FROM [tbl_FinApply] AS A WHERE A.Id=@BaoXiaoId
		SET @errorcount=@errorcount+@@ERROR
	END	

	IF(@IStatus=3 AND @Status=2)--ȡ��֧��
	BEGIN
		UPDATE [tbl_FinApply] SET [PayId]=0,[PayRemark]=''''
			,[PayTime]=NULL,[State]=@Status 
			,[BankId]='''',[BankDate]=NULL
		WHERE [Id]=@BaoXiaoId
		SET @errorcount=@errorcount+@@ERROR

		IF(@errorcount=0)
		BEGIN
			DELETE FROM [tbl_FinCope] WHERE [CollectionItem]=107 AND [CollectionId]=@BaoXiaoId
			SET @errorcount=@errorcount+@@ERROR
		END
	END

	IF(@IStatus IN(1,2) AND @Status=0)--ȡ������
	BEGIN
		UPDATE [tbl_FinApply] SET [State]=@Status 
		WHERE [Id]=@BaoXiaoId
		SET @errorcount=@errorcount+@@ERROR	
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-19
-- Description:�޸ı����Ǽ���Ϣ������1�ɹ�������ʧ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_BaoXiao_Update]
	 @BaoXiaoId CHAR(36)--�������
	,@CompanyId INT--��˾���
	,@BaoXiaoRiQi DATETIME--��������
	,@BaoXiaoRenId INT--�����˱��
	,@JinE MONEY--�������ϼ�
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@MxXml NVARCHAR(MAX)--����������ϸXML:<root><info XiaoFeiRiQi="" JinE="" XiaoFeiType="" XiaoFeiBeiZhu="" /></root>
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinApplyDetail] WHERE [Id]=@BaoXiaoId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	BEGIN TRAN
	UPDATE [tbl_FinApply] SET [ApplyDate]=@BaoXiaoRiQi,[ApplyerId]=@BaoXiaoRenId,[ApplyAmount]=@JinE
	WHERE [Id]=@BaoXiaoId
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @MxXml IS NOT NULL AND LEN(@MxXml)>0)
	BEGIN
		DELETE FROM [tbl_FinApplyDetail] WHERE [Id]=@BaoXiaoId
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@MxXml

		INSERT INTO [tbl_FinApplyDetail]([Id],[CostDate],[CostAmount],[CostType],[CostRemark])
		SELECT @BaoXiaoId,A.XiaoFeiRiQi,A.JinE,A.XiaoFeiType,A.XiaoFeiBeiZhu
		FROM OPENXML(@hdoc,''/root/info'')
		WITH(XiaoFeiRiQi DATETIME,JinE MONEY,XiaoFeiType TINYINT,XiaoFeiBeiZhu NVARCHAR(MAX)) AS A

		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_BaoXiao_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_BaoXiao_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-19
-- Description:д�뱨���Ǽ���Ϣ������1�ɹ�������ʧ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_BaoXiao_Insert]
	 @BaoXiaoId CHAR(36)--�������
	,@CompanyId INT--��˾���
	,@BaoXiaoRiQi DATETIME--��������
	,@BaoXiaoRenId INT--�����˱��
	,@JinE MONEY--�������ϼ�
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@MxXml NVARCHAR(MAX)--����������ϸXML:<root><info XiaoFeiRiQi="" JinE="" XiaoFeiType="" XiaoFeiBeiZhu="" /></root>
	,@RetCode INT OUTPUT
	,@ZxsId CHAR(36)
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0

	BEGIN TRAN
	INSERT INTO [tbl_FinApply]([Id],[CompanyId],[ApplyDate],[ApplyerId]
		,[ApplyAmount],[OperatorId],[IssueTime],[State]
		,[ApproverId],[ApproveRemark],[ApproveTime],[PayId]
		,[PayTime],[PayRemark],[BankId],[BankDate]
		,[ZxsId])
	VALUES(@BaoXiaoId,@CompanyId,@BaoXiaoRiQi,@BaoXiaoRenId
		,@JinE,@OperatorId,@IssueTime,0
		,NULL,NULL,NULL,NULL
		,NULL,NULL,NULL,NULL
		,@ZxsID)
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @MxXml IS NOT NULL AND LEN(@MxXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@MxXml

		INSERT INTO [tbl_FinApplyDetail]([Id],[CostDate],[CostAmount],[CostType],[CostRemark])
		SELECT @BaoXiaoId,A.XiaoFeiRiQi,A.JinE,A.XiaoFeiType,A.XiaoFeiBeiZhu
		FROM OPENXML(@hdoc,''/root/info'')
		WITH(XiaoFeiRiQi DATETIME,JinE MONEY,XiaoFeiType TINYINT,XiaoFeiBeiZhu NVARCHAR(MAX)) AS A

		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�����·����>
-- Result :0:���ʧ�� 1:��ӳɹ�
-- History:
-- 1.2013-01-06 ����@Status
-- =============================================
CREATE proc [dbo].[proc_RouteZhengCe_Add]
	 @Id char(36)			--���߱��
	,@CompanyId int		--��˾���
	,@Title nvarchar(255)	--���߱���
	,@FilePath nvarchar(255)--���߸���
	,@OperatorId int		--�����˱��
	,@Result int output
	,@Status TINYINT--����״̬
	,@ZxsId CHAR(36)
as
begin
	declare @error int
	set @error=0

	INSERT INTO tbl_RouteZhengCe(Id,CompanyId,Title,FilePath,OperatorId,IssueTime,[Status],[ZxsId])
	VALUES(@Id,@CompanyId,@Title,@FilePath,@OperatorId,getdate(),@Status,@ZxsId)
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�޸���·����>
-- Result :0:ʧ�� 1:�ɹ�
-- History:
-- 1.2013-01-06 ����@Status
-- =============================================
CREATE proc [dbo].[proc_RouteZhengCe_Update]
	 @Id char(36)	--���߱��
	,@CompanyId int	--��˾���
	,@Title nvarchar(255)--���߱���
	,@FilePath nvarchar(255)--���߸���
	,@OperatorId int--�����˱��
	,@Result int output
	,@Status TINYINT--����״̬
as
begin
	declare @error int
	set @error=0

	UPDATE tbl_RouteZhengCe SET Title = @Title,FilePath = @FilePath,[Status]=@Status WHERE Id = @Id
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteZhengCe_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_RouteZhengCe_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�����·����>
-- Result :0:ʧ�� 1:�ɹ�
-- =============================================
Create proc [dbo].[proc_RouteZhengCe_Delete]
@Id char(36),			--���߱��
@Result int output
as
begin
	declare @error int
	set @error=0
	Delete from  tbl_RouteZhengCe WHERE Id = @Id
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end' 
END
GO
/****** Object:  View [dbo].[view_Pt_YongHu]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_YongHu]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		����־
-- Create date: 2014-09-04
-- Description: ƽ̨-�û�
-- =============================================
CREATE VIEW [dbo].[view_Pt_YongHu]
AS
SELECT A.Id AS KeHuLxrId
	,A.CustomerId AS KeHuId
	,A.Companyid
	,A.JobId AS ZhiWu
	,A.DepartmentId AS BuMenName
	,A.Sex AS XingBie
	,A.Name AS XingMing
	,A.Tel AS DianHua
	,A.Mobile AS ShouJi
	,A.QQ
	,A.Fax
	,A.YongHuId
	,A.Status AS KeHuLxrStatus
	,A.Email AS YouXiang
	,B.UserName AS YongHuMing
	,ISNULL(B.LeiXing,1) AS LeiXing
	,B.WeiXinHao
FROM tbl_CustomerContactInfo AS A LEFT OUTER JOIN tbl_CompanyUser AS B
ON A.YongHuId=B.Id AND A.CustomerId=B.KeHuId AND A.CompanyId=B.CompanyId

'
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_YuanGong_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_YuanGong_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-03
-- Description:	ƽ̨-Ա���������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_YuanGong_CU]
	@YongHuId INT
	,@YongHuMing NVARCHAR(50)
	,@CompanyId INT
	,@KeHuId CHAR(36)
	,@MiMa NVARCHAR(50)
	,@MiMaMd5 NVARCHAR(50)
	,@YuanMiMaMd5 NVARCHAR(50)
	,@XingMing NVARCHAR(50)
	,@XingBie TINYINT
	,@ShouJi NVARCHAR(50)
	,@DianHua NVARCHAR(50)
	,@Fax NVARCHAR(50)
	,@YouXiang NVARCHAR(50)
	,@QQ NVARCHAR(50)
	,@WeiXinHao NVARCHAR(50)
	,@BuMenName NVARCHAR(50)
	,@ZhiWu NVARCHAR(50)
	,@DanJuTaiTouMingCheng NVARCHAR(50)
	,@DanJuTaiTouDiZhi NVARCHAR(50)
	,@OperatorId INT
	,@IssueTime DATETIME
	,@RetCode INT OUTPUT
	,@KeHuLxrId INT
	,@DanJuDaYinMoBan NVARCHAR(255)
	,@DanJuTaiTouDianHua NVARCHAR(255)
AS
BEGIN	
	DECLARE @errorcount INT
	SET @errorcount=0
	SET @RetCode=0
	
	IF (@YongHuMing IS NOT NULL AND LEN(@YongHuMing)>0 AND EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND Id<>@YongHuId AND Username=@YongHuMing))
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END	
	
	IF (@YouXiang IS NOT NULL AND LEN(@YouXiang)>0 AND EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE CompanyId=@CompanyId AND ID<>@YongHuId AND ContactEmail=@YouXiang))
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF(@YongHuId>0 AND NOT EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE Id=@YongHuId AND KeHuId=@KeHuId AND CompanyId=@CompanyId))
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF(@YongHuId>0 AND @MiMaMd5 IS NOT NULL AND LEN(@MiMaMd5)>0 AND @YuanMiMaMd5 IS NOT NULL AND LEN(@YuanMiMaMd5)>0 AND NOT EXISTS(SELECT 1 FROM tbl_CompanyUser WHERE Id=@YongHuId AND [MD5Password]=@YuanMiMaMd5))
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	IF(@KeHuLxrId>0)
	BEGIN
		SELECT @YongHuId=YongHuId FROM [tbl_CustomerContactInfo] WHERE Id=@KeHuLxrId
	END
	
	BEGIN TRAN
	IF(@YongHuId=0)
	BEGIN
		IF(@YongHuMing IS NOT NULL AND LEN(@YongHuMing)>0)
		BEGIN
			INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password]
				,[MD5Password],[ContactName],[ContactSex]
				,[ContactTel],[ContactFax],[ContactMobile]
				,[ContactEmail],[QQ],[MSN]
				,[JobName],[LastLoginIP],[LastLoginTime]
				,[RoleID],[PermissionList],[PeopProfile]
				,[Remark],[IsDelete],[UserStatus]
				,[IsAdmin],[IssueTime],[DepartId]
				,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
				,[LeiXing],[ZxsId],[KeHuId]
				,[KeHuLxrId],[WeiXinHao],[BuMenName]
				,[DanJuTaiTouMingCheng],[DanJuTaiTouDiZhi],[DanJuDaYinMoBan]
				,[DanJuTaiTouDianHua])
			VALUES(@CompanyId,@YongHuMing,@MiMa
				,@MiMaMd5,@XingMing,@XingBie
				,@DianHua,@Fax,@ShouJi
				,@YouXiang,@QQ,''''
				,@ZhiWu,'''',GETDATE()
				,0,'''',''''
				,'''',''0'',1
				,''0'',@IssueTime,0
				,0,0,''''
				,1,'''',@KeHuid
				,@KeHuLxrId,@WeiXinHao,@BuMenName
				,@DanJuTaiTouMingCheng,@DanJuTaiTouDiZhi,@DanJuDaYinMoBan
				,@DanJuTaiTouDianHua)		
			SET @errorcount=@errorcount+@@ERROR
			SET @YongHuId=SCOPE_IDENTITY()
		END
		
		IF(@KeHuLxrId=0)
		BEGIN
			INSERT INTO [tbl_CustomerContactInfo]([CustomerId],[CompanyId],[JobId]
				,[DepartmentId],[Sex],[Name]
				,[Tel],[Mobile],[qq]
				,[BirthDay],[Email],[Spetialty]
				,[Hobby],[Remark],[Fax]
				,[YongHuId],[Status],[WeiXinHao])
			VALUES(@KeHuId,@CompanyId,@ZhiWu
				,@BuMenName,@XingBie,@XingMing
				,@DianHua,@ShouJi,@QQ
				,NULL,@YouXiang,''''
				,'''','''',@Fax
				,@YongHuId,0,@WeiXinHao)		
			SET @errorcount=@errorcount+@@ERROR
			SET @KeHuLxrId=SCOPE_IDENTITY()	
			
			IF(@YongHuId>0)
			BEGIN
				UPDATE [tbl_CompanyUser] SET [KeHuLxrId]=@KeHuLxrId WHERE Id=@YongHuId
				SET @errorcount=@errorcount+@@ERROR
			END
		END
		ELSE
		BEGIN
			UPDATE tbl_CustomerContactInfo SET JobId=@ZhiWu
				,DepartmentId=@BuMenName,Sex=@XingBie
				,Name=@XingMing,Tel=@DianHua
				,Mobile=@ShouJi,qq=@QQ
				,Email=@YouXiang,Fax=@Fax
				,YongHuId=@YongHuId,WeiXinHao=@WeiXinHao
			WHERE Id=@KeHuLxrId
			SET @errorcount=@errorcount+@@ERROR	
		END
	END
	ELSE
	BEGIN
		SELECT @KeHuLxrId=KeHuLxrId FROM [tbl_CompanyUser] WHERE Id=@YongHuId
		UPDATE [tbl_CompanyUser] SET [ContactName]=@XingMing
			,[ContactSex]=@XingBie,[ContactMobile]=@ShouJi
			,[ContactTel]=@DianHua,[ContactFax]=@Fax
			,[ContactEmail]=@YouXiang,[QQ]=@QQ
			,[WeiXinHao]=@WeiXinHao,[BuMenName]=@BuMenName
			,[DanJuTaiTouMingCheng]=@DanJuTaiTouMingCheng,[DanJuTaiTouDiZhi]=@DanJuTaiTouDiZhi
			,[JobName]=@ZhiWu,[DanJuDaYinMoBan]=@DanJuDaYinMoBan
			,[DanJuTaiTouDianHua]=@DanJuTaiTouDianHua
		WHERE Id=@YongHuId
		SET @errorcount=@errorcount+@@ERROR
		
		UPDATE tbl_CustomerContactInfo SET JobId=@ZhiWu
			,DepartmentId=@BuMenName,Sex=@XingBie
			,Name=@XingMing,Tel=@DianHua
			,Mobile=@ShouJi,qq=@QQ
			,Email=@YouXiang,Fax=@Fax
			,WeiXinHao=@WeiXiNhao
		WHERE Id=@KeHuLxrId
		SET @errorcount=@errorcount+@@ERROR	
		
		IF(@MiMaMd5 IS NOT NULL AND LEN(@MiMaMd5)>0)
		BEGIN
			UPDATE [tbl_CompanyUser] SET [Password]=@MiMa,[MD5Password]=@MiMaMd5 WHERE Id=@YongHuId
			SET @errorcount=@errorcount+@@ERROR	
		END	
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	COMMIT TRAN
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_XiaoXi_GetKeHuXiaoXi]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_XiaoXi_GetKeHuXiaoXi]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-22
-- Description:	��ȡ��Ϣ-ͬ�пͻ���̨
-- =============================================
CREATE PROCEDURE [dbo].[proc_XiaoXi_GetKeHuXiaoXi]
	@CompanyId INT--��˾���
	,@KeHuId CHAR(36)--�ͻ����
	,@YongHuId INT--��¼�û����
AS
BEGIN
	DECLARE @TEMP TABLE(LeiXing TINYINT,ShuLiang INT,IdentityId INT IDENTITY)
	--LeiXing:EyouSoft.Model.EnumType.CompanyStructure.XiaoXiLeiXing
	DECLARE @ShuLiang INT
	
	--δȷ�϶���
	SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND BuyCompanyId=@KeHuId AND IsDelete=''0'' AND OrderStatus=4
	INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(0,@ShuLiang)
    --�����ж���
    SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND BuyCompanyId=@KeHuId AND IsDelete=''0'' AND OrderStatus=6
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(1,@ShuLiang)
    --������ȫ����
    SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND BuyCompanyId=@KeHuId AND IsDelete=''0'' AND OrderStatus=5
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(2,@ShuLiang)
    --Ԥ������
    SELECT @ShuLiang=COUNT(*) FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND BuyCompanyId=@KeHuId AND IsDelete=''0'' AND OrderStatus=0
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(3,@ShuLiang)
    --δ����һ�����
    SELECT @ShuLiang=COUNT(*) FROM tbl_Pt_JiFenDingDan WHERE CompanyId=@CompanyId AND XiaDanRenId=@YongHuId AND [Status]=0
    INSERT INTO @TEMP(LeiXing,ShuLiang)VALUES(4,@ShuLiang)
	
	SELECT * FROM @TEMP ORDER BY IdentityId ASC
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	���ɻ��ֶ������׺�
-- =============================================
CREATE FUNCTION [dbo].[fn_Pt_CreateJiFenDingDanJiaoYiHao]
(
	@CompanyId INT
)
RETURNS NVARCHAR(255)
AS
BEGIN
	DECLARE @JiaoYiHao NVARCHAR(255)
	DECLARE @ShuLiang INT
	SELECT @ShuLiang=COUNT(*) FROM [tbl_Pt_JiFenDingDan] WHERE CompanyId=@CompanyId
	SET @ShuLiang=@ShuLiang+1
	
	SET @JiaoYiHao=''JF''+CONVERT(NVARCHAR(100),GETDATE(),112)+dbo.fn_PadLeft(@ShuLiang,''0'',5)	
	RETURN @JiaoYiHao
END
' 
END
GO
/****** Object:  View [dbo].[view_YongHu_JiFenMingXi]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_YongHu_JiFenMingXi]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-05
-- Description: �û�������ϸ
-- =============================================
CREATE VIEW [dbo].[view_YongHu_JiFenMingXi]
AS
SELECT A.IdentityId AS JiFenMingXiId
	,A.CompanyId
	,A.YongHuId
	,A.JiFen
	,A.Status
	,A.IssueTime AS JiFenShiJian
	,A.GuanLianLeiXing
	,A.GuanLianId
	,B.OrderCode AS JiaoYiHao
	,(SELECT A1.XianLuCode FROM tbl_Pt_KongWeiXianLu AS A1 WHERE A1.XianLuId=B.XianLuId) AS ChanPinBianHao
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=B.RouteId) AS ChanPinName
	,B.BusinessType AS YeWuLeiXing
FROM tbl_Pt_YongHuJiFenMingXi AS A INNER JOIN tbl_TourOrder AS B
ON A.GuanLianId=B.OrderId
WHERE A.GuanLianLeiXing=0 
UNION ALL
SELECT A.IdentityId AS JiFenMingXiId
	,A.CompanyId
	,A.YongHuId
	,A.JiFen
	,A.Status
	,A.IssueTime AS JiFenShiJian
	,A.GuanLianLeiXing
	,A.GuanLianId
	,B.JiaoYiHao AS JiaoYiHao
	,(SELECT A1.BianMa FROM tbl_Pt_JiFenShangPin AS A1 WHERE A1.ShangPinId=B.ShangPinId) AS ChanPinBianHao
	,(SELECT A1.MingCheng FROM tbl_Pt_JiFenShangPin AS A1 WHERE A1.ShangPinId=B.ShangPinId) AS ChanPinName
	,NULL AS YeWuLeiXing
FROM tbl_Pt_YongHuJiFenMingXi AS A INNER JOIN tbl_Pt_JiFenDingDan AS B
ON A.GuanLianId=B.DingDanId
WHERE A.GuanLianLeiXing=1
'
GO
/****** Object:  View [dbo].[view_Pt_JiFenDingDan]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_JiFenDingDan]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2014-08-15
-- Description: ���ֶ���
-- =============================================
CREATE VIEW [dbo].[view_Pt_JiFenDingDan]
AS
SELECT A.[DingDanId]
	,A.[CompanyId]
	,A.[ShangPinId]
	,A.[JiaoYiHao]
	,A.[ShuLiang]
	,A.[JiFen1]
	,A.[JiFen2]
	,A.[Status]
	,A.[LxrXingMing]
	,A.[LxrDianHua]
	,A.[LxrProvinceId]
	,A.[LxrCityId]
	,A.[LxrDiZhi]
	,A.[XiaDanBeiZhu]
	,A.[XiaDanRenId]
	,A.[IssueTime]
	,A.[KuaiDi]
	,A.[FuKuanShiJian]
	,A.[FuKuanJinE]
	,A.[FuKuanFangShi]
	,A.[FuKuanZhangHao]
	,A.[FuKuanDuiFangDanWei]
	,A.[FuKuanBeiZhu]
	,A.[FuKuanOperatorId]
	,A.[FuKuanTime]
	,A.[FuKuanStatus]
	,A.[FuKuanShenPiRenId]
	,A.[FuKuanShenPiShiJian]
	,A.[FuKuanShenPiBeiZhu]
	,A.[FuKuanZhiFuRenId]
	,A.[FuKuanZhiFuShiJian]
	,A.[FuKuanZhiFuBeiZhu]
	,A.[IdentityId]
	,A.[LatestOperatorId]
	,A.[LatestTime]
	,B.MingCheng AS ShangPinMingCheng
	,B.BianMa AS ShangPinBianMa
	,B.LeiXing AS ShangPinLeiXing
	,A.LxrShouJi
	,A.LxrYouXiang
	,A.LxrYouBian
FROM [tbl_Pt_JiFenDingDan] AS A INNER JOIN tbl_Pt_JiFenShangPin AS B
ON A.ShangPinId=B.ShangPinId

'
GO
/****** Object:  View [dbo].[view_TongJi_JiFenShouFuKuanMingXi]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TongJi_JiFenShouFuKuanMingXi]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:	����־
-- Create date: 2014-08-17
-- Description:	ͳ�Ʒ���-�����ո�����ϸ��
-- =============================================
CREATE VIEW [dbo].[view_TongJi_JiFenShouFuKuanMingXi]
AS
--��������
SELECT A.JieSuanId AS MxId
	,A.ZxsId
	,A.CompanyId
	,A.JieSuanRiQi AS MxShiJian
	,A.JinE AS JieFangJinE
	,0 AS DaiFangJinE
	,A.JieSuanFangShi AS FangShi
	,A.JieSuanZhangHao AS YinHangZhangHao
	,A.JieSuanBeiZhu AS BeiZhu
	,A.Status AS KuXiangStatus
	,A.OperatorId
	,A.IssueTime	
	,B.MingCheng AS WangLaiDanWeiName
	,0 AS MxLeiXing
FROM tbl_Pt_FinJiFenJieSuan AS A INNER JOIN tbl_Pt_ZhuanXianShang AS B
ON A.ZxsId=B.ZxsId
--�һ���Ʒ֧��
UNION ALL
SELECT A.DingDanId AS MxId
	,'''' AS ZxsId
	,A.CompanyId
	,A.FuKuanShiJian AS MxShiJian
	,0 AS JieFangJinE
	,A.FuKuanJinE AS DaiFangJinE
	,A.FuKuanFangShi AS FangShi
	,A.FuKuanZhangHao AS YinHangZhangHao
	,A.FuKuanBeiZhu AS BeiZhu
	,A.FuKuanStatus AS KuXiangStatus
	,A.FuKuanOperatorId AS OperatorId
	,A.FuKuanTime AS IssueTime
	,A.FuKuanDuiFangDanWei AS WangLaiDanWeiName
	,1 AS MxLeiXing
FROM tbl_Pt_JiFenDingDan AS A
WHERE A.Status=2'
GO
/****** Object:  View [dbo].[view_Pt_KongWei]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_KongWei]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2014-09-01
-- Description: ƽ̨-��λ
-- =============================================
CREATE VIEW [dbo].[view_Pt_KongWei]
AS
SELECT A.KongWeiId
	,A.CompanyId
	,A.KongWeiCode
	,A.IsChuTuan
	,A.ShuLiang
	,A.Status
	,A.AreaId
	,A.QuDate
	,A.QuJiaoTongId
	,A.QuDepProvinceId
	,A.QuDepCityId
	,A.QuArrProvinceId
	,A.QuArrCityId
	,A.QuBanCi
	,A.HuiJiaoTongId
	,A.HuiDepProvinceId
	,A.HuiDepCityId
	,A.HuiArrProvinceId
	,A.HuiArrCityId
	,A.HuiBanCi
	,A.TianShu
	,A.ZxsId
	,A.ZxlbId
	,A.ZhanDianId
	,(SELECT A1.AreaName FROM tbl_Area AS A1 WHERE A1.Id=A.AreaId) AS QuYuName
	,(SELECT A1.TrafficName FROM tbl_CompanyTraffic AS A1 WHERE A1.Id=A.QuJiaoTongId) AS QuJiaoTongName
	,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.QuDepProvinceId) AS QuChuFaDiShengFenName
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.QuDepCityId) AS QuChuFaDiChengShiName
	,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.QuArrProvinceId) AS QuMuDiDiShengFenName
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.QuArrCityId) AS QuMuDiDiChengShiName	
	,(SELECT A1.TrafficName FROM tbl_CompanyTraffic AS A1 WHERE A1.Id=A.HuiJiaoTongId) AS HuiJiaoTongName
	,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.HuiDepProvinceId) AS HuiChuFaDiShengFenName
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.HuiDepCityId) AS HuiChuFaDiChengShiName
	,(SELECT A1.ProvinceName FROM tbl_CompanyProvince AS A1 WHERE A1.Id=A.HuiArrProvinceId) AS HuiMuDiDiShengFenName
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.HuiArrCityId) AS HuiMuDiDiChengShiName	
	
	,(SELECT ISNULL(SUM(A1.Accounts),0) FROM tbl_TourOrder AS A1 WHERE A1. TourId=A.KongWeiId AND A1.IsDelete=''0'' AND A1.OrderStatus IN(0,1,4,5)) AS YiZhanWeiShuLiang
	,A.PingTaiShuLiang
	,A.Status AS ShouKeStatus
	,A.PingTaiShouKeStatus
FROM tbl_KongWei AS A
WHERE A.KongWeiType=0 AND A.IsDelete=''0'' AND A.QuDate>=GETDATE() AND EXISTS(SELECT 1 FROM tbl_Pt_KongWeiXianLu AS A1 WHERE A1.KongWeiId=A.KongWeiId AND A1.Status=0 )
'
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-29>
-- Description:	<��ӹ����㱨>
-- Result :1:��ӳɹ� 0:���ʧ��
-- =============================================
CREATE proc [dbo].[proc_WorkReport_Add]
@CompanyId int,
@Title nvarchar(255),
@Description nvarchar(max),
@FilePath nvarchar(255),
@DepartmentId int,
@OperatorId int,
@ReportingTime datetime,
@Status tinyint,
@WorkType tinyint,
@AcceptPeople xml,	--<ROOT><AcceptInfo AcceptId=\"{0}\" WorkType=\"{1}\" /></ROOT>
@Result int output
as
begin
	declare @error int 
	set @error=0
	
	begin transaction

	declare @PlanId int
	INSERT INTO tbl_WorkReport(CompanyId,Title,Description
           ,FilePath,DepartmentId,OperatorId,ReportingTime,Status)
     VALUES(@CompanyId,@Title,@Description
           ,@FilePath,@DepartmentId,@OperatorId,@ReportingTime,@Status)
	select @PlanId=@@identity
	set @error=@error+@@error
	

	if(@AcceptPeople is not null)
	begin
		declare @idoc int
		exec sp_xml_preparedocument @idoc output,@AcceptPeople
		set @error=@error+@@error

		INSERT INTO tbl_WorkPlanAccept(CompanyId,PlanId,AccetpId,WorkType)
		select @CompanyId,@PlanId,AccetpId,@WorkType from openxml(@idoc,''/ROOT/AcceptInfo'')
		with(AccetpId int)
		set @error=@error+@@error
		
		exec sp_xml_removedocument @idoc
		set @error=@error+@@error
	end
	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		rollback transaction
	end
	return @Result
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-12-03>
-- Description:	<ɾ�������㱨>
-- Result :1:ɾ���ɹ� 0:ɾ��ʧ�� -1����˵Ĳ�����ɾ��
-- =============================================
CREATE proc [dbo].[proc_WorkReport_Delete]
@Id int,
@Result int output
as
begin
	
	declare @error int 
	set @error=0
	
	select * from tbl_WorkReport
	
	declare @IsCheck char(1) 
	declare @CompanyId int
	select @CompanyId=CompanyId,@IsCheck=Status from  tbl_WorkReport where ReportId=@Id
	if(@IsCheck=''1'')
	begin
		set @Result=-1
		return @Result
	end

	begin transaction
	UPDATE tbl_WorkReport SET Status=''1'' where ReportId=@Id
	set @error=@error+@@error
	
	--WorkType:�����㱨 = 0,�����ƻ�    
	Delete from tbl_WorkPlanAccept 
	where PlanId=@Id and CompanyId=@CompanyId and WorkType=0
	set @error=@error+@@error
	
		
	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		rollback transaction
	end
	return @Result
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkReport_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkReport_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-29>
-- Description:	<�޸Ĺ����㱨>
-- Result :1:�޸ĳɹ� 0:�޸�ʧ�� -1:����˵Ĳ������޸�
-- =============================================
CREATE proc [dbo].[proc_WorkReport_Update]
@Id int,
@CompanyId int,
@Title nvarchar(255),
@Description nvarchar(max),
@FilePath nvarchar(255),
@DepartmentId int,
@OperatorId int,
@ReportingTime datetime,
@Status tinyint,
@WorkType tinyint,
@AcceptPeople xml,	--<ROOT><AcceptInfo AccetpId=\"{0}\" WorkType=\"{1}\" /></ROOT>
@Result int output
as
begin
	declare @error int 
	set @error=0
	
	begin transaction

	declare @oStatus tinyint 
	select @oStatus=Status from  tbl_WorkReport where ReportId=@Id
	--CheckState:δ��� = 0,����� = 1
	if(@oStatus=1)
	begin
		set @Result=-1
		rollback transaction
		return @Result
	end


	UPDATE tbl_WorkReport SET Title=@Title,Description=@Description,FilePath=@FilePath
	WHERE ReportId=@Id
	set @error=@error+@@error
	
	DELETE FROM tbl_WorkPlanAccept 
	WHERE PlanId=@Id 
	AND CompanyId=@CompanyId 
	AND WorkType=@WorkType
	set @error=@error+@@error

	if(@AcceptPeople is not null)
	begin
		declare @idoc int
		exec sp_xml_preparedocument @idoc output,@AcceptPeople
		set @error=@error+@@error
		
		select @CompanyId,@Id,AccetpId,@WorkType from openxml(@idoc,''/ROOT/AcceptInfo'')
		with(AccetpId int)

		INSERT INTO tbl_WorkPlanAccept(CompanyId,PlanId,AccetpId,WorkType)
		select @CompanyId,@Id,AccetpId,@WorkType from openxml(@idoc,''/ROOT/AcceptInfo'')
		with(AccetpId int)
		set @error=@error+@@error
		exec sp_xml_removedocument @idoc
		set @error=@error+@@error
	end
	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		rollback transaction
	end
	return @Result
end
' 
END
GO
/****** Object:  View [dbo].[view_TongJi_JiFenFaFangMingXi]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_TongJi_JiFenFaFangMingXi]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:	����־
-- Create date: 2014-08-17
-- Description:	ͳ�Ʒ���-���ַ�����ϸ
-- =============================================
CREATE VIEW [dbo].[view_TongJi_JiFenFaFangMingXi]
AS
SELECT A.OrderId
	,A.OrderCode
	,A.CompanyId
	,A.TourId
	,A.BusinessType
	,A.Adults
	,A.Childs
	,A.YingErRenShu
	,A.Bears
	,A.Accounts
	,A.ZxsId
	,A.JiFen1
	,A.JiFen2
	,A.OrderStatus
	,A.IssueTime AS XiaDanShiJian
	,B.JiFen AS ShiJiFaFangJiFen
	,B.Status AS JiFenStatus
	,B.IssueTime AS JiFenShiJian
	,B.ShengXiaoShiJian
	,C.MingCheng AS ZxsName
	,D.QuDate
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName
FROM tbl_TourOrder AS A INNER JOIN tbl_Pt_YongHuJiFenMingXi AS B
ON A.OrderId=B.GuanLianId AND B.GuanLianLeiXing=0 AND B.Status<>3 INNER JOIN tbl_Pt_ZhuanXianShang AS C
ON A.ZxsId=C.ZxsId INNER JOIN tbl_KongWei AS D
ON A.TourId=D.KongWeiId
WHERE A.IsDelete=''0''

'
GO
/****** Object:  View [dbo].[view_Fin_YingFuJiuDian]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuJiuDian]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:Ӧ���Ƶ���ͼ
-- =============================================
CREATE VIEW [dbo].[view_Fin_YingFuJiuDian]
AS
SELECT A.Id AS PlanId,A.CompanyId,B.KongWeiId
	,A.JiaoYiHao,A.GysId
	,A.HotelName,C.Adults,C.Childs,C.Bears,C.YingErRenShu
	,A.SettleDetail AS JieSuanMX,A.SettleAmount AS JieSuanAmount,C.IssueTime
	,B.KongWeiCode,B.QuTime,B.QuDate,(SELECT TOP 1 C.ContactName,C.ContactTel FROM tbl_SupplierContact C WHERE C.SupplierId=A.GysId ORDER BY C.Id ASC FOR XML RAW,ROOT) AS ContactInfo
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.CollectionItem=105 AND A1.Status=0),0) AS WeiShenPiJinE--δ�������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.CollectionItem=105 AND A1.Status=1),0) AS YiShenPiJinE--������(δ֧��)���
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.Id AND A1.CollectionItem=105 AND A1.Status=2),0) AS YiZhiFuJinE--��֧�����
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--��Ӧ������
	,B.ZxsId
FROM tbl_TourOrderHotelPlan AS A INNER JOIN tbl_TourOrder AS C
ON A.OrderId=C.OrderId AND C.IsDelete=''0'' INNER JOIN tbl_KongWei AS B
ON C.TourId=B.KongWeiId AND B.IsDelete=''0''
WHERE A.GysId>'''' AND C.OrderStatus=1 AND A.IsDelete=''0''

'
GO
/****** Object:  StoredProcedure [dbo].[proc_Route_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Route_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<ɾ����·>
-- Result :-1:����·�´��ڶ���������ɾ�� 0:ɾ��ʧ�� 1:ɾ���ɹ�
-- =============================================
CREATE proc [dbo].[proc_Route_Delete]
@RouteId char(36),				--��·��Ʒ���
@Result int output
as
begin
	declare @error int
	set @error=0
	
	if exists(select 1 from tbl_TourOrder where RouteId=@RouteId and IsDelete=''0'')
	begin
		set @Result=-1 --����·�´��ڶ���������ɾ��
		return @Result
	end

	update tbl_Route set IsDelete=''1'' where RouteId=@RouteId
	set @error=@error+@@error
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-20>
-- Description:	<ɾ����λ>
-- Result :-1:��λ���ڶ���������ɾ��
--		   -2:��λ���ڵؽӰ��Ų�����ɾ��
--		   -3:��λ���ڳ�Ʊ���Ų�����ɾ��
--		   -4����λ�����̴���Ѻ��Ǽǲ�����ɾ��
--			1:�ɹ� 0��ʧ��
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���
-- =============================================
CREATE proc [dbo].[proc_KongWei_Delete]
@KongWeiId char(36),		--��λ���
@Result int output
as
begin
	declare @error int
	set @error=0
	
	
	if exists(select 1 from tbl_TourOrder where TourId=@KongWeiId /*AND OrderStatus IN(0,1)*/ AND IsDelete=''0'')
	begin
		set @Result=-1  --��λ���ڶ���������ɾ��
		return @Result
	end

	if exists(select 1 from tbl_PlanDiJie where KongWeiId=@KongWeiId)
	begin
		set @Result=-2  --��λ���ڵؽӰ��Ų�����ɾ��
		return @Result
	end

	if exists(select 1 from tbl_PlanChuPiao where KongWeiId=@KongWeiId)
	begin
		set @Result=-3  --��λ���ڳ�Ʊ���Ų�����ɾ��	
		return @Result
	end

	if exists(select 1 from tbl_KongWeiDaiLi where KongWeiId=@KongWeiId and YaJinAmount<>0)
	begin
		set @Result=-4  --��λ�����̴���Ѻ��Ǽǲ�����ɾ��
		return @Result
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	UPDATE tbl_TourOrder SET IsDelete=''1'' WHERE TourId=@KongWeiId
	SET @error=@error+@@error

	UPDATE tbl_PlanHotelMX SET IsDelete=''1'' WHERE KongWeiId=@KongWeiId
	SET @error=@error+@@ERROR

	UPDATE tbl_TourOrderHotelPlan SET IsDelete=''1'' WHERE TourId=@KongWeiId
	SET @error=@error+@@error

	UPDATE tbl_KongWeiDaiLi SET IsDelete=''1'' WHERE KongWeiId=@KongWeiId
	SET @error=@error+@@error

	Update tbl_KongWei set IsDelete=''1'' where KongWeiId=@KongWeiId
	set @error=@error+@@error
	
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end

	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WeiHuKongWeiStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WeiHuKongWeiStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-22>
-- Description:	<ά���ƻ�λ�տ�״̬>
-- Return :1: Success
-- History:
-- 1.2012-12-31 @total��isnull����
-- =============================================
CREATE PROC [dbo].[proc_WeiHuKongWeiStatus]
	@TourId char(36)
	,@Result int output
AS
BEGIN
	declare @ZhanWeiShuLiang int
	--OrderStatus:����λ = 0,�ѳɽ� = 1,��λ���� = 2,��ȡ�� = 3
	SELECT @ZhanWeiShuLiang=ISNULL(SUM(Accounts),0) FROM tbl_TourOrder 
	WHERE TourId=@TourId AND OrderStatus IN (0,1,4,5) AND IsDelete=''0''
	
	--Status:�����տ� = 0,�ֶ�ͣ�� = 1,�Զ����� = 2
	UPDATE tbl_KongWei SET [Status]=2 WHERE KongWeiId=@TourId AND ShuLiang=@ZhanWeiShuLiang

	UPDATE tbl_KongWei SET [Status]=0 WHERE KongWeiId=@TourId AND ShuLiang>@ZhanWeiShuLiang AND [Status]<>1

	SET @Result=1

	RETURN @Result
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SQLPlan_TourOrderSaveSeat]    Script Date: 09/29/2014 16:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLPlan_TourOrderSaveSeat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-22>
-- Description:	<������λ���ڵĶ���>
-- Return :1: Success 0:Error
-- =============================================
CREATE proc [dbo].[SQLPlan_TourOrderSaveSeat]
as
begin
	if exists(select 1 from tbl_TourOrder 
			  where SaveSeatDate<=getdate() and OrderStatus=0 and IsDelete=''0'')
	begin
		declare @error int
		set @error=0
		
		begin transaction

		--���������ڵļƻ�λ������ʱ��
		select TourId into #temp from tbl_TourOrder  where SaveSeatDate<=getdate() 
		and OrderStatus=0 and IsDelete=''0'' group by TourId
	
		--ά����λ���ڵĶ���	
		UPDATE tbl_TourOrder set OrderStatus=2
		where SaveSeatDate<=getdate() and OrderStatus=0 and IsDelete=''0''
		set @error=@error+@@error
		
		--ά���ƻ�Ϊ���տ�״̬
	    declare @xml xml
		declare @count int
		declare @i int
		set @xml=(select TourId from #temp for xml raw,root(''Root''))		
		set @count=(select count(TourId) from #temp)
		set @i=1
		while(@i<=@count)	
		begin
			declare @TourId char(36)
			select @TourId=@xml.value(''(Root/row[sql:variable("@i")]/@TourId)[1]'',''char(36)'')
		
			declare @total int
			--OrderStatus:����λ = 0,�ѳɽ� = 1,��λ���� = 2,��ȡ�� = 3
			select @total=sum(Accounts) from tbl_TourOrder 
			where TourId=@TourId and OrderStatus in (0,1) and IsDelete=''0''
			set @error=@error+@@error
		
			--Status:�����տ� = 0,�ֶ�ͣ�� = 1,�Զ����� = 2
			update tbl_KongWei set Status=2 where KongWeiId=@TourId and ShuLiang=@total
			set @error=@error+@@error

			update tbl_KongWei set Status=0 where KongWeiId=@TourId and ShuLiang>@total and Status<>1
			set @error=@error+@@error
			
		    set @i=@i+1
		end
		
		if(@error=0)
		begin
			commit transaction
		end
		else
		begin
			rollback transaction
		end
	end
	
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	ר����ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_D]
	@ZxsId char(36)
	,@CompanyId int
	,@OperatorId int
	,@IssueTime datetime
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShang WHERE ZxsId=@ZxsId AND T1=1)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Route WHERE ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_ComJiChuXinXi WHERE ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_TourOrder WHERE ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-95
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-94
		RETURN @RetCode
	END
	
	UPDATE tbl_Pt_ZhuanXianShang SET IsDelete=''1'' WHERE ZxsId=@ZxsId
	UPDATE tbl_CompanyUser SET IsDelete=''1'' WHERE ZxsId=@ZxsId
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-15>
-- Description:	<ɾ�������Ƶ�>
-- Result :
-- -1:�Ѿ������ա�����Ǽǵĵ���ҵ���ṩɾ����
--1:ɾ���ɹ� 0��ɾ��ʧ��
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���
-- =============================================
CREATE proc [dbo].[proc_TourOrderHotel_Delete]
@KongWeiId char(36),		--��λ���
@Result int output
as
begin
	declare @error int
	set @error=0	

	--����������֧������ɾ��
	if exists(select 1 from tbl_FinCope where 
			  CollectionId=(select OrderId from tbl_TourOrder where TourId=@KongWeiId))
	begin
		set @Result=-1	--�Ѿ������ա�����Ǽǵĵ���ҵ���ṩɾ����
		return @Result
	end

	--�����Ƶ�ľƵ갲�Ŵ�����֧ ������ɾ��
	if exists(select 1 from tbl_FinCope where 
			  CollectionId in (select Id from tbl_TourOrderHotelPlan where TourId=@KongWeiId) )
	begin
		set @Result=-1	--�Ѿ������ա�����Ǽǵĵ���ҵ���ṩɾ����
		return @Result
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	begin transaction
	UPDATE tbl_PlanHotelMX SET IsDelete=''1'' WHERE KongWeiId=@KongWeiId
	SET @error=@error+@@ERROR

	UPDATE tbl_TourOrderHotelPlan SET IsDelete=''1'' WHERE TourId=@KongWeiId
	SET @error=@error+@@ERROR

	UPDATE tbl_TourOrder Set IsDelete=''1'' where TourId=@KongWeiId
	set @error=@error+@@error

	UPDATE tbl_KongWei SET IsDelete=''1'' where KongWeiId=@KongWeiId
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end

	return @Result
end
' 
END
GO
/****** Object:  View [dbo].[view_Fin_KongWeiZhiChu]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_KongWeiZhiChu]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-12-05
-- Description:��λ֧����ͼ(��λ����)
-- History:
-- 1.2013-02-25 ����־ �Ƶ갲��֧�����Ӷ���״̬����
-- =============================================
CREATE VIEW [dbo].[view_Fin_KongWeiZhiChu]
AS
--�ؽӰ���
SELECT A.PlanId AS XiangMuId
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName
	,102 AS KuanXiangType
	,A.JiaoYiHao
	,A.JieSuanMX
	,A.JieSuanAmount AS JinE
	,A.KongWeiId
	,A.IssueTime
FROM tbl_PlanDiJie AS A 

UNION ALL
--Ʊ����
SELECT A.PlanId AS XiangMuId
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName
	,104 AS KuanXiangType
	,A.JiaoYiHao
	,A.JieSuanMX
	,A.JieSuanAmount AS JinE
	,A.KongWeiId
	,A.IssueTime
FROM tbl_PlanChuPiao AS A 

UNION ALL
--�Ƶ갲��
SELECT A.Id AS XiangMuId
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName
	,105 AS KuanXiangType
	,A.JiaoYiHao
	,A.SettleDetail AS JieSuanMX
	,A.SettleAmount AS JinE
	,A.TourId AS KongWeiId
	,B.IssueTime
FROM tbl_TourOrderHotelPlan AS A INNER JOIN tbl_TourOrder AS B
ON A.OrderId=B.OrderId AND B.IsDelete=''0'' AND B.OrderStatus=1
WHERE A.IsDelete=''0''

UNION ALL
--Ѻ��֧��
SELECT A.DaiLiId AS XiangMuId
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName
	,103 AS KuanXiangType
	,''Ʊ��Ѻ��(�����Ż����''+A.GysOrderCode+'')'' AS JiaoYihao
	,''Ʊ��Ѻ��'' AS JieSuanMX
	,A.YaJinAmount-A.TuiYaJinAmount AS JinE
	,A.KongWeiId
	,B.IssueTime
FROM tbl_KongWeiDaiLi AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId
WHERE A.YaJinAmount-A.TuiYaJinAmount>0
'
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2011-11-16>
-- Description:	<�޸ĵؽӰ���>
--Result:
--	-1:�Ѿ����ŵؽӵĶ��� �������°���
--  -2:����������Ϊ�Ŷ�ʱ��һ��ֻ��ѡ��һ���������еؽӰ���
--  -3:����������Ϊɢƴʱ����ѡ����ͬ��·�µĶ���������еؽӰ���
--1:�޸ĳɹ� 0:�޸�ʧ��
-- History:
-- 1.2013-01-15 ����־ ȥ�����ε�����
-- 2.2013-01-24 ����־ ����@YouKeXinXi
-- 3.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���	
-- =============================================
CREATE proc [dbo].[proc_PlanDiJie_Update]
	@PlanId char(36) 
	,@CompanyId int
	,@KongWeiId char(36)
	,@JiaoYiHao nvarchar(50)
	,@GysId char(36)
	,@RouteId char(36)
	,@LxrName nvarchar(50)
	,@LxrTelephone nvarchar(50)
	,@ChengRenShu int
	,@ErTongShu int
	,@QuPeiShu int
	,@QuPeiName nvarchar(50)
	--@DaoYouId int 
	,@YongCan nvarchar(255)
	,@JieSuanMX nvarchar(255)
	,@JieSuanAmount money 
	,@JieTuanFangShi nvarchar(255)
	,@OperatorId int
	,@Remark nvarchar(MAX)
	,@OrderIds nvarchar(max)
	,@Result int output
	,@YouKeXinXi NVARCHAR(MAX)--�ο���Ϣ
	,@YingErShu INT
as
begin
	declare @error int
	set @error=0

	if exists(select 1 from tbl_PlanDiJIeOrder where PlanId<>@PlanId and OrderId in(select [value] from dbo.fn_split(@OrderIds,'','')))
	begin
		set @Result=-1	  --�Ѿ����ŵؽӵĶ��� �������°���
		return @Result
	end

	declare @BusinessNature tinyint	--��������  ɢƴ = 0,���� = 1
	select @BusinessNature=BusinessNature from tbl_TourOrder 
	where OrderId=(select top 1 [value] from dbo.fn_split(@OrderIds,'',''))

	if(@BusinessNature=1)
	begin
		declare @tuanduiordercount int
		select @tuanduiordercount=count(1) from dbo.fn_split(@OrderIds,'','') 
		if(@tuanduiordercount<>1)
		begin
			set @Result=-2	  --����������Ϊ�Ŷ�ʱ��һ��ֻ��ѡ��һ���������еؽӰ���
			return @Result 
		end
	end

	if(@BusinessNature=0)
	begin
		 declare @sanpinordercount int
--		 select @sanpinordercount= count(RouteId) from tbl_TourOrder 
--		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,'',''))
--		 group by RouteId
		 select @sanpinordercount=count(distinct(RouteId)) from tbl_TourOrder
		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,'',''))
		 if(@sanpinordercount<>1)
		 begin
			set @Result=-3	  --����������Ϊɢƴʱ����ѡ����ͬ��·�µĶ���������еؽӰ���
			return @Result 
		 end
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	begin transaction	
	
	UPDATE tbl_PlanDiJie SET GysId = @GysId,LxrName = @LxrName,LxrTelephone = @LxrTelephone
		,ChengRenShu = @ChengRenShu,ErTongShu = @ErTongShu	,QuPeiShu = @QuPeiShu
		,QuPeiName = @QuPeiName,YongCan = @YongCan,JieSuanMX = @JieSuanMX
		,JieSuanAmount = @JieSuanAmount	,JieTuanFangShi = @JieTuanFangShi,Remark = @Remark
		,RouteId=@RouteId,[YouKeXinXi]=@YouKeXinXi,YingErShu=@YingErShu
	WHERE PlanId = @PlanId
	set @error=@error+@@error

	DELETE From  tbl_PlanDiJIeOrder where PlanId=@PlanId
	set @error=@error+@@error

	INSERT INTO tbl_PlanDiJIeOrder(PlanId,OrderId)
	select @PlanId,[value] from dbo.fn_split(@OrderIds,'','')
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Wage_Set]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Wage_Set]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2011-10-19
-- Description:	�������������¹�����Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[proc_Wage_Set]
	@CompanyId INT,--��˾���
	@Year INT,--���
	@Month TINYINT,--�·�
	@OperatorId INT,--����Ա���
	@WagesXML NVARCHAR(MAX),--XML:<ROOT><Info ... /></ROOT>
	@Result INT OUTPUT--������� 1:�ɹ�
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0
	SET @Result=1

	BEGIN TRAN
	DELETE FROM tbl_Wage WHERE CompanyId=@CompanyId AND [Year]=@Year AND [Month]=@Month
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @WagesXML IS NOT NULL AND LEN(@WagesXML)>0 AND @WagesXML<>''<ROOT></ROOT>'')
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@WagesXML
		INSERT INTO [tbl_Wage]([CompanyId],[Year],[Month],[OperatorId],[IssueTime]
			,[ZhiWei],[XingMing],[GangWeiGongZi],[QuanQinJiang],[JiangJin]
			,[FanBu],[HuaBu],[YouBu],[JiaBanFei],[ChiDao]
			,[BingJia],[ShiJia],[XingZhengFaKuan],[YeWuFaKuan],[QianKuan]
			,[YingFaGongZi],[WuXian],[SheBao],[ShiFaGongZi])
		SELECT @CompanyId,@Year,@Month,@OperatorId,GETDATE()
			,[ZhiWei],[XingMing],[GangWeiGongZi],[QuanQinJiang],[JiangJin]
			,[FanBu],[HuaBu],[YouBu],[JiaBanFei],[ChiDao]
			,[BingJia],[ShiJia],[XingZhengFaKuan],[YeWuFaKuan],[QianKuan]
			,[YingFaGongZi],[WuXian],[SheBao],[ShiFaGongZi]
		FROM OPENXML(@hdoc,''/ROOT/Info'') 
		WITH([ZhiWei] NVARCHAR(255),[XingMing] NVARCHAR(255),[GangWeiGongZi] MONEY,[QuanQinJiang] MONEY,[JiangJin] MONEY
			,[FanBu] MONEY,[HuaBu] MONEY,[YouBu] MONEY,[JiaBanFei] MONEY,[ChiDao] MONEY
			,[BingJia] MONEY,[ShiJia] MONEY,[XingZhengFaKuan] MONEY,[YeWuFaKuan] MONEY,[QianKuan] MONEY
			,[YingFaGongZi] MONEY,[WuXian] MONEY,[SheBao] MONEY,[ShiFaGongZi] MONEY)		
		SET @errorcount=@errorcount+@@ERROR
		EXEC sp_xml_removedocument @hdoc
	END	

	IF(@errorcount>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
		RETURN -1
	END

	COMMIT TRAN
	SET @Result=1
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Sys_Create]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Sys_Create]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		���ĳ�
-- Create date: 2011-09-27
-- Description:	������ϵͳ
-- RetCode��1�ɹ� 0ʧ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Sys_Create]
	@SysId INT OUTPUT,		--ϵͳ���
	@SysName NVARCHAR(50),	--ϵͳ����
	@CompanyId INT OUTPUT,	--��˾���
	@FullName NVARCHAR(100) = '''',--��ϵ������
	@Telephone NVARCHAR(20) = '''',	--��ϵ�绰
	@Mobile NVARCHAR(20) = '''',	--�ֻ�
	@UserId INT OUTPUT,		--����Ա�û����
	@Username NVARCHAR(50),	--����Ա�û���
	@NoEncryptPassword NVARCHAR(50),--����Ա�û���������
	@MD5Password NVARCHAR(50),	--����Ա�û�MD5����
	@IssueTime DATETIME,	--����ʱ��
	@RetCode INT OUTPUT		--���ؽ������
AS
BEGIN

	DECLARE @ErrorCount INT
	DECLARE @DeptId INT	--���ű��
	DECLARE @RoleId INT --��ɫ���
	DECLARE @ZxsId CHAR(36)
	
	SET @ErrorCount = 0
	SET @ZxsId=NEWID()

	BEGIN TRAN
	
	--1.����ϵͳ��Ϣ
	INSERT INTO [tbl_Sys] ([SysName],CreateTime) VALUES (@SysName,@IssueTime)
	SET @ErrorCount = @ErrorCount + @@ERROR
	SET @SysId = @@IDENTITY

	--2.������˾��Ϣ
	INSERT INTO [tbl_CompanyInfo]([CompanyName],[CompanyType],[CompanyEnglishName],[License]
		,[ContactName],[ContactTel],[ContactMobile],[ContactFax]
		,[CompanyAddress],[CompanyZip],[CompanySiteUrl],[SystemId]
		,[IssueTime])
	VALUES(@SysName,'''','''',''''
		,@FullName,@Telephone,@Mobile,''''
		,'''','''','''',@SysId
		,@IssueTime)
	SET @ErrorCount = @ErrorCount + @@ERROR
	SET @CompanyId = @@IDENTITY

	--3.�����ܲ���Ϣ
	INSERT INTO [tbl_CompanyDepartment]([DepartName],[PrevDepartId],[DepartManger],[ContactTel]
		,[ContactFax],[Remark],[CompanyId],[OperatorId]
		,[IssueTime],[ZxsId])
	VALUES(''�ܲ�'',0,0,''''
		,'''','''',@CompanyId,0
		,@IssueTime,@ZxsId)
	SET @ErrorCount = @ErrorCount + @@ERROR 
	SET @DeptId = @@IDENTITY

	--4.��������Ա��ɫ��Ϣ
	INSERT INTO [tbl_SysRoleManage]([RoleName],[RoleChilds],[CompanyId],[IsDelete],[ZxsId])
	VALUES(''����Ա'','''',@CompanyId,''0'',@ZxsId)
	SET @ErrorCount = @ErrorCount + @@ERROR 
	SET @RoleId = @@IDENTITY

	--5.��������Ա�˺���Ϣ
	INSERT INTO [tbl_CompanyUser]([CompanyId],[UserName],[Password],[MD5Password]
		,[ContactName],[ContactSex],[ContactTel],[ContactFax]
		,[ContactMobile],[ContactEmail],[QQ],[MSN]
		,[JobName],[LastLoginIP],[LastLoginTime],[RoleID]
		,[PermissionList],[PeopProfile],[Remark],[IsDelete]
		,[UserStatus],[IsAdmin],[IssueTime],[DepartId]
		,[SuperviseDepartId],[OnlineStatus],[OnlineSessionId]
		,[LeiXing],[ZxsId],[KeHuId],[KeHuLxrId])
	VALUES(@CompanyId,@Username,@NoEncryptPassword,@MD5Password
		,@FullName,0,@Telephone,''''
		,@Mobile,'''','''',''''
		,'''','''',NULL,@RoleId
		,'''','''','''',''0''
		,1,''1'',@IssueTime,@DeptId
		,0,0,''00000000-0000-0000-0000-000000000000''
		,0,@ZxsId,'''',0)	
	SET @ErrorCount = @ErrorCount + @@ERROR 
	SET @UserId = @@IDENTITY

	IF(@errorcount=0)--����ϵͳĬ�ϵ�ʡ�ݳ�����Ϣ
	BEGIN
		DECLARE @i INT--������
		DECLARE @ProvinceId INT--��˾ʡ�ݱ��
		DECLARE @ProvinceCount INT--ʡ������
		
		SELECT @ProvinceCount=COUNT(*) FROM [tbl_SysProvince]
		SET @i=1

		WHILE(@i<=@ProvinceCount AND @errorcount=0)
		BEGIN
			INSERT INTO [tbl_CompanyProvince]([ProvinceName],[CompanyId],[OperatorId])
			SELECT [ProvinceName],@CompanyId,0 FROM [tbl_SysProvince] WHERE [Id]=@i
			SET @errorcount=@errorcount+@@ERROR
			SET @ProvinceId=@@IDENTITY			

			INSERT INTO [tbl_CompanyCity] ([ProvinceId],[CityName],[CompanyId],[IsFav],[OperatorId])
			SELECT @ProvinceId,[CityName],@CompanyId,''0'',0 FROM [tbl_SysCity] WHERE [ProvinceId]=@i
			SET @errorcount=@errorcount+@@ERROR
			SET @i=@i+1
		END
	END
	
	IF(@errorcount=0)
	BEGIN
		INSERT INTO [tbl_Pt_ZhuanXianShang]([ZxsId],[CompanyId],[MingCheng]
			,[ZhuCeHao],[ShuiWuHao],[XuKeZhengHao]
			,[FaRenName],[LxrName],[LxrDianHua]
			,[LxrShouJi],[LxrQQ],[Fax]
			,[ProvinceId],[CityId],[DiZhi]
			,[Logo],[LianXiFangShi],[YinHangZhangHao]
			,[JieShao],[Status],[JiFenStatus]
			,[Privs1],[Privs2],[Privs3]
			,[OperatorId],[IssueTime],[IsDelete]
			,[T1])
		VALUES(@ZxsId,@CompanyId,@SysName
			,'''','''',''''
			,@FullName,@FullName,@Telephone
			,@Mobile,'''',''''
			,0,0,''''
			,'''','''',''''
			,'''',0,0
			,''ALL'',''ALL'',''ALL''
			,0,@IssueTime,''0''
			,1)
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@ErrorCount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=0
		RETURN 0
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN 1
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-12-03>
-- Description:	<ɾ�������ƻ�>
-- Result :1:ɾ���ɹ� 0:ɾ��ʧ�� -1����˵Ĳ�����ɾ��
-- =============================================
create proc [dbo].[proc_WorkPlan_Delete]
@Id int,
@Result int output
as
begin
	
	declare @error int 
	set @error=0

	declare @IsCheck char(1) 
	declare @CompanyId int
	select @CompanyId=CompanyId,@IsCheck=IsCheck from  tbl_WorkPlan where PlanId=@Id
	if(@IsCheck=''1'')
	begin
		set @Result=-1
		return @Result
	end	

	begin transaction
	update tbl_WorkPlan set IsDelete=''1'' where PlanId=@Id
	set @error=@error+@@error

	--WorkType:�����㱨 = 0,�����ƻ�    
	Delete from tbl_WorkPlanAccept 
	where PlanId=@Id and CompanyId=@CompanyId and WorkType=1
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		rollback transaction
	end
	return @Result
end
	
	





' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

--==================================
--��������-�����ƻ����
--�����ˣ�³��Դ
--ʱ�䣺2011-01-19
--Return : -1:��� �������޸� 1:�޸ĳɹ� 0:�޸�ʧ��
--==================================
CREATE procedure [dbo].[proc_WorkPlan_Update]
(
	@PlanId int, --�������
	@PlanNo nvarchar(255),--�ƻ����
	@CompanyId int,--��˾���
	@Title nvarchar(255),--����
	@Description nvarchar(max),--����
	@FilePath nvarchar(255),--����
	@Remark nvarchar(max),--��ע
	@ExpectedDate datetime,--�ƻ����ʱ��
	@ActualDate datetime,--ʵ�����ʱ��
	@Status tinyint,--״̬
	@WorkType tinyint,
	@AcceptXML nvarchar(max), --���ն���XML��<ROOT><AcceptInfo AccetpId="" /></ROOT>
	@Result int output --�������
)
as
begin 
	declare @error int
	set @error=0

	begin tran
		if exists(select 1 from tbl_WorkPlan where planId=@PlanId and IsCheck=''1'')
		begin
			set @Result=-1
			rollback tran
		end
		--�޸Ĺ����ƻ�������Ϣ
		update tbl_WorkPlan set PlanNo=@PlanNo,Title=@Title,
		Description=@Description,FilePath=@FilePath,
		Remark=@Remark,ExpectedDate=@ExpectedDate,
		ActualDate=@ActualDate,Status=@Status
		where planId=@PlanId
		set @error=@error+@@error

		--���빤����������������Ϣ
		if (@AcceptXML is not null)
		begin
			declare @hdoc int

			delete tbl_WorkPlanAccept where planId=@PlanId 
			and companyId=@CompanyId and WorkType=@WorkType
			set @error=@error+@@error
	
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@AcceptXML

			INSERT INTO tbl_WorkPlanAccept(CompanyId,PlanId,AccetpId,WorkType)
			SELECT @CompanyId,@planId,AccetpId,@WorkType
			FROM OPENXML(@hdoc,''/ROOT/AcceptInfo'')WITH(AccetpId int)
			set @error=@error+@@error
			
			EXECUTE sp_xml_removedocument @hdoc
		end
		
		if @error=0
		begin
			set @Result=1
			commit tran
		end
		else
		begin
			set @Result=0
			rollback tran
		end
	return @Result
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--==================================
--��������-�����ƻ����
--�����ˣ�³��Դ
--ʱ�䣺2011-01-19
--==================================
CREATE procedure [dbo].[proc_WorkPlan_Insert]
(
	@CompanyId int,--��˾���
	@PlanNo nvarchar(255),--�ƻ����
	@Title nvarchar(255),--����
	@Description nvarchar(max),--����
	@FilePath nvarchar(255),--����
	@Remark nvarchar(max),--��ע
	@OperatorId int,--�����˱��
	@OperatorName nvarchar(255),--����������
	@ExpectedDate datetime,--�ƻ����ʱ��
	@ActualDate datetime,--ʵ�����ʱ��
	@Status tinyint,--״̬
	@WorkType tinyint,
	@AcceptXML nvarchar(max), --���ն���XML��<ROOT><AcceptInfo AccetpId="" /></ROOT>
	@Result int output --�������
)
as
begin 
	DECLARE @hdoc int
	DECLARE @error int
	set @error=0
	DECLARE @planId int
	set @planId=0

	begin tran
		--���빤���ƻ�������Ϣ
		insert into tbl_WorkPlan
		(CompanyId,PlanNo,Title,Description,FilePath,
		Remark,ExpectedDate,ActualDate,OperatorId,
		OperatorName,Status)
		values
		(@CompanyId,@PlanNo,@Title,@Description,@FilePath,
		@Remark,@ExpectedDate,@ActualDate,@OperatorId,
		@OperatorName,@Status)
		select @planId=@@identity
		set @error=@error+@@error
		

		--���빤����������������Ϣ
		if @AcceptXML is not null
		begin
			
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@AcceptXML
			INSERT INTO tbl_WorkPlanAccept(CompanyId,PlanId,AccetpId,WorkType)
			SELECT @CompanyId,@planId,AccetpId,@WorkType
			FROM OPENXML(@hdoc,''/ROOT/AcceptInfo'')WITH(AccetpId int)
			set @error=@error+@@error
			
			EXECUTE sp_xml_removedocument @hdoc
		end
		
		if (@error<>0)
		begin
			set @Result=0
			rollback tran
		end
		else
		begin
			set @Result=1
			commit tran
		end
	return @Result
end
' 
END
GO
/****** Object:  View [dbo].[view_Fin_YingFuDiJie]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuDiJie]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:Ӧ���ؽ���ͼ
-- History:
-- 1.2013-05-22 ����־ ����[DaoYouName]
-- =============================================
CREATE VIEW [dbo].[view_Fin_YingFuDiJie]
AS
SELECT A.PlanId,A.CompanyId,A.KongWeiId
	,A.JiaoYiHao,A.GysId,A.RouteId
	,A.ChengRenShu,A.ErTongShu,A.QuPeiShu
	,A.JieSuanMX,A.JieSuanAmount,A.IssueTime
	,B.KongWeiCode,B.QuTime,B.QuDate,(SELECT TOP 1 C.ContactName,C.ContactTel FROM tbl_SupplierContact C WHERE C.SupplierId=A.GysId ORDER BY C.Id ASC FOR XML RAW,ROOT) AS ContactInfo
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=A.RouteId) AS RouteName
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=0),0) AS WeiShenPiJinE--δ�������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=1),0) AS YiShenPiJinE--������(δ֧��)���
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=102 AND A1.Status=2),0) AS YiZhiFuJinE--��֧�����
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--��Ӧ������
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHErE A1.Id=A.DaoYouId) AS DaoYouName--��������
	,B.ZxsId
	,A.YingErShu
FROM tbl_PlanDiJie AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId


'
GO
/****** Object:  View [dbo].[view_Fin_YingFuJiaoTong]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YingFuJiaoTong]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:Ӧ����ͨ��ͼ
-- =============================================
CREATE VIEW [dbo].[view_Fin_YingFuJiaoTong]
AS
SELECT A.PlanId,A.CompanyId,A.KongWeiId
	,A.JiaoYiHao,A.GysId
	,A.ShuLiang
	,A.JieSuanMX,A.JieSuanAmount,A.IssueTime
	,B.KongWeiCode,B.QuTime,B.QuDate,(SELECT TOP 1 A1.ContactName,A1.ContactTel FROM tbl_SupplierContact A1 WHERE A1.SupplierId=A.GysId ORDER BY A1.Id ASC FOR XML RAW,ROOT) AS ContactInfo
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=104 AND A1.Status=0),0) AS WeiShenPiJinE--δ�������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=104 AND A1.Status=1),0) AS YiShenPiJinE--������(δ֧��)���
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.PlanId AND A1.CollectionItem=104 AND A1.Status=2),0) AS YiZhiFuJinE--��֧�����
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--��Ӧ������
	,C.GysOrderCode
	,B.QuJiaoTongId
	,B.ZxsId
FROM tbl_PlanChuPiao AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId INNER JOIN tbl_KongWeiDaiLi AS C
ON A.DaiLiId=C.DaiLiId


'
GO
/****** Object:  View [dbo].[view_KongWeiYajin]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_KongWeiYajin]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		
-- Create date: 
-- Description:�ƻ�λ������Ϣ��ͼ
-- History:
-- 1.2013-01-05 ����־ SUM(��֧�����)��SUM(���ս��)
-- =============================================
CREATE view [dbo].[view_KongWeiYajin]
as
select DaiLiId,KongWeiId,(select UnitName from tbl_CompanySupplier where  Id=tbl_KongWeiDaiLi.GysId)as GysName,
Price,ShuLiang,ShiXian,GysOrderCode,YaJinAmount,YaJinBeiZhu,YaJinOperatorId,
TuiYaJinAmount,TuiYaJinBeiZhu,TuiTime,TuiYaJinOperatorId,
(select top 1 ContactName from tbl_SupplierContact where SupplierId=tbl_KongWeiDaiLi.GysId) as ContactName,
(select top 1 ContactTel from tbl_SupplierContact where SupplierId=tbl_KongWeiDaiLi.GysId) as ContactTel,
isnull((select SUM(CollectionRefundAmount) from tbl_FinCope where CollectionId=tbl_KongWeiDaiLi.DaiLiId 
	and CollectionItem=103  
	and [Status]=2
),0) as CheckMoney,
isnull((select SUM(CollectionRefundAmount) from tbl_FinCope where CollectionId=tbl_KongWeiDaiLi.DaiLiId 
	and CollectionItem=2   
	and [Status]=1
),0) as ReturnMoney,
(select isnull(sum(ShuLiang),0) from tbl_PlanChuPiao where DaiLiId=tbl_KongWeiDaiLi.DaiLiId) as YiChuPiao
,IdentityId
from tbl_KongWeiDaiLi

'
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_RiJiZhang_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_RiJiZhang_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2012-11-22
-- Description:д���ռ���
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_RiJiZhang_Insert]
	 @RiJiId CHAR(36)--�ռ��˱��
	,@CompanyId INT--��˾���
	,@DengJiRiQi DATETIME--�Ǽ�����
	,@XiangMu TINYINT--��Ŀ
	,@YeWuRiQi NVARCHAR(50)--ҵ������
	,@PingZhengHao NVARCHAR(50)--ƾ֤��
	,@ZhangHuId CHAR(36)--�����˻����
	,@WangLaiDanWei NVARCHAR(255)--������λ
	,@MingXi NVARCHAR(255) --��ϸ
	,@JieFangJinE MONEY--�跽���
	,@DaiFangJinE MONEY--�������
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@RetCode INT OUTPUT	
	,@WangLaiDanWeiLeiXing TINYINT--������λ����
	,@WangLaiDanWeiId CHAR(36)--������λ���
	,@YeWuRiQi1 DATETIME--ҵ������
	,@ZxsId CHAR(36)
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @YuE MONEY--���

	SET @errorcount=0

	IF EXISTS(SELECT 1 FROM tbl_FinRiJiZhang WHERE CompanyId=@CompanyId)	
	BEGIN
		SELECT TOP(1) @YuE=YuE FROM tbl_FinRiJiZhang WHERE CompanyId=@CompanyId ORDER BY IssueTime DESC
	END
	ELSE
	BEGIN
		SELECT @YuE=SUM(AccountMoney) FROM tbl_CompanyAccount WHERE CompanyId=@CompanyId AND AccountState IN(1,2)
	END

	SET @YuE=ISNULL(@YuE,0)
	SET @YuE=@YuE+@JieFangJinE-@DaiFangJinE

	INSERT INTO [tbl_FinRiJiZhang]([DengJiId],[CompanyId],[DengJiRiQi],[XiangMu]
		,[YeWuRiQi],[PingZhengHao],[ZhangHuId],[WangLaiDanWei]
		,[MingXi],[JieFangJinE],[DaiFangJinE],[YuE]
		,[OperatorId],[IssueTime],[WangLaiDanWeiLeiXing],[WangLaiDanWeiId]
		,[YeWuRiQi1],[ZxsId])
	VALUES(@RiJiId,@CompanyId,@DengJiRiQi,@XiangMu
		,@YeWuRiQi,@PingZhengHao,@ZhangHuId,@WangLaiDanWei
		,@MingXi,@JieFangJinE,@DaiFangJinE,@YuE
		,@OperatorId,@IssueTime,@WangLaiDanWeiLeiXing,@WangLaiDanWeiId
		,@YeWuRiQi1,@ZxsId)
	SET @errorcount=@errorcount+@@ERROR
	
	IF(@errorcount<>0)
	BEGIN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianLeiBie_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianLeiBie_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-03
-- Description:	ר�����ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianLeiBie_D]
	@ZxlbId INT
	,@CompanyId INT
	,@OperatorId INT
	,@IssueTime DATETIME
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianLeiBie WHERE ZxlbId=@ZxlbId AND CompanyId=@CompanyId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Area WHERE ZxlbId=@ZxlbId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXaingShangZhanDian WHERE ZxlbId=@ZxlbId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Route WHERE ZxlbId=@ZxlbId)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE ZxlbId=@ZxlbId)
	BEGIN
		SET @RetCode=-95
		RETURN @RetCode
	END
	
	UPDATE tbl_Pt_ZhuanXianLeiBie SET IsDelete=''0'' WHERE ZxlbId=@ZxlbId AND CompanyId=@CompanyId
	
	SET @RetCode=1
	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhanDian_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhanDian_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-03
-- Description:	վ��ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhanDian_D]
	@ZhanDianId INT
	,@CompanyId INT
	,@IssueTime DATETIME
	,@OperatorId INT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_ZhanDian WHERE CompanyId=@CompanyId AND ZhanDianId=@ZhanDianId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianLeiBie WHERE ZhanDianId=@ZhanDianId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXaingShangZhanDian WHERE ZhanDianId=@ZhanDianId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Route WHERE ZhanDianId=@ZhanDianId)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	
	UPDATE tbl_Pt_ZhanDian SET IsDelete=''1'' WHERE ZhanDianId=@ZhanDianId
	
	SET @RetCode=1
	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianLeiBie_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianLeiBie_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-03
-- Description:	ר������������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianLeiBie_CU]
	@ZxlbId INT
	,@CompanyId INT
	,@ZhanDianId INT
	,@MingCheng NVARCHAR(255)
	,@Status TINYINT
	,@OperatorId INT
	,@IssueTime DATETIME
	,@RetCode INT OUTPUT
	,@RetZxlbId INT OUTPUT
	,@PaiXuId INT
AS
BEGIN
	SET @RetCode=0
	SET @RetZxlbId=@ZxlbId
	--DECLARE @YuanZhanDianId INT
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianLeiBie WHERE CompanyId=@CompanyId AND ZhanDianId=@ZhanDianId AND MingCheng=@MingCheng AND IsDelete=''0'' AND ZxlbId<>@ZxlbId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END	
	
	IF(@ZxlbId=0)
	BEGIN
		INSERT INTO [tbl_Pt_ZhuanXianLeiBie]([CompanyId],[ZhanDianId],[MingCheng]
			,[Status],[OperatorId],[IssueTime]
			,[IsDelete],[PaiXuId])
		VALUES(@CompanyId,@ZhanDianId,@MingCheng
			,@Status,@OperatorId,@IssueTime
			,''0'',@PaiXuId)
		SET @RetZxlbId=SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		--SELECT @YuanZhanDianId=ZhanDianId FROM [tbl_Pt_ZhuanXianLeiBie] WHERE ZxlbId=@ZxlbId
		UPDATE [tbl_Pt_ZhuanXianLeiBie] SET MingCheng=@MingCheng,[Status]=@Status,ZhanDianId=@ZhanDianId,PaiXuId=@PaiXuId
		WHERE ZxlbId=@ZxlbId AND CompanyId=@CompanyId
	END
	
	SET @RetCode=1
	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLeave_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_UserLeave_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-12-5>
-- Description:	<�޸��������>
-- Result :-1:����˲������޸� 1:�޸ĳɹ� 0:�޸�ʧ��
-- =============================================
CREATE proc [dbo].[proc_UserLeave_Update]
@Id int,
@StartDate datetime, 
@StartTime nvarchar(255), 
@EndDate datetime, 
@EndTime nvarchar(255), 
@Reason nvarchar(255), 
@Nature tinyint, 
@Situation nvarchar(255),
@Result int output
as
begin
	if exists(select 1 from tbl_UserLeave where CheckState=1 and Id=@Id)
	begin
		set @Result=-1
	end
	else
	begin
	   declare @error int
	   set @error=0
	   UPDATE tbl_UserLeave SET StartDate = @StartDate,StartTime = @StartTime, 
	    EndDate = @EndDate,EndTime = @EndTime, Reason = @Reason, 
        Nature = @Nature,Situation = @Situation WHERE Id=@Id
		set @error=@error+@@error
		if @error=0
			set @Result=1
		else
			set @Result=0
	end
	
	return @Result
end

' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLeave_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_UserLeave_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-12-5>
-- Description:	<ɾ���������>
-- Result :-1:�������˲�����ɾ�� 1:ɾ���ɹ� 0:ɾ��ʧ��
-- =============================================
CREATE proc [dbo].[proc_UserLeave_Delete]
@Id int,
@Result int output
as
begin
	if exists(select 1 from tbl_UserLeave where CheckState=1 and Id=@Id)
	begin
		set @Result=-1
	end
	else
	begin
		declare @error int
		set @error=0
		DELETE FROM tbl_UserLeave WHERE Id=@Id
		set @error=@error+@@error
		if @error=0
			set @Result=1
		else
			set @Result=0
	end
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_ChongDi]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_ChongDi]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2013-01-31
-- Description: �������-���ɵ��� ���
-- History:
-- 1.2013-08-08 ����־ ��ֲ�����������������Ĺ���
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_DengZhang_ChongDi]	 
	 @ChongDiId CHAR(36)--��ֱ��
	,@CompanyId INT--��˾���
	,@DengZhangId CHAR(36)--���˱��
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@JinE MONEY--��ֽ��
	,@BeiZhu NVARCHAR(255)--��ע
	,@LeiXing TINYINT--����
	,@RetCode INT OUTPUT--OUTPUT CODE
	,@DanWeiId CHAR(36)--��λ���
	,@DanWeiType TINYINT--��λ����
	,@XiangMuId INT--��Ŀ���
	,@QiTaShouRuId CHAR(36)--����������
	,@QiTaShouZhiType TINYINT--������֧���
	,@ZxsId CHAR(36)
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @OperatorName NVARCHAR(50)
	DECLARE @XiangMuName NVARCHAR(50)
	
	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM tbl_FinRegister WHERE CompanyId=@CompanyId AND DengZhangId=@DengZhangId AND [Status]=1)
	BEGIN
		SET @RetCode=-1
		RETURN @RetCode
	END
	
	DECLARE @DaoKuanJinE MONEY--������
	DECLARE @YiXiaoZhangJinE MONEY--�����˽��
	SELECT @DaoKuanJinE=DaoKuanJinE FROM tbl_FinRegister WHERE DengZhangId=@DengZhangId
	SELECT @YiXiaoZhangJinE=ISNULL(SUM(UnCheckMoney),0) FROM tbl_FinRegisterUnCheck WHERE DZId=@DengZhangId

	IF(@DaoKuanJinE<@YiXiaoZhangJinE+@JinE)
	BEGIN
		SET @RetCode=-2
		RETURN @RetCode
	END

	SELECT @OperatorName=ContactName FROM tbl_CompanyUser WHERE Id=@OperatorId
	SELECT @XiangMuName=[Name] FROM tbl_ComJiChuXinXi WHERE Id=@XiangMuId

	BEGIN TRAN

	INSERT INTO [tbl_FinRegisterUnCheck]([UnCheckId],[DZId],[OrderId],[UnCheckMoney]
		,[OperatorId],[IssueTime],[LeiXing],[BeiZhu]
		,[XiangMuId],[DanWeiType],[DanWeiId])
	VALUES(@ChongDiId,@DengZhangId,'''',@JinE
		,@OperatorId,@IssueTime,@LeiXing,@BeiZhu
		,@XiangMuId,@DanWeiType,@DanWeiId)
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0)--��������
	BEGIN
		INSERT INTO [tbl_FinOther]([Id],[CompanyId],[TourId],[CostType]
			,[CustromType],[CustromCId],[ProceedItem],[Proceed]
			,[Date],[Remark],[OperatorId],[CreateTime]
			,[XiangMuId],[IsChongDi],[ChongDiId],[ZxsId])
		VALUES(@QiTaShouRuId,@CompanyId,NULL,@QiTaShouZhiType
			,@DanWeiType,@DanWeiId,@XiangMuName,@JinE
			,@IssueTime,''���ɵ��˳��'',@OperatorId,@IssueTime
			,@XiangMuId,''1'',@ChongDiId,@ZxsId)
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount=0)--���������տ�Ǽ�
	BEGIN
		INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem]
			,[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount]
			,[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate]
			,[Status],[ApproverId],[ApproveTime],[ApproveRemark]
			,[PayId],[PayTime],[PayRemark],[OperatorId]
			,[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId])
		SELECT NEWID(),@CompanyId,@QiTaShouRuId,4
			,A.DaoKuanTime,@OperatorName,@OperatorId,@JinE
			,A.PayType,''���ɵ���-���-���������տ�'',A.BankId,A.BankDate
			,1,A.ApproverId,A.ApproveTime,''''
			,NULL,NULL,NULL,@OperatorId
			,@IssueTime,''1'',@ChongDiId,@ZxsId
		FROM tbl_FinRegister AS A
		WHERE A.DengZhangId=@DengZhangId

		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  View [dbo].[view_Pt_KongWeiXianLu]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Pt_KongWeiXianLu]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-01
-- Description: ƽ̨-��λ��·
-- =============================================
CREATE VIEW [dbo].[view_Pt_KongWeiXianLu]
AS
SELECT A.[IdentityId] 
	,A.[XianLuId]
	,A.[LeiXing]
	,A.[KongWeiId]
	,A.[RouteId]
	,A.[MenShiJiaGe1]
	,A.[MenShiJiaGe2]
	,A.[MenShiJiaGe3]
	,A.[JieSuanJiaGe1]
	,A.[JieSuanJiaGe2]
	,A.[JieSuanJiaGe3]
	,A.[QuanPeiJiaGe]
	,A.[BuFangChaJiaGe]
	,A.[TuiFangChaJiaGe]
	,A.[JiFen]
	,A.[Status]
	,A.[PaiXuId]
	,A.[XianLuCode]
	,B.RouteName
	,B.BiaoZhun
	,B.FengMian
FROM tbl_Pt_KongWeiXianLu AS A LEFT OUTER JOIN tbl_Route AS B
ON A.RouteId=B.RouteId
'
GO
/****** Object:  View [dbo].[view_Fin_YaJin]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YaJin]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:Ѻ��ǼǱ�
-- =============================================
CREATE VIEW [dbo].[view_Fin_YaJin]
AS
SELECT A.DaiLiId,A.CompanyId,A.KongWeiId
	,A.GysId,A.GysOrderCode,A.ShuLiang
	,A.YaJinAmount,A.TuiYaJinAmount
	,B.KongWeiCode
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.DaiLiId AND A1.CollectionItem=103 AND A1.Status=0),0) AS WeiShenPiJinE--Ѻ��֧��δ�������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.DaiLiId AND A1.CollectionItem=103 AND A1.Status=1),0) AS YiShenPiJinE--Ѻ��֧��������(δ֧��)���
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.DaiLiId AND A1.CollectionItem=103 AND A1.Status=2),0) AS YiZhiFuJinE--Ѻ��֧����֧�����
	,(SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.GysId) AS GysName--��Ӧ������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.DaiLiId AND A1.CollectionItem=2 AND A1.Status=0),0) AS TuiWeiShenPiJinE--�˻�Ѻ��δ�������
	,ISNULL((SELECT SUM(CollectionRefundAmount) FROM tbl_FinCope AS A1 WHERE A1.CollectionId=A.DaiLiId AND A1.CollectionItem=2 AND A1.Status=1),0) AS TuiYiShenPiJinE--�˻�Ѻ�����������
	,A.IdentityId
	,B.QuDate
	,B.ZxsId
FROM tbl_KongWeiDaiLi AS A INNER JOIN tbl_KongWei AS B
ON A.KongWeiId=B.KongWeiId
WHERE A.YaJinAmount>0

'
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWeiYajin]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWeiYajin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-19>
-- Description:	<Ʊ��Ѻ�����˿�>
-- Result :-1:Ѻ�����С���ѵǼǵĸ�����
--		   -2:�˻ؽ���С���ѵǼǵ��տ���
--		   -3:��ӳɹ�
--		   -4:���ʧ��			
-- =============================================
CREATE proc [dbo].[proc_KongWeiYajin]
@DaiLiId char(36),
@YaJinAmount money, 
@YaJinBeiZhu nvarchar(255), 
@YaJinOperatorId int, 
@TuiYaJinAmount money, 
@TuiYaJinBeiZhu nvarchar(255), 
@TuiTime datetime, 
@TuiYaJinOperatorId int,
@Result int output
as
begin
	declare @error int
	set @error=0

	--CollectionId 103:Ʊ��Ѻ�𸶿�  2:Ʊ��Ѻ���˻�

	declare @CheckMoney money	--�ѵǼǸ��֧����
	select @CheckMoney=sum(CollectionRefundAmount) from tbl_FinCope
	where CollectionId=@DaiLiId 
	and CollectionItem=103 
	set @error=@error+@@error
	
	if(@YaJinAmount<@CheckMoney)
	begin
		set @Result=-1 --Ѻ�����С���ѵǼǵĸ�����	
		return @Result
	end

	declare @ReturnMoney money--�ѵǼ��˿���룩
	select @ReturnMoney=sum(CollectionRefundAmount) from tbl_FinCope
	where CollectionId=@DaiLiId 
	and CollectionItem=2 
	set @error=@error+@@error

	if(@TuiYaJinAmount<@ReturnMoney)
	begin
		set @Result=-2	--�˻ؽ���С���ѵǼǵ��տ���
		return @Result
	end
	
	UPDATE tbl_KongWeiDaiLi
	SET YaJinAmount = @YaJinAmount,
        YaJinBeiZhu = @YaJinBeiZhu,
        YaJinOperatorId = @YaJinOperatorId,
        TuiYaJinAmount = @TuiYaJinAmount,
        TuiYaJinBeiZhu = @TuiYaJinBeiZhu,
        TuiTime = @TuiTime,
        TuiYaJinOperatorId = @TuiYaJinOperatorId
	WHERE DaiLiId = @DaiLiId
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=-3	--��ӳɹ�
	end
	else
	begin
		set @Result=-4	--���ʧ��
	end

	return @Result
end

' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_SetOrderJinE]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_SetOrderJinE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:ά�������ո�����
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_SetOrderJinE]
	 @OrderId CHAR(36)--�������
AS
BEGIN
		UPDATE [tbl_TourOrder] SET [CheckMoney]=ISNULL((SELECT SUM([CollectionRefundAmount]) FROM [tbl_FinCope] WHERE [CollectionId]=@OrderId AND [CollectionItem]=0 AND [Status]=1),0)
			,[ReceivedMoney]=ISNULL((SELECT SUM([CollectionRefundAmount]) FROM [tbl_FinCope] WHERE [CollectionId]=@OrderId AND [CollectionItem]=0),0)
			,[ReturnMoney]=ISNULL((SELECT SUM([CollectionRefundAmount]) FROM [tbl_FinCope] WHERE [CollectionId]=@OrderId AND [CollectionItem]=101 AND [Status]=2),0)
			,[RefundMoney]=ISNULL((SELECT SUM([CollectionRefundAmount]) FROM [tbl_FinCope] WHERE [CollectionId]=@OrderId AND [CollectionItem]=101),0)
		WHERE [OrderId]=@OrderId
END
' 
END
GO
/****** Object:  View [dbo].[view_PlanDiJie]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_PlanDiJie]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		
-- Create date: 
-- Description:�Ѱ��ŵؽ���ͼ
-- History:
-- 1.2013-01-05 ����־ ����[OperatorId],[OperatorName]
-- 2.2013-01-28 ����־ SUM(CollectionRefundAmount)
-- =============================================
CREATE view [dbo].[view_PlanDiJie]
AS
SELECT 
	 A.PlanId
	,A.KongWeiId
	,A.ChengRenShu
	,A.ErTongShu
	,A.QuPeiShu
	,A.JieTuanFangShi
	,A.JieSuanAmount
	,A.JiaoYiHao
	,(SELECT UnitName FROM  tbl_CompanySupplier AS B WHERE B.Id=A.GysId) AS GysName
	,(SELECT RouteName FROM tbl_Route AS B WHERE B.RouteId=A.RouteId) AS RouteName
	,(SELECT ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.DaoYouId) AS DaoYouName
	,(SELECT ISNULL(SUM(CollectionRefundAmount),0) FROM tbl_FinCope AS B WHERE B.CollectionId=A.PlanId AND B.CollectionItem=102 AND B.[Status]=2) AS PayAmount 
	,A.OperatorId
	,(SELECT ContactName FROM tbl_CompanyUser AS B WHERE B.Id=A.OperatorId) AS OperatorName
	,A.YingErShu
FROM tbl_PlanDiJie  AS A

'
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-19>
-- Description:	<�޸İ���Ʊ��>
-- Result :-1:��Ʊ��������ʣ������
--		   -2:��ǰ�������ڲ���������Ʊ�ο�
--		   -3:�޸ĳɹ�
--		   -4:�޸�ʧ��	
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���			
-- =============================================
CREATE proc [dbo].[proc_PlanChuPiao_Update]
@PlanId char(36),				--�ƻ����
@CompanyId int,					--��˾���
@KongWeiId char(36),			--��λ��
@JiaoYiHao nvarchar(255),		--���׺�
@DaiLiId char(36),				--������
@GysId char(36),				--��Ӧ�̱��
@ShuLiang int,					--����
@JieSuanMX nvarchar(255),		--������ϸ
@JieSuanAmount money,			--������
@Remark nvarchar(255),			--��ע	
@FilePath nvarchar(255),		--�ļ�
@OperatorId int,				--������
@Traveller xml,		--�ο���Ϣ<Root><Traveller PlanId=\"{0}\" YouKeId=\"{1}\" OrderId=\"{2}\" /></Root>
@Result int output
as
begin
	declare @error int
	set @error=0
	
	declare @TotalNum int
	DECLARE @YuanGysId CHAR(36)--��Ӧ�̱��
	select @TotalNum=isnull(ShuLiang,0),@YuanGysId=GysId from tbl_KongWeiDaiLi where DaiLiId=@DaiLiId

	--���ڸ���Ǽǵĳ�Ʊ���Ų������޸Ĵ�������Ϣ
	if  exists(select 1 from tbl_FinCope where CollectionId=@PlanId and CollectionItem=104) AND @GysId<>@YuanGysId
	begin	
		set @Result=-81
		return @Result
	end
	
	--�ѳ�Ʊ�ų�����
	declare @YiChuPiao int
	select @YiChuPiao=isnull(sum(ShuLiang),0) from tbl_PlanChuPiao 
	where DaiLiId=@DaiLiId and PlanId<>@PlanId


	if(@TotalNum-@YiChuPiao<@ShuLiang)
	begin
		set @Result=-1 -- -1:��Ʊ��������ʣ������
		return @Result
	end	

	if(@Traveller is null)
	begin
		set @Result=-4
	end
	
	declare @idoc int
	exec sp_xml_preparedocument @idoc output,@Traveller
	set @error=@error+@@error

	--�ҳ������ӵĳ�Ʊ�ο�
	select YouKeId,OrderId into #temp from openxml(@idoc,''/Root/Traveller'')
    with(YouKeId char(36),OrderId char(36))
	where YouKeId  not in (select YouKeId from tbl_PlanChuPiaoYouKe where PlanId=@PlanId)
	

	if exists (select 1 from #temp where YouKeId not in 
										(select TravellerId  from tbl_TourOrderTraveller 
										 where TourId=@KongWeiId))
	begin
		 set @Result=-2 --���ڲ���������Ʊ�ο�
		 return @Result
	end

	if exists(select 1 from tbl_TourOrderTraveller where TourId=@KongWeiId and (Status=1 or TicketType in (1,2))
	and exists(select 1 from #temp where YouKeId=tbl_TourOrderTraveller.TravellerId))
	begin
		set @Result=-2 --���ڲ���������Ʊ�ο�
		return @Result
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	--�жϵ�ǰ�ο��Ƿ�������δ��Ʊstatus:���� = 0,���� = 1	
	--TicketType:δ��Ʊ = 0,�ѳ�Ʊ = 1,����Ʊ = 2

	--�ҳ�ɾ���ĳ�Ʊ�ο�
	select * into #temp1 from tbl_PlanChuPiaoYouKe where PlanId=@PlanId
	and not exists(select YouKeId from openxml(@idoc,''/Root/Traveller'') with(YouKeId char(36))
				   where YouKeId=tbl_PlanChuPiaoYouKe.YouKeId	
				  )
	
	begin transaction
	--�޸ĳ�Ʊ����
	UPDATE tbl_PlanChuPiao SET DaiLiId = @DaiLiId,
	GysId = @GysId,ShuLiang = @ShuLiang,JieSuanMX = @JieSuanMX,
	JieSuanAmount = @JieSuanAmount,Remark = @Remark,FilePath = @FilePath
	WHERE PlanId = @PlanId
	set @error=@error+@@error

	--����³�Ʊ���ο���Ϣ
	INSERT INTO tbl_PlanChuPiaoYouKe(PlanId,YouKeId,OrderId)
	select @PlanId,YouKeId,OrderId from #temp
	set @error=@error+@@error	

	--������ӵ��ο�״̬��Ϊ�ѳ�Ʊ
	UPDATE tbl_TourOrderTraveller SET TicketType=1 
	where TravellerId in (select YouKeId from #temp)
	set @error=@error+@@error

	--ɾ����Ϣ
	Delete from tbl_PlanChuPiaoYouKe where YouKeId in (select YouKeId from #temp1)

	--��ɾ���ѳ�Ʊ���ο�״̬��Ϊδ��Ʊ
	UPDATE tbl_TourOrderTraveller SET TicketType=0
	where TravellerId in (select YouKeId from #temp1)
	set @error=@error+@@error

	exec sp_xml_removedocument @idoc
	set @error=@error+@@error
	
	drop table #temp
	set @error=@error+@@error

	drop table #temp1
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=-3
		commit transaction
	end
	else
	begin
		set @Result=-4
		rollback transaction
	end
	return @Result

end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_GongZi_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_GongZi_SetStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2013-08-05
-- Description: ���ù���״̬
-- History:
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_GongZi_SetStatus]
	 @GongZiId CHAR(36)--���ʱ��
	,@OperatorId INT--�����˱��
	,@OperatorTime DATETIME--����ʱ��
	,@BeiZhu NVARCHAR(255)--������ע
	,@Status TINYINT--����״̬
	,@ZhangHuId CHAR(36)=NULL--֧���˺�
	,@YingHangTime DATETIME=NULL--����ʵ��ҵ������
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @ZxsId CHAR(36)

	SET @errorcount=0
	
	IF(@Status NOT IN(0,1,2))
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinGongZi] WHERE [GongZiId]=@GongZiId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	DECLARE @IStatus TINYINT--��ǰ״̬
	SELECT @IStatus=[Status],@ZxsId=ZxsId FROM [tbl_FinGongZi] WHERE [GongZiId]=@GongZiId

	BEGIN TRAN

	IF(@IStatus=0 AND @Status =1)--����
	BEGIN
		UPDATE [tbl_FinGongZi] SET [ShenHeOperatorId]=@OperatorId,[ShenHeBeiZhu]=@BeiZhu
			,[ShenHeTime]=@OperatorTime ,[Status]=@Status
		WHERE [GongZiId]=@GongZiId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@IStatus=1 AND @Status=2)--֧��
	BEGIN
		UPDATE [tbl_FinGongZi] SET [ZhiFuOperatorId]=@OperatorId,[ZhiFuBeiZhu]=@BeiZhu
			,[ZhiFuTime]=@OperatorTime,[Status]=@Status 
			,[ZhangHuId]=@ZhangHuId,[YingHangTime]=@YingHangTime
		WHERE [GongZiId]=@GongZiId
		SET @errorcount=@errorcount+@@ERROR

		DECLARE @FuKuanRenName NVARCHAR(36)
		SELECT @FuKuanRenName=ContactName FROM tbl_CompanyUser WHERE Id=@OperatorId
		--д������ϸ
		INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem]
			,[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount]
			,[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate]
			,[Status],[ApproverId],[ApproveTime],[ApproveRemark]
			,[PayId],[PayTime],[PayRemark],[OperatorId]
			,[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId])
		SELECT NEWID(),A.CompanyId,@GongZiId,109
			,@OperatorTime,@FuKuanRenName,@OperatorId,A.ShiFaGongZi
			,0,@BeiZhu,@ZhangHuId,@YingHangTime
			,2,@OperatorId,@OperatorTime,@BeiZhu
			,@OperatorId,@OperatorTime,@BeiZhu,@OperatorId
			,@OperatorTime,''0'',NULL,@ZxsId
		FROM [tbl_FinGongZi] AS A WHERE A.[GongZiId]=@GongZiId
		SET @errorcount=@errorcount+@@ERROR
	END	

	IF(@IStatus=2 AND @Status=1)--ȡ��֧��
	BEGIN
		UPDATE [tbl_FinGongZi] SET [ZhiFuOperatorId]=0,[ZhiFuBeiZhu]=''''
			,[ZhiFuTime]=NULL,[Status]=@Status 
			,[ZhangHuId]='''',[YingHangTime]=NULL
		WHERE [GongZiId]=@GongZiId
		SET @errorcount=@errorcount+@@ERROR

		IF(@errorcount=0)
		BEGIN
			DELETE FROM [tbl_FinCope] WHERE [CollectionItem]=109 AND [CollectionId]=@GongZiId
			SET @errorcount=@errorcount+@@ERROR
		END
	END

	IF(@IStatus=1 AND @Status=0)--ȡ������
	BEGIN
		UPDATE [tbl_FinGongZi] SET [Status]=@Status 
		WHERE [GongZiId]=@GongZiId
		SET @errorcount=@errorcount+@@ERROR	
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2011-11-16>
-- Description:	<ɾ���ؽӰ���>
--Result:1:ɾ���ɹ� 0:�޸�ʧ��,-1���Ѿ��Ǽǹ�����İ��������ɾ����
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���
-- =============================================
CREATE proc [dbo].[proc_PlanDiJie_Delete]
@PlanId char(36), 
@Result int output
as
begin
	declare @error int
	set @error=0
	
	--�Ѿ��Ǽǹ�����İ��������ɾ����
	if exists(select 1 from tbl_FinCope where CollectionId=@PlanId and CollectionItem=102)
	begin
		set @Result=-1
		return @Result
	end

	DECLARE @KongWeiId CHAR(36)
	SELECT @KongWeiId=KongWeiid FROM tbl_PlanDiJie WHERE PlanId=@PlanId
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END

	begin transaction
	delete from tbl_PlanDiJIeOrder where PlanId=@PlanId
	set @error=@error+@@error
		
	delete from tbl_PlanDiJie WHERE PlanId = @PlanId
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end

	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhanDian_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhanDian_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-03
-- Description:	վ���������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhanDian_CU]
	@ZhanDianId INT
	,@CompanyId INT
	,@MingCheng NVARCHAR(255)
	,@IssueTime DATETIME
	,@OperatorId INT
	,@RetCode INT OUTPUT
	,@RetZhanDianId INT OUTPUT
	,@PaiXuId INT
	,@XzqhdmXml NVARCHAR(MAX)
AS
BEGIN
	SET @RetCode=0
	SET @RetZhanDianId=@ZhanDianId
	DECLARE @hdoc INT
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_ZhanDian WHERE CompanyId=@CompanyId AND ZhanDianId<>@ZhanDianId AND MingCheng=@MingCheng AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF(@ZhanDianId=0)
	BEGIN
		INSERT INTO [tbl_Pt_ZhanDian]([CompanyId],[MingCheng],[IssueTime]
			,[OperatorId],[PaiXuId],[IsDelete])
		VALUES(@CompanyId,@MingCheng,@IssueTime
			,@OperatorId,@PaiXuId,''0'')
		SET @RetZhanDianId=SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		UPDATE [tbl_Pt_ZhanDian] SET [MingCheng]=@MingCheng,PaiXuId=@PaiXuId
		WHERE ZhanDianId=@ZhanDianId AND [CompanyId]=@CompanyId
	END
	
	DELETE FROM tbl_Pt_ZhanDianXzqhdm WHERE ZhanDianId=@ZhanDianId
	IF(@XzqhdmXml IS NOT NULL AND LEN(@XzqhdmXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@XzqhdmXml
		INSERT INTO [tbl_Pt_ZhanDianXzqhdm]([ZhanDianId],[Xzqhdm])
		SELECT @ZhanDianId,[Xzqhdm]
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH([Xzqhdm] NVARCHAR(50))
		EXEC sp_xml_removedocument @hdoc
	END
	
	SET @RetCode=1
	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkPlan_Check]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkPlan_Check]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [dbo].[proc_WorkPlan_Check]
@PlanId int,
@CheckId int,
@ManagerComment varchar(max),
@Result int output
as
begin
	declare @error int
	set @error=0
	UPDATE tbl_WorkPlan SET IsCheck = ''1'', 
	CheckId = @CheckId,CheckDate = getdate(),ManagerComment = @ManagerComment
	where PlanId=@PlanId
	set @error=@error+@@error
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	return @Result
end



' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:��Ʊ�Ǽǣ�����1�ɹ�������ʧ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_FaPiao_Insert]
	 @FaPiaoId CHAR(36)--��Ʊ���
	,@CompanyId INT--��˾���
	,@ShenQingRiQi DATETIME--��Ʊ��������
	,@KeHuId CHAR(36)--�ͻ���λ���
	,@TaiTou NVARCHAR(255)--��Ʊ̧ͷ
	,@JinE MONEY--��Ʊ���
	,@XiangMuMingXi NVARCHAR(MAX)--��Ʊ��Ŀ��ϸ
	,@KaiJuDanWeiName NVARCHAR(255)--���߷�Ʊ��λ����
	,@FaPiaoHao NVARCHAR(255)--��Ʊ��
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@MxXml NVARCHAR(MAX)--��Ʊ��ϸXML:<root><info MxId="" ChuTuanRiQi="" JinE="" Status="" FaSongTime="" FaSongFangShi="" YouJiGongSiName="" YouJiDanHao="" QianShouRenName="" QianShouTime="" /></root>
	,@RetCode INT OUTPUT
	,@ZxsId CHAR(36)
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0

	BEGIN TRAN
	INSERT INTO [tbl_FinFaPiao]([DengJiId],[CompanyId],[ShenQingRiQi],[KeHuId]
		,[TaiTou],[JinE],[MingXi],[KaiJuDanWeiName]
		,[FaPiaoHao],[Status],[OperatorId],[IssueTime]
		,[ZxsId])
	VALUES(@FaPiaoId,@CompanyId,@ShenQingRiQi,@KeHuId
		,@TaiTou,@JinE,@XiangMuMingXi,@KaiJuDanWeiName
		,@FaPiaoHao,0,@OperatorId,@IssueTime
		,@ZxsId)
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @MxXml IS NOT NULL AND LEN(@MxXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@MxXml

		INSERT INTO [tbl_FinFaPiaoMx]([DengJiId],[ChuTuanRiQi],[JinE],[Status])
		SELECT @FaPiaoId,A.ChuTuanRiQi,A.JinE,0
		FROM OPENXML(@hdoc,''/root/info'') 
		WITH(ChuTuanRiQi DATETIME,JinE MONEY) AS A
		SET @errorcount=@errorcount+@@ERROR

		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:��Ʊ�޸ģ�����1�ɹ�������ʧ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_FaPiao_Update]
	 @FaPiaoId CHAR(36)--��Ʊ���
	,@CompanyId INT--��˾���
	,@ShenQingRiQi DATETIME--��Ʊ��������
	,@KeHuId CHAR(36)--�ͻ���λ���
	,@TaiTou NVARCHAR(255)--��Ʊ̧ͷ
	,@JinE MONEY--��Ʊ���
	,@XiangMuMingXi NVARCHAR(MAX)--��Ʊ��Ŀ��ϸ
	,@KaiJuDanWeiName NVARCHAR(255)--���߷�Ʊ��λ����
	,@FaPiaoHao NVARCHAR(255)--��Ʊ��
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@MxXml NVARCHAR(MAX)--��Ʊ��ϸXML:<root><info MxId="" ChuTuanRiQi="" JinE="" Status="" FaSongTime="" FaSongFangShi="" YouJiGongSiName="" YouJiDanHao="" QianShouRenName="" QianShouTime="" /></root>
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinFaPiao] WHERE [DengJiId]=@FaPiaoId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	BEGIN TRAN
	UPDATE [tbl_FinFaPiao] SET [ShenQingRiQi]=@ShenQingRiQi,[KeHuId]=@KeHuId ,[TaiTou]=@TaiTou,[JinE]=@JinE
		,[MingXi]=@XiangMuMingXi,[KaiJuDanWeiName]=@KaiJuDanWeiName,[FaPiaoHao]=@FaPiaoHao
		,[Status]=0
	WHERE [DengJiId]=@FaPiaoId
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @MxXml IS NOT NULL AND LEN(@MxXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@MxXml

		DELETE FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId AND [Status]=0 AND [Id] NOT IN(SELECT MxId FROM OPENXML(@hdoc,''/root/info'') WITH(MxId INT) AS A WHERE A.MxId>0)
		SET @errorcount=@errorcount+@@ERROR

		UPDATE [tbl_FinFaPiaoMx] SET [ChuTuanRiQi]=B.ChuTuanRiQi,[JinE]=B.JinE
		FROM [tbl_FinFaPiaoMx] AS A INNER JOIN (SELECT MxId,ChuTuanRiQi,JinE FROM OPENXML(@hdoc,''/root/info'') WITH(MxId INT,ChuTuanRiQi DATETIME,JinE MONEY)) AS B
		ON A.[Id]=B.[MxId] AND B.[MxId]>0
		SET @errorcount=@errorcount+@@ERROR

		INSERT INTO [tbl_FinFaPiaoMx]([DengJiId],[ChuTuanRiQi],[JinE],[Status])
		SELECT @FaPiaoId,A.ChuTuanRiQi,A.JinE,0
		FROM OPENXML(@hdoc,''/root/info'') 
		WITH(MxId INT,ChuTuanRiQi DATETIME,JinE MONEY) AS A
		WHERE A.MxId=0
		SET @errorcount=@errorcount+@@ERROR

		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND NOT EXISTS(SELECT 1 FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId AND [Status]=0 ))
	BEGIN
		UPDATE [tbl_FinFaPiao] SET [Status]=1 WHERE [DengJiId]=@FaPiaoId
	END

	IF(@errorcount=0)
	BEGIN
		UPDATE [tbl_FinFaPiao] SET [JinE]=ISNULL((SELECT SUM([JinE]) FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId),0) WHERE [DengJiId]=@FaPiaoId
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_FaPiao_UpdateMxs]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_FaPiao_UpdateMxs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-20
-- Description:�޸ķ�Ʊ��ϸ������1�ɹ�������ʧ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_FaPiao_UpdateMxs]
	 @FaPiaoId CHAR(36)--��Ʊ���
	,@MxXml NVARCHAR(MAX)--��Ʊ��ϸXML:<root><info MxId="" ChuTuanRiQi="" JinE="" Status="" FaSongTime="" FaSongFangShi="" YouJiGongSiName="" YouJiDanHao="" QianShouRenName="" QianShouTime="" /></root>
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinFaPiao] WHERE [DengJiId]=@FaPiaoId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	BEGIN TRAN	
	UPDATE [tbl_FinFaPiao] SET [Status]=0 WHERE [DengJiId]=@FaPiaoId

	IF(@errorcount=0 AND @MxXml IS NOT NULL AND LEN(@MxXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@MxXml

		UPDATE [tbl_FinFaPiaoMx] SET [Status]=B.[Status],[SongChuTime]=B.[FaSongTime],[SongChuFangShi]=B.[FaSongFangShi]
			,[YouJiGongSiName]=B.YouJiGongSiName,[YouJiDanHao]=B.YouJiDanHao,[QianShouRenName]=B.QianShouRenName
			,[QianShouTime]=B.QianShouTime
		FROM [tbl_FinFaPiaoMx] AS A INNER JOIN (SELECT * FROM OPENXML(@hdoc,''/root/info'') WITH(MxId INT,ChuTuanRiQi DATETIME,JinE MONEY,[Status] TINYINT,FaSongTime DATETIME,FaSongFangShi NVARCHAR(255),YouJiGongSiName NVARCHAR(255),YouJiDanHao NVARCHAR(255),QianShouRenName NVARCHAR(255),QianShouTime DATETIME)) AS B
		ON A.[Id]=B.[MxId] AND B.[MxId]>0
		SET @errorcount=@errorcount+@@ERROR

		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND NOT EXISTS(SELECT 1 FROM [tbl_FinFaPiaoMx] WHERE [DengJiId]=@FaPiaoId AND [Status]=0 ))
	BEGIN
		UPDATE [tbl_FinFaPiao] SET [Status]=1 WHERE [DengJiId]=@FaPiaoId
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkExchange_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkExchange_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--==================================
--��������-�����������
--�����ˣ�³��Դ
--ʱ�䣺2011-01-19
--==================================
CREATE procedure [dbo].[proc_WorkExchange_Update]
@ExchangeId int,
@CompanyId int,
@Type tinyint,
@Title nvarchar(255),
@Description nvarchar(max),
@OperatorId int,
@CreateTime datetime,
@IsAnonymous char(1),
@FilePath nvarchar(255),
@Result int output
as
begin 
	declare @error int
	set @error=0

	UPDATE tbl_WorkExchange
    SET [Type] = @Type,Title = @Title,Description = @Description, 
      IsAnonymous = @IsAnonymous,FilePath=@FilePath
    WHERE  ExchangeId=@ExchangeId
	set @error=@error+@@error
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
	   set @Result=0
	end
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WorkExchange_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_WorkExchange_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--==================================
--��������-�����������
--�����ˣ�³��Դ
--ʱ�䣺2011-01-19
--==================================
CREATE procedure [dbo].[proc_WorkExchange_Insert]
@CompanyId int,
@Type tinyint,
@Title nvarchar(255),
@Description nvarchar(max),
@OperatorId int,
@CreateTime datetime,
@IsAnonymous char(1),
@FilePath nvarchar(255),
@Result int output,
@ZxsId CHAR(36)
as
begin 
	declare @error int
	set @error=0

	INSERT INTO tbl_WorkExchange
           (CompanyId,[Type],Title,Description,OperatorId,CreateTime,IsAnonymous,FilePath,ZxsId)
     VALUES(@CompanyId,@Type,@Title,@Description,@OperatorId,@CreateTime,@IsAnonymous,@FilePath,@ZxsId)
	 set @error=@error+@@error
	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
	   set @Result=0
	end
	return @Result
end' 
END
GO
/****** Object:  View [dbo].[View_AttendanceInfo]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_AttendanceInfo]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[View_AttendanceInfo]
AS
SELECT     at.[id] AS [StaffNo],at.ArchiveNo, at.companyid, at.[DepartmentId], at.[UserName] AS [StaffName],at.IssueTime,					   
                          (SELECT     [Id], [DepartName]
                            FROM          tbl_CompanyDepartment b
                            WHERE      b.[id] IN ( SELECT [value] from dbo.fn_split(at.[DepartmentId],'','')) FOR XML Raw, Root(''Department'')) AS [DepartmentXML],
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo d
                            WHERE      d .[StaffNo] = at.[id] AND d .[WorkStatus] = 0 AND datediff(mm, GETDATE(), d .[AddDate]) = 0) AS Punctuality,
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo e
                            WHERE      e.[StaffNo] = at.[id] AND e.[WorkStatus] = 1 AND datediff(mm, GETDATE(), e.[AddDate]) = 0) AS Late,
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo f
                            WHERE      f.[StaffNo] = at.[id] AND f.[WorkStatus] = 2 AND datediff(mm, GETDATE(), f.[AddDate]) = 0) AS LeaveEarly,
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo g
                            WHERE      g.[StaffNo] = at.[id] AND g.[WorkStatus] = 3 AND datediff(mm, GETDATE(), g.[AddDate]) = 0) AS Absenteeism,
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo h
                            WHERE      h.[StaffNo] = at.[id] AND h.[WorkStatus] = 4 AND datediff(mm, GETDATE(), h.[AddDate]) = 0) AS Vacation,
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo j
                            WHERE      j.[StaffNo] = at.[id] AND j.[WorkStatus] = 5 AND datediff(mm, GETDATE(), j.[AddDate]) = 0) AS Out,
                          (SELECT     Count(1)
                            FROM          tbl_AttendanceInfo k
                            WHERE      k.[StaffNo] = at.[id] AND k.[WorkStatus] = 6 AND datediff(mm, GETDATE(), k.[AddDate]) = 0) AS [Group],
                          (SELECT     SUM(OutTime)
                            FROM          tbl_AttendanceInfo l
                            WHERE      l.[StaffNo] = at.[id] AND l.[WorkStatus] = 7 AND datediff(mm, GETDATE(), l.[AddDate]) = 0) AS AskLeave,
                          (SELECT     SUM(OutTime)
                            FROM          tbl_AttendanceInfo m
                            WHERE      m.[StaffNo] = at.[id] AND m.[WorkStatus] = 8 AND datediff(mm, GETDATE(), m.[AddDate]) = 0) AS OverTime
FROM         [tbl_PersonnelInfo] AS at
WHERE     at.[IsLeave] = 0
'
GO
/****** Object:  StoredProcedure [dbo].[proc_AttendanceInfo_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_AttendanceInfo_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:luofx
-- Create date: 2011-01-18
-- Description:	��������:��Ҫ����Ӱࣨ��٣�ʱ�䳬������ʱ��ÿ�����һ�����ݵ����
-- =============================================
CREATE PROCEDURE [dbo].[proc_AttendanceInfo_Insert] 
	  @AttendanceInfoXML NVARCHAR(MAX), --����XML��Ϣ��<ROOT><AttendanceInfo CompanyId="" AddDate="" OperatorId="" BeginDate="" EndDate="" OutTime="" Reason="" StaffNo="" WorkStatus="" /></ROOT>
	  @Result INT OUTPUT                -- ���ز���	
AS
BEGIN
DECLARE @MAXID INT              --�ݴ����id
DECLARE @ErrorCount INT         --��֤����
DECLARE @hdoc INT               --XMLʹ�ò���
DECLARE @i CHAR(36)		        --����
DECLARE @Days INT               --��٣��Ӱࣩʱ�������������ѭ�������������
DECLARE @DayCont INT            --��٣��Ӱࣩʱ��������ֻ�е�һ���ᱣ����ٵ�����
DECLARE @CompanyId INT          --��˾���	
DECLARE @AddDate DATETIME       --����ʱ��
DECLARE @OperatorId INT         --�����˱��
DECLARE @BeginDate DATETIME     --��٣��Ӱࣩ��ʼʱ��
DECLARE @EndDate DATETIME       --��٣��Ӱࣩ����ʱ��
DECLARE @OutTime DECIMAL(10,4)  --��٣��Ӱࣩʱ��
DECLARE @Reason NVARCHAR(1000)  --ԭ��
DECLARE @StaffNo INT            --Ա�����
DECLARE @WorkStatus INT         --����״��
SET @i=1
--ʹ�ñ�����ݴ�XML��Ϣ
	CREATE Table #tmpAttendanceInfoTbl(
		Vid INT ,              --��ʶID
		CompanyId INT,         --��˾���	
		AddDate DATETIME,      --����ʱ��
		OperatorId INT,        --�����˱��
		BeginDate DATETIME,    --��٣��Ӱࣩ��ʼʱ��
		EndDate DATETIME,      --��٣��Ӱࣩ����ʱ��
		OutTime DECIMAL(10,4),       --��٣��Ӱࣩʱ��
		Reason NVARCHAR(1000), --ԭ��
		StaffNo INT,           --Ա�����
		WorkStatus INT         --����״��
	)    
BEGIN Transaction AttendanceInfo_Insert 
	--����XML���ݣ������뵽�ݴ��
    EXEC sp_xml_preparedocument @hdoc OUTPUT, @AttendanceInfoXML	
		INSERT INTO #tmpAttendanceInfoTbl([Vid],[CompanyId],AddDate,OperatorId,
						BeginDate,EndDate,OutTime,Reason,StaffNo,WorkStatus)
				SELECT row_number() OVER(ORDER BY CompanyId DESC) AS [row_id],[CompanyId],[AddDate],
					[OperatorId],[BeginDate],[EndDate],[OutTime],[Reason],[StaffNo],[WorkStatus]
					FROM OPENXML(@hdoc,N''/ROOT/AttendanceInfo'') 
						WITH(CompanyId INT,AddDate DATETIME,OperatorId INT,BeginDate DATETIME,
						EndDate DATETIME,[OutTime] DECIMAL(10,4),Reason NVARCHAR(1000),StaffNo INT,WorkStatus INT)																
	EXEC sp_xml_removedocument @hdoc 
    SELECT @MAXID=MAX(Vid) FROM #tmpAttendanceInfoTbl
    WHILE(@i<=@MAXID)
		BEGIN
			SELECT @CompanyId=CompanyId,@AddDate=AddDate,@OperatorId=OperatorId,@BeginDate=BeginDate,
				@EndDate=EndDate,@OutTime=OutTime,@Reason=Reason,@StaffNo=StaffNo,@WorkStatus=WorkStatus FROM #tmpAttendanceInfoTbl WHERE [Vid]=@i			
			IF(@WorkStatus=7 OR @WorkStatus=8)--���(�Ӱ�)ʱ
				BEGIN
					SET @Days=DATEDIFF(DAY,@BeginDate,@EndDate) --���������
					SET @DayCont=0	
					WHILE(@Days>=0)
						BEGIN
							IF(@DayCont>0 AND (@WorkStatus=7 OR @WorkStatus=8)) --���(�Ӱ�)ʱ���ҿ���
								SET @OutTime=0
							--���뿼����Ϣ
							INSERT INTO tbl_AttendanceInfo([id],CompanyId,StaffNo,OperatorId,WorkStatus,AddDate,Reason,BeginDate,EndDate,OutTime)
										VALUES(newid(),@CompanyId,@StaffNo,@OperatorId,@WorkStatus,
											DATEADD(DAY,@DayCont,@BeginDate),@Reason,@BeginDate,@EndDate,@OutTime)
							SET @Result=@Result+1
							SET @Days=@Days-1
							SET @DayCont=@DayCont+1
							IF(@@ERROR>0)
								BEGIN
									SET @ErrorCount=@ErrorCount+1
								END
						END							
				END
			ELSE	--�����ʱ
				BEGIN
					--���뿼����Ϣ
					INSERT INTO tbl_AttendanceInfo([id],CompanyId,StaffNo,OperatorId,WorkStatus,AddDate,Reason)
							VALUES(newid(),@CompanyId,@StaffNo,@OperatorId,@WorkStatus,@AddDate,@Reason)
					SET @Result=@Result+1
					IF(@@ERROR>0)
						BEGIN
							SET @ErrorCount=@ErrorCount+1
						END
				END
			SET @i=@i+1
		END
    --�Ƿ�ع�
	IF(@ErrorCount>0)
		BEGIN
			SET @Result=0
			ROLLBACK TRANSACTION AttendanceInfo_Insert
		END
	COMMIT TRANSACTION AttendanceInfo_Insert
	SET @Result=1
	DROP TABLE #tmpAttendanceInfoTbl
    RETURN @Result
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_AttendanceInfo_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_AttendanceInfo_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:luofx
-- Create date: 2011-01-18
-- Description:	�����޸�:��Ҫ����Ӱࣨ��٣�ʱ�䳬������ʱ��ÿ�����һ�����ݵ����
-- =============================================
CREATE PROCEDURE [dbo].[proc_AttendanceInfo_Update] 
	  @CompanyId INT,                --��˾���
	  @AddDate DATETIME,                --����ʱ��
	  @AttendanceInfoXML NVARCHAR(MAX), --����XML��Ϣ��<ROOT><AttendanceInfo CompanyId="" AddDate="" OperatorId="" BeginDate="" EndDate="" OutTime="" Reason="" StaffNo="" WorkStatus="" /></ROOT>
	  @Result INT OUTPUT                -- ���ز���	
AS
BEGIN
DECLARE @MAXID INT              --�ݴ����id
DECLARE @ErrorCount INT         --��֤����
DECLARE @hdoc INT               --XMLʹ�ò���
DECLARE @i CHAR(36)		        --����
DECLARE @Days INT               --��٣��Ӱࣩʱ�������������ѭ�������������
DECLARE @DayCont INT            --��٣��Ӱࣩʱ��������ֻ�е�һ���ᱣ����ٵ�����
DECLARE @TmpAddDate DATETIME       --����ʱ��
DECLARE @OperatorId INT         --�����˱��
DECLARE @BeginDate DATETIME     --��٣��Ӱࣩ��ʼʱ��
DECLARE @EndDate DATETIME       --��٣��Ӱࣩ����ʱ��
DECLARE @OutTime DECIMAL(10,4)  --��٣��Ӱࣩʱ��
DECLARE @Reason NVARCHAR(1000)  --ԭ��
DECLARE @StaffNo INT            --Ա�����
DECLARE @WorkStatus INT         --����״��
SET @i=1
--ʹ�ñ�����ݴ�XML��Ϣ
	CREATE Table #tmpAttendanceInfoTbl(
		Vid INT ,              --��ʶID
		CompanyId INT,         --��˾���	
		AddDate DATETIME,      --����ʱ��
		OperatorId INT,        --�����˱��
		BeginDate DATETIME,    --��٣��Ӱࣩ��ʼʱ��
		EndDate DATETIME,      --��٣��Ӱࣩ����ʱ��
		OutTime DECIMAL(10,4),       --��٣��Ӱࣩʱ��
		Reason NVARCHAR(1000), --ԭ��
		StaffNo INT,           --Ա�����
		WorkStatus INT         --����״��
	)    
BEGIN Transaction AttendanceInfo_Insert 
	--����XML���ݣ������뵽�ݴ��
    EXEC sp_xml_preparedocument @hdoc OUTPUT, @AttendanceInfoXML	
		INSERT INTO #tmpAttendanceInfoTbl([Vid],[CompanyId],AddDate,OperatorId,
						BeginDate,EndDate,OutTime,Reason,StaffNo,WorkStatus)
				SELECT row_number() OVER(ORDER BY CompanyId DESC) AS [row_id],[CompanyId],[AddDate],
					[OperatorId],[BeginDate],[EndDate],[OutTime],[Reason],[StaffNo],[WorkStatus]
					FROM OPENXML(@hdoc,N''/ROOT/AttendanceInfo'') 
						WITH(CompanyId INT,AddDate DATETIME,OperatorId INT,BeginDate DATETIME,
						EndDate DATETIME,[OutTime] DECIMAL(10,4),Reason NVARCHAR(1000),StaffNo INT,WorkStatus INT)																
	EXEC sp_xml_removedocument @hdoc 
	SET @ErrorCount=@ErrorCount+@@ERROR
    SELECT @MAXID=MAX(Vid) FROM #tmpAttendanceInfoTbl
	DELETE FROM tbl_AttendanceInfo WHERE (DATEDIFF(DAY,AddDate,@AddDate)=0 OR EXISTS(SELECT 1 FROM #tmpAttendanceInfoTbl WHERE tbl_AttendanceInfo.AddDate BETWEEN BeginDate AND EndDate)) AND CompanyId=@CompanyId AND StaffNo IN (SELECT StaffNo FROM #tmpAttendanceInfoTbl)
	SET @ErrorCount=@ErrorCount+@@ERROR
    WHILE(@i<=@MAXID)
		BEGIN
			SELECT @TmpAddDate=AddDate,@OperatorId=OperatorId,@BeginDate=BeginDate,
				@EndDate=EndDate,@OutTime=OutTime,@Reason=Reason,@StaffNo=StaffNo,@WorkStatus=WorkStatus FROM #tmpAttendanceInfoTbl WHERE [Vid]=@i			
			IF(@WorkStatus=7 OR @WorkStatus=8)--���(�Ӱ�)ʱ
				BEGIN
					SET @Days=DATEDIFF(DAY,@BeginDate,@EndDate) --���������
					SET @DayCont=0	
					WHILE(@Days>=0)
						BEGIN
							IF(@DayCont>0 AND (@WorkStatus=7 OR @WorkStatus=8)) --���(�Ӱ�)ʱ���ҿ���
								SET @OutTime=0
							--���뿼����Ϣ
							INSERT INTO tbl_AttendanceInfo([id],CompanyId,StaffNo,OperatorId,WorkStatus,AddDate,Reason,BeginDate,EndDate,OutTime)
										VALUES(newid(),@CompanyId,@StaffNo,@OperatorId,@WorkStatus,
											DATEADD(DAY,@DayCont,@BeginDate),@Reason,@BeginDate,@EndDate,@OutTime)
							SET @ErrorCount=@ErrorCount+@@ERROR
							SET @Result=@Result+1
							SET @Days=@Days-1
							SET @DayCont=@DayCont+1
						END							
				END
			ELSE	--�����ʱ
				BEGIN
					--���뿼����Ϣ
					INSERT INTO tbl_AttendanceInfo([id],CompanyId,StaffNo,OperatorId,WorkStatus,AddDate,Reason)
							VALUES(newid(),@CompanyId,@StaffNo,@OperatorId,@WorkStatus,@TmpAddDate,@Reason)
					SET @Result=@Result+1
					SET @ErrorCount=@ErrorCount+@@ERROR
				END
			SET @i=@i+1
		END
    --�Ƿ�ع�
	IF(@ErrorCount>0)
		BEGIN
			SET @Result=0
			ROLLBACK TRANSACTION AttendanceInfo_Insert
		END
	COMMIT TRANSACTION AttendanceInfo_Insert
	SET @Result=1
	DROP TABLE #tmpAttendanceInfoTbl
    RETURN @Result
END

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Pt_CreateJiFenShangPinBianMa]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Pt_CreateJiFenShangPinBianMa]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	���ɻ�����Ʒ����
-- =============================================
CREATE FUNCTION [dbo].[fn_Pt_CreateJiFenShangPinBianMa]
(
	@CompanyId INT
)
RETURNS NVARCHAR(255)
AS
BEGIN
	DECLARE @BianHao NVARCHAR(255)
	DECLARE @ShuLiang INT
	SELECT @ShuLiang=COUNT(*) FROM tbl_Pt_JiFenShangPin WHERE CompanyId=@CompanyId
	SET @ShuLiang=@ShuLiang+1
	SET @BianHao=''JFSP''+dbo.fn_PadLeft(@ShuLiang,''0'',5)	
	RETURN @BianHao
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenShangPin_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenShangPin_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	������Ʒɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenShangPin_D]
	@ShangPinId CHAR(36) 
	,@CompanyId INT
	,@OperatorId INT
	,@IssueTime DATETIME
	,@RetCode INT OUTPUT
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_JiFenShangPin WHERE ShangPinId=@ShangPinId AND CompanyId=@CompanyId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_JiFenDingDan WHERE ShangPinId=@ShangPinId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	UPDATE tbl_Pt_JiFenShangPin SET IsDelete=''1'' WHERE ShangPinId=@ShangPinId
	
	SET @RetCode=1	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-18
-- Description:	���ֽ���-�տ�����״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_SheZhiStatus]
	@JieSuanId char(36)
	,@ZxsId char(36)
	,@CompanyId int
	,@Status TINYINT
	,@OperatorId INT
	,@IssueTime DATETIME
	,@BeiZhu NVARCHAR(255)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @YuanStatus TINYINT
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId AND ZxsId=@ZxsId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END	
	
	SELECT @YuanStatus=[Status] FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
	
	IF(@YuanStatus=0 AND @Status=1)--����
	BEGIN
		UPDATE tbl_Pt_FinJiFenJieSuan SET ShenPiRenId=@OperatorId,ShenPiBeiZhu=@BeiZhu,ShenPiShiJian=@IssueTime,[Status]=@Status WHERE JieSuanId=@JieSuanId
	END
	
	IF(@YuanStatus=1 AND @Status=0)--ȡ������
	BEGIN
		UPDATE tbl_Pt_FinJiFenJieSuan SET [Status]=@Status WHERE JieSuanId=@JieSuanId
	END
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-18
-- Description:	���ֽ���-�տ�ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_D]
	@JieSuanId char(36)
	,@ZxsId char(36)
	,@CompanyId int
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId AND ZxsId=@ZxsId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END	
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId AND Status=0)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	DELETE FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-18
-- Description:	���ֽ���-�տ�Ǽǡ��޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenJieSuanShouKuan_CU]
	@JieSuanId char(36)
	,@ZxsId char(36)
	,@CompanyId int
	,@JieSuanRiQi datetime
	,@JieSuanRenName nvarchar(255)
	,@JiFen int
	,@JinE money
	,@JieSuanFangShi tinyint
	,@JieSuanZhangHao nvarchar(255)
	,@JieSuanBeiZhu nvarchar(255)
	,@Status tinyint
	,@OperatorId int
	,@IssueTime datetime
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @YuanStatus TINYINT
	
	DECLARE @FS CHAR(1)
	SET @FS=''C''
		
	IF EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId)
	BEGIN
		SET @FS=''U''
	END
	
	IF(@FS=''U'')
	BEGIN
		SELECT @YuanStatus=[Status] FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
		IF(@YuanStatus<>0)
		BEGIN
			SET @RetCode=-99
			RETURN @RetCode
		END
	END
	
	IF(@FS=''C'')
	BEGIN
		INSERT INTO [tbl_Pt_FinJiFenJieSuan]([JieSuanId],[ZxsId],[CompanyId]
			,[JieSuanRiQi],[JieSuanRenName],[JiFen]
			,[JinE],[JieSuanFangShi],[JieSuanZhangHao]
			,[JieSuanBeiZhu],[Status],[OperatorId]
			,[IssueTime],[ShenPiRenId],[ShenPiBeiZhu]
			,[ShenPiShiJian])
		VALUES(@JieSuanId,@ZxsId,@CompanyId
			,@JieSuanRiQi,@JieSuanRenName,@JiFen
			,@JinE,@JieSuanFangShi,@JieSuanZhangHao
			,@JieSuanBeiZhu,@Status,@OperatorId
			,@IssueTime,NULL,NULL
			,NULL)
	END
	
	IF(@FS=''U'')
	BEGIN
		UPDATE [tbl_Pt_FinJiFenJieSuan] SET [JieSuanRiQi]=@JieSuanRiQi
			,[JieSuanRenName]=@JieSuanRenName,[JiFen]=@JiFen
			,[JinE]=@JinE,[JieSuanFangShi]=@JieSuanFangShi
			,[JieSuanZhangHao]=@JieSuanZhangHao,[JieSuanBeiZhu]=@JieSuanBeiZhu
		WHERE [JieSuanId]=@JieSuanId
	END
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	ר���̻��ֽ���ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_D]
	@JieSuanId char(36)
	,@ZxsId char(36)
	,@CompanyId int
	,@OperatorId int
	,@IssueTime datetime
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @YuanStatus TINYINT
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @YuanStatus=[Status] FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
	IF(@YuanStatus<>0)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	DELETE FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	ר���̻��ֽ���ɾ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_SheZhiStatus]
	@JieSuanId char(36)
	,@ZxsId char(36)
	,@CompanyId int
	,@Status TINYINT
	,@OperatorId int
	,@BeiZhu NVARCHAR(255)
	,@IssueTime datetime
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @YuanStatus TINYINT
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @YuanStatus=[Status] FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
	
	IF(@YuanStatus=0 AND @Status=1)--����
	BEGIN
		UPDATE tbl_Pt_FinJiFenJieSuan SET [Status]=@Status,ShenPiRenId=@OperatorId,ShenPiBeiZhu=@BeiZhu, ShenPiShiJian=@IssueTime WHERE JieSuanId=@JieSuanId
		SET @RetCode=1	
	END
	
	IF(@YuanStatus=0 AND @Status=0)--ȡ������
	BEGIN
		UPDATE tbl_Pt_FinJiFenJieSuan SET [Status]=@Status,ShenPiRenId=@OperatorId,ShenPiBeiZhu=@BeiZhu, ShenPiShiJian=@IssueTime WHERE JieSuanId=@JieSuanId
		SET @RetCode=1	
	END	
	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	ר���̻��ֽ����������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_JiFenJieSuan_CU]
	@JieSuanId char(36)
	,@ZxsId char(36)
	,@CompanyId int
	,@JieSuanRiQi datetime
	,@JieSuanRenName nvarchar(255)
	,@JiFen int
	,@JinE money
	,@JieSuanFangShi tinyint
	,@JieSuanZhangHao nvarchar(255)
	,@JieSuanBeiZhu nvarchar(255)
	,@Status tinyint
	,@OperatorId int
	,@IssueTime datetime
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @FS NVARCHAR(50)
	DECLARE @YuanStatus TINYINT
	SET @FS=''INSERT''
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId)
	BEGIN
		SET @FS=''UPDATE''
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		SELECT @YuanStatus=[Status] FROM tbl_Pt_FinJiFenJieSuan WHERE JieSuanId=@JieSuanId
		
		IF(@YuanStatus<>0)
		BEGIN
			SET @RetCode=-99
			RETURN @RetCode
		END
	END
	
	IF(@FS=''INSERT'')
	BEGIN
		INSERT INTO [tbl_Pt_FinJiFenJieSuan]([JieSuanId],[ZxsId],[CompanyId]
			,[JieSuanRiQi],[JieSuanRenName],[JiFen]
			,[JinE],[JieSuanFangShi],[JieSuanZhangHao]
			,[JieSuanBeiZhu],[Status],[OperatorId]
			,[IssueTime],[ShenPiRenId],[ShenPiBeiZhu]
			,[ShenPiShiJian])
		VALUES(@JieSuanId,@ZxsId,@CompanyId
			,@JieSuanRiQi,@JieSuanRenName,@JiFen
			,@JinE,@JieSuanFangShi,@JieSuanZhangHao
			,@JieSuanBeiZhu,@Status,@OperatorId
			,@IssueTime,NULL,NULL
			,NULL)
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		UPDATE [tbl_Pt_FinJiFenJieSuan] SET [JieSuanRiQi]=@JieSuanRiQi,[JieSuanRenName]=@JieSuanRenName
			,[JiFen]=@JiFen,[JinE]=@JinE
			,[JieSuanFangShi]=@JieSuanFangShi,[JieSuanZhangHao]=@JieSuanZhangHao
			,[JieSuanBeiZhu]=@JieSuanBeiZhu
		WHERE [JieSuanId]=@JieSuanId
	END	
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_HotelJiaoYiHao]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_HotelJiaoYiHao]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<����>
-- Create date: <2012-12-10>
-- Description:	<���ɿؾƵ갲�ŵĽ��׺�>
-- Result :��λ��+D+��λ������ˮ�Ľ��׺š�
-- =============================================
CREATE function [dbo].[fn_HotelJiaoYiHao]
(
	@TourId char(36)
)
RETURNS varchar(200)
begin
	declare @KongWeiCode nvarchar(100)
	select @KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@TourId
	
	declare @index int
	select  @index=isnull(count(*),0)+1 from tbl_TourOrderHotelPlan where TourId=@TourId
	
	
	declare @JiaoYiHao nvarchar(100)
	if(@index>=1 and @index<=9)
	begin
		set @JiaoYiHao= @KongWeiCode+''D''+''0''+cast(@index as varchar(10))
	end
	else
	begin
		set @JiaoYiHao= @KongWeiCode+''D''+cast(@index as varchar(10))
	end

	return (@JiaoYiHao)
end






' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TourCode]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_TourCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2011-11-23>
-- Description:	<���ɵؽӽ��׺ţ��źţ�>
--Result:ϵͳ����λ��+��дӢ����ĸ�����źţ���������ĸ��ʾ��Χʱ��
--       �ÿ�λ��+DJ+��λ������ˮ��
-- =============================================
create function [dbo].[fn_TourCode]
(
	@KongWeiId char(36)
)
returns nvarchar(100)
begin
--	create table #temp 
--	(Id int IDENTITY, value varchar(10))
	
	declare @TourCode nvarchar(100)
	
	declare @Code varchar(100)
	set @Code=''A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z''

--	while(charindex('','',@Code)<>0)
--	begin
--		--���ַ��ָ� ��ӵ���ʱ��
--		insert into #temp values (substring(@Code,1,charindex('','',@Code)-1))
--		set @Code=stuff(@Code,1,charindex('','',@Code),'''')  
--	end
	--ȡ�ÿ�λ��
	declare @KongWeiCode nvarchar(100)
	select @KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@KongWeiId

	--�ؽӰ����˶��ٵ�
	declare @dijiecount int
	select @dijiecount=count(1)+1 from tbl_PlanDiJie where KongWeiId=@KongWeiId
	
	declare @c nvarchar(10)
	select @c=[value] from dbo.fn_split(@Code,'','') where Id=@dijiecount
	if(len(@c)>0)
	begin
		set @TourCode=@KongWeiCode+@c
	end
	else
	begin	
		if(@dijiecount-26>=1 and @dijiecount-26<=9)
		begin
			set @TourCode=@KongWeiCode+''DJ0''+cast(@dijiecount as nvarchar(10))
		end
		else
		begin
			set @TourCode=@KongWeiCode+''DJ''+cast(@dijiecount as nvarchar(10))
		end
	end

	return @TourCode
	
	
end


' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	����ר����״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiStatus]
	@ZxsId char(36)
	,@Status TINYINT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	UPDATE tbl_Pt_ZhuanXianShang SET [Status]=@Status WHERE ZxsId=@ZxsId
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	����ר���̻��ַ���״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiJiFenStatus]
	@ZxsId char(36)
	,@JiFenStatus TINYINT
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	UPDATE tbl_Pt_ZhuanXianShang SET [JiFenStatus]=@JiFenStatus WHERE ZxsId=@ZxsId
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-08
-- Description:	����ר����Ȩ��
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_ZhuanXianShang_SheZhiPrivs]
	@ZxsId char(36)
	,@Privs1 NVARCHAR(MAX)
	,@Privs2 NVARCHAR(MAX)
	,@Privs3 NVARCHAR(MAX)
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	DECLARE @RoleId INT
	DECLARE @UserId INT
	DECLARE @T1 TINYINT
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_ZhuanXianShang WHERE ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @RoleId=Id FROM tbl_SysRoleManage WHERE ZxsId=@ZxsId AND RoleName=''����Ա''
	SELECT @UserId=Id FROM tbl_CompanyUser WHERE ZxsId=@ZxsId AND IsAdmin=''1''
	SELECT @T1=T1 FROM tbl_Pt_ZhuanXianShang WHERE ZxsId=@ZxsId
	
	IF(@T1=1)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	UPDATE tbl_Pt_ZhuanXianShang SET [Privs1]=@Privs1,[Privs2]=@Privs2,[Privs3]=@Privs3 WHERE ZxsId=@ZxsId
	UPDATE tbl_SysRoleManage SET RoleChilds=@Privs3 WHERE Id=@RoleId
	UPDATE tbl_CompanyUser SET PermissionList=@Privs3 WHERE Id=@UserId
	
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ValidUserLevDepartManagers]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_ValidUserLevDepartManagers]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		³��Դ
-- Create date: 2011-02-16
-- Description:	��֤��ǰ��¼�û��Ƿ���Ȩ�޲鿴�����ƻ�[�����˵�ͬ���ŵ����ܻ����ϼ����ŵ����ܲ��ܲ鿴]
-- History:
-- 2011-06-10 ���ĵݹ���ʽ
-- =============================================
CREATE FUNCTION [dbo].[fn_ValidUserLevDepartManagers]
(	
	@CurrUserId int, --��ǰ��¼�˱��
	@OperatorId int --�����ƻ������˱��
)
RETURNS INT
AS
begin
	DECLARE @Result int --�ش�����
	DECLARE @OperatorDepartID int--�����ƻ����������ڲ���
	SET @Result=0
	SET @OperatorDepartID=0
	
	SELECT @OperatorDepartID=DepartId from tbl_CompanyUser where ID=@OperatorId

	if @OperatorDepartID is null or @OperatorDepartID < 0	
	BEGIN
		RETURN @Result
	END

	ELSE
	BEGIN
		WITH SubsCTE
		AS
		(
		  -- Anchor member returns root node
		  SELECT PrevDepartId,DepartManger, 0 AS lvl ,id
		  FROM dbo.tbl_CompanyDepartment
		  WHERE id = @OperatorDepartID

		  UNION ALL

		  -- Recursive member returns next level of children
		  SELECT C.PrevDepartId, C.DepartManger, P.lvl + 1,c.id
		  FROM SubsCTE AS P
			JOIN dbo.tbl_CompanyDepartment AS C
			  ON C.id = P.PrevDepartId
		)
		select @Result=count(*) from SubsCTE where DepartManger=@CurrUserId
	END
	RETURN @Result	
END

' 
END
GO
/****** Object:  View [dbo].[view_News]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_News]'))
EXEC dbo.sp_executesql @statement = N'
CREATE view [dbo].[view_News]
as
SELECT   a.ID, a.CompanyId, a.Title, a.Views, a.OperatorId, a.IssueTime, 
b.[NewId], b.AcceptType, b.AcceptId, a.IsDelete,
(select ContactName from tbl_CompanyUser where tbl_CompanyUser.Id = a.OperatorId) as OperatorName 
FROM tbl_News AS a INNER JOIN tbl_NewsAccept AS b ON a.ID = b.[NewId]
'
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TourOrderHotelCode]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_TourOrderHotelCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<����>
-- Create date: <2012-11-21>
-- Description:	<���ɾƵ�Ԥ���Ľ��׺�>
-- Result :ÿһ����Ӧ�̰������ɿ�λ��+D+��λ������ˮ�Ľ��׺š�
-- =============================================
CREATE function [dbo].[fn_TourOrderHotelCode](
	@TourId char(36),
	@xml xml
)
RETURNS @tempTable TABLE (Id char(36),JiaoYiHao nvarchar(100))
begin
	--Select CONVERT(varchar(100), @LDate, 112)
	declare @KongWeiCode nvarchar(100)
	select @KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@TourId
	
	declare @index int
	select  @index=count(1)+1 from tbl_TourOrderHotelPlan where TourId=@TourId

	declare @idoc int
	exec sp_xml_preparedocument @idoc output,@xml
	
	declare @count int
	select @count=count(1)  from openxml(@idoc,''/Root/TourOrderHotelPlan'') 
	with(Id char(36),JiaoYiHao nvarchar(100)) where len(JiaoYiHao)<=0
	
	declare @i  int
	set @i=1
	while(@i<=@count)
	begin
		declare @Id nvarchar(200)
		set @Id=@xml.value(''(Root/TourOrderHotelPlan[sql:variable("@i")]/@Id)[1]'',''nvarchar(200)'')
		
		declare @JiaoYiHao nvarchar(100)
		if(@index>=1 and @index<=9)
		begin
			set @JiaoYiHao= @KongWeiCode+''D''+''0''+cast(@index as varchar(10))
		end
		else
		begin
			set @JiaoYiHao= @KongWeiCode+''D''+cast(@index as varchar(10))
		end
		insert into @tempTable(Id,JiaoYiHao) values(@Id,@JiaoYiHao)
		--set @xml.modify(''replace value of (Root/row[sql:variable("@i")]/@JiaoYiHao)[1] with @JiaoYiHao'')
		set @index=@index+1
		set @i=@i+1
	end
	exec sp_xml_removedocument @idoc
	return 
end


' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_UpdateStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_UpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-12-7>
-- Description:	<�޸Ŀ�λ�տ�״̬>
-- =============================================
CREATE proc [dbo].[proc_KongWei_UpdateStatus]
	@KongWeiId char(36)--��λ���
	,@Status tinyint
	,@Result int output
AS
BEGIN
	UPDATE tbl_KongWei SET [Status]=@Status
	WHERE KongWeiId=@KongWeiId AND [Status]<>2
		
	SET @Result=2
	RETURN @Result
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_PiaoCode]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_PiaoCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<����>
-- Create date: <2012-11-23>
-- Description:	<��Ʊ���ɽ��׺�>
-- Result ����Ʊϵͳ�Զ����ɽ��ױ�ţ���λ��+JP+��λ��ˮ�ţ���	
-- =============================================
create function [dbo].[fn_PiaoCode]
(
	@KongWeiId char(36)
)
returns nvarchar(100)
begin
	declare @PiaoCode nvarchar(100)
	
	declare @KongWeiCode nvarchar(100)
	select @KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@KongWeiId

	declare @index int
	select @index=count(1)+1 from tbl_PlanChuPiao where KongWeiId=@KongWeiId
	
	if(@index>=1 and @index<=9)
	begin
		set @PiaoCode=@KongWeiCode+''JP0''+cast(@index as nvarchar(10))
	end
	else
	begin
		set @PiaoCode=@KongWeiCode+''JP''+cast(@index as nvarchar(10))
	end

	return @PiaoCode
end


' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_KongWeiCode]    Script Date: 09/29/2014 16:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_KongWeiCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-21>
-- Description:	<���ɿ�λ��>
-- Result :ϵͳ���ݳ��������Զ����ɿ�λ�ţ���λ�Ű���������+��λ������ˮ����
-- =============================================
CREATE function [dbo].[fn_KongWeiCode](
	@LDate datetime
	,@CompanyId int
	,@ZxsId CHAR(36)
)
RETURNS varchar(200)
begin
	--Select CONVERT(varchar(100), @LDate, 112)

	declare @code nvarchar(200)
	declare @index int
	select @index=count(1)+1 from tbl_KongWei  where CompanyId=@CompanyId and QuDate=@LDate  AND ZxsId=@ZxsId
	if(@index>=1 and @index<=9)
	begin
		set @code= CONVERT(varchar(100), @LDate, 112)+''0''+cast(@index as varchar(10))
	end
	else
	begin
		set @code=CONVERT(varchar(100), @LDate, 112)+cast(@index as varchar(10))
	end
	
	return (@code)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SQLPlan_Tour]    Script Date: 09/29/2014 16:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLPlan_Tour]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:����
-- Create date: 2012-12-11
-- Description��ά���Ŷӳ���״̬
-- =============================================
CREATE proc [dbo].[SQLPlan_Tour]
as
begin
	--����Ŷ��ѳ���״̬
	UPDATE tbl_KongWei SET IsChuTuan=''1'' WHERE  IsChuTuan=''0'' AND DATEDIFF(DAY,GETDATE(),QuDate)<=0 
	--�����·�Զ�����
	UPDATE tbl_Route SET [Status]=1 WHERE [Status]=0 AND GuoQiShiJian IS NOT NULL AND GuoQiShiJian<=GETDATE()
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_YongHu_JiFen_Handler]    Script Date: 09/29/2014 16:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_YongHu_JiFen_Handler]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-05
-- Description:	�û����ִ���
-- =============================================
CREATE PROCEDURE [dbo].[proc_YongHu_JiFen_Handler]
	@YongHuId INT--�û����,
	,@KeHuLxrId INT--�ͻ���ϵ�˱��
	,@RetCode INT OUTPUT
AS
BEGIN
	SET @RetCode=0
	
	IF((@YongHuId=0 OR @YongHuId IS NULL) AND (@KeHuLxrId=0 OR @KeHuLxrId IS NULL))
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	IF(@YongHuId=0 OR @YongHuId IS NULL)
	BEGIN
		SELECT @YongHuId=Id FROM tbl_CompanyUser WHERE KeHuLxrId=@KeHuLxrId
	END
	
	IF(@YongHuId=0 OR @YongHuId IS NULL)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	DECLARE @JiFen1 INT --�ۻ�����-����
	DECLARE @JiFen2 INT --�ۻ�����-����
	DECLARE @JiFen3 INT --���ѻ���-��ʹ��
	DECLARE @JiFen4 INT --���ѻ���-����
	
	DECLARE @KeYongJiFen INT
	DECLARE @DongJieJiFen INT
	
	SELECT @JiFen1=ISNULL(SUM(JiFen),0) FROM tbl_Pt_YongHuJiFenMingXi WHERE YongHuId=@YongHuId AND Status=1 AND GuanLianLeiXing=0
	SELECT @JiFen2=ISNULL(SUM(JiFen),0) FROM tbl_Pt_YongHuJiFenMingXi WHERE YongHuId=@YongHuId AND Status=0 AND GuanLianLeiXing=0

	SELECT @JiFen3=ISNULL(SUM(JiFen),0) FROM tbl_Pt_YongHuJiFenMingXi WHERE YongHuId=@YongHuId AND Status=1 AND GuanLianLeiXing=1
	SELECT @JiFen4=ISNULL(SUM(JiFen),0) FROM tbl_Pt_YongHuJiFenMingXi WHERE YongHuId=@YongHuId AND Status=0 AND GuanLianLeiXing=1	

	SET @KeYongJiFen=@JiFen1-@JiFen3-@JiFen4
	SET @DongJieJiFen=@JiFen2+@JiFen4
	
	UPDATE tbl_CompanyUser SET KeYongJiFen=@KeYongJiFen,DongJieJiFen=@DongJieJiFen WHERE Id=@YongHuId
		
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	���û��ֶ�������״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenDingDan_SheZhiFuKuanStatus]
	@DingDanId CHAR(36)
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@OperatorBeiZhu NVARCHAR(255)--������ע
	,@FuKuanStatus TINYINT
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @YuanFuKuanStatus TINYINT
	DECLARE @YuanDingDanStatus TINYINT
	DECLARE @MS NVARCHAR(255)
	SET @MS=''''
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_JiFenDingDan WHERE DingDanId=@DingDanId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @YuanDingDanStatus=[Status],@YuanFuKuanStatus=FuKuanStatus FROM tbl_Pt_JiFenDingDan WHERE DingDanId=@DingDanId

	IF(@YuanFuKuanStatus=0 AND @FuKuanStatus=1)--����
	BEGIN
		UPDATE tbl_Pt_JiFenDingDan SET FuKuanStatus=@FuKuanStatus,FuKuanShenPiRenId=@OperatorId
			,FuKuanShenPiShiJian=@IssueTime,FuKuanShenPiBeiZhu=@OperatorBeiZhu
		WHERE DingDanId=@DingDanId
		SET @MS=''����''
		SET @RetCode=1
	END
	
	IF(@YuanFuKuanStatus=1 AND @FuKuanStatus=0)--ȡ������
	BEGIN
		UPDATE tbl_Pt_JiFenDingDan SET FuKuanStatus=@FuKuanStatus,FuKuanShenPiRenId=@OperatorId
			,FuKuanShenPiShiJian=@IssueTime,FuKuanShenPiBeiZhu=@OperatorBeiZhu
		WHERE DingDanId=@DingDanId
		SET @MS=''ȡ������''
		SET @RetCode=1
	END
	
	IF(@YuanFuKuanStatus=1 AND @FuKuanStatus=2)--֧��
	BEGIN
		UPDATE tbl_Pt_JiFenDingDan SET FuKuanStatus=@FuKuanStatus,FuKuanZhiFuRenId=@OperatorId
			,FuKuanZhiFuShiJian=@IssueTime,FuKuanZhiFuBeiZhu=@OperatorBeiZhu
		WHERE DingDanId=@DingDanId
		SET @MS=''֧��''
		SET @RetCode=1
	END
	
	IF(@YuanFuKuanStatus=2 AND @FuKuanStatus=1)--ȡ��֧��
	BEGIN
		UPDATE tbl_Pt_JiFenDingDan SET FuKuanStatus=@FuKuanStatus,FuKuanZhiFuRenId=@OperatorId
			,FuKuanZhiFuShiJian=@IssueTime,FuKuanZhiFuBeiZhu=@OperatorBeiZhu
		WHERE DingDanId=@DingDanId
		SET @MS=''ȡ��֧��''
		SET @RetCode=1
	END
	
	INSERT INTO [tbl_Pt_JiFenDingDanLiShiLiShi]([DingDanId],[Status],[FuKuanStatus]
		,[BeiZhu],[OperatorId],[IssueTime]
		,[MiaoShu])
	VALUES(@DingDanId,@YuanDingDanStatus,@FuKuanStatus
		,'''',@OperatorId,@IssueTime
		,''���ø���״̬-''+@MS)
	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  View [dbo].[view_Fin_YiXiaoZhang]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_YiXiaoZhang]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2013-01-29
-- Description:�������-���ɵ���-��������Ϣ��ͼ
-- History:
-- 1.2013-01-31 ����־ �������ˡ���ֵĻ���
-- 2.2013-08-08 ����־ ��ֲ�����������������Ŀ���ͻ���Ϣ
-- =============================================
CREATE VIEW [dbo].[view_Fin_YiXiaoZhang]
AS
--����-������
SELECT A.UnCheckId
	,A.DZId
	,A.OrderId
	,A.UnCheckMoney
	,A.OperatorId
	,A.IssueTime
	,A.LeiXing
	,B.Id AS ShouKuanId
	,B.CollectionItem 
	,B.CollectionRefundAmount
	,C.CompanyId
	,C.OrderCode
	,C.SumPrice AS YingShouJinE
	,C.BuyCompanyId
	,(SELECT A1.Name FROM tbl_Customer AS A1 WHERE A1.Id=C.BuyCompanyId) AS KeHuName
	,D.KongWeiId
	,D.KongWeiCode
	,(SELECT A1.RouteName FROM tbl_Route AS A1 WHERE A1.RouteId=C.RouteId) AS RouteName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,C.BusinessType AS YeWuLeiXing
	,A.LeiXing1
FROM [tbl_FinRegisterUnCheck] AS A INNER JOIN [tbl_FinCope] AS B
ON A.UnCheckId=B.XiaoZhangId AND B.IsXiaoZhang=''1'' INNER JOIN [tbl_TourOrder] AS C
ON A.OrderId=C.OrderId INNER JOIN [tbl_KongWei] AS D
ON C.TourId=D.KongWeiId
WHERE A.LeiXing=0 AND A.LeiXing1=1
--���
UNION ALL
SELECT A.UnCheckId
	,A.DZId
	,A.OrderId
	,A.UnCheckMoney
	,A.OperatorId
	,A.IssueTime
	,A.LeiXing
	,'''' AS ShouKuanId
	,0 AS CollectionItem
	,A.UnCheckMoney AS CollectionRefundAmount
	,B.CompanyId AS CompanyId
	,(SELECT A1.Name FROM tbl_ComJiChuXinXi AS A1 WHERE A1.Id=A.XiangMuId  ) AS OrderCode--,'''' AS OrderCode
	,0 AS YingShouJinE
	,DanWeiId AS BuyCompanyId--,'''' AS BuyCompanyId
	,(CASE A.DanWeiType WHEN 0 THEN (SELECT A1.Name FROM tbl_Customer AS A1 WHERE A1.Id=A.DanWeiId) WHEN 1 THEN (SELECT A1.UnitName FROM tbl_CompanySupplier AS A1 WHERE A1.Id=A.DanWeiId) END) AS KeHuName--,'''' AS KeHuName
	,'''' AS KongWeiId
	,''���'' AS KongWeiCode
	,A.BeiZhu AS RouteName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,CAST(240 AS TINYINT) AS YeWuLeiXing
	,A.LeiXing1
FROM [tbl_FinRegisterUnCheck] AS A INNER JOIN [tbl_FinRegister] AS B
ON A.DZId=B.DengZhangId
WHERE A.LeiXing=1
--����-��Ʊ��
UNION ALL
SELECT A.UncheckId
	,A.DZId
	,A.OrderId
	,A.UnCheckMoney
	,A.OperatorId
	,A.IssueTime
	,A.LeiXing
	,B.Id AS ShouKuanId
	,B.CollectionItem 
	,B.CollectionRefundAmount
	,C.CompanyId
	,'''' AS OrderCode
	,C.TuiAmount AS YingShouJinE
	,C.GysId AS BuyCompanyId
	,C.GysName  AS KeHuName
	,D.KongWeiId
	,D.KongWeiCode
	,''����Ʊ��'' AS RouteName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,CAST(240 AS TINYINT) AS YeWuLeiXing
	,A.LeiXing1
FROM [tbl_FinRegisterUnCheck] AS A INNER JOIN [tbl_FinCope] AS B
ON A.UnCheckId=B.XiaoZhangId AND B.IsXiaoZhang=''1'' INNER JOIN view_Fin_TuiPiao AS C
ON C.TuiId=A.OrderId INNER JOIN tbl_KongWei AS D
ON C.KongWeiId=D.KongWeiId
WHERE A.LeiXing=0 AND A.LeiXing1=2
--����-�˻�Ѻ��
UNION ALL
SELECT A.UncheckId
	,A.DZId
	,A.OrderId
	,A.UnCheckMoney
	,A.OperatorId
	,A.IssueTime
	,A.LeiXing
	,B.Id AS ShouKuanId
	,B.CollectionItem 
	,B.CollectionRefundAmount
	,C.CompanyId
	,'''' AS OrderCode
	,TuiYaJinAmount AS YingShouJinE
	,C.GysId AS BuyCompanyId
	,C.GysName  AS KeHuName
	,D.KongWeiId
	,D.KongWeiCode
	,''���˻�Ѻ���'' AS RouteName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,CAST(240 AS TINYINT) AS YeWuLeiXing
	,A.LeiXing1
FROM [tbl_FinRegisterUnCheck] AS A INNER JOIN [tbl_FinCope] AS B
ON A.UnCheckId=B.XiaoZhangId AND B.IsXiaoZhang=''1'' INNER JOIN view_Fin_YaJin AS C
ON C.DaiLiId=A.OrderId INNER JOIN tbl_KongWei AS D
ON C.KongWeiId=D.KongWeiId
WHERE A.LeiXing=0 AND A.LeiXing1=3
--����-�Ŷӽ�����������
UNION ALL
SELECT A.UncheckId
	,A.DZId
	,A.OrderId
	,A.UnCheckMoney
	,A.OperatorId
	,A.IssueTime
	,A.LeiXing
	,B.Id AS ShouKuanId
	,B.CollectionItem 
	,B.CollectionRefundAmount
	,C.CompanyId
	,'''' AS OrderCode
	,Proceed AS YingShouJinE
	,C.CustromCId AS BuyCompanyId
	,C.KeHuName
	,D.KongWeiId
	,D.KongWeiCode
	,''���Ŷӽ�����������'' AS RouteName
	,(SELECT A1.ContactName FROM tbl_CompanyUser AS A1 WHERE A1.Id=A.OperatorId) AS OperatorName
	,CAST(240 AS TINYINT) AS YeWuLeiXing
	,A.LeiXing1
FROM [tbl_FinRegisterUnCheck] AS A INNER JOIN [tbl_FinCope] AS B
ON A.UnCheckId=B.XiaoZhangId AND B.IsXiaoZhang=''1'' INNER JOIN view_Fin_QiTaShouRu AS C
ON C.Id=A.OrderId INNER JOIN tbl_KongWei AS D
ON C.TourId=D.KongWeiId
WHERE A.LeiXing=0 AND A.LeiXing1=4
'
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_XiaoZhang]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_XiaoZhang]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-08-04
-- Description:	���ɵ���-���˴���
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_DengZhang_XiaoZhang]
	@DengZhangId CHAR(36)
	,@LeiXing1 TINYINT
	,@OperatorId INT
	,@IssueTime DATETIME
	,@Xml NVARCHAR(MAX)
	,@RetCode INT OUTPUT
	,@LeiXing TINYINT
	,@KuanXiangStatus TINYINT
	,@KuanXiangType TINYINT
AS
BEGIN
	DECLARE @hdoc INT
	DECLARE @DaoKuanJinE MONEY
	DECLARE @YiXiaoZhangJinE MONEY
	DECLARE @errorcount INT
	DECLARE @XiaoZhangJinE MONEY
	DECLARE @OperatorName NVARCHAR(255)
	
	SET @RetCode=0
	SET @errorcount=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_FinRegister WHERE DengZhangId=@DengZhangId AND [Status]=1)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @DaoKuanJinE=DaoKuanJinE FROM tbl_FinRegister WHERE DengZhangId=@DengZhangId
	SELECT @YiXiaoZhangJinE=ISNULL(SUM(UnCheckMoney),0) FROM tbl_FinRegisterUnCheck WHERE DZId=@DengZhangId
	
	IF(@DaoKuanJinE-@YiXiaoZhangJinE<=0)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	DECLARE @TEMP1 TABLE(XiaoZhangId CHAR(36),GuanLianId CHAR(36),XiaoZhangJinE MONEY,WeiDengJiJinE MONEY,DengZhangId CHAR(36),IdentityId INT IDENTITY(1,1))
	
	EXEC sp_xml_preparedocument @hdoc OUTPUT,@Xml
	INSERT INTO @TEMP1(XiaoZhangId,GuanLianId,XiaoZhangJinE,WeiDengJiJinE,DengZhangId)
	SELECT XiaoZhangId,GuanLianId,XiaoZhangJinE,0,@DengZhangId
	FROM OPENXML(@hdoc,''/root/info'')
	WITH(XiaoZhangId CHAR(36),GuanLianId CHAR(36),XiaoZhangJinE MONEY)
	EXEC sp_xml_removedocument @hdoc
	
	SELECT @XiaoZhangJinE=SUM(XiaoZhangJinE) FROM @TEMP1
	
	IF(@DaoKuanJinE-@YiXiaoZhangJinE-@XiaoZhangJinE<0)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode
	END
	
	IF(@LeiXing1=1)
	BEGIN
		UPDATE @TEMP1 SET WeiDengJiJinE=B.SumPrice-B.ReceivedMoney+B.ReturnMoney
		FROM @TEMP1 AS A INNER JOIN view_TourOrder AS B
		ON A.GuanLianId=B.OrderId
	END
	
	IF(@LeiXing1=2)--����Ʊ��
	BEGIN
		UPDATE @TEMP1 SET WeiDengJiJinE=B.TuiAmount-B.YiShenPiJinE-B.WeiShenPiJinE
		FROM @TEMP1 AS A INNER JOIN view_Fin_TuiPiao AS B
		ON A.GuanLianId=B.TuiId
	END
	
	IF(@LeiXing1=3)--�����˻�Ѻ��
	BEGIN
		UPDATE @TEMP1 SET WeiDengJiJinE=B.TuiYaJinAmount-B.TuiYiShenPiJinE-B.TuiWeiShenPiJinE
		FROM @TEMP1 AS A INNER JOIN view_Fin_YaJin AS B
		ON A.GuanLianId=B.DaiLiId
	END
	
	IF(@LeiXing1=4)--��������������
	BEGIN
		UPDATE @TEMP1 SET WeiDengJiJinE=B.Proceed-B.YiShenPiJinE-B.WeiShenPiJinE
		FROM @TEMP1 AS A INNER JOIN view_Fin_QiTaShouRu AS B
		ON A.GuanLianId=B.Id
	END
	
	--ɾ�����˽��>δ�Ǽǽ�����Ϣ
	--DELETE FROM @TEMP1 WHERE XiaoZhangJinE>WeiDengJiJinE
	--���˽��>δ�Ǽǽ������˽������δ�Ǽǽ��
	UPDATE @TEMP1 SET XiaoZhangJinE=WeiDengJiJinE WHERE XiaoZhangJinE>WeiDengJiJinE
	--ɾ�����˽��Ϊ0����Ϣ
	DELETE FROM @TEMP1 WHERE XiaoZhangJinE<=0
	
	IF NOT EXISTS(SELECT 1 FROM @TEMP1)
	BEGIN
		SET @RetCode=-96
		RETURN @RetCode
	END
	
	SELECT @OperatorName=ContactName FROM tbl_CompanyUser WHERE Id=@OperatorId
	
	BEGIN TRAN
	
	INSERT INTO [tbl_FinRegisterUnCheck]([UnCheckId],[DZId],[OrderId]
		,[UnCheckMoney],[OperatorId],[IssueTime]
		,[LeiXing],[BeiZhu],[XiangMuId]
		,[DanWeiType],[DanWeiId],[LeiXing1])
	SELECT XiaoZhangId,@DengZhangId,GuanLianid
		,XiaoZhangJinE,@operatorId,@IssueTime
		,@LeiXing,'''',0
		,0,'''',@LeiXing1
	FROM @TEMP1
	SET @errorcount=@errorcount+@@ERROR
	
	INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId]
		,[CollectionItem],[CollectionRefundDate],[CollectionRefundOperator]
		,[CollectionRefundOperatorID],[CollectionRefundAmount],[CollectionRefundMode]
		,[CollectionRefundMemo],[BankId],[BankDate]
		,[Status],[ApproverId],[ApproveTime]
		,[ApproveRemark],[PayId],[PayTime]
		,[PayRemark],[OperatorId],[IssueTime]
		,[IsXiaoZhang],[XiaoZhangId],[ZxsId])
	SELECT NEWID(),B.CompanyId,A.GuanLianId
		,@KuanXiangType,@IssueTime,@OperatorName
		,@OperatorId,A.XiaoZhangJinE,B.PayType
		,''���ɵ���-����'',B.BankId,B.BankDate
		,@KuanXiangStatus,@OperatorId,@IssueTime
		,''���ɵ���-����-�Զ�����'',NULL,NULL
		,NULL,@OperatorId,@IssueTIme
		,''1'',A.XiaoZhangId,B.ZxsId
	FROM @TEMP1 AS A INNER JOIN tbl_FinRegister AS B
	ON A.DengZhangId=B.DengZhangId
	SET @errorcount=@errorcount+@@ERROR
	
	--������ά�����������Ϣ
	IF(@LeiXing1=1)
	BEGIN
		DECLARE @MaxIdentityId INT
		SELECT @MaxIdentityId=ISNULL(MAX(IdentityId),0) FROM @TEMP1
		DECLARE @i INT
		SET @i=1
		
		WHILE(@i<=@MaxIdentityId)
		BEGIN
			DECLARE @DingDanId CHAR(36)
			SELECT @DingDanId=GuanLianId FROM @TEMP1 WHERE IdentityId=@i
			SET @i=@i+1
			IF(@DingDanId IS NULL) CONTINUE
			EXEC proc_Fin_SetOrderJinE @OrderId=@DingDanId
		END	
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-15>
-- Description:	<�޸Ķ���>
-- History:
-- 1.����־ 2013-01-22 ����@PlanHotelMxsXML
-- 2.����־ 2013-01-30 ����@ShiJiChuPiaoShuLiangʵ�ʳ�Ʊ�����Ĵ���
-- 3.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���	
-- 4.2013-03-05 ����־ ����@BiaoShiYanSe	
-- =============================================
CREATE proc [dbo].[proc_TourOrder_Update]
	@OrderId char(36)--�������
	,@OrderCode nvarchar(100)--������
	,@CompanyId int--��˾���
	,@TourId char(36)--�Ŷӱ��
	,@BusinessType tinyint--ҵ������
	,@BusinessNature tinyint--����
	,@Adults int--������
	,@Childs int--��ͯ��
	,@Bears int--ȫ����
	,@Accounts int--ռλ��
	,@BuyCompanyId char(36)--��Դ��λ���
	,@BuyOperatorId int--�Է������˱��
	,@RouteId char(36)--��·���
	,@PriceDetials nvarchar(max)--�۸���ϸ
	,@SumPrice money--�ϼƽ��
	,@PriceRemark nvarchar(max)--�۸�ע
	,@CongregationPlace nvarchar(255)--���ϵص�
	,@CongregationTime nvarchar(255)--����ʱ��
	,@SendTourInfo nvarchar(max)--������Ϣ
	,@WelcomeWay nvarchar(max)--���ŷ�ʽ
	,@SpecialAskRemark nvarchar(max)--����Ҫ��
	,@GroundRemark nvarchar(max)--�ؽӱ�ע
	,@OperatoRemark nvarchar(max)--������ע
	,@OperatorId int--�µ��˱��
	,@OrderStatus tinyint--����״̬
	,@SaveSeatDate datetime--��λʱ��
	,@YouKeXml NVARCHAR(MAX)--�����ο�Xml
	,@JiuDianAnPaiXml NVARCHAR(MAX)--�����Ƶ�Ԥ��XML
	,@Result int output
	,@PlanHotelMxXml NVARCHAR(MAX)--�Ƶ갲����ϸ��ϢXML:<root><info KognWeiId="" OrderId="" AnPaiId="" RuZhuTime="" TuiFangTime="" FangXing="" YaoQiuBeiZhu="" JianYe="" QuFangFangShi="" JiuDianName="" /></root>
	,@BiaoShiYanSe VARCHAR(10)--��ʶ��ɫ
	,@LatestOperatorId INT
	,@LatestTime DATETIME
	,@YingErRenShu INT--Ӥ������
	,@BuFangChaRenShu INT--����������
	,@TuiFangChaRenShu INT--�˷�������
	,@JiaJinE MONEY--���ӽ��
	,@JianJinE MONEy--���ٽ��
	,@JiaBeiZhu NVARCHAR(MAX)--���ӽ�ע
	,@JianBeiZhu NVARCHAR(MAX)--���ٽ�ע
	,@DingDanJinE MONEY--��Ʒ���
	,@XianLuId CHAR(36)--��λ��·���
	,@ChengRenJiaGe MONEY--���˼۸�
	,@ErTongJiaGe MONEY--��ͯ�۸�
	,@YingErJiaGe MONEY--Ӥ���۸�
	,@QuanPeiJiaGe MONEY--ȫ��۸�
	,@TuiFangChaJiaGe MONEY--�˷���۸�
	,@BuFangChaJiaGe MONEY--������۸�
	,@JiFen1 INT--���˻���
	,@JiFen2 INT--�ܻ���
	,@BuZhanWeiRenShu INT--��ռλ����
	,@XiaDanBeiZhu NVARCHAR(MAX)--�µ���ע
	,@JiaGeMingXi NVARCHAR(MAX)
	,@DingDanLxrXingMing NVARCHAR(255)--������ϵ������
	,@DingDanLxrShouJi NVARCHAR(255)--������ϵ���ֻ�
	,@DingDanLxrDianHua NVARCHAR(255)--������ϵ�˵绰
	,@DingDanLxrFax NVARCHAR(255)--������ϵ�˴���
as
begin
	declare @error int
	set @error=0
	DECLARE @KongWeiShuLiang INT--��λ����
	DECLARE @KongWeiCode NVARCHAR(50)--��λ��
	DECLARE @hdoc INT
	DECLARE @XiaDanLeiXing TINYINT--�µ�����
	DECLARE @XiaDanRenid INT--�µ��˱��
	DECLARE @YuanDuiFangCaoZuoRenId INT--ԭ�Է������˱��
	DECLARE @YuanDingDanStatus TINYINT--����ԭʼ״̬
	DECLARE @OldBusinessNature tinyint--����ԭʼ����
	DECLARE @YuanYeWuLeiXing TINYINT--ԭҵ������
	DECLARE @YuanXianLuId CHAR(36)--ԭ��·��Ʒ���
	
	select @KongWeiShuLiang=ShuLiang,@KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@TourId

	declare @ZongZhanWeiShuLiang int --��ռλ����
	select @ZongZhanWeiShuLiang=isnull(sum(Accounts),0) from tbl_TourOrder 
	where IsDelete=''0'' and TourId=@TourId AND OrderId<>@OrderId and OrderStatus in (0,1,4,5)

	DECLARE @ShiJiChuPiaoShuLiang INT--ʵ�ʳ�Ʊ����
	SELECT @ShiJiChuPiaoShuLiang=ISNULL(SUM(A.ShuLiang),0) FROM tbl_PlanChuPiao AS A WHERE A.KongWeiId=@TourId

	IF(@ZongZhanWeiShuLiang<@ShiJiChuPiaoShuLiang) SET @ZongZhanWeiShuLiang=@ShiJiChuPiaoShuLiang

	if(@KongWeiShuLiang<@ZongZhanWeiShuLiang+@Accounts)--������λ����
	begin
		--set @Result=-99
		--return @Result
		SET @OrderStatus=6--����״̬Ϊ������
	end	
	
	SELECT @OldBusinessNature=BusinessNature
		,@XiaDanLeiXing=XiaDanLeiXing,@XiaDanRenid=OperatorId
		,@YuanDuiFangCaoZuoRenId=BuyOperatorId
		,@YuanDingDanStatus=OrderStatus
		,@YuanYeWuLeiXing=BusinessType
		,@YuanXianLuId=XianLuId
	FROM tbl_TourOrder WHERE OrderId=@OrderId
	
	if (@OldBusinessNature<>@BusinessNature) AND exists(select 1 from tbl_PlanDiJIeOrder where OrderId=@OrderId)
	begin		
		set @Result=-98
		return @Result
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@TourId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-93
		RETURN @Result
	END
	
	IF(@YuanDingDanStatus NOT IN(0,1,4,5,6))
	BEGIN
		SET @Result=-92
		RETURN @Result
	END
	
	IF(@YuanYeWuLeiXing IN(1,2))
	BEGIN
		SET @XianLuId=@YuanXianLuId
	END

	begin transaction

	UPDATE tbl_TourOrder SET BusinessNature=@BusinessNature,Adults=@Adults
		,Childs=@Childs,Bears=@Bears,Accounts=@Accounts,BuyCompanyId=@BuyCompanyId
		,BuyOperatorId=@BuyOperatorId,RouteId=@RouteId
		,PriceDetials=@PriceDetials,SumPrice=@SumPrice,PriceRemark=@PriceRemark
		,CongregationPlace=@CongregationPlace,CongregationTime=@CongregationTime
		,SendTourInfo=@SendTourInfo,WelcomeWay=@WelcomeWay,SpecialAskRemark=@SpecialAskRemark
		,GroundRemark=@GroundRemark,OperatoRemark=@OperatoRemark,OrderStatus=@OrderStatus
		,SaveSeatDate=@SaveSeatDate,BiaoShiYanSe=@BiaoShiYanSe,BusinessType=@BusinessType
		,LatestOperatorId=@LatestOperatorId,LatestTime=@LatestTime
		,[XianLuId]=@XianLuId,[YingErRenShu]=@YingErRenShu
		,[BuZhanWeiRenShu]=@BuZhanWeiRenShu,[ChengRenJiaGe]=@ChengRenJiaGe
		,[ErTongJiaGe]=@ErTongJiaGe,[QuanPeiJiaGe]=@QuanPeiJiaGe
		,[YingErJiaGe]=@YingErJiaGe,[JiaJinE]=@JiaJinE
		,[JianJinE]=@JianJinE,[JiaBeiZhu]=@JiaBeiZhu
		,[JianBeiZhu]=@JianBeiZhu,[BuFangChaRenShu]=@BuFangChaRenShu
		,[TuiFangChaRenShu]=@TuiFangChaRenShu,[BuFangChaJiaGe]=@BuFangChaJiaGe
		,[TuiFangChaJiaGe]=@TuiFangChaJiaGe,[DingDanJinE]=@DingDanJinE
		,[JiFen1]=@JiFen1,[JiFen2]=@JiFen2
		,[XiaDanBeiZhu]=@XiaDanBeiZhu,[JiaGeMingXi]=@JiaGeMingXi
		,[DingDanLxrXingMing]=@DingDanLxrXingMing,[DingDanLxrDianHua]=@DingDanLxrDianHua
		,[DingDanLxrShouJi]=@DingDanLxrShouJi,[DingDanLxrFax]=@DingDanLxrFax
	WHERE OrderId=@OrderId 
	set @error=@error+@@error
	
	DECLARE @TEMP1 TABLE(TravellerId char(36),TravellerName nvarchar(50)
		,TravellerType tinyint,CardType tinyint,CardNumber nvarchar(50)
		,Gender tinyint,Contact nvarchar(255),Status tinyint
		,TicketType tinyint,T1 CHAR(1))
		
	IF(@YouKeXml IS NOT NULL AND LEN(@YouKeXml)>0)
	BEGIN
		exec sp_xml_preparedocument @hdoc output,@YouKeXml
		INSERT INTO @TEMP1(TravellerId,TravellerName
			,TravellerType,CardType,CardNumber
			,Gender,Contact,Status
			,TicketType,T1)
		SELECT TravellerId,TravellerName
			,TravellerType,CardType,CardNumber
			,Gender,Contact,Status
			,TicketType,''C''		
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(TravellerId char(36),TravellerName nvarchar(50)
			,TravellerType tinyint,CardType tinyint,CardNumber nvarchar(50)
			,Gender tinyint,Contact nvarchar(255),Status tinyint
			,TicketType tinyint)
		exec sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP1 SET T1=''U'' WHERE TravellerId IN(SELECT [TravellerId] FROM [tbl_TourOrderTraveller] WHERE OrderId=@OrderId)
	
	--�����ο�
	INSERT INTO [tbl_TourOrderTraveller]([TravellerId],[OrderId],[TourId]
		,[TravellerName],[TravellerType],[CardType]
		,[CardNumber],[Gender],[Contact]
		,[Status],[TicketType])
	SELECT TravellerId,@OrderId,@TourId
		,TravellerName,TravellerType,CardType
		,CardNumber,Gender,Contact
		,Status,TicketType
	FROM @TEMP1 WHERE T1=''C''
	
	--�޸��ο�
	UPDATE tbl_TourOrderTraveller SET [TravellerName]=B.[TravellerName]
		,[TravellerType]=B.[TravellerType],[CardType]=B.[CardType]
		,[CardNumber]=B.[CardNumber],[Gender]=B.[Gender]
		,[Contact]=B.[Contact],[Status]=B.Status
	FROM tbl_TourOrderTraveller AS A INNER JOIN @TEMP1 AS B
	ON A.[TravellerId]=B.[TravellerId] AND B.T1=''U''
	WHERE A.OrderId=@OrderId
	
	--ɾ���ο�
	DELETE FROM tbl_TourOrderTraveller WHERE OrderId=@OrderId
	AND TravellerId NOT IN(SELECT TravellerId FROM @TEMP1)
	AND Status=0 AND TicketType=0
	
	--�������ο�״̬��Ϊ��δ��Ʊ
	UPDATE  tbl_TourOrderTraveller SET TicketType=0 WHERE orderId=@OrderId

	--ά���ѳ�Ʊ״̬
	Update tbl_TourOrderTraveller set TicketType=1 
	where TravellerId in(select YouKeId from tbl_PlanChuPiaoYouKe where OrderId=@OrderId)

	--ά������Ʊ״̬
	Update tbl_TourOrderTraveller set TicketType=2
	where TravellerId in(select YouKeId from tbl_PlanTuiPiaoYouKe where OrderId=@OrderId)
	
	--�Ƶ갲�Ŵ���
	DECLARE @TEMP2 TABLE(Id char(36),CheckInDate datetime,CheckOutDate datetime
		,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
		,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
		,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
		,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100)
		,IDENTITYID INT IDENTITY,T1 CHAR(1))
		
	IF(@JiuDianAnPaiXml IS NOT NULL AND LEN(@JiuDianAnPaiXml)>0)
	BEGIN
		exec sp_xml_preparedocument @hdoc output,@JiuDianAnPaiXml
		INSERT INTO @TEMP2(Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
			,T1)
		SELECT Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
			,''C''
		FROM openxml(@hdoc,''/root/info'',3)
		with(Id char(36),CheckInDate datetime,CheckOutDate datetime
			,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
			,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
			,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
			,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100))		
		exec sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP2 SEt T1=''U'' WHERE Id IN(SELECT Id FROM tbl_TourOrderHotelPlan WHERE OrderId=@OrderId)
	
	--�����Ƶ갲��
	INSERT INTO tbl_TourOrderHotelPlan(Id,OrderId,TourId
		,CompanyId,CheckInDate,CheckOutDate
		,Room,Remark,RoomNights
		,HumorWas,HotelName,GYSId
		,SideOperatorId,SettleDetail,SettleAmount
        ,PlanRemark,PlanDetail,FileInfo)
	SELECT Id,@OrderId,@TourId
		,@CompanyId,CheckInDate,CheckOutDate
		,Room,Remark,RoomNights
		,HumorWas,HotelName,GYSId
		,SideOperatorId,SettleDetail,SettleAmount
		,PlanRemark,PlanDetail,FileInfo
	FROM @TEMP2 WHERE T1=''C'' ORDER BY IdentityId ASC
	
	--�޸ľƵ갲��
	UPDATE tbl_TourOrderHotelPlan SET CheckInDate=B.CheckInDate
		,CheckOutDate=B.CheckOutDate,Room=B.Room
		,Remark=B.Remark,RoomNights=B.RoomNights
		,HumorWas=B.HumorWas,HotelName=B.HotelName
		,GYSId=B.GYSId,SideOperatorId=B.SideOperatorId
		,SettleDetail=B.SettleDetail,SettleAmount=B.SettleAmount
		,PlanRemark=B.PlanRemark,PlanDetail=B.PlanDetail
		,FileInfo=B.FileInfo
	FROM tbl_TourOrderHotelPlan AS A INNER JOIN @Temp2 AS B
	ON A.Id=B.Id AND B.T1=''U''
	WHERE A.OrderId=@OrderId
	
	--ɾ���Ƶ갲��
	UPDATE tbl_TourOrderHotelPlan SET IsDelete=''1'' WHERE OrderId=@OrderId
	AND Id NOT IN(SELECT Id FROM @TEMP2)
	AND NOT EXISTS(SELECT 1 FROM tbl_FinCope AS A1 WHERE A1.CollectionId=tbl_TourOrderHotelPlan.Id)
	
	--���Ž��׺Ŵ���
	DECLARE @count INT
	DECLARE @i INT
	SELECT @count=COUNT(*) FROM @TEMP2
	SET @i=1
	
	WHILE(@i<=@count)
	BEGIN
		DECLARE @TempId CHAR(36)
		DECLARE @T1 CHAR(1)
		SELECT @TempId=Id,@T1=T1 FROM @TEMP2 WHERE IdentityId=@i
		
		SET @i=@i+1
		IF(@T1=''U'')
		BEGIN
			CONTINUE
		END
		
		DECLARE @JiaoYiHao nvarchar(50)
		DECLARE @index INT
		
		SELECT @index=COUNT(*)+1 FROM tbl_TourOrderHotelPlan WHERE OrderId=@OrderId AND JiaoYiHao IS NOT NULL AND LEN(JiaoYiHao)>0
		
		SET @JiaoYiHao= @KongWeiCode+''D''+dbo.fn_PadLeft(@index,0,2)
		
		update tbl_TourOrderHotelPlan set JiaoYiHao=@JiaoYiHao
		where Id=@TempId		
	END
	
	--�Ƶ갲����ϸ��Ϣ����
	IF(@error=0)
	BEGIN
		UPDATE [tbl_PlanHotelMX] SET IsDelete=''1'' WHERE KongWeiId=@TourId AND OrderId=@OrderId
		SET @error=@error+@@ERROR
	END

	IF(@error=0 AND LEN(@PlanHotelMxXML)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@PlanHotelMxXML
		INSERT INTO [tbl_PlanHotelMX]([AnPaiId],[KongWeiId],[OrderId],[RuZhuTime]
			,[TuiFangTime],[FangXing],[YaoQiuBeiZhu],[JianYe]
			,[QuFangFangShi],[JiuDianName],[IssueTime],[IsDelete])
		SELECT A.AnPaiId,A.KongWeiId,A.OrderId,A.RuZhuTime
			,A.TuiFangTime,A.FangXing,A.YaoQiuBeiZhu,A.JianYe
			,A.QuFangFangShi,A.JiuDianName,@LatestTime,''0''
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(KongWeiId CHAR(36),OrderId CHAR(36),AnPaiId CHAR(36),RuZhuTime DATETIME,TuiFangTime DATETIME,FangXing NVARCHAR(255),YaoQiuBeiZhu NVARCHAR(255),JianYe NVARCHAR(255),QuFangFangShi NVARCHAR(255),JiuDianName NVARCHAR(255)) AS A

		EXECUTE sp_xml_removedocument @hdoc
		set @error=@error+@@error
	END
	
	--���ִ���
	DECLARE @YuanJiFenYongHuId INT--ԭ�����û����
	IF(@XiaDanLeiXing=0)
	BEGIN
		SELECT @YuanJiFenYongHuId=YongHuId FROM tbl_CustomerContactInfo WHERE ID=@YuanDuiFangCaoZuoRenId
	END
	ELSE
	BEGIN
		SET @YuanJiFenYongHuId=@XiaDanRenId
	END
	
	DECLARE @JiFenYongHuId INT--�»����û����
	SELECT @JiFenYongHuId=YongHuId FROM tbl_CustomerContactInfo WHERE ID=@BuyOperatorId
	
	DECLARE @JiFenMingXiId INT
	SET @JiFenMingXiId=0
	SELECT @JiFenMingXiId=IdentityId FROM [tbl_Pt_YongHuJiFenMingXi] WHERE CompanyId=@CompanyId AND [YongHuId]=@YuanJiFenYongHuId AND [GuanLianLeiXing]=0 AND GuanLianId=@OrderID AND [Status]<>3

	IF(@JiFenYongHuId IS NOT NULL AND @JiFenYongHuId>0)
	BEGIN
		IF (@JiFenMingXiId>0)
		BEGIN
			IF(@JiFen2>0)
			BEGIN
				UPDATE [tbl_Pt_YongHuJiFenMingXi] SET JiFen=@JiFen2,YongHuId=@JiFenYongHuId WHERE IdentityId=@JiFenMingXiId
			END
			ELSE
			BEGIN
				UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [Status]=3 WHERE IdentityId=@JiFenMingXiId
			END
		END
		ELSE
		BEGIN
			IF(@JiFen2>0)
			BEGIN
				INSERT INTO [tbl_Pt_YongHuJiFenMingXi]([CompanyId],[YongHuId],[JiFen]
					,[Status],[IssueTime],[GuanLianLeiXing]
					,[GuanLianId],[ShengXiaoShiJian])
				VALUES(@CompanyId,@JiFenYongHuId,@JiFen2
					,0,@LatestTime,0
					,@OrderID,NULL)
				set @error=@error+@@error
			END
		END
	END
	ELSE
	BEGIN
		IF(@JiFenMingXiId>0)
		BEGIN
			UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [Status]=3 WHERE IdentityId=@JiFenMingXiId
		END
	END
	
	DECLARE @JiFenHandlerRetCode INT
	EXEC proc_YongHu_JiFen_Handler @YongHuId=@YuanJiFenYongHuId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
	EXEC proc_YongHu_JiFen_Handler @YongHuId=@JiFenYongHuId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
	
	--ά���ƻ�λ���տ�״̬
	DECLARE @tempresult INT
	exec proc_WeiHuKongWeiStatus @TourId,@tempresult output
	
	IF(@error<>0)
	BEGIN
		SET @Result=-100
		ROLLBACK TRAN
		RETURN @Result
	END

	SET @Result=1
	COMMIT TRAN

	return @Result		
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrder_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrder_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-15>
-- Description:	<��Ӷ���>
-- History:
-- 1.����־ 2013-01-22 ����@PlanHotelMxsXML
-- 2.����־ 2013-01-30 ����@ShiJiChuPiaoShuLiangʵ�ʳ�Ʊ�����Ĵ���
-- 3.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���
-- 4.2013-03-05 ����־ ����@BiaoShiYanSe	
-- =============================================
CREATE proc [dbo].[proc_TourOrder_Add]
	@OrderId char(36)--�������
	,@OrderCode nvarchar(100)--������
	,@CompanyId int--��˾���
	,@TourId char(36)--�Ŷӱ��
	,@BusinessType tinyint--ҵ������
	,@BusinessNature tinyint--����
	,@Adults int--������
	,@Childs int--��ͯ��
	,@Bears int--ȫ����
	,@Accounts int--ռλ��
	,@BuyCompanyId char(36)--��Դ��λ���
	,@BuyOperatorId int--�Է������˱��
	,@RouteId char(36)--��·���
	,@PriceDetials nvarchar(max)--�۸���ϸ
	,@SumPrice money--�ϼƽ��
	,@PriceRemark nvarchar(max)--�۸�ע
	,@CongregationPlace nvarchar(255)--���ϵص�
	,@CongregationTime nvarchar(255)--����ʱ��
	,@SendTourInfo nvarchar(max)--������Ϣ
	,@WelcomeWay nvarchar(max)--���ŷ�ʽ
	,@SpecialAskRemark nvarchar(max)--����Ҫ��
	,@GroundRemark nvarchar(max)--�ؽӱ�ע
	,@OperatoRemark nvarchar(max)--������ע
	,@OperatorId int--�µ��˱��
	,@OrderStatus tinyint--����״̬
	,@SaveSeatDate datetime--��λʱ��
	,@YouKeXml NVARCHAR(MAX)--�����ο�xml
	,@JiuDianAnPaiXml NVARCHAR(MAX)--�����Ƶ갲��xml
	,@Result int output
	,@JiuDianAnPaiMxXml NVARCHAR(MAX)--�Ƶ갲����ϸ��ϢXML:<root><info KognWeiId="" OrderId="" AnPaiId="" RuZhuTime="" TuiFangTime="" FangXing="" YaoQiuBeiZhu="" JianYe="" QuFangFangShi="" JiuDianName="" /></root>
	,@BiaoShiYanSe VARCHAR(10)--��ʶ��ɫ
	,@XiaDanLeiXing TINYINT--�µ�����
	,@ZxsId CHAR(36)--ר���̱��
	,@LatestOperatorId INT--�������˱��
	,@LatestTime DATETIME--������ʱ��
	,@YingErRenShu INT--Ӥ������
	,@BuFangChaRenShu INT--����������
	,@TuiFangChaRenShu INT--�˷�������
	,@JiaJinE MONEY--���ӽ��
	,@JianJinE MONEy--���ٽ��
	,@JiaBeiZhu NVARCHAR(MAX)--���ӽ�ע
	,@JianBeiZhu NVARCHAR(MAX)--���ٽ�ע
	,@DingDanJinE MONEY--��Ʒ���
	,@XianLuId CHAR(36)--��λ��·���
	,@ChengRenJiaGe MONEY--���˼۸�
	,@ErTongJiaGe MONEY--��ͯ�۸�
	,@YingErJiaGe MONEY--Ӥ���۸�
	,@QuanPeiJiaGe MONEY--ȫ��۸�
	,@TuiFangChaJiaGe MONEY--�˷���۸�
	,@BuFangChaJiaGe MONEY--������۸�
	,@JiFen1 INT--���˻���
	,@JiFen2 INT--�ܻ���
	,@BuZhanWeiRenShu INT--��ռλ����
	,@XiaDanBeiZhu NVARCHAR(MAX)--�µ���ע
	,@JiaGeMingXi NVARCHAR(MAX)
	,@DingDanLxrXingMing NVARCHAR(255)--������ϵ������
	,@DingDanLxrShouJi NVARCHAR(255)--������ϵ���ֻ�
	,@DingDanLxrDianHua NVARCHAR(255)--������ϵ�˵绰
	,@DingDanLxrFax NVARCHAR(255)--������ϵ�˴���
as
begin
	declare @error int
	set @error=0
	
	DECLARE @KongWeiStatus TINYINT--��λ״̬
	DECLARE @KongWeiShuLiang INT--��λ����
	DECLARE @KongWeiCode NVARCHAR(50)--��λ��
	DECLARE @hdoc INT
	
	select @KongWeiStatus=[Status],@KongWeiShuLiang=ShuLiang,@KongWeiCode=KongWeiCode from tbl_KongWei where KongWeiId=@TourId
	
	IF(@KongWeiStatus=1)--�ֶ�ͣ��
	begin
		set @Result=-99
		return @Result
	end

	declare @ZongZhanWeiShuLiang int --��ռλ����
	select @ZongZhanWeiShuLiang=isnull(sum(Accounts),0) from tbl_TourOrder 
	where IsDelete=''0'' and TourId=@TourId and OrderStatus in (0,1,4,5)

	DECLARE @ShiJiChuPiaoShuLiang INT--ʵ�ʳ�Ʊ����
	SELECT @ShiJiChuPiaoShuLiang=ISNULL(SUM(A.ShuLiang),0) FROM tbl_PlanChuPiao AS A WHERE A.KongWeiId=@TourId

	IF(@ZongZhanWeiShuLiang<@ShiJiChuPiaoShuLiang) SET @ZongZhanWeiShuLiang=@ShiJiChuPiaoShuLiang

	if(@KongWeiShuLiang<@ZongZhanWeiShuLiang+@Accounts)--������λ����
	begin
		--set @Result=-98
		--return @Result
		SET @OrderStatus=6
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@TourId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-97
		RETURN @Result
	END
	
	begin transaction

	--�Զ����ɶ�����
	set @OrderCode=dbo.fn_OrderCode(@TourId)

	INSERT INTO tbl_TourOrder(OrderId,OrderCode,CompanyId
		,TourId,BusinessType,BusinessNature
		,Adults,Childs,Bears
		,Accounts,BuyCompanyId,BuyOperatorId
		,RouteId,PriceDetials,SumPrice
		,PriceRemark,CongregationPlace,CongregationTime
		,SendTourInfo,WelcomeWay,SpecialAskRemark
		,GroundRemark,OperatoRemark,OperatorId
		,OrderStatus,SaveSeatDate,BiaoShiYanSe
		,ZxsId,XiaDanLeiXing,LatestOperatorId
		,LatestTime,IssueTime,[XianLuId]
		,[YingErRenShu],[BuZhanWeiRenShu],[ChengRenJiaGe]
		,[ErTongJiaGe],[QuanPeiJiaGe],[YingErJiaGe]
		,[JiaJinE],[JianJinE],[JiaBeiZhu]
		,[JianBeiZhu],[BuFangChaRenShu],[TuiFangChaRenShu]
		,[BuFangChaJiaGe],[TuiFangChaJiaGe],[DingDanJinE]
		,[JiFen1],[JiFen2],[XiaDanBeiZhu]
		,[JiaGeMingXi],[DingDanLxrXingMing],[DingDanLxrDianHua]
		,[DingDanLxrShouJi],[DingDanLxrFax])
	VALUES (@OrderId,@OrderCode,@CompanyId
		,@TourId,@BusinessType,@BusinessNature
		,@Adults,@Childs,@Bears
		,@Accounts,@BuyCompanyId,@BuyOperatorId
		,@RouteId,@PriceDetials,@SumPrice
		,@PriceRemark,@CongregationPlace,@CongregationTime
		,@SendTourInfo,@WelcomeWay,@SpecialAskRemark
		,@GroundRemark,@OperatoRemark,@OperatorId
		,@OrderStatus,@SaveSeatDate,@BiaoShiYanSe
		,@ZxsId,@XiaDanLeiXing,@LatestOperatorId
		,@LatestTime,@LatestTime,@XianLuId
		,@YingErRenShu,@BuZhanWeiRenShu,@ChengRenJiaGe
		,@ErTongJiaGe,@QuanPeiJiaGe,@YingErJiaGe
		,@JiaJinE,@JianJinE,@JiaBeiZhu
		,@JianBeiZhu,@BuFangChaRenShu,@TuiFangChaRenShu
		,@BuFangChaJiaGe,@TuiFangChaJiaGe,@DingDanJinE
		,@JiFen1,@JiFen2,@XiaDanBeiZhu
		,@JiaGeMingXi,@DingDanLxrXingMing,@DingDanLxrDianHua
		,@DingDanLxrShouJi,@DingDanLxrFax)
	set @error=@error+@@error
	
	if(@YouKeXml is not null AND LEN(@YouKeXml)>0)
	begin
		exec sp_xml_preparedocument @hdoc output,@YouKeXml
		INSERT INTO tbl_TourOrderTraveller(TravellerId,OrderId,TourId
			,TravellerName,TravellerType,CardType
			,CardNumber,Gender,Contact
			,Status,TicketType)
		SELECT TravellerId,@OrderId,@TourId
			,TravellerName,TravellerType,CardType
			,CardNumber,Gender,Contact
			,Status,TicketType 
		from openxml(@hdoc,''/root/info'',3)
		with(TravellerId char(36),TravellerName nvarchar(50),TravellerType tinyint
			,CardType tinyint,CardNumber nvarchar(50),Gender tinyint
			,Contact nvarchar(255),Status tinyint,TicketType tinyint)
		set @error=@error+@@error
		exec sp_xml_removedocument @hdoc
	end
	
	if(@JiuDianAnPaiXml is not null AND LEN(@JiuDianAnPaiXml)>0)
	begin
		exec sp_xml_preparedocument @hdoc output,@JiuDianAnPaiXml
		
		DECLARE @TEMP1 TABLE(Id char(36),CheckInDate datetime,CheckOutDate datetime
			,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
			,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
			,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
			,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100)
			,IDENTITYID INT IDENTITY)
			
		INSERT INTO @TEMP1(Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo)
		SELECT Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
		FROM openxml(@hdoc,''/root/info'',3)
		with(Id char(36),CheckInDate datetime,CheckOutDate datetime
			,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
			,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
			,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
			,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100))		
		exec sp_xml_removedocument @hdoc
		
		INSERT INTO tbl_TourOrderHotelPlan(Id,OrderId,TourId
			,CompanyId,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
            ,PlanRemark,PlanDetail,FileInfo)
		SELECT Id,@OrderId,@TourId
			,@CompanyId,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
		FROM @TEMP1 ORDER BY IdentityId ASC
		set @error=@error+@@error
		
		--���Ž��׺Ŵ���
		DECLARE @count INT
		DECLARE @index INT
		SELECT @count=COUNT(*) FROM @TEMP1
		SET @index=1
		
		WHILE(@index<=@count)
		BEGIN
			DECLARE @TempId CHAR(36)
			SELECT @TempId=Id FROM @TEMP1 WHERE IdentityId=@index
			DECLARE @JiaoYiHao nvarchar(50)
			
			SET @JiaoYiHao= @KongWeiCode+''D''+dbo.fn_PadLeft(@index,0,2)
			
			update tbl_TourOrderHotelPlan set JiaoYiHao=@JiaoYiHao
			where Id=@TempId
			
			SET @index=@index+1
		END
	end

	--�Ƶ갲����ϸ��Ϣ����
	IF(@error=0 AND @JiuDianAnPaiMxXml IS NOT NULL AND LEN(@JiuDianAnPaiMxXml)>0)
	BEGIN		
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@JiuDianAnPaiMxXML
		INSERT INTO [tbl_PlanHotelMX]([AnPaiId],[KongWeiId],[OrderId],[RuZhuTime]
			,[TuiFangTime],[FangXing],[YaoQiuBeiZhu],[JianYe]
			,[QuFangFangShi],[JiuDianName],[IssueTime],[IsDelete])
		SELECT A.AnPaiId,A.KongWeiId,A.OrderId,A.RuZhuTime
			,A.TuiFangTime,A.FangXing,A.YaoQiuBeiZhu,A.JianYe
			,A.QuFangFangShi,A.JiuDianName,@LatestTime,''0''
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(KongWeiId CHAR(36),OrderId CHAR(36),AnPaiId CHAR(36),RuZhuTime DATETIME,TuiFangTime DATETIME,FangXing NVARCHAR(255),YaoQiuBeiZhu NVARCHAR(255),JianYe NVARCHAR(255),QuFangFangShi NVARCHAR(255),JiuDianName NVARCHAR(255)) AS A
		set @error=@error+@@error
		EXECUTE sp_xml_removedocument @hdoc		
	END
	
	IF(@JiFen2>0)--���ִ���
	BEGIN
		DECLARE @JiFenYongHuId INT
		IF(@XiaDanLeiXing=0)
		BEGIN
			SELECT @JiFenYongHuId=YongHuId FROM tbl_CustomerContactInfo WHERE ID=@BuyOperatorId
		END
		ELSE
		BEGIN
			SET @JiFenYongHuId=@OperatorId
		END
		
		IF(@JiFenYongHuId IS NOT NULL AND @JiFenYongHuId>0)
		BEGIN
			INSERT INTO [tbl_Pt_YongHuJiFenMingXi]([CompanyId],[YongHuId],[JiFen]
				,[Status],[IssueTime],[GuanLianLeiXing]
				,[GuanLianId],[ShengXiaoShiJian])
			VALUES(@CompanyId,@JiFenYongHuid,@JiFen2
				,0,@LatestTime,0
				,@OrderID,NULL)
			set @error=@error+@@error
		END
		
		DECLARE @JiFenHandlerRetCode INT
		EXEC proc_YongHu_JiFen_Handler @YongHuId=@JiFenYongHuId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
	END
	
	--ά���ƻ�λ���տ�״̬
	DECLARE @tempresult int
	exec proc_WeiHuKongWeiStatus @TourId,@tempresult output
	
	IF(@error<>0)
	BEGIN
		SET @Result=-100
		ROLLBACK TRAN
		RETURN @Result
	END

	SET @Result=1
	COMMIT TRAN

	return @Result	
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_XianLuDingDan_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_XianLuDingDan_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-07
-- Description:	ƽ̨-��·�����������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_XianLuDingDan_CU]
	@DingDanId CHAR(36)--�������
	,@CompanyId INT--��˾���
	,@YeWuLeiXing TINYINT--ҵ������
	,@XianLuId CHAR(36)--��λ��·��Ʒ���
	,@KongWeiId CHAR(36)--��λ���
	,@RouteId CHAR(36)--��·���
	,@KeHuId CHAR(36)--�ͻ����
	,@XiaDanRenId INT--�µ��˱��
	,@KeHuLxrId INT--�ͻ���ϵ�˱��
	,@ChengRenShu INT--������
	,@ErTongShu INT--��ͯ��
	,@YingErShu INT--Ӥ����
	,@QuanPeiShu INT--ȫ����
	,@BuZhanWeiShu INT--��ռλ����
	,@ZhanWeiShu INT--ռλ��
	,@BuFangChaShu INT--����������
	,@TuiFangChaShu INT--�˷�������
	,@ChengRenJiaGe MONEY--���˼�
	,@ErTongJiaGe MONEY--��ͯ��
	,@YingErJiaGe MONEY--Ӥ����
	,@QuanPeiJiaGe MONEY--ȫ���
	,@TuiFangChaJiaGe MONEY--�˷���۸�
	,@BuFangChaJiaGe MONEY--������۸�
	,@JiFen1 INT--���ۻ���
	,@JiFen2 INT--�ܻ���
	,@DingDanJinE MONEY--��Ʒ���
	,@JinE MONEY--������
	,@JiaGeMingXi NVARCHAR(255)--�۸���ϸ
	,@DingDanLxrXingMing NVARCHAR(255)--������ϵ������
	,@DingDanLxrShouJi NVARCHAR(255)--������ϵ���ֻ�
	,@DingDanLxrDianHua NVARCHAR(255)--������ϵ�˵绰
	,@DingDanLxrFax NVARCHAR(255)--������ϵ�˴���
	,@XiaDanBeiZhu NVARCHAR(255)--�µ���ע
	,@YouKeXml NVARCHAR(MAX)--�ο���ϢXML
	,@DingDanStatus TINYINT--����״̬
	,@DingDanLaiYuan TINYINT--������Դ
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @FS CHAR(1)
	DECLARE @ShouKeStatus TINYINT--�տ�״̬
	DECLARE @KongWeiShuLiang INT--��λ����
	DECLARE @KongWeiCode NVARCHAR(50)--��λ��
	DECLARE @ZxsId CHAR(36)--ר���̱��
	DECLARE @ZongZhanWeiShuLiang INT --��ռλ����
	DECLARE @ShiJiChuPiaoShuLiang INT--ʵ�ʳ�Ʊ����
	DECLARE @KongWeiZhuangTai TINYINT--��λ״̬
	DECLARE @JiaoYiHao NVARCHAR(50)--���׺�
	DECLARE @JiHeShiJian NVARCHAR(255)--����ʱ��
	DECLARE @JiHeDiDian NVARCHAR(255)--���ϵ�
	DECLARE @SongTuanXinXi NVARCHAR(255)--������Ϣ
	DECLARE @MuDiDiJieTuanFangShi NVARCHAR(255)--Ŀ�ĵؽ��ŷ�ʽ
	DECLARE @hdoc INT
	DECLARE @YuanJiFenYongHuId INT--ԭ�����û����
	DECLARE @YuanKeHuLxrId INT--ԭ�ͻ���ϵ�˱��
	DECLARE @JiFenYongHuId INT--�ֻ����û����
	DECLARE @YuanDingDanStatus TINYINT--ԭ����״̬
	DECLARE @PingTaiShouKeStatus TINYINT--ƽ̨�տ�״̬
	DECLARE @PingTaiShuLiang INT--ƽ̨��λ����
	
	SET @errorcount=0
	SET @FS=''C''
	SET @RetCode=0
	SET @YuanJiFenYongHuId=@XiaDanRenId
	SET @YuanKeHuLxrId=@KeHuLxrId
	
	IF EXISTS(SELECT 1 FROM tbl_TourOrder WHERE CompanyId=@CompanyId AND OrderId=@DingDanId)
	BEGIN
		SET @FS=''U''
	END
	
	IF (@FS=''C'' AND NOT EXISTS(SELECT 1 FROM tbl_Pt_KongWeiXianLu WHERE XianLuId=@XianLuId AND KongWeiId=@KongWeiId AND RouteId=@RouteId))
	BEGIN
		SET @RetCode=-99--�����ڵĿ�λ��·��Ʒ
		RETURN @RetCode
	END
	
	IF NOT EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND CompanyId=@CompanyId)
	BEGIN
		SET @RetCode=-98--�����ڵĿ�λ
		RETURN @RetCode
	END
	
	SELECT @ShouKeStatus=[Status],@KongWeiShuLiang=ShuLiang,@KongWeiCode=KongWeiCode,@ZxsId=ZxsId,@KongWeiZhuangTai=KongWeiZhuangTai,@PingTaiShuLiang=PingTaiShuLiang,@PingTaiShouKeStatus=PingTaiShouKeStatus FROM tbl_KongWei WHERE KongWeiId=@KongWeiId

	IF(@FS=''C'' AND @ShouKeStatus=1)	
	BEGIN
		SET @RetCode=-97--�ֶ�ͣ��
		RETURN @RetCode
	END	
	
	IF(@FS=''C'' AND @PingTaiShouKeStatus=1)
	BEGIN
		SET @RetCode=-94
		RETURN @RetCode
	END
	
	IF (@KongWeiZhuangTai=1)
	BEGIN
		SET @RetCode=-96--��λ�Ѻ������
		RETURN @RetCode
	END
	
	IF(@FS=''U'')
	BEGIN
		SELECT @YuanDingDanStatus=OrderStatus,@DingDanLaiYuan=XiaDanLeiXing,@YuanKeHuLxrId=BuyOperatorId FROM tbl_TourOrder WHERE OrderId=@DingDanId
		
		IF(@YuanDingDanStatus NOT IN(0,4,5,6))
		BEGIN
			SET @RetCode=-95--�ö���״̬��������������Ϣ
			RETURN @RetCode
		END	
	END
	
	SELECT @ZongZhanWeiShuLiang=ISNULL(SUM(Accounts),0) FROM tbl_TourOrder 
	WHERE IsDelete=''0'' AND TourId=@KongWeiId AND OrderStatus IN (0,1,4,5)
	
	SELECT @ShiJiChuPiaoShuLiang=ISNULL(SUM(A.ShuLiang),0) FROM tbl_PlanChuPiao AS A WHERE A.KongWeiId=@KongWeiID

	IF(@ZongZhanWeiShuLiang<@ShiJiChuPiaoShuLiang) SET @ZongZhanWeiShuLiang=@ShiJiChuPiaoShuLiang

	IF(@KongWeiShuLiang<@ZongZhanWeiShuLiang+@ZhanWeiShu)
	BEGIN
		SET @DingDanStatus=6--������λ��������״̬���Ϊ��������
	END
	
	IF(@PingTaiShuLiang<@ZongZhanWeiShuLiang+@ZhanWeiShu)
	BEGIN
		SET @DingDanStatus=6--������λ��������״̬���Ϊ��������
	END
	
	SELECT @JiHeShiJian=JiHeShiJian,@JiHeDiDian=@JiHeDiDian,@SongTuanXinXi=SongTuanXinXi,@MuDiDiJieTuanFangShi=MuDiDiJieTuanFangShi
	FROM tbl_Route WHERE RouteId=@RouteId
	
	BEGIN TRAN	
	
	IF(@FS=''C'')
	BEGIN
		SET @JiaoYiHao=dbo.fn_OrderCode(@KongWeiId)
		INSERT INTO [tbl_TourOrder]([OrderId],[OrderCode],[CompanyId]
			,[TourId],[BusinessType],[BusinessNature]
			,[Adults],[Childs],[Bears]
			,[Accounts],[BuyCompanyId],[BuyOperatorId]
			,[RouteId],[PriceDetials],[SumPrice]
			,[PriceRemark],[CongregationPlace],[CongregationTime]
			,[SendTourInfo],[WelcomeWay],[SpecialAskRemark]
			,[GroundRemark],[OperatoRemark],[OperatorId]
			,[OrderStatus],[SaveSeatDate],[IsDelete]
			,[IssueTime],[CheckMoney],[ReturnMoney]
			,[ReceivedMoney],[RefundMoney],[BiaoShiYanSe]
			,[ZxsId],[LatestOperatorId],[LatestTime]
			,[XiaDanLeiXing],[XianLuId],[YingErRenShu]
			,[BuZhanWeiRenShu],[ChengRenJiaGe],[ErTongJiaGe]
			,[QuanPeiJiaGe],[YingErJiaGe],[JiaJinE]
			,[JianJinE],[JiaBeiZhu],[JianBeiZhu]
			,[BuFangChaRenShu],[TuiFangChaRenShu],[BuFangChaJiaGe]
			,[TuiFangChaJiaGe],[DingDanJinE],[JiFen1]
			,[JiFen2],[XiaDanBeiZhu],[YuanYin1]
			,[YuanYin2],[JiaGeMingXi],[DingDanLxrXingMing]
			,[DingDanLxrShouJi],[DingDanLxrDianHua],[DingDanLxrFax])
		VALUES(@DingDanId,@JiaoYiHao,@CompanyId
			,@KongWeiId,@YeWuLeiXing,0
			,@ChengRenShu,@ErTongShu,@QuanPeiShu
			,@ZhanWeiShu,@KeHuId,@KeHuLxrId
			,@RouteId,'''',@JinE
			,'''',@JiHeDiDian,@JiHeShiJian
			,@SongTuanXinXi,@MuDiDiJieTuanFangShi,''''
			,'''','''',@OperatorId
			,@DingDanStatus,NULL,''0''
			,@IssueTime,0,0
			,0,0,''''
			,@ZxsId,@OperatorId,@IssueTime
			,@DingDanLaiYuan,@XianLuId,@YingErShu
			,@BuZhanWeiShu,@ChengRenJiaGe,@ErTongJiaGe
			,@QuanPeiJiaGE,@YingErJiaGe,0
			,0,'''',''''
			,@BuFangChaShu,@TuiFangChaShu,@BuFangChaJiaGe
			,@TuiFangChaJiaGe,@DingDanJinE,@JiFen1
			,@JiFen2,@XiaDanBeiZhu,''''
			,'''',@JiaGeMingXi,@DingDanLxrXingMing
			,@DingDanLxrShouJi,@DingDanLxrDianHua,@DingDanLxrFax)
		SET @errorcount=@errorcount+@@error
	END
	
	IF(@FS=''U'')
	BEGIN
		UPDATE tbl_TourOrder SET [Adults]=@ChengRenShu,[Childs]=@ErTongShu
			,[YingErRenShu]=@YingErShu,[Bears]=@QuanPeiShu
			,[BuZhanWeiRenShu]=@BuZhanWeiShu,[Accounts]=@ZhanWeiShu
			,[BuFangChaRenShu]=@BuFangChaShu,[TuiFangChaRenShu]=@TuiFangChaShu
			,[DingDanJinE]=@DingDanJinE,[SumPrice]=@JinE
			,[JiFen2]=@JiFen2,[JiaGeMingXi]=@JiaGeMingXi
			,[DingDanLxrXingMing]=@DingDanLxrXingMing,[DingDanLxrShouJi]=@DingDanLxrShouJi
			,[DingDanLxrDianHua]=@DingDanLxrDianHua,[DingDanLxrFax]=@DingDanLxrFax
			,[XiaDanBeiZhu]=@XiaDanBeiZhu,OrderStatus=@DingDanStatus
		WHERE OrderId=@DingDanId
		SET @errorcount=@errorcount+@@error
	END
	
	DECLARE @TEMP1 TABLE(YouKeId char(36),YouKeXingMing nvarchar(50)
		,YouKeLeiXing tinyint,YouKeZhengJianLeiXing tinyint,YouKeZhengJianHaoMa nvarchar(50)
		,YouKeXingBie tinyint,YouKeLianXiFangShi nvarchar(255),YouKeStatus tinyint
		,YouKeChuPiaoSatus tinyint,T1 CHAR(1))
	
	IF(@YouKeXml IS NOT NULL AND LEN(@YouKeXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@YouKeXml
		INSERT INTO @TEMP1(YouKeId,YouKeXingMing
			,YouKeLeiXing,YouKeZhengJianLeiXing,YouKeZhengJianHaoMa
			,YouKeXingBie,YouKeLianXiFangShi,YouKeStatus
			,YouKeChuPiaoSatus,T1)
		SELECT YouKeId,YouKeXingMing
			,YouKeLeiXing,YouKeZhengJianLeiXing,YouKeZhengJianHaoMa
			,YouKeXingBie,YouKeLianXiFangShi,0
			,0,''C''
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(YouKeId char(36),YouKeXingMing nvarchar(50)
			,YouKeLeiXing tinyint,YouKeZhengJianLeiXing tinyint,YouKeZhengJianHaoMa nvarchar(50)
			,YouKeXingBie tinyint,YouKeLianXiFangShi nvarchar(255))
		EXEC sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP1 SET T1=''U'' WHERE YouKeId IN(SELECT [TravellerId] FROM [tbl_TourOrderTraveller] WHERE OrderId=@DingDanId)
	SET @errorcount=@errorcount+@@error	

	--�����ο�
	INSERT INTO [tbl_TourOrderTraveller]([TravellerId],[OrderId],[TourId]
		,[TravellerName],[TravellerType],[CardType]
		,[CardNumber],[Gender],[Contact]
		,[Status],[TicketType])
	SELECT YouKeId,@DingDanId,@KongWeiId
		,YouKeXingMing,YouKeLeiXing,YouKeZhengJianLeiXing
		,YouKeZhengJianHaoMa,YouKeXingBie,YouKeLianXiFangShi
		,YouKeStatus,YouKeChuPiaoSatus
	FROM @TEMP1 WHERE T1=''C''
	SET @errorcount=@errorcount+@@error
	
	--�޸��ο�
	UPDATE tbl_TourOrderTraveller SET [TravellerName]=B.YouKeXingMing
		,[TravellerType]=B.YouKeLeiXing,[CardType]=B.YouKeZhengJianLeiXing
		,[CardNumber]=B.YouKeZhengJianHaoMa,[Gender]=B.YouKeXingBie
		,[Contact]=B.YouKeLianXiFangShi
	FROM tbl_TourOrderTraveller AS A INNER JOIN @TEMP1 AS B
	ON A.[TravellerId]=B.[YouKeId] AND B.T1=''U''
	WHERE A.OrderId=@DingDanId
	SET @errorcount=@errorcount+@@error
	
	--ɾ���ο�
	DELETE FROM tbl_TourOrderTraveller WHERE OrderId=@DingDanId
	AND TravellerId NOT IN(SELECT YouKeId FROM @TEMP1)
	AND Status=0 AND TicketType=0
	SET @errorcount=@errorcount+@@error
	
	--���ִ���
	IF(@FS=''U'' AND @DingDanLaiYuan=0)
	BEGIN
		SELECT @YuanJiFenYongHuId=YongHuId FROM tbl_CustomerContactInfo WHERE ID=@YuanKeHuLxrId
	END
	
	SELECT @JiFenYongHuId=YongHuId FROM tbl_CustomerContactInfo WHERE ID=@KeHuLxrId
	DECLARE @JiFenMingXiId INT
	SET @JiFenMingXiId=0
	SELECT @JiFenMingXiId=IdentityId FROM [tbl_Pt_YongHuJiFenMingXi] WHERE CompanyId=@CompanyId AND [YongHuId]=@YuanJiFenYongHuId AND [GuanLianLeiXing]=0 AND GuanLianId=@DingDanId AND [Status]<>3

	IF(@JiFenYongHuId IS NOT NULL AND @JiFenYongHuId>0)
	BEGIN
		IF (@JiFenMingXiId>0)
		BEGIN
			IF(@JiFen2>0)
			BEGIN
				UPDATE [tbl_Pt_YongHuJiFenMingXi] SET JiFen=@JiFen2,YongHuId=@JiFenYongHuId WHERE IdentityId=@JiFenMingXiId
				SET @errorcount=@errorcount+@@error			
			END
			ELSE
			BEGIN
				UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [Status]=3 WHERE IdentityId=@JiFenMingXiId
				SET @errorcount=@errorcount+@@error
			END
		END
		ELSE
		BEGIN
			IF(@JiFen2>0)
			BEGIN
				INSERT INTO [tbl_Pt_YongHuJiFenMingXi]([CompanyId],[YongHuId],[JiFen]
					,[Status],[IssueTime],[GuanLianLeiXing]
					,[GuanLianId],[ShengXiaoShiJian])
				VALUES(@CompanyId,@JiFenYongHuId,@JiFen2
					,0,@IssueTime,0
					,@DingDanId,NULL)
				SET @errorcount=@errorcount+@@error
			END
		END
	END
	ELSE
	BEGIN
		IF(@JiFenMingXiId>0)
		BEGIN
			UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [Status]=3 WHERE IdentityId=@JiFenMingXiId
			SET @errorcount=@errorcount+@@error
		END
	END
	
	DECLARE @JiFenHandlerRetCode INT
	EXEC proc_YongHu_JiFen_Handler @YongHuId=@YuanJiFenYongHuId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
	EXEC proc_YongHu_JiFen_Handler @YongHuId=@JiFenYongHuId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
	
	DECLARE @JiHuaStatusHandlerRetCode INT
	EXEC proc_WeiHuKongWeiStatus @TourId=@KongWeiId,@Result=@JiHuaStatusHandlerRetCode OUTPUT	
	
	IF(@errorcount<>0)
	BEGIN
		SET @RetCode=-100
		ROLLBACK TRAN
		RETURN @RetCode
	END

	SET @RetCode=1
	COMMIT TRAN

	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	���û��ֶ���״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenDingDan_SheZhiStatus]
	@DingDanId char(36)
	,@Status tinyint
	,@KuaiDi nvarchar(255)
	,@FuKuanShiJian datetime
	,@FuKuanJinE money
	,@FuKuanFangShi tinyint
	,@FuKuanZhangHao nvarchar(255)
	,@FuKuanDuiFangDanWei nvarchar(255)
	,@FuKuanBeiZhu nvarchar(255)
	,@FuKuanStatus tinyint
	,@OperatorId INT
	,@IssueTime DATETIME
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @YuanDingDanStatus TINYINT
	DECLARE @YuanFuKuanStatus TINYINT
	DECLARE @XiaDanRenId INT
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_JiFenDingDan WHERE DingDanId=@DingDanId)
	BEGIN
		SET @RetCode=-99--����������
		RETURN @RetCode
	END
	
	SELECT @YuanDingDanStatus=[Status],@YuanFuKuanStatus=FuKuanStatus FROM tbl_Pt_JiFenDingDan WHERE DingDanId=@DingDanId	
	--dingdan status:[0:δȷ��] [1:��ȷ��] [2:�ѷ���] [3:��ȡ��]
	--fukuan status:[0:δ����] [1:δ֧��] [2:��֧��]
	
	IF(@YuanFuKuanStatus<>0)
	BEGIN
		SET @RetCode=-98--���������������ܱ������״̬
		RETURN @RetCode
	END
	
	SELECT @XiaDanRenId=XiaDanREnId FROM tbl_Pt_JiFenDingDan WHERE DingDanId=@DingDanId
	
	UPDATE tbl_Pt_JiFenDingDan SET [Status]=@Status,[LatestOperatorId]=@OperatorId,[LatestTime]=@IssueTime WHERE DingDanId=@DingDanId
	
	IF(@Status=2)
	BEGIN
		UPDATE [tbl_Pt_JiFenDingDan] SET [KuaiDi]=@KuaiDi,[FuKuanShiJian]=@FuKuanShiJian
			,[FuKuanJinE]=@FuKuanJinE,[FuKuanFangShi]=@FuKuanFangShi
			,[FuKuanZhangHao]=@FuKuanZhangHao,[FuKuanDuiFangDanWei]=@FuKuanDuiFangDanWei
			,[FuKuanBeiZhu]=@FuKuanBeiZhu,[FuKuanOperatorId]=@OperatorId
			,[FuKuanTime]=@IssueTime,[FuKuanStatus]=@FuKuanStatus
		WHERE [DingDanId]=@DingDanId
		
		UPDATE tbl_Pt_YongHuJiFenMingXi SET [Status]=1,ShengXiaoShiJian=@IssueTime WHERE GuanLianLeiXing=1 AND GuanLianId=@DingDanId
	END
	ELSE IF(@Status=3)
	BEGIN
		UPDATE tbl_Pt_YongHuJiFenMingXi SET [Status]=2,ShengXiaoShiJian=@IssueTime WHERE GuanLianLeiXing=1 AND GuanLianId=@DingDanId
	END
	ELSE
	BEGIN
		UPDATE tbl_Pt_YongHuJiFenMingXi SET [Status]=0,ShengXiaoShiJian=@IssueTime WHERE GuanLianLeiXing=1 AND GuanLianId=@DingDanId
	END
	
	INSERT INTO [tbl_Pt_JiFenDingDanLiShiLiShi]([DingDanId],[Status],[FuKuanStatus]
		,[BeiZhu],[OperatorId],[IssueTime]
		,[MiaoShu])
	VALUES(@DingDanId,@Status,@FuKuanStatus
		,'''',@OperatorId,@IssueTime
		,''�޸Ķ���״̬'')
		
	
	DECLARE @JiFenHandlerRetCode INT
	EXEC proc_YongHu_JiFen_Handler @YongHuId=@XiaDanRenId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
		
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenDingDan_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenDingDan_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	���ֶ����������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenDingDan_CU]
	@DingDanId char(36)
	,@CompanyId int
	,@ShangPinId char(36)
	,@ShuLiang int
	,@JiFen1 int
	,@JiFen2 INT
	,@Status tinyint
	,@LxrXingMing nvarchar(255)
	,@LxrDianHua nvarchar(255)
	,@LxrShouJi NVARCHAR(255)
	,@LxrYouXiang NVARCHAR(255)
	,@LxrProvinceId int
	,@LxrCityId int
	,@LxrDiZhi nvarchar(255)
	,@LxrYouBian NVARCHAR(255)
	,@XiaDanBeiZhu nvarchar(255)
	,@XiaDanRenId int
	,@OperatorId INT
	,@IssueTime datetime
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @YuanDingDanStatus TINYINT
	DECLARE @ShangPinStatus TINYINT
	DECLARE @FS NVARCHAR(50)--INSERT UPDATE
	DECLARE @YuanJiFen INT
	DECLARE @KeYongJiFen INT
	
	SET @errorcount=0
	SET @RetCode=0
	SET @FS=''INSERT''
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_JiFenShangPin WHERE ShangPinId=@ShangPinId AND CompanyId=@CompanyId AND IsDelete=''0'')
	BEGIN
		SET @RetCode=-99--��Ʒ��Ϣ������
		RETURN @RetCode
	END	
	
	SELECT @ShangPinStatus=[Status] FROM tbl_Pt_JiFenShangPin WHERE ShangPinId=@ShangPinId
	
	IF EXISTS(SELECT 1 FROM tbl_Pt_JiFenDingDan WHERE DingDanId=@DingDanId)
	BEGIN
		SET @FS=''UPDATE''
	END
	
	IF(@FS=''INSERT'')
	BEGIN
		IF(@ShangPinStatus<>0)
		BEGIN
			SET @RetCode=-98--��Ʒ���¼�
			RETURN @RetCode
		END
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		SELECT @YuanDingDanStatus=[Status],@YuanJiFen=JiFen2 FROM [tbl_Pt_JiFenDingDan] WHERE [DingDanId]=@DingDanId
		
		IF(@YuanDingDanStatus NOT IN(0))
		BEGIN
			SET @RetCode=-97--����״̬������δ�������޸Ķ���
			RETURN @RetCode
		END
	END
	
	SELECT @KeYongJiFen=KeYongJiFen FROM tbl_CompanyUser WHERE Id=@XiaDanRenId
	
	IF(@FS=''INSERT'')
	BEGIN
		IF(@KeYongJiFen<@JiFen2)
		BEGIN
			SET @RetCode=-96--���ֲ���
			RETURN @RetCode
		END
	END
	
	IF(@FS=''UPDATE'')
	BEGIN
		IF(@KeYongJiFen+@YuanJiFen<@JiFen2)
		BEGIN
			SET @RetCode=-95--���ֲ���
			RETURN @RetCode
		END
	END
	
	
	BEGIN TRAN
	IF (@FS=''INSERT'')
	BEGIN		
		INSERT INTO [tbl_Pt_JiFenDingDan]([DingDanId],[CompanyId],[ShangPinId]
			,[JiaoYiHao],[ShuLiang],[JiFen1],[JiFen2]
			,[Status],[LxrXingMing],[LxrDianHua]
			,[LxrShouJi],[LxrYouXiang]
			,[LxrProvinceId],[LxrCityId],[LxrDiZhi]
			,[LxrYouBian]
			,[XiaDanBeiZhu],[XiaDanRenid],[IssueTime]
			,[LatestOperatorId],[LatestTime])
		VALUES(@DingDanId,@CompanyId,@ShangPinId
			,dbo.[fn_Pt_CreateJiFenDingDanJiaoYiHao](@CompanyId),@ShuLiang,@JiFen1,@JiFen2
			,@Status,@LxrXingMing,@LxrDianHua
			,@LxrShouJi,@LxrYouXiang
			,@LxrProvinceId,@LxrCityId,@LxrDiZhi
			,@LxrYouBian
			,@XiaDanBeiZhu,@XiaDanRenid,@IssueTime
			,@XiaDanRenId,@IssueTime)
		SET @errorcount=@errorcount+@@ERROR
		
		INSERT INTO [tbl_Pt_YongHuJiFenMingXi]([CompanyId],[YongHuId],[JiFen]
			,[Status],[IssueTime],[GuanLianLeiXing]
			,[GuanLianId],[ShengXiaoShiJian])
		VALUES(@CompanyId,@OperatorId,@JiFen2
			,0,@IssueTime,1
			,@DingDanId,NULL)
		SET @errorcount=@errorcount+@@ERROR
		
		INSERT INTO [tbl_Pt_JiFenDingDanLiShiLiShi]([DingDanId],[Status],[FuKuanStatus]
			,[BeiZhu],[OperatorId],[IssueTime]
			,[MiaoShu])
		VALUES(@DingDanId,@Status,0
			,'''',@OperatorId,@IssueTime
			,''�û��µ�'')
		SET @errorcount=@errorcount+@@ERROR
	END
	
	IF(@FS=''UPDATE'')
	BEGIN		
		UPDATE [tbl_Pt_JiFenDingDan]SET [ShuLiang]=@ShuLiang,[JiFen1]=@JiFen1,[JiFen2]=@JiFen2,[LxrXingMing]=@LxrXingMing
			,[LxrDianHua]=@LxrDianHua,[LxrProvinceId]=@LxrProvinceId,[LxrCityId]=@LxrCityId
			,[LxrDiZhi]=@LxrDiZhi,[XiaDanBeiZhu]=@XiaDanBeiZhu,[LatestOperatorId]=@OperatorId
			,[LatestTime]=@IssueTime,LxrShouJi=@LxrShouJi,LxrYouXiang=@LxrYouXiang
			,LxrYouBian=@LxrYouBian
		WHERE [DingDanId]=@DingDanId
		SET @errorcount=@errorcount+@@ERROR
		
		UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [JiFen]=@JiFen2 WHERE GuanLianLeiXing=1 AND GuanLianId=@DingDanId
		SET @errorcount=@errorcount+@@ERROR
		
		INSERT INTO [tbl_Pt_JiFenDingDanLiShiLiShi]([DingDanId],[Status],[FuKuanStatus]
			,[BeiZhu],[OperatorId],[IssueTime]
			,[MiaoShu])
		VALUES(@DingDanId,@YuanDingDanStatus,0
			,'''',@OperatorId,@IssueTime
			,''�޸Ķ���'')
		SET @errorcount=@errorcount+@@ERROR
	END	
	
	IF(@errorcount=0)
	BEGIN
		DECLARE @JiFenHandlerRetCode INT
		EXEC proc_YongHu_JiFen_Handler @YongHuId=@XiaDanRenId,@KeHuLxrId=0,@RetCode=@JiFenHandlerRetCode OUTPUT
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END
	
	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  View [dbo].[view_Fin_TuanDuiJieSuan]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_Fin_TuanDuiJieSuan]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		����־
-- Create date: 2013-01-15
-- Description:�Ŷӽ�����ͼ
-- History:
-- 1.2013-02-27 ����־ ����[KongWeiZhuangTai]
-- =============================================
CREATE VIEW [dbo].[view_Fin_TuanDuiJieSuan]
AS
SELECT A.KongWeiId
	,A.CompanyId
	,A.KongWeiType
	,A.KongWeiCode
	,A.IsChuTuan
	,A.ShuLiang
	--ռλ����
	,(SELECT ISNULL(SUM(A1.Accounts),0) FROM tbl_TourOrder AS A1 WHERE A1.TourId=A.KongWeiId AND A1.OrderStatus=1 AND IsDelete=''0'') AS ZhanWeiShuLiang
	,A.Status
	,A.AreaId
	,(SELECT A1.AreaName FROM tbl_Area AS A1 WHERE A1.Id=A.AreaId) AS AreaName
	,A.QuDate
	,A.QuJiaoTongId
	,(SELECT A1.TrafficName FROM tbl_CompanyTraffic AS A1 WHERE A1.Id=A.QuJiaoTongId) AS QuJiaoTongName
	,A.QuDepProvinceId
	,A.QuDepCityId
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.QuDepCityId) AS QuDepCityName
	,A.QuArrProvinceId
	,A.QuArrCityId
	,(SELECT A1.CityName FROM tbl_CompanyCity AS A1 WHERE A1.Id=A.QuArrCityId) AS QuArrCityName
	,A.IssueTime
	--������
	,(SELECT ISNULL(SUM(JinE),0) FROM view_Fin_KongWeiShouRu AS A1 WHERE A1.KongWeiId=A.KongWeiId) AS ShouRuJinE
	--֧�����
	,(SELECT ISNULL(SUM(JinE),0) FROM view_Fin_KongWeiZhiChu AS A1 WHERE A1.KongWeiId=A.KongWeiId) AS ZhiChuJinE
	--����������
	,(SELECT ISNULL(SUM(Proceed),0) FROM tbl_FinOther AS A1 WHERE A1.TourId=A.KongWeiId AND A1.CostType=0) AS QiTaShouRuJinE
	--����֧�����
	,(SELECT ISNULL(SUM(Proceed),0) FROM tbl_FinOther AS A1 WHERE A1.TourId=A.KongWeiId AND A1.CostType=1) AS QiTaZhiChuJinE
	,A.KongWeiZhuangTai
	,A.ZxsId
FROM [tbl_KongWei] AS A 
WHERE A.IsDelete=''0''

'
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_SheZhiZhuangTai]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_SheZhiZhuangTai]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-11
-- Description:	���ÿ�λ״̬
-- =============================================
CREATE PROCEDURE [dbo].[proc_KongWei_SheZhiZhuangTai]
	@KongWeiId CHAR(36)
	,@CompanyId INT
	,@ZxsId CHAR(36)
	,@ZhuangTai TINYINT
	,@IssueTime DATETIME
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @YuanZhuangTai TINYINT
	SET @RetCode=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND CompanyId=@CompanyId AND ZxsId=@ZxsId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	SELECT @YuanZhuangTai=KongWeiZhuangTai FROM tbl_KongWei WHERE KongWeiId=@KongWeiId
	
	IF(@YuanZhuangTai=@ZhuangTai)
	BEGIN
		SET @RetCode=1
		RETURN @RetCode
	END
	
	UPDATE tbl_KongWei SET KongWeiZhuangTai=@ZhuangTai WHERE KongWeiId=@KongWeiId
	
	DECLARE @TEMP TABLE(DingDanId CHAR(36),KeHuLxrId INT,IdentityId INT IDENTITY)
	INSERT INTO @TEMP(DingDanId,KeHuLxrId)
	SELECT OrderId,BuyOperatorId FROM tbl_TourOrder 
	WHERE TourId=@KongWeiId AND IsDelete=''0'' AND OrderStatus=1	
	
	IF(@ZhuangTai=0)--�������������Ϊ����
	BEGIN
		UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [Status]=0,[ShengXiaoShiJian]=@IssueTime
		FROM [tbl_Pt_YongHuJiFenMingXi] AS A INNER JOIN @TEMP AS B
		ON A.[GuanLianId]=B.DingDanId
		WHERE A.[GuanLianLeiXing]=0 AND A.Status=1
	END
	
	IF(@ZhuangTai=1)--����������������Ϊ��Ч
	BEGIN		
		UPDATE [tbl_Pt_YongHuJiFenMingXi] SET [Status]=1,[ShengXiaoShiJian]=@IssueTime
		FROM [tbl_Pt_YongHuJiFenMingXi] AS A INNER JOIN @TEMP AS B
		ON A.[GuanLianId]=B.DingDanId
		WHERE A.[GuanLianLeiXing]=0 AND A.Status=0
	END
	
	DECLARE @DingDanShuLiang INT
	DECLARE @i INT
	
	SELECT @DingDanShuLiang=COUNT(*) FROM @TEMP
	SET @i=0
	
	WHILE(@i<@DingDanShuLiang)--ͬ���û�����
	BEGIN
		DECLARE @JiFenHandlerRetCode INT
		DECLARE @KeHuLxrId INT
		SELECT @KeHuLxrId=KeHuLxrId FROM @TEMP WHERE IdentityId=@i+1
		EXEC proc_YongHu_JiFen_Handler @YongHuId=0,@KeHuLxrId=@KeHuLxrId,@RetCode=@JiFenHandlerRetCode OUTPUT
		SET @i=@i+1
	END
	
	SET @RetCode=1
	RETURN @RetCode	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TourOrderHotel_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_TourOrderHotel_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-15>
-- Description:	<��Ӵ����Ƶ�>
-- History:
-- 1.����־ 2013-01-22 ����@PlanHotelMxXML
-- =============================================
CREATE proc [dbo].[proc_TourOrderHotel_Add]
	@KongWeiId char(36)--��λ���
	,@CompanyId int--��˾���
	,@BusinessType tinyint--ҵ������
	,@BusinessNature tinyint--ҵ������
	,@OrderId char(36)--�������
	,@QuDate datetime--��������
	,@Adults int--������
	,@Childs int--��ͯ��
	,@BuyCompanyId char(36)--�ͻ���λ
	,@BuyOperatorId int--�Է�������
	,@PriceDetials varchar(max)--�۸���ϸ
	,@SumPrice MONEY--�ϼƽ��
	,@PriceRemark varchar(max)--�۸�ע
	,@SpecialAskRemark varchar(max)--����Ҫ��
	,@OperatoRemark varchar(max)--������ע
	,@OperatorId int--����Ա
	,@YouKeXml NVARCHAR(MAX)--�����ο�XML
	,@JiuDianAnPaiXml NVARCHAR(MAX)--�������Ŷ�XML
	,@Result int output
	,@PlanHotelMxXML NVARCHAR(MAX)--�Ƶ갲����ϸ��ϢXML:<root><info KognWeiId="" OrderId="" AnPaiId="" RuZhuTime="" TuiFangTime="" FangXing="" YaoQiuBeiZhu="" JianYe="" QuFangFangShi="" JiuDianName="" /></root>
	,@ZxsId CHAR(36)
	,@LatestOperatorId INT
	,@LatestTime DATETIME	
as
begin
	declare @error int
	set @error=0	
	DECLARE @hdoc INT
	DECLARE @KongWeiCode NVARCHAR(50)
	DECLARE @OrderCode NVARCHAR(50)

	begin transaction
	--���ɿ�λ��
	set @KongWeiCode=dbo.fn_KongWeiCode(@QuDate,@CompanyId,@ZxsId)

	INSERT INTO tbl_KongWei(KongWeiId,CompanyId,KongWeiType,KongWeiCode
		,ShuLiang,Status,QuDate,OperatorId,IssueTime
		,MoBanId,ZxsId)
	VALUES(@KongWeiId,@CompanyId,@BusinessType,@KongWeiCode
		,@Adults+@Childs,2,@QuDate,@OperatorId,@LatestTime
		,NEWID(),@ZxsId)
	set @error=@error+@@error	

	--���ɶ�����
	set @OrderCode=dbo.fn_OrderCode(@KongWeiId)

	INSERT INTO tbl_TourOrder(OrderId,OrderCode,CompanyId
		,TourId,BusinessType,BusinessNature
		,Adults,Childs,Accounts
		,BuyCompanyId,BuyOperatorId,PriceDetials
		,SumPrice,PriceRemark,SpecialAskRemark
		,OperatoRemark,OperatorId,OrderStatus
		,RouteId,ZxsId,IssueTime
		,LatestTime,LatestOperatorId)
     VALUES(@OrderId,@OrderCode,@CompanyId
		,@KongWeiId,@BusinessType,@BusinessNature
		,@Adults,@Childs,@Adults+@Childs
		,@BuyCompanyId,@BuyOperatorId,@PriceDetials
		,@SumPrice,@PriceRemark,@SpecialAskRemark
		,@OperatoRemark,@OperatorId,1
		,'''',@ZxsId,@LatestTime
		,@LatestTime,@LatestOperatorId)
	set @error=@error+@@error
	
	if(@YouKeXml is not null AND LEN(@YouKeXml)>0)
	begin
		exec sp_xml_preparedocument @hdoc output,@YouKeXml
		INSERT INTO tbl_TourOrderTraveller(TravellerId,OrderId,TourId
			,TravellerName,TravellerType,CardType
			,CardNumber,Gender,Contact
			,Status,TicketType)
		SELECT TravellerId,@OrderId,@KongWeiId
			,TravellerName,TravellerType,CardType
			,CardNumber,Gender,Contact
			,Status,TicketType 
		from openxml(@hdoc,''/root/info'',3)
		with(TravellerId char(36),TravellerName nvarchar(50),TravellerType tinyint
			,CardType tinyint,CardNumber nvarchar(50),Gender tinyint
			,Contact nvarchar(255),Status tinyint,TicketType tinyint)
		set @error=@error+@@error
		exec sp_xml_removedocument @hdoc
	end
	
	if(@JiuDianAnPaiXml is not null AND LEN(@JiuDianAnPaiXml)>0)
	begin
		exec sp_xml_preparedocument @hdoc output,@JiuDianAnPaiXml
		
		DECLARE @TEMP1 TABLE(Id char(36),CheckInDate datetime,CheckOutDate datetime
			,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
			,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
			,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
			,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100)
			,IDENTITYID INT IDENTITY)
			
		INSERT INTO @TEMP1(Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo)
		SELECT Id,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
		FROM openxml(@hdoc,''/root/info'',3)
		with(Id char(36),CheckInDate datetime,CheckOutDate datetime
			,Room nvarchar(255),Remark nvarchar(max),RoomNights nvarchar(255)
			,HumorWas nvarchar(max),HotelName nvarchar(100),GYSId char(36)
			,SideOperatorId int,SettleDetail nvarchar(max),SettleAmount money
			,PlanRemark nvarchar(max),PlanDetail nvarchar(max),FileInfo nvarchar(100))		
		exec sp_xml_removedocument @hdoc
		
		INSERT INTO tbl_TourOrderHotelPlan(Id,OrderId,TourId
			,CompanyId,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
            ,PlanRemark,PlanDetail,FileInfo)
		SELECT Id,@OrderId,@KongWeiId
			,@CompanyId,CheckInDate,CheckOutDate
			,Room,Remark,RoomNights
			,HumorWas,HotelName,GYSId
			,SideOperatorId,SettleDetail,SettleAmount
			,PlanRemark,PlanDetail,FileInfo
		FROM @TEMP1 ORDER BY IdentityId ASC
		set @error=@error+@@error
		
		--���Ž��׺Ŵ���
		DECLARE @count INT
		DECLARE @index INT
		SELECT @count=COUNT(*) FROM @TEMP1
		SET @index=1
		
		WHILE(@index<=@count)
		BEGIN
			DECLARE @TempId CHAR(36)
			SELECT @TempId=Id FROM @TEMP1 WHERE IdentityId=@index
			DECLARE @JiaoYiHao nvarchar(50)
			
			SET @JiaoYiHao= @KongWeiCode+''D''+dbo.fn_PadLeft(@index,0,2)
			
			update tbl_TourOrderHotelPlan set JiaoYiHao=@JiaoYiHao
			where Id=@TempId
			
			SET @index=@index+1
		END
	end	

	--�Ƶ갲����ϸ��Ϣ����
	IF(@error=0 AND LEN(@PlanHotelMxXml)>13)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@PlanHotelMxXml
		INSERT INTO [tbl_PlanHotelMX]([AnPaiId],[KongWeiId],[OrderId],[RuZhuTime]
			,[TuiFangTime],[FangXing],[YaoQiuBeiZhu],[JianYe]
			,[QuFangFangShi],[JiuDianName],[IssueTime],[IsDelete])
		SELECT A.AnPaiId,A.KongWeiId,A.OrderId,A.RuZhuTime
			,A.TuiFangTime,A.FangXing,A.YaoQiuBeiZhu,A.JianYe
			,A.QuFangFangShi,A.JiuDianName,@LatestTime,''0''
		FROM OPENXML(@hdoc,''/root/info'',3)
		WITH(KongWeiId CHAR(36),OrderId CHAR(36),AnPaiId CHAR(36),RuZhuTime DATETIME,TuiFangTime DATETIME,FangXing NVARCHAR(255),YaoQiuBeiZhu NVARCHAR(255),JianYe NVARCHAR(255),QuFangFangShi NVARCHAR(255),JiuDianName NVARCHAR(255)) AS A

		EXECUTE sp_xml_removedocument @hdoc
		set @error=@error+@@error
	END
	
	IF(@error<>0)
	BEGIN
		set @Result=-100
		rollback transaction
		RETURN @Result
	END

	set @Result=1
	commit transaction

	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanDiJie_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanDiJie_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2011-11-16>
-- Description:	<��ӵؽӰ���>
--Result:
-- -1:�Ѿ����ŵؽӵĶ��� �������°���
-- -2:����������Ϊ�Ŷ�ʱ��һ��ֻ��ѡ��һ���������еؽӰ���
-- -3:����������Ϊɢƴʱ����ѡ����ͬ��·�µĶ���������еؽӰ���
-- 1:���ųɹ� 
-- 0:����ʧ��
-- History:
-- 1.2013-01-15 ����־ ȥ�����ε�����
-- 2.2013-01-24 ����־ ����@YouKeXinXi
-- 3.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���	
-- =============================================
CREATE proc [dbo].[proc_PlanDiJie_Add]
	@PlanId char(36)
	,@CompanyId int
	,@KongWeiId char(36)
	,@JiaoYiHao nvarchar(50) 
	,@GysId char(36)
	,@RouteId char(36) 
	,@LxrName nvarchar(50)
	,@LxrTelephone nvarchar(50)
	,@ChengRenShu int
	,@ErTongShu int
	,@QuPeiShu int 
	,@QuPeiName nvarchar(50)
	--,@DaoYouId int
	,@YongCan nvarchar(255)
	,@JieSuanMX nvarchar(255) 
	,@JieSuanAmount money
	,@JieTuanFangShi nvarchar(255)
	,@OperatorId int
	,@Remark nvarchar(MAX)
	,@OrderIds nvarchar(max)
	,@Result int output
	,@YouKeXinXi NVARCHAR(MAX)--�ο���Ϣ
	,@ZxsId CHAR(36)
	,@YingErShu INT
as
begin
	declare @error int
	set @error=0

	if exists(select 1 from tbl_PlanDiJIeOrder where OrderId in (select [value] from dbo.fn_split(@OrderIds,'','')))
	begin
		set @Result=-1	  --�Ѿ����ŵؽӵĶ��� �������°���
		return @Result
	end

	declare @BusinessNature tinyint	--��������  ɢƴ = 0,���� = 1
	select @BusinessNature=BusinessNature from tbl_TourOrder 
	where OrderId=(select top 1 [value] from dbo.fn_split(@OrderIds,'',''))

	if(@BusinessNature=1)
	begin
		declare @tuanduiordercount int
		select @tuanduiordercount=count(1) from dbo.fn_split(@OrderIds,'','') 
		if(@tuanduiordercount<>1)
		begin
			set @Result=-2	  --����������Ϊ�Ŷ�ʱ��һ��ֻ��ѡ��һ���������еؽӰ���
			return @Result 
		end
	end

	if(@BusinessNature=0)
	begin
		declare @sanpinordercount int
--		 select @sanpinordercount= count(RouteId) from tbl_TourOrder 
--		 where OrderId in (select [value] from dbo.fn_split(@OrderIds,'',''))
--		 group by RouteId
		select @sanpinordercount=count(distinct(RouteId)) from tbl_TourOrder
		where OrderId in (select [value] from dbo.fn_split(@OrderIds,'',''))
		if(@sanpinordercount<>1)
		begin
			set @Result=-3	  --����������Ϊɢƴʱ����ѡ����ͬ��·�µĶ���������еؽӰ���
			return @Result 
		end
	end

	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	begin transaction	
	--���ɽ��׺ţ��źţ�
	set @JiaoYiHao=dbo.fn_TourCode(@KongWeiId)

	INSERT INTO tbl_PlanDiJie(PlanId,CompanyId,KongWeiId
		,JiaoYiHao,GysId,RouteId
		,LxrName,LxrTelephone,ChengRenShu
		,ErTongShu,QuPeiShu,QuPeiName
		,YongCan,JieSuanMX,JieSuanAmount
		,JieTuanFangShi,OperatorId,Remark
		,IssueTime,[YouKeXinXi],[ZxsId]
		,YingErShu)
     VALUES(@PlanId,@CompanyId,@KongWeiId
		,@JiaoYiHao,@GysId,@RouteId
		,@LxrName,@LxrTelephone,@ChengRenShu
		,@ErTongShu,@QuPeiShu,@QuPeiName
		,@YongCan,@JieSuanMX,@JieSuanAmount
		,@JieTuanFangShi,@OperatorId,@Remark
		,getdate(),@YouKeXinXi,@ZxsId
		,@YingErShu)
	set @error=@error+@@error

	IF(@error=0)
	BEGIN
		INSERT INTO tbl_PlanDiJIeOrder(PlanId,OrderId)
		select @PlanId,[value] from dbo.fn_split(@OrderIds,'','')
		set @error=@error+@@error
	END
	
	IF(@error<>0)
	BEGIN
		set @Result=0
		rollback transaction
		RETURN @Result
	END

	set @Result=1
	commit transaction
	
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<�޸Ŀ�λ>
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���	
-- 2.2014-07-18 ����־ ���̵���-�����������޸�ɾ����ʽ����·��Ʒ��Ϣ��
-- =============================================
CREATE proc [dbo].[proc_KongWei_Update]
	@KongWeiId char(36)--��λ���
	,@CompanyId int--��˾���
	,@ShuLiang int--��λ����
	,@AreaId int--��·������
	,@QuDate datetime--ȥ������
	,@QuJiaoTongId int--ȥ�̽�ͨ���
	,@QuDepProvinceId int--ȥ�̳���ʡ�ݱ��
	,@QuDepCityId int--ȥ�̳������б��
	,@QuArrProvinceId int--ȥ�̵���ʡ�ݱ��
	,@QuArrCityId int--ȥ�̵�����б��
	,@QuBanCi nvarchar(50)--ȥ�̰��
	,@QuTime nvarchar(50)--ȥ��ʱ��
	,@HuiDate datetime--�س�����
	,@HuiJiaoTongId int--�س̽�ͨ���
	,@HuiDepProvinceId int--�س̳���ʡ�ݱ��
	,@HuiDepCityId int--�س̳������б��
	,@HuiArrProvinceId int--�س̵���ʡ�ݱ��
	,@HuiArrCityId int--�س̵�����б��
	,@HuiBanCi nvarchar(50)--�س̰��
	,@HuiTime nvarchar(50)--�س�ʱ��
	,@OperatorId int--�����˱��
	,@DaiLiXml NVARCHAR(MAX)--��λ������XML
	,@Result int output--OUTPUT CODE
	,@TianShu INT--����
	,@ZxsId CHAR(36)--ר���̱��
	,@ZhanDianId INT--վ����
	,@ZxlbId INT--ר�������
	,@XianLuXml NVARCHAR(MAX)--��·��ƷXML
	,@PingTaiShuLiang INT--ƽ̨��λ����
as
begin
	declare @error int
	DECLARE @hdoc INT
	set @error=0
	DECLARE @YiZhanWeiRenShu INT--������ռλ����
	
	IF NOT EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND IsDelete=''0'')
	BEGIN
		SET @Result=-99
		RETURN @Result
	END

	--��������Ŀ�λ���޸�
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-98
		RETURN @Result
	END
	
	SELECT @YiZhanWeiRenShu=ISNULL(SUM(Accounts),0) FROM tbl_TourOrder
	WHERE TourId=@KongWeiId AND IsDelete=''0'' AND OrderStatus IN(0,1)	
	
	DECLARE @ShiFouXiuGaiDaiLiShangRenShu CHAR(1)--�Ƿ��޸Ĵ���������
	SET @ShiFouXiuGaiDaiLiShangRenShu=''Y''
	IF(@YiZhanWeiRenShu>@ShuLiang)--��ռλ����>����������
	BEGIN
		--SET @Result=-97
		--RETURN @Result	
		--SET @ShuLiang=@YiZhanWeiRenShu
		SET @ShiFouXiuGaiDaiLiShangRenShu=''N''
	END	
	
	DECLARE @TEMP1 TABLE(DaiLiId CHAR(36),GysId CHAR(36),GysOrderCode NVARCHAR(50)
		,LxrName NVARCHAR(50),LxrTelephone NVARCHAR(50),Price MONEY
		,ShuLiang INT,ShiXian NVARCHAR(50),Remark NVARCHAR(255)
		,MoBanId CHAR(36)
		,T1 CHAR(1)--������ʽ C:���� U:�޸�
		,T2 CHAR(1)--Y:�޸Ĵ����� N:���޸Ĵ�����
		,T3 CHAR(1)--Y:�޸����� N:���޸�����
		,T4 INT--��Ʊ����
	)
	
	EXEC sp_xml_preparedocument @hdoc OUTPUT,@DaiLiXml
	INSERT INTO @TEMP1(DaiLiId,GysId,GysOrderCode
		,LxrName,LxrTelephone,Price
		,ShuLiang,ShiXian,Remark
		,MoBanId,T1,T2
		,T3,T4)
	SELECT DaiLiId,GysId,GysOrderCode
		,LxrName,LxrTelephone,Price
		,ShuLiang,ShiXian,Remark
		,MoBanId,''U'',''Y''
		,''Y'',0
	FROM OPENXML(@hdoc,''/root/info'')
	WITH(DaiLiId CHAR(36),GysId CHAR(36),GysOrderCode NVARCHAR(50)
		,LxrName NVARCHAR(50),LxrTelephone NVARCHAR(50),Price MONEY
		,ShuLiang INT,ShiXian NVARCHAR(50),Remark NVARCHAR(255)
		,MoBanId CHAR(36))
	EXEC sp_xml_removedocument @hdoc
	
	UPDATE @TEMP1 SET T1=''C'' WHERE MoBanId NOT IN(SELECT MoBanId FROM tbl_KongWeiDaiLi WHERE KongWeiId=@KongWeiId)
	
	--��Ҫ�޸ĵİ�ģ�����޸Ĵ����̱��
	UPDATE @TEMP1 SET DaiLiId=B.DaiLiId 
	FROM @TEMP1 AS A INNER JOIN tbl_KongWeiDaiLi AS B ON A.MoBanId=B.MoBanId AND B.KongWeiId=@KongWeiId
	WHERE A.T1=''U''
	
	--��Ѻ��ǼǵĲ��޸Ĵ�����
	UPDATE @TEMP1 SET T2=''N''
	FROM @TEMP1 AS A 
	WHERE A.T1=''U'' AND EXISTS(SELECT 1 FROM tbl_KongWeiDaiLi AS A1 WHERE A1.KongWeiId=@KongWeiId AND A1.DaiLiId=A.DaiLiId AND A1.YaJinAmount<>0)
	--��Ʊ����
	UPDATE @TEMP1 SET T4=(SELECT ISNULL(SUM(ShuLiang),0) FROM tbl_PlanChuPiao AS A1 WHERE A1.DaiLiId=A.DaiLiId)
	FROM @TEMP1 AS A
	WHERE A.T1=''U''
	--��Ʊ����>�����Ĳ��޸�����
	UPDATE @TEMP1 SET T3=''N''
	FROM @TEMP1 AS A
	WHERE A.T1=''U'' AND A.ShuLiang<A.T4
	
	--�Ƿ��޸���������
	IF(@ShiFouXiuGaiDaiLiShangRenShu=''N'')
	BEGIN
		UPDATE @TEMP1 SET T3=''N''
		FROM @TEMP1 AS A
		WHERE A.T1=''U''
	END
	
	BEGIN TRAN
	--�޸Ĵ����̻�����Ϣ
	UPDATE tbl_KongWeiDaiLi SET GysOrderCode=B.GysOrderCode,LxrName=B.LxrName
		,LxrTelephone=B.LxrTelephone,Price=B.Price
		,ShiXian=B.ShiXian,Remark=B.Remark
	FROM tbl_KongWeiDaiLi AS A INNER JOIN @TEMP1 AS B
	ON A.DaiLiId=B.DaiLiId AND B.T1=''U''
	WHERE A.KongWeiId=@KongWeiId	
	set @error=@error+@@error
	--�޸Ĵ�����
	UPDATE tbl_KongWeiDaiLi SET GysId=B.GysId
	FROM tbl_KongWeiDaiLi AS A INNER JOIN @TEMP1 AS B
	ON A.DaiLiId=B.DaiLiId AND B.T1=''U'' AND B.T2=''Y''
	WHERE A.KongWeiId=@KongWeiId
	set @error=@error+@@error
	--�޸Ĵ���������
	UPDATE tbl_KongWeiDaiLi SET ShuLiang=B.ShuLiang
	FROM tbl_KongWeiDaiLi AS A INNER JOIN @TEMP1 AS B
	ON A.DaiLiId=B.DaiLiId AND B.T1=''U'' AND B.T3=''Y''
	WHERE A.KongWeiId=@KongWeiId
	set @error=@error+@@error
	
	--����������
	INSERT INTO tbl_KongWeiDaiLi(DaiLiId,CompanyId,KongWeiId
		,GysId,GysOrderCode,LxrName
		,LxrTelephone,Price,ShuLiang
		,ShiXian,Remark,MoBanId)
	SELECT DaiLiId,@CompanyId,@KongWeiId
		,GysId,GysOrderCode,LxrName
		,LxrTelephone,Price,ShuLiang
		,ShiXian,Remark,MoBanId 
	FROM @TEMP1
	WHERE T1=''C''
	set @error=@error+@@error
	
	--ɾ�������� ��Ѻ��Ǽǡ��г�Ʊ�Ĳ�ɾ��
	DELETE FROM tbl_KongWeiDaiLi
	WHERE KongWeiId=@KongWeiId 
		AND MoBanId NOT IN(SELECT MoBanId FROM @TEMP1)
		AND DaiLiId NOT IN(SELECT DaiLiId FROM @TEMP1)
		AND YaJinAmount=0
		AND NOT EXISTS(SELECT 1 FROM tbl_PlanChuPiao AS A WHERE A.KongWeiId=@KongWeiId AND A.DaiLiId=tbl_KongWeiDaiLi.DaiLiId)
	set @error=@error+@@error	
	
	--���¼�������
	SELECT @ShuLiang=SUM(ShuLiang) FROM tbl_KongWeiDaiLi
	WHERE KongWeiId=@KongWeiId AND IsDelete=''0''
	
	IF(@PingTaiShuLiang>@ShuLiang) SET @PingTaiShuLiang=@ShuLiang

	--�޸Ŀ�λ��Ϣ
	UPDATE tbl_KongWei SET ShuLiang =@ShuLiang,AreaId =@AreaId
      ,QuJiaoTongId =@QuJiaoTongId,QuDepProvinceId =@QuDepProvinceId
      ,QuDepCityId =@QuDepCityId,QuArrProvinceId =@QuArrProvinceId
      ,QuArrCityId =@QuArrCityId,QuBanCi =@QuBanCi,QuTime =@QuTime
      ,HuiDate =@HuiDate,HuiJiaoTongId =@HuiJiaoTongId,HuiDepProvinceId =@HuiDepProvinceId
      ,HuiDepCityId =@HuiDepCityId,HuiArrProvinceId =@HuiArrProvinceId,HuiArrCityId =@HuiArrCityId
      ,HuiBanCi =@HuiBanCi,HuiTime =@HuiTime,LatestTime =getdate()
      ,TianShu=@TianShu,ZhanDianId=@ZhanDianId,ZxlbId=@ZxlbId
      ,PingTaiShuLiang=@PingTaiShuLiang
	WHERE  KongWeiId =@KongWeiId
	set @error=@error+@@error
	
	DECLARE @TEMP2 TABLE([XianLuId] CHAR(36),[LeiXing] TINYINT
		,[RouteId] CHAR(36),[MenShiJiaGe1] MONEY,[MenShiJiaGe2] MONEY
		,[MenShiJiaGe3] MONEY,[JieSuanJiaGe1] MONEY,[JieSuanJiaGe2] MONEY
		,[JieSuanJiaGe3] MONEY,[QuanPeiJiaGe] MONEY,[BuFangChaJiaGe] MONEY
		,[TuiFangChaJiaGe] MONEY,[JiFen] INT,[Status] TINYINT
		,[PaiXuId] INT
		,T1 CHAR(1)----C:���� U:�޸�
	)
	
	IF(@error=0 AND @XianLuXml IS NOT NULL AND LEN(@XianLuXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@XianLuXml
		INSERT INTO @TEMP2([XianLuId],[LeiXing]
			,[RouteId],[MenShiJiaGe1],[MenShiJiaGe2]
			,[MenShiJiaGe3],[JieSuanJiaGe1],[JieSuanJiaGe2]
			,[JieSuanJiaGe3],[QuanPeiJiaGe],[BuFangChaJiaGe]
			,[TuiFangChaJiaGe],[JiFen],[Status]
			,[PaiXuId],[T1])
		SELECT [XianLuId],[LeiXing]
			,[RouteId],[MenShiJiaGe1],[MenShiJiaGe2]
			,[MenShiJiaGe3],[JieSuanJiaGe1],[JieSuanJiaGe2]
			,[JieSuanJiaGe3],[QuanPeiJiaGe],[BuFangChaJiaGe]
			,[TuiFangChaJiaGe],[JiFen],[Status]
			,[PaiXuId],''C''
		FROM OPENXML(@hdoc,''/root/info'')
		WITH([XianLuId] CHAR(36),[LeiXing] TINYINT
			,[RouteId] CHAR(36),[MenShiJiaGe1] MONEY,[MenShiJiaGe2] MONEY
			,[MenShiJiaGe3] MONEY,[JieSuanJiaGe1] MONEY,[JieSuanJiaGe2] MONEY
			,[JieSuanJiaGe3] MONEY,[QuanPeiJiaGe] MONEY,[BuFangChaJiaGe] MONEY
			,[TuiFangChaJiaGe] MONEY,[JiFen] INT,[Status] TINYINT
			,[PaiXuId] INT)
		EXEC sp_xml_removedocument @hdoc
	END
	
	UPDATE @TEMP2 SET XianLuId=B.XianLuId,T1=''U''
	FROM @TEMP2 AS A INNER JOIN tbl_Pt_KongWeiXianLu AS B
	ON A.RouteId=B.RouteId AND B.KongWeiId=@KongWeiId
	
	--�޸���·��Ʒ��Ϣ
	UPDATE tbl_Pt_KongWeiXianLu SET MenShiJiaGe1=B.MenShiJiaGe1
		,MenShiJiaGe2=B.MenShiJiaGe2,MenShiJiaGe3=B.MenShiJiaGe3
		,JieSuanJiaGe1=B.JieSuanJiaGe1,JieSuanJiaGe2=B.JieSuanJiaGe2
		,JieSuanJiaGe3=B.JieSuanJiaGe3,QuanPeiJiaGe=B.QuanPeiJiaGe
		,BuFangChaJiaGe=B.BuFangChaJiaGe,TuiFangChaJiaGe=B.TuiFangChaJiaGe
		,JiFen=B.JiFen,[Status]=B.[Status]
		,PaiXuId=B.PaiXuId		
	FROM tbl_Pt_KongWeiXianLu AS A INNER JOIN @TEMP2 AS B
	ON A.XianLuId=B.XianLuId AND B.T1=''U''
	WHERE A.KongWeiId=@KongWeiId
	set @error=@error+@@error
	
	--������·��Ʒ��Ϣ
	INSERT INTO [tbl_Pt_KongWeiXianLu]([XianLuId],[LeiXing],[KongWeiId]
		,[RouteId],[MenShiJiaGe1],[MenShiJiaGe2]
		,[MenShiJiaGe3],[JieSuanJiaGe1],[JieSuanJiaGe2]
		,[JieSuanJiaGe3],[QuanPeiJiaGe],[BuFangChaJiaGe]
		,[TuiFangChaJiaGe],[JiFen],[Status]
		,[PaiXuId],[XianLuCode])
	SELECT [XianLuId],[LeiXing],@KongWeiId
		,[RouteId],[MenShiJiaGe1],[MenShiJiaGe2]
		,[MenShiJiaGe3],[JieSuanJiaGe1],[JieSuanJiaGe2]
		,[JieSuanJiaGe3],[QuanPeiJiaGe],[BuFangChaJiaGe]
		,[TuiFangChaJiaGe],[JiFen],[Status]
		,[PaiXuId],''''
	FROM @TEMP2 WHERE T1=''C''
	set @error=@error+@@error
	UPDATE [tbl_Pt_KongWeiXianLu] SET [XianLuCode]=''CP''+CAST(YEAR(@QuDate) AS NVARCHAR(4))+dbo.fn_PadLeft(IdentityId,''0'',5) WHERE KongWeiId=@KongWeiId AND XianLuId IN(SELECT XianLuId FROM @TEMP2 WHERE T1=''C'')
	SET @error=@error+@@ERROR	
	
	--ɾ����·��Ʒ �ж����Ĳ�ɾ��
	DELETE FROM [tbl_Pt_KongWeiXianLu] WHERE XianLuId NOT IN(SELECT [XianLuId] FROM @TEMP2)
	AND XianLuId NOT IN(SELECT XianLuId FROM tbl_TourOrder WHERE TourId=@KongWeiId)
	AND KongWeiId=@KongWeiId
	set @error=@error+@@error	

	--ά���ƻ�λ���տ�״̬
	DECLARE @weihuresult INT
	exec proc_WeiHuKongWeiStatus @KongWeiId,@weihuresult output
	
	IF(@error<>0)
	BEGIN	
		rollback transaction
		set @Result=-100
		RETURN @Result
	END
	
	commit transaction
	set @Result=1
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Delete]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:ɾ���ո���
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Delete]
	 @DengJiId CHAR(36)--�ո���ǼǱ��
	,@CompanyId INT--��˾���
	,@XiangMuId CHAR(36)--�ո�����Ŀ���
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @KuanXiangType TINYINT--�ո�����Ŀ����
	DECLARE @errorcount INT

	SET @errorcount=0
	SELECT @KuanXiangType=[CollectionItem] FROM [tbl_FinCope] WHERE [Id]=@DengJiId

	BEGIN TRAN	
	DELETE FROM [tbl_FinCope] WHERE [Id]=@DengJiId AND [CompanyId]=@CompanyId AND [CollectionId]=@XiangMuId
	SET @errorcount=@errorcount+@@ERROR

	IF(@KuanXiangType IN(0,101))--�����տ�
	BEGIN
		EXEC proc_Fin_SetOrderJinE @OrderId=@XiangMuId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Update]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:�޸��ո���
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Update]
	 @DengJiId CHAR(36)--�ո���ǼǱ��
	,@RiQi DATETIME --�ո�������
	,@XingMing NVARCHAR(50)--�ո���������
	,@JinE MONEY--�ո�����
	,@FangShi TINYINT--�ո��ʽ
	,@BeiZhu NVARCHAR(255)--�ո��ע
	,@ZhangHuId CHAR(36)--�ո��������˻����
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @XiangMuId CHAR(36)--�ո�����Ŀ���
	DECLARE @KuanXiangType TINYINT--�ո�����Ŀ����
	DECLARE @errorcount INT

	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_FinCope] WHERE [Id]=@DengJiId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END
	
	SELECT @XiangMuId=[CollectionId],@KuanXiangType=[CollectionItem] FROM [tbl_FinCope] WHERE [Id]=@DengJiId

	BEGIN TRAN	
	UPDATE [tbl_FinCope] SET [CollectionRefundDate]=@RiQi,[CollectionRefundOperator]=@XingMing
		,[CollectionRefundAmount]=@JinE,[CollectionRefundMode]=@FangShi
		,[CollectionRefundMemo]=@BeiZhu,[BankId]=@ZhangHuId 
	WHERE [Id]=@DengJiId
	SET @errorcount=@errorcount+@@ERROR

	IF(@KuanXiangType IN(0,101))--�����տ�
	BEGIN
		EXEC proc_Fin_SetOrderJinE @OrderId=@XiangMuId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_Insert]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:д���ո���
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_ShouFuKuan_Insert]
	 @DengJiId CHAR(36)--�ո���ǼǱ��
	,@CompanyId INT--��˾���
	,@XiangMuId CHAR(36)--�ո�����Ŀ���
	,@KuanXiangType TINYINT--�ո�����Ŀ����
	,@RiQi DATETIME --�ո�������
	,@XingMing NVARCHAR(50)--�ո���������
	,@JinE MONEY--�ո�����
	,@FangShi TINYINT--�ո��ʽ
	,@BeiZhu NVARCHAR(255)--�ո��ע
	,@ZhangHuId CHAR(36)--�ո��������˻����
	,@Status TINYINT--״̬
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@RetCode INT OUTPUT
	,@ZxsId CHAR(36)
AS
BEGIN
	DECLARE @errorcount INT

	SET @errorcount=0

	BEGIN TRAN	
	INSERT INTO [tbl_FinCope]([Id],[CompanyId],[CollectionId],[CollectionItem]
		,[CollectionRefundDate],[CollectionRefundOperator],[CollectionRefundOperatorID],[CollectionRefundAmount]
		,[CollectionRefundMode],[CollectionRefundMemo],[BankId],[BankDate]
		,[Status],[ApproverId],[ApproveTime],[ApproveRemark]
		,[PayId],[PayTime],[PayRemark],[OperatorId]
		,[IssueTime],[IsXiaoZhang],[XiaoZhangId],[ZxsId]) 
	VALUES (@DengJiId,@CompanyId,@XiangMuId,@KuanXiangType
		,@RiQi,@XingMing,0,@JinE
		,@FangShi,@BeiZhu,@ZhangHuId,NULL
		,@Status,NULL,NULL,NULL
		,NULL,NULL,NULL,@OperatorId
		,@IssueTime,''0'',NULL,@ZxsId)
	SET @errorcount=@errorcount+@@ERROR

	IF(@KuanXiangType IN(0,101))--�����տ�
	BEGIN
		EXEC proc_Fin_SetOrderJinE @OrderId=@XiangMuId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_ShouFuKuan_SetStatus]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_ShouFuKuan_SetStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		����־
-- Create date: 2012-11-21
-- Description:�����ո���״̬
-- History:
-- 1.2013-01-16 ����־ ����ȡ��������ȡ��֧������
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_ShouFuKuan_SetStatus]
	 @DengJiId CHAR(36)--�ǼǱ��
	,@KuanXiangType TINYINT--��������
	,@XiangMuId CHAR(36)--�ո�����Ŀ���
	,@OperatorId INT--�����˱��
	,@OperatorTime DATETIME--����ʱ��
	,@OperatorBeiZhu NVARCHAR(255)--������ע
	,@BankDate DATETIME=NULL--����ʵ��ҵ������
	,@Status TINYINT--״̬
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT

	SET @errorcount=0

	IF(@Status NOT IN(0,1,2))
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	DECLARE @IStatus TINYINT--��ǰ״̬
	DECLARE @IKuanXiangType TINYINT--��������
	SELECT @IStatus=[Status],@IKuanXiangType=[CollectionItem] FROM [tbl_FinCope] WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType

	IF (@IStatus IS NULL OR @IKuanXiangType<>@KuanXiangType)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN	
	IF(@Status=1 AND @KuanXiangType<100 AND @IStatus=0)--�տ�����
	BEGIN
		UPDATE [tbl_FinCope] SET [Status]=1,[ApproverId]=@OperatorId,[ApproveTime]=@OperatorTime,[ApproveRemark]=@OperatorBeiZhu,[BankDate]=@BankDate
		WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType
		SET @errorcount=@errorcount+@@ERROR
	END	

	IF(@Status=0 AND @KuanXiangType<100 AND @IStatus=1)--ȡ���տ�����
	BEGIN
		UPDATE [tbl_FinCope] SET [Status]=0 
		WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@Status=1 AND @KuanXiangType>100 AND @IStatus=0)--��������
	BEGIN
		UPDATE [tbl_FinCope] SET [Status]=1,[ApproverId]=@OperatorId,[ApproveTime]=@OperatorTime,[ApproveRemark]=@OperatorBeiZhu
		WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@Status=0 AND @KuanXiangType>100 AND @IStatus=1 )--ȡ����������
	BEGIN
		UPDATE [tbl_FinCope] SET [Status]=0
		WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@Status=2 AND @IStatus=1)--����֧��
	BEGIN
		UPDATE [tbl_FinCope] SET [Status]=2,[PayId]=@OperatorId,[PayTime]=@OperatorTime,[PayRemark]=@OperatorBeiZhu,[BankDate]=@BankDate
		WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@Status=1 AND @IStatus=2)--ȡ������֧��
	BEGIN
		UPDATE [tbl_FinCope] SET [Status]=1
		WHERE [Id]=@DengJiId AND [CollectionId]=@XiangMuId AND [CollectionItem]=@KuanXiangType
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@KuanXiangType IN(0,101))--�������˿�
	BEGIN
		EXEC proc_Fin_SetOrderJinE @OrderId=@XiangMuId
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2013-01-31
-- Description: �������-���ɵ��� ȡ�����ˡ�ȡ�����
-- =============================================
CREATE PROCEDURE [dbo].[proc_Fin_DengZhang_QuXiaoXiaoZhang]	 
	 @CompanyId INT--��˾���
	,@DengZhangId CHAR(36)--���˱��
	,@OperatorId INT--�����˱��
	,@IssueTime DATETIME--����ʱ��
	,@IdXml NVARCHAR(MAX)--���ˡ���ֱ�ż���XML:<root><info Id="" /></root>
	,@LeiXing TINYINT--����
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT

	SET @errorcount=0
	
	IF NOT EXISTS(SELECT 1 FROM tbl_FinRegister WHERE DengZhangId=@DengZhangId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END
	
	DECLARE @TEMP1 TABLE(XiaoZhangId CHAR(36),LeiXing TINYINT,LeiXing1 TINYINT,GuanLianId CHAR(36),IdentityId INT IDENTITY)
	EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@IdXml
	INSERT INTO @TEMP1(XiaoZhangId,LeiXing,LeiXing1,GuanLianId)
	SELECT Id,240,240,''''
	FROM OPENXML(@hdoc,''/root/info'') WITH(Id CHAR(36))	
	EXECUTE sp_xml_removedocument @hdoc
	
	UPDATE @TEMP1 SET LeiXing=B.LeiXing,LeiXing1=B.LeiXing1,GuanLianId=B.OrderId
	FROM @TEMP1 AS A INNER JOIN tbl_FinRegisterUnCheck AS B
	ON A.XiaoZhangId=B.UnCheckId
	
	IF NOT EXISTS(SELECT 1 FROM tbl_FinRegisterUnCheck WHERE DZId=@DengZhangId AND UnCheckId IN(SELECT XiaoZhangId FROM @TEMP1) AND LeiXing=@LeiXing)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN

	IF(@LeiXing=0)--ȡ������
	BEGIN
		DELETE FROM tbl_FinCope WHERE CompanyId=@CompanyId AND IsXiaoZhang=''1'' AND XiaoZhangId IN(SELECT XiaoZhangId FROM @TEMP1)
		SET @errorcount=@errorcount+@@ERROR

		IF(@errorcount=0)--ά�������ո�����
		BEGIN			
			DECLARE @length INT
			SELECT @length=COUNT(*) FROM @TEMP1
			DECLARE @i INT			
			SET @i=1
			WHILE(@i<=@length)
			BEGIN
				DECLARE @DingDanId CHAR(36)
				SET @DingDanId=NULL
				SELECT @DingDanId=GuanLianId FROM @TEMP1 WHERE [IdentityId]=@i AND LeiXing=0 AND LeiXing1=1
				SET @i=@i+1
				
				IF(@DingDanId IS NULL) CONTINUE
				
				EXEC proc_Fin_SetOrderJinE @OrderId=@DingDanId
			END
		END
	END

	IF(@LeiXing=1)--ȡ�����
	BEGIN
		DELETE FROM tbl_FinCope WHERE CompanyId=@CompanyId AND IsXiaoZhang=''1'' AND XiaoZhangId IN(SELECT XiaoZhangId FROM @TEMP1)
		SET @errorcount=@errorcount+@@ERROR

		IF(@errorcount=0)
		BEGIN
			DELETE FROM [tbl_FinOther] WHERE CompanyId=@CompanyId AND IsChongDi=''1'' AND ChongDiId IN(SELECT XiaoZhangId FROM @TEMP1)
			SET @errorcount=@errorcount+@@ERROR
		END
	END

	IF(@errorcount=0)
	BEGIN
		DELETE FROM tbl_FinRegisterUnCheck WHERE UnCheckId IN(SELECT XiaoZhangId FROM @TEMP1)
		SET @errorcount=@errorcount+@@ERROR
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_KongWei_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_KongWei_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-14>
-- Description:	<��ӿ�λ>
-- Histtory:
-- 1.2014-07-17 ����־ ���̵���-��·��Ʒ��Ϣ��
-- =============================================
CREATE proc [dbo].[proc_KongWei_Add]
	@KongWeiId char(36)--��λ���
	,@CompanyId int--��˾���
	,@KongWeiType tinyint--��λ����(����ҵ�񡢵����Ƶ�)
	,@ShuLiang int--��λ����
	,@Status tinyint--��λ״̬
	,@AreaId int--��·������
	,@QuDate datetime--ȥ������
	,@QuJiaoTongId int--ȥ�̽�ͨ���
	,@QuDepProvinceId int--ȥ�̳���ʡ�ݱ��
	,@QuDepCityId int--ȥ�̳������б��
	,@QuArrProvinceId int--ȥ�̵���ʡ�ݱ��
	,@QuArrCityId int--ȥ�̵�����б��
	,@QuBanCi nvarchar(50)--ȥ�̰��
	,@QuTime nvarchar(50)--ȥ��ʱ��
	,@HuiDate datetime--�س�����
	,@HuiJiaoTongId int--�س̽�ͨ���
	,@HuiDepProvinceId int--�س̳���ʡ�ݱ��
	,@HuiDepCityId int--�س̳������б��
	,@HuiArrProvinceId int--�س̵���ʡ�ݱ��
	,@HuiArrCityId int--�س̵�����б��
	,@HuiBanCi nvarchar(50)--�س̰��
	,@HuiTime nvarchar(50)--�س�ʱ��
	,@OperatorId int--�����˱��
	,@DaiLiXml NVARCHAR(MAX)--��λ������XML
	,@Result int output
	,@TianShu INT=0--����
	,@MoBanId CHAR(36)=''''--ģ����
	,@ZxsId CHAR(36)--ר���̱��
	,@ZhanDianId INT--վ����
	,@ZxlbId INT--ר�������
	,@XianLuXml NVARCHAR(MAX)--��·��ƷXML
	,@PingTaiShuLiang INT--ƽ̨��λ����
as
begin
	DECLARE @KongWeiCode NVARCHAR(50)
	declare @error int
	DECLARE @hdoc int
	set @error=0
	--������ˮ��
	set @KongWeiCode=dbo.fn_KongWeiCode(@QuDate,@CompanyId,@ZxsId)	
	
	begin transaction
	
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_KongWeiMoBan WHERE MoBanId=@MoBanId)
	BEGIN
		DECLARE @Now DATETIME
		DECLARE @Year INT
		DECLARE @PiCiXuHao INT		
		DECLARE @PiCiCode NVARCHAR(50)
		SET @Now=GETDATE()
		SET @Year=YEAR(@Now)
		SELECT @PiCiXuHao=COUNT(*)+1 FROM [tbl_Pt_KongWeiMoBan] WHERE [CompanyId]=@CompanyId AND [ZxsId]=@ZxsId AND YEAR([IssueTime])=@Year
		SET @PiCiCode=''PC''+CAST(@Year AS NVARCHAR(10))+dbo.fn_PadLeft(@PiCiXuHao,''0'',4)
			
		INSERT INTO [tbl_Pt_KongWeiMoBan]([CompanyId],[ZxsId],[MoBanId],[PiCiCode],[PiCiXuHao],[IssueTime])
		VALUES(@CompanyId,@ZxsId,@MoBanId,@PiCiCode,@PiCiXuHao,@Now)
	END
	
	INSERT INTO tbl_KongWei(KongWeiId,CompanyId,KongWeiType
		,KongWeiCode,ShuLiang,Status
		,AreaId,QuDate,QuJiaoTongId
		,QuDepProvinceId,QuDepCityId,QuArrProvinceId
		,QuArrCityId,QuBanCi,QuTime
        ,HuiDate,HuiJiaoTongId,HuiDepProvinceId
        ,HuiDepCityId,HuiArrProvinceId,HuiArrCityId
        ,HuiBanCi,HuiTime,OperatorId
        ,TianShu,MoBanId,ZxsId
        ,ZhanDianId,ZxlbId,PingTaiShuLiang)
     VALUES(@KongWeiId,@CompanyId,@KongWeiType
		,@KongWeiCode,@ShuLiang,@Status
		,@AreaId,@QuDate,@QuJiaoTongId
		,@QuDepProvinceId,@QuDepCityId,@QuArrProvinceId
		,@QuArrCityId,@QuBanCi,@QuTime
        ,@HuiDate,@HuiJiaoTongId,@HuiDepProvinceId
        ,@HuiDepCityId,@HuiArrProvinceId,@HuiArrCityId
        ,@HuiBanCi,@HuiTime,@OperatorId
        ,@TianShu,@MoBanId,@ZxsId
        ,@ZhanDianId,@ZxlbId,@PingTaiShuLiang)
	set @error=@error+@@error
	
	if(@error=0 AND @DaiLiXml IS NOT NULL)
	begin
		exec sp_xml_preparedocument @hdoc output,@DaiLiXml
		INSERT INTO tbl_KongWeiDaiLi(DaiLiId,CompanyId,KongWeiId
			,GysId,GysOrderCode,LxrName
			,LxrTelephone,Price,ShuLiang
			,ShiXian,Remark,MoBanId)
		SELECT DaiLiId,@CompanyId,@KongWeiId
			,GysId,GysOrderCode,LxrName
			,LxrTelephone,Price,ShuLiang
			,ShiXian,Remark,MoBanId
		from openxml(@hdoc,''/root/info'')
		with(DaiLiId char(36), GysId char(36),GysOrderCode nvarchar(50)
			,LxrName nvarchar(50),LxrTelephone nvarchar(50),Price money
			,ShuLiang int,ShiXian nvarchar(50),Remark nvarchar(255)
			,MoBanId CHAR(36))
		set @error=@error+@@error
		exec sp_xml_removedocument @hdoc
	end
	
	IF(@error=0 AND @XianLuXml IS NOT NULL AND LEN(@XianLuXml)>0)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@XianLuXml
		INSERT INTO [tbl_Pt_KongWeiXianLu]([XianLuId],[LeiXing],[KongWeiId]
			,[RouteId],[MenShiJiaGe1],[MenShiJiaGe2]
			,[MenShiJiaGe3],[JieSuanJiaGe1],[JieSuanJiaGe2]
			,[JieSuanJiaGe3],[QuanPeiJiaGe],[BuFangChaJiaGe]
			,[TuiFangChaJiaGe],[JiFen],[Status]
			,[PaiXuId],[XianLuCode])
		SELECT [XianLuId],[LeiXing],@KongWeiId
			,[RouteId],[MenShiJiaGe1],[MenShiJiaGe2]
			,[MenShiJiaGe3],[JieSuanJiaGe1],[JieSuanJiaGe2]
			,[JieSuanJiaGe3],[QuanPeiJiaGe],[BuFangChaJiaGe]
			,[TuiFangChaJiaGe],[JiFen],[Status]
			,[PaiXuId],''''
		FROM OPENXML(@hdoc,''/root/info'')
		WITH([XianLuId] CHAR(36),[LeiXing] TINYINT
			,[RouteId] CHAR(36),[MenShiJiaGe1] MONEY,[MenShiJiaGe2] MONEY
			,[MenShiJiaGe3] MONEY,[JieSuanJiaGe1] MONEY,[JieSuanJiaGe2] MONEY
			,[JieSuanJiaGe3] MONEY,[QuanPeiJiaGe] MONEY,[BuFangChaJiaGe] MONEY
			,[TuiFangChaJiaGe] MONEY,[JiFen] INT,[Status] TINYINT
			,[PaiXuId] INT)
		SET @error=@error+@@ERROR
		EXEC sp_xml_removedocument @hdoc
		
		UPDATE [tbl_Pt_KongWeiXianLu] SET [XianLuCode]=''CP''+CAST(YEAR(@QuDate) AS NVARCHAR(4))+dbo.fn_PadLeft(IdentityId,''0'',5) WHERE KongWeiId=@KongWeiId
		SET @error=@error+@@ERROR
	END
	
	IF(@error<>0)
	BEGIN	
		rollback transaction
		set @Result=-100
		RETURN @Result
	END
	
	commit transaction
	set @Result=1
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_GetGuanLianKongWeiXianLu]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_GetGuanLianKongWeiXianLu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-09-05
-- Description:	��ȡ��·������λ��·��Ʒ��Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_GetGuanLianKongWeiXianLu]
	@XianLuId CHAR(36)--��λ��·��Ʒ���
	,@QuDate1 DATETIME--ȥ������-��
	,@QuDate2 DATETIME--ȥ������-ֹ
AS
BEGIN
	DECLARE @KongWeiXianLuLeiXing TINYINT
	DECLARE @RouteId CHAR(36)
	DECLARE @KongWeiId CHAR(36)
	
	DECLARE @QuYuId INT
	DECLARE @QuMuDiDiChengShiId INT
	DECLARE @QuJiaoTongId INT
	DECLARE @ZxsId CHAR(36)
	
	SELECT @KongWeiId=KongWeiId,@RouteId=RouteId,@KongWeiXianLuLeiXing=LeiXing FROM tbl_Pt_KongWeiXianLu WHERE XianLuId=@XianLuId
	SELECT @QuYuId=AreaId,@QuMuDiDiChengShiId=QuArrCityId,@QuJiaoTongId=QuJiaoTongId,@ZxsId=ZxsId FROM tbl_KongWei WHERE KongWeiId=@KongWeiId

	--��ѯ��λ��Ϣ
	DECLARE @TEMP TABLE(KongWeiId CHAR(36),QuDate DATETIME,ShuLiang INT
		,YiZhanWeiShuLiang INT,XianLuId CHAR(36)
		,MenShiJiaGe1 MONEY,JieSuanJiaGe1 MONEY
		,KongWeiXianLuLeiXing TINYINT,IdentityId INT IDENTITY)	
	
	INSERT INTO @TEMP(KongWeiId,QuDate,ShuLiang
		,YiZhanWeiShuLiang,XianLuId,MenShiJiaGe1
		,JieSuanJiaGe1,KongWeiXianLuLeiXing)
	SELECT A.KongWeiId,A.QuDate,A.ShuLiang
		,A.YiZhanWeiShuLiang,'''',0
		,0,@KongWeiXianLuLeiXing FROM view_Pt_KongWei AS A
	WHERE A.ZxsId=@ZxsId AND A.QuArrCityId=@QuMuDiDiChengShiId AND A.AreaId=@QuYuId AND A.QuJiaoTongId=@QuJiaoTongId AND A.QuDate>=@QuDate1 AND A.QuDate<=@QuDate2 AND EXISTS(SELECT 1 FROM view_Pt_KongWeiXianLu AS A1 WHERE A1.KongWeiId=A.KongWeiId AND A1.RouteId=@RouteId AND A1.[Status]=0)
	
	--������·��Ʒ���	
	UPDATE @TEMP SET XianLuId=(SELECT A1.XianLuId FROM view_Pt_KongWeiXianLu AS A1 WHERE A1.KongWeiId=A.KongWeiId AND A1.RouteId=@RouteId)
	FROM @TEMP AS A	
	
	--���¼۸�
	UPDATE @TEMP SET MenShiJiaGe1=B.MenShiJiaGe1,JieSuanJiaGe1=B.JieSuanJiaGe1
	FROM @TEMP AS A INNER JOIN view_Pt_KongWeiXianLu AS B
	ON A.XianLuId=B.XianLuId
	
	--�Ƴ��ظ�����
	DELETE FROM @TEMP WHERE [QuDate] IN (SELECT [QuDate] FROM @TEMP GROUP BY [QuDate] HAVING COUNT([QuDate]) > 1) AND [IdentityId] NOT IN(SELECT MIN([IdentityId]) FROM  @TEMP GROUP BY [QuDate] HAVING COUNT([QuDate])>1)
	
	SELECT * FROM @TEMP ORDER BY QuDate ASC
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PlanChuPiao_Add]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_PlanChuPiao_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<����>
-- Create date: <2012-11-19>
-- Description:	<����Ʊ�񡪡���Ʊ>
-- Result :-1:��Ʊ��������ʣ������
--		   -2:��ǰ�������ڲ���������Ʊ�ο�	
--		   -3:��ӳɹ�
--		   -4:���ʧ��		
-- History:
-- 1.2013-02-26 ����־ ���ӿ�λ״̬�Ŀ���			
-- =============================================
CREATE proc [dbo].[proc_PlanChuPiao_Add]
	@PlanId char(36)--�ƻ����
	,@CompanyId int--��˾���
	,@KongWeiId char(36)--��λ��
	,@JiaoYiHao nvarchar(255)--���׺�
	,@DaiLiId char(36)--������
	,@GysId char(36)--��Ӧ�̱��
	,@ShuLiang int--����
	,@JieSuanMX nvarchar(255)--������ϸ
	,@JieSuanAmount money--������
	,@Remark nvarchar(255)--��ע	
	,@FilePath nvarchar(255)--�ļ�
	,@OperatorId int--������
	,@Traveller xml--�ο���Ϣ<Root><Traveller PlanId=\"{0}\" YouKeId=\"{1}\" OrderId=\"{2}\" /></Root>
	,@Result int output
	,@ZxsId CHAR(36)
as
begin
	declare @error int
	set @error=0	

	declare @TotalNum int
	select @TotalNum=isnull(ShuLiang,0) from tbl_KongWeiDaiLi where DaiLiId=@DaiLiId

	declare @YiChuPiao int
	select @YiChuPiao=isnull(sum(ShuLiang),0) from tbl_PlanChuPiao where DaiLiId=@DaiLiId

	if(@TotalNum-@YiChuPiao<@ShuLiang)
	begin
		set @Result=-1 -- -1:��Ʊ��������ʣ������
		return @Result
	end

	if(@Traveller is null)
	begin
		set @Result=-4  
		return @Result
	end
	
	declare @idoc int
	exec sp_xml_preparedocument @idoc output,@Traveller
	set @error=@error+@@error

	if exists(select YouKeId from openxml(@idoc,''/Root/Traveller'')with(YouKeId char(36)) where YouKeId not in((select TravellerId  from tbl_TourOrderTraveller where TourId=@KongWeiId)))
	begin
		set @Result=-2  --��ǰ�������ڲ���������Ʊ�ο�
		return @Result
	end
		
	--�жϵ�ǰ�ο��Ƿ�������δ��Ʊ
	if exists(select 1 from tbl_TourOrderTraveller where TourId=@KongWeiId  and (Status=1 or TicketType in (1,2)) and exists(select YouKeId from openxml(@idoc,''/Root/Traveller'') with(YouKeId char(36)) where YouKeId=tbl_TourOrderTraveller.TravellerId))
	begin
		set @Result=-2	--��ǰ�������ڲ���������Ʊ�ο�
		return @Result
	end
	
	IF EXISTS(SELECT 1 FROM tbl_KongWei WHERE KongWeiId=@KongWeiId AND KongWeiZhuangTai=1)
	BEGIN
		SET @Result=-19
		RETURN @Result
	END
	
	begin transaction	
	--�Զ����ɻ�Ʊ��
	set @JiaoYiHao=dbo.fn_PiaoCode(@KongWeiId)

	INSERT INTO tbl_PlanChuPiao(PlanId,CompanyId,KongWeiId
		,JiaoYiHao,DaiLiId,GysId
		,ShuLiang,JieSuanMX,JieSuanAmount
		,Remark,FilePath,OperatorId
		,IssueTime,[ZxsId])
	VALUES(@PlanId,@CompanyId,@KongWeiId
		,@JiaoYiHao,@DaiLiId,@GysId
		,@ShuLiang,@JieSuanMX,@JieSuanAmount
		,@Remark,@FilePath,@OperatorId
		,getdate(),@ZxsId)
	set @error=@error+@@error

	INSERT INTO tbl_PlanChuPiaoYouKe(PlanId,YouKeId,OrderId)
	SELECT @PlanId,YouKeId,OrderId from openxml(@idoc,''/Root/Traveller'')
	WITH(YouKeId char(36),OrderId char(36)) 
	set @error=@error+@@error	

	--���οͳ�Ʊ״̬��Ϊ�ѳ�Ʊ
	UPDATE tbl_TourOrderTraveller SET TicketType =1
	WHERE  TravellerId in (select YouKeId from openxml(@idoc,''/Root/Traveller'') with(YouKeId char(36)))
	set @error=@error+@@error

	exec sp_xml_removedocument @idoc
	
	IF(@error<>0)
	BEGIN
		set @Result=-4
		rollback transaction
		RETURN @Result
	END

	set @Result=-3
	commit transaction
	return @Result
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Pt_JiFenShangPin_CU]    Script Date: 09/29/2014 16:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_Pt_JiFenShangPin_CU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		����־
-- Create date: 2014-07-07
-- Description:	������Ʒ�������޸�
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pt_JiFenShangPin_CU]
	@ShangPinId CHAR(36) 
	,@CompanyId INT 
	,@MingCheng NVARCHAR(255)
	,@JiaGe MONEY
	,@JiFen INT
	,@LeiXing TINYINT
	,@Status TINYINT
	,@FengMian NVARCHAR(255)
	,@MiaoShu NVARCHAR(MAX)
	,@DuiHuanXuZhi NVARCHAR(MAX)
	,@PeiSongShuoMing NVARCHAR(MAX)
	,@OperatorId INT
	,@IssueTime DATETIME
	,@FuJianXml NVARCHAR(MAX)
	,@RetCode INT OUTPUT
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	SET @errorcount=0
	SET @RetCode=0
	
	BEGIN TRAN
	IF NOT EXISTS(SELECT 1 FROM tbl_Pt_JiFenShangPin WHERE ShangPinId=@ShangPinId AND CompanyId=@CompanyId)
	BEGIN
		INSERT INTO [tbl_Pt_JiFenShangPin]([ShangPinId],[CompanyId],[BianMa]
			,[MingCheng],[JiaGe],[JiFen]
			,[LeiXing],[Status],[FengMian]
			,[MiaoShu],[DuiHuanXuZhi],[PeiSongShuoMing]
			,[OperatorId],[IssueTime])
		VALUES(@ShangPinId,@CompanyId,dbo.fn_Pt_CreateJiFenShangPinBianMa(@CompanyId)
			,@MingCheng,@JiaGe,@JiFen
			,@LeiXing,@Status,@FengMian
			,@MiaoShu,@DuiHuanXuZhi,@PeiSongShuoMing
			,@OperatorId,@IssueTime)
		SET @errorcount=@errorcount+@@ERROR
	END
	ELSE
	BEGIN
		UPDATE [tbl_Pt_JiFenShangPin] SET [MingCheng]=@MingCheng,[JiaGe]=@JiaGe
			,[JiFen]=@JiFen,[LeiXing]=@LeiXing,[Status]=@Status
			,[FengMian]=@FengMian,[MiaoShu]=@MiaoShu,[DuiHuanXuZhi]=@DuiHuanXuZhi
			,[PeiSongShuoMing]=@PeiSongShuoMing
		WHERE [ShangPinId]=@ShangPinId
		SET @errorcount=@errorcount+@@ERROR
	END
	
	DELETE FROM tbl_Pt_JiFenShangPinFuJian WHERE ShangPinId=@ShangPinId
	SET @errorcount=@errorcount+@@ERROR
	
	IF(LEN(@FuJianXML)>8)
	BEGIN
		EXEC sp_xml_preparedocument @hdoc OUTPUT,@FuJianXML
		INSERT INTO tbl_Pt_JiFenShangPinFuJian([ShangPinId],[LeiXing],[Filepath],[MiaoShu])
		SELECT @ShangPinId,[LeiXing],[Filepath],[MiaoShu] FROM OPENXML(@hdoc,''/root/info'',3)
		WITH([LeiXing] INT,[Filepath] NVARCHAR(255),[MiaoShu] NVARCHAR(255))
		SET @errorcount=@errorcount+@@ERROR
		EXEC sp_xml_removedocument @hdoc
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100	
		RETURN @RetCode
	END
	
	COMMIT TRAN
	SET @RetCode=1	
	RETURN @RetCode
END
' 
END
GO
/****** Object:  View [dbo].[View_PayRemind_GetList]    Script Date: 09/29/2014 16:26:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PayRemind_GetList]'))
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		֣֪Զ
-- Create date: 2012-11-22
-- Description:	��Ӧ��δ������ͼ
-- History:
-- =============================================
CREATE VIEW [dbo].[View_PayRemind_GetList]
AS
SELECT GysId,GysName,CompanyId,ContactInfo,JieSuanAmount,JieSuanAmount-YiZhiFuJinE AS WeiZhiFuJinE,QuDate,KongWeiCode,RouteName,ChengRenShu,ErTongShu,QuPeiShu,YingErShu,ZxsId FROM view_Fin_YingFuDiJie
UNION ALL
SELECT GysId,GysName,CompanyId,ContactInfo,JieSuanAmount,JieSuanAmount-YiZhiFuJinE AS WeiZhiFuJinE,QuDate,KongWeiCode,JiaoYiHao,ShuLiang,0,0,0,ZxsId FROM view_Fin_YingFuJiaoTong
UNION ALL
SELECT GysId,GysName,CompanyId,ContactInfo,JieSuanAmount,JieSuanAmount-YiZhiFuJinE AS WeiZhiFuJinE,QuDate,KongWeiCode,JiaoYiHao,Adults,Childs,Bears,YingErRenShu,ZxsId FROM view_Fin_YingFuJiuDian


'
GO
