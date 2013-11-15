using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Our game field
    public class Engine
    {
        // Game speed: 0 - 1
        public int Speed { get; set; }

        IRenderer renderer;
        IUserInterface userInterface;

        // List of all objects in the game
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;

        protected Racket playerRacket;

        // Constructors
        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        public Engine(IRenderer renderer, IUserInterface userInterface, byte speed)
            : this(renderer, userInterface)
        {
            this.Speed = speed;
        }


        // Add some static object in the list
        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        // Add some moving object in the list
        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        // Add some object in depending his type
        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket) AddRacket(obj);
                else this.AddStaticObject(obj);
            }
        }

        private void AddRacket(GameObject obj)
        {
            // Remove the previous racket from the list of objects
            this.allObjects.Remove(playerRacket);
            this.staticObjects.Remove(playerRacket);

            // Add the new racket in the list
            this.playerRacket = obj as Racket;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft(int leftBorder)
        {
            if (this.playerRacket.TopLeft.Col > leftBorder) this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight(int rightBorder)
        {
            if (this.playerRacket.TopLeft.Col < rightBorder) this.playerRacket.MoveRight();
        }

        public virtual void Run(List<dynamic> list, MatrixCoords topLeft)
        {
            while (true)
            {
                // Print every object over the screen
                this.renderer.RenderAll();

                // Set game speed
                System.Threading.Thread.Sleep(520 - 5 * Speed);

                // Check for user input
                this.userInterface.ProcessInput();

                // Clear all objects from the screen
                this.renderer.ClearQueue();

                // For each objects the new position is updated             
                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                // Check for collisions
                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                // Check for produced objects
                List<GameObject> producedObjects = new List<GameObject>();
                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                // Delete all dead objects
                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                // Add all produced objects in the list
                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }

                // Print the information field
                Infofield infoField = new Infofield();
                infoField.Print(list, topLeft);
            }
        }
    }
}
