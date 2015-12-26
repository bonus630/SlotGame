using System.Windows.Forms;
using System.Threading;

namespace br.corp.bonus630.SlotGame
{
    public partial class GameForm : Form
    {
        Game game = new Game();
        Thread th;
        public GameForm()
        {
            InitializeComponent();
            th = new Thread(new ThreadStart(start));
            th.IsBackground = true;
            th.Start();
        }
        public void start()
        {
            while (true)
            {
               
                this.Invalidate();
                game.update();
                Thread.Sleep(16);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            game.draw(e.Graphics);
        }

   

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            game.input(e.KeyValue);
        }
       
    }
}
