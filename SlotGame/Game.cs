using System;
using System.Drawing;

namespace br.corp.bonus630.SlotGame
{
    public enum GameState
    {
        NONINIT,
        RUNNING,
        FINISH
    }
    class Game : IGameComponent
    {
        Slot slot = new Slot(20, 100);
        Slot slot2 = new Slot(211, 100);
        Slot slot3 = new Slot(402, 100);
        Background background = new Background();
        private bool gameOver = true;
        private bool winner = false;
        private GameState gameState = GameState.NONINIT;
        private int credits = 0;
        public void update()
        {
            background.update();
            if (!gameOver)
            {
                slot.update();
                slot2.update();
                slot3.update();
                if (!slot.spinning && !slot2.spinning && !slot3.spinning && gameState !=GameState.NONINIT)
                {
                    gameState = GameState.FINISH;
                }
                if(gameState==GameState.FINISH)
                {
                    if (slot.getSlotResult() == slot2.getSlotResult() && slot2.getSlotResult() == slot3.getSlotResult() && slot3.getSlotResult() != SlotResult.NONE)
                    {
                        this.winner = true;
                    }
                    else
                    {
                        this.winner = false;
                    }
                }

            }
           
        }
        public void draw(Graphics e)
        {
            background.draw(e);
            slot.draw(e);
            slot2.draw(e);
            slot3.draw(e);
            if (gameState==GameState.FINISH)
            {
                Console.WriteLine("1- " + slot.getSlotResult().ToString() + " | 2- " + slot2.getSlotResult().ToString() + " | 3-" + slot3.getSlotResult().ToString());
                if (winner)
                    e.DrawImage(br.corp.bonus630.SlotGame.Properties.Resources.winner, 106, 25, 400, 300);
                //e.DrawString("Você ganhou uma bolada", new Font("Genova", 16.0f), new SolidBrush(Color.Red), new PointF(30.0f, 280.0f));
                else
                    e.DrawString("Você Perdeu", new Font("Genova", 16.0f), new SolidBrush(Color.Red), new PointF(30.0f, 280.0f));
            }
            e.DrawString("Créditos: "+credits, new Font("Genova", 12.0f), new SolidBrush(Color.Red), new PointF(480.0f, 320.0f));
           
        }
        public void start()
        {
            if (gameState != GameState.RUNNING && credits >= 25)
            {
                credits = credits - 25;
                gameState = GameState.RUNNING;
                this.gameOver = false;
                slot.startSpinning(10);
                slot2.startSpinning(15);
                slot3.startSpinning(20);
            }
        }
        public void stop()
        {
            slot.stopSpinning();
            slot2.stopSpinning();
            slot3.stopSpinning();
            
        }

        public void input(int keys)
        {
            if (keys == 32)
            {
                if (gameState == GameState.RUNNING)
                    this.stop();
                else
                    this.start();
            }
            if(keys == 67)
                this.credits += 25;
        }
    }
}
