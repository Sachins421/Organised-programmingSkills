
-- =============================================
-- Author:      Sachin Shukla
-- CREATE date: 07.12.2022
-- Description: Archive Glass Selection records where corresponding Sales order is archived
-- =============================================


CREATE or Alter PROCEDURE [NAVMaintenance].[ArchiveGlassSelectionLineOption]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	insert into [Mister Spex GmbH$Glass Sel_ Line Option Archive] ([Glass Selection Header No_], [Glass Selection Line No_], [Line No_], [Option Code], [Option Name], [Purchase Price], Lotus, Selected, [Glass Item No_(Left)], [Glass Item No_(Right)])
	select
		gslo.[Glass Selection Header No_],
		gslo.[Glass Selection Line No_],
		gslo.[Line No_],
		gslo.[Option Code],
		gslo.[Option Name],
		gslo.[Purchase Price],
		gslo.Lotus,
		gslo.Selected,
		gslo.[Glass Item No_(Left)],
		gslo.[Glass Item No_(Right)]
	from
		[Mister Spex GmbH$Glass Selection Header] gsh
	inner join
		[Mister Spex GmbH$Glass Selection Line] gsl
		on gsh.[Entry No_] = gsl.[Glass Selection Header No_]
	inner join
		[Mister Spex GmbH$Glass Selection Line Option] gslo
		on gsl.[Glass Selection Header No_] = gslo.[Glass Selection Header No_]
		and gsl.[Line No_] = gslo.[Glass Selection Line No_]
	where
		gsl.Selected = 1
		and gslo.Selected = 1
		and exists (select sha.No_ from [Mister Spex GmbH$Sales Header Archive] sha where sha.[Document Type] = 1 and sha.[No_] = gsh.[Order No_])
END;

GO

