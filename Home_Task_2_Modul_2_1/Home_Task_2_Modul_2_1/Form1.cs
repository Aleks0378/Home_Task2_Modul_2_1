using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Home_Task_2_Modul_2_1
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            gender.Items.Add("male");
            gender.Items.Add("female");
            marital_status.Items.Add("marriage");
            marital_status.Items.Add("single");
        }

        public void save_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>()
            { surname.Text, name.Text, second_name.Text, gender.Text, dateTimePickerBirthday.Value.ToLongDateString() , marital_status.Text, add_info.Text };
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<string>));
            try
            {
                using (Stream fStream = File.Create("Form1.xml"))
                {
                    xmlFormat.Serialize(fStream, list);
                }
                MessageBox.Show("XmlSerialize OK!", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void load_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            //Form1 form = new Form1();
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<string>));
            try
            {
                using (Stream fStream = File.OpenRead("Form1.xml"))
                {
                    list = (List<string>)xmlFormat.Deserialize(fStream);
                }
                this.surname.Text = list[0];
                this.name.Text = list[1];
                this.second_name.Text = list[2];
                this.gender.Text = list[3];
                this.dateTimePickerBirthday.Text = list[4];
                this.marital_status.Text = list[5];
                this.add_info.Text = list[6];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
