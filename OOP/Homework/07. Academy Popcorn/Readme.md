## Academy Popcorn

**Task 01.** `AcademyPopcorn` class contains an `IndestructibleBlock` class. Use it to create side and ceiling walls to the game. You can ONLY edit the `AcademyPopcornMain.cs` file.

**Task 02.** The `Engine` class has a hardcoded sleep time (search for *"System.Threading.Sleep(500)"*. Make the sleep time a field in the `Engine` and implement a constructor, which takes it as an additional parameter.

**Task 03.** Search for a *"TODO"* in the `Engine` class, regarding the `AddRacket` method. Solve the problem mentioned there. There should always be only one `Racket`.

Note: comment in TODO not completely correct.

**Task 04.** Inherit the `Engine` class. Create a method `ShootPlayerRacket`. Leave it empty for now.

**Task 05.** Implement a `TrailObject` class. It should inherit the `GameObject` class and should have a constructor which takes an additional *"lifetime"* integer. The `TrailObject` should disappear after a *"lifetime"* amount of turns. You must NOT edit any existing .cs file. Then test the `TrailObject` by adding an instance of it in the engine through the `AcademyPopcornMain.cs` file.

**Task 06.** Implement a `MeteoriteBall`. It should inherit the `Ball` class and should leave a trail of `TrailObject` objects. Each trail objects should last for 3 *"turns"*. Other than that, the meteorite ball should behave the same way as the normal ball. You must NOT edit any existing .cs file.

**Task 07.** Test the `MeteoriteBall` by replacing the normal ball in the `AcademyPopcornMain.cs` file.

**Task 08.** Implement an `UnstoppableBall` and an `UnpassableBlock`. The `UnstopableBall` only bounces off `UnpassableBlocks` and will destroy any other block it passes through. The `UnpassableBlock` should be indestructible.

Hint: Take a look at the `RespondToCollision` method, the `GetCollisionGroupString` method and the `CollisionData` class.
		 
**Task 09.** Test the `UnpassableBlock` and the `UnstoppableBall` by adding them to the engine in `AcademyPopcornMain.cs` file.

**Task 10.** Implement an `ExplodingBlock`. It should destroy all blocks around it when it is destroyed. You must NOT edit any existing .cs file.

Hint: what does an explosion *"produce"*?

**Task 11.** Implement a `Gift` class. It should be a moving object, which always falls down. The gift shouldn't collide with any ball, but should collide (and be destroyed) with the racket. You must NOT edit any existing .cs file.

**Task 12.** Implement a `GiftBlock` class. It should be a block, which *"drops"* a `Gift` object when it is destroyed.

You must NOT edit any existing .cs file. Test the `Gift` and `GiftBlock` classes by adding them through the `AcademyPopcornMain.cs` file.

**Task 13.** Implement a shoot ability for the player racket. The ability should only be activated when a `Gift` object falls on the racket. The shot objects should be a new class (e.g. `Bullet`) and should destroy normal `Block` objects (and be destroyed on collision with any block). Use the engine and `ShootPlayerRacket` method you implemented in task 4, but don't add items in any of the engine lists through the `ShootPlayerRacket` method. Also don't edit the `Racket.cs` file.

Hint: you should have a `ShootingRacket` class and override its `ProduceObjects` method.

**Task 14\*.** Download JustBelot game source from https://github.com/NikolayIT/JustBelot (code commits are made often so be sure to always work on the latest game source). Write your own C# library called `JustBelot.AI.YourBotName` and write a class in it that implements `JustBelot.Common.IPlayer` interface.

Implement your own AI belot player that will fight with other AI players. The winner will be awarded. Please send your players to academy@telerik.com and add them in the homework archive when you upload it. You are allowed to work in teams.

Discussions: http://forums.academy.telerik.com/67583/oop-justbelot.
