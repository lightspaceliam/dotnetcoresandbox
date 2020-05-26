using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Extensions
{
    public static class MigrationExtensions
    {
        public static void AddTemporalTableSupport(this MigrationBuilder builder, string tableName, string schema = "dbo", string historyTableSchemaPart = "History")
        {
            var createPrimarySchemaIfNotExists = $@"
                IF NOT EXISTS ( SELECT  *
                                FROM    sys.schemas
                                WHERE   name = N'{schema}' )
	                BEGIN
		                EXEC('CREATE SCHEMA [{schema}]');
	                END
            ";
            builder.Sql(createPrimarySchemaIfNotExists);

            var createHistorySchemaIfNotExists = $@"
                IF NOT EXISTS ( SELECT  *
                                FROM    sys.schemas
                                WHERE   name = N'{schema}{historyTableSchemaPart}' )
	                BEGIN
		                EXEC('CREATE SCHEMA [{schema}{historyTableSchemaPart}]');
	                END
            ";
            builder.Sql(createHistorySchemaIfNotExists);

            var addAppropriateVersioningColumnsToTable = $@"
                ALTER TABLE [{schema}].[{tableName}] 
                ADD     [ValidFrom] datetime2(7) GENERATED ALWAYS AS ROW START NOT NULL
                        , [ValidTo] datetime2(7) GENERATED ALWAYS AS ROW END NOT NULL
                        , PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo]);
            ";
            builder.Sql(addAppropriateVersioningColumnsToTable);

            var applySystemVersioningToTable = $@"
                ALTER TABLE [{schema}].[{tableName}] 
                SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [{schema}{historyTableSchemaPart}].[{tableName}]));
            ";
            builder.Sql(applySystemVersioningToTable);
        }

        public static void RemoveTemporalTableSupportAndDropTables(this MigrationBuilder builder, string tableName, string schema = "PRO", string historyTableSchema = "History")
        {
            var setSystemVersioningToOff = $@"
                ALTER TABLE [{schema}].[{tableName}] 
                SET     (SYSTEM_VERSIONING = OFF);
            ";
            builder.Sql(setSystemVersioningToOff);

            var dropIndexOnIdIfExists = $@"
                IF EXISTS (
                        SELECT	[name]
	                    FROM	sys.indexes 
	                    WHERE	[name] = 'PK_{tableName}_Id')
	                BEGIN
		                ALTER TABLE [{schema}].[{tableName}] DROP CONSTRAINT [PK_{tableName}_Id];
	                END
            ";
            builder.Sql(dropIndexOnIdIfExists);

            var dropPrimaryTable = $@"
                DROP TABLE [{schema}].[{tableName}];
            ";
            builder.Sql(dropPrimaryTable);

            var dropSystemVersioningTable = $@"
                DROP TABLE [{schema}{historyTableSchema}].[{tableName}];
            ";
            builder.Sql(dropSystemVersioningTable);
        }
    }
}
