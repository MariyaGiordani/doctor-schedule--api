﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [U_USER] (
        [USER_ID] int NOT NULL IDENTITY,
        [USER_NAME] nvarchar(100) NOT NULL,
        [USER_PASSWORD] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_U_USER] PRIMARY KEY ([USER_ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [M_DOCTOR] (
        [CPF] nvarchar(11) NOT NULL,
        [FIRST_NAME] nvarchar(30) NOT NULL,
        [LAST_NAME] nvarchar(70) NOT NULL,
        [CRM] int NOT NULL,
        [SPECIALITY] nvarchar(39) NOT NULL,
        [USER_ID] int NOT NULL,
        CONSTRAINT [PK_M_DOCTOR] PRIMARY KEY ([CPF]),
        CONSTRAINT [FK_M_DOCTOR_U_USER_USER_ID] FOREIGN KEY ([USER_ID]) REFERENCES [U_USER] ([USER_ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [P_PATIENT] (
        [CPF] nvarchar(30) NOT NULL,
        [FIRST_NAME] nvarchar(30) NOT NULL,
        [LAST_NAME] nvarchar(70) NOT NULL,
        [USER_ID] int NOT NULL,
        CONSTRAINT [PK_P_PATIENT] PRIMARY KEY ([CPF]),
        CONSTRAINT [FK_P_PATIENT_U_USER_USER_ID] FOREIGN KEY ([USER_ID]) REFERENCES [U_USER] ([USER_ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [U_SECURITY] (
        [USER_ID] int NOT NULL,
        [SALT_PASSWORD] varbinary(max) NOT NULL,
        CONSTRAINT [PK_U_SECURITY] PRIMARY KEY ([USER_ID]),
        CONSTRAINT [FK_U_SECURITY_U_USER_USER_ID] FOREIGN KEY ([USER_ID]) REFERENCES [U_USER] ([USER_ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [M_ADDRESS] (
        [ADDRESS_ID] int NOT NULL IDENTITY,
        [ROAD_TYPE] nvarchar(30) NOT NULL,
        [STREET] nvarchar(100) NOT NULL,
        [NUMBER] int NOT NULL,
        [NEIGHBORHOOD] nvarchar(100) NOT NULL,
        [COMPLEMENT] nvarchar(200) NULL,
        [POSTAL_CODE] nvarchar(10) NOT NULL,
        [CITY] nvarchar(max) NOT NULL,
        [UF] nvarchar(max) NOT NULL,
        [INFORMATION] nvarchar(4000) NULL,
        [Cpf] nvarchar(11) NOT NULL,
        [TELEPHONE] nvarchar(max) NOT NULL,
        [HEALTHCARE] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_M_ADDRESS] PRIMARY KEY ([ADDRESS_ID]),
        CONSTRAINT [FK_M_ADDRESS_M_DOCTOR_Cpf] FOREIGN KEY ([Cpf]) REFERENCES [M_DOCTOR] ([CPF]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [M_TIMESHEET] (
        [TIMESHEET_ID] int NOT NULL IDENTITY,
        [START_DATE] datetime2 NOT NULL,
        [END_DATE] datetime2 NOT NULL,
        [LUNCH_START_DATE] datetime2 NOT NULL,
        [LUNCH_END_DATE] datetime2 NOT NULL,
        [APPOINTMENT_DURATION] datetime2 NOT NULL,
        [CPF] nvarchar(11) NOT NULL,
        [ADDRESS_ID] int NOT NULL,
        [APPOINTMENT_CANCEL_TIME] datetime2 NOT NULL,
        CONSTRAINT [PK_M_TIMESHEET] PRIMARY KEY ([TIMESHEET_ID]),
        CONSTRAINT [FK_M_TIMESHEET_M_ADDRESS_ADDRESS_ID] FOREIGN KEY ([ADDRESS_ID]) REFERENCES [M_ADDRESS] ([ADDRESS_ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_M_TIMESHEET_M_DOCTOR_CPF] FOREIGN KEY ([CPF]) REFERENCES [M_DOCTOR] ([CPF]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE TABLE [M_DAYS_OF_THE_WEEK] (
        [DAYS_ID] int NOT NULL IDENTITY,
        [NAME] int NOT NULL,
        [TIME_SHEET_ID] int NOT NULL,
        CONSTRAINT [PK_M_DAYS_OF_THE_WEEK] PRIMARY KEY ([DAYS_ID]),
        CONSTRAINT [FK_M_DAYS_OF_THE_WEEK_M_TIMESHEET_TIME_SHEET_ID] FOREIGN KEY ([TIME_SHEET_ID]) REFERENCES [M_TIMESHEET] ([TIMESHEET_ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE INDEX [IX_M_ADDRESS_Cpf] ON [M_ADDRESS] ([Cpf]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE INDEX [IX_M_DAYS_OF_THE_WEEK_TIME_SHEET_ID] ON [M_DAYS_OF_THE_WEEK] ([TIME_SHEET_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE UNIQUE INDEX [IX_M_DOCTOR_USER_ID] ON [M_DOCTOR] ([USER_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE UNIQUE INDEX [IX_M_TIMESHEET_ADDRESS_ID] ON [M_TIMESHEET] ([ADDRESS_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE UNIQUE INDEX [IX_M_TIMESHEET_CPF] ON [M_TIMESHEET] ([CPF]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    CREATE UNIQUE INDEX [IX_P_PATIENT_USER_ID] ON [P_PATIENT] ([USER_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514024349_Initialize')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200514024349_Initialize', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    DROP INDEX [IX_M_TIMESHEET_CPF] ON [M_TIMESHEET];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    CREATE TABLE [APPOINTMENT] (
        [APPOINTMENT_ID] int NOT NULL IDENTITY,
        [APPOINTMENT_TIME] datetime2 NOT NULL,
        [STATUS] int NOT NULL,
        [RE_SCHEDULED_APPOINTMENT_ID] int NOT NULL,
        [DOCTOR_CPF] nvarchar(11) NOT NULL,
        [PATIENT_CPF] nvarchar(30) NOT NULL,
        [ADDRESS_ID] int NOT NULL,
        CONSTRAINT [PK_APPOINTMENT] PRIMARY KEY ([APPOINTMENT_ID]),
        CONSTRAINT [FK_APPOINTMENT_M_ADDRESS_ADDRESS_ID] FOREIGN KEY ([ADDRESS_ID]) REFERENCES [M_ADDRESS] ([ADDRESS_ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_APPOINTMENT_M_DOCTOR_DOCTOR_CPF] FOREIGN KEY ([DOCTOR_CPF]) REFERENCES [M_DOCTOR] ([CPF]) ON DELETE NO ACTION,
        CONSTRAINT [FK_APPOINTMENT_P_PATIENT_PATIENT_CPF] FOREIGN KEY ([PATIENT_CPF]) REFERENCES [P_PATIENT] ([CPF]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    CREATE INDEX [IX_M_TIMESHEET_CPF] ON [M_TIMESHEET] ([CPF]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    CREATE INDEX [IX_APPOINTMENT_ADDRESS_ID] ON [APPOINTMENT] ([ADDRESS_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    CREATE INDEX [IX_APPOINTMENT_DOCTOR_CPF] ON [APPOINTMENT] ([DOCTOR_CPF]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    CREATE INDEX [IX_APPOINTMENT_PATIENT_CPF] ON [APPOINTMENT] ([PATIENT_CPF]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200516190916_CreateAppointmentTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200516190916_CreateAppointmentTable', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524215641_AlterarCamposTimeSheet')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[M_TIMESHEET]') AND [c].[name] = N'APPOINTMENT_DURATION');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [M_TIMESHEET] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [M_TIMESHEET] ALTER COLUMN [APPOINTMENT_DURATION] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524215641_AlterarCamposTimeSheet')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[M_TIMESHEET]') AND [c].[name] = N'APPOINTMENT_CANCEL_TIME');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [M_TIMESHEET] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [M_TIMESHEET] ALTER COLUMN [APPOINTMENT_CANCEL_TIME] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524215641_AlterarCamposTimeSheet')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200524215641_AlterarCamposTimeSheet', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528011443_AddFieldFodase')
BEGIN
    ALTER TABLE [APPOINTMENT] ADD [APPOINTMENT_END_TIME] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200528011443_AddFieldFodase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200528011443_AddFieldFodase', N'2.2.6-servicing-10079');
END;

GO

