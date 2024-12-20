class Racemanager
    {

    List<Rider> Riders = [
        new Rider("Speedy Rider", 5, 1), 
        new Rider("The Dwarvish Rider", 3, 2)
        ]; //listar alla spelarval
    
    List<Kart> Karts = [
        new Kart("Little Speedy", 10, 3), 
        new Kart("The Short Stone", 5, 5)]; //listar alla fordon
    
    Rider playerRider;
    Rider botRider;
    Kart playerKart;
    Kart botKart;
    Random rand = new Random();
    
    public Racemanager() //hamnar i Program. Skriv vidare här
    {
        chooseCharacter();
        chooseKart();
        Console.WriteLine("Would you like to start the race or view your chosen character and kart info?"); //Ger valet starta racet eller skriva ut information
        Console.WriteLine("1. Start The Race!");
        Console.WriteLine("2. View my character and kart Info!");
        int playerInput = Convert.ToInt32(Console.ReadLine());
        switch (playerInput)
        {
            case 1:
                break; //Valde att starta racet

            case 2:
                PrintInfo();
                break; //Valde att skriva ut information
        }

        Console.WriteLine("Starting race...");
        opponentBot();
        Console.WriteLine("Good luck!");


        //Race start
        double realTrackProgress = 0;
        double realBotTrackProgress = 0;

        int speedTotal = playerRider.SpeedAdd + playerKart.KartSpeed;
        int accelerationTotal = playerRider.AccelerationAdd + playerKart.KartAcceleration;

        int botSpeedTotal = botRider.SpeedAdd + botKart.KartSpeed;
        int botAccelerationTotal = botRider.AccelerationAdd + botKart.KartAcceleration;

        int randomBalancer = 0;
        int randomBotBalancer = 0;
        double trackProgress = 0;
        double botTrackProgress = 0;

        while (realTrackProgress < 100 && realBotTrackProgress < 100)
        {
            randomBalancer = rand.Next(4, 13);
            randomBotBalancer = rand.Next(5, 13);
            trackProgress = speedTotal * accelerationTotal / randomBalancer;
            botTrackProgress = botSpeedTotal * botAccelerationTotal / randomBotBalancer;
            
            if (trackProgress >= 10)
            {
                Console.WriteLine("You make an incredible turn, just scrapping the wall gaining you a good distance! Your current progress is {0} meters", realTrackProgress);
                Console.WriteLine("Your opponents progress is {0}", realBotTrackProgress);
                Console.WriteLine("");
            } 
            else if (trackProgress >= 5 && trackProgress < 10)
            {
                Console.WriteLine("You do not do anything special, but gain a pretty good distance. Your current progress is {0} meters", realTrackProgress);
                Console.WriteLine("Your opponents progress is {0}", realBotTrackProgress);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("You unfortunately crash into a wall and loose a lot of speed. Your current progress is {0} meters", realTrackProgress);
                Console.WriteLine("Your opponents progress is {0}", realBotTrackProgress);
                Console.WriteLine("");
            }
            
            Thread.Sleep(3000);
            
            if (botTrackProgress >= 10)
            {
                Console.WriteLine("Your opponent does an incredible turn, gaining alot of distance!");
            } else if (botTrackProgress >= 5 && botTrackProgress < 10)
            {
                Console.WriteLine("Your opponent does not do anything special");
            } else
            {
                Console.WriteLine("Your opponent crases into a wall, loosing alot of speed");
            }

            realTrackProgress = realTrackProgress + trackProgress;
            realBotTrackProgress = realBotTrackProgress + botTrackProgress;
        }

        if (realTrackProgress >= 100)
        {
            Console.WriteLine("Congratulations! You won!"); //Har inte tid att göra något mer

        } else if (realBotTrackProgress >= 100)
        {
            Console.WriteLine("You unfortunately lost!");
        }

    }

    
    
    
    
    void chooseCharacter()
    {
        Console.WriteLine("Choose your character! ");
        for (int i = 0; i < Riders.Count; i++)
        {
            Console.WriteLine(i+1 + ". " + Riders[i].RiderName);
        } //skriver ut alla karaktärer
        bool validPlayerInput = false;
        while (!validPlayerInput) //Startar en while loop för att välja karaktär
        {
            int playerInput = Convert.ToInt32(Console.ReadLine());
            if (playerInput > 0 && playerInput <= Riders.Count) //om spelarens input är rätt så körs if satsen
            {
                playerRider = Riders[playerInput - 1]; //ger playerRider den ridern som faktiskt valts
                Console.WriteLine("You have choosen " + playerRider.RiderName + "!"); //skriver ut valet av karaktär
                validPlayerInput = true; //tar oss ur loopen
            }
            else
            {
                Console.WriteLine("Write the number correspodning to the driver!"); //Tvingar användaren att skriva rätt
            }
            //Om val att byta karaktär, skriv här
        }
    }

    void chooseKart()
    {
        Console.WriteLine("Choose your Kart! ");
        for (int i = 0; i < Karts.Count; i++)
        {
            Console.WriteLine(i + 1 + ". " + Karts[i].KartName);
        } //skriver ut alla karts
        bool validPlayerInput = false;
        while (!validPlayerInput) //Startar en while loop för att välja kart
        {
            int playerInput = Convert.ToInt32(Console.ReadLine());
            if (playerInput > 0 && playerInput <= Karts.Count) //om spelarens input är rätt så körs if satsen
            {
                playerKart = Karts[playerInput - 1]; //ger playerRider den ridern som faktiskt valts
                Console.WriteLine("You have choosen " + playerKart.KartName + "!"); //skriver ut valet av karaktär
                validPlayerInput = true; //tar oss ur loopen
            }
            else
            {
                Console.WriteLine("Write the number correspodning to the driver!"); //Tvingar användaren att skriva rätt
            }
            //Om val att byta kart, skriv här
        }
    }

    void PrintInfo() //Skriver ut informationen om den valda karaktären och kart. 
    {
        Console.WriteLine("You are " + playerRider.RiderName + ". You have " + playerRider.SpeedAdd + " bonus speed and you have " + playerRider.AccelerationAdd + " bonus acceleration.");
        Console.WriteLine("Your kart is " + playerKart.KartName + ". It has " + playerKart.KartSpeed + " speed and it has " + playerKart.KartAcceleration + " acceleratin.");

        int speedTotal = playerRider.SpeedAdd + playerKart.KartSpeed;
        int accelerationTotal = playerRider.AccelerationAdd + playerKart.KartAcceleration;
        
        Console.WriteLine("Your total speed is " + speedTotal + " and your total acceleration is " + accelerationTotal + ".");
    }

    void opponentBot()
    {
        int botRiderChoice = rand.Next(0, 2);
        int botKartChoice = rand.Next(0, 2);
        botRider = Riders[botRiderChoice];
        botKart = Karts[botKartChoice];

        int botSpeedTotal = botRider.SpeedAdd + botKart.KartSpeed;
        int botAccelerationTotal = botRider.AccelerationAdd + botKart.KartAcceleration;
        Console.WriteLine("Your opponent is " + botRider.RiderName + ". Their kart is " + botKart.KartName + " and their total speed is " + botSpeedTotal + ". Their total acceleration is " + botAccelerationTotal + ".");
    }
}