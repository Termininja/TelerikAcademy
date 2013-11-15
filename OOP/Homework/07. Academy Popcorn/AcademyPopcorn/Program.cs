/* 
 *  Task 1. AcademyPopcorn class contains an IndestructibleBlock class. Use it to create side and ceiling walls
 *          to the game. You can ONLY edit the AcademyPopcornMain.cs file.
 *          
 *  Task 2. The Engine class has a hardcoded sleep time (search for "System.Threading.Sleep(500)". Make the sleep
 *          time a field in the Engine and implement a constructor, which takes it as an additional parameter.
 *          
 *  Task 3. Search for a "TODO" in the Engine class, regarding the AddRacket method. Solve the problem mentioned
 *          there. There should always be only one Racket. Note: comment in TODO not completely correct.
 *          
 *  Task 4. Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.
 *  
 *  Task 5. Implement a TrailObject class. It should inherit the GameObject class and should have a constructor
 *          which takes an additional "lifetime" integer. The TrailObject should disappear after a "lifetime"
 *          amount of turns. You must NOT edit any existing .cs file. Then test the TrailObject by adding an
 *          instance of it in the engine through the AcademyPopcornMain.cs file.
 *          
 *  Task 6. Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of TrailObject
 *          objects. Each trail objects should last for 3 "turns". Other than that, the meteorite ball should
 *          behave the same way as the normal ball. You must NOT edit any existing .cs file.
 *          
 *  Task 7. Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.
 *  
 *  Task 8. Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces off UnpassableBlocks
 *          and will destroy any other block it passes through. The UnpassableBlock should be indestructible.
 *          Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method and the CollisionData class.
 *          
 *  Task 9. Test the UnpassableBlock and the UnstoppableBall by adding them to the engine in AcademyPopcornMain.cs file.
 *  
 * Task 10. Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. You must NOT
 *          edit any existing .cs file. Hint: what does an explosion "produce"?
 *          
 * Task 11. Implement a Gift class. It should be a moving object, which always falls down. The gift shouldn't collide
 *          with any ball, but should collide (and be destroyed) with the racket. You must NOT edit any existing .cs file. 
 *          
 * Task 12. Implement a GiftBlock class. It should be a block, which "drops" a Gift object when it is destroyed.
 *          You must NOT edit any existing .cs file. Test the Gift and GiftBlock classes by adding them through the
 *          AcademyPopcornMain.cs file.
 *          
 * Task 13. Implement a shoot ability for the player racket. The ability should only be activated when a Gift object
 *          falls on the racket. The shot objects should be a new class (e.g. Bullet) and should destroy normal Block
 *          objects (and be destroyed on collision with any block). Use the engine and ShootPlayerRacket method you
 *          implemented in task 4, but don't add items in any of the engine lists through the ShootPlayerRacket method.
 *          Also don't edit the Racket.cs file. Hint: you should have a ShootingRacket class and override its ProduceObjects method.
 *          
 * Task 14. Bonus task (optional): Download JustBelot game source from https://github.com/NikolayIT/JustBelot
 *          (code commits are made often so be sure to always work on the latest game source). Write your own C# library
 *          called JustBelot.AI.YourBotName and write a class in it that implements JustBelot.Common.IPlayer interface.
 *          Implement your own AI belot player that will fight with other AI players. The winner will be awarded.
 *          Please send your players to academy@telerik.com and add them in the homework archive when you upload it.
 *          You are allowed to work in teams.This task is not obligatory. Discussions: http://forums.academy.telerik.com/67583/oop-justbelot.
 */

