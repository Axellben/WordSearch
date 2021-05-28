using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace WordSearch {
  public partial class WordSearch : Form {
    Graphics g;
    Image img;
    WordSearchGame game;

    bool cliked;

    string ItemToDelete = "";
    List<string> Words;
    int nRows;
    int minChars;
    int maxChars;
    string category;
    private Stack<Point> Points = new Stack<Point>();



    public WordSearch(List<string> WordsParams, string SelectedCategory, int _nRows, int _minChars, int _maxChars) {
      this.DoubleBuffered = true;

      InitializeComponent();

      List<string> Words = new List<string>(WordsParams);
      category = SelectedCategory;
      nRows = _nRows;
      minChars = _minChars;
      maxChars = _maxChars;

      foreach (string w in Words) {
        wordListView.Items.Add(w);
      }


      img = new Bitmap(canvas.Height, canvas.Height);
      g = Graphics.FromImage(img);
      cliked = false;
      game = new WordSearchGame(Words, canvas.Height, canvas.Height, nRows, g);
      game.updateGame();


    }




    private void canvas_Paint(object sender, PaintEventArgs e) {
      e.Graphics.DrawImage(img, canvas.Width / 2 - canvas.Height / 2, canvas.Height / 2 - canvas.Height / 2, canvas.Height, canvas.Height);
    }

    private void canvas_MouseDown(object sender, MouseEventArgs e) {
      cliked = true;
      canvas.Cursor = Cursors.Hand;
      if (cliked) {
        game.getLetterCell(e);

        canvas.Refresh();
      }

      if (e.Button == MouseButtons.Left) {
        Points.Clear();
        Points.Push(e.Location);
      }
    }

    private void canvas_MouseUp(object sender, MouseEventArgs e) {
      cliked = false;
      canvas.Cursor = Cursors.Default;

      if (Points.Count == 1) return; // This was a doble click, no dragging, hence return.

      string TheWordIntended = "";
      game.CheckValidity(Points, ref TheWordIntended);



      if (game.StatusForDisplay.Equals("Bingo!!!")) {
        wordListView.Items[wordListView.FindItemWithText(TheWordIntended).Index].BackColor = Color.Gray;
        game.UpdateGrid(Points);
      }

      game.updateGame();
      canvas.Refresh();
    }

    private void canvas_MouseMove(object sender, MouseEventArgs e) {
      if (cliked) {
        game.getLetterCell(e);

        canvas.Refresh();
      }


      try {
        if (e.Button == MouseButtons.Left) {
          if (Points.Count > 1)
            Points.Pop();
          if (Points.Count > 0)
            Points.Push(e.Location);
        }
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'GameBoard_MouseMove' method of 'GameBoard' form. Error msg: " + Ex.Message);
      }
    }

    private void canvas_Move(object sender, EventArgs e) {
      Points.Clear();
    }
  }
}


