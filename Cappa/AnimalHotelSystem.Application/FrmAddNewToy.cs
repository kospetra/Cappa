using AnimalHotelSystem.Application.Services;
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
   
    public partial class FrmAddNewToy : Form
    {
        private ToyService toyService = new ToyService();
        public FrameAddNewToy newToy = new FrameAddNewToy();

        public FrmAddNewToy()
        {
            InitializeComponent();
            listBox1.DataSource = Enum.GetValues(typeof(TypeOfAnimal));
        }

        private void save_Click(object sender, EventArgs e)
        {
            newToy.Name = textBox1.Text;
            newToy.TypeOfAnimal = (TypeOfAnimal)listBox1.SelectedItem;

            bool excHappened = false;
            try
            {
                 toyService.AddToy(newToy);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se graška prilikom dodavanja nove igračke: \n" + ex.Message, "", MessageBoxButtons.OK);
                excHappened = true;
            }

            if (!excHappened)
            {
                Close();
            }
        }

        private void exit_click(object sender, EventArgs e)
        {
            Close();
        }
    } 
    
    public class FrameAddNewToy
    {
        public string Name { get; set; }
        public TypeOfAnimal TypeOfAnimal { get; set; }
    }

}
