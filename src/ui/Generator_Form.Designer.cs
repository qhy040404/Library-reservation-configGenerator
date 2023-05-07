namespace ConfigGenerator
{
    partial class Generator_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generator_Form));
            mail_label=new Label();
            id_label=new Label();
            pass_label=new Label();
            area_label=new Label();
            room_label=new Label();
            id_textBox=new TextBox();
            pass_textBox=new TextBox();
            area_comboBox=new ComboBox();
            room_comboBox=new ComboBox();
            mail_checkBox=new CheckBox();
            mail_user_textBox=new TextBox();
            mail_user_label=new Label();
            mail_pass_textBox=new TextBox();
            mail_pass_label=new Label();
            mail_pass_prompt=new Label();
            mail_link=new LinkLabel();
            generate_button=new Button();
            target_seats_label=new Label();
            target_textBox=new TextBox();
            target_prompt1=new Label();
            multiple_checkBox=new CheckBox();
            multi_user_label=new Label();
            multiple_prompt=new Label();
            target_prompt2=new Label();
            multi_user_list=new ListBox();
            schtask_generate_button=new Button();
            schtask_delete_button=new Button();
            SuspendLayout();
            // 
            // mail_label
            // 
            mail_label.AutoSize=true;
            mail_label.Font=new Font("等线 Light", 24F, FontStyle.Regular, GraphicsUnit.Point);
            mail_label.Location=new Point(12, 21);
            mail_label.Name="mail_label";
            mail_label.Size=new Size(527, 33);
            mail_label.TabIndex=0;
            mail_label.Text="欢迎来到图书馆自动预约配置生成器";
            // 
            // id_label
            // 
            id_label.AutoSize=true;
            id_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            id_label.Location=new Point(39, 121);
            id_label.Name="id_label";
            id_label.Size=new Size(123, 19);
            id_label.TabIndex=2;
            id_label.Text="请输入学号：";
            // 
            // pass_label
            // 
            pass_label.AutoSize=true;
            pass_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            pass_label.Location=new Point(39, 155);
            pass_label.Name="pass_label";
            pass_label.Size=new Size(123, 19);
            pass_label.TabIndex=3;
            pass_label.Text="请输入密码：";
            // 
            // area_label
            // 
            area_label.AutoSize=true;
            area_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            area_label.Location=new Point(39, 189);
            area_label.Name="area_label";
            area_label.Size=new Size(85, 19);
            area_label.TabIndex=4;
            area_label.Text="图书馆：";
            // 
            // room_label
            // 
            room_label.AutoSize=true;
            room_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            room_label.Location=new Point(39, 223);
            room_label.Name="room_label";
            room_label.Size=new Size(85, 19);
            room_label.TabIndex=5;
            room_label.Text="阅览室：";
            // 
            // id_textBox
            // 
            id_textBox.Location=new Point(189, 117);
            id_textBox.Name="id_textBox";
            id_textBox.Size=new Size(152, 23);
            id_textBox.TabIndex=6;
            // 
            // pass_textBox
            // 
            pass_textBox.Location=new Point(189, 151);
            pass_textBox.Name="pass_textBox";
            pass_textBox.Size=new Size(152, 23);
            pass_textBox.TabIndex=7;
            // 
            // area_comboBox
            // 
            area_comboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            area_comboBox.FormattingEnabled=true;
            area_comboBox.Location=new Point(189, 183);
            area_comboBox.Name="area_comboBox";
            area_comboBox.Size=new Size(152, 25);
            area_comboBox.TabIndex=8;
            area_comboBox.SelectedIndexChanged+=area_comboBox_SelectedIndexChanged;
            // 
            // room_comboBox
            // 
            room_comboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            room_comboBox.FormattingEnabled=true;
            room_comboBox.Location=new Point(189, 217);
            room_comboBox.Name="room_comboBox";
            room_comboBox.Size=new Size(152, 25);
            room_comboBox.TabIndex=9;
            // 
            // mail_checkBox
            // 
            mail_checkBox.AutoSize=true;
            mail_checkBox.Location=new Point(73, 272);
            mail_checkBox.Name="mail_checkBox";
            mail_checkBox.Size=new Size(75, 21);
            mail_checkBox.TabIndex=10;
            mail_checkBox.Text="邮件提醒";
            mail_checkBox.UseVisualStyleBackColor=true;
            mail_checkBox.CheckedChanged+=mail_checkBox_CheckedChanged;
            // 
            // mail_user_textBox
            // 
            mail_user_textBox.Location=new Point(189, 308);
            mail_user_textBox.Name="mail_user_textBox";
            mail_user_textBox.Size=new Size(152, 23);
            mail_user_textBox.TabIndex=12;
            mail_user_textBox.Visible=false;
            // 
            // mail_user_label
            // 
            mail_user_label.AutoSize=true;
            mail_user_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            mail_user_label.Location=new Point(39, 312);
            mail_user_label.Name="mail_user_label";
            mail_user_label.Size=new Size(123, 19);
            mail_user_label.TabIndex=11;
            mail_user_label.Text="请输入邮箱：";
            mail_user_label.Visible=false;
            // 
            // mail_pass_textBox
            // 
            mail_pass_textBox.Location=new Point(189, 342);
            mail_pass_textBox.Name="mail_pass_textBox";
            mail_pass_textBox.Size=new Size(152, 23);
            mail_pass_textBox.TabIndex=14;
            mail_pass_textBox.Visible=false;
            // 
            // mail_pass_label
            // 
            mail_pass_label.AutoSize=true;
            mail_pass_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            mail_pass_label.Location=new Point(39, 346);
            mail_pass_label.Name="mail_pass_label";
            mail_pass_label.Size=new Size(142, 19);
            mail_pass_label.TabIndex=13;
            mail_pass_label.Text="请输入授权码：";
            mail_pass_label.Visible=false;
            // 
            // mail_pass_prompt
            // 
            mail_pass_prompt.AutoSize=true;
            mail_pass_prompt.Location=new Point(39, 379);
            mail_pass_prompt.Name="mail_pass_prompt";
            mail_pass_prompt.Size=new Size(152, 17);
            mail_pass_prompt.TabIndex=15;
            mail_pass_prompt.Text="授权码请在网页版邮箱获取";
            mail_pass_prompt.Visible=false;
            // 
            // mail_link
            // 
            mail_link.AutoSize=true;
            mail_link.Location=new Point(225, 379);
            mail_link.Name="mail_link";
            mail_link.Size=new Size(116, 17);
            mail_link.TabIndex=16;
            mail_link.TabStop=true;
            mail_link.Text="点此前往网页版邮箱";
            mail_link.Visible=false;
            // 
            // generate_button
            // 
            generate_button.Font=new Font("等线", 16F, FontStyle.Regular, GraphicsUnit.Point);
            generate_button.Location=new Point(690, 379);
            generate_button.Name="generate_button";
            generate_button.Size=new Size(81, 46);
            generate_button.TabIndex=17;
            generate_button.Text="生成";
            generate_button.UseVisualStyleBackColor=true;
            generate_button.Click+=generate_button_Click;
            // 
            // target_seats_label
            // 
            target_seats_label.AutoSize=true;
            target_seats_label.Font=new Font("等线", 14F, FontStyle.Regular, GraphicsUnit.Point);
            target_seats_label.Location=new Point(378, 117);
            target_seats_label.Name="target_seats_label";
            target_seats_label.Size=new Size(161, 19);
            target_seats_label.TabIndex=18;
            target_seats_label.Text="请输入期望座位：";
            // 
            // target_textBox
            // 
            target_textBox.Location=new Point(378, 151);
            target_textBox.Name="target_textBox";
            target_textBox.Size=new Size(409, 23);
            target_textBox.TabIndex=19;
            // 
            // target_prompt1
            // 
            target_prompt1.AutoSize=true;
            target_prompt1.Location=new Point(526, 100);
            target_prompt1.Name="target_prompt1";
            target_prompt1.Size=new Size(248, 17);
            target_prompt1.TabIndex=20;
            target_prompt1.Text="（可输入多个，请以 - 隔开，例：123-125）";
            target_prompt1.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // multiple_checkBox
            // 
            multiple_checkBox.AutoSize=true;
            multiple_checkBox.Location=new Point(378, 187);
            multiple_checkBox.Name="multiple_checkBox";
            multiple_checkBox.Size=new Size(99, 21);
            multiple_checkBox.TabIndex=21;
            multiple_checkBox.Text="多人预约模式";
            multiple_checkBox.UseVisualStyleBackColor=true;
            multiple_checkBox.CheckedChanged+=multiple_checkBox_CheckedChanged;
            // 
            // multi_user_label
            // 
            multi_user_label.AutoSize=true;
            multi_user_label.Location=new Point(39, 91);
            multi_user_label.Name="multi_user_label";
            multi_user_label.Size=new Size(103, 17);
            multi_user_label.TabIndex=22;
            multi_user_label.Text="multi_user_count";
            multi_user_label.Visible=false;
            // 
            // multiple_prompt
            // 
            multiple_prompt.AutoSize=true;
            multiple_prompt.Location=new Point(378, 211);
            multiple_prompt.Name="multiple_prompt";
            multiple_prompt.Size=new Size(284, 17);
            multiple_prompt.TabIndex=23;
            multiple_prompt.Text="多人预约模式已启用，学号上方可查看当前用户编号";
            multiple_prompt.Visible=false;
            // 
            // target_prompt2
            // 
            target_prompt2.AutoSize=true;
            target_prompt2.Location=new Point(526, 123);
            target_prompt2.Name="target_prompt2";
            target_prompt2.Size=new Size(183, 17);
            target_prompt2.TabIndex=25;
            target_prompt2.Text="（不足三位数的座位请用0补齐）";
            target_prompt2.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // multi_user_list
            // 
            multi_user_list.FormattingEnabled=true;
            multi_user_list.ItemHeight=17;
            multi_user_list.Location=new Point(378, 252);
            multi_user_list.Name="multi_user_list";
            multi_user_list.Size=new Size(120, 89);
            multi_user_list.TabIndex=26;
            multi_user_list.Visible=false;
            // 
            // schtask_generate_button
            // 
            schtask_generate_button.Font=new Font("等线", 12F, FontStyle.Regular, GraphicsUnit.Point);
            schtask_generate_button.Location=new Point(525, 315);
            schtask_generate_button.Name="schtask_generate_button";
            schtask_generate_button.Size=new Size(120, 26);
            schtask_generate_button.TabIndex=27;
            schtask_generate_button.Text="生成计划任务";
            schtask_generate_button.UseVisualStyleBackColor=true;
            schtask_generate_button.Click+=schtask_generate_button_Click;
            // 
            // schtask_delete_button
            // 
            schtask_delete_button.Font=new Font("等线", 12F, FontStyle.Regular, GraphicsUnit.Point);
            schtask_delete_button.Location=new Point(651, 315);
            schtask_delete_button.Name="schtask_delete_button";
            schtask_delete_button.Size=new Size(120, 26);
            schtask_delete_button.TabIndex=28;
            schtask_delete_button.Text="删除计划任务";
            schtask_delete_button.UseVisualStyleBackColor=true;
            schtask_delete_button.Click+=schtask_delete_button_Click;
            // 
            // Generator_Form
            // 
            AutoScaleDimensions=new SizeF(7F, 17F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(800, 450);
            Controls.Add(schtask_delete_button);
            Controls.Add(schtask_generate_button);
            Controls.Add(multi_user_list);
            Controls.Add(target_prompt2);
            Controls.Add(multiple_prompt);
            Controls.Add(multi_user_label);
            Controls.Add(multiple_checkBox);
            Controls.Add(target_prompt1);
            Controls.Add(target_textBox);
            Controls.Add(target_seats_label);
            Controls.Add(generate_button);
            Controls.Add(mail_link);
            Controls.Add(mail_pass_prompt);
            Controls.Add(mail_pass_textBox);
            Controls.Add(mail_pass_label);
            Controls.Add(mail_user_textBox);
            Controls.Add(mail_user_label);
            Controls.Add(mail_checkBox);
            Controls.Add(room_comboBox);
            Controls.Add(area_comboBox);
            Controls.Add(pass_textBox);
            Controls.Add(id_textBox);
            Controls.Add(room_label);
            Controls.Add(area_label);
            Controls.Add(pass_label);
            Controls.Add(id_label);
            Controls.Add(mail_label);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="Generator_Form";
            Text="ConfigGenerator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mail_label;
        private Label id_label;
        private Label pass_label;
        private Label area_label;
        private Label room_label;
        private TextBox id_textBox;
        private TextBox pass_textBox;
        private ComboBox area_comboBox;
        private ComboBox room_comboBox;
        private CheckBox mail_checkBox;
        private TextBox mail_user_textBox;
        private Label mail_user_label;
        private TextBox mail_pass_textBox;
        private Label mail_pass_label;
        private Label mail_pass_prompt;
        private LinkLabel mail_link;
        private Button generate_button;
        private Label target_seats_label;
        private TextBox target_textBox;
        private Label target_prompt1;
        private CheckBox multiple_checkBox;
        private Label multi_user_label;
        private Label multiple_prompt;
        private Label target_prompt2;
        private ListBox multi_user_list;
        private Button schtask_generate_button;
        private Button schtask_delete_button;
    }
}