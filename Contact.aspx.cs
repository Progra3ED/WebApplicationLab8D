using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationLab8D
{
    public partial class Contact : Page
    {
        static List<Jugador> jugadores = new List<Jugador>();
        static List<Resultado> resultados = new List<Resultado>();
        static List<Reporte> reportes = new List<Reporte>();
        public void LeerJugador()
        {
            string fileName = Server.MapPath("~/Archivos/Jugadores.txt");


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Jugador jugador = new Jugador();
                jugador.id = Convert.ToInt32(reader.ReadLine());
                jugador.nombre = reader.ReadLine();
                jugador.equipo = reader.ReadLine();

                jugadores.Add(jugador);
            }

            reader.Close();
        }

        public void LeerResultado()
        {
            string fileName = Server.MapPath("~/Archivos/Resultados.txt");


            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
                Resultado resultado = new Resultado();
                resultado.idJugador = Convert.ToInt32(reader.ReadLine());
                resultado.fecha = Convert.ToDateTime(reader.ReadLine());
                resultado.equipo = reader.ReadLine();
                resultado.goles = Convert.ToInt32(reader.ReadLine());

                resultados.Add(resultado);

            }

            reader.Close();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LeerJugador();
            LeerResultado();

            for (int i = 0; i < resultados.Count; i++)
            {
                for (int j = 0; j < jugadores.Count; j++)
                {
                    if (resultados[i].idJugador == jugadores[j].id)
                    {
                        Reporte reporte = new Reporte();
                        reporte.nombre = jugadores[j].nombre;
                        reporte.goles = resultados[i].goles;

                        reportes.Add(reporte);
                    }
                }
            }
            reportes = reportes.OrderBy(g => g.goles).ToList();

            GridView1.DataSource = reportes;
            GridView1.DataBind();   

            double promedio = reportes.Average(g => g.goles);

            Label1.Text = promedio.ToString();

            

        }
    }
}