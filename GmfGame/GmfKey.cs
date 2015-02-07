using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GmfGame
{
    public class GmfKey
    {
        private static Dictionary<Keys, bool> keyPressed = new Dictionary<Keys, bool>();

        public static bool IsKeyPressed(Keys key)
        {
            if (keyPressed.ContainsKey(key))
                return keyPressed[key];
            return false;
        }

        public static void SetKeyPressed(Keys key, bool isPressed)
        {
            keyPressed[key] = isPressed;
        }

        public static void ResetKeyPressed()
        {
            keyPressed.Clear();
        }

    }
}
