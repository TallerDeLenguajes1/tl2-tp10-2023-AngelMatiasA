using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kanban.Models;
namespace kanban.ViewModels;

    
    public class ListarTareasViewModel
    {
        public List<TareaViewModel> ListarTareasVM {get;set;}
        public ListarTareasViewModel(List<Tarea> tareas)
        {
            ListarTareasVM = new List<TareaViewModel>(); 
            foreach (var tar in tareas)
            {
                var TareaVM = new TareaViewModel(tar);
                ListarTareasVM.Add(TareaVM);
            }
        }

        public ListarTareasViewModel(Tarea tarea){
            
            ListarTareasVM = new List<TareaViewModel>();
            var TareaViewM = new TareaViewModel(tarea);
            ListarTareasVM.Add(TareaViewM);
        }
    }