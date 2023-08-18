using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRU.ViewModel
{
    public class RegistrationVM : ObservableObject, IDataErrorInfo
    {
        public string Error { get { return null; } }
        private string _username;
        private string _textfield;

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Usuario no puede ser vacío";
                        else if (Username.Length < 5)
                            result = "Usuario debe tener al menos 5 caractéres.";
                        break;
                    case "Textfield":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                          break;
                    case "Textfield1":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield2":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield3":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield4":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield5":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield6":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield7":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield8":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield9":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield10":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield11":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield12":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield13":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield14":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield15":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield16":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Textfield17":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "El campo no puede ser vacío";
                        break;
                    case "Password":
                        if (string.IsNullOrWhiteSpace(Textfield))
                            result = "La contraseña no puede ser vacía";
                        else if (Username.Length < 6)
                            result = "La contraseña debe tener al menos 6 caractéres.";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }

        public string Textfield
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield2
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield3
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield4
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield5
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield6
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield7
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield8
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield9
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield10
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield11
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield12
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield13
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield14
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield15
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield16
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }
        public string Textfield17
        {
            get { return _textfield; }
            set
            {
                OnPropertyChanged(ref _textfield, value);
            }
        }

    }
}
