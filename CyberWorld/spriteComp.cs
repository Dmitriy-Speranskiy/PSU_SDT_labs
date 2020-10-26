using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CyberWorld
{
    public partial class spriteComp : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Texture2D sprTexture;
        public Rectangle sprRectangle;
        public Vector2 sprPosition;
        protected Rectangle scrBounds;


        public spriteComp(Game game, ref Texture2D newTexture, Rectangle newRectangle, Vector2 newPosition)
            : base(game)
        {
            sprTexture = newTexture;
            sprRectangle = newRectangle;
            sprPosition = newPosition;
            scrBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void Move()
        {
            Check_bounds();
        }

        void Check_bounds()
        {
            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;
            }

            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
            }

            if (sprPosition.Y < scrBounds.Top)
            {
                sprPosition.Y = scrBounds.Top;
            }

            if (sprPosition.Y > scrBounds.Height - sprRectangle.Height)
            {
                sprPosition.Y = scrBounds.Height - sprRectangle.Height;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBatch.Draw(sprTexture, sprPosition, sprRectangle, Color.White);
            base.Draw(gameTime);
        }

    }
}
