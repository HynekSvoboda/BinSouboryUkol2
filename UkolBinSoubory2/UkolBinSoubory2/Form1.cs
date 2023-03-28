using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UkolBinSoubory2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader cteni = new StreamReader("sport.txt", Encoding.UTF8);
            FileStream tok = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter zapis = new BinaryWriter(tok);
            while(!cteni.EndOfStream)
            {
                string text = cteni.ReadLine();
                string[] rozdeleni = text.Split(';');
                int osc = Convert.ToInt32(rozdeleni[0]);
                string jmeno = rozdeleni[1];
                string prijmeni = rozdeleni[2];
                char pohlavi = Convert.ToChar(rozdeleni[3]);
                int vyska = Convert.ToInt32(rozdeleni[4]);
                int hmotnost = Convert.ToInt32(rozdeleni[5]);
                zapis.Write(osc);
                zapis.Write(jmeno);
                zapis.Write(prijmeni);
                zapis.Write(pohlavi);
                zapis.Write(vyska);
                zapis.Write(hmotnost);
            }
            cteni.Close();
            tok.Close();
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            FileStream tok = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cteni = new BinaryReader(tok);
            cteni.BaseStream.Position = 0;
            while(cteni.BaseStream.Position<cteni.BaseStream.Length)
            {
                textBox1.Text +=cteni.ReadInt32().ToString() + " " + cteni.ReadString() + " " + cteni.ReadString() + " " + cteni.ReadChar().ToString() + " " + cteni.ReadInt32().ToString() + " " + cteni.ReadInt32().ToString()+"\r\n";
            }
            tok.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na disku je textový soubor sport.txt, obsahující na každém řádku\r\nosc;jméno;příjmení;pohlavi;vyska;hmotnost. Vytvořte datový soubor sport.dat, který bude\r\nobsahovat položky\r\n(int osc;String jmeno;String prijmeni;char pohlavi;int vyska;int hmotnost). Soubor zobrazte\r\nv komponentě TextBox.", "INFO");
        }
    }
}
