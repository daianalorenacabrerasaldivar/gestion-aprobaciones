using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases.Command.Create
{
    public class CreateProyect
    {
        private readonly IDataBaseService _dataService;
        public CreateProyect(IDataBaseService dataBase) { 
        _dataService= dataBase;}
    }
}
