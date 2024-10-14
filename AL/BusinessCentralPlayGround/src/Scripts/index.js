function Greet(FirstName, LastName)
{
    let GreetingText = "Hello" + FirstName;

    if(LastName != null)
        GreetingText += "" + LastName;

    console.log(GreetingText);

}