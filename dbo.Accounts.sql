CREATE TABLE [dbo].[Accounts] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Balance]  DECIMAL (18, 2) NOT NULL,
    [IBAN_Number]   VARCHAR(34)             NOT NULL,
    [Name]     NVARCHAR (100)  NOT NULL,
    [IdClient] INT             NOT NULL,
    CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

