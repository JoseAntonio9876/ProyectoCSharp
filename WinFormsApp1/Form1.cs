using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.clases;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Persona person = new Persona();
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]";
        string nombrePattern = @"^[a-zA-Z]+$";
        bool isEmailValid;
        bool isNombreValid;
        public Form1()
        {
            InitializeComponent();
            this.llenarGrid();
        }

       

        public void limpiar()
        {
           txtid.Text = "";
           txtnombre.Text="";
           txtapp.Text="";
           txtxapm.Text="";
           txtxcorreo.Text="";
        }

        public void llenarGrid()
        {
            dtview.DataSource = person.obtener_personas();
        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {


           
            person.Nombre = txtnombre.Text;
            person.Apellido_p = txtapp.Text;
            person.Apellido_m = txtxapm.Text;
            person.Correo = txtxcorreo.Text;
            isEmailValid = Regex.IsMatch(txtxcorreo.Text, emailPattern);
            isNombreValid = Regex.IsMatch(txtnombre.Text, nombrePattern);
            if (!isEmailValid)
            {
                MessageBox.Show("Error el correo es incorrecto, " + txtxcorreo.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!isNombreValid)
            {
                MessageBox.Show("Error el nombre es incorrecto, " + txtnombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
             int result = person.insertar_persona();

                        if (result > 0)
                        {
                            MessageBox.Show("Se registro de manera correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiar();
                            this.llenarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

            }
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelcontenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            person.Nombre = txtbuscar.Text;
            dtview.DataSource = person.buscar_persona();
          

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dtview.Rows[e.RowIndex];


        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            person.Id =Convert.ToInt32(txtid.Text);
            DialogResult dialog;
            if(person.Id >=0)
            {

                 dialog=MessageBox.Show("¿Desea eliminar el regsitro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog== DialogResult.Yes)
                {
                    if (person.eliminar_persona() > 0)
                    {
                        this.limpiar();
                        this.llenarGrid();
                        MessageBox.Show("Se elimino de manera correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el registro de "+txtnombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.limpiar();
                      
                    }
                }
            }
         
           


        }

        private void button2_Click(object sender, EventArgs e)
        {

            person.Id = Convert.ToInt32(txtid.Text);
            person.Nombre = txtnombre.Text;
            person.Apellido_p = txtapp.Text;
            person.Apellido_m = txtxapm.Text;
            person.Correo = txtxcorreo.Text;
            isEmailValid = Regex.IsMatch(txtxcorreo.Text, emailPattern);
            isNombreValid = Regex.IsMatch(txtnombre.Text, nombrePattern);
            DialogResult dialog;
            if (person.Id >= 0 )
            {
                if (!isEmailValid )
                {
                    MessageBox.Show("Error el correo es incorrecto, " + txtxcorreo.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }else if (!isNombreValid)
                {
                    MessageBox.Show("Error el nombre es incorrecto, " + txtnombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                             dialog = MessageBox.Show("¿Desea actualizar el registro", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialog == DialogResult.Yes)
                        {
                                if (person.actualiza_persona() > 0)
                                {
                                    this.limpiar();
                                    this.llenarGrid();
                                    MessageBox.Show("Se Actualizo de manera correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    MessageBox.Show("Error al Actualziar el registro de " + txtnombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.limpiar();

                                }
                    }
                }

             
            }


        }

       

        private void dtview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtid.Text = dtview.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dtview.CurrentRow.Cells[1].Value.ToString();
                txtapp.Text = dtview.CurrentRow.Cells[2].Value.ToString();
                txtxapm.Text = dtview.CurrentRow.Cells[3].Value.ToString();
                txtxcorreo.Text = dtview.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {
            }
        }
    }

}
