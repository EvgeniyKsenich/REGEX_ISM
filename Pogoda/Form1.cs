using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pogoda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string site = client.DownloadString("https://www.gismeteo.ua/weather-zhytomyr-4943/");
            Regex temperature = new Regex(@"<dd class='value m_temp c'>((?:\+|-)?\d+)");
            Regex vindSp = new Regex(@"<dd class='value m_wind ms' style='display:inline'>(\d+)");
            Regex preas = new Regex(@"<dd class='value m_press torr'>(\d+)");
            Regex vilig = new Regex(@"<div class=.+ title=.+>(\d+)");
            Regex tw = new Regex(@"<div class=.wicon water. title=.+>\n\t\t<dd class=.value m_temp c[""]>((?:\+|-)?\d+)");

            Match tmp = temperature.Match(site);
            label_temp.Text = tmp.Groups[1].Value;

            tmp = vindSp.Match(site);
            label_w_sp.Text = tmp.Groups[1].Value +"м\\с";

            tmp = preas.Match(site);
            label_prea.Text = tmp.Groups[1].Value;

            tmp = vilig.Match(site);
            label_volog.Text = tmp.Groups[1].Value;

            tmp = tw.Match(site);
            label_temp_water.Text = tmp.Groups[1].Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string site = client.DownloadString("http://finance.i.ua/");
            Regex dolar = new Regex(@"<td class=.align_left.><b>USD<\/b><\/td>\n\t\t\t\t\t<td>\n\t\t\t\t<big>(\d+\.?\d+)");
            Regex euro = new Regex(@"<td class=.align_left.><b>EUR<\/b><\/td>\n\t\t\t\t\t<td>\n\t\t\t\t<big>(\d+\.?\d+)");
            Regex rub = new Regex(@"<td class=.align_left.><b>RUB<\/b><\/td>\n\t\t\t\t\t<td>\n\t\t\t\t<big>(\d+\.?\d+)");

            Regex dolar1 = new Regex(@"<td class=.align_left.><b>USD<\/b><\/td>\s+<td>\s+<big>(\d+\.?\d+)<\/big><i class=.decrease.><\/i><br \/><span class=.report.>.+<\/span><\/td>\s+<td>\s+<big>(\d+\.?\d+)");
            Regex euro1 = new Regex(@"<td class=.align_left.><b>EUR<\/b><\/td>\s+<td>\s+<big>(\d+\.?\d+)<\/big><i class=.decrease.><\/i><br \/><span class=.report.>.+<\/span><\/td>\s+<td>\s+<big>(\d+\.?\d+)");
            Regex rub1 = new Regex(@"<td class=.align_left.><b>RUB<\/b><\/td>\s+<td>\s+<big>(\d+\.?\d+)<\/big><i class=.decrease.><\/i><br \/><span class=.report.>.+<\/span><\/td>\s+<td>\s+<big>(\d+\.?\d+)");

            Match tmp = dolar.Match(site);
            label3.Text = tmp.Groups[1].Value;

            tmp = euro.Match(site);
            label9.Text = tmp.Groups[1].Value;

            tmp = rub.Match(site);
            label10.Text = tmp.Groups[1].Value;


            tmp = dolar1.Match(site);
            label16.Text = tmp.Groups[2].Value;

            tmp = euro1.Match(site);
            label15.Text = tmp.Groups[2].Value;

            tmp = rub1.Match(site);
            label14.Text = tmp.Groups[2].Value;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