using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class Program
    {
        // Game screen width and height
        const int WorldRows = 26;
        const int WorldCols = 74;

        // Wall constants
        const int WallWidth = 2;
        const int WallGap = 18;

        // Block constants
        const int StartBlockRow = 3;
        const int BlockLines = 6;

        // Racket constatnt
        const int RacketLength = 6;

        // Info-display constants
        const int InfofieldWidth = 20;

        // Drawing all objects
        static void Initialize(Engine engine)
        {
            // Wall coordinates           
            for (int col = 0; col < WorldCols; col += WallGap)
            {
                if (col > WorldCols / 3 && col < 2 * WorldCols / 3) col += WallGap;
                for (int width = col; width < col + WallWidth; width++)
                {
                    for (int row = 0; row <= ((col != 0 && col < WorldCols - WallGap) ? WorldRows - 1 : WorldRows); row++)
                    {
                        if (col != 0 && col < WorldCols - WallGap && row == 2) row = 6;
                        if (col > WallGap && col < WorldCols - WallGap && row == 17) row = 22;
                        IndestructibleBlock Wall = new IndestructibleBlock(new MatrixCoords(row, width));
                        engine.AddObject(Wall);
                    }
                }
            }

            // Ceiling coordinates            
            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(0, col));
                engine.AddObject(ceiling);
            }

            // Floor coordinates
            for (int col = 0; col < WorldCols - 1; col++)
            {
                if (col == WallGap + WallWidth) col = 3 * WallGap;
                IndestructibleBlock floor = new IndestructibleBlock(new MatrixCoords(WorldRows - 1, col));
                engine.AddObject(floor);
            }

            // Block coordinates
            for (int row = 0; row < BlockLines; row++)
            {
                if (row == 2) row = 3;
                for (int col = WallGap + WallWidth + 1; col < 3 * WallGap - 1; col++)
                {
                    if (row == 4 && (col == 3 * WallGap / 2 || col == 5 * WallGap / 2)) col++;
                    Block currBlock = new Block(new MatrixCoords(StartBlockRow + row, col));
                    engine.AddObject(currBlock);
                }
            }

            for (int col = WallGap + WallWidth + 1; col < 3 * WallGap - 1; col++)
            {
                if (col == WallGap + 6) col = 3 * WallGap - 4;
                Block currBlock2 = new Block(new MatrixCoords(5, col));
                engine.AddObject(currBlock2);
            }

            for (int row = 0; row < WorldRows - 2 * BlockLines + 1; row += 3)
            {
                for (int col = WallWidth + 1; col < WorldCols - WallWidth - 1; col++)
                {
                    if (col == WallGap - 1) col = 3 * WallGap + WallWidth + 1;
                    Block currBlock = new Block(new MatrixCoords(StartBlockRow + row, col));
                    engine.AddObject(currBlock);
                }
            }

            for (int col = WallGap + WallWidth + 4; col < 3 * WallGap - 4; col++)
            {
                UnpassableBlock unpassBlock = new UnpassableBlock(new MatrixCoords(5, col));
                engine.AddObject(unpassBlock);
            }

            ExplodingBlock exploBlock1 = new ExplodingBlock(new MatrixCoords(7, 3 * WallGap / 2));
            engine.AddObject(exploBlock1);
            ExplodingBlock exploBlock2 = new ExplodingBlock(new MatrixCoords(7, 5 * WallGap / 2));
            engine.AddObject(exploBlock2);

            // Ball coordinates
            Ball theBall = new Ball(new MatrixCoords(2 * WorldRows / 3, WorldCols / 2 - 10), new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            // Meteorite ball coordinates
            MeteoriteBall meteoBall = new MeteoriteBall(new MatrixCoords(WorldRows - 1, 1), new MatrixCoords(-1, 1));
            engine.AddObject(meteoBall);

            MeteoriteBall meteoBall2 = new MeteoriteBall(new MatrixCoords(WorldRows - 1, 3), new MatrixCoords(-1, 1));
            engine.AddObject(meteoBall2);

            MeteoriteBall meteoBall3 = new MeteoriteBall(new MatrixCoords(WorldRows - 1, 7), new MatrixCoords(-1, 1));
            engine.AddObject(meteoBall3);

            // Unstoppable ball coordinates
            UnstoppableBall unstopBall = new UnstoppableBall(new MatrixCoords(WorldRows - 8, WorldCols - WallWidth - 3), new MatrixCoords(-1, -1));
            engine.AddObject(unstopBall);

            // Racket coordinates
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, (WorldCols - RacketLength) / 2), RacketLength);
            engine.AddObject(theRacket);

            // Gift coordinates
            for (int col = WallGap + 3; col < 3 * WallGap - 1; col++)
            {
                GiftBlock gift = new GiftBlock(new MatrixCoords(1, col));
                engine.AddObject(gift);
            }
        }

        static void Main()
        {
            Console.BufferWidth = Console.WindowWidth = WorldCols + InfofieldWidth;
            Console.BufferHeight = Console.WindowHeight = WorldRows;

            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingEngine gameEngine = new ShootingEngine(renderer, keyboard, 80);

            keyboard.OnLeftPressed += (sender, eventInfo) => { gameEngine.MovePlayerRacketLeft(WallGap + WallWidth); };
            keyboard.OnRightPressed += (sender, eventInfo) => { gameEngine.MovePlayerRacketRight(3 * WallGap - RacketLength); };
            keyboard.OnActionPressed += (sender, eventInfo) => { gameEngine.ShootPlayerRacket(); };

            Initialize(gameEngine);

            List<dynamic> infoList = new List<dynamic>();
            infoList.Add("Balls:");
            infoList.Add(String.Empty);
            infoList.Add("o Normal ball");
            infoList.Add(String.Empty);
            infoList.Add("O Unstoppable");
            infoList.Add(String.Empty);
            infoList.Add("♦ Meteorite");
            infoList.Add(String.Empty);
            infoList.Add(String.Empty);
            infoList.Add("Blocks:");
            infoList.Add(String.Empty);
            infoList.Add("▒ Normal block");
            infoList.Add(String.Empty);
            infoList.Add("▓ Unpassable");
            infoList.Add(String.Empty);
            infoList.Add("█ Indestructible");
            infoList.Add(String.Empty);
            infoList.Add("☼ Bomb");
            infoList.Add(String.Empty);
            infoList.Add("♥ Gift");

            gameEngine.Run(infoList, new MatrixCoords(1, WorldCols + 2));
        }
    }
}
