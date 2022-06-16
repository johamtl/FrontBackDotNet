using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ServiceAgent.Agents;
using CommonContracts;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            //InitializeComponent();
            //await DogService.DBConnection_Start();
        }

        private async void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            
            Dog newDog = new Dog();
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                //txtName.Clear();
                newDog.Name = txtName.Text;
                lstNames.Items.Add(txtName.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtBreed.Text) && !lstNames.Items.Contains(txtBreed.Text))
            {
                newDog.Breed = txtBreed.Text;
            }
            if (!string.IsNullOrWhiteSpace(txtWeight.Text) && !lstNames.Items.Contains(txtWeight.Text))
            {
                newDog.Weight = Int32.Parse(txtWeight.Text);
            }
            await DogServiceAgent.Post(newDog);
        }
        private async void ButtonShowCurrentUsers_Click(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Clear();

            List<Dog> dogs = await DogServiceAgent.GetAllDog();

            foreach (var a in dogs)
            {
                lstNames.Items.Add(a.Name);
            }
        }
    }
}
