using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exx_15
{
    public partial class Form1 : Form
    {
        abstract class TFish
        {
            public void Init()
            {
                Draw();
            }

            public abstract void Draw();
            public void Look()
            {

            }
            public void Run()
            {
                
            }
        }

        class TPike : TFish
        {
            public override void Draw()
            {

            }
        }

        class TKarp : TFish
        {
            public override void Draw()
            {

            }
        }

        class TAquarium
        {
            public TFish[] fish;

            public void Init()
            {

            }
            public void Run()
            {

            }
            public void Done()
            {

            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
