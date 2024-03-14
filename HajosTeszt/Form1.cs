using HajosTesztes;
using System.Reflection.Metadata.Ecma335;

namespace HajosTeszt
{
    public partial class Form1 : Form
    {
        List<Kerdes> OsszesKerdes;
        List<Kerdes> AktualisKerdesek;
        int Megjelen�tettK�rd�sSz�ma = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OsszesKerdes = KerdesekBetoltese();
            AktualisKerdesek = new List<Kerdes>();

            for (int i = 0; i < 7; i++)
            {
                AktualisKerdesek.Add(OsszesKerdes[0]);
                OsszesKerdes.RemoveAt(0);
            }
            dataGridView1.DataSource = AktualisKerdesek;
            K�rd�sMegjelen�t�s(AktualisKerdesek[Megjelen�tettK�rd�sSz�ma]);

        }
        List<Kerdes> KerdesekBetoltese()
        {
            List<Kerdes> kerdesek = new List<Kerdes>();
            StreamReader sr = new StreamReader("hajozasi_szabalyzat_kerdessor_BOM.txt", true);
            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine();
                string[] t�mb = sor.Split("\t");

                if (t�mb.Length != 7) continue;

                Kerdes k = new Kerdes();
                k.KerdesSzoveg = t�mb[1].ToUpper();
                k.Valasz1 = t�mb[2].Trim('"');
                k.Valasz2 = t�mb[3].Trim('"');
                k.Valasz3 = t�mb[4].Trim('"');
                k.URL = t�mb[5];

                int x = 0;
                int.TryParse(t�mb[6], out x);
                k.HelyesValasz = x;

                kerdesek.Add(k);


            }


            sr.Close();
            return kerdesek;
        }

        void K�rd�sMegjelen�t�s(Kerdes kerdes)
        {
            label1.Text = kerdes.KerdesSzoveg;
            textBox1.Text = kerdes.Valasz1;
            textBox2.Text = kerdes.Valasz2;
            textBox3.Text = kerdes.Valasz3;

            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;

            if (string.IsNullOrEmpty(kerdes.URL))
            {
                pictureBox1.Visible = false;

            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + kerdes.URL);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Megjelen�tettK�rd�sSz�ma++;
            if (Megjelen�tettK�rd�sSz�ma == AktualisKerdesek.Count) Megjelen�tettK�rd�sSz�ma = 0;
            K�rd�sMegjelen�t�s(AktualisKerdesek[Megjelen�tettK�rd�sSz�ma]);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Salmon;
            Sz�nez�s();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Salmon;
            Sz�nez�s();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Salmon;
            Sz�nez�s();
        }
        void Sz�nez�s()
        {
            int helyesvalasz = AktualisKerdesek[Megjelen�tettK�rd�sSz�ma].HelyesValasz;
            if(helyesvalasz == 1) textBox1.BackColor= Color.LightGreen;
            if(helyesvalasz == 2) textBox2.BackColor= Color.LightGreen;
            if(helyesvalasz == 3) textBox3.BackColor= Color.LightGreen;
        }
    }
}