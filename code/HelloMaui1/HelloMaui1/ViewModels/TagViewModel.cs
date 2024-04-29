using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace B.ViewModels
{
    public partial class TagViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> wishes = new() { };

        TagViewModel()
        {
        }

    }
}
