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
        private WallPaperType WallPaperType { get; set; }

        public bool IsEdit { get; }

        [Obsolete("Only for XAML")]
        public CoverEditVM()
        {

        }
        public CoverEditVM(object objCover, int coverIndex, bool isEdit = false)
        {
            BaseCover = objCover as BaseCover;
            WallPaper = objCover as WallPaper;
            WallPaperType = objCover as WallPaperType;
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
                    CapacityText = "Расход литры на кв.м.:";
                    break;
                case 4: //Краска
                    Tittle += " краска";
                    CapacityText = "Расход литры на кв.м.:";
                    break;
                case 5: //Краска
                    Tittle += " тип обоя";
                    CapacityText = "Коэфициент:";
                    IsVisiblePrice = false;
                    break;

            }
        }
        public bool IsVisiblePrice { get; set; } = true;
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string CapacityText { get; set; }

        public string Name
        {
            get
            {
                if (BaseCover != null)
                {
                    return BaseCover.Name;
                }
                else if (WallPaper != null)
                {
                    return WallPaper.Name;
                }
                else
                {
                    return WallPaperType.Name;
                }
            }
            set
            {
                if (BaseCover != null)
                {
                    BaseCover.Name = value;
                }
                else if (WallPaper != null)
                {
                    WallPaper.Name = value;
                }
                else
                {
                    WallPaperType.Name = value;
                }
                RaisePropertyChanged();
            }
        }

        public double Capacity
        {
            get
            {
                if (BaseCover != null)
                {
                    return BaseCover.Capacity;
                }
                else if (WallPaper != null)
                {
                    return WallPaper.Length;
                }
                else
                {
                    return WallPaperType.Rate;
                }
            }
            set
            {
                if (BaseCover != null)
                {
                    BaseCover.Capacity = value;
                }
                else if (WallPaper != null)
                {
                    WallPaper.Length = value;
                }
                else
                {
                    WallPaperType.Rate = value;
                }
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get => IsVisiblePrice ? BaseCover?.Price ?? WallPaper.Price : 0;
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
                else if (WallPaper != null)
                    CommandCancelChanged.Invoke(WallPaper, EventArgs.Empty);
                else
                    CommandCancelChanged.Invoke(WallPaperType, EventArgs.Empty);


            }));
        }

        RelayCommand _CommandSave;
        public RelayCommand CommandSave
        {
            get => _CommandSave ?? (_CommandSave = new RelayCommand(() =>
            {
                if (BaseCover != null)
                    CommandSaveChanged.Invoke(BaseCover, IsEdit);
                else if (WallPaper != null)
                    CommandSaveChanged.Invoke(WallPaper, IsEdit);
                else
                    CommandSaveChanged.Invoke(WallPaperType, IsEdit);
            }));
        }
    }
}
