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
            if (lstCanciones.SelectedIndex == 0)
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }
            if (lstCanciones.SelectedIndex == rutasArchivosMP3.Length-1)
            {
                btnSiguiente.Enabled = false;
            }
            else
            {
                btnSiguiente.Enabled = true;
            }
            Reproductor.URL = rutasArchivosMP3[lstCanciones.SelectedIndex];
            lblCancion.Text = ArchivosMP3[lstCanciones.SelectedIndex];
            lblAlbum.Text = "No found";
            lblArtist.Text = "No found";
            lblGenero.Text = "No found";
            lblYear.Text = "No found";
            try
            {
                TagLib.File datos = TagLib.File.Create(rutasArchivosMP3[lstCanciones.SelectedIndex]);
                lblGenero.Text = datos.Tag.Genres[0];
                lblArtist.Text = datos.Tag.AlbumArtists[0];
                lblYear.Text = Convert.ToString(datos.Tag.Year);
                lblAlbum.Text = datos.Tag.Album;
                //lblDuracion.Text = datos.Tag.
            }
            catch
            {
            }
        }
        private void bntAdjuntar_Click(object sender, EventArgs e)
        {
            lstCanciones.SelectedIndex = 0; //Poner en primer lugar
            if (lstCanciones.SelectedIndex == 0)
                btnPrimera.Enabled = false;
            else
                btnPrimera.Enabled = true;
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            lstCanciones.SelectedIndex = lstCanciones.SelectedIndex - 1; //Regresar una posicion
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            lstCanciones.SelectedIndex = lstCanciones.SelectedIndex + 1; //Regresar una posicion
        }
        private void bntUltimo_Click(object sender, EventArgs e)
        {
            lstCanciones.SelectedIndex = lstCanciones.Items.Count - 1; //Ultimo lugar
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblCancion_Click(object sender, EventArgs e)
        {

        }
    }
}
