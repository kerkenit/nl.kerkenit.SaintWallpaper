using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Text;  // For class Encoding
using System.IO;    // For StreamReader
using System.Diagnostics;
using Newtonsoft.Json;

namespace kerkenit
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        private string jsonFolder = string.Empty;
        private string jsonPath = string.Empty;
        private FileInfo imageName = null;

        public Form1()
        {
            InitializeComponent();
        }

        public class JsonData
        {
            public int taal { get; set; }
        }

        public class Saint
        {
            public DateTime datum { get; set; }
            public int id { get; set; }
            public string image_url { get; set; }
            public string imagename { get; set; }
            public string key { get; set; }
            public string naam { get; set; }
            public int trackid { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jsonFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + Application.ProductName;
            DirectoryInfo directoryInfo = new DirectoryInfo(jsonFolder);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            jsonPath = jsonFolder + "/calendar.json";
            FileInfo fileInfo = new FileInfo(jsonPath);
            if (!fileInfo.Exists || fileInfo.LastWriteTime < DateTime.Today.AddMonths(-1))
            {
                //File.WriteAllText(fileInfo.FullName, JsonConvert.SerializeObject(new JsonData() { taal = 1 }));
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                // Create a request for the URL. 		
                WebRequest request = WebRequest.Create("https://api.luistertnaarhem.nl/?mode=heiligeKalender");
                request.Method = "POST";
                // If required by the server, set the credentials.
                request.ContentType = "application/json";


                using (Stream stm = request.GetRequestStream())
                {
                    using (StreamWriter sw = new StreamWriter(stm))
                    {
                        sw.Write(JsonConvert.SerializeObject(new JsonData() { taal = 1 }));
                    }
                }


                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Display the status.
                Console.WriteLine(response.StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();


                File.WriteAllText(fileInfo.FullName, responseFromServer);

                //Process.Start("notepad.exe", fileInfo.FullName);
            }

            if (File.Exists(fileInfo.FullName))
            {
                Saint lastSaint = null;
                List<Saint> saints = JsonConvert.DeserializeObject<List<Saint>>(File.ReadAllText(fileInfo.FullName));

                foreach (Saint saint in saints)
                {
                    if (!string.IsNullOrEmpty(saint.image_url))
                    {
                        DateTime date = new DateTime(DateTime.Today.Year, saint.datum.Month, saint.datum.Day);
                        if (date <= DateTime.Today)
                        {
                            lastSaint = saint;
                        }
                    }
                }
                if (lastSaint != null)
                {
                    imageName = new FileInfo(jsonFolder + "\\" + lastSaint.imagename);
                    if (!imageName.Exists)
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(lastSaint.image_url, imageName.FullName);
                    }
                }
            }

            txtPictureFile.Text = imageName.FullName;
            DisplayPicture(txtPictureFile.Text, chkUpdateRegistry.Checked);
            Application.Exit();
        }

        // Set the desktop picture.
        private void btnSetDesktop_Click(object sender, EventArgs e)
        {
            DisplayPicture(txtPictureFile.Text, chkUpdateRegistry.Checked);
        }

        // Display the file on the desktop.
        private void DisplayPicture(string file_name, bool update_registry)
        {
            try
            {
                // If we should update the registry,
                // set the appropriate flags.
                uint flags = 0;
                if (update_registry)
                    flags = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;

                // Set the desktop background to this file.
                if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0, file_name, flags))
                {
                    MessageBox.Show("SystemParametersInfo failed.",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying picture " +
                    file_name + ".\n" + ex.Message,
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        // Let the user browse for a file.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                txtPictureFile.Text = ofdImage.FileName;
            }
        }
    }
}
