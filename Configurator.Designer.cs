
namespace WordSearch {
  partial class Configurator {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.categoriesComboBox = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.languagesComboBox = new System.Windows.Forms.ComboBox();
      this.wordsListView = new System.Windows.Forms.ListView();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.playBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // categoriesComboBox
      // 
      this.categoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.categoriesComboBox.FormattingEnabled = true;
      this.categoriesComboBox.Location = new System.Drawing.Point(529, 149);
      this.categoriesComboBox.Margin = new System.Windows.Forms.Padding(4);
      this.categoriesComboBox.Name = "categoriesComboBox";
      this.categoriesComboBox.Size = new System.Drawing.Size(121, 28);
      this.categoriesComboBox.TabIndex = 0;
      this.categoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(423, 117);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "Language";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(423, 152);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(99, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Catergory";
      // 
      // languagesComboBox
      // 
      this.languagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.languagesComboBox.FormattingEnabled = true;
      this.languagesComboBox.Location = new System.Drawing.Point(529, 114);
      this.languagesComboBox.Name = "languagesComboBox";
      this.languagesComboBox.Size = new System.Drawing.Size(121, 28);
      this.languagesComboBox.TabIndex = 3;
      this.languagesComboBox.SelectedIndexChanged += new System.EventHandler(this.languagesComboBox_SelectedIndexChanged);
      // 
      // wordsListView
      // 
      this.wordsListView.HideSelection = false;
      this.wordsListView.Location = new System.Drawing.Point(460, 224);
      this.wordsListView.Name = "wordsListView";
      this.wordsListView.Size = new System.Drawing.Size(168, 399);
      this.wordsListView.TabIndex = 7;
      this.wordsListView.UseCompatibleStateImageBehavior = false;
      this.wordsListView.View = System.Windows.Forms.View.List;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(51, 262);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(199, 20);
      this.label3.TabIndex = 5;
      this.label3.Text = "Number of rows/cols";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(256, 255);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 27);
      this.textBox1.TabIndex = 6;
      this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(519, 201);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "Words";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(256, 325);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 27);
      this.textBox2.TabIndex = 9;
      this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(51, 332);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(199, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Minimum no of chars";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(256, 389);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(100, 27);
      this.textBox3.TabIndex = 11;
      this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(51, 396);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(199, 20);
      this.label6.TabIndex = 10;
      this.label6.Text = "Maximum no of chars";
      // 
      // playBtn
      // 
      this.playBtn.Font = new System.Drawing.Font("Fira Code", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.playBtn.Location = new System.Drawing.Point(613, 667);
      this.playBtn.Name = "playBtn";
      this.playBtn.Size = new System.Drawing.Size(114, 52);
      this.playBtn.TabIndex = 12;
      this.playBtn.Text = "PLAY";
      this.playBtn.UseVisualStyleBackColor = true;
      // 
      // Configurator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(784, 761);
      this.Controls.Add(this.playBtn);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.wordsListView);
      this.Controls.Add(this.languagesComboBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.categoriesComboBox);
      this.Font = new System.Drawing.Font("Fira Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.MaximizeBox = false;
      this.Name = "Configurator";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Configurator";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox categoriesComboBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox languagesComboBox;
    private System.Windows.Forms.ListView wordsListView;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button playBtn;
  }
}