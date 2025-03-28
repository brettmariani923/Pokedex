
  CREATE PROCEDURE [dbo].[SeedTable_Types] AS
BEGIN

    PRINT 'Populating records in [dbo].[Types]';

    IF OBJECT_ID('tempdb.dbo.#dbo_SeedTypes') IS NOT NULL DROP TABLE #dbo_SeedTypes;

    SELECT 
        [Id], [Name] 
    INTO #dbo_SeedTypes 
    FROM [dbo].[Types] 
    WHERE 0 = 1;

    INSERT INTO #dbo_SeedTypes 
        ( [Id], [Name] )
    SELECT 
          [Id], [Name] 
    FROM 
    (  VALUES
            (0, 'Fire')
          , (1, 'Water')
          , (2, 'Flying')
          , (3, 'Fighting')
          , (4, 'Steel')
          , (5, 'Ground')
          , (6, 'Psychic')
          , (7, 'Rock')
          , (8, 'Grass')
          , (9, 'Electric')
          , (10, 'Ice')
          , (11, 'Bug')
          , (12, 'Poison')
          , (13, 'Ghost')
          , (14, 'Dark')
          , (15, 'Dragon')
          , (16, 'Fairy')
          , (17, 'Normal')
          


    ) AS v ( [Id], [Name] );

    WITH cte_data as 
        (SELECT 
            [Id], [Name] 
        FROM #dbo_SeedTypes)
    MERGE [dbo].[Types] as t
        USING cte_data as s ON t.[Id] = s.[Id]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT 
                ([Id], [Name])
            VALUES 
                (s.[Id], s.[Name])
        WHEN MATCHED 
            THEN UPDATE SET 
                [Name] = s.[Name]
    ;

    DROP TABLE #dbo_SeedTypes;

    PRINT 'Finished Populating records in [dbo].[Types]'
END
GO

EXEC [dbo].[SeedTable_Types];

DROP PROCEDURE IF EXISTS [dbo].[SeedTable_Types] 
GO
