using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.GUI
{
    public partial class frmBase : Form
    {
        private bool mouseDown;     
        private Point lastLocation; 

        public frmBase()
        {
            InitializeComponent();
        }
        //public virtual void ApplyTheme(ColorTheme theme)
        //{

        //}
        public virtual void LoadLanguage()
        {

        }
        public void SetMouseMove(Control control)
        {
            control.MouseMove += Event_MouseMove;
            control.MouseDown += Event_MouseDown;
            control.MouseUp += Event_MouseUp;
        }
        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
            }
        }

        private void Event_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;

        }

        private void Event_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
