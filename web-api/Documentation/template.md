# Template
This project is meant to be copied when a new backend Web API services is needed.

The following infrastructure is implemented and setup.

- [x] Controllers
- [x] Swagger
- [x] Configuration
- [x] Healthchecks
- [x] Docker
- [x] Mediatr pipeline
- [x] Logging
- [x] Entity Framework Core
- [x] Database access
- [ ] Lazy loading
- [x] Integrationtesting
- [x] Unittesting
- [ ] Versioning
- [ ] Temporal tables
- [x] Automapper
- [ ] OData
- [x] CORS
- [x] Documentation
- [x] Correlation ID
- [ ] Authorization
- [ ] Authentication
- [ ] NuGet Rest consumer lib

# Using the template

A script is located in the root folder.
Before executing the script the ExecutionPolicy needs to be changed. To do this, open a PowerShell as administrator and execute the following:

```ps
# Get the current policy
Get-ExecutionPolicy

# Update policy to run script
Set-ExecutionPolicy -ExecutionPolicy Unrestricted
```

## Before running the script

- Make sure none of the files are open in editors.

## Running the script
Run the powershell script `Rename-Project.ps1` by right-clicking it and select `Run with PowerShell`.
Then provide the new short name for the project and the script will rename all files, folders and relevant kode to work with the new name.
