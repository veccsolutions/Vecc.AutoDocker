$oldInfoPreference = $InformationPreference
$InformationPreference = "Continue"

$currentVersion = [version](Get-Content .version | select -First 1)
$newVersion = "{0}.{1}" -f $currentVersion.Major, ($currentVersion.Minor + 1)
Set-Content -Path .version -Value $newVersion

$imageNamePrefix = "docker.veccsolutions.org:5000/autodocker"
$imageName = "${imageNamePrefix}:${newVersion}"
$imageNameLatest = "${imageNamePrefix}:latest"

docker build -t $imageName -t $imageNameLatest .
docker image push $imageName
docker image push $imageNameLatest

Write-Information "New Version: ${newVersion}"
$InformationPreference = $oldInfoPreference