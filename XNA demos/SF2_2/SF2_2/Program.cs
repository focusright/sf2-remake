using System;

namespace SF2_2 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            //using (RectangleTest game = new RectangleTest()) {
            using (GamePlay game = new GamePlay()) {
                game.Run();
            }
        }
    }
}

