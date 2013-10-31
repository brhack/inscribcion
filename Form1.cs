using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace unison
{
    public partial class Form1 : Form
    {
        DataTable a = new DataTable();
        DataTable r = new DataTable();
        int rei = 0;
        int rer = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a.Columns.Add("nombre", typeof(string));
            a.Columns.Add("carrera", typeof(string));
            a.Columns.Add("Fecha de nacimiento", typeof(string));
            a.Columns.Add("direccion", typeof(string));
            a.Columns.Add("curp", typeof(string));
            a.Columns.Add("colegiatura", typeof(Int32));



            r.Columns.Add("nombre", typeof(string));
            r.Columns.Add("expediente", typeof(Int32));
            r.Columns.Add("reprobadas", typeof(string));
            r.Columns.Add("colegiatura", typeof(Int32));
            r.Columns.Add("promedio", typeof(double));


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Nuevo ingreso"))
            {
                panel2.SendToBack();

            }
            else
            {
                groupBox2.Enabled = true;
                panel2.BringToFront();

            }

        }

        public void Add()
        {
            DataRow i = a.NewRow();
            i[0] = txtnombre.Text;
            i[1] = txtcarrera.Text;
            i[2] = dateTimePicker1.Text;
            i[3] = txtdirec.Text;
            i[4] = txtcurp.Text;
            i[5] = "800";
            a.Rows.Add(i);
            dataGridView1.DataSource = a;
            
        }

        public void Addd()
        {
            DataRow r1 = r.NewRow();
            r1[0] = txtnombre2.Text;
            r1[1] = txtexp.Text;
            r1[2] = cbrep.Text;
            r1[4] = txtprom.Text;
            r.Rows.Add(r1);
            dataGridView2.DataSource = r;
            double des1=.10, desc2=.30,resul=0, resul2=0;
           int pago=1500;
           if (cbrep.Text == "Si")
           {
               r1[3] = pago;
           }
           else
           {
               for (int x = 69; x <= 80; x++)
               {

                   if (txtprom.Text == x.ToString())
                   {
                       resul = pago * des1;
                       resul2 = pago - resul;
                       r1[3] = resul2;
                   }
                   else
                   {
                       resul = pago * desc2;
                       resul2 = pago - resul;
                       r1[3] = resul2;
                   }
               }
           }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Add();
            suma();
            contador();
        }

        private void Agregarre_Click(object sender, EventArgs e)
        {
            Addd();
            contador2();
            suma2();
            limpiar();
            
        }

        private void suma()
        {
            int suma = 0, d = dataGridView1.RowCount;
            for (int y = 0; y < d; y++)

            {
                suma = suma + Convert.ToInt32(dataGridView1["colegiatura", y].Value.ToString());
            
            }
            txtcoleg.Text = suma.ToString();
        }

        private void contador()
        {

            int renglones = dataGridView1.RowCount;
            int conta = 0;

            for (int i = 0; i < renglones; i++)
            {
                conta = conta + 1;
            }

            textBox2.Text = conta.ToString();
        }

        private void contador2()
        {
            int renglones = dataGridView2.RowCount;
            int conta = 0;
            for (int i = 0; i < renglones; i++)
            {
                conta = conta+1;
            }
            alrein.Text = conta.ToString();
        }

        private void suma2()
        {
            int suma = 0;
            int j = dataGridView2.RowCount;

            for (int i = 0; i < j; i++)
            {
                suma = suma + Convert.ToInt32(dataGridView2[3, i].Value.ToString());
            }
            colegre.Text = suma.ToString();

        }

        private void limpiar()
        {
            txtcarrera.Clear();
            txtcurp.Clear();
            txtdirec.Clear();
            txtexp.Clear();
            txtnombre.Clear();
            txtnombre2.Clear();
            txtprom.Clear();
            cbrep.ResetText();
        }

       

        private void cbrep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbrep.Text == "Si")
            {
                rei = rei + 1;
            }
            if (cbrep.Text == "No")
            
            {
                rer = rer + 1;
            }
            iregu.Text = rei.ToString();
            regu.Text = rer.ToString();

        }


      
    }
}
