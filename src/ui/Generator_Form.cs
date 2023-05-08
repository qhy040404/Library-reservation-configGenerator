using ConfigGenerator.src.constants;
using ConfigGenerator.src.utils;
using TaskScheduler;

namespace ConfigGenerator
{
    public partial class Generator_Form : Form
    {
        public Generator_Form()
        {
            InitializeComponent();
            area_comboBox.Items.AddRange(Constants.libraries.Keys.ToArray());
        }

        int user_count = 1;

        private void area_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (area_comboBox.SelectedIndex == -1) return;
            room_comboBox.Items.Clear();
            room_comboBox.Items.AddRange(Constants.libraries[area_comboBox.Text]);
        }

        private void mail_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mail_checkBox.Checked)
            {
                mail_user_label.Visible = true;
                mail_pass_label.Visible = true;
                mail_pass_prompt.Visible = true;
                mail_link.Visible = true;
                mail_user_textBox.Visible = true;
                mail_pass_textBox.Visible = true;
            }
            else
            {
                mail_user_label.Visible = false;
                mail_pass_label.Visible = false;
                mail_pass_prompt.Visible = false;
                mail_link.Visible = false;
                mail_user_textBox.Visible = false;
                mail_pass_textBox.Visible = false;
            }
        }
        private void generate_button_Click(object sender, EventArgs e)
        {
            if (id_textBox.TextLength == 9 || id_textBox.TextLength == 11)
            {
                if (GenerateFile.DataAlreadyExists() && user_count == 1)
                {
                    MessageBoxButtons ConfirmCover = MessageBoxButtons.YesNo;
                    DialogResult dr = MessageBox.Show("检测到已存在的数据，是否覆盖？", "警告", ConfirmCover);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
                GenerateFile.WriteBasicData(id_textBox.Text, pass_textBox.Text, Constants.areas[area_comboBox.Text], room_comboBox.Text, user_count);
                GenerateFile.WriteSeatsData(target_textBox.Text);
                if (mail_checkBox.Checked)
                {
                    GenerateFile.WriteMailData(mail_user_textBox.Text, mail_pass_textBox.Text);
                }
                if (!multiple_checkBox.Checked)
                {
                    MessageBox.Show("生成完毕", "提示");
                }
                else
                {
                    multi_user_list.Items.Add("# " + user_count + "    " + id_textBox.Text);
                    user_count++;
                    multi_user_label.Text = "# " + user_count;
                    multi_user_label.Update();
                    id_textBox.Text = "";
                    pass_textBox.Text = "";
                    mail_user_textBox.Text = "";
                    mail_pass_textBox.Text = "";
                    target_textBox.Text = "";
                    area_comboBox.SelectedIndex = -1;
                    room_comboBox.Items.Clear();
                    room_comboBox.SelectedIndex = -1;
                    mail_checkBox.Checked = false;
                }
            }
            else if (pass_textBox.Text == "" || area_comboBox.SelectedIndex == -1 || room_comboBox.SelectedIndex == -1 || target_textBox.Text == "")
            {
                MessageBox.Show("必要项为空", "错误");
            }
            else
            {
                MessageBox.Show("学号长度错误", "错误");
            }
        }

        private void multiple_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (multiple_checkBox.Checked)
            {
                multi_user_label.Visible = true;
                multi_user_label.Text = "# " + user_count;
                multiple_prompt.Visible = true;
                multi_user_list.Visible = true;
                multi_user_list.Items.Add("编号   学号");
            }
            else
            {
                multi_user_label.Visible = false;
                multiple_prompt.Visible = false;
                multi_user_list.Visible = false;
            }
        }

        private void schtask_generate_button_Click(object sender, EventArgs e)
        {
            //创建者
            var creator = "Library";
            //计划任务名称
            var taskName = "Library";
            //执行的程序路径
            var CurrentPath = Application.StartupPath;
            var path = CurrentPath + "main.exe";
            //计划任务执行的频率 PT1M一分钟  PT1H30M 90分钟
            var interval = "PT24H";
            //开始时间 请遵循 yyyy-MM-ddTHH:mm:ss 格式
            DateTime dt = DateTime.Now;
            dt.AddDays(1);
            string day = dt.ToString("yyyy-MM-dd");
            var startBoundary = day + "T06:30:00";
            var description = "Automatic reserve library.";
            _TASK_STATE state = SchTaskExt.CreateTaskScheduler(creator, taskName, path, CurrentPath, interval, startBoundary, description);
            if (state == _TASK_STATE.TASK_STATE_READY)
            {
                MessageBox.Show("计划任务部署成功!", "提示");
            }
        }

        private void schtask_delete_button_Click(object sender, EventArgs e)
        {
            var taskName = "Library";
            if (!SchTaskExt.IsExists(taskName))
            {
                MessageBox.Show("计划任务不存在", "错误");
                return;
            }
            else
            {
                SchTaskExt.DeleteTask(taskName);
            }
            //Confirm
            if (!SchTaskExt.IsExists(taskName))
            {
                MessageBox.Show("计划任务删除成功", "提示");
            }
        }
    }
}