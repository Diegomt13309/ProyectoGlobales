using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LESCOnario.ViewModels
{
    public interface IPdfViewer 
    {

        Task Open(string filePath);
        
    }
}

