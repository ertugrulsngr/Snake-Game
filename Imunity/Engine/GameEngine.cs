using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using Imunity.Tools;
using Imunity.Tools.Shapes;

namespace Imunity.Engine
{
    public class GameEngine
    {
        private static Canvas mainWindow;

        private Thread gameLoopThread;

        private Time gameTime;

        private FrameLimiter frameLimiter;

        private FrameCounter frameCounter;

        private Game game;

        public static int frameCount { get; private set; }

        public static int FPS { get; set; } 

        public static Vector2 windowSize { get { return new Vector2(mainWindow.Size.Width, mainWindow.Size.Height); } }
        public GameEngine()
        {
            mainWindow = new Canvas(new Vector2(600, 644));
            mainWindow.Paint += Draw;
            mainWindow.FormClosed += BeforeExit;
            mainWindow.KeyDown += Input.OnKeyDown;
            mainWindow.KeyUp += Input.OnKeyUp;

            game = new Game();

            Load();

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(mainWindow);

        }

        private void BeforeExit(object sender, FormClosedEventArgs e)
        {
            gameLoopThread.Abort();
        }

        public void GameLoop()
        {
            while (!mainWindow.IsHandleCreated) { Thread.Sleep(1); }
            game.OnStart();
            while (true)
            {
                game.BeforeUpdate();
                MainGameLoop();
                game.AfterUpdate();
                frameCounter.Count();
            }
        }

        public void MainGameLoop()
        {
            gameTime.loopStartTime = Time.now;
            Update();
            RefreshMainWindow();
            frameLimiter.Wait();
            gameTime.loopEndTime = Time.now;
            frameCount++;
        }

        public void Load()
        {
            gameTime = new Time();
            frameLimiter = new FrameLimiter(gameTime);
            frameCounter = new FrameCounter();
            game.OnLoad();
        }

        public void Update()
        {
            for (int i = 0; i < GameObject.allGameObjects.Count; i++)
            {
                if (GameObject.allGameObjects[i].enabled)
                {
                    GameObject.allGameObjects[i].OnUpdate();
                }
            }
            UpdateShapesPoses();
        }

        public void UpdateShapesPoses()
        {
            for (int i = 0; i<Shape.AllShapes.Count; i++)
            {
                Shape.AllShapes[i].pose = Shape.AllShapes[i].parent.pose + Shape.AllShapes[i].relativePose;
            }
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            ShapeRenderer.OnDraw(e.Graphics);
        }


        public void RefreshMainWindow()
        {
            mainWindow.Invoke((MethodInvoker)delegate { mainWindow.Refresh(); });
        }
    }
}
