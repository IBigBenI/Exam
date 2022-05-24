using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Exam.Models;
using System.Net;

namespace Exam
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class MainPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRecords(value);
            }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Records();
        }
        async void LoadRecords(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                Records records = await App.Database.GetRecordsAsync(id);
                BindingContext = records;
               
                
            }
            catch (Exception)
            {
                Console.WriteLine("Не возможно загрузить запись");
            }
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var records = (Records)BindingContext;
            if (!string.IsNullOrWhiteSpace(records.Text))
            {
                await App.Database.SaveRecordsAsync(records);
            }

            await Shell.Current.GoToAsync(nameof(TableRecords));
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var records = (Records)BindingContext;
            await App.Database.DeleteRecordsAsync(records);

            await Navigation.PushModalAsync(new TableRecords());
        }
    }
}
