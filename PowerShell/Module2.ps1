# Save result in variable
$Command = Get-Command

# Save result in variable and in external file
$Command | Out-File 'C:\Users\sachin.shukla\OneDrive - Mister Spex\Documents\Powershell_Assingment\Text Files\Command.txt'
$Command | Out-File 'C:\Users\sachin.shukla\OneDrive - Mister Spex\Documents\Powershell_Assingment\Text Files\Command.csv'
# $Command | Out-File 'C:\Users\sachin.shukla\OneDrive - Mister Spex\Documents\Powershell_Assingment\Text Files\Command.xlsx'

# Show result in powershell grid view 
Get-ChildItem | Select-Object LastWriteTime, Name | Out-GridView 

$Command = Get-Content -Path 'C:\Users\sachin.shukla\Organised-programmingSkills\PowerShell\Text Files\TestFile.txt'
$Command | Get-Member

# Contains the variable in the string
$Command.Contains('S')

# Get type like details of the variable 
$Command.GetType() 
$Command.GetHashCode()
$Command.IndexOf('sachin')

$Command.CopyTo(3,1,1,1)