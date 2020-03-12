using System;
using System.Drawing;
using System.Windows.Forms;
using FractalPainting.Infrastructure.UiActions;
using System.Linq;

namespace FractalPainting.App
{
    public class MainForm : Form
    {
        public MainForm(IUiAction[] actions, AppSettings appSettings, PictureBoxImageHolder pictureBox)
        {
            var imageSettings = appSettings.ImageSettings;
            ClientSize = new Size(imageSettings.Width, imageSettings.Height);

            var mainMenu = new MenuStrip();
            mainMenu.Items.AddRange(actions.OrderBy(item => item.Category.Priority).ToArray().ToMenuItems());
            Controls.Add(mainMenu);

            pictureBox.RecreateImage(imageSettings);
            pictureBox.Dock = DockStyle.Fill;
            Controls.Add(pictureBox);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Text = "Fractal Painter";
        }
    }
}