ALTER TABLE dbo.Users
ADD CONSTRAINT df_LastLoginTime
DEFAULT CURRENT_TIMESTAMP FOR LastLoginTime