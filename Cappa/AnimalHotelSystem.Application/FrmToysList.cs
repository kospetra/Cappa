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
    public partial class FrmToysList : Form
    {
        private ToyService toyService = new ToyService(); 
        public FrmToysList()
        {
            InitializeComponent();
            listBox1.DataSource = toyService.GetAllToys().Select( x => x.Name + "          " + x.TypeOfAnimal
                                                         .ToString()).ToList();
        }

        private void close_click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class FrameListToys
    {
        public string Name { get; set; }
        public TypeOfAnimal TypeOfAnimal { get; set; }
    }
}
