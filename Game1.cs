using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Part_4___Time_and_Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont timeText;
        
        Texture2D bombTexture, explosionImageTexture;
        Rectangle bombRect, explosionImageRect;

        float seconds;
        float startTime;

        MouseState mouseState;

        SoundEffect explode;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 500; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions

            bombRect = new Rectangle(50, 50, 700, 400);
            explosionImageRect = new Rectangle(100, 100, 600, 300);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            timeText = Content.Load<SpriteFont>("text");
            
            bombTexture = Content.Load<Texture2D>("bomb");
            explosionImageTexture = Content.Load<Texture2D>("explosionImage");
            explode = Content.Load<SoundEffect>("explosion");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();

            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (mouseState.LeftButton == ButtonState.Pressed)
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;

            if (seconds == 10)
            {
                explode.Play();
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;                                             
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(timeText, seconds.ToString("00.0"), new Vector2(270, 200), Color.Black);
            if (seconds >= 10)
            {
                _spriteBatch.Draw(explosionImageTexture, explosionImageRect, Color.White);
                
            }
              

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}