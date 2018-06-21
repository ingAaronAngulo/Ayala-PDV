using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Drive.v2.Data;
using System.Collections;
using Ayala_PDV.Infraestructura;

namespace Ayala_PDV.Negocios
{
    class ControlSincronizacion
    {
        public ControlSincronizacion()
        {

        }

        public void InicializarAPI()
        {
            APIGoogleDrive.Instance.Autentificar();
        }

        public void SubirBDD()
        {
            if (getCarpetaID() == null)
                APIGoogleDrive.Instance.CrearCarpeta("AyalaPDV", "Almacenamiento de base de datos de Ayala PDV", "root");

            string id = getCarpetaID();

            if (getArchivoID(id) == null)
                APIGoogleDrive.Instance.SubirArchivo(ConexionSQL.Instance.BDDDrive(), id);
            else
                APIGoogleDrive.Instance.ActualizarArchivo(ConexionSQL.Instance.BDDDrive(), id, getArchivoID(id));
            Console.WriteLine("Done");
            APIGoogleDrive.Instance.InsertPermission(getArchivoID(id), "anyone", "reader");
        }

        public string getCarpetaID()
        {
            List<File> files = APIGoogleDrive.Instance.GetFiles("root");
            for (int i = 0; i < files.Count; i++)
                if (files[i].Title == "AyalaPDV")
                    return files[i].Id;

            return null;
        }

        public string getArchivoID(string parent)
        {
            List<File> files = APIGoogleDrive.Instance.GetFiles(parent);
            for (int i = 0; i < files.Count; i++)
                if (files[i].Title == "AyalaBDDMovil.db")
                    return files[i].Id;

            return null;
        }
    }
}
