using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSearch {
  class WordSearchGame {
    int width, height, columns, gridSize, cellWidth, padding = 10;

    Graphics g;

    List<List<LetterCell>> grid;
    List<String> Words;
    public List<string> WordsFound = new List<string>();      // These arrays are needed to store all the words that the player found.

    Random Rnd = new Random(DateTime.Now.Millisecond);
    public string StatusForDisplay = "";




    public WordSearchGame(List<String> _Words, int width, int height, int _gridSize, Graphics g) {
      Words = new List<string>(_Words);

      this.width = width;
      this.height = height;
      this.g = g;
      this.gridSize = _gridSize;
      cellWidth = width / gridSize;
      grid = new List<List<LetterCell>>();


      for (int i = 0; i < gridSize; i++) {
        List<LetterCell> row = new List<LetterCell>();
        for (int j = 0; j < gridSize; j++) {
          row.Add(new LetterCell(i * cellWidth + cellWidth / 2, j * cellWidth + cellWidth / 2, cellWidth, cellWidth, '\0', false));
        }
        grid.Add(row);
      }




      int PlacementIndex_X, PlacementIndex_Y;
      bool PlacementSuccessful;
      int OrientationDecision;


      // For all the words in the list, try to place them on the board.
      for (int i = 0; i < Words.Count; i++) {
        PlacementSuccessful = false;
        do {
          OrientationDecision = GetRandomNumber(Rnd, 8) + 1;   // From randomizer, orientation of the string to put should be either of the eight orientations.
          PlacementIndex_X = GetRandomNumber(Rnd, gridSize);    // Get the X-coordinate for the string to place.
          PlacementIndex_Y = GetRandomNumber(Rnd, gridSize);    // Get the Y-coordinate for the string to place.
          PlacementSuccessful = PlaceTheWords(OrientationDecision, PlacementIndex_X, PlacementIndex_Y, Words[i]);
        }
        while (!PlacementSuccessful);
      }

      FillInTheGaps();


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


      for (int i = 0; i <= gridSize; i++) {
        //g.DrawLine(creion, 0, cellWidth + i * cellWidth, width, cellWidth + i * cellWidth);
        //g.DrawLine(creion, cellWidth + i * cellWidth, 0, cellWidth + i * cellWidth, height);
      }


      for (int i = 0; i < gridSize; i++) {
        for (int j = 0; j < gridSize; j++) {
          g.DrawString(grid[i][j].Letter.ToString(), f, Brushes.Black, new RectangleF(grid[i][j].X - grid[i][j].Width / 2, grid[i][j].Y - grid[i][j].Height / 2, grid[i][j].Width, grid[i][j].Height), sf); ;

          if (grid[i][j].Used) {

            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            g.FillRectangle(brush, grid[i][j].X - grid[i][j].Width / 2, grid[i][j].Y - grid[i][j].Height / 2, grid[i][j].Width, grid[i][j].Height);

          }
        }
      }
    }

    private int GetRandomNumber(Random Rnd, int Max) {
      return Rnd.Next(Max);   // Generates a number from 0 up to the grid size.
    }


    public void updateGame() {

      drawTable();
    }

    public void getLetterCell(MouseEventArgs e) {

      int i = e.X / cellWidth;
      int j = e.Y / cellWidth;


      Pen creion = new Pen(Color.Black, 3);


      if (i >= 0 && i < gridSize && j >= 0 && j < gridSize) {

        // Verificam rectangle mai mic ca sa punem alege si diagonal
        if (e.X > grid[i][j].X - grid[i][j].Width / 3 && e.X < grid[i][j].X + grid[i][j].Width / 3 && e.Y > grid[i][j].Y - grid[i][j].Height / 3 && e.Y < grid[i][j].Y + grid[i][j].Height / 3) {

          // Select word
          g.DrawRectangle(creion, grid[i][j].X - grid[i][j].Width / 2, grid[i][j].Y - grid[i][j].Height / 2, grid[i][j].Width, grid[i][j].Height);


        }
      }

    }

    private bool PlaceTheWords(int OrientationDecision, int PlacementIndex_X, int PlacementIndex_Y, string Word) {
      try {
        bool PlaceAvailable = true;

        switch (OrientationDecision) {
          case 1:
            for (int i = 0, j = PlacementIndex_Y; i < Word.Length; i++, j++)               // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j >= gridSize) return false; // Falling outside the grid. Hence placement unavailable.
              if (grid[PlacementIndex_X][j].Letter != '\0')
                if (grid[PlacementIndex_X][j].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, or a non-conflicting overlap is available, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_Y; i < Word.Length; i++, j++)
                grid[PlacementIndex_X][j].Letter = Word[i];
              return true;
            }
            break;
          case 2:
            for (int i = 0, j = PlacementIndex_Y; i < Word.Length; i++, j--)               // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j < 0) return false; // Falling outside the grid. Hence placement unavailable.
              if (grid[PlacementIndex_X][j].Letter != '\0')
                if (grid[PlacementIndex_X][j].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, or a non-conflicting overlap is available, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_Y; i < Word.Length; i++, j--)
                grid[PlacementIndex_X][j].Letter = Word[i];
              return true;
            }
            break;
          case 3:
            for (int i = 0, j = PlacementIndex_X; i < Word.Length; i++, j++)               // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j >= gridSize) return false; // Falling outside the grid. Hence placement unavailable.
              if (grid[j][PlacementIndex_Y].Letter != '\0')
                if (grid[j][PlacementIndex_Y].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, or a non-conflicting overlap is available, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_X; i < Word.Length; i++, j++)
                grid[j][PlacementIndex_Y].Letter = Word[i];
              return true;
            }
            break;
          case 4:
            for (int i = 0, j = PlacementIndex_X; i < Word.Length; i++, j--)               // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j < 0) return false; // Falling outside the grid. Hence placement unavailable.
              if (grid[j][PlacementIndex_Y].Letter != '\0')
                if (grid[j][PlacementIndex_Y].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, or a non-conflicting overlap is available, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_X; i < Word.Length; i++, j--)
                grid[j][PlacementIndex_Y].Letter = Word[i];
              return true;
            }
            break;
          case 5:
            for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j++, k--)  // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j >= gridSize || k < 0) return false;   // Falling outside the grid. Hence placement unavailable.
              if (grid[k][j].Letter != '\0')
                if (grid[k][j].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j++, k--)
                grid[k][j].Letter = Word[i];
              return true;
            }
            break;
          case 6:
            for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j--, k--)  // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j < 0 || k < 0) return false;   // Falling outside the grid. Hence placement unavailable.
              if (grid[k][j].Letter != '\0')
                if (grid[k][j].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j--, k--)
                grid[k][j].Letter = Word[i];
              return true;
            }
            break;
          case 7:
            for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j++, k++)  // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j >= gridSize || k >= gridSize) return false;   // Falling outside the grid. Hence placement unavailable.
              if (grid[j][k].Letter != '\0')
                if (grid[j][k].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j++, k++)
                grid[j][k].Letter = Word[i];
              return true;
            }
            break;
          case 8:
            for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j++, k--)  // First we check if the word can be placed in the array. For this it needs blanks there.
            {
              if (j >= gridSize || k < 0) return false;   // Falling outside the grid. Hence placement unavailable.
              if (grid[j][k].Letter != '\0')
                if (grid[j][k].Letter != Word[i])   // If there is an overlap, then we see if the characters match. If matches, then it can still go there.
                {
                  PlaceAvailable = false;
                  break;
                }
            }
            if (PlaceAvailable) {   // If all the cells are blank, then this word can be placed there. So place it.
              for (int i = 0, j = PlacementIndex_X, k = PlacementIndex_Y; i < Word.Length; i++, j++, k--)
                grid[j][k].Letter = Word[i];
              return true;
            }
            break;
        }
        return false;   // Otherwise continue with a different place and index.
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'PlaceTheWords' method of the 'GameEngine' class. Error msg: " + Ex.Message);
        return false;   // Otherwise continue with a different place and index.
      }
    }

    private void FillInTheGaps() {
      try {
        for (int i = 0; i < gridSize; i++)
          for (int j = 0; j < gridSize; j++)
            if (grid[i][j].Letter == '\0')
              grid[i][j].Letter = (char)(65 + GetRandomNumber(Rnd, 26));
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'FillInTheGaps' method of the 'GameEngine' class. Error msg: " + Ex.Message);
      }
    }


    public void CheckValidity(Stack<Point> Points, ref string TheWordIntendedParam) {
      try {

        if (Points.Count == 1) return; // This was a doble click, no dragging, hence return.
        int StartX = Points.ToArray()[1].X / cellWidth + 1;    // Retrieve the starting position of the line.
        int StartY = Points.ToArray()[1].Y / cellWidth + 1;

        int EndX = Points.ToArray()[0].X / cellWidth + 1;      // Retrieve the ending position of the line.
        int EndY = Points.ToArray()[0].Y / cellWidth + 1;

        if (StartX >= gridSize || EndX >= gridSize || StartY >= gridSize || EndY >= gridSize || // Boundary checks.
            StartX <= 0 || EndX <= 0 || StartY <= 0 || EndY <= 0)
          StatusForDisplay = "Nope!";

        StringBuilder TheWordIntended = new StringBuilder();
        TheWordIntended.Clear();
        if (StartX < EndX && StartY == EndY) // Right line drawn.
          for (int i = StartX; i <= EndX; i++) {
            TheWordIntended.Append(grid[i - 1][StartY - 1].Letter.ToString());
          }
        else if (StartX > EndX && StartY == EndY) // Left line drawn.
          for (int i = StartX; i >= EndX; i--) {
            TheWordIntended.Append(grid[i - 1][StartY - 1].Letter.ToString());
          }
        else if (StartX == EndX && StartY < EndY) // Down line drawn.
          for (int i = StartY; i <= EndY; i++) {
            TheWordIntended.Append(grid[StartX - 1][i - 1].Letter.ToString());
          }
        else if (StartX == EndX && StartY > EndY) // Up line drawn.
          for (int i = StartY; i >= EndY; i--) {
            TheWordIntended.Append(grid[StartX - 1][i - 1].Letter.ToString());
          }
        else if (StartX > EndX && EndY > StartY) // Down Left line drawn.
          for (int i = StartX, j = StartY; i >= EndX; i--, j++) {
            TheWordIntended.Append(grid[i - 1][j - 1].Letter.ToString());
          }
        else if (StartX > EndX && EndY < StartY) // Up Left line drawn.
          for (int i = StartX, j = StartY; i >= EndX; i--, j--) {
            TheWordIntended.Append(grid[i - 1][j - 1].Letter.ToString());
          }
        else if (EndX > StartX && EndY > StartY) // Down Right line drawn.
          for (int i = StartX, j = StartY; i <= EndX; i++, j++) {
            TheWordIntended.Append(grid[i - 1][j - 1].Letter.ToString());
          }
        else if (EndX > StartX && EndY < StartY) // Up Right line drawn.
          for (int i = StartX, j = StartY; i <= EndX; i++, j--) {
            TheWordIntended.Append(grid[i - 1][j - 1].Letter.ToString());
          }
        TheWordIntendedParam = TheWordIntended.ToString();




        if (FoundAWord(TheWordIntended.ToString())) // Checking if the word the player made is available in the words list.
        {
          if (WordsFound.FindIndex(p => p.Equals(TheWordIntended.ToString())) == -1)  // Checking if the word was already found before or it is a new finding. It is -1 when the word is not found.
          {
            WordsFound.Add(TheWordIntended.ToString()); // If it is a new finding, then add the word in the 'found' list.
            TheWordIntendedParam = TheWordIntended.ToString();

            StatusForDisplay = "Bingo!!!";
          } else
            StatusForDisplay = "Already found! Why wasting time?";
        } else  // This is not a legitimate word in the word list.
          StatusForDisplay = "Nope!";

      } catch (ArgumentOutOfRangeException e) {
        MessageBox.Show("Please select only the cells inside the board.");

      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'CheckValidity' method of the 'WordSearchGame' class. Error msg: " + Ex.Message);
      }
    }


    public void UpdateGrid(Stack<Point> Points) {
      try {
        if (Points.Count == 1) return; // This was a doble click, no dragging, hence return.
        int StartX = Points.ToArray()[1].X / cellWidth + 1;    // Retrieve the starting position of the line.
        int StartY = Points.ToArray()[1].Y / cellWidth + 1;

        int EndX = Points.ToArray()[0].X / cellWidth + 1;      // Retrieve the ending position of the line.
        int EndY = Points.ToArray()[0].Y / cellWidth + 1;

        if (StartX > gridSize || EndX > gridSize || StartY > gridSize || EndY > gridSize || // Boundary checks.
            StartX <= 0 || EndX <= 0 || StartY <= 0 || EndY <= 0)
          StatusForDisplay = "Nope!";


        if (StartX < EndX && StartY == EndY) // Right line drawn.
          for (int i = StartX; i <= EndX; i++) {
            grid[i - 1][StartY - 1].Used = true;
          }
        else if (StartX > EndX && StartY == EndY) // Left line drawn.
          for (int i = StartX; i >= EndX; i--) {
            grid[i - 1][StartY - 1].Used = true;
          }
        else if (StartX == EndX && StartY < EndY) // Down line drawn.
          for (int i = StartY; i <= EndY; i++) {
            grid[StartX - 1][i - 1].Used = true;
          }
        else if (StartX == EndX && StartY > EndY) // Up line drawn.
          for (int i = StartY; i >= EndY; i--) {
            grid[StartX - 1][i - 1].Used = true;
          }
        else if (StartX > EndX && EndY > StartY) // Down Left line drawn.
          for (int i = StartX, j = StartY; i >= EndX; i--, j++) {
            grid[i - 1][j - 1].Used = true;
          }
        else if (StartX > EndX && EndY < StartY) // Up Left line drawn.
          for (int i = StartX, j = StartY; i >= EndX; i--, j--) {
            grid[i - 1][j - 1].Used = true;
          }
        else if (EndX > StartX && EndY > StartY) // Down Right line drawn.
          for (int i = StartX, j = StartY; i <= EndX; i++, j++) {
            grid[i - 1][j - 1].Used = true;
          }
        else if (EndX > StartX && EndY < StartY) // Up Right line drawn.
          for (int i = StartX, j = StartY; i <= EndX; i++, j--) {
            grid[i - 1][j - 1].Used = true;
          }
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'UpdateGrid' method of the 'WordSearchGame' class. Error msg: " + Ex.Message);

      }
    }


    private bool FoundAWord(string TheWordIntended) {
      foreach (string s in Words)
        if (TheWordIntended.Equals(s))
          return true;
      return false;
    }

  }


  class LetterCell {
    int x, y, width, height;
    char letter;
    bool used;

    public LetterCell(int x, int y, int width, int height, char letter, bool _used) {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
      this.letter = letter;
      this.used = _used;
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

    public char Letter {
      get { return letter; }
      set { this.letter = value; }
    }

    public bool Used {
      get { return used; }
      set { this.used = value; }
    }

  }

}
