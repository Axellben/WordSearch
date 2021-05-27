using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSearch {

  class WordEntity {
    public string Language { get; set; }
    public string Category { get; set; }
    public string Word { get; set; }
  }

  class CategoryEntity {
    public string Language { get; set; }
    public string Category { get; set; }

  }

  class Words {

    private const int MAX_LENGTH = 10;
    private const int MIN_LENGTH = 3;


    private List<string> Languages = new List<string>();
    private List<CategoryEntity> CategoriesList = new List<CategoryEntity>();
    private List<WordEntity> WordsList = new List<WordEntity>();



    public List<CategoryEntity> GetCategories() {
      return CategoriesList;
    }

    public List<WordEntity> GetWords() {
      return WordsList;
    }

    public List<string> GetLanguages() {
      return Languages;
    }


    public Words() {
      LoadCategoriesAndWords();
    }

    public void LoadCategoriesAndWords() {
      try {
        var json = File.ReadAllText("db.json");

        var jObject = JObject.Parse(json);

        if (jObject != null) {
          foreach (JProperty lan in jObject.OfType<JProperty>()) {
            //MessageBox.Show($"{prop.Name}");
            Languages.Add(lan.Name.ToUpper());



            foreach (JProperty category in jObject[lan.Name].OfType<JProperty>()) {
              //MessageBox.Show("ID :");
              CategoryEntity Category = new CategoryEntity();
              Category.Language = lan.Name.ToUpper();
              Category.Category = category.Name.ToUpper();
              CategoriesList.Add(Category);


              foreach (var word in (JArray)jObject[lan.Name][category.Name]) {
                WordEntity Word = new WordEntity();
                Word.Language = lan.Name.ToUpper();
                Word.Category = category.Name.ToUpper();
                Word.Word = word.ToString().ToUpper();
                WordsList.Add(Word);
              }
            }

            /*
            JArray categories = (JArray)jObject[lan.Name];
            if (categories != null) {
              foreach (var item in categories) {
                MessageBox.Show("ID :");

                //Console.WriteLine("company Id :" + item["companyid"]);
                // Console.WriteLine("company Name :" + item["companyname"].ToString());
              }

            }
            */

          }
        }




      } catch (Exception Ex) {
        //MessageBox.Show("An error occurred in 'ReadWordsFromFile' method of 'LoadWords' form. Error msg: " + Ex.Message);
      }
    }
  }
}
