using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Tokens.backend
{
    class PositionCursor
    {
        Point p;
        public PositionCursor()
        {
            p = new Point(Cursor.Position.X,Cursor.Position.Y);
        }
        public int positionX(RichTextBox rchTextbox)
        {
            return rchTextbox.PointToClient(p).X;
        }
        public int positionY(RichTextBox rchTextbox)
        {
            return rchTextbox.PointToClient(p).Y;
        }

    }
}
