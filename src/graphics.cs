using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

class graphics {

	public void configure() {

	Form menu = new Form();

	menu.FormBorderStyle = FormBorderStyle.FixedDialog;
	menu.StartPosition = FormStartPosition.CenterScreen;
	menu.Text = "Configuration Panel";
	menu.MaximizeBox = false;
   	menu.MinimizeBox = false;
   	//menu.Height = 500;
   	menu.Size = new Size(800,600);

   	menu.ShowDialog();

	}

}
	