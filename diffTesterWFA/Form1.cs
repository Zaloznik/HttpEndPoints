using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diffTesterWFA
{
    public partial class Form1 : Form
    {
        private HttpClient httpClient;
        Guid clientID;
        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
            clientID = Guid.NewGuid();
        }

        private async void setLeftButton_Click(object sender, EventArgs e)
        {
            string setLeftDataStr = setLeftTextBox.Text;

            byte[] bytesToEncode = System.Text.Encoding.UTF8.GetBytes(setLeftDataStr);
            string base64String = Convert.ToBase64String(bytesToEncode);
            StringContent leftContent = new StringContent($"\"{base64String}\"", Encoding.UTF8, "application/json");

            var leftResponse = await httpClient.PostAsync("/v1/diff/" + clientID + "/left", leftContent);
            int statusCode = (int)leftResponse.StatusCode;
            string message = string.Empty;
            switch (statusCode)
            {
                case 200:
                    message = "OK";
                    break;
                case 201:
                    message = "Created";
                    break;
                case 404:
                    message = "Not Found";
                    break;
                case 400:
                    message = "Bad Request";
                    break;
            }
            MessageBox.Show(statusCode + " " + message);
        }

        private async void setRightButton_Click(object sender, EventArgs e)
        {
            string setRightDataStr = setRightTextBox.Text;

            byte[] bytesToEncode = System.Text.Encoding.UTF8.GetBytes(setRightDataStr);
            string base64String = Convert.ToBase64String(bytesToEncode);
            StringContent rightContent = new StringContent($"\"{base64String}\"", Encoding.UTF8, "application/json");

            var rightResponse = await httpClient.PostAsync("/v1/diff/" + clientID + "/right", rightContent);

            int statusCode = (int)rightResponse.StatusCode;
            string message = string.Empty;
            switch (statusCode)
            {
                case 200:
                    message = "OK";
                    break;
                case 201:
                    message = "Created";
                    break;
                case 404:
                    message = "Not Found";
                    break;
                case 400:
                    message = "Bad Request";
                    break;
            }
            MessageBox.Show(statusCode + " " + message);
        }

        private async void getButton_Click(object sender, EventArgs e)
        {
            var diffResponse = await httpClient.GetAsync("/v1/diff/" + clientID);
            string responseContent = await diffResponse.Content.ReadAsStringAsync();

            int statusCode = (int)diffResponse.StatusCode;
            string message = string.Empty;
            switch (statusCode)
            {
                case 200:
                    message = "OK";
                    break;
                case 201:
                    message = "Created";
                    break;
                case 404:
                    message = "Not Found";
                    break;
                case 400:
                    message = "Bad Request";
                    break;
            }
            MessageBox.Show(statusCode + " " + message + "\n" + responseContent);
        }
    }
}
