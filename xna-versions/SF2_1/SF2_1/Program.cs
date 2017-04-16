using System;

namespace SF2_1 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            using (SF2_1 game = new SF2_1()) {
                game.Run();
            }
        }
    }
}

