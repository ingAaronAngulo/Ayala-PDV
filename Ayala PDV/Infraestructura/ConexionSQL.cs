//Código creado por Aarón Angulousing System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Ayala_PDV.Negocios
{
    class ConexionSQL
    {
        private SQLiteConnection conexion;
        private string path;
        private bool conectada;

        private static ConexionSQL instance;
        private ConexionSQL()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/AyalaPDV/AyalaBDD.db";
            Console.WriteLine(path);
        }

        public bool ConectarBDD()
        {
            conexion = new SQLiteConnection("Data Source=" + path);
            if (!File.Exists(path))
            {
                InsertQuery("CREATE TABLE Productos ( `idProducto` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `nombre` varchar(50), `distribuidor` varchar(50), `existencia` int, `codigo` varchar(50), `precio` double, `origen` varchar(50), `existenciaMinima` int, `activado` int )");
                InsertQuery("CREATE TABLE Ventas ( `idVenta` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `fecha` TEXT, `monto` double, `concretada` int )");
                InsertQuery("CREATE TABLE DetalleVentas( `idDetalleVentas` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `idVenta` INTEGER NOT NULL, `idProducto` INTEGER NOT NULL, `cantidad` INTEGER, `precio` double)");
            }
            else
            {
                try
                {
                    conexion.Open();
                    conexion.Close();
                    conectada = true;
                }
                catch (Exception e)
                {
                    conectada = false;
                    Console.WriteLine(e.StackTrace);
                }
            }

            return conectada;
        }

        public string BDDDrive()
        {
            string pathTemporal = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/AyalaPDV/AyalaBDDMovil.db";
            SQLiteConnection conexionTemporal = new SQLiteConnection("Data Source=" + pathTemporal); ;
            
            File.Delete(pathTemporal);
            File.Copy(path, pathTemporal);
            
            SQLiteCommand cmd;
            conexionTemporal.Open();
            cmd = conexionTemporal.CreateCommand();
            cmd.CommandText = "DROP TABLE Ventas";
            cmd.ExecuteScalar();
            cmd.CommandText = "DROP TABLE DetalleVentas";
            cmd.ExecuteScalar();

            cmd.Dispose();
            conexionTemporal.Close();
            
            return pathTemporal;
        }
        public DataTable SelectQuery(String query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                conexion.Open();
                cmd = conexion.CreateCommand();
                cmd.CommandText = query;
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); 
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error en SelectQuery: " + ex.Message);
            }

            conexion.Close();
            return dt;
        }

        public bool InsertQuery(String query)
        {
            bool exito = true;

            try
            {
                SQLiteCommand cmd;
                conexion.Open();
                cmd = conexion.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteScalar();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error en InsertQuery: " + ex.Message);
                exito = false;
            }

            conexion.Close();

            return exito;
        }

        public static ConexionSQL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConexionSQL();
                return instance;
            }
        }

        public bool getConectada()
        {
            return conectada;
        }

        public string getPath()
        {
            return path;
        }
    }
}
