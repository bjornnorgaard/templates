function Add-CrudEntity () {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $True, Position = 0)]
        [string] $Entity,
        [Parameter(Mandatory = $False, Position = 2)]
        [string] $Folder = "."
    )

    Process {
        # Create folders.
        New-Item -Path ..\Source\Api.Web\Controllers -Name ${Entity} -ItemType Directory
        New-Item -Path ..\Source\Api.Nuget -Name ${Entity} -ItemType Directory
        New-Item -Path ..\Source\Application\Features -Name ${Entity} -ItemType Directory
        New-Item -Path ..\Source\Test.Arrange\Features -Name ${Entity} -ItemType Directory
        New-Item -Path ..\Source\Test.Unit\Features -Name ${Entity} -ItemType Directory
        New-Item -Path ..\Source\Test.Integration\Features -Name ${Entity} -ItemType Directory

        # Create RestEase service.
        copy-item -Path .\Template\Api.Nuget\Pet\IPetService.cs -Destination ..\Source\Api.Nuget\${Entity}\I${Entity}Service.cs

        # Create features.
        Copy-Item -Path .\Template\Application\Features\Pet\CreatePet.cs -Destination ..\Source\Application\Features\${Entity}\Create${Entity}.cs
        Copy-Item -Path .\Template\Application\Features\Pet\GetPet.cs -Destination ..\Source\Application\Features\${Entity}\Get${Entity}.cs
        Copy-Item -Path .\Template\Application\Features\Pet\GetAllPet.cs -Destination ..\Source\Application\Features\${Entity}\GetAll${Entity}.cs
        Copy-Item -Path .\Template\Application\Features\Pet\UpdatePet.cs -Destination ..\Source\Application\Features\${Entity}\Update${Entity}.cs
        Copy-Item -Path .\Template\Application\Features\Pet\DeletePet.cs -Destination ..\Source\Application\Features\${Entity}\Delete${Entity}.cs
        Copy-Item -Path .\Template\Application\Features\Pet\MappingProfile.cs -Destination ..\Source\Application\Features\${Entity}\MappingProfile.cs

        # Create controller.
        Copy-Item -Path .\Template\Api.Web\Controllers\PetController.cs -Destination ..\Source\Api.Web\Controllers\${Entity}\${Entity}Controller.cs

        # Create repository configuration.
        Copy-Item -Path .\Template\Repository\Configurations\PetConfiguration.cs -Destination ..\Source\Repository\Configurations\${Entity}Configuration.cs

        # Create model.
        Copy-Item -Path .\Template\Models\Pet.cs -Destination ..\Source\Models\${Entity}.cs

        # Create arrange helper for testing.
        Copy-Item -Path .\Template\Test.Arrange\Features\Pet\ContextHelper.cs -Destination ..\Source\Test.Arrange\Features\${Entity}\ContextHelper.cs
        Copy-Item -Path .\Template\Test.Arrange\Features\Pet\CreatePetHelper.cs -Destination ..\Source\Test.Arrange\Features\${Entity}\Create${Entity}Helper.cs
        Copy-Item -Path .\Template\Test.Arrange\Features\Pet\UpdatePetHelper.cs -Destination ..\Source\Test.Arrange\Features\${Entity}\Update${Entity}Helper.cs

        # Create unit tests.
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\CreatePetHandlerTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Create${Entity}HandlerTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\CreatePetValidatorTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Create${Entity}ValidatorTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\GetAllPetHandlerTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\GetAll${Entity}HandlerTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\GetAllPetValidatorTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\GetAll${Entity}HandlerTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\GetPetHandlerTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Get${Entity}HandlerTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\GetPetValidatorTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Get${Entity}ValidatorTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\UpdatePetHandlerTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Update${Entity}HandlerTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\UpdatePetValidatorTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Update${Entity}ValidatorTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\DeletePetHandlerTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Delete${Entity}HandlerTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\DeletePetValidatorTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\Delete${Entity}ValidatorTests.cs
        Copy-Item -Path .\Template\Test.Unit\Features\Pet\MappingProfileTests.cs -Destination ..\Source\Test.Unit\Features\${Entity}\MappingProfileTests.cs

        # Create integration tests.
        Copy-Item -Path .\Template\Test.Integration\Features\Pet\CreatePetTests.cs -Destination ..\Source\Test.Integration\Features\${Entity}\Create${Entity}Tests.cs
        Copy-Item -Path .\Template\Test.Integration\Features\Pet\GetAllPetTests.cs -Destination ..\Source\Test.Integration\Features\${Entity}\GetAll${Entity}Tests.cs
        Copy-Item -Path .\Template\Test.Integration\Features\Pet\GetPetTests.cs -Destination ..\Source\Test.Integration\Features\${Entity}\Get${Entity}Tests.cs
        Copy-Item -Path .\Template\Test.Integration\Features\Pet\UpdatePetTests.cs -Destination ..\Source\Test.Integration\Features\${Entity}\Update${Entity}Tests.cs
        Copy-Item -Path .\Template\Test.Integration\Features\Pet\DeletePetTests.cs -Destination ..\Source\Test.Integration\Features\${Entity}\Delete${Entity}Tests.cs

        # Find and rename tags.
        Rename-EntityInFiles -OldString "\[Entity\]" -NewString ${Entity} -Folder "..\Source"
        Rename-EntityInFiles -OldString "\[Entity.ToLower\]" -NewString ${Entity}.ToLower() -Folder "..\Source"

        Write-Host ""
        Write-Host "Remember to add the model to Context.cs as a 'public DbSet<${Entity}> ${Entity}s'!"
    }
}

function Rename-EntityInFiles () {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $True, Position = 0)]
        [string] $OldString,
        [Parameter(Mandatory = $True, Position = 1)]
        [string] $NewString,
        [Parameter(Mandatory = $False, Position = 2)]
        [string] $Folder = "."
    )

    Process {
        Foreach ($Child in Get-ChildItem -Path $Folder) {
            if ($Child -is [System.IO.DirectoryInfo]) {
                Rename-EntityInFiles -OldString $OldString -NewString $NewString -Folder $Child.FullName
            }

            if ($Child -isnot [System.IO.DirectoryInfo]) {
                $RawContent = Get-Content -Path $Child.FullName -Raw
                $UpdatedContent = $RawContent -replace $OldString, $NewString
                Set-Content -Path $Child.FullName -Value $UpdatedContent
            }
        }
    }
}

$NewName = Read-Host -Prompt "New Entity to add"
Add-CrudEntity -Entity $NewName

Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');
