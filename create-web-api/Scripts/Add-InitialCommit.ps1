[CmdletBinding()]
Param (
    [Parameter(Mandatory)]
    [string]$Folder
)

$OriginalPath = (Get-Item -Path ".").FullName

Invoke-Expression "cd $Folder"
Invoke-Expression "git add --all"
Invoke-Expression "git commit -m 'Initial commit'"
Invoke-Expression "git push origin master"

Invoke-Expression "cd $OriginalPath"

