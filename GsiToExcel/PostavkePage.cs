using GsiToExcel.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsiToExcel
{
    public partial class PostavkePage : Form
    {
        public PostavkePage()
        {
            InitializeComponent();
            BrojDecimalaTextBox.PromptChar = ' ';
            BrojDecimalaTextBox.HidePromptOnLeave = true;
          
            BrojDecimalaTextBox.Text = Properties.Settings.Default.Decimalno.ToString().Trim();
            textBox1.Text = Properties.Settings.Default.Odstupanje.ToString().Trim();

            
            var kolone = new List<Kolone>
                {
                    new Kolone() { ID=2,Naziv="Vezna tačka" },
                    new Kolone() { ID=3,Naziv="Odstojanje od letve" },
                    new Kolone() { ID=4,Naziv="Prva podjela Z1 P1 Z1-P1" },
                    new Kolone() {ID=5,Naziv="Druga podjela Z2 P2 Z2-P2"},
                    new Kolone(){ID=6,Naziv="Proba"},
                    new Kolone() { ID=7,Naziv="Srednja visinska razlika"},
                    new Kolone() {ID=10,Naziv="Suma visinskih razlika"},
                    new Kolone(){ID=11,Naziv="Suma dužina"}
                };

            if (Properties.Settings.Default.GridKolone.Trim()==string.Empty && Properties.Settings.Default.GridSakri.Trim()==string.Empty)
            {

                KoloneZaprikaz.DataSource = kolone;
                KoloneZaprikaz.DisplayMember = "Naziv";
                KoloneZaprikaz.ValueMember = "ID";
            }
            else
            {
                List<Kolone> zaprikaz = new List<Kolone>();
                List<Kolone> sakri = new List<Kolone>(); 
                List<string> za = new List<string>(Properties.Settings.Default.GridKolone.Split(','));
                za.Remove("");

                List<string> ne = new List<string>(Properties.Settings.Default.GridSakri.Split(','));
                ne.Remove("");
                if (za.Count>0)
                  {
                    foreach(string a in za)
                    {
                       KoloneZaprikaz.Items.Add(kolone.Find(x => x.ID == Convert.ToInt32(a)));
                        KoloneZaprikaz.DisplayMember = "Naziv";
                        KoloneZaprikaz.ValueMember = "ID";
                    }
                  }

               

                if(ne.Count>0)
                {

                    foreach (string a in ne)
                    {
                        Kolone.Items.Add(kolone.Find(x => x.ID == Convert.ToInt32(a)));
                        Kolone.DisplayMember = "Naziv";
                        Kolone.ValueMember = "ID";


                    }
                }

                
                    
            }
        }

        private void PostavkePage_Load(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string greske = " ";
            if(BrojDecimalaTextBox.Text.Trim()=="")
            {
                greske = greske + "Molimo unesite broj decimala za prikaz!"+ System.Environment.NewLine;
            }
            if(textBox1.Text.Trim()=="")
            {
                greske = greske + "Molimo unesite dozvoljeno odstupanje!"+ System.Environment.NewLine;
            }
            decimal n;
            if(!decimal.TryParse(textBox1.Text,out n) || textBox1.Text.Contains(","))
            {
                greske = greske + "Molimo unesite dozvoljeno odsupanje u sljdececom formatu: 0.03"+ System.Environment.NewLine;
            }

            if(greske==" ")
            {
                Properties.Settings.Default.Decimalno =Convert.ToInt32(BrojDecimalaTextBox.Text.Trim());
                Properties.Settings.Default.Odstupanje = Convert.ToDecimal(textBox1.Text.Trim());

                string ListaPrikazi = string.Empty;
                string ListaSakri = string.Empty;
                
                foreach(Kolone a in Kolone.Items)
                {
                    ListaSakri = ListaSakri + a.ID+",";
                }

                foreach(Kolone a in KoloneZaprikaz.Items)
                {
                    ListaPrikazi = ListaPrikazi + a.ID+",";
                }
                
                Properties.Settings.Default.GridKolone = ListaPrikazi.Trim();
                Properties.Settings.Default.GridSakri = ListaSakri.Trim();
                Properties.Settings.Default.Save();

                Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form != null)
                {
                    form.KolonePrikaz();
                   
                }

                this.Close();
            }
            else
            {
                MessageBox.Show(greske.TrimStart(), "Upozorenje");

                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (KoloneZaprikaz.Items.Count > 1)
            {
                if (KoloneZaprikaz.SelectedItems.Count > 0)
                {
                    Kolone k = (Kolone)KoloneZaprikaz.SelectedItem;
                    List<Kolone> kolones = new List<Kolone>();

                    foreach (Kolone a in KoloneZaprikaz.Items)
                    {
                        if (a.ID != k.ID)
                        {
                            kolones.Add(new Kolone
                            {
                                ID = a.ID,
                                Naziv = a.Naziv
                            });
                        }
                    }

                    List<Kolone> koloneSakri = new List<Kolone>();
                    foreach (Kolone a in Kolone.Items)
                    {
                        koloneSakri.Add(new Kolone
                        {
                            ID = a.ID,
                            Naziv = a.Naziv
                        });
                    }
                    koloneSakri.Add(new Kolone
                    {
                        ID = k.ID,
                        Naziv = k.Naziv
                    });

                    Kolone.DataSource = null;
                    Kolone.Items.Clear();
                    Kolone.DataSource = koloneSakri;
                    Kolone.DisplayMember = "Naziv";
                    Kolone.ValueMember = "ID";



                    KoloneZaprikaz.DataSource = null;
                    KoloneZaprikaz.Items.Clear();
                    KoloneZaprikaz.DataSource = kolones;
                    KoloneZaprikaz.DisplayMember = "Naziv";
                    KoloneZaprikaz.ValueMember = "ID";
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Kolone.SelectedItems.Count > 0)
            {
                Kolone k = (Kolone)Kolone.SelectedItem;
                List<Kolone> kolones = new List<Kolone>();

                foreach (Kolone a in Kolone.Items)
                {
                    if (a.ID!=null &&a.ID!= k.ID)
                    {
                        kolones.Add(new Kolone
                        {
                            ID = a.ID,
                            Naziv = a.Naziv
                        });
                    }
                }


                List<Kolone> kolonezaPrikazat = new List<Kolone>();

                foreach(Kolone a in KoloneZaprikaz.Items)
                {
                    kolonezaPrikazat.Add(new Kolone
                    {
                        ID = a.ID,
                        Naziv = a.Naziv
                    });
                }

                kolonezaPrikazat.Add(new Class.Kolone
                {
                    ID=k.ID,
                    Naziv=k.Naziv
                });

                KoloneZaprikaz.DataSource = null;
                KoloneZaprikaz.Items.Clear();
                KoloneZaprikaz.DataSource = kolonezaPrikazat;
                
                KoloneZaprikaz.DisplayMember = "Naziv";
                KoloneZaprikaz.ValueMember = "ID";
                Kolone.DataSource = null;
                Kolone.Items.Clear();


                Kolone.DataSource = kolones;
                Kolone.DisplayMember = "Naziv";
                Kolone.ValueMember = "ID";
            }
        }
    }
}
