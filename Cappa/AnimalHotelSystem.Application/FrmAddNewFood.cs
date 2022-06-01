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
    public partial class FrmAddNewFood : Form
    {
        private AnimalFoodService foodService = new AnimalFoodService();
        public FrameAddNewFood InputDataFromFrame = new FrameAddNewFood();

        public FrmAddNewFood()
        {
            InitializeComponent();
            listBox1.DataSource = Enum.GetValues(typeof (AgeOfAnimal));
            listBox2.DataSource = Enum.GetValues(typeof (TypeOfAnimal));
        }

        private void FrmAddNewFood_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            InputDataFromFrame.FoodName = textBox1.Text;
            InputDataFromFrame.AlergensInFood.Add(textBox2.Text);
            InputDataFromFrame.AgeGroup = (AgeOfAnimal) listBox1.SelectedItem;
            InputDataFromFrame.TypeOfAnimalGroup = (TypeOfAnimal) listBox2.SelectedItem;
            InputDataFromFrame.PortionsOfFood = (int) numericUpDown1.Value;

            bool excHappened = false;
            try
            {
                foodService.AddNewFood(InputDataFromFrame);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se graška prilikom dodavanja nove hrane: \n" + ex.Message, "", MessageBoxButtons.OK);
                excHappened = true;
            }

            if (!excHappened)
            {
                Close();
            }
        }
    } 
    
    public class FrameAddNewFood
    {
        public string FoodName { get; set; }
        public List<string> AlergensInFood { get; set; } = new List<string>();
        public AgeOfAnimal AgeGroup { get; set; }
        public TypeOfAnimal TypeOfAnimalGroup { get; set; }
        public int PortionsOfFood { get; set; }
    }
}
