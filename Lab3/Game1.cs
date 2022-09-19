using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Lab3_game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D cloudTexture;
        Vector2 scaleCloud;
        Texture2D myTexture;

        Random r = new Random();

        Vector2[] CloudStartPos = new Vector2[4];
        Vector2[] CloudSize = new Vector2[4];
        int[] CloudSpeed = new int[4];

        Vector2 spritePosition = Vector2.Zero;
        int frame = 1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            scaleCloud.X = 0.5f;
            scaleCloud.Y = 0.5f;

            for (int i = 0;i < 4;i++)
            {
                CloudStartPos[i] = new Vector2(0, r.Next(0, 400));
                CloudSize[i] = new Vector2(r.Next(1, 3), r.Next(1, 3));
                CloudSpeed[i] = r.Next(2, 7);
            }

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("NatureSprite");
            cloudTexture = Content.Load<Texture2D>("Cloud_sprite");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(85, 133, 50));
            spriteBatch.Begin();

            spriteBatch.Draw(myTexture, new Vector2(270, 290), new Rectangle(64 * frame, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(270, 220), new Rectangle(64 * frame, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(400, 300), new Rectangle(64 * frame, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(250, 250), new Rectangle(64 * frame, 64, 0, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(400, 300), new Rectangle(64 * frame, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(100, 120), new Rectangle(64 * frame, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(200, 200), new Rectangle(64 * frame, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(270, 150), new Rectangle(64 * frame, 0, 128, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(500, 250), new Rectangle(64 * frame, 0, 128, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(600, 300), new Rectangle(64 * frame, 64, 128, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(500, 0), new Rectangle(256 * frame, 128, 256, 256), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(0, 280), new Rectangle(256 * frame, 128, 256, 256), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(450, 300), new Rectangle(0 * frame, 128, 128, 256), Color.White);
           
            for (int i = 0; i < 4;i++)
            {
                spriteBatch.Draw(cloudTexture, CloudStartPos[i], null, Color.White, 0, Vector2.Zero, CloudSize[i], 0, 0);
                CloudStartPos[i].X += CloudSpeed[i];

                if( CloudStartPos[i].X > this.graphics.GraphicsDevice.Viewport.Width )
                {
                    CloudStartPos[i] = new Vector2(0, r.Next(0, 400));
                    CloudSize[i] = new Vector2(r.Next(1, 2), r.Next(1, 2));
                    CloudSpeed[i] = r.Next(2, 7);
                }

            }

            spriteBatch.End();
  /*kuey*/
            base.Draw(gameTime);

        }
    }
}
