using AnimalHotelSystem.Application.Services;
using AnimalHotelSystem.Model;
using System;
using System.Windows.Forms;

namespace AnimalHotelSystem.Application
{
    public partial class FrmAddNewRoom : Form
    {
        private RoomService roomService = new RoomService();
        public FrameNewRoom newRoom = new FrameNewRoom();
        
        public FrmAddNewRoom()
        {
            InitializeComponent();
            listBox1.DataSource = Enum.GetValues(typeof(TypeOfAnimal));
        }

        private void close_click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_click(object sender, EventArgs e)
        {
            newRoom.RoomNumber = textBox1.Text;
            newRoom.Length = (double) numericUpDown1.Value;
            newRoom.Width = (double) numericUpDown2.Value;
            newRoom.Temperative = (int) numericUpDown3.Value;
            newRoom.AnimalType = (TypeOfAnimal)listBox1.SelectedItem;

            if ((TypeOfAnimal) listBox1.SelectedItem == TypeOfAnimal.Parrot)
            {
                newRoom.CageLength = (double)numericUpDown4.Value;
                newRoom.CageWidth = (double)numericUpDown5.Value;
                newRoom.CageHeight = (double)numericUpDown6.Value;
            }

            bool excHappened = false;
            try
            {
                roomService.CreateNewRoom(newRoom);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dogodila se graška prilikom dodavanja nove prostorije: \n" + ex.Message, "", MessageBoxButtons.OK);
                excHappened = true;
            }

            if (!excHappened)
            {
                Close();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TypeOfAnimal) listBox1.SelectedItem == TypeOfAnimal.Parrot)
            {
                groupBox1.Visible = true;
            }
        }
    }

    public class FrameNewRoom
    {
        public string RoomNumber { get; set; }
        public TypeOfAnimal AnimalType { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int Temperative { get; set; }
        public double CageLength { get; set; }
        public double CageWidth { get; set; }
        public double CageHeight { get; set; }
    }
}
