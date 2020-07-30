using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manifiesto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

        public static void Manifiesto(int solicitud, string dbf, string[][] data)
        {
            string barra = "C5851312"; //data["info_shi"]["shi_id"] + data["info_shi"]["producto"]+ data["info_shi"]["ciclo"].Substring(0,2) + data["info_shi"]["ciclo"].Substring(3, 2);
            string descripcion = "150108"; //data["info_shi"]["ord_descri"];
            string zona, impresion, archivo,adicional1,adicional2;
            string distr,prov,dep;
            string[,] linea;
            string[] agencias = { "001", "005", "111", "112", "113", "114", "115" };
            string[] arraydbf = {  };
            string[] fecha_inicial = { };
            
            int total_registros = 10;//Total de Registros en el dbf

            string shipper_final = "C5"; //data["info_shi"]["shi_codigo"];
            string[] fecha_inicial_lima = {"01/07/2020","02/07/2020","03/07/2020","04/07/2020","05/07/2020"};//[verfecha($listado_fechas->lima->fec1), verfecha($listado_fechas->lima->fec2), verfecha($listado_fechas->lima->fec3), verfecha($listado_fechas->lima->fec4), verfecha($listado_fechas->lima->fec5), verfecha($listado_fechas->lima->fec6)];
            string[] fecha_inicial_prov = {"08/07/2020", "09/07/2020", "10/07/2020", "11/07/2020", "12/07/2020" };//[verfecha($listado_fechas->provincia->fec1), verfecha($listado_fechas->provincia->fec2), verfecha($listado_fechas->provincia->fec3), verfecha($listado_fechas->provincia->fec4), verfecha($listado_fechas->provincia->fec5), verfecha($listado_fechas->provincia->fec6)];
            string puerta = "SI"; //data["info_shi"]["bajo_puerta"];


            for (int i = 0; i < total_registros; i++)
            {
                arraydbf = datadbf(dbf); //"CLI_CODIGO" + "C58513121723851312000001" + "CLI_NOMBRE" + "CLI_DIREC1" + "CLI_DIREC2" + "CLI_DISTRI" + "CLI_PROVIN" + "CLI_DEPART" + "150108" + "AR" + "001" + "CLI_NOMAGE" + "23CR06A-004" + "-77.01180028909" + "-12.19582834103" + "1" + "1" + "" + "" + "CLI_NOVAR" + "CLI_NOEMP" + "CLI_CARGO" + "089" + "CLI_NROGUI" + "CLI_NRODOC" + "SOCIEDAD ANONIMA PAPELSA // 851312000001" + "CLI_FLGVAR" + "CLI_GUIREM" + "5004" + "85" + "13/12/2019" + "ARCHIVO" + "ADICIONAL1" + "ADICIONAL2" + "ESTADO" + "" + "1919" + "" + "31723";

                string agencia_lima = arraydbf[10]; 
                string chk_codigo = arraydbf[9] ;
                string cli_nrogui = arraydbf[23] ;
                string marcas = arraydbf[22];
                string barra_total = arraydbf[1] ;
                string zon_codigo = arraydbf[12];


                if (agencias.Contains(agencia_lima))
                {
                    fecha_inicial = fecha_inicial_lima;
                }
                else
                {
                    fecha_inicial = fecha_inicial_prov;
                }

                if (chk_codigo == "AR"){zona = "AS"; }else {zona = chk_codigo; }

                distr = arraydbf[5];
                prov = arraydbf[6];
                dep = arraydbf[7];

                if (arraydbf[31] != null) { archivo = arraydbf[31]; } else { archivo=""; };
                if (arraydbf[32] != null) { adicional1 = arraydbf[31]; } else { adicional1 = ""; };
                if (arraydbf[33] != null) { adicional2 = arraydbf[31] ; } else { adicional2 = ""; };

                impresion = archivo + adicional1 + adicional2;

                linea = new string[total_registros, 16];

                linea[i, 0] = shipper_final;
                linea[i, 1] = arraydbf[2];
                linea[i, 2] = arraydbf[3]+"-"+ arraydbf[4];
                linea[i, 3] = distr+prov+dep;
                linea[i, 4] = arraydbf[25] + " " + arraydbf[27]+" "+ impresion;
                linea[i, 5] = ""; //array de fechas fecha_inicial
                linea[i, 6] = barra_total;
                linea[i, 7] = arraydbf[16];
                linea[i, 8] = arraydbf[16] + " " + arraydbf[15];
                linea[i, 9] = "";
                linea[i, 10] = chk_codigo + " " + arraydbf[10] + " " + zon_codigo + " " + marcas;
                linea[i, 11] = arraydbf[21] + " " + arraydbf[11];
                linea[i, 12] = cli_nrogui;
                linea[i, 13] = descripcion;
                linea[i, 14] = arraydbf[24];
                linea[i, 15] = adicional1;
                linea[i, 16] = marcas;









            }


        }
        public static string[] datadbf(string name) {

            string[] data = { "CLI_CODIGO", "C58513121723851312000001", "CLI_NOMBRE", "CLI_DIREC1", "CLI_DIREC2", "CLI_DISTRI", "CLI_PROVIN", "CLI_DEPART", "150108", "AR", "001", "CLI_NOMAGE", "23CR06A-004", "-77.01180028909", "-12.19582834103", "1", "1", "", "", "CLI_NOVAR", "CLI_NOEMP", "CLI_CARGO", "089", "CLI_NROGUI", "CLI_NRODOC", "SOCIEDAD ANONIMA PAPELSA // 851312000001", "CLI_FLGVAR", "CLI_GUIREM", "5004", "85", "13/12/2019", "ARCHIVO", "ADICIONAL1", "ADICIONAL2", "ESTADO", "", "1919", "", "31723" };
            return data; }
    }
}