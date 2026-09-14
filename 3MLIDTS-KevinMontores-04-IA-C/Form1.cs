using System;
using System.IO;
using System.Windows.Forms;

namespace _3MLIDTS_KevinMontores_04_IA_C
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = tbNombre.Text.Trim();
            string apellidos = tbApellido.Text.Trim();
            string telefono = tbTelefono.Text.Trim();
            string edad = tbEdad.Text.Trim();
            string estatura = tbEstatura.Text.Trim();

            if (nombres == "" ||
                apellidos == "" ||
                telefono == "" ||
                edad == "" ||
                estatura == "")
            {
                MessageBox.Show(
                    "Complete todos los campos.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string genero = "";

            if (rbMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbFemenino.Checked)
            {
                genero = "Femenino";
            }
            else if (rbOtro.Checked)
            {
                genero = "Otro";
            }
            else
            {
                MessageBox.Show(
                    "Seleccione un género.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string mensaje =
                "Nombre: " + nombres + Environment.NewLine +
                "Apellido: " + apellidos + Environment.NewLine +
                "Teléfono: " + telefono + Environment.NewLine +
                "Edad: " + edad + Environment.NewLine +
                "Estatura: " + estatura + Environment.NewLine +
                "Género: " + genero;

            try
            {
                // Obtener automáticamente la carpeta Documentos
                string carpetaDocumentos =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments
                    );

                // Crear ruta del archivo
                string rutaFile =
                    Path.Combine(
                        carpetaDocumentos,
                        "#3MAgoDic26.txt"
                    );

                // Guardar en el TXT
                using (StreamWriter escritor =
                       new StreamWriter(rutaFile, true))
                {
                    escritor.WriteLine(mensaje);
                    escritor.WriteLine("---------------------------");
                }

                MessageBox.Show(
                    "Registro guardado correctamente.\n\n" +
                    "Archivo guardado en:\n" +
                    rutaFile,
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el archivo.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbApellido.Clear();
            tbTelefono.Clear();
            tbEdad.Clear();
            tbEstatura.Clear();

            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            rbOtro.Checked = false;

            tbNombre.Focus();
        }
    }
}