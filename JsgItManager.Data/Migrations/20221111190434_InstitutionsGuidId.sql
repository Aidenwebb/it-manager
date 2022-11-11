START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM __ef_migrations_history WHERE "migration_id" = '20221111190434_InstitutionsGuidId') THEN
        ALTER TABLE institutions ALTER COLUMN id DROP IDENTITY;
        ALTER TABLE institutions ALTER COLUMN id TYPE uuid using gen_random_uuid();
        ALTER TABLE institutions ALTER COLUMN id SET DEFAULT (gen_random_uuid());
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM __ef_migrations_history WHERE "migration_id" = '20221111190434_InstitutionsGuidId') THEN
    INSERT INTO __ef_migrations_history (migration_id, product_version)
    VALUES ('20221111190434_InstitutionsGuidId', '7.0.0');
    END IF;
END $EF$;
COMMIT;

