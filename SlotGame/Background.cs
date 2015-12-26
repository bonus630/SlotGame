using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace br.corp.bonus630.SlotGame
{
    class Background : IGameComponent
    {
        private Image static_bg = br.corp.bonus630.SlotGame.Properties.Resources.static_bg;
        public void update()
        {

        }
        public void draw(Graphics e)
        {
            e.DrawImage(static_bg, 0, 0, static_bg.Width, static_bg.Height);
        }
    }
}
