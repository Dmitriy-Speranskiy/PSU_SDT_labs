using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

namespace CyberWorld
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        spriteComp gameObject1, gameObject2;
        Texture2D cat_texture;
        Texture2D dog_texture;
        Texture2D background;
        Rectangle screen_bounds;
        float sprite_speed;


        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1037;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            cat_texture = Content.Load<Texture2D>("cat");
            dog_texture = Content.Load<Texture2D>("dog");
            screen_bounds = new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
            CreateNewObject();
            background = Content.Load<Texture2D>("Background");
            sprite_speed = 5;
        }


        protected void CreateNewObject()
        {
            gameObject1 = new spriteComp(this, ref cat_texture, new Rectangle(4, 1, 288, 449), new Vector2(100, 150));
            Components.Add(gameObject1);
            gameObject2 = new spriteComp(this, ref dog_texture, new Rectangle(12, 7, 269, 429), new Vector2(800, 150));
            Components.Add(gameObject2);
        }

        void Test_coords(spriteComp spr, Rectangle scr)
        {
            if (spr.sprPosition.X < scr.Left)
            {
                spr.sprPosition.X = scr.Left;
            }
            if (spr.sprPosition.X > scr.Width - spr.sprRectangle.Width)
            {
                spr.sprPosition.X = scr.Width - spr.sprRectangle.Width;
            }
            if (spr.sprPosition.Y < scr.Top)
            {
                spr.sprPosition.Y = scr.Top;
            }
            if (spr.sprPosition.Y > scr.Height - spr.sprRectangle.Height)
            {
                spr.sprPosition.Y = scr.Height - spr.sprRectangle.Height;
            }
        }
        void MoveUp(spriteComp spr, float speed)
        {
            spr.sprPosition.Y -= speed;
        }
        void MoveDown(spriteComp spr, float speed)
        {
            spr.sprPosition.Y += speed;
        }
        void MoveLeft(spriteComp spr, float speed)
        {
            spr.sprPosition.X -= speed;
        }
        void MoveRight(spriteComp spr, float speed)
        {
            spr.sprPosition.X += speed;
        }

        bool IsCollide(spriteComp sp1, spriteComp sp2)
        {
            if (sp1.sprPosition.X < sp2.sprPosition.X + sp2.sprRectangle.Width &&
            sp1.sprPosition.X + sp1.sprRectangle.Width > sp2.sprPosition.X &&
            sp1.sprPosition.Y < sp2.sprPosition.Y + sp2.sprRectangle.Height &&
            sp1.sprPosition.Y + sp1.sprRectangle.Height > sp2.sprPosition.Y) return true;
            else return false;
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Up))
            {
                MoveUp(gameObject1, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveDown(gameObject1, (sprite_speed / 10));
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                MoveDown(gameObject1, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveUp(gameObject1, (sprite_speed / 10));
            }
            if (kbState.IsKeyDown(Keys.Left))
            {
                MoveLeft(gameObject1, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveRight(gameObject1, (sprite_speed / 10));
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                MoveRight(gameObject1, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveLeft(gameObject1, (sprite_speed / 10));
            }
            Test_coords(gameObject1, screen_bounds);
            if (kbState.IsKeyDown(Keys.W))
            {
                MoveUp(gameObject2, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveDown(gameObject2, (sprite_speed / 10));
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                MoveDown(gameObject2, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveUp(gameObject2, (sprite_speed / 10));
            }
            if (kbState.IsKeyDown(Keys.A))
            {
                MoveLeft(gameObject2, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveRight(gameObject2, (sprite_speed / 10));

            }
            if (kbState.IsKeyDown(Keys.D))
            {
                MoveRight(gameObject2, sprite_speed);
                while (IsCollide(gameObject1, gameObject2))
                    MoveLeft(gameObject2, (sprite_speed / 10));
            }
            Test_coords(gameObject2, screen_bounds);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            base.Draw(gameTime);
            spriteBatch.End();
            

        }
    }
}
