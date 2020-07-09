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
        BindingList<CarReport> _CarReportList = new BindingList<CarReport>();
        public Form1()
        {
            InitializeComponent();
            dgvCarReports.DataSource = _CarReportList;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private CarReport.CarMaker GetMaker()
        {
            //LINQとラムダ式を使用
            RadioButton selectMaker = (MakerGroup.Controls.Cast<RadioButton>().FirstOrDefault(rb => rb.Checked));
            return (CarReport.CarMaker)int.Parse(selectMaker.Tag.ToString());
        }

        private void btResist_Click(object sender, EventArgs e)
        {

            CarReport carReport = new CarReport()
            {
                CreatedDate = dtpDate.Value,
                Author=cbAuthor.Text,
                Maker= GetMaker(),
                Name = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };

            carReport.Maker = GetMaker();

            _CarReportList.Insert(0, carReport);

            //高さを自動調整
            dgvCarReports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btImageOpen_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                //選択した画像をピクチャーボックスに表示
                pbPicture.Image = Image.FromFile(ofdOpen.FileName);
                ////ピクチャーボックスのサイズに画像を調整
                //pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btPictureDelete_Click(object sender, EventArgs e)
        {
            if (pbPicture.Image == null)
                return;

            if(MessageBox.Show("削除してよいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                pbPicture.Image = null;
            }
        }

        private void dgvCarReports_Click(object sender, EventArgs e)
        {
            CarReport selectedCar = _CarReportList[dgvCarReports.CurrentRow.Index];
            dtpDate.Value = selectedCar.CreatedDate;
            cbAuthor.Text = selectedCar.Author;
            cbCarName.Text = selectedCar.Name;
            tbReport.Text = selectedCar.Report;
            pbPicture.Image = selectedCar.Picture;

            //ラジオボタンの設定
            setRadioButtonMaker(selectedCar.Maker);
        }

        private void setRadioButtonMaker(CarReport.CarMaker carMaker)
        {
            (MakerGroup.Controls
                .Cast<RadioButton>()
                .FirstOrDefault(rb => int.Parse(rb.Tag.ToString()) == (int)carMaker)).Checked = true;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}