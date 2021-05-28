
namespace WordSearch {
  partial class WordSearch {
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
      this.canvas = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.wordListView = new System.Windows.Forms.ListView();
      ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
      this.SuspendLayout();
      // 
      // canvas
      // 
      this.canvas.Location = new System.Drawing.Point(447, 49);
      this.canvas.Name = "canvas";
      this.canvas.Size = new System.Drawing.Size(700, 700);
      this.canvas.TabIndex = 0;
      this.canvas.TabStop = false;
      this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
      this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
      this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
      this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
      this.canvas.Move += new System.EventHandler(this.canvas_Move);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Fira Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(157, 200);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(163, 29);
      this.label1.TabIndex = 2;
      this.label1.Text = "Words List";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Fira Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(708, 18);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(178, 29);
      this.label2.TabIndex = 0;
      this.label2.Text = "Word Search";
      // 
      // wordListView
      // 
      this.wordListView.Font = new System.Drawing.Font("Fira Code", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.wordListView.Location = new System.Drawing.Point(103, 232);
      this.wordListView.Name = "wordListView";
      this.wordListView.Size = new System.Drawing.Size(246, 356);
      this.wordListView.TabIndex = 7;
      this.wordListView.UseCompatibleStateImageBehavior = false;
      this.wordListView.View = System.Windows.Forms.View.List;
      // 
      // WordSearch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(1184, 761);
      this.Controls.Add(this.wordListView);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.canvas);
      this.Font = new System.Drawing.Font("Fira Code", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.MaximizeBox = false;
      this.Name = "WordSearch";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "WordSearch";
      ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox canvas;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListView wordListView;
  }
}