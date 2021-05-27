using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSearch {
  class WordSearchGame {
    int width, height, columns, rows, n, cellWidth, padding = 10;

    Graphics g;

    List<List<LetterCell>> grid;


    public WordSearchGame(int width, int height, int n, Graphics g) {
      this.width = width;
      this.height = height;
      this.g = g;
      this.n = n;
      cellWidth = width / n;
      grid = new List<List<LetterCell>>();

      for (int i = 0; i < n; i++) {
        List<LetterCell> row = new List<LetterCell>();
        for (int j = 0; j < n; j++) {
          row.Add(new LetterCell(i * cellWidth + cellWidth / 2, j * cellWidth + cellWidth / 2, cellWidth, cellWidth, GetLetter()));
          //g.DrawString(GetLetter(), f, Brushes.Black, new RectangleF(i * cellWidth, j * cellWidth, cellWidth, cellWidth + cellWidth / 4), sf);
          //g.DrawString(((char)(i + 'a')).ToString(), f, Brushes.Black, new RectangleF(cellWidth + i * cellWidth, 9 * cellWidth, cellWidth, cellWidth / 2), sf);
        }
        grid.Add(row);
      }



    }

    string GetLetter() {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      Random rand = new Random();
      int num = rand.Next(0, chars.Length - 1);
      return chars[num].ToString();
    }


    void drawTable() {
      g.Clear(Color.White);
      Pen creion = new Pen(Color.Black, 1);


      Font f = new Font("Fira Code", cellWidth / 2);
      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Center;
      sf.LineAlignment = StringAlignment.Center;
      SizeF stringSize = new SizeF();
      string measureString = "A";
      stringSize = g.MeasureString(measureString, f);




      /*for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          g.FillRectangle((i + j) % 2 == 0 ? col1 : col2, l + i * l, l + j * l, l, l);
        }
      }
      */
      for (int i = 0; i <= n; i++) {
        //g.DrawLine(creion, 0, cellWidth + i * cellWidth, width, cellWidth + i * cellWidth);
        //g.DrawLine(creion, cellWidth + i * cellWidth, 0, cellWidth + i * cellWidth, height);
      }


      for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
          g.DrawString(grid[i][j].Letter, f, Brushes.Black, new RectangleF(grid[i][j].X - grid[i][j].Width / 2, grid[i][j].Y - grid[i][j].Height / 2, grid[i][j].Width, grid[i][j].Height), sf); ;

          //g.DrawString(GetLetter(), f, Brushes.Black, new RectangleF(i * cellWidth, j * cellWidth, cellWidth, cellWidth + cellWidth / 4), sf);
          //g.DrawString(((char)(i + 'a')).ToString(), f, Brushes.Black, new RectangleF(cellWidth + i * cellWidth, 9 * cellWidth, cellWidth, cellWidth / 2), sf);
        }
      }

    }


    public void updateGame() {

      drawTable();
    }

    public void getLetterCell(MouseEventArgs e) {

      int i = e.X / cellWidth;
      int j = e.Y / cellWidth;


      Pen creion = new Pen(Color.Black, 3);

      //MessageBox.Show(i.ToString() + " " + j.ToString());

      //if (e.X > grid[i][j].X - grid[i][j].Width / 2 && e.X < grid[i][j].X + grid[i][j].Width / 2 && e.Y > grid[i][j].Y - grid[i][j].Height / 2 && e.Y < grid[i][j].Y + grid[i][j].Height / 2) {


      //if (e.X > i * cellWidth - grid[i][j].Width / 2 && e.X < i * cellWidth + grid[i][j].Width / 2 && j * cellWidth > grid[i][j].Y - grid[i][j].Height / 2 && j * cellWidth < grid[i][j].Y + grid[i][j].Height / 2)
      //g.DrawEllipse(creion, i * cellWidth, j * cellWidth, cellWidth, cellWidth);
      if (i >= 0 && i < n && j >= 0 && j < n) {

        // Verificam rectangle mai mic ca sa punem alege si diagonal
        if (e.X > grid[i][j].X - grid[i][j].Width / 3 && e.X < grid[i][j].X + grid[i][j].Width / 3 && e.Y > grid[i][j].Y - grid[i][j].Height / 3 && e.Y < grid[i][j].Y + grid[i][j].Height / 3) {


          // Debugging
          g.DrawRectangle(creion, grid[i][j].X - grid[i][j].Width / 2, grid[i][j].Y - grid[i][j].Height / 2, grid[i][j].Width, grid[i][j].Height);
          g.DrawRectangle(creion, grid[i][j].X - grid[i][j].Width / 4, grid[i][j].Y - grid[i][j].Height / 4, grid[i][j].Width / 2, grid[i][j].Height / 2);


        }
      }

    }



  }


  class LetterCell {
    int x, y, width, height;
    string letter;

    public LetterCell(int x, int y, int width, int height, string letter) {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
      this.letter = letter;
    }

    public int X {
      get { return x; }
      set { this.x = value; }
    }
    public int Y {
      get { return y; }
      set { this.y = value; }
    }
    public int Width {
      get { return width; }
      set { this.width = value; }
    }
    public int Height {
      get { return height; }
      set { this.height = value; }
    }

    public string Letter {
      get { return letter; }
      set { this.letter = value; }
    }

  }

}
