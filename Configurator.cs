using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSearch {
  public partial class Configurator : Form {

    private List<string> Languages = new List<string>();
    private List<CategoryEntity> CategoriesList = new List<CategoryEntity>();
    private List<WordEntity> WordsList = new List<WordEntity>();
    Words WordsObj = new Words();


    public Configurator() {
      try {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;


        CategoriesList = WordsObj.GetCategories();
        WordsList = WordsObj.GetWords();
        Languages = WordsObj.GetLanguages();
        languagesComboBox.DataSource = Languages;
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'LoadWords' method of 'LoadWords' form. Error msg: " + Ex.Message);
      }
    }



    private void languagesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      try {

        categoriesComboBox.DataSource = null;

        List<string> categories = new List<string>();
        List<CategoryEntity> CategotyInLanguages = CategoriesList.FindAll(p => p.Language.Equals(languagesComboBox.Text));
        foreach (CategoryEntity category in CategotyInLanguages)
          categories.Add(category.Category);

        categoriesComboBox.DataSource = categories;
        categoriesComboBox.Refresh();
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in LanguageComboBox. Error msg: " + Ex.Message);
      }
    }

    private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        wordsListView.Clear();
        List<WordEntity> WordsInCategory = WordsList.FindAll(p => p.Category.Equals(categoriesComboBox.Text));
        foreach (WordEntity word in WordsInCategory)
          wordsListView.Items.Add(new ListViewItem(word.Word));
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in CategoryComboBox. Error msg: " + Ex.Message);
      }
    }

    private void playBtn_Click(object sender, EventArgs e) {

      try {
        int nRows = Convert.ToInt32(numberRowsTextBox.Text);
        int maxChar = Convert.ToInt32(maxCharTextBox.Text);
        int minChar = Convert.ToInt32(minCharTextBox.Text);


        if (!(minChar <= maxChar && maxChar <= nRows)) {
          throw new Exception("Minimum no of chars must be <= than Maximum no of chars and Maximum no of chars must be <= thab Number of rows/cols");
        }



        List<WordEntity> WordsInCategory = WordsList.FindAll(p => p.Category.Equals(categoriesComboBox.Text) &&
                                                                  p.Word.Length >= minChar &&
                                                                  p.Word.Length <= maxChar);
        List<string> Words = new List<string>();
        foreach (WordEntity WordStr in WordsInCategory)
          Words.Add(WordStr.Word);

        if (Words.Count == 0) {
          throw new Exception("Game cannot be played with 0 words please modify the fields");

        }

        WordSearch WordSearchObj = new WordSearch(Words, categoriesComboBox.Text, nRows, minChar, maxChar);
        WordSearchObj.Show();

      } catch (Exception Ex) {
        if (Ex.Message == "Minimum no of chars must be <= than Maximum no of chars and Maximum no of chars must be <= thab Number of rows/cols") {
          MessageBox.Show(Ex.Message);

        } else if (Ex.Message == "Game cannot be played with 0 words please modify the fields") {
          MessageBox.Show(Ex.Message);

        } else {
          MessageBox.Show("All fields are required" + Ex.Message);
        }

      }
    }


  }

}
