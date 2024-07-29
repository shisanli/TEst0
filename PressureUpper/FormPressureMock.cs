using NPOI.OpenXmlFormats.Dml.Chart;
using NPOI.Util.ArrayExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressureUpper
{
    public partial class FormPressureMock : Form
    {
        public static bool Mocking = false;
        public static float[] PressureMock = new float[66];
        private TextBox[] textBoxes;
        private bool autoChanging = false;
        private bool dynamic = false;

        public FormPressureMock()
        {
            InitializeComponent();
            textBoxMax.Text = "10000";
            textBoxes = new TextBox[30] {
             textBox1,
            textBox2,
            textBox3,
            textBox4,
            textBox8,
            textBox7,
            textBox6,
            textBox5,
            textBox9,
            textBox14,
            textBox13,
            textBox12,
            textBox11,
            textBox10,
            textBox15,
            textBox30,
            textBox29,
            textBox28,
            textBox27,
            textBox26,
            textBox25,
            textBox24,
            textBox23,
            textBox22,
            textBox21,
            textBox20,
            textBox19,
            textBox18,
            textBox17,
            textBox16,
            };
            foreach (var item in textBoxes)
            {
                item.Text = "9000";
                item.TextChanged += textBox_TextChanged;
            }
        }

        private void buttonMock_Click(object sender, EventArgs e)
        {
            refreshPressure();
            Mocking = true;
        }

        private void buttonUnmock_Click(object sender, EventArgs e)
        {
            Mocking = false;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            refreshPressure();
        }

        private void refreshPressure()
        {
            if (autoChanging)
            {
                return;
            }
            PressureMock[6] = getFloat(textBox1.Text);
            PressureMock[7] = getFloat(textBox2.Text);
            PressureMock[8] = getFloat(textBox3.Text);
            PressureMock[9] = getFloat(textBox4.Text);

            PressureMock[12] = getFloat(textBox5.Text);
            PressureMock[13] = getFloat(textBox6.Text);
            PressureMock[14] = getFloat(textBox7.Text);
            PressureMock[15] = getFloat(textBox8.Text);
            PressureMock[16] = getFloat(textBox9.Text);

            PressureMock[19] = getFloat(textBox10.Text);
            PressureMock[20] = getFloat(textBox11.Text);
            PressureMock[21] = getFloat(textBox12.Text);
            PressureMock[22] = getFloat(textBox13.Text);
            PressureMock[23] = getFloat(textBox14.Text);
            PressureMock[24] = getFloat(textBox15.Text);


            PressureMock[39] = getFloat(textBox16.Text);
            PressureMock[40] = getFloat(textBox17.Text);
            PressureMock[41] = getFloat(textBox18.Text);
            PressureMock[42] = getFloat(textBox19.Text);

            PressureMock[45] = getFloat(textBox20.Text);
            PressureMock[46] = getFloat(textBox21.Text);
            PressureMock[47] = getFloat(textBox22.Text);
            PressureMock[48] = getFloat(textBox23.Text);
            PressureMock[49] = getFloat(textBox24.Text);

            PressureMock[52] = getFloat(textBox25.Text);
            PressureMock[53] = getFloat(textBox26.Text);
            PressureMock[54] = getFloat(textBox27.Text);
            PressureMock[55] = getFloat(textBox28.Text);
            PressureMock[56] = getFloat(textBox29.Text);
            PressureMock[57] = getFloat(textBox30.Text);
        }

        private float getFloat(string text)
        {
            try
            {
                return float.Parse(text);
            }
            catch (Exception)
            {
                return 0f;
            }
        }
        private int getInt(string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            autoChanging = true;
            int max = getInt(textBoxMax.Text);
            max = max <= 0 ? 10000 : max;
            Random random = new Random((int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
            foreach (var item in textBoxes)
            {
                item.Text = Convert.ToString(random.Next(max));
            }
            autoChanging = false;
            refreshPressure();
        }

        private void timerDynamic_Tick(object sender, EventArgs e)
        {
            if (!dynamic)
            {
                return;
            }
            autoChanging = true;
            int max = getInt(textBoxMax.Text);
            max = max <= 0 ? 10000 : max;
            Random random = new Random((int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
            foreach (var item in textBoxes)
            {
                int val = getInt(item.Text);
                val += random.Next(max/10 + 1) - max/20;
                val = val > max ? max : val;
                val = val < 0 ? 0 : val;
                item.Text = Convert.ToString(val);
            }
            autoChanging = false;
            refreshPressure();
        }

        private void buttonDynamic_Click(object sender, EventArgs e)
        {
            dynamic = !dynamic;
            if (dynamic)
            {
                buttonDynamic.Text = "stop dynamic";
            }
            else
            {
                buttonDynamic.Text = "start dynamic";
            }
        }
    }
}
