[CmdletBinding()]
Param (
    [Parameter(Mandatory)]
    [string]$CloneUrl
)

# Extract name of service from clone url
$ServiceName = (Get-Culture).TextInfo.ToTitleCase($CloneUrl.Split("/")[-1].Replace(".git", ""))

# Clone repository
Write-Host "Cloning $CloneUrl into folder $ServiceName"
Invoke-Expression ".\Scripts\Add-GitRemote.ps1 -Remote $CloneUrl -Name $ServiceName"
$ProjectFolder = (Get-Item -Path "..\$ServiceName").FullName

# Check if repo is empty
$NotEmpty = Test-Path "$ProjectFolder\Source"
if ($NotEmpty) {
    Write-Host "The repository is not empty. Make sure to run this script on a fresh repository"
    Read-Host "Press 'Enter' to continue"
    return
}

# Copy template to cloned repo
Write-Host "Copying template..."
Copy-Item -Path ".\Template\*" -Destination $ProjectFolder -Recurse

# Run renaming in copied folder
Write-Host "Renaming project in folder $ProjectFolder with shortname: $ServiceName..."
Invoke-Expression ".\Scripts\Rename-Project.ps1 -Folder $ProjectFolder -NewName $ServiceName"

# Create initial commit
Write-Host "Creating and pushing initial commit..."
Invoke-Expression ".\Scripts\Add-InitialCommit.ps1 -Folder $ProjectFolder"

# Add helm

# Setup TeamCity

# Setup Octo

# Inform user
Write-Host "You're ready to go. Happy coding!"
Read-Host -Prompt "Press 'Enter' to continue"