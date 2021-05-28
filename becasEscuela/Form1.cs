using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace becasEscuela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
        private void ValidarCampo()
        {
            var vr = !string.IsNullOrEmpty(textBoxApellido.Text) && !string.IsNullOrEmpty(textBoxNombre.Text) &&
                !string.IsNullOrEmpty(textBoxDni.Text) && !string.IsNullOrEmpty(textBoxCuil.Text) &&
                !string.IsNullOrEmpty(textBoxNacionalidad.Text) && !string.IsNullOrEmpty(textBoxDomNum.Text) &&
                !string.IsNullOrEmpty(textBoxCodPostal.Text) && !string.IsNullOrEmpty(textBoxLocalBarrio.Text) &&
                !string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxTel.Text) &&
                !string.IsNullOrEmpty(textBoxGradoAño.Text) && !string.IsNullOrEmpty(textBoxTurno.Text) &&
                !string.IsNullOrEmpty(textBoxNombPadre.Text) && !string.IsNullOrEmpty(textBoxApellPadre.Text) && !string.IsNullOrEmpty(textBoxEdadPadre.Text) &&
                !string.IsNullOrEmpty(textBoxOcupPadre.Text) && !string.IsNullOrEmpty(textBoxIngrNetosPad.Text) &&
                !string.IsNullOrEmpty(textBoxNomMad.Text) && !string.IsNullOrEmpty(textBox5ApeMad.Text) && !string.IsNullOrEmpty(textBox4EdadMad.Text) &&
                !string.IsNullOrEmpty(textBox3OcuMad.Text) && !string.IsNullOrEmpty(textBoxIngNetosMad.Text);
            button1.Enabled = vr;
         }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            ValidarCampo();
        }
     
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Alumno alu = new Alumno(Convert.ToInt64(textBoxDni.Text.Trim()), textBoxNombre.Text.Trim(), textBoxApellido.Text.Trim(), textBoxNacionalidad.Text.Trim(),
                                    dateTimePickerFechaNac.Value.Year + "/" +dateTimePickerFechaNac.Value.Month + "/" +dateTimePickerFechaNac.Value.Day,
                                    Convert.ToInt64(textBoxCuil.Text.Trim()), textBoxDomNum.Text.Trim(), textBoxCodPostal.Text.Trim(), textBoxLocalBarrio.Text.Trim(),
                                    textBoxEmail.Text.Trim(), textBoxTel.Text.Trim(), textBoxGradoAño.Text.Trim(), textBoxTurno.Text.Trim(),1,1);

            int resultado1 = AlumnoDAL.Agregar(alu);
            if (resultado1 < 1)
                MessageBox.Show("No se pudo guardar la 1ea parte: Alumno”, “Fallo!!");

            //Ingresa el padre, es el 1 que lo relaciona con la tabla Rol

            int convivePadre = 0;
            int conviveMadre = 0;
            
            if (radioButtonPadreSi.Checked == true)
                convivePadre = 1;
            if (radioButtonMadreSi.Checked == true)
                convivePadre = 1;
            Padres padre = new Padres(textBoxApellPadre.Text.Trim(), textBoxNombPadre.Text.Trim(), Convert.ToInt16(textBoxEdadPadre.Text.Trim()),
                textBoxOcupPadre.Text.Trim(), textBoxLugTrabPadre.Text.Trim(), Convert.ToDouble(textBoxIngrNetosPad.Text.Trim()), convivePadre,
                1,alu.DNI);

            //Ingresa la madre, es el 2 que lo relaciona con la tabla Rol
            Padres madre = new Padres(textBox5ApeMad.Text.Trim(), textBoxNomMad.Text.Trim(), Convert.ToInt16(textBox4EdadMad.Text.Trim()),
                textBox3OcuMad.Text.Trim(), textBoxLugTrabMad.Text.Trim(), Convert.ToDouble(textBoxIngNetosMad.Text.Trim()), conviveMadre,
                2, alu.DNI);
            
            int resultadoPadre = PadresDAL.Agregar(padre);
            if (resultadoPadre < 1)
                MessageBox.Show("No se pudo guardar el Padre”, “Fallo!!");
            int resultadoMadre = PadresDAL.Agregar(madre);
            if (resultadoMadre < 1)
                MessageBox.Show("No se pudo guardar la Madre”, “Fallo!!");

            alu.PadresLista.Add(padre); 
            alu.PadresLista.Add(madre);


            //MessageBox.Show("SE GUARDO Correcto”, “Bien");
            // Agrega hermanos, los que estan el edad escolar, y con ya tener dos afecta la beca
            if(textBox3NomHer1.Text.Length != 0  && textBoxEdadHer1.Text.Length !=0){
                int conviveHer1 = 0;
                if (radioButtonHer1Si.Checked == true)
                    conviveHer1 = 1;
                Hermano hermano1 = new Hermano(textBox3NomHer1.Text.Trim(),Convert.ToInt16(textBoxEdadHer1.Text.Trim()),textBoxOcupHer1.Text.Trim(),
                    textBoxEscuHer1.Text.Trim(), conviveHer1, alu.DNI);
                int resultadoHermano1 = HermanoDAL.Agregar(hermano1);
                if (resultadoHermano1 < 1)
                    MessageBox.Show("No se pudo guardar el Hermano1”, “Fallo!!");
                
                alu.HermanosLista.Add(hermano1);
            }
                        
            if(textBoxNomHer2.Text.Length != 0  && textBoxEdadHer2.Text.Length !=0){
                int conviveHer2 = 0;
                if (radioButtonHer2Si.Checked == true)
                    conviveHer2 = 1;
                Hermano hermano2 = new Hermano(textBoxNomHer2.Text.Trim(),Convert.ToInt16(textBoxEdadHer2.Text.Trim()),textBoxOcupHer2.Text.Trim(),
                    textBoxEscuHer2.Text.Trim(), conviveHer2, alu.DNI);
                int resultadoHermano2 = HermanoDAL.Agregar(hermano2);
                if (resultadoHermano2 < 1)
                    MessageBox.Show("No se pudo guardar el Hermano2”, “Fallo!!");

                alu.HermanosLista.Add(hermano2);

            }

            if (textBoxNomHer3.Text.Length != 0 && textBoxEdadHer3.Text.Length != 0)
            {
                int conviveHer3 = 0;
                if (radioButtonHer3Si.Checked == true)
                    conviveHer3 = 1;
                Hermano hermano3 = new Hermano(textBoxNomHer3.Text.Trim(), Convert.ToInt16(textBoxEdadHer3.Text.Trim()), textBoxOcupHer3.Text.Trim(),
                    textBoxEscuHer3.Text.Trim(), conviveHer3, alu.DNI);
                int resultadoHermano3 = HermanoDAL.Agregar(hermano3);
                if (resultadoHermano3 < 1)
                    MessageBox.Show("No se pudo guardar el Hermano3”, “Fallo!!");

                alu.HermanosLista.Add(hermano3);
            }
            //agrega la parte enfermedad cronica si lo hay       
            if (textBoxDiagnostFam.Text != "" && textBoxGastosMens.Text != "" && radioButtonCronicaSi.Checked == true)
            {
                FamiliarEnfermedadCronica enferCronica = new FamiliarEnfermedadCronica(textBoxDiagnostFam.Text.Trim(),
                     Convert.ToDouble(textBoxGastosMens.Text.Trim()), alu.DNI);
                int resultadoEnfCronica = FamiliarEnfermedadCronicaDAL.Agregar(enferCronica);
                if (resultadoEnfCronica < 1)
                    MessageBox.Show("No se pudo guardar enfermedad cronica","Fallo!!");
                alu.EnfermedadCronica = enferCronica;
                //MessageBox.Show("ALUMNO CARGADO (Grupo Familiar con EC)”, “Correcto");
            }
            else 
            {
                FamiliarEnfermedadCronica enferCronica = new FamiliarEnfermedadCronica(alu.DNI);
                alu.EnfermedadCronica = enferCronica;
                //MessageBox.Show("ALUMNO CARGADO (Sin  EC)”, “Correcto");

            }
            int calificacionBecaAlumno = alu.CalificarAlumnoBeca(alu);
            int resultadoActualizarBeca = AlumnoDAL.Actualizar(alu.DNI,calificacionBecaAlumno);
            if (resultadoActualizarBeca < 1)
                MessageBox.Show("No se pudo guardar la actualizacion de estado de beca”, “Fallo!!");

            switch (calificacionBecaAlumno) {
                case 2:
                    MessageBox.Show("ALUMNO CARGADO  -  Estado: BECA RECHAZADA", "Estado Beca");
                    break;
                case 3:
                    MessageBox.Show("ALUMNO CARGADO  -  Estado: MEDIA BECA", "Estado Beca");
                    break;
                case 4:
                    MessageBox.Show("ALUMNO CARGADO  -  Estado: BECA COMPLETA", "Estado Beca");
                    break;
                case 5:
                    MessageBox.Show("ALUMNO CARGADO  -  Estado:CASO  A ESTUDIAR POR COMISION DE BECA", "Estado Beca");
                    break;
            }
            
            
            Form1 formAux = new Form1();
            formAux.Show();
            this.Hide();            

        }
        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDiagnostFam.Enabled = false;
            textBoxGastosMens.Enabled = false;
        }

        private void radioButtonCronicaSi_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDiagnostFam.Enabled = true;
            textBoxGastosMens.Enabled = true;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxDni_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxCodPostal_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxLocalBarrio_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxTel_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxGradoAño_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxTurno_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxNombPadre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxApellPadre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxEdadPadre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxOcupPadre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxNomMad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBox5ApeMad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBox4EdadMad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBox3OcuMad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxIngrNetosPad_KeyPress(object sender, KeyPressEventArgs e) 
        {   
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void textBoxIngNetosMad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxEdadPadre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxEdadHer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxEdadHer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxEdadHer3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxGastosMens_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDomNum_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxIngrNetosPad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void textBoxIngNetosMad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }
    }

}