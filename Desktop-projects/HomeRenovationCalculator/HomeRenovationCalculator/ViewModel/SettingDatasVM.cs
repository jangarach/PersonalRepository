using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeRenovationCalculator.Model;
using HomeRenovationCalculator.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.ViewModel
{
    public class SettingDatasVM : ViewModelBase
    {
        AppContext AppContext;
        public SettingDatasVM()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                AppContext = new AppContext();
                AppContext.CoverTypes.Load();
                AppContext.Covers.Load();

                AppContext.Glue.Load();
                AppContext.Plaster.Load();
                AppContext.Putty.Load();
                AppContext.WallPaper.Load();
                AppContext.Wall.Load();

                Glue = AppContext.Glue.Local.ToBindingList();
                Plaster = AppContext.Plaster.Local.ToBindingList();
                Putty = AppContext.Putty.Local.ToBindingList();
                WallPaper = AppContext.WallPaper.Local.ToBindingList();
                WallPaint = AppContext.Wall.Local.ToBindingList();

            }
        }

        IEnumerable<BaseCover> _Plaster;
        public IEnumerable<BaseCover> Plaster
        {
            get => _Plaster;
            set => Set(ref _Plaster, value);
        }

        IEnumerable<Putty> _Putty;
        public IEnumerable<Putty> Putty
        {
            get => _Putty;
            set => Set(ref _Putty, value);
        }

        IEnumerable<WallPaper> _WallPaper;
        public IEnumerable<WallPaper> WallPaper
        {
            get => _WallPaper;
            set => Set(ref _WallPaper, value);
        }

        IEnumerable<BaseCover> _Glue;
        public IEnumerable<BaseCover> Glue
        {
            get => _Glue;
            set => Set(ref _Glue, value);
        }

        IEnumerable<WallPaint> _WallPaint;
        public IEnumerable<WallPaint> WallPaint
        {
            get => _WallPaint;
            set => Set(ref _WallPaint, value);
        }



        BaseCover _SelectedCover;
        public BaseCover SelectedCover
        {
            get => _SelectedCover;
            set => Set(ref _SelectedCover, value);
        }

        WallPaper _SelectedWallPaper;
        public WallPaper SelectedWallPaper
        {
            get => _SelectedWallPaper;
            set => Set(ref _SelectedWallPaper, value);
        }

        Cover _SelectedCoverType;
        public Cover SelectedCoverType
        {
            get => _SelectedCoverType;
            set => Set(ref _SelectedCoverType, value);
        }

        public int _SelectedTabIndex;
        public int SelectedTabIndex
        {
            get => _SelectedTabIndex;
            set => Set(ref _SelectedTabIndex, value);
        }

        CoverEdit CoverEdit;
        CoverTypeEdit CoverTypeEdit;

        RelayCommand _AddCommand;
        public RelayCommand AddCommand
        {
            get => _AddCommand ?? (_AddCommand = new RelayCommand(() =>
            {
                CoverEditVM coverTypeEditVm;
                if (SelectedTabIndex == 2)
                    coverTypeEditVm = new CoverEditVM(new WallPaper(), SelectedTabIndex);
                else

                {

                    BaseCover baseCover = null;
                    switch (SelectedTabIndex)
                    {
                        case 0: //Штукатурка
                            baseCover = new Plaster();
                            break;
                        case 1: //Шпаклевка
                            baseCover = new Putty();
                            break;
                        case 3: //Клей
                            baseCover = new Glue();
                            break;
                        case 4: //Краска
                            baseCover = new WallPaint();
                            break;

                    }
                    coverTypeEditVm = new CoverEditVM(baseCover, SelectedTabIndex);
                }
                coverTypeEditVm.CommandSaveChanged += CoverTypeEditVm_CommandSaveChanged;
                coverTypeEditVm.CommandCancelChanged += CoverTypeEditVm_CommandCancelChanged;
                CoverEdit = new CoverEdit();
                CoverEdit.DataContext = coverTypeEditVm;
                CoverEdit.ShowDialog();
            }));
        }

        RelayCommand _EditCommand;
        public RelayCommand EditCommand
        {
            get => _EditCommand ?? (_EditCommand = new RelayCommand(() =>
            {
                CoverEditVM coverTypeEditVm;
                if (SelectedTabIndex == 2)
                {
                    if (SelectedWallPaper == null)
                        return;
                    coverTypeEditVm = new CoverEditVM(SelectedWallPaper, SelectedTabIndex, true);
                }
                    
                else
                {
                    if (SelectedCover == null)
                        return;
                    coverTypeEditVm = new CoverEditVM(SelectedCover, SelectedTabIndex, true);
                }
                CoverEdit = new CoverEdit();
                coverTypeEditVm.CommandSaveChanged += CoverTypeEditVm_CommandSaveChanged;
                coverTypeEditVm.CommandCancelChanged += CoverTypeEditVm_CommandCancelChanged;
                CoverEdit.DataContext = coverTypeEditVm;
                CoverEdit.ShowDialog();
            }));
        }

        private void CoverTypeEditVm_CommandSaveChanged(object sender, bool isEdit)
        {
            if (isEdit == false)
            {
                if (sender is Plaster plaster)
                {
                    AppContext.Plaster.Add(plaster);
                }
                else if (sender is Putty putty)
                {
                    AppContext.Putty.Add(putty);
                }
                else if (sender is Glue glue)
                {
                    AppContext.Glue.Add(glue);
                }
                else if (sender is WallPaint wallPaint)
                {
                    AppContext.Wall.Add(wallPaint);
                }
                else if (sender is WallPaper wallPaper)
                {
                    AppContext.WallPaper.Add(wallPaper);
                }
                AppContext.SaveChanges();
            }
            else
            {
                AppContext.Entry(sender).State = EntityState.Modified;
                AppContext.SaveChanges();
            }
            if (CoverEdit != null)
                CoverEdit.Close();
        }

        private void CoverTypeEditVm_CommandCancelChanged(object sender, EventArgs e)
        {
            if (CoverEdit != null)
                CoverEdit.Close();
        }


        RelayCommand _DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get => _DeleteCommand ?? (_DeleteCommand = new RelayCommand(() =>
            {
                switch (SelectedTabIndex)
                {
                    case 0: //Штукатурка
                        AppContext.Plaster.Remove(SelectedCover as Plaster);
                        break;
                    case 1: //Шпаклевка
                        AppContext.Putty.Remove(SelectedCover as Putty);
                        break;
                    case 2: //Обои
                        AppContext.WallPaper.Remove(SelectedWallPaper);
                        break;
                    case 3: //Клей
                        AppContext.Glue.Remove(SelectedCover as Glue);
                        break;
                    case 4: //Краска
                        AppContext.Wall.Remove(SelectedCover as WallPaint);
                        break;
                        
                }
                AppContext.SaveChanges();
            }));
        }

        private void CoverEditVm_CommandCancelChanged(object sender, EventArgs e)
        {
            if (sender is CoverEditVM)
            {
                CoverEdit.Close();
            }
            else
            {
                CoverTypeEdit.Close();
            }
        }
    }
}
