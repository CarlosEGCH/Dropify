namespace Dropify
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panel1 = new Panel();
			panel3 = new Panel();
			songsList = new ListBox();
			panel2 = new Panel();
			deleteButton = new Button();
			addButton = new Button();
			songInput = new TextBox();
			label2 = new Label();
			artistInput = new TextBox();
			label1 = new Label();
			panel4 = new Panel();
			panel5 = new Panel();
			downloadButton = new Button();
			panel6 = new Panel();
			dataGridViewProgress = new DataGridView();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewProgress).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(songInput);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(artistInput);
			panel1.Controls.Add(label1);
			panel1.Dock = DockStyle.Left;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Padding = new Padding(10);
			panel1.Size = new Size(169, 450);
			panel1.TabIndex = 0;
			// 
			// panel3
			// 
			panel3.Controls.Add(songsList);
			panel3.Dock = DockStyle.Fill;
			panel3.Location = new Point(10, 124);
			panel3.Name = "panel3";
			panel3.Padding = new Padding(0, 10, 0, 0);
			panel3.Size = new Size(149, 316);
			panel3.TabIndex = 1;
			// 
			// songsList
			// 
			songsList.Dock = DockStyle.Fill;
			songsList.FormattingEnabled = true;
			songsList.ItemHeight = 15;
			songsList.Location = new Point(0, 10);
			songsList.Name = "songsList";
			songsList.Size = new Size(149, 306);
			songsList.TabIndex = 15;
			// 
			// panel2
			// 
			panel2.Controls.Add(deleteButton);
			panel2.Controls.Add(addButton);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new Point(10, 92);
			panel2.Name = "panel2";
			panel2.Size = new Size(149, 32);
			panel2.TabIndex = 13;
			// 
			// deleteButton
			// 
			deleteButton.Dock = DockStyle.Right;
			deleteButton.Location = new Point(91, 0);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(58, 32);
			deleteButton.TabIndex = 13;
			deleteButton.Text = "Delete";
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += deleteButton_Click;
			// 
			// addButton
			// 
			addButton.Dock = DockStyle.Left;
			addButton.Location = new Point(0, 0);
			addButton.Name = "addButton";
			addButton.Size = new Size(58, 32);
			addButton.TabIndex = 11;
			addButton.Text = "Add";
			addButton.UseVisualStyleBackColor = true;
			addButton.Click += addButton_Click;
			// 
			// songInput
			// 
			songInput.Dock = DockStyle.Top;
			songInput.Location = new Point(10, 69);
			songInput.Name = "songInput";
			songInput.Size = new Size(149, 23);
			songInput.TabIndex = 5;
			// 
			// label2
			// 
			label2.Dock = DockStyle.Top;
			label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(10, 51);
			label2.Name = "label2";
			label2.Size = new Size(149, 18);
			label2.TabIndex = 4;
			label2.Text = "Song Name";
			// 
			// artistInput
			// 
			artistInput.Dock = DockStyle.Top;
			artistInput.Location = new Point(10, 28);
			artistInput.Name = "artistInput";
			artistInput.Size = new Size(149, 23);
			artistInput.TabIndex = 3;
			// 
			// label1
			// 
			label1.Dock = DockStyle.Top;
			label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(10, 10);
			label1.Name = "label1";
			label1.Size = new Size(149, 18);
			label1.TabIndex = 2;
			label1.Text = "Song Artist";
			// 
			// panel4
			// 
			panel4.Controls.Add(panel6);
			panel4.Controls.Add(panel5);
			panel4.Dock = DockStyle.Fill;
			panel4.Location = new Point(169, 0);
			panel4.Name = "panel4";
			panel4.Size = new Size(631, 450);
			panel4.TabIndex = 1;
			// 
			// panel5
			// 
			panel5.Controls.Add(downloadButton);
			panel5.Dock = DockStyle.Bottom;
			panel5.Location = new Point(0, 398);
			panel5.Name = "panel5";
			panel5.Size = new Size(631, 52);
			panel5.TabIndex = 0;
			// 
			// downloadButton
			// 
			downloadButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			downloadButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			downloadButton.Location = new Point(246, 3);
			downloadButton.Name = "downloadButton";
			downloadButton.Size = new Size(150, 40);
			downloadButton.TabIndex = 1;
			downloadButton.Text = "DOWNLOAD";
			downloadButton.UseVisualStyleBackColor = true;
			downloadButton.Click += buttonDownload_Click;
			// 
			// panel6
			// 
			panel6.Controls.Add(dataGridViewProgress);
			panel6.Dock = DockStyle.Fill;
			panel6.Location = new Point(0, 0);
			panel6.Name = "panel6";
			panel6.Padding = new Padding(20);
			panel6.Size = new Size(631, 398);
			panel6.TabIndex = 1;
			// 
			// dataGridViewProgress
			// 
			dataGridViewProgress.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewProgress.Dock = DockStyle.Fill;
			dataGridViewProgress.Location = new Point(20, 20);
			dataGridViewProgress.Name = "dataGridViewProgress";
			dataGridViewProgress.RowTemplate.Height = 25;
			dataGridViewProgress.Size = new Size(591, 358);
			dataGridViewProgress.TabIndex = 1;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel4);
			Controls.Add(panel1);
			Name = "MainForm";
			Text = "MainForm";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel5.ResumeLayout(false);
			panel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewProgress).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label2;
		private TextBox artistInput;
		private Label label1;
		private TextBox songInput;
		private Panel panel3;
		private ListBox songsList;
		private Panel panel2;
		private Button deleteButton;
		private Button addButton;
		private Panel panel4;
		private Panel panel5;
		private Button downloadButton;
		private Panel panel6;
		private DataGridView dataGridViewProgress;
	}
}