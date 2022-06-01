using AnimalHotelSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalHotelSystem.Application
{
    public partial class List : Form
    {
        private AnimalFoodService foodService = new AnimalFoodService();
        public FrameFood InputDataFromFrame = new FrameFood();
        public List<String> allAnimalFoodInList = new List<string>();
        public List()
        {
            InitializeComponent();
            allAnimalFoodInList = foodService.GetFoodList().Select(x => x.Name + "           " + x.TypeOfAnimalGroup.ToString() + "           " 
                            + x.AgeGroup.ToString() + "                  " + x.PortionsOfFood + "                             " + x.AlergensInFood[0]).ToList();
            allAnimalFoodInList.Insert(0, "IME:       TIP ŽIVOTINJE:      UZRAST:    kOLIČINA PORCIJA:     ALERGENI: ");
            listBox1.DataSource = allAnimalFoodInList;
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addPortions_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex-1;
            AnimalFood foodForChange = foodService.GetFoodList()[index];
            //MessageBox.Show(foodForChange.ToString());
            FrmAddPortionsToFood frmAddPortionsToFood = new FrmAddPortionsToFood(foodForChange);
            frmAddPortionsToFood.ShowDialog();
            Close();
        }

        private void changeQuantityOfFood_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void feedTheAnimals_Click(object sender, EventArgs e)
        {
            //bool excHappend = false;
            try
            {
               foodService.FeedAnimals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se greška prilikom hranjenja, dodajte hrane\n" + ex.Message, "", MessageBoxButtons.OK);
                //excHappend = true;
            }
            
            Close();
        }
    }

    public class FrameFood
    {
        public string FoodName { get; set; }
        public List<string> AlergensInFood { get; set; } = new List<string>();
        public AgeOfAnimal AgeGroup { get; set; }
        public TypeOfAnimal TypeOfAnimalGroup { get; set; }
        public int PortionsOfFood { get; set; }
    }
}
