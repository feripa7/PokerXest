﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerXestWPF.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        //Campos
        private readonly Action<object> _executeAction;//ejecuta los comandos
        private readonly Predicate<object> _canExecuteAction; //controla si se puede o no ejecutar la accion 

        //Constructores
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        //Eventos
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        //Metodos
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
           _executeAction(parameter);
        }
    }
}
