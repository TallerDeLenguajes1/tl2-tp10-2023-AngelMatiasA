using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kanban.Models;
namespace kanban.ViewModels;


    public class ListarTableroViewModel
    {
        
        public List<TableroViewModel> ListarTableroVM {get;set;}= new List<TableroViewModel>(); 
        public ListarTableroViewModel(List<Tablero> tableros)
        {
           
            foreach (var tabl in tableros)
            {
                var TableroVM = new TableroViewModel(tabl);
                ListarTableroVM.Add(TableroVM);
            }
        }

        public ListarTableroViewModel(Tablero tablero){
            
            var UsuarioViewM = new TableroViewModel(tablero);
            ListarTableroVM.Add(UsuarioViewM);
        }
    }