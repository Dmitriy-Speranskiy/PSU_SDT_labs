using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CyberWorld
{

    public partial class gameObj2 : spriteComp
    {
        public gameObj2(Game game, ref Texture2D newTexture,
        Rectangle newRectangle, Vector2 newPosition)
        : base(game, ref newTexture, newRectangle, newPosition)
        {
            // TODO: Construct any child components here
        }
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}