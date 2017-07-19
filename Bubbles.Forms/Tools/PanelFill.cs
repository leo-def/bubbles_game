using BubblesVisualComponenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubbles.Forms.tools
{
    public class PanelFill
    {
        public const int USED = 1;
        public const int NOT_USED = 0;


        public int BubbleSideSize { get; set; }
        public int BubbleMargin { get; set; }
        public int SegmentSize { get; set; }
        //bubble
        public int BubbleCount { get; set; }
        public double UseArea { get; set; }

        

        public Panel Panel { get; set; }
        public Dictionary<int, int[]> Segments { get; set; }


        public PanelFill(Panel _p, int _bubbleCount, double _useArea)
        {
            Segments = new Dictionary<int, int[]>();
            Panel = _p;
            BubbleCount = _bubbleCount;
            UseArea = _useArea;
            LoadBubbleValues();
        }
        
        //get values
        public double PanelArea()
        {
            return (Panel.Width * Panel.Height);
        }
        public double PanelUseArea()
        {
            return ((PanelArea() * UseArea) / 100);
        }
        public double PanelNoUseArea()
        {
            return ((PanelArea() * (100 - UseArea)) / 100);
        }
        
        //load values
        public void LoadBubbleSideSize()
        {
            BubbleSideSize =  (int)(Math.Sqrt(PanelUseArea()) / BubbleCount);
        }

        public void LoadDefaultBubbleMargin()
        {
            if (BubbleMargin == 0)
            {
                //BubbleMargin = (int)(Math.Sqrt(PanelNoUseArea()) / (BubbleCount * 2));
                //PanelArea = 100
                //BubbleArea = X
                BubbleMargin = (int)BubbleSideSize/BubbleCount ;
            }
        }
        public void LoadSegmentSize()
        {
            SegmentSize = (int)(Math.Sqrt(PanelArea())/BubbleCount);
        }

        public void LoadBubbleValues()
        {
            LoadBubbleSideSize();
            LoadDefaultBubbleMargin();
            LoadSegmentSize();
            int cont = 0;
            int x_seg = 0;
            int y_seg = 0;
            for(int x_value = 0 ; x_value < Panel.Width ; x_value = (int)(x_value +=SegmentSize))
            {
                for (int y_value = 0; y_value < Panel.Height; y_value = (int)(y_value += SegmentSize))
                {
                    Segments.Add(cont, new int[]{x_seg,y_seg,NOT_USED});
                    y_seg++;
                    cont++;
                }
                y_seg = 0;
                x_seg++;
            }
        }

        public void FillPanel()
        {
            for(int index = 0; index < BubbleCount ; index++)
            {
                Bubble bubble = new Bubble(Panel.Childs.Count,Panel);
                bubble.Margin = BubbleMargin;
                bubble.LoadSize( BubbleSideSize);
                
                SetBubble(bubble);
            }
        }

    
        public void SetBubble(Bubble _b)
        {
           // this.pictureBox1.Location = new System.Drawing.Point(112, 170);
           // this.pictureBox1.Size = new System.Drawing.Size(186, 137);
            int _segment = GetRandomSegment();
            _b.Location = new System.Drawing.Point(GetSegmentWidth(_segment),GetSegmentHeight(_segment));
            Panel.AddBubble(_b);

        }
    
        public int GetRandomSegment()
        {
            Random r = new Random();
            while (true)
            {
                int index = r.Next(Segments.Count - 1);
                if(Segments[index][2] == NOT_USED)
                {
                    Segments[index][2] = USED;
                    return index;
                }
            }
        }
   
        public int GetSegmentWidth(int segment_index)
        {
            int x_segment = Segments[segment_index][0];
            return (int)(SegmentSize * x_segment);
        }
        public int GetSegmentHeight(int segment_index)
        {
            int y_segment = Segments[segment_index][1];
            return (int)(SegmentSize * y_segment);
        }
    
    }
}
