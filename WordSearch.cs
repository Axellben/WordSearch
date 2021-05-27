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
    int n = 18;
    bool cliked;

    string ItemToDelete = "";

    public WordSearch() {
      this.DoubleBuffered = true;

      InitializeComponent();


      wordsList.Items.Add("PROIECT");
      wordsList.Items.Add("PROGRAMARE");
      wordsList.Items.Add("ORIENTATA");
      wordsList.Items.Add("OBIECT");

      listView1.View = View.Details;
      listView1.HeaderStyle = ColumnHeaderStyle.None;
      listView1.Columns.Add("", -1);
      listView1.Columns[0].Width = listView1.Width - 4 - SystemInformation.VerticalScrollBarWidth;

      listView1.Items.Add("Something").Font = new Font(
        "Fira Code", 10, FontStyle.Strikeout);
      listView1.Items.Add("Something else");
      listView1.Items.Add("Something");
      listView1.Items.Add("Something else");

      //  var item = (Item)wordsList.Items.IndexOf("PROIECT");


      wordsList.DrawMode = DrawMode.OwnerDrawFixed;
      wordsList.DrawItem += wordsList_DrawItem;


      /*
      if (File.Exists("db.json")) {

        dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText("db.json"));

        //fojsonFile["en"];

        foreach (var element in jsonFile["en"]["animale"]) {

          MessageBox.Show(element);

        }
      }
      */


      var json = File.ReadAllText("db.json");
      try {
        var jObject = JObject.Parse(json);

        if (jObject != null) {
          MessageBox.Show("ID :" + jObject["alex"].ToString());

          foreach (JProperty prop in jObject.OfType<JProperty>()) {
            MessageBox.Show($"{prop.Name}");
          }


          /*
          JArray experiencesArrary = (JArray)jObject["en"]["cars"];
          if (experiencesArrary != null) {
            foreach (var item in experiencesArrary) {
              MessageBox.Show("ID :" + item.ToString());

              //Console.WriteLine("company Id :" + item["companyid"]);
              // Console.WriteLine("company Name :" + item["companyname"].ToString());
            }

          }
          */
        }
      } catch (Exception) {

        throw;
      }



    }

    private void wordsList_DrawItem(object sender, DrawItemEventArgs e) {
      //wordsList.SelectionMode = SelectionMode.None;

      // 1. Get the item
      string selectedItem = wordsList.Items[e.Index].ToString();


      // 2. Choose font 
      Font font;

      if (selectedItem == ItemToDelete) {
        font = new Font("Fira Code", 15, FontStyle.Strikeout);
      } else {
        font = new Font("Fira Code", 15);
      }


      // 3. Choose colour
      SolidBrush solidBrush;

      if (selectedItem == ItemToDelete) {
        solidBrush = new SolidBrush(Color.Green);
      } else {
        solidBrush = new SolidBrush(Color.Black);
      }


      // 4. Get bounds
      int left = e.Bounds.Left;
      int top = e.Bounds.Top;


      //Daca nu e pus nu pot selecta
      // 5. Use Draw the background within the bounds
      //e.DrawBackground();

      // 6. Colorize listbox items
      e.Graphics.DrawString(selectedItem, font, solidBrush, left, top);
    }





    private void WordSearch_Load(object sender, EventArgs e) {

      img = new Bitmap(canvas.Height, canvas.Height);
      g = Graphics.FromImage(img);
      game = new WordSearchGame(canvas.Height, canvas.Height, n, g);
      cliked = false;
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


      ItemToDelete = "PROGRAMARE";
      wordsList.Refresh();
    }

    private void canvas_MouseUp(object sender, MouseEventArgs e) {
      cliked = false;
      canvas.Cursor = Cursors.Default;
    }

    private void canvas_MouseMove(object sender, MouseEventArgs e) {
      if (cliked) {
        game.getLetterCell(e);

        canvas.Refresh();
      }
    }


  }
}


