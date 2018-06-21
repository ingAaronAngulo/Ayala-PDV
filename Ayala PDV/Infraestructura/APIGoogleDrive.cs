//Código creado por Aarón Angulo

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
using Google.Apis.Services;
using System.Windows.Forms;

namespace Ayala_PDV.Infraestructura
{
    class APIGoogleDrive
    {
        private DriveService service;
        private static APIGoogleDrive instance;

        private string idCliente = ""; //Incluir id de cliente
        private string secretoCliente = ""; //Incluir secreto de cliente

        public APIGoogleDrive()
        {

        }

        public static APIGoogleDrive Instance
        {
            get
            {
                if (instance == null)
                    instance = new APIGoogleDrive();
                return instance;
            }
        }

        public void Autentificar()
        {
            UserCredential credential;
            try
            {

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                          new ClientSecrets { ClientId = idCliente, ClientSecret = secretoCliente },
                          new[] { DriveService.Scope.Drive,
                          DriveService.Scope.DriveFile },
                          "user",
                          CancellationToken.None,
                          new FileDataStore("AyalaPDV")).Result;

                service = new DriveService(new DriveService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Ayala PDV",
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se puede utilizar éste servicio si no acepta las condiciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Permission InsertPermission(string fileId, string type, string role)
        {
            Permission newPermission = new Permission();
            newPermission.Type = type;
            newPermission.Role = role;
            try
            {
                return service.Permissions.Insert(newPermission, fileId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return null;
        }

        public File CrearCarpeta(string _title, string _description, string _parent)
        {
            File carpeta = null;
            
            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
            try
            {
                FilesResource.InsertRequest request = service.Files.Insert(body);
                carpeta = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            
            return carpeta;
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        
        public File SubirArchivo(string _uploadFile, string _parent)
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                File body = new File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "Base de datos para el sistema Ayala PDV";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + _uploadFile);
                return null;
            }

        }

        public File ActualizarArchivo(string _uploadFile, string _parent, string _fileId)
        {

            if (System.IO.File.Exists(_uploadFile))
            {
                File body = new File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "Base de datos para el sistema Ayala PDV";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.UpdateMediaUpload request = service.Files.Update(body, _fileId, stream, GetMimeType(_uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("File does not exist: " + _uploadFile);
                return null;
            }

        }


        public Boolean downloadFile(File _fileResource, string _saveTo)
        {

            if (!String.IsNullOrEmpty(_fileResource.DownloadUrl))
                try
                {
                    var x = service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl);
                    byte[] arrBytes = x.Result;
                    System.IO.File.WriteAllBytes(_saveTo, arrBytes);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return false;
                }
            else
                return false;
        }

        public List<File> GetFiles(string search)
        {
            List<File> Files = new List<File>();

            try
            {
                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;
                if (search != null)
                {
                    list.Q = "'" + search + "' in parents and trashed = false";
                }
                FileList filesFeed = list.Execute();

                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }

                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;

                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex)
            {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);
            }
            return Files;
        }
    }
}
