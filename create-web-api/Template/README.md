# ASP.NET Core Template
This project is meant to be copied when a new backend Web API services is needed. Most questions should hopefully be addressed by the [FAQ](#faq) in the buttom.

- [ASP.NET Core Template](#aspnet-core-template)
- [Using the template](#using-the-template)
- [Documentation](#documentation)
- [FAQ](#faq)

# Using the template
This section descripes how to get started with the template.

- **Important**: _Make sure none of the files are open in editors._
- Copy the `/src` folder and `Rename-Project.ps1` script into your own repository.
- Run the script, see walkthough below...
- Commit the changes immediately.

A script is located in the root folder.
Before executing the script the ExecutionPolicy needs to be changed. To do this, open a PowerShell as administrator and execute the following:

```ps
# Update policy to run script
Set-ExecutionPolicy -ExecutionPolicy Unrestricted
```

Next, run the powershell script `Rename-Project.ps1` by right-clicking it and select `Run with PowerShell`.
Then provide a new short name for the project and the script will rename all files, folders and relevant code to work with the new name.

Additional scripts are provided and more information is availeble in the [scripts documentation.](doc/scripts.md)

# Documentation
Further reading is available in the documentation.

- [Template and Features](doc/template.md)
- [Scripts](doc/scripts.md)
- [Mediator Pattern](doc/mediator.md)
- [Database and Entity Framework Core](doc/database.md)
- [Configuration and Environment](doc/configuration.md)
- [Solution Architecture](doc/architecture.md)
- [Docker usage](doc/docker.md)

# FAQ
If something is insuffiently documented or is entirely missing, then please add a description of the desired doc to the list below. Then submit a Pull-Request.

When answered, the question below will link to the updated part of the docs.

- This is how you add questions (bjors)
- [How do I use docker to run the application locally?](doc/docker.md)
- [How do I setup environment configuration for azure hosted applications?](doc/configuration.md)
  - [I need to connect to an on-premise server](doc/configuration.md)
- Solution Architecture: Project Applications has traditionally been named Services, Project Infrastructure have traditionally been named Common
- Mediator as a template pattern is problematic as the current standard is 3-layer architecture (MVC) + repository pattern

