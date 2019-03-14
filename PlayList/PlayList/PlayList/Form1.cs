using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayList
{
    public partial class Form1 : Form
    {
        bool play = false;
        string[] ArchivosMP3;
        string[] rutasArchivosMP3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reproductor.URL = rutasArchivosMP3[lstCanciones.SelectedIndex];
            lblCancion.Text = ArchivosMP3[lstCanciones.SelectedIndex];
        }

        private void bntAdjuntar_Click(object sender, EventArgs e)
        {
           
                
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog cajaBusqueda = new OpenFileDialog(); //Instanciamos OpenFileDialog
            cajaBusqueda.Multiselect = true; //Multiselect nos permite seleccionar varios archivos
            if (cajaBusqueda.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Checamos si el usuario oprimio OK
            {
                ArchivosMP3 = cajaBusqueda.SafeFileNames;
                rutasArchivosMP3 = cajaBusqueda.FileNames;
                foreach (var Archivo in ArchivosMP3) //Leer cada archivo MP3
                {
                    lstCanciones.Items.Add(Archivo);
                }
                Reproductor.URL = rutasArchivosMP3[0];
                lstCanciones.SelectedIndex = 0;

                //SelectIndex, SelectValues
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            

        }
    }
}
