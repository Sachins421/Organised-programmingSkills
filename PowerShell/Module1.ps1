# Declare how variable are created
$Variable

# Assign value to the variable
$Variable = 1

# Do something with variable
$variable = $Variable + 1

# Show the variable value
$Variable

# Numbers in powershell
$variable = $Variable + 0.5
$variable = $Variable - 0.3
$variable = $Variable * 2
$variable = $Variable / 3

# Order of operations
$Variable = 1
$Variable = $Variable + 1 * 4
$Variable = ($Variable + 3) * 1

# add letters
$Variable = $Variable + 'Sachin'

# Variable can just change
$Variable = 'Sachin'
$Variable = $Variable + 1

# Now add "thing"
$Variable = $Variable + "Shukla"

# String and string literals
$Number1 = 1
$Number10 = 10

$String = "I can thing of between $Number1 and $Number10"

$String = "I thing only about $100"
$String

$String = 'I thing only about $100'
$String

$String = 'I can thing of between $Number1 and $Number10'
$String

$String = 'I can thing of between ' + $Number1 + ' and ' + $Number10

# Booleans
$FlagVariable = $true
$FlagVariable
$FlagVariable = $false
$FlagVariable

# Decalre Arrays
$ArrayVar = @(1, 2, 3, 4)
$ArrayVar

$ArrayVar[0]
$ArrayVar[1]
$ArrayVar[2]
$ArrayVar[4]
$ArrayVar[5]
$ArrayVar[10] # does not exist

$ArrayVar[1] = 'New Value'
$ArrayVar[10] = 'Old value' # Index was outside the bounds of the array.

$ArrayVar = $ArrayVar + 'add value'

# subtract from an array
$ArrayVar = $ArrayVar - 1

# Are there any restriction
# $true = 1
# $false = 'Sachin'

# Starting from numbers
$123 = 123 # not recommended