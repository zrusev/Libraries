$usrName = $env:UserName
$destinationFolderName = "JS Dashboard"
$sourceRoot = "C:\Users\" + $destinationFolderName + "\"
$destinationRoot = "C:\Users\" + $usrName + "\Desktop\"
$pathOnDesktop = $destinationRoot + $destinationFolderName

if(!(Test-Path $pathOnDesktop -PathType Container)) { 
    write-host "-- Path not found"
} else {
    write-host "-- Path found"
	Remove-Item $pathOnDesktop -Force -Recurse
}

 write-host "-- Copy provider"
 write-host "-- Wait a second"
 
 Copy-Item -Path $sourceRoot -Filter "*.*" -Recurse -Destination $destinationRoot -Container
 
 write-host "-- Almost done"
 
 $item = "C:\Users\" + $usrName + "\Desktop\" + $destinationFolderName + "\index.html"
 Invoke-item $item

 # if ($Host.Name -eq "ConsoleHost")
 # {
     # Write-Host "Press any key to continue..."
     # $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyUp") > $null
 # }