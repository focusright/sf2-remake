using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace TypingMatrix {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font1;

        List<Letter> letters = new List<Letter>();
        List<KeyValuePair<Keys, char>> selectedKeys = new List<KeyValuePair<Keys, char>>();

        int totalMissed = 0;
        int totalHit = 0;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            selectedKeys.Add(new KeyValuePair<Keys, char>(Keys.H, 'H'));
            selectedKeys.Add(new KeyValuePair<Keys, char>(Keys.J, 'J'));
            selectedKeys.Add(new KeyValuePair<Keys, char>(Keys.K, 'K'));
            selectedKeys.Add(new KeyValuePair<Keys, char>(Keys.L, 'L'));
            selectedKeys.Add(new KeyValuePair<Keys, char>(Keys.OemSemicolon, ';'));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font1 = Content.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {

            InputUpdate();
            GameObjectsUpdate(gameTime);

            base.Update(gameTime);
        }

        private TimeSpan interval = TimeSpan.MaxValue;
        private void GameObjectsUpdate(GameTime gameTime) {
            interval += gameTime.ElapsedGameTime;

            if (interval >= TimeSpan.FromSeconds(1f)) {
                Random rand = new Random();
                int randLetter = rand.Next(5);
                Keys key = selectedKeys[randLetter].Key;
                char ch = selectedKeys[randLetter].Value;
                letters.Add(new Letter(key, ch, graphics));
                interval = TimeSpan.Zero;
            }

            List<int> missedIndices = new List<int>();
            for (int i=0; i<letters.Count; i++) {
                letters[i].Update();
                if (letters[i].Missed) {
                    missedIndices.Add(i);
                    totalMissed++;
                }
            }

            for (int i = missedIndices.Count - 1; i >= 0; i--)
                letters.RemoveAt(missedIndices[i]);
        }

        private void InputUpdate() {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            List<int> hitIndices = new List<int>();

            for(int i=0; i<letters.Count; i++)  {
                if (Keyboard.GetState().IsKeyDown(letters[i].Key)) {
                    if (!hitIndices.Contains(i)) {
                        hitIndices.Add(i);
                        totalHit++;
                    }
                }
            }

            for (int i = hitIndices.Count-1; i>=0; i--)
                letters.RemoveAt(hitIndices[i]);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            
            spriteBatch.DrawString(font1, "Missed: "            , new Vector2(10, 10), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(font1, totalMissed.ToString(), new Vector2(80, 10), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(font1, "Hit: "               , new Vector2(10, 30), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(font1, totalHit.ToString()   , new Vector2(80, 30), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            
            foreach (Letter letter in letters) {
                letter.Draw(spriteBatch, font1);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
