using System.Drawing;

namespace br.corp.bonus630.SlotGame
{
    interface IGameComponent
    {
        void draw(Graphics e);
        void update();
    }
}
