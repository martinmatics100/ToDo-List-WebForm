namespace ToDoList
{
    partial class Form1
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            TitleTextBox = new TextBox();
            DescriptionTextBox = new TextBox();
            SearchButton = new Button();
            LoadButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            DateCreatedTextBox = new DateTimePicker();
            label5 = new Label();
            SearchBox = new TextBox();
            DueDateTextBox = new DateTimePicker();
            label6 = new Label();
            GridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)GridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(298, -4);
            label2.Name = "label2";
            label2.Size = new Size(142, 25);
            label2.TabIndex = 2;
            label2.Text = "DateCreated";
            // 
            // label3
            // 
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(-4, 126);
            label3.Name = "label3";
            label3.Size = new Size(170, 44);
            label3.TabIndex = 3;
            label3.Text = "Description :";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(-4, 72);
            label4.Name = "label4";
            label4.Size = new Size(84, 34);
            label4.TabIndex = 4;
            label4.Text = "Title :";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Menu;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Times New Roman", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(-5, -4);
            label1.Name = "label1";
            label1.Size = new Size(291, 61);
            label1.TabIndex = 5;
            label1.Text = "myToDoList";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TitleTextBox
            // 
            TitleTextBox.AllowDrop = true;
            TitleTextBox.BorderStyle = BorderStyle.None;
            TitleTextBox.Location = new Point(5, 106);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(250, 24);
            TitleTextBox.TabIndex = 6;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(2, 172);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(1048, 68);
            DescriptionTextBox.TabIndex = 7;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = SystemColors.ActiveCaption;
            SearchButton.Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point);
            SearchButton.Location = new Point(922, 78);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(112, 34);
            SearchButton.TabIndex = 8;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.BackColor = SystemColors.ActiveCaption;
            LoadButton.Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point);
            LoadButton.Location = new Point(765, 77);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(112, 34);
            LoadButton.TabIndex = 9;
            LoadButton.Text = "LoadAll";
            LoadButton.UseVisualStyleBackColor = false;
            LoadButton.Click += LoadButton_Click;
            // 
            // EditButton
            // 
            EditButton.BackColor = SystemColors.ActiveCaption;
            EditButton.Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EditButton.Location = new Point(765, 126);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(112, 34);
            EditButton.TabIndex = 10;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = SystemColors.ActiveCaption;
            DeleteButton.Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteButton.Location = new Point(627, 78);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(112, 34);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddButton
            // 
            AddButton.BackColor = SystemColors.ActiveCaption;
            AddButton.Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.Location = new Point(765, 20);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(112, 34);
            AddButton.TabIndex = 12;
            AddButton.Text = "Add/Save";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // DateCreatedTextBox
            // 
            DateCreatedTextBox.Location = new Point(298, 23);
            DateCreatedTextBox.Name = "DateCreatedTextBox";
            DateCreatedTextBox.Size = new Size(298, 31);
            DateCreatedTextBox.TabIndex = 13;
            // 
            // label5
            // 
            label5.Font = new Font("SimSun", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(906, 22);
            label5.Name = "label5";
            label5.Size = new Size(150, 23);
            label5.TabIndex = 14;
            label5.Text = "Enter search...          ";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(906, 48);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(150, 31);
            SearchBox.TabIndex = 15;
            // 
            // DueDateTextBox
            // 
            DueDateTextBox.Location = new Point(298, 101);
            DueDateTextBox.Name = "DueDateTextBox";
            DueDateTextBox.Size = new Size(298, 31);
            DueDateTextBox.TabIndex = 16;
            // 
            // label6
            // 
            label6.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(298, 77);
            label6.Name = "label6";
            label6.Size = new Size(142, 25);
            label6.TabIndex = 17;
            label6.Text = "DueDate";
            // 
            // GridView1
            // 
            GridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView1.BackgroundColor = SystemColors.ActiveCaption;
            GridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridView1.Location = new Point(-5, 246);
            GridView1.Name = "GridView1";
            GridView1.RowHeadersWidth = 62;
            GridView1.RowTemplate.Height = 33;
            GridView1.Size = new Size(1061, 430);
            GridView1.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1049, 665);
            Controls.Add(GridView1);
            Controls.Add(label6);
            Controls.Add(DueDateTextBox);
            Controls.Add(SearchBox);
            Controls.Add(label5);
            Controls.Add(DateCreatedTextBox);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(LoadButton);
            Controls.Add(SearchButton);
            Controls.Add(DescriptionTextBox);
            Controls.Add(TitleTextBox);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
           
            ((System.ComponentModel.ISupportInitialize)GridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label1;
        private TextBox TitleTextBox;
        private TextBox DescriptionTextBox;
        private Button SearchButton;
        private Button LoadButton;
        private Button EditButton;
        private Button DeleteButton;
        private Button AddButton;
        private DateTimePicker DateCreatedTextBox;
        private Label label5;
        private TextBox SearchBox;
        private DateTimePicker DueDateTextBox;
        private Label label6;
        private DataGridView GridView1;
    }
}