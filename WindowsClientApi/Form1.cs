using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClientApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            Uri baseaddress = new Uri("https://localhost:44311/");
            HttpResponseMessage response = await client.GetAsync("https://localhost:44311/api/example");
            string result = await response.Content.ReadAsStringAsync();
            label1.Text = result;
        }
    }
}
