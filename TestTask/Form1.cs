namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Data data = new Data();

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int n) && Int32.Parse(textBox3.Text) >= 0)
            {
                data.NewPayment(textBox2.Text, n);
                string[] personArray = data.GetPersonArray();
                listBox1.Items.Clear();
                for (int i = 0; i < data.GetLength(); i++)
                {
                    listBox1.Items.Add(i + 1 + ".  " + personArray[i]);
                }
            }
            else
            {
                MessageBox.Show("«начение размера платежа должно быть целым, не отрицательным числом");
            }
            textBox2.ResetText();
            textBox3.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int n) && Int32.Parse(textBox5.Text) >= 0)
            {
                data.NewPurchase(textBox1.Text, n);
                string[] personArray = data.GetPersonArray();
                listBox1.Items.Clear();
                for (int i = 0; i < data.GetLength(); i++)
                {
                    listBox1.Items.Add(i + 1 + ".  " + personArray[i]);
                }
            }
            else
            {
                MessageBox.Show("«начение цены покупки должно быть целым, не отрицательным числом");
            }
            textBox1.ResetText();
            textBox5.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int n) && Int32.Parse(textBox6.Text) >= 0)
            {
                data.AddNewPerson(textBox4.Text, n);
                string[] personArray = data.GetPersonArray();
                listBox1.Items.Clear();
                for (int i = 0; i < data.GetLength(); i++)
                {
                    listBox1.Items.Add(i + 1 + ".  " + personArray[i]);
                }
            }
            else
            {
                MessageBox.Show("«начение баланса должно быть целым, не отрицательным числом");
            }
            textBox4.ResetText();
            textBox6.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data.DeletePerson(textBox7.Text);
            string[] personArray = data.GetPersonArray();
            listBox1.Items.Clear();
            for (int i = 0; i < data.GetLength(); i++)
            {
                listBox1.Items.Add(i + 1 + ".  " + personArray[i]);
            }
            textBox7.ResetText();
        }
    }
}