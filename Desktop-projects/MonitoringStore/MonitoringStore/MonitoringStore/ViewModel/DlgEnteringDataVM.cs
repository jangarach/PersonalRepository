using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringStore.ViewModel
{
    public class DlgEnteringDataVM : ViewModelBase
    {
        /// <summary>
        /// Событие при отмене
        /// </summary>
        public event Action EventCommandCancel;
        /// <summary>
        /// Событие при сохранении
        /// </summary>
        public event Action EventCommandSave;
        [Obsolete("Only for XAML")]
        public DlgEnteringDataVM()
        {

        }
        /// <summary>
        /// Для добавление нового значения
        /// </summary>
        /// <param name="title">Заголовок окна</param>
        public DlgEnteringDataVM(string title, Information currentObj)
        {
            this.Title = title;
            if (currentObj == null)
            {
                throw new NullReferenceException();
            }
            this.EnteringObject = currentObj;
        }
        public Information EnteringObject { get; private set; }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public string EnteringName
        {
            get => EnteringObject.EditingName;
            set
            {
                if (EnteringObject.EditingName == value)
                {
                    return;
                }
                EnteringObject.EditingName = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand _CommandSaveData;
        public RelayCommand CommandSaveData
        {
            get
            {
                return _CommandSaveData ?? (new RelayCommand(() =>
                {
                    EventCommandSave?.Invoke();
                }));
            }
        }

        public RelayCommand _CommandCancel;
        public RelayCommand CommandCancel
        {
            get
            {
                return _CommandCancel ?? (new RelayCommand(() =>
                {
                    EventCommandCancel?.Invoke();
                }));
            }
        }
    }
}
