using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imunity.Tools;
using Imunity.Tools.Shapes;
using Imunity.Engine;
using System.Drawing;
namespace Imunity.GameScripts
{
    public class Snake : GameObject
    {
        public Vector2 direction = new Vector2(1, 0);

        public static  Vector2 squareSize = new Vector2(18, 18);

        public List<SnakeSquare> squares = new List<SnakeSquare>();

        private Food food;

        public static int movedPixel = 20;
        
        private float movedSquarePerSecond = 15f; 

        private float lastMovedTime;

        private Text gameOverText = new Text(new Vector2(160, 250), 18);

        private Vector2 targetDirection = new Vector2();

        public int score 
        { 
            get 
            { 
                if (squares.Count > 0) { return squares.Count-1; }
                else { return 0; }
            } 
        }

        public Snake()
        {
            gameOverText.visible = false;
            gameOverText.color = Color.DarkRed;
            SnakeSquare square = new SnakeSquare(new Vector2());
            squares.Add(square);
            food = new Food();
        }

        public override void OnUpdate()
        {
            InputHandler();
            if (Time.now - lastMovedTime >= (1 / movedSquarePerSecond))
            {
                direction = targetDirection;
                CheckForBorders();
                lastMovedTime = Time.now;
                CheckForCollisions();
            }
        }
        
        private void CheckForBorders()
        {
            if (pose.x < 0) { pose.x = Game.lastVisibleX; }
            else if (pose.x > Game.lastVisibleX) { pose.x = 0; }
            else if (pose.y < 0) { pose.y = Game.lastVisibleY; }
            else if (pose.y > Game.lastVisibleY) { pose.y = 0; }
            else { Move(); }
        }

        private void ChildSquaresUpdates()
        {
            for (int i = squares.Count-1; i > 0; i--)
            {
                squares[i].pose = squares[i - 1].pose;
            }
        }

        private void InputHandler()
        {
            if (Input.upArrowPressed)
            {
                if (direction.y == 0)
                {
                    targetDirection = Vector2.down;
                }
            }
            else if (Input.downArrowPressed)
            {
                if (direction.y == 0)
                {
                    targetDirection = Vector2.up;
                }
            }
            else if (Input.leftArrowPressed)
            {
                if (direction.x == 0)
                {
                    targetDirection = Vector2.left;
                }
            }
            else if (Input.rightArrowPressed)
            {
                if (direction.x == 0)
                {
                    targetDirection = Vector2.right;
                }
            }
        }

        private void Move()
        {
            ChildSquaresUpdates();
            pose += direction * (movedPixel);
            squares[0].pose = pose;
        }

        private void AddSquare()
        {
            SnakeSquare square = new SnakeSquare(squares.Last().pose);
            square.squareShape.color = Color.Green;
            squares.Add(square);
        }
    
        private void CheckForCollisions()
        {
            for (int i = 1; i<squares.Count; i++)
            {
                if (squares[0].pose == squares[i].pose)
                {
                    Restart();
                }
            }

            if (pose == food.pose)
            {
                AddSquare();
                food.NewPose();
            }
        }

        private void Restart()
        {
            GameOver();
            DestroySquares();
            enabled = false;
            new WaitAndRun(3f, ResetValues);
        }

        private void DestroySquares()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Destroy();
            }
            squares.Clear();
            food.pose = Vector2.one*1000;
        }
    
        private void ResetValues()
        {
            gameOverText.visible = false;
            Game.scoreText.visible = true;
            pose = Vector2.zero;
            SnakeSquare square = new SnakeSquare(new Vector2());
            squares.Add(square);
            food.NewPose();
            enabled = true;
        }
    
        private void GameOver()
        {
            gameOverText.visible = true;
            Game.scoreText.visible = false;
            gameOverText.text = $"               Game Over\n         Your score was: {score}\n    Restarting in 3 seconds...";
        }
        
    }
}
