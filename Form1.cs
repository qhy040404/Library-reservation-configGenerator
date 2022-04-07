using TaskScheduler;

namespace ConfigGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 1;
        bool first_time = false;
        string area;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("��ϣ");
            comboBox1.Items.Add("����");
            comboBox2.Items.Add("����ѡ��ͼ���");
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.Text == "��ϣ")
            {
                comboBox2.Items.Add("301");
                comboBox2.Items.Add("302");
                comboBox2.Items.Add("401");
                comboBox2.Items.Add("402");
                comboBox2.Items.Add("501");
                comboBox2.Items.Add("502");
                comboBox2.Items.Add("601");
                comboBox2.Items.Add("602");
                area = "LX";
            }
            else if (comboBox1.Text == "����")
            {
                comboBox2.Items.Add("301");
                comboBox2.Items.Add("312");
                comboBox2.Items.Add("401");
                comboBox2.Items.Add("404");
                comboBox2.Items.Add("409");
                comboBox2.Items.Add("501");
                comboBox2.Items.Add("504");
                comboBox2.Items.Add("507");
                area = "BC";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                linkLabel1.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                linkLabel1.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 9 || textBox1.TextLength == 11)
            {
                if (GenerateFile.DataAlreadyExists() == true && (!checkBox2.Checked || first_time == false))
                {
                    MessageBoxButtons ConfirmCover = MessageBoxButtons.YesNo;
                    DialogResult dr = MessageBox.Show("��⵽�Ѵ��ڵ����ݣ��Ƿ񸲸ǣ�", "����", ConfirmCover);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
                if (!checkBox2.Checked)
                {
                    GenerateFile.WriteBasicDataFirst(this.textBox1.Text, this.textBox2.Text, area, this.comboBox2.Text);
                    GenerateFile.WriteSeatsData(this.textBox5.Text);
                    if (checkBox1.Checked)
                    {
                        GenerateFile.WriteMailData(this.textBox3.Text, this.textBox4.Text);
                    }
                    label14.Visible = true;
                }
                else
                {
                    if (first_time == false)
                    {
                        GenerateFile.WriteBasicDataFirst(this.textBox1.Text, this.textBox2.Text, area, this.comboBox2.Text);
                        GenerateFile.WriteSeatsData(this.textBox5.Text);
                        if (checkBox1.Checked)
                        {
                            GenerateFile.WriteMailData(this.textBox3.Text, this.textBox4.Text);
                        }
                        first_time = true;
                    }
                    else
                    {
                        GenerateFile.WriteBasicData(this.textBox1.Text, this.textBox2.Text, area, this.comboBox2.Text, count);
                        GenerateFile.WriteSeatsData(this.textBox5.Text);
                        if (checkBox1.Checked)
                        {
                            GenerateFile.WriteMailData(this.textBox3.Text, this.textBox4.Text);
                        }
                    }
                    listBox1.Items.Add("# " + count + "    " + textBox1.Text);
                    count++;
                    label12.Text = "# " + count;
                    label12.Update();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox2.Items.Clear();
                    comboBox2.SelectedIndex = -1;
                    checkBox1.Checked = false;
                }
            }
            else if (textBox2.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox5.Text == "")
            {
                MessageBox.Show("��Ҫ��Ϊ��", "����");
            }
            else
            {
                MessageBox.Show("ѧ�ų��ȴ���", "����");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label12.Visible = true;
                label12.Text = "# " + count;
                label13.Visible = true;
                listBox1.Visible = true;
                listBox1.Items.Add("���   ѧ��");
            }
            else
            {
                label12.Visible = false;
                label13.Visible = false;
                listBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //������
            var creator = "Library";
            //�ƻ���������
            var taskName = "Library";
            //ִ�еĳ���·��
            var CurrentPath = System.Windows.Forms.Application.StartupPath;
            var path = CurrentPath + "main.exe";
            //�ƻ�����ִ�е�Ƶ�� PT1Mһ����  PT1H30M 90����
            var interval = "PT24H";
            //��ʼʱ�� ����ѭ yyyy-MM-ddTHH:mm:ss ��ʽ
            DateTime dt = DateTime.Now;
            dt.AddDays(1);
            string day = dt.ToString("yyyy-MM-dd");
            var startBoundary = day + "T06:30:02";
            var description = "Automatic reserve library.";
            _TASK_STATE state = SchTaskExt.CreateTaskScheduler(creator, taskName, path, CurrentPath, interval, startBoundary, description);
            if (state == _TASK_STATE.TASK_STATE_READY)
            {
                MessageBox.Show("�ƻ�������ɹ�!", "��ʾ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var taskName = "Library";
            if (!SchTaskExt.IsExists(taskName))
            {
                MessageBox.Show("�ƻ����񲻴���", "����");
                return;
            }
            else
            {
                SchTaskExt.DeleteTask(taskName);
            }
            //Confirm
            if (!SchTaskExt.IsExists(taskName))
            {
                MessageBox.Show("�ƻ�����ɾ���ɹ�", "��ʾ");
            }
        }
    }
}