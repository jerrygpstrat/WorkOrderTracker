

# all decimal fields on entity should have this attribute so migration wont fail
 [Column(TypeName = "decimal(18,2)")]

# on DataLayer we must use parameter -context WoTrackerDbContext to avoid multiple DbContext failure on migrations
  Add-migration initialEntities -context WoTrackerDbContext


# same for update-database command
update-database -context WoTrackerDbContext



