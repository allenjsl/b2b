GO
--系统数据清理 执行操作前务必做数据备份 
--2012-12-27 汪奇志

BEGIN TRAN

DECLARE @CID INT
SET @CID=0

--线路产品
DELETE FROM tbl_RoutePlan WHERE RouteId IN(SELECT RouteId FROM tbl_Route WHERE CompanyId=@CID)
DELETE FROM tbl_Route WHERE CompanyId=@CID
--线路政策
DELETE FROM tbl_RouteZhengCe WHERE CompanyId=@CID

--控位相关
DELETE FROM tbl_PlanTuiPiaoYouKe WHERE TuiId IN(SELECT TuiId FROM tbl_PlanTuiPiao WHERE PlanId IN(SELECT PlanId FROM tbl_PlanChuPiao WHERE CompanyId=@CID))
DELETE FROM tbl_BianGeng WHERE BianId IN(SELECT TuiId FROM tbl_PlanTuiPiao WHERE PlanId IN(SELECT PlanId FROM tbl_PlanChuPiao WHERE CompanyId=@CID))
DELETE FROM tbl_PlanTuiPiao WHERE PlanId IN(SELECT PlanId FROM tbl_PlanChuPiao WHERE CompanyId=@CID)
DELETE FROM tbl_PlanChuPiaoYouKe WHERE PlanId IN(SELECT PlanId FROM tbl_PlanChuPiao WHERE CompanyId=@CID)
DELETE FROM tbl_BianGeng WHERE BianId IN(SELECT PlanId FROM tbl_PlanChuPiao WHERE CompanyId=@CID)
DELETE FROM tbl_PlanChuPiao WHERE CompanyId=@CID

DELETE FROM tbl_PlanDiJIeOrder WHERE PlanId IN(SELECT PlanId FROM tbl_PlanDiJie WHERE CompanyId=@CID)
DELETE FROM tbl_BianGeng WHERE BianId IN(SELECT PlanId FROM tbl_PlanDiJie WHERE CompanyId=@CID)
DELETE FROM tbl_PlanDiJie WHERE CompanyId=@CID

DELETE FROM tbl_KongWeiDaiLi WHERE KongWeiId IN(SELECT KongWeiId FROM tbl_KongWei WHERE CompanyId=@CID)
DELETE FROM tbl_KongWei WHERE CompanyId=@CID

DELETE FROM tbl_TourOrderHuiFang WHERE OrderId IN(SELECT OrderId FROM tbl_TourOrder WHERE CompanyId=@CID)
DELETE FROM tbl_TourOrderTraveller WHERE OrderId IN(SELECT OrderId FROM tbl_TourOrder WHERE CompanyId=@CID)
DELETE FROM tbl_TourOrderHotelPlan WHERE OrderId IN(SELECT OrderId FROM tbl_TourOrder WHERE CompanyId=@CID)
DELETE FROM tbl_BianGeng WHERE BianId IN(SELECT OrderId FROM tbl_TourOrder WHERE CompanyId=@CID)
DELETE FROM tbl_TourOrder WHERE CompanyId=@CID


--财务相关
DELETE FROM tbl_FinApplyDetail WHERE Id IN(SELECT Id FROM tbl_FinApply WHERE CompanyId=@CID)
DELETE FROM tbl_FinApply WHERE CompanyId=@CID

DELETE FROM tbl_FinFaPiaoMx WHERE DengJiId IN(SELECT DengJiId FROM tbl_FinFaPiao WHERE CompanyId=@CID)
DELETE FROM tbl_FinFaPiao WHERE CompanyId=@CID

DELETE FROM tbl_FinYinHangHeDuiMx WHERE HeDuiId IN(SELECT HeDuiId FROM tbl_FinYinHangHeDui WHERE CompanyId=@CID)
DELETE FROM tbl_FinYinHangHeDui WHERE CompanyId=@CID

DELETE FROM tbl_FinCope WHERE CompanyId=@CID

DELETE FROM tbl_FinLoan WHERE CompanyId=@CID

DELETE FROM tbl_FinOther WHERE CompanyId=@CID

DELETE FROM tbl_FinRiJiZhang WHERE CompanyId=@CID

DELETE FROM tbl_FinRegisterUnCheck WHERE DZId IN(SELECT DengZhangId FROM tbl_FinRegister WHERE CompanyId=@CID)
DELETE FROM tbl_FinRegister WHERE CompanyId=@CID

--银行账号
DELETE FROM tbl_CompanyAccount WHERE CompanyId=@CID

--行政中心
DELETE FROM tbl_FixedAsset WHERE CompanyId=@CID
DELETE FROM tbl_TrainPlanAccepts WHERE TrainPlanId IN(SELECT ID FROM tbl_TrainPlan WHERE CompanyId=@CID)
DELETE FROM tbl_TrainPlan WHERE CompanyId=@CID
DELETE FROM tbl_ContractInfo WHERE CompanyId=@CID
DELETE FROM tbl_RuleInfo WHERE CompanyId=@CID
DELETE FROM tbl_DutyManager WHERE CompanyId=@CID
DELETE FROM tbl_Wage WHERE CompanyId=@CID
DELETE FROM tbl_MeetingInfo WHERE CompanYId=@CID
DELETE FROM tbl_SchoolInfo WHERE PersonId IN(SELECT ID FROM tbl_PersonnelInfo WHERE CompanyId=@CID)
DELETE FROM tbl_AttendanceInfo WHERE StaffNo IN(SELECT ID FROM tbl_PersonnelInfo WHERE CompanyId=@CID)
DELETE FROM tbl_PersonalHistory WHERE PersonId IN(SELECT ID FROM tbl_PersonnelInfo WHERE CompanyId=@CID)
DELETE FROM tbl_PersonnelInfo WHERE CompanyId=@CID

--个人中心
DELETE FROM tbl_UserLeave WHERE CompanyId=@CID
DELETE FROM tbl_UserMemorandum WHERE CompanyId=@CID
DELETE FROM tbl_WorkPlan WHERE CompanyId=@CID
DELETE FROM tbl_WorkPlanAccept WHERE CompanyId=@CID
DELETE FROM tbl_WorkReport WHERE CompanyId=@CID
DELETE FROM tbl_Document WHERE CompanyId=@CID
DELETE FROM tbl_WorkExchangeAccept WHERE ExchangeId IN(SELECT ExchangeId FROM tbl_WorkExchange WHERE CompanyId=@CID)
DELETE FROM tbl_WorkExchangeReply WHERE ExchangeId IN(SELECT ExchangeId FROM tbl_WorkExchange WHERE CompanyId=@CID)
DELETE FROM tbl_WorkExchange WHERE CompanyId=@CID

--操作日志
--DELETE FROM tbl_SysHandleLogs WHERE CompanyId=@CID

--登录日志
--DELETE FROM tbl_SysLoginLog WHERE CompanyId=@CID

COMMIT TRAN
GO
