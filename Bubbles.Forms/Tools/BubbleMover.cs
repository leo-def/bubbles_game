using BubblesVisualComponenets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
namespace Bubbles.Forms.Tools
{
    public class BubbleMover
    {
        //p/ms
        // 1p/ms   ms == 0
        // 0.
        public Bubble Bubble { get; set; }
        public Point Direction { get; set; }
        public int Moves { get; set; }
        public long SpeedMoveIncrement { get; set; }


        private long _sleeping;
        private int _move;

        public BubbleMover(Bubble b, Point direction, int moves, long startSleep,long sleepDecrement )
        {
            Bubble = b;
            Direction = direction;
            Moves = moves;
            SpeedMoveIncrement = sleepDecrement;
            _sleeping = startSleep;
            _move = 0;
        }
        public bool Move()
        {
            if (_move >= Moves) { return false; }
            Direction = Bubble.ReflateOnPanel(Direction);
            Bubble.AlterPosition(Direction);
            Thread.Sleep((int)_sleeping);
            _sleeping += SpeedMoveIncrement;
            _move++;
            return true;
        }
    }
}
