using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.Controls
{
    public class SKYNET_Label : Label
    {
        [Category("SKYNET")]
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        private Color _textColor;

        [Category("SKYNET")]
        public Color TextColor_MouseHover
        {
            get { return _textColor_MouseOver; }
            set { _textColor_MouseOver = value; }
        }
        private Color _textColor_MouseOver;

        [Category("SKYNET")]
        public bool ChangeColor
        {
            get { return _changeColor; }
            set { _changeColor = value; }
        }
        private bool _changeColor;

        [Category("SKYNET")]
        public bool GradiantColor
        {
            get { return _gradiantolor; }
            set 
            { 
                _gradiantolor = value;
                if (value)
                {
                    ChangeColor = false;
                }
            }
        }
        private bool _gradiantolor;

        [Category("SKYNET")]
        public Color GradiantColor1
        {
            get { return _gradiantolor1; }
            set { _gradiantolor1 = value; }
        }
        private Color _gradiantolor1;
        
        [Category("SKYNET")]
        public Color GradiantColor2
        {
            get { return _gradiantolor2; }
            set { _gradiantolor2 = value; }
        }
        private Color _gradiantolor2;

        [Category("SKYNET")]
        public LinearGradientMode GradiantMode
        {
            get { return _gradiantMode; }
            set { _gradiantMode = value; }
        }
        private LinearGradientMode _gradiantMode;

        public SKYNET_Label()
        {
            ChangeColor = true;
            TextColor = ForeColor;
            TextColor_MouseHover = ForeColor;

            GradiantColor = false;
            GradiantColor1 = Color.FromArgb(72, 98, 255);
            GradiantColor2 = Color.FromArgb(255, 92, 135);
            GradiantMode = LinearGradientMode.Horizontal;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ChangeColor)
            {
                ForeColor = TextColor_MouseHover;
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (ChangeColor)
            {
                ForeColor = TextColor;
            }
            base.OnMouseLeave(e);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (GradiantColor)
            {
                StringFormat sf = new StringFormat();

                RectangleF rectF = new
                RectangleF(0, this.Height / 2 - Font.Height / 2, this.Width, this.Height);

                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height + 5), _gradiantolor1, _gradiantolor2, _gradiantMode);
                e.Graphics.DrawString(Text, this.Font, brush, rectF, sf);
            }
            else
            {
                base.OnPaint(e);
            }
        }

        public void Reset()
        {
            ChangeColor = true;
            ForeColor = TextColor;
        }
    }
}
