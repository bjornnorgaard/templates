# Updating Database

Use the VS Package Manager Console. Set the TMP.Api.Web as the startup project and the TMP.Repository project as the Default Project.

1. Change model
2. Add migration.
3. Apply migration.

```c
// Add migration, with PascalCased name
add-migration NameOfMigration

// Apply migration with verbose flag -v
update-database -v
```
