using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NativeSharp;
using TsudaKageyu;
using System.Diagnostics;

namespace SKYNET.GUI.Controls
{
    public partial class ModuleControl : UserControl
    {
        public NativeModule Module
        {
            get
            {
                return _nativeModule;
            }
            set
            {
                _nativeModule = value;
                unsafe
                {
                    LB_ModuleAddress.Text = "0x" + ((IntPtr)value.Handle).ToString("X8");
                    LB_ModuleName.Text = value.Name.Replace(".ni.dll", ".dll");
                    PB_ModuleIcon.Image = IconFromFile(value.ImagePath.Replace(".ni.dll", ".dll"));
                }
            }
        }
        NativeModule _nativeModule;

        public Process Process
        {
            get
            {
                return _process;
            }
            set
            {
                _process = value;
                LB_ModuleAddress.Text = _process.Id.ToString();
                LB_ModuleName.Text = _process.ProcessName;

                try
                {
                    PB_ModuleIcon.Image = IconFromFile(_process.MainModule.FileName.Replace(".ni.dll", ".dll"));
                }
                catch
                {
                    PB_ModuleIcon.Image = IconFromFile("");
                }
            }
        }
        Process _process;

        public static Image IconFromFile(string filePath)
        {
            Image image = null;

            try
            {
                var extractor = new IconExtractor(filePath);
                var icon = extractor.GetIcon(0);

                Icon[] splitIcons = IconUtil.Split(icon);

                Icon selectedIcon = null;

                foreach (var item in splitIcons)
                {
                    if (selectedIcon == null)
                    {
                        selectedIcon = item;
                    }
                    else
                    {
                        if (IconUtil.GetBitCount(item) > IconUtil.GetBitCount(selectedIcon))
                        {
                            selectedIcon = item;
                        }
                        else if (IconUtil.GetBitCount(item) == IconUtil.GetBitCount(selectedIcon) && item.Width > selectedIcon.Width)
                        {
                            selectedIcon = item;
                        }
                    }
                }
                return selectedIcon.ToBitmap();
            }
            catch (Exception)
            {

            }

            try
            {
                image = Icon.ExtractAssociatedIcon(filePath)?.ToBitmap();
            }
            catch
            {
                image = new Icon(SystemIcons.Application, 256, 256).ToBitmap();
            }

            return image;
        }

        public ModuleControl()
        {
            InitializeComponent();
        }

        private void Controls_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.BackColor = BackColor;
        }

        private void Controls_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(29, 40, 52);
        }

        private void Controls_MouseClick(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        private void PB_ModuleIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
        }
    }
}
