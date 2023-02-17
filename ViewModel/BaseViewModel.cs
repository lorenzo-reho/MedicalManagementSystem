using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementSystem.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // In C# gli eventi possono essere rappresentati come oggetti
        
        // Questo metodo va chiamato ogni volta che viene modificata una proprietà dal ViewModel
        // per notificare la modifica alla view
        public void OnPropertyChanged(string obj) {

            // Esame:
            // 1) PropertyChanged è l'handler dell'evento
            // 2) PropertyChangedEventArgs contiene le proprietà che devono essere passate alle classi subscriber (View)
            // 3) this è chi ha generato l'evento

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(obj));
        }

        /*
         
        https://www.csharptutorial.net/csharp-tutorial/csharp-events/

         Gli eventi sono uno strumento che consentono ad una classe (Publisher) di notificare
        ad altre classi/oggetti (Subscriber) il verificarsi di un evento
         */

    }
}
