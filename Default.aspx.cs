using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationLab8D
{
    public partial class _Default : Page
    {
        static List<Jugador> jugadores = new List<Jugador>();
        static List<Resultado> resultados = new List<Resultado>();

        public void Leer()
        {
            string fileName = Server.MapPath("~/Archivos/Jugadores.txt");

            
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            
            while (reader.Peek() > -1)            
            {
                Jugador jugador = new Jugador();
                jugador.id =  Convert.ToInt32(reader.ReadLine());
                jugador.nombre = reader.ReadLine();
                jugador.equipo = reader.ReadLine();
               
                jugadores.Add(jugador);
            }
            
            reader.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Leer();
                DropDownList1.DataValueField = "id";
                DropDownList1.DataTextField = "nombre";

                DropDownList1.DataSource = jugadores;
                DropDownList1.DataBind();
            }


        }

        private void Guardar()
        {
            string fileName = Server.MapPath("~/Archivos/Resultados.txt");

            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);           
            StreamWriter writer = new StreamWriter(stream);
            foreach (var resultado in resultados)
            {
                writer.WriteLine(resultado.idJugador);
                writer.WriteLine(resultado.fecha);
                writer.WriteLine(resultado.equipo);
                writer.WriteLine(resultado.goles);
            }
            
            writer.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Resultado resultado = new Resultado();

            resultado.idJugador = Convert.ToInt16(DropDownList1.SelectedValue);
            resultado.fecha = Calendar1.SelectedDate;
            resultado.equipo = TextBox1.Text;
            resultado.goles = Convert.ToInt16(TextBox2.Text);

            resultados.Add(resultado);

            Guardar();
        }
    }
}