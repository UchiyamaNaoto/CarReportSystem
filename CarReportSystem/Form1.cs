using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarReport carReport = new CarReport();
            
            carReport.Maker = GetMaker();
                        
        }

        private CarReport.CarMaker GetMaker()
        {
            //LINQとラムダ式を使用
            RadioButton selectMaker = (MakerGroup.Controls.Cast<RadioButton>().FirstOrDefault(rb => rb.Checked));
            return (CarReport.CarMaker)int.Parse(selectMaker.Tag.ToString());
        }
    }
}
