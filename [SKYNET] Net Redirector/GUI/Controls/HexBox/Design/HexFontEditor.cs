using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Be.Windows.Forms.Design
{
	internal class HexFontEditor 
	{
		private object value;

		public object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			this.value = value;
			if (provider != null)
			{
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService != null)
				{
					FontDialog fontDialog = new FontDialog();
					fontDialog.ShowApply = false;
					fontDialog.ShowColor = false;
					fontDialog.AllowVerticalFonts = false;
					fontDialog.AllowScriptChange = false;
					fontDialog.FixedPitchOnly = true;
					fontDialog.ShowEffects = false;
					fontDialog.ShowHelp = false;
					Font font = value as Font;
					if (font != null)
					{
						fontDialog.Font = font;
					}
					if (fontDialog.ShowDialog() == DialogResult.OK)
					{
						this.value = fontDialog.Font;
					}
					fontDialog.Dispose();
				}
			}
			value = this.value;
			this.value = null;
			return value;
		}

		public UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}
