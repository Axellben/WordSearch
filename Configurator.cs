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
        //categoryComboBox.DataSource = Categories;
      } catch (Exception Ex) {
        MessageBox.Show("An error occurred in 'LoadWords' method of 'LoadWords' form. Error msg: " + Ex.Message);
      }
    }



    private void languagesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        //categoryComboBox.DataSource = "";
        //WordsListView.Clear();
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
  }
}
