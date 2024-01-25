using System;
using System.ComponentModel.Design;
using System.Data;

Console.Title = "Blindeo Game";

int Manticore = 10;
int City = 15;
int round = 1; // Initiating the objects required for the game.

int Damage(int dmg)
{
if (round % 5 == 0 && round % 3 == 0) return 10; // Electric & Fire
else if (round % 5 == 0 || round % 3 == 0) return 3; // Fire
return 1; // Normal
}

int userInput(string text)
{
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.Cyan;
    int number = int.Parse(Console.ReadLine());
    return number; // The user input method.
}

int inputRange(string text)
{
    while (true)
    {
        int number = userInput(text);
        if (number >= 0 && number < 100)
            return number; // Checks if the user input is between the predetermined min & max.
        else
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Sorry, that's outside the bounds of the city, input a coordinate between 0 and 100."); // Displayed when the min or max are broken.
    }
}

do
{
    int dmg = Damage(round); // Calls the method to see what the damage this round will be.

    int pilotNum = inputRange("Pilot, choose where you will fly the SS Manticore: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Clear(); // The first player inputs where they want o tgo and it gets cleared to prevent cheating.

     Console.WriteLine($"Round: {round}. City HP: {City}/15. Manticore HP {Manticore}/10."); // Round information is displayed.

    {
        if (dmg == 10)
            Console.ForegroundColor = ConsoleColor.Blue;
        else if (dmg == 3)
            Console.ForegroundColor = ConsoleColor.Red; // Colour of text changes depending on damage multiplier.
    }

    Console.WriteLine($"The cannon is expected to do {dmg} damage");
    Console.ForegroundColor = ConsoleColor.White; // Displays the expected damage and changes text back to normal colour.

    
    int soldierNum = inputRange("Soldier, choose where you will fire the cannon: ");
    Console.ForegroundColor = ConsoleColor.White; // Second player inputs guess, changes colour back to normal.

    if (pilotNum == soldierNum && dmg == 1)
    {
        Console.WriteLine($"That was a direct hit on the Manticore, it dealt {dmg} damage!");
        Manticore -= Damage(round); // If the ship is hit, displays this message and colour. Also subtracts damage from ship health.
    }
    else if (pilotNum == soldierNum && dmg == 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"That was a direct hit on the Manticore, it dealt {dmg} fire damage!");
        Manticore -= Damage(round); // If the ship is hit, displays this message and colour. Also subtracts damage from ship health.
    }
    else if (pilotNum == soldierNum && dmg == 10)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"That was a direct hit on the Manticore, it dealt {dmg} electro-fire damage, instantly killing it!");
        Manticore -= Damage(round); // If the ship is hit, displays this message and colour. Also subtracts damage from ship health.
    }
    else if (pilotNum < soldierNum)
    {
        Console.WriteLine("You overshot and missed the Manticore!");
        City--; // Displays relevant miss message and subtracts city health.
    }
    else
    {
        Console.WriteLine("You undershot and missed the Manticore!");
        City--; // Displays relevant miss message and subtracts city health.
    }
    
    Console.ForegroundColor= ConsoleColor.White;
    round++; // Changes text back to normal colour and progresses round.
}
while (Manticore > 0 && City > 0); // Program will loop until at least one condition is no longer met.

if (City <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("You took too long and the Manticore has destroyed the city! It is so unbelievably over!"); // If city reaches 0 first, display relevant message in specified colour.
}
else if (Manticore <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("You did it! You destroyed the Manticore! We are so back!"); // If ship reaches 0 first, display relevant message in specified colour.
}