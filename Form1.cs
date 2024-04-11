using System.Drawing.Drawing2D;
using Xml2CSharp;
namespace Homework_Weather_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiKey = "21f7d65ecffdc917dd2ac6cc6784c8e5";
            string city = textBox1.Text;

            HttpClient client = new HttpClient();
            string uri = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&mode=xml&units=metric";
            string data = await client.GetStringAsync(uri);

            Serializer serializer = new Serializer();
            Current current = serializer.Deserialize<Current>(data);

            string icon = current.Weather.Icon;
            string uriIcon = $"https://openweathermap.org/img/wn/{icon}@2x.png";
            byte[] iconData = await client.GetByteArrayAsync(uriIcon);

            using (var stream = new MemoryStream(iconData))
            {
                Bitmap bitmap = new Bitmap(stream);
                pictureBox1.Image = bitmap;
            }
            label16.Text = current.City.Country;
            label17.Text = current.City.Sun.Rise;
            label18.Text = current.City.Sun.Set;
            label19.Text = current.Temperature.Value+ " ∞C";
            label20.Text = current.Temperature.Min+" ∞C";
            label21.Text = current.Temperature.Max+ " ∞C";
            label22.Text = current.Feels_like.Value+ " ∞C";
            label23.Text = current.Humidity.Value + " %";
            label24.Text = current.Pressure.Value +" Ï≥Î≥·‡";
            label25.Text = current.Wind.Gusts.Value;
            label26.Text = current.Wind.Speed.Value+" ÍÏ/„Ó‰";
            label27.Text = current.Visibility.Value;
            label28.Text = current.Precipitation.Mode;
            label29.Text = current.Lastupdate.Value;
        }
    }
}
