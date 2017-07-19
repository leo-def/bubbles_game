
using Bubbles.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubblesVisualComponenets
{
    public class Bubble : PictureBox
    {
        private delegate void ObjectDelegate(Point _direction);
        public int Id { get; set; }
        public Bubbles.Forms.Panel Panel { get; set; }
        public Point CentralPoint { get { return new Point(Location.X + Radius, Location.Y + Radius); } } 
        public int Radius { get {return  SideSize / 2; } }
        public int SideSize { get; set; }
        public int Margin { get; set; }

        public bool BubbleRuning { get; set; }

        public bool Moved { get; set; }
        // contrutors and inits
        public Bubble(int _id, Bubbles.Forms.Panel _panel, int _sideSize, int _margin)
        {
            Id = _id;
            Panel = _panel;
            SideSize = _sideSize;
            Margin = _margin;
            Init();       
        }
       
        public Bubble(int _id, Bubbles.Forms.Panel _panel)
        {
            Id = _id;
            Panel = _panel;
            Init();
        }

        public void Init()
        {
           
            Name = Panel.GetBubbleName();  
            this.Image = global::Bubbles.Forms.Properties.Resources.bubble;
            //this.Name = Panel.GetBubbleName();
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //this.TabIndex = Panel.Childs.Count;
            //this.TabStop = false;
            BackColor = Color.Transparent;
            BubbleRuning = false;
        }

        public void LoadSize(int _sideSize)
        {
            SideSize = _sideSize;
            this.Size = new Size(SideSize, SideSize);

        }
        public bool IsSameBubble(Bubble _b)
        {
            return (_b == this || _b.Id.Equals(this.Id));
        }


        // take values
        public int GetDistance(Point _p)
        {
            int dist_x =GetXDistance(_p);
            int dist_y = GetYDistance(_p);
            return (int)Math.Sqrt((dist_x * dist_x) + (dist_y * dist_y));
        }
        public int GetXDistance(Point _p)
        {
            int dist = _p.X - CentralPoint.X;
            if (dist < 0) { dist = dist * -1; }
            return dist;

        }
        public int GetYDistance(Point _p)
        {
            int dist = _p.Y - CentralPoint.Y;
            if (dist < 0) { dist = dist * -1; }
            return dist;
        }


        // distance verify
        public bool InMargin(Point _p)
        {
            return (GetDistance(_p) <= (Radius + Margin));
            
        }
        public bool InMargin(Bubble _b)
        {
            return (GetDistance(_b.CentralPoint) <= (Radius + Margin + _b.Margin + _b.Radius));
        }
        /*
        public bool WillRun(Point _p)
        {
            return InMargin(_p);
        }
        public bool WillRun(Bubble _b)
        {
            return(InMargin(_b) && !IsSameBubble(_b));
        }
        */
        // escape 
        public Point GetEscapeDirection(Point _p)
        {
            Point _d = new Point(0, 0);
            if (_p.X < CentralPoint.X)  { _d.X = 1; }
            else if (_p.X > CentralPoint.X) { _d.X = -1; }

            if(_p.Y < CentralPoint.Y ){ _d.Y = 1;}
            else if (_p.Y > CentralPoint.Y) { _d.Y = -1; }
            if (_p.Y <= (CentralPoint.Y + Radius) && _p.Y >= (CentralPoint.Y - Radius))
            {
                _p.X = 0;
            }
            if (_p.X <= (CentralPoint.X + Radius) && _p.Y >= (CentralPoint.X - Radius))
            {
                _p.Y = 0;
            }
            return _d;
        }
        /*
        public bool Escape(Bubble _b)
        {
           
            if (!InMargin(_b) || IsSameBubble(_b)) { Moved = false;  return false; }
            return EscapeWithOutCheck(_b);
        }
        
        public bool EscapeWithOutCheck(Bubble _b)
        {
            Run(GetEscapeDirection(_b.CentralPoint));
            Moved = true;
            return true;
        }
        public bool Escape(Point _p)
        {
           

            if (!InMargin(_p)) { Moved = false; return false; }
            return EscapeWithOutCheck(_p);
        }
        public bool EscapeWithOutCheck(Point _p)
        {
            Run(GetEscapeDirection(_p));
            Moved = true;
            return true;
        }
      
        //moviment
        public void Run(Point _p)
        {
                BubbleRuning = true;
                Point _direction = GetEscapeDirection(_p);
                int sleep = 0;
                for (int moves = 0; moves <= 50; moves++)
                {
                    AlterPosition(_p);
                    System.Threading.Thread.Sleep(sleep);
                    sleep += 1;
                }
                BubbleRuning = false;
        }
        */
        public void AlterPosition(Point _direction)
        {
           //LoadLocation( new Point(Location.X + _direction.X, Location.Y + _direction.Y));
            if(InvokeRequired)
            {
                
                ObjectDelegate method = new ObjectDelegate(LoadNewPosition);
                Invoke(method, _direction);
                return;
            }

           // Left += _direction.X;
            //Top += _direction.Y;
            //Panel.InformBubblePosition(this);
            
        }

        public void LoadNewPosition(Point _direction)
        {
            Left += _direction.X;
            Top += _direction.Y;
        }

        public Point ReflateOnPanel(Point _direction)
        {
            int _x = CentralPoint.X + _direction.X;
            int _y = CentralPoint.Y + _direction.Y;

            int _max_x = _x + Radius;
            int _min_x = _x - Radius;

            int _max_y = _y + Radius;
            int _min_y = _y - Radius;
            
            if(_min_x < 0  || _max_x > Panel.Width)
            {
                _direction.X = _direction.X * -1;
                
                if(_direction.Y == 0)
                {
                    if(_min_y - 1 > 0){ _direction.Y -= 1; }
                    if(_max_y  + 1 < Panel.Height) {  _direction.Y += 1;  }
                }
            }
            if (_min_y < 0 || _max_y > Panel.Height)
            {
                _direction.Y = _direction.Y * -1;
                if (_direction.X == 0)
                {
                    if (_min_x - 1 > 0) { _direction.X -= 1; }
                    if (_max_x + 1 < Panel.Width){ _direction.X += 1; }
                }
            }
            return _direction;
        }
        

    }
}
