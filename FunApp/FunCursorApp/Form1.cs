using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = 30;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MoveCursor();
        }

        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);
            
            SetInterval(() => HelloWorld(), TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown1.Value)), true);
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        public async Task SetInterval(Action action, TimeSpan timeout, bool resetFlag = false)
        {
            if (this.checkBox1.Checked)
            {
                await Task.Delay(timeout).ConfigureAwait(false);
                var xCurrentPosition = Cursor.Position.X;
                var yCurrentPosition = Cursor.Position.Y;

                int x = 0;
                int y = 0;

                if (resetFlag)
                {
                    x = xCurrentPosition - 15;
                    y = yCurrentPosition - 15;
                }
                else
                {
                    x = xCurrentPosition + 15;
                    y = yCurrentPosition + 15;
                }

                Cursor.Position = new Point(x, y);

                SetInterval(action, timeout, resetFlag ? false : true);
            }
        }

        private void HelloWorld()
        {

        }
    }
}
