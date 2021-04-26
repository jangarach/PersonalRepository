using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeRenovationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.ViewModel
{
    public class CoverEditVM : ViewModelBase
    {
        public event EventHandler CommandCancelChanged;
        public event EventHandler<bool> CommandSaveChanged;
        private BaseCover BaseCover { get; set; }
        private WallPaper WallPaper { get; set; }

        public bool IsEdit { get; }

        [Obsolete("Only for XAML")]
        public CoverEditVM()
        {

        }
        public CoverEditVM(object objCover, int coverIndex, bool isEdit = false)
        {
            BaseCover = objCover as BaseCover;
            WallPaper = objCover as WallPaper;
            IsEdit = isEdit;
            if (IsInDesignMode)
            {
                Tittle = "Редактирование покрытий";
                return;
            }

            if (isEdit)
            {
                Tittle = isEdit ? "Редактировать" : "Добавить";
            }

            switch (coverIndex)
            {
                case 0: //Штукатурка
                    Tittle += " штукатурку";
                    CapacityText = "Объем (кг.):";
                    break;
                case 1: //Шпаклевка
                    Tittle += " шпаклевку";
                    CapacityText = "Объем (кг.):";
                    break;
                case 2: //Обои
                    Tittle += " обои";
                    CapacityText = "Ширина (м.):";
                    break;
                case 3: //Клей
                    Tittle += " клей";
                    CapacityText = "Объем (л.):";
                    break;
                case 4: //Краска
                    Tittle += " краска";
                    CapacityText = "Объем (л.):";
                    break;

            }
        }

        public int Id { get; set; }
        public string Tittle { get; set; }
        public string CapacityText { get; set; }

        public string Name
        {
            get => BaseCover?.Name ?? WallPaper?.Name;
            set
            {
                if (BaseCover != null)
                {
                    BaseCover.Name = value;
                }
                else
                {
                    WallPaper.Name = value;
                }
                RaisePropertyChanged();


            }
        }

        public double Capacity
        {
            get => BaseCover?.Capacity ?? WallPaper.Length;
            set
            {
                if (BaseCover != null)
                {
                    BaseCover.Capacity = value;
                }
                else
                {
                    WallPaper.Length = value;
                }
                RaisePropertyChanged();


            }
        }

        public double Price
        {
            get => BaseCover?.Price ?? WallPaper.Price;
            set
            {
                if (BaseCover != null)
                {
                    BaseCover.Price = value;
                }
                else
                {
                    WallPaper.Price = value;
                }
                RaisePropertyChanged();


            }
        }

        RelayCommand _CommandCancel;
        public RelayCommand CommandCancel
        {
            get => _CommandCancel ?? (_CommandCancel = new RelayCommand(() =>
            {
                if (BaseCover != null)
                    CommandCancelChanged.Invoke(BaseCover, EventArgs.Empty);
                else
                    CommandCancelChanged.Invoke(WallPaper, EventArgs.Empty);

            }));
        }

        RelayCommand _CommandSave;
        public RelayCommand CommandSave
        {
            get => _CommandSave ?? (_CommandSave = new RelayCommand(() =>
            {
                if (BaseCover != null)
                    CommandSaveChanged.Invoke(BaseCover, IsEdit);
                else
                    CommandSaveChanged.Invoke(WallPaper, IsEdit);
            }));
        }
    }
}
