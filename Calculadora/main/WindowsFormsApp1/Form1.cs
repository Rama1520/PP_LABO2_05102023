﻿using Entidades;
using System;
using System.Text;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private eSistema sistema;
        private StringBuilder sb = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.opcionDecimal.Checked = true;
        }


        private void txtOpPrimer_TextChanged(object sender, EventArgs e)
        {
            this.primerOperando = new Numeracion(txtOpPrimer.Text, eSistema.Decimal);

        }

        private void txtOpseg_TextChanged(object sender, EventArgs e)
        {
            this.segundoOperando = new Numeracion(txtOpseg.Text, eSistema.Decimal);
        }

        private void botonOperar_Click(object sender, EventArgs e)
        {

            string operar = cajaOperacion.Text;
            char miChar;
            miChar = operar[0];
            sb.Clear();
            calculadora = new Operacion(primerOperando, segundoOperando);
            this.resultado = calculadora.Operar(miChar);
            resultMostrar.Text = resultado.ValorNumerico;
            //agrego
            sb.Append(primerOperando.ValorNumerico);
            sb.Append(miChar);
            sb.Append(segundoOperando.ValorNumerico);
            sb.Append('=');
            sb.Append(resultado.ValorNumerico);
            setResultado();
        }
        private void opcionDecimal_CheckedChanged(object sender, EventArgs e)
        {
            this.sistema = eSistema.Decimal;
        }

        private void opcionBinario_CheckedChanged(object sender, EventArgs e)
        {
            this.sistema = eSistema.Binario;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {

            this.txtOpPrimer.Clear();
            this.txtOpseg.Clear();
            lbox_historial.Items.Clear();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult mensajeSalida = MessageBox.Show("¿Desea cerrar la calculadora?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensajeSalida == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        public void setResultado()
        {
            lbox_historial.Items.Add(sb.ToString());
            resultMostrar.Text = resultado.ConvertirA(this.sistema);
        }
    }
}