-- ===================
-- [NAVMaintenance].[ArchiveGlassSelectionLine]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[ArchiveGlassSelectionLine]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	insert into [Mister Spex GmbH$Glass Selection Line Archive] (
			[Glass Selection Header No_]
			, [Line No_]
			, [Code Right]
			, [Code Left]
			, [LensName Right]
			, [LensName Left]
			, [Diameter1 Right]
			, [Diameter1 Left]
			, [Diameter2 Right]
			, [Diameter2 Left]
			, [Elliptic Right]
			, [Elliptic Left]
			, [MaxMeridianFrom Right]
			, [MaxMeridianFrom Left]
			, [MaxMeridianTo Right]
			, [MaxMeridianTo Left]
			, [MaxCylinderFrom Right]
			, [MaxCylinderFrom Left]
			, [MaxCylinderTo Right]
			, [MaxCylinderTo Left]
			, [CylPart1 Right]
			, [CylPart1 Left]
			, [CylPart2 Right]
			, [CylPart2 Left]
			, [Stocklens Right]
			, [Stocklens Left]
			, [OrderDiameter1 Right]
			, [OrderDiameter1 Left]
			, [OrderDiameter2 Right]
			, [OrderDiameter2 Left]
			, [Purchase Price Right]
			, [Purchase Price Left]
			, [Purchase Price Glasses]
			, [Purchase Price Service]
			, [Total Price]
			, [Glass Color]
			, [Glass Manufacturer]
			, [Selected]
			, [Glass Package Restricted]
			, [Glass Selection Restricted]
			, [Sorting]
			, [Selected at]
			, [Selected by]
			, [Order No_]
			, [Order Line No_]
			, [Glass Order Status]
			, [Created At]
			, [Created by]
			, [Modified at]
			, [Modified by]
			, [Ordering Type]
			, [Purchase Price Option]
			, [Purchase Price Color]
			, [Glass Color Name]
			, [Free Glas Thickness (int_)]
			, [Description]
			, [Free Glas Thickness]
			, [Glass Item No_(Left)]
			, [Glass Item No_(Right)]
			, [Own Production]
			, [Tinge Percentage]
			, [Gradient Percentage])
	select
		gsl.[Glass Selection Header No_]
		, gsl.[Line No_]
		, gsl.[Code Right]
		, gsl.[Code Left]
		, gsl.[LensName Right]
		, gsl.[LensName Left]
		, gsl.[Diameter1 Right]
		, gsl.[Diameter1 Left]
		, gsl.[Diameter2 Right]
		, gsl.[Diameter2 Left]
		, gsl.[Elliptic Right]
		, gsl.[Elliptic Left]
		, gsl.[MaxMeridianFrom Right]
		, gsl.[MaxMeridianFrom Left]
		, gsl.[MaxMeridianTo Right]
		, gsl.[MaxMeridianTo Left]
		, gsl.[MaxCylinderFrom Right]
		, gsl.[MaxCylinderFrom Left]
		, gsl.[MaxCylinderTo Right]
		, gsl.[MaxCylinderTo Left]
		, gsl.[CylPart1 Right]
		, gsl.[CylPart1 Left]
		, gsl.[CylPart2 Right]
		, gsl.[CylPart2 Left]
		, gsl.[Stocklens Right]
		, gsl.[Stocklens Left]
		, gsl.[OrderDiameter1 Right]
		, gsl.[OrderDiameter1 Left]
		, gsl.[OrderDiameter2 Right]
		, gsl.[OrderDiameter2 Left]
		, gsl.[Purchase Price Right]
		, gsl.[Purchase Price Left]
		, gsl.[Purchase Price Glasses]
		, gsl.[Purchase Price Service]
		, gsl.[Total Price]
		, gsl.[Glass Color]
		, gsl.[Glass Manufacturer]
		, gsl.[Selected]
		, gsl.[Glass Package Restricted]
		, gsl.[Glass Selection Restricted]
		, gsl.[Sorting]
		, gsl.[Selected at]
		, gsl.[Selected by]
		, gsl.[Order No_]
		, gsl.[Order Line No_]
		, gsl.[Glass Order Status]
		, gsl.[Created At]
		, gsl.[Created By]
		, gsl.[Modified at]
		, gsl.[Modified by]
		, gsl.[Ordering Type]
		, gsl.[Purchase Price Option]
		, gsl.[Purchase Price Color]
		, gsl.[Glass Color Name]
		, gsl.[Free Glas Thickness (int_)]
		, gsl.[Description]
		, gsl.[Free Glas Thickness]
		, gsl.[Glass Item No_(Left)]
		, gsl.[Glass Item No_(Right)]
		, gsl.[Own Production]
		, gsl.[Tinge Percentage]
		, gsl.[Gradient Percentage]
from
    [Mister Spex GmbH$Glass Selection Header] gsh
inner join
    [Mister Spex GmbH$Glass Selection Line] gsl
    on gsh.[Entry No_] = gsl.[Glass Selection Header No_]
where
    gsl.Selected = 1
    and exists (select sha.No_ from [Mister Spex GmbH$Sales Header Archive] sha where sha.[Document Type] = 1 and sha.[No_] = gsh.[Order No_])
END;

GO

-- ===================
-- [NAVMaintenance].[ArchiveGlassSelectionHeader]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[ArchiveGlassSelectionHeader]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	insert into [Mister Spex GmbH$Glass Selection Header Archive] (
	[Entry No_]
	, [Barcode Pre-Manufacturing]
	, [Order No_]
	, [Order Line No_]
	, [Item No_]
	, [Item Description]
	, [Glass Traced]
	, [Created at]
	, [Created by]
	, [Modified at]
	, [Modified by]
	, [Glass Order Status]
	, [Tracer Data Entry No_]
	, [Glass Order Entry No_]
	, [Glass Manufacturer Changed]
	, [Glass Manufacturer]
	, [Manufacture Method]
	, [Glas Thickness (int_)]
	, [Color Code (int_)]
	, [Multifocal (int_)]
	, [LMS Message])
select
	gsh.[Entry No_]
	, gsh.[Barcode Pre-Manufacturing]
	, gsh.[Order No_]
	, gsh.[Order Line No_]
	, gsh.[Item No_]
	, gsh.[Item Description]
	, gsh.[Glass Traced]
	, gsh.[Created at]
	, gsh.[Created by]
	, gsh.[Modified at]
	, gsh.[Modified by]
	, gsh.[Glass Order Status]
	, gsh.[Tracer Data Entry No_]
	, gsh.[Glass Order Entry No_]
	, gsh.[Glass Manufacturer Changed]
	, gsh.[Glass Manufacturer]
	, gsh.[Manufacture Method]
	, gsh.[Glas Thickness (int_)]
	, gsh.[Color Code (int_)]
	, gsh.[Multifocal (int_)]
	, gsh.[LMS Message]
from
	[Mister Spex GmbH$Glass Selection Header] gsh
where
	exists (select sha.No_ from [Mister Spex GmbH$Sales Header Archive] sha where sha.[Document Type] = 1 and sha.[No_] = gsh.[Order No_])
	and exists (select gsl.[Glass Selection Header No_] from [Mister Spex GmbH$Glass Selection Line] gsl where gsh.[Entry No_] = gsl.[Glass Selection Header No_] and gsl.Selected = 1)
END;

Go

-- ===================
-- [NAVMaintenance].[DeleteObsoleteGlassSelectionHeader]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteObsoleteGlassSelectionHeader]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gsh
	from
		[Mister Spex GmbH$Glass Selection Header] gsh
	inner join
		[Mister Spex GmbH$Glass Selection Header Archive] gsha
		on gsh.[Entry No_] = gsha.[Entry No_]
END;

Go

-- ===================
-- [NAVMaintenance].[DeleteObsoleteGlassSelectionLine]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteObsoleteGlassSelectionLine]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gsl
	from
		[Mister Spex GmbH$Glass Selection Line] gsl
	inner join
		[Mister Spex GmbH$Glass Selection Header Archive] gsha
		on gsl.[Glass Selection Header No_] = gsha.[Entry No_]
End;

Go

-- ===================
-- [NAVMaintenance].[DeleteObsoleteGlassSelectionLineOption]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteObsoleteGlassSelectionLineOption]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gslo
	from
		[Mister Spex GmbH$Glass Selection Line Option] gslo
	inner join
		[Mister Spex GmbH$Glass Selection Header Archive] gsha
		on gslo.[Glass Selection Header No_] = gsha.[Entry No_]
End;

Go

-- ===================
-- [NAVMaintenance].[DeleteGlassSelectionHeaderWithOutSalesOrder]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteGlassSelectionHeaderWithOutSalesOrder]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gsh
	from
		[Mister Spex GmbH$Glass Selection Header] gsh
	left join
		[Mister Spex GmbH$Sales Header] sh
		on sh.[Document Type] = 1
		and sh.No_ = gsh.[Order No_]
	where
		sh.No_ is null
End;

Go

-- ===================
-- [NAVMaintenance].[DeleteGlassSelectionLineOptionWithOutSalesOrder]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteGlassSelectionLineOptionWithOutSalesOrder]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gslo
	from
		[Mister Spex GmbH$Glass Selection Line Option] gslo
	left join
		[Mister Spex GmbH$Glass Selection Header] gsh
		on gslo.[Glass Selection Header No_] = gsh.[Entry No_]
	where
		gsh.[Entry No_] is null
End;

Go

-- ===================
-- [NAVMaintenance].[DeleteGlassSelectionLineWithOutGlassSelectionHeader]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteGlassSelectionLineWithOutGlassSelectionHeader]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gsl
	from
		[Mister Spex GmbH$Glass Selection Line] gsl
	left join
		[Mister Spex GmbH$Glass Selection Header] gsh
		on gsl.[Glass Selection Header No_] = gsh.[Entry No_]
	where
		gsh.[Entry No_] is null
END;

Go

-- ===================
-- [NAVMaintenance].[DeleteGlassSelectionHeaderWithOutGlassSelectionLine]
-- ===================

CREATE or Alter PROCEDURE [NAVMaintenance].[DeleteGlassSelectionHeaderWithOutGlassSelectionLine]
AS
BEGIN
    SET NOCOUNT ON
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	delete
		gsh
	from
		[Mister Spex GmbH$Glass Selection Header] gsh
	left join
		[Mister Spex GmbH$Glass Selection Line] gsl
		on gsl.[Glass Selection Header No_] = gsh.[Entry No_]
	where
		gsl.[Glass Selection Header No_] is null
End;

GO

-- ==============================================================================================================================================================
-- Description - Job_NAVMaintenance: Archive Glass Selection records

USE [msdb]
GO

/****** Object:  Job [Glass Production: Archive Glass Selection records]    Script Date: 07.12.2022 13:29:07 ******/
BEGIN TRANSACTION
	DECLARE @ReturnCode INT
	SELECT @ReturnCode = 0

	/****** Object:  Delete existing job   Script Date: 07.12.2022 13:29:07 ******/
	IF EXISTS (SELECT job_id
				FROM msdb.dbo.sysjobs_view
				WHERE name = N'Glass Production: Archive Glass Selection records')
	EXEC msdb.dbo.sp_delete_job @job_name=N'Glass Production: Archive Glass Selection records', @delete_unused_schedule=1

	IF EXISTS (SELECT job_id
				FROM msdb.dbo.sysjobs_view
				WHERE name = N'NAVMaintenance: Archive Glass Selection records')
	EXEC msdb.dbo.sp_delete_job @job_name=N'NAVMaintenance: Archive Glass Selection records', @delete_unused_schedule=1

	/****** Object:  JobCategory [Database Maintenance]    Script Date: 07.12.2022 13:29:07 ******/
	IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
	BEGIN
	EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'NAVMaintenance: Archive Glass Selection records',
		@enabled=1,
		@notify_level_eventlog=0,
		@notify_level_email=0,
		@notify_level_netsend=0,
		@notify_level_page=0,
		@delete_level=0,
		@description=N'NAV-24572',
		@category_name=N'[Uncategorized (Local)]',
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Archive Glass Selection Line Option]    Script Date: 07.12.2022 13:29:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Archive Glass Selection Line Option',
		@step_id=1,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[ArchiveGlassSelectionLineOption]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Archive Glass Selection Line]    Script Date: 07.12.2022 13:29:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Archive Glass Selection Line',
		@step_id=2,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[ArchiveGlassSelectionLine]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Archive Glass Selection Header]    Script Date: 07.12.2022 13:29:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Archive Glass Selection Header',
		@step_id=3,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[ArchiveGlassSelectionHeader]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Obsolet Glass Selection Header]    Script Date: 07.12.2022 13:29:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Obsolet Glass Selection Header',
		@step_id=4,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteObsoleteGlassSelectionHeader]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Obsolet Glass Selection Line]    Script Date: 07.12.2022 13:29:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Obsolet Glass Selection Line',
		@step_id=5,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteObsoleteGlassSelectionLine]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Obsolet Glass Selection Line Option]    Script Date: 07.12.2022 13:29:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Obsolet Glass Selection Line Option',
		@step_id=6,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteObsoleteGlassSelectionLineOption]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Glass Selection without Sales order',
		@step_id=7,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteGlassSelectionHeaderWithOutSalesOrder]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Glass Selection Line Option wihout header]    Script Date: 05.07.2021 11:14:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Glass Selection Line Option wihout header',
		@step_id=8,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteGlassSelectionLineOptionWithOutSalesOrder]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Glass Selection Line without header]    Script Date: 05.07.2021 11:14:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Glass Selection Line without header',
		@step_id=9,
		@cmdexec_success_code=0,
		@on_success_action=3,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteGlassSelectionLineWithOutGlassSelectionHeader]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Delete Glass Selection Header without Lines]    Script Date: 05.07.2021 11:14:08 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Delete Glass Selection Header without Lines',
		@step_id=10,
		@cmdexec_success_code=0,
		@on_success_action=1,
		@on_success_step_id=0,
		@on_fail_action=2,
		@on_fail_step_id=0,
		@retry_attempts=0,
		@retry_interval=0,
		@os_run_priority=0, @subsystem=N'TSQL',
		@command=N'exec [NAVMaintenance].[DeleteGlassSelectionHeaderWithOutGlassSelectionLine]',
		@database_name=N'NAV2018-DEV',
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO
