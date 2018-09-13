using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GsiToExcel.Class;
namespace GsiToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            dataGridView1.AutoGenerateColumns = false;
            buttonNapraviNO1.Enabled = false;
            buttonNapraviNO2.Enabled = false;
            buttonPreracuna.Enabled = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;

            KolonePrikaz();
            

        }

        private void buttonUcitajGSI_Click(object sender, EventArgs e)
        {
            try
            {


                //dozvoljeno odstupanje

               


                //otvori GSI datoteku
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "GSI datoteka (*.GSI, *.gsi) | *.GSI; *.gsi;";
                openFileDialog1.ShowDialog();




                List<ListaLinija> listaLinijas = new List<ListaLinija>();
                BindingList<PripremaLista> pripremaListas = new BindingList<PripremaLista>();
                int idZagrid = 0;
                System.IO.StreamReader file =
                        new System.IO.StreamReader(openFileDialog1.FileName);

                string oznaka = " ";
                string line;
                int counter = 0;
                //citanja linija iz GSI datoteke
                while ((line = file.ReadLine()) != null)
                {
                    //oznaka linije
                    if (line.Length == 16)
                    {
                        oznaka = line;
                    }

                    //uzimanje 4 linije 
                    if (line.Length == 48 || line.Length == 80)
                    {

                        listaLinijas.Add(new ListaLinija
                        {
                            Oznaka = oznaka,
                            Linija = line

                        });

                        counter++;
                    }

                    if (counter == 4)
                    {
                        PripremaLista pripremaRed1 = new PripremaLista
                        {
                            ID = 1,
                            IDZaGrid = idZagrid,
                            VeznaTacka = listaLinijas[0].Linija.Split(' ')[0].Split('+')[1].TrimStart('0').Trim(),
                            OdstojanjeODLetve = ((Convert.ToDecimal(listaLinijas[0].Linija.Split(' ')[1].Split('+')[1]) / 100000) + (Convert.ToDecimal(listaLinijas[3].Linija.Split(' ')[1].Split('+')[1]) / 100000)) / 2,
                            PrvaPodjela = ((Convert.ToDecimal(listaLinijas[0].Linija.Split(' ')[2].Split('+')[1]) / 100000)),
                            DrugaPodjela = (Convert.ToDecimal(listaLinijas[3].Linija.Split(' ')[2].Split('+')[1]) / 100000),
                            Proba = (Convert.ToDecimal(listaLinijas[3].Linija.Split(' ')[2].Split('+')[1]) / 100000) - (Convert.ToDecimal(listaLinijas[0].Linija.Split(' ')[2].Split('+')[1]) / 100000),
                            Oznaka = oznaka,
                            ODDO = " "
                        };
                        idZagrid++;
                        pripremaListas.Add(pripremaRed1);

                        PripremaLista pripremaRed2 = new PripremaLista
                        {
                            ID = 2,
                            IDZaGrid = idZagrid,
                            VeznaTacka = listaLinijas[1].Linija.Split(' ')[0].Split('+')[1].TrimStart('0').Trim(),
                            OdstojanjeODLetve = ((Convert.ToDecimal(listaLinijas[1].Linija.Split(' ')[1].Split('+')[1]) / 100000) + (Convert.ToDecimal(listaLinijas[2].Linija.Split(' ')[1].Split('+')[1]) / 100000)) / 2,
                            PrvaPodjela = (Convert.ToDecimal(listaLinijas[1].Linija.Split(' ')[2].Split('+')[1]) / 100000),
                            DrugaPodjela = (Convert.ToDecimal(listaLinijas[2].Linija.Split(' ')[2].Split('+')[1]) / 100000),
                            Proba = (Convert.ToDecimal(listaLinijas[2].Linija.Split(' ')[2].Split('+')[1]) / 100000) - (Convert.ToDecimal(listaLinijas[1].Linija.Split(' ')[2].Split('+')[1]) / 100000),
                            Oznaka = oznaka,
                            ODDO = " "
                        };
                        idZagrid++;
                        pripremaListas.Add(pripremaRed2);

                        PripremaLista pripremaRed3 = new PripremaLista
                        {

                            ID = 3,
                            IDZaGrid = idZagrid,
                            VeznaTacka = " ",
                            OdstojanjeODLetve = pripremaRed1.OdstojanjeODLetve + pripremaRed2.OdstojanjeODLetve,
                            PrvaPodjela = pripremaRed1.PrvaPodjela - pripremaRed2.PrvaPodjela,
                            DrugaPodjela = pripremaRed1.DrugaPodjela - pripremaRed2.DrugaPodjela,
                            Proba = pripremaRed1.Proba - pripremaRed2.Proba,
                            Oznaka = oznaka,
                            ODDO = " "



                        };
                        pripremaRed3.SrednjaVisinskaRazlika = ((pripremaRed3.PrvaPodjela + pripremaRed3.DrugaPodjela) / 2);
                        pripremaListas.Add(pripremaRed3);
                        idZagrid++;
                        counter = 0;
                        listaLinijas = new List<ListaLinija>();

                    } // kraj counter=4


                } //kraj while


                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();




                int n;
                decimal sumaVisina = 0;
                decimal sumaDuzina = 0;
                for (int i = 0; i < pripremaListas.Count; i++)
                {

                    if (pripremaListas[i].ID == 1 && !int.TryParse(pripremaListas[i].VeznaTacka, out n))
                    {
                        pripremaListas[i].ODDO = "OD";

                        if (i < pripremaListas.Count + 1)
                        {
                            for (int j = i + 1; j < pripremaListas.Count; j++)
                            {
                                if (pripremaListas[j].ID == 3)
                                {
                                    sumaVisina = sumaVisina + pripremaListas[j].SrednjaVisinskaRazlika;
                                    sumaDuzina = sumaDuzina + pripremaListas[j].OdstojanjeODLetve;
                                }


                                if (pripremaListas[j].ID == 2 && !int.TryParse(pripremaListas[j].VeznaTacka, out n))
                                {
                                    pripremaListas[j].ODDO = "DO";
                                    pripremaListas[j + 1].SumaDuzina = (sumaDuzina + pripremaListas[j + 1].OdstojanjeODLetve) / 1000;
                                    pripremaListas[j + 1].SumaVisinskihRazlika = sumaVisina + pripremaListas[j + 1].SrednjaVisinskaRazlika;
                                    sumaVisina = 0;
                                    sumaDuzina = 0;
                                    i = j + 1;
                                    j = pripremaListas.Count + 1;

                                }


                            }
                        }
                    }
                }

                dataGridView1.DataSource = pripremaListas;

                pripremaGrid();
                DozvoljenoOdstupanje();




            }
            catch
            {
                MessageBox.Show("Dogodila se greška sa GSI datotekom");
            }

        }//kraj ucitaj GSI button

        private void DozvoljenoOdstupanje()
        {
            decimal n;
            int a;

            decimal odstupanje = Properties.Settings.Default.Odstupanje;
           
                
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if ((Math.Abs(Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value.ToString()))) > (odstupanje / 1000))
                        {
                            dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.White;
                        }
                    }
                }
                
       

        public void pripremaGrid()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //postavka broja decimala za prikaz
                int BrojDecimalaZaPrikaz = Properties.Settings.Default.Decimalno;



                string nule = "0.";
                for (int g = 0; g < BrojDecimalaZaPrikaz; g++)
                {
                    nule = nule + "0";
                }
                //OdstojanjeODletve
                dataGridView1.Columns[3].DefaultCellStyle.Format = "0.000";

                //prva podjela
                dataGridView1.Columns[4].DefaultCellStyle.Format = nule;
                //druga podjela
                dataGridView1.Columns[5].DefaultCellStyle.Format = nule;
                //proba
                dataGridView1.Columns[6].DefaultCellStyle.Format = nule;
                //srednjavisinska razlika
                dataGridView1.Columns[7].DefaultCellStyle.Format = nule;
                //suma visinskih razlika
                dataGridView1.Columns[10].DefaultCellStyle.Format = nule;
                //suma duzina
                dataGridView1.Columns[11].DefaultCellStyle.Format = nule;
                sumirajgreske();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[0, i].Value.ToString() == "3")
                    {
                        dataGridView1.Rows[i].ReadOnly = true;
                    }
                }

                KolonePrikaz();

                buttonPreracuna.Enabled = true;
            }

        }

        public void KolonePrikaz()
        {
            List<string> ne = new List<string>(Properties.Settings.Default.GridSakri.Split(','));
            ne.Remove("");
            if (ne.Count > 0)
            {
                foreach (string a in ne)
                {
                    dataGridView1.Columns[Convert.ToInt32(a)].Visible = false;
                }
            }

            List<string> za = new List<string>(Properties.Settings.Default.GridKolone.Split(','));
            za.Remove("");

            if (za.Count > 0)
            {
                foreach (string a in za)
                {
                    dataGridView1.Columns[Convert.ToInt32(a)].Visible = true;
                }
            }
        }

        private void sumirajgreske()
        {
            int n;
            string greske = " ";
              //redovi u kojima su greske da jedna provjera ne ponistu drugu
             List<int> nizredova = new List<int>();
            
            if (int.TryParse(dataGridView1[2, 0].Value.ToString(), out n))
            {
                greske = greske + "Red 1: Greška imena početne tačke" + System.Environment.NewLine;
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                nizredova.Add(0);
            }
            else
            {
                if(!nizredova.Contains(0))
                {
                    dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.White;
                }
               
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //provjera jesu li od do tacke iste
                if (dataGridView1[8, i].Value.ToString() == "OD")
                {
                    int t;
                    int y = i + 1;

                    for (int k = y; k < dataGridView1.RowCount; k++)
                    {
                        if (dataGridView1[2, k].Value.ToString() != " " && !int.TryParse(dataGridView1[2, k].Value.ToString(), out t) && dataGridView1[8, k].Value.ToString() != "DO")
                        {
                            greske = greske + "Red" + (k + 1) + ": Greška u nazivu među tačke" + System.Environment.NewLine;

                            dataGridView1.Rows[k].DefaultCellStyle.BackColor = Color.Red;
                            nizredova.Add(k);

                        }
                        else
                        {
                            if (!nizredova.Contains(0))
                            {
                                dataGridView1.Rows[k].DefaultCellStyle.BackColor = Color.White;
                            }
                            
                        }
                        if (dataGridView1[8, k].Value.ToString() == "DO")
                        {


                            if (dataGridView1[2, k].Value.ToString() == dataGridView1[2, i].Value.ToString())
                            {
                                greske = greske + "Red" + (i + 1) + ": Pocetna i zavrsna tacka ne mogu biti iste" + System.Environment.NewLine;
                                dataGridView1.Rows[k].DefaultCellStyle.BackColor = Color.Red;
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                greske = greske + "Red" + (k + 1) + ": Pocetna i zavrsna tacka ne mogu biti iste" + System.Environment.NewLine;
                                nizredova.Add(k);
                                nizredova.Add(i);
                                i = k;
                                k = dataGridView1.RowCount + 1;
                            }
                            else
                            {
                                if(!nizredova.Contains(i))
                                {
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                }

                                if(!nizredova.Contains(k))
                                {
                                    dataGridView1.Rows[k].DefaultCellStyle.BackColor = Color.White;
                                }
                                
                                
                                i = k;
                                k = dataGridView1.RowCount + 1;
                            }





                        }

                    }
                }//kraj provjere od do

            }

            //provjera da nisu medju tacke iste
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Value.ToString() == "1")
                {
                    if (dataGridView1[2, i].Value.ToString() == dataGridView1[2, i + 1].Value.ToString())
                    {
                        greske = greske + "Red " + (i + 1) + ": Pocetna i zavrsna međutacka ne mogu biti iste" + System.Environment.NewLine;
                        greske = greske + "Red " + (i + 2) + ": Pocetna i zavrsna međutacka ne mogu biti iste" + System.Environment.NewLine;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dataGridView1.Rows[i + 1].DefaultCellStyle.BackColor = Color.Red;
                        nizredova.Add(i);
                        nizredova.Add(i+1);
                    }
                    else
                    {
                        if(!nizredova.Contains(i))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        if(!nizredova.Contains(i+1))
                        {
                            dataGridView1.Rows[i + 1].DefaultCellStyle.BackColor = Color.White;
                        }
                        
                        
                    }
                }
            }

            if (greske != " ")
            {

                ErrorForm errorForm = new ErrorForm(greske);
                errorForm.ShowDialog();
                buttonNapraviNO1.Enabled = false;
                buttonNapraviNO2.Enabled = false;
            }
            else
            {
                buttonNapraviNO1.Enabled = true;
                buttonNapraviNO2.Enabled = true;
            }
        }

        public void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        } //kraj copy stream

        private void buttonNapraviNO1_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                String resourceName = "NO1template.xlsx";
                String path = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


                Assembly asm = Assembly.GetExecutingAssembly();
                string res = string.Format("{0}.Resources." + resourceName, asm.GetName().Name);
                Stream stream = asm.GetManifestResourceStream(res);
                try
                {
                    using (Stream filea = File.Create(path + @"\" + resourceName))
                    {
                        CopyStream(stream, filea);
                    }

                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlsWorkBook = xls.Workbooks.Open(path + @"\" + resourceName);
                Microsoft.Office.Interop.Excel.Worksheet Glavni = xlsWorkBook.Worksheets["NO1Obrazac"];

                Glavni = xlsWorkBook.Sheets["NO1Obrazac"];
                Glavni = xlsWorkBook.ActiveSheet;
                int zadnjiROw = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //vezna tacka
                    Glavni.Cells[i + 8, 3] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    //odstojanje od letve
                    Glavni.Cells[i + 8, 4] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    // prva podjela
                    Glavni.Cells[i + 8, 5] = decimal.Round(Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value.ToString()), 5).ToString();
                    //druga podjela
                    Glavni.Cells[i + 8, 6] = decimal.Round(Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value.ToString()), 5).ToString();
                    //proba
                    Glavni.Cells[i + 8, 7] = decimal.Round(Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value.ToString()), 5).ToString();
                    //srednja visinska razlika
                    if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value.ToString()) == 0)
                    {
                        Glavni.Cells[i + 8, 8] = " ";
                    }
                    else
                    {
                        Glavni.Cells[i + 8, 8] = decimal.Round(Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value.ToString()), 5).ToString();
                    }

                    zadnjiROw = i + 9;

                }
                Microsoft.Office.Interop.Excel.Range last = Glavni.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

                Microsoft.Office.Interop.Excel.Range range = Glavni.get_Range("A" + zadnjiROw, last);
                range.EntireRow.Clear();
                range.EntireRow.Delete();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx, *.xls)|*.xlsx; *.xls";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = "N01 obrazac.xlsx";

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Glavni.SaveAs(saveDialog.FileName);

                    MessageBox.Show("Zavrseno", "Informacija");
                }
                xlsWorkBook.Close(true);

                xls.Quit();

                Marshal.ReleaseComObject(xlsWorkBook);
                Marshal.ReleaseComObject(Glavni);
                Marshal.ReleaseComObject(xls);
                Cursor.Current = Cursors.Default;

            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška u kreiranju NO1 obrasca");
            }
        }
        //umjesto 0 prazno
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "SrednjaVisinskaRazlika" || dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "SumaVisinskihRazlika" || dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "SumaDuzina")
            {
                decimal value = (decimal)e.Value;
                if (value == 0)
                {
                    e.Value = string.Empty;
                    e.FormattingApplied = true;
                }
            }
        }
        //id reda
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void buttonNapraviNO2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                String resourceName = "templateNO2.xlsx";
                String path = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


                Assembly asm = Assembly.GetExecutingAssembly();
                string res = string.Format("{0}.Resources." + resourceName, asm.GetName().Name);
                Stream stream = asm.GetManifestResourceStream(res);
                try
                {
                    using (Stream filea = File.Create(path + @"\" + resourceName))
                    {
                        CopyStream(stream, filea);
                    }
                    // Process.Start(path + @"\" + resourceName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlsWorkBook = xls.Workbooks.Open(path + @"\" + resourceName);
                Microsoft.Office.Interop.Excel.Worksheet Glavni = xlsWorkBook.Worksheets["NO2 obrazac"];


                Glavni = xlsWorkBook.Sheets["NO2 obrazac"];
                Glavni = xlsWorkBook.ActiveSheet;
                int zadnjiROw = 0;

                List<No2Lista> no2Listas = new List<No2Lista>();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[8, i].Value.ToString() == "OD")
                    {
                        No2Lista no2 = new No2Lista();
                        no2.OD = dataGridView1[2, i].Value.ToString();
                        for (int k = i; k < dataGridView1.RowCount; k++)
                        {
                            if (dataGridView1[8, k].Value.ToString() == "DO")
                            {
                                no2.DO = dataGridView1[2, k].Value.ToString();
                                no2.Uzeto = "N.O.1";
                                no2.SumaDuzina = dataGridView1[11, k + 1].Value.ToString();
                                no2.SumaVisinskihRazlika = dataGridView1[10, k + 1].Value.ToString();
                                i = k;
                                k = dataGridView1.RowCount + 1;

                            }
                        }
                        no2Listas.Add(no2);

                    }
                }

                for (int i = 0; i < no2Listas.Count; i++)
                {
                    Glavni.Cells[i + 9, 1] = no2Listas[i].OD;
                    Glavni.Cells[i + 9, 2] = no2Listas[i].DO;
                    Glavni.Cells[i + 9, 3] = no2Listas[i].Uzeto;
                    Glavni.Cells[i + 9, 4] = no2Listas[i].SumaDuzina;
                    Glavni.Cells[i + 9, 5] = no2Listas[i].SumaVisinskihRazlika;
                    zadnjiROw = i + 10;
                    for (int k = 1 + i; k < no2Listas.Count; k++)
                    {
                        if ((no2Listas[k].OD == no2Listas[i].DO) && (no2Listas[k].DO == no2Listas[i].OD))
                        {
                            Glavni.Cells[i + 9, 7] = no2Listas[i].Uzeto;
                            Glavni.Cells[i + 9, 8] = no2Listas[k].SumaDuzina;
                            Glavni.Cells[i + 9, 9] = no2Listas[k].SumaVisinskihRazlika;

                            no2Listas.RemoveAt(k);
                            k = no2Listas.Count + 1;
                        }
                    }

                }
                Microsoft.Office.Interop.Excel.Range last = Glavni.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

                Microsoft.Office.Interop.Excel.Range range = Glavni.get_Range("A" + zadnjiROw, last);

                range.EntireRow.Delete();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx, *.xls)|*.xlsx; *.xls";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = "N02 obrazac.xlsx";

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Glavni.SaveAs(saveDialog.FileName);


                    MessageBox.Show("Zavrseno", "Informacija");
                }
                xlsWorkBook.Close(true);

                xls.Quit();

                Marshal.ReleaseComObject(xlsWorkBook);
                Marshal.ReleaseComObject(Glavni);
                Marshal.ReleaseComObject(xls);
                Cursor.Current = Cursors.Default;


            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška u kreiranju NO2 obrasca");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Dozvoljen unos samo brojeva");
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView1.Tag = dataGridView1.CurrentCell.Value;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;

            int n;
            if (column == 2 && row == 0)
            {
                if (int.TryParse(dataGridView1[2, 0].Value.ToString(), out n))
                {
                    dataGridView1[2, 0].Value = dataGridView1.Tag;
                    MessageBox.Show("Prva tačka ne moze biti broj", "Upozorenje");
                }
            }
            else
            {
                if (column == 2 && row > 0)
                {
                    if (dataGridView1[0, row].Value.ToString() == "1" && (dataGridView1[12, row].Value.ToString() == dataGridView1[12, row - 2].Value.ToString()))
                    {
                        dataGridView1[2, row - 2].Value = dataGridView1[2, row].Value.ToString();
                    }
                    else
                    {
                        if (dataGridView1[12, row].Value.ToString() == dataGridView1[12, row + 2].Value.ToString())
                        {
                            dataGridView1[2, row + 2].Value = dataGridView1[2, row].Value.ToString();
                        }
                    }
                }
            }

        }

        private void buttonPreracuna_Click(object sender, EventArgs e)
        {
            //sume
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[0, i].Value.ToString() == "3")
                {
                    dataGridView1[3, i].Value = Convert.ToDecimal(dataGridView1[3, i - 2].Value.ToString()) + Convert.ToDecimal(dataGridView1[3, i - 1].Value.ToString());
                    dataGridView1[4, i].Value = Convert.ToDecimal(dataGridView1[4, i - 2].Value.ToString()) - Convert.ToDecimal(dataGridView1[4, i - 1].Value.ToString());
                    dataGridView1[5, i].Value = Convert.ToDecimal(dataGridView1[5, i - 2].Value.ToString()) - Convert.ToDecimal(dataGridView1[5, i - 1].Value.ToString());
                    dataGridView1[6, i].Value = Convert.ToDecimal(dataGridView1[6, i - 2].Value.ToString()) - Convert.ToDecimal(dataGridView1[6, i - 1].Value.ToString());
                    dataGridView1[7, i].Value = ((Convert.ToDecimal(dataGridView1[4, i].Value.ToString()) + Convert.ToDecimal(dataGridView1[5, i].Value.ToString())) / 2).ToString();
                }

            }

            //od do , suma duzina i suma visinskih razlika
            int n;
            decimal sumaVisina = 0;
            decimal sumaDuzina = 0;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                dataGridView1[8, i].Value = " ";
                dataGridView1[11, i].Value =Convert.ToDecimal(0);
                dataGridView1[10, 1].Value =Convert.ToDecimal(0);
                if (dataGridView1[0,i].Value.ToString()=="1" && !int.TryParse(dataGridView1[2,i].Value.ToString(),out n) )
                {
                    dataGridView1[8, i].Value = "OD";
                    

                    if(i<dataGridView1.Rows.Count+1)
                    {
                        for(int j=i+1;j<dataGridView1.Rows.Count;j++)
                        {
                            dataGridView1[8, j].Value = " ";
                            dataGridView1[11, j].Value = Convert.ToDecimal(0);
                            dataGridView1[10, j].Value = Convert.ToDecimal(0);

                            if (dataGridView1[0,j].Value.ToString()=="3")
                            {
                                sumaVisina = sumaVisina + Convert.ToDecimal(dataGridView1[7, j].Value.ToString());
                                sumaDuzina = sumaDuzina + Convert.ToDecimal(dataGridView1[3, j].Value.ToString());

                            }

                            if(dataGridView1[0,j].Value.ToString()=="2" && !int.TryParse(dataGridView1[2,j].Value.ToString(),out n))
                            {
                                dataGridView1[8, j].Value = "DO";
                                dataGridView1[11, j+1].Value = (sumaDuzina + Convert.ToDecimal(dataGridView1[3, j + 1].Value.ToString())) / 1000;
                                dataGridView1[10, j+1].Value = sumaVisina + Convert.ToDecimal(dataGridView1[7, j + 1].Value.ToString());
                                sumaVisina = 0;
                                sumaDuzina = 0;
                                i = j + 1;
                                j = dataGridView1.RowCount +1;
                            }
                        }
                    }
                }
            }

            pripremaGrid();
            DozvoljenoOdstupanje();
           
        }

        private void preračunajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonPreracuna.PerformClick();
        }

        private void obrišiRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        int index = this.dataGridView1.SelectedRows[i].Index;
                        if (dataGridView1[2, dataGridView1.SelectedRows[i].Index].Value.ToString() == " ")
                        {
                            dataGridView1.Rows.RemoveAt(index - 2);
                            dataGridView1.Rows.RemoveAt(index - 2);
                            dataGridView1.Rows.RemoveAt(index - 2);


                        }
                        else
                        {

                            if (index > 0 && dataGridView1[2, dataGridView1.SelectedRows[i].Index - 1].Value.ToString() != " ")
                            {
                                dataGridView1.Rows.RemoveAt(index);
                                dataGridView1.Rows.RemoveAt(index);
                                dataGridView1.Rows.RemoveAt(index - 1);

                            }
                            else
                            {
                                dataGridView1.Rows.RemoveAt(index);
                                dataGridView1.Rows.RemoveAt(index);
                                dataGridView1.Rows.RemoveAt(index);

                            }



                        }

                    }
                    catch
                    {

                    }
                }



            }
            buttonPreracuna.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostavkePage postavkePage = new PostavkePage();
            postavkePage.ShowDialog();
        }
    }
}
    

