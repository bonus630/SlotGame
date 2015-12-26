using System;
using System.Drawing;
using System.Media;

namespace br.corp.bonus630.SlotGame
{
    public enum SlotResult
    {
        NONE,
        ORANGE,
        SEVEN,
        BAR,
        PEAR,
        BANANA,
        CHERRY
    }
    class Slot : IGameComponent
    {
        private Point position;
        private int speed = 0;
        private int bgPosition;
        public bool spinning = false;
        private bool stoped = true;
        private int spriteXPosition = 0;
        private Image bgSlot = br.corp.bonus630.SlotGame.Properties.Resources.teste;
        private SoundPlayer slotSound = new SoundPlayer(br.corp.bonus630.SlotGame.Properties.Resources.slotSound);
        private Size slotSize = new Size(142, 100);
        private SlotResult slotResult = SlotResult.NONE;
        public Slot (int x, int y)
        {
            position = new Point(x, y);
            Random rd = new Random();
            bgPosition = rd.Next(0, 6) * slotSize.Height;
        }
        public void draw(Graphics e)
        {
            e.DrawImage(bgSlot, position.X, position.Y, new Rectangle(spriteXPosition, bgPosition, slotSize.Width, slotSize.Height), GraphicsUnit.Pixel);
            if(bgPosition>500)
            {
                Rectangle ret = new Rectangle(spriteXPosition, bgPosition - 600, slotSize.Width, slotSize.Height);
                
                e.DrawImage(bgSlot, position.X, position.Y,ret , GraphicsUnit.Pixel);
            }
            if (bgPosition > 600)
                bgPosition = 0;
        }
        public void update()
        {
            if (speed > 0)
            {
               
                bgPosition = bgPosition + speed;
                if (speed > 5)
                {
                    slotSound.Play();
                    spriteXPosition = slotSize.Width;
                }
                else
                    spriteXPosition = 0;
                if (stoped)
                    speed--;
                if (bgPosition % slotSize.Height != 0 && speed == 0)
                {
                    speed++;
                }
            }
            if (speed == 0 && stoped)
            {
                this.spinning = false;
                this.slotResult = setSlotResult();
            }
           
           
        }

        private SlotResult setSlotResult()
        {
            switch(bgPosition)
            {
                case 0:
                    return SlotResult.ORANGE;
                
                case 100:
                return SlotResult.SEVEN;
              
                case 200:
                return SlotResult.BAR;
                
                case 300:
                return SlotResult.PEAR;
               
                case 400:
                return SlotResult.BANANA;
                
                case 500:
                return SlotResult.CHERRY;
                case 600:
                return SlotResult.ORANGE;
                default:
                    return SlotResult.NONE;
                
            }
        }
        public void startSpinning(int speed)
        {
            this.slotResult = SlotResult.NONE;
            this.speed = speed;
            this.spinning = true;
            this.stoped = false;
        }
        public void stopSpinning()
        {
            this.stoped = true;
        }
        public SlotResult getSlotResult()
        {
            return this.slotResult;
        }
    }
}
