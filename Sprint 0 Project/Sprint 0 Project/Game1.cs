using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D spriteSheet;
        private Texture2D spriteCoin;

        AnimatedSprite animSprite;
        ISprite sprite;
        IController keyboardController;
        IController mouseController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            // Makes Monogame window size of the current PC window
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("monochrome_tilemap_transparent"); // tile_0300 and monochrome_tilemap_transparent
            spriteCoin = Content.Load<Texture2D>("tile_0002");

            animSprite = new AnimatedSprite(spriteSheet, spriteBatch, new Vector2(100,100), new Point(1, 207), 4);
            sprite = new Sprite(spriteSheet, spriteBatch, new Vector2(100, 100), new Point(1, 207));

            keyboardController = new KeyboardController();
            mouseController = new MouseController(spriteSheet, spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Vector2 movement = keyboardController.UpdateMovement();
            
            animSprite.UpdateAnimation(gameTime, movement);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            animSprite.Draw(spriteSheet);
            spriteBatch.Draw(spriteCoin, mouseController.MousePos(), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
