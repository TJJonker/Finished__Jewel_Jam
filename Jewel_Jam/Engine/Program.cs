using System;

namespace Jewel_Jam
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new JewelJam())
                game.Run();
        }
    }
}
