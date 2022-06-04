// This is challenge work for the "C# Players Guide"
// Level 21 the Arrow Factories Challenge
// This challenge mirrors the Level 18,19,  and 20 challenges, but requires that that Arrow Class includes static methods for premade arrow types 
// The user will select from 4 arrows.  One that is custom and three that are made using static methods in the Arrow Class. 

//Main
Arrow arrow = StartMenu();
float ArrowCost = arrow.GetCost;
FinalCloseOut(arrow, ArrowCost);


//Methods
Arrow? StartMenu()
{
    char face = ((char)2);
    int UserChoice = 0;
    while (UserChoice < 1 || UserChoice > 4)
    {
        Console.WriteLine("***************Arrow Factory 3000: Ready to take your order*************");
        Console.WriteLine("\nWelcome to Vin Fleatcher's High End Arrows");
        Console.WriteLine("Fabulous Arrows for Fabulous Rangers!\n");
        Console.WriteLine("Which arrow type would you like to order?");
        Console.WriteLine("Press 1 for 'Elite Arrows'");
        Console.WriteLine("Press 2 for 'Beginner Arrows'");
        Console.WriteLine("Press 3 for 'Marksman Arrows'");
        Console.WriteLine("Press 4 for handcrafted 'Customized Arrows'");
        UserChoice = Convert.ToInt32(Console.ReadLine());
        if (UserChoice >= 1 && UserChoice <= 4)
        {
            Console.WriteLine("\n" + face + " Press any key to build the arrows of your dreams " + face);
            Console.ReadKey();
            Console.Clear();

            Arrow arrow = UserChoice switch
            {
                1 => Arrow.MakeEliteArrow(),
                2 => Arrow.MakeBeginnerArrow(),
                3 => Arrow.MakeMarksmanArrow(),
                4 => ArrowFactory(),
            };
            return arrow;
        }
        else
        {
            Console.WriteLine($"\nArrow Factory 3000 ERROR:The selection you made {UserChoice} was not a valid choice");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.Clear();
        }
    }
    return null;
}
// ArrowFactory Method (Method of methods) to return new arrow:
// This is needed so that main can call as many arrows as is needed (if needed)
Arrow ArrowFactory()
{
    Console.WriteLine("*******************Arrow Factory 3000: Building order******************");
    Arrowhead ArrowHead = BuildArrowHead(); //must be set to Arrowhead because of the enum
    Fletchingmaterial FletchingMaterial = BuildFletchingMaterial(); //must be set to Fletchingmaterial because of the enum
    float TotalLength = BuildTotalLength();
    return new Arrow(ArrowHead, FletchingMaterial, TotalLength);
}

//must be set to Arrowhead because of the enum
Arrowhead BuildArrowHead()
{
    //Get user info for Arrowhead
    string arrow_info = "null";
    while (arrow_info != "steel" && arrow_info != "wood" && arrow_info != "obsidian")
    {
        Console.WriteLine("\nPlease enter the arrowhead type for your custom arrows (Steel,Wood, or Obsidian): ");
        arrow_info = Console.ReadLine().ToLower();
    }
    Arrowhead head = arrow_info switch //must be set to Arrowhead because of the enum
    {
        //standardized input using enum
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian,
    };
    return head;
}

Fletchingmaterial BuildFletchingMaterial() //must be set to Fletchingmaterial because of the enum
{
    // Get user info for Fletching type
    string fletching_info = "null";
    while (fletching_info != "plastic" && fletching_info != "turkey feathers" && fletching_info != "goose feathers")
    {
        Console.WriteLine("\nPlease enter the Fletching type for your custom arrows (Plastic, Turkey Feathers, or Goose Feathers): ");
        fletching_info = Console.ReadLine().ToLower();
    }
    Fletchingmaterial fletch = fletching_info switch  //must be set to Fletchingmaterial because of the enum
    {
        //standardized input using enum
        "plastic" => Fletchingmaterial.Plastic,
        "turkey feathers" => Fletchingmaterial.TurkeyFeathers,
        "goose feathers" => Fletchingmaterial.GooseFeathers,
    };
    return fletch;
}

float BuildTotalLength()
{
    //Get user info for Arrow Length
    float Length;
    do
    {
        Console.WriteLine("\nPlease enter the shaft length of your custom arrows (Between 60 and 100 cm): ");
        Length = Convert.ToSingle(Console.ReadLine());
    }
    while (Length < 60 || Length > 100);
    return Length;
}

void FinalCloseOut(Arrow arrow, float ArrowCost)
{
    Console.Clear();
    Console.WriteLine("*******************Arrow Factory 3000: Processing order******************");
    Console.WriteLine($"The arrow you requested has the following characteristics: " +
    $"\nThe Arrowhead is made of {arrow.arrowhead}" +
    $"\nThe Fletching is made of {arrow.fletchingmaterial} " +
    $"\nThe Shaft is {arrow.totallength} cm");
    Console.WriteLine($"\nThis type of custom arrow costs a total of {ArrowCost} gold per arrow");
    Console.Write($"\nHow many of these arrows would you like to order?: ");
    float TotalCost = Convert.ToSingle(Console.ReadLine());
    TotalCost *= ArrowCost;
    Console.WriteLine($"\nThe total amount due for these luxury custom arrows: {TotalCost} gold");
    Console.WriteLine("\nThanks for shopping at Vin Fleatchers!");
    Console.WriteLine("\nPress any key to exit the Arrow Factory 3000");
    Console.ReadKey();
}
class Arrow
{
    //must be set to Arrowhead because of the enum
    //must be set to Fletchingmaterial because of enum
    // Set to public and use get
    public Arrowhead arrowhead { get; }
    public Fletchingmaterial fletchingmaterial { get; }
    public float totallength { get; }

    //must be set to Arrowhead because of the enum
    //must be set to Fletchingmaterial because of enum
    // Updated Lines 92 - 94 to use "get" in property rather than get methods. 
    public Arrow(Arrowhead ArrowHead, Fletchingmaterial FletchingMaterial, float TotalLength)
    {
        arrowhead = ArrowHead;
        fletchingmaterial = FletchingMaterial;
        totallength = TotalLength;
    }

    //Methods to create premade arrows
    public static Arrow MakeEliteArrow() => new Arrow(Arrowhead.Steel, Fletchingmaterial.Plastic, 95);
    public static Arrow MakeBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletchingmaterial.GooseFeathers, 75);
    public static Arrow MakeMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletchingmaterial.GooseFeathers, 65);


    //Method for total price replaced with get. Had to replace the method call on line 9
    public float GetCost
    {
        get
        {
            float HeadCost = arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5
            };

            float FletchingCost = fletchingmaterial switch
            {
                Fletchingmaterial.Plastic => 10,
                Fletchingmaterial.TurkeyFeathers => 5,
                Fletchingmaterial.GooseFeathers => 3,
            };

            float LengthCost = .05f * totallength;
            return HeadCost + FletchingCost + LengthCost;

        }
    }
}



//Enum
enum Arrowhead { Steel, Wood, Obsidian }
enum Fletchingmaterial { Plastic, TurkeyFeathers, GooseFeathers }
