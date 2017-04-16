using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;


namespace SF2_1 {
    class RyuAnimation : DrawableGameComponent{
        private float TotalElapsed = 0f;

        private Texture2D spriteSheet;
        private Move _currentMove;

        private Idle Idle                     = new Idle();
        private Walk_Forwards  Walk_Forwards  = new Walk_Forwards();
        private Walk_Backwards Walk_Backwards = new Walk_Backwards();
        private Jab Jab                       = new Jab();
        private Strong Strong                 = new Strong();
        private Fierce Fierce                 = new Fierce();
        
        //private Rectangle[] Frames_Short           = new Rectangle[2];
        //private Rectangle[] Frames_Forward         = new Rectangle[2];
        //private Rectangle[] Frames_Roundhouse      = new Rectangle[2];

        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;

        private Move CurrentMove {
            get { return _currentMove; }
            set {
                if (_currentMove != value) {
                    _currentMove = value;
                    _currentMove.Reset();
                }
            }
        }

        public RyuAnimation(Game game) : base(game) {
            CurrentMove = Idle;
        }

        public override void Initialize() {
            audioEngine = new AudioEngine("Content/Audio/myXACTProject.xgs");
            waveBank = new WaveBank(audioEngine, "Content/Audio/myWaveBank.xwb");
            soundBank = new SoundBank(audioEngine, "Content/Audio/mySoundBank.xsb");
            Jab.AnimationFinished += new Action(OnAnimationFinish);
            Strong.AnimationFinished += new Action(OnAnimationFinish);
            Fierce.AnimationFinished += new Action(OnAnimationFinish);

            base.Initialize();
        }

        void OnAnimationFinish() {
            CurrentMove = PreviousMove;
        }

        protected override void LoadContent() {
            //spriteSheet = Game.Content.Load<Texture2D>("RyuCE");
            spriteSheet = Game.Content.Load<Texture2D>("RyuCE_Transparent");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) {
            if (CurrentMove is InterruptibleMove)
                UpdateKeyboard();

            if (!AnimationDisabled) {
                float TimePerFrame = 1f / CurrentMove.FramesPerSecond;
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                TotalElapsed += elapsed;
                if (TotalElapsed >= TimePerFrame) {
                    CurrentMove.AdvanceFrame();
                    TotalElapsed = 0;
                }
            }

            audioEngine.Update();
            base.Update(gameTime);
        }

        bool AnimationDisabled = false;
        private KeyboardState PreviousKeyboardState;
        Move PreviousMove;

        private void UpdateKeyboard() {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                CurrentMove = Walk_Forwards;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                CurrentMove = Walk_Backwards;
            else if (KeyCheck(Keys.A))
                TriggerMove(Jab, "Jab");
            else if (KeyCheck(Keys.S))
                TriggerMove(Strong, "Strong");
            else if (KeyCheck(Keys.D))
                TriggerMove(Fierce, "Fierce");

            else if (Keyboard.GetState().IsKeyDown(Keys.I))
                CurrentMove = Idle;
            else if (Keyboard.GetState().GetPressedKeys().Length == 0)
                CurrentMove = Idle;

            if (Keyboard.GetState().IsKeyDown(Keys.RightShift))
                AnimationDisabled = true;
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                AnimationDisabled = false;

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                CurrentMove.SetFrame(0);
            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
                CurrentMove.SetFrame(1);
            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
                CurrentMove.SetFrame(2);

            PreviousKeyboardState = Keyboard.GetState();
        }

        private void TriggerMove(Move move, string name) {
            PreviousMove = CurrentMove;
            CurrentMove = move;
            soundBank.PlayCue(name);
        }
        private bool KeyCheck(Keys key) {
            if (Keyboard.GetState().IsKeyDown(key) && !PreviousKeyboardState.IsKeyDown(key))
                return true;
            else
                return false;
        }

        public override void Draw(GameTime gameTime) {
            Picture CurrentPicture = CurrentMove.CurrentPicture;
            Rectangle block = CurrentPicture.Frame;
            //Vector2 center = new Vector2(block.Width / 2, block.Height / 2);
            SpriteBatch sb = ((SF2_1)this.Game).SpriteBatch;
            Viewport vp = Game.GraphicsDevice.Viewport;
            //Vector2 pos = new Vector2(vp.Width / 2, vp.Height / 2 + 100);
            Vector2 pos = new Vector2(vp.Width / 2 - 100, vp.Height / 2 - 100);

            sb.Begin();

            sb.Draw(spriteSheet, pos + CurrentPicture.Offset, block, Color.White, 0, Vector2.Zero, 3, SpriteEffects.None, 0);

            sb.End();

            base.Draw(gameTime);
        }
    }
}
