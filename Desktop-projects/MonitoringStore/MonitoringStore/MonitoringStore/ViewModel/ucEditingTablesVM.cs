using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MonitoringStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonitoringStore.ViewModel
{
    public interface Information
    {
        int? Id { get; set; }
        string EditingName { get; set; }

    }
    #region Classes for VM
    public class Post : ViewModelBase, Information
    {
        public Post(string editingName, int? id = null)
        {
            this.Id = id;
            this.EditingName = editingName;
        }
        public int? Id { get; set; }

        private string _EditingName;
        public string EditingName
        {
            get => _EditingName;
            set => Set(ref _EditingName, value);
        }

    }

    public class Sector : ViewModelBase, Information
    {
        public Sector(string editingName, int? id = null)
        {
            this.Id = id;
            EditingName = editingName;
        }
        public int? Id { get; set; }
        private string _EditingName;
        public string EditingName
        {
            get => _EditingName;
            set => Set(ref _EditingName, value);
        }
    }
    public class Clothes : ViewModelBase, Information
    {
        public Clothes(string editingName, int? id = null)
        {
            this.Id = id;
            EditingName = editingName;
        }
        public int? Id { get; set; }
        private string _EditingName;
        public string EditingName
        {
            get => _EditingName;
            set => Set(ref _EditingName, value);
        }
    }
    #endregion

    public enum ModeWindow
    {
        Common = 0,
        User = 1,
        Post = 2,
        Sector = 3,
        Сlothes = 4
    }

    public enum OpenWindowMode
    {
        Add = 0,
        Edit = 1
    }
    public class ucEditingTablesVM : ViewModelBase
    {
        /// <summary>
        /// Список должностей
        /// </summary>
        public ObservableCollection<Post> ListPosts { get; set; }
        public ObservableCollection<Sector> ListSectors { get; set; }
        public ObservableCollection<Clothes> ListClothes { get; set; }
        public DlgEnteringDataVM DlgEnteringDataVM { get; set; }
        public DlgEnteringData DlgEnteringData;
        public ucEditingTablesVM()
        {
            ListPosts = new ObservableCollection<Post>()
            {
                new Post("Test1",0),
                new Post("Test1",1),
                new Post("Test1",2),
                new Post("Test1",3),
                new Post("Test1",4)
            };
            ListSectors = new ObservableCollection<Sector>()
            {
                new Sector("Sector",0),
                new Sector("Sector1",1),
                new Sector("Sector2",2),
                new Sector("Sector3",3),
                new Sector("Sector4",4)
            };
            ListClothes = new ObservableCollection<Clothes>()
            {
                new Clothes("Clothes",0),
                new Clothes("Clothes1",1),
                new Clothes("Clothes2",2),
                new Clothes("Clothes3",3),
                new Clothes("Clothes3",4)
            };
        }

        private int _SelectedTabIndex;
        public int SelectedTabIndex
        {
            get => _SelectedTabIndex;
            set => Set(ref _SelectedTabIndex, value);
        }
        private RelayCommand _CommandAdd;
        public RelayCommand CommandAdd
        {
            get
            {
                return _CommandAdd ?? (new RelayCommand(() =>
                {
                    DefineWindow("Добавить", OpenWindowMode.Add);
                }));
            }
        }

        private RelayCommand _CommandEditing;
        public RelayCommand CommandEditing
        {
            get
            {
                return _CommandEditing ?? (new RelayCommand(() =>
                {
                    DefineWindow("Редактировать", OpenWindowMode.Edit);
                }));
            }
        }

        private RelayCommand _CommandRemove;
        public RelayCommand CommandRemove
        {
            get
            {
                return _CommandRemove ?? (new RelayCommand(() =>
                {
                    DeleteSelectedValue();
                }));
            }
        }

        private object _SelectedObject;
        public object SelectedObject
        {
            get => _SelectedObject;
            set => Set(ref _SelectedObject, value);
        }

        private void DefineWindow(string title, OpenWindowMode openMode)
        {
            switch (SelectedTabIndex)
            {
                case (int)ModeWindow.Common:

                    break;
                case (int)ModeWindow.User:

                    break;
                case (int)ModeWindow.Post:
                    title += " должность";
                    if (openMode == OpenWindowMode.Add)
                    {
                        OpenWindow(title, new Post(""));
                        break;
                    }
                    var post = SelectedObject as Post;
                    if (openMode == OpenWindowMode.Edit & post != null)
                    {
                        OpenWindow(title, post);
                        break;
                    }
                    break;
                case (int)ModeWindow.Sector:
                    title += " участок";
                    if (openMode == OpenWindowMode.Add)
                    {
                        OpenWindow(title, new Sector(""));
                        break;
                    }
                    var sector = SelectedObject as Sector;
                    if (openMode == OpenWindowMode.Edit & sector != null)
                    {
                        OpenWindow(title, sector);
                        break;
                    }
                    break;
                case (int)ModeWindow.Сlothes:
                    title += " спец одежду";
                    if (openMode == OpenWindowMode.Add)
                    {
                        OpenWindow(title, new Clothes(""));
                        break;
                    }
                    var clothes = SelectedObject as Clothes;
                    if (openMode == OpenWindowMode.Edit & clothes != null)
                    {
                        OpenWindow(title, clothes);
                        break;
                    }
                    break;
            }
        }

        private void OpenWindow(string title, Information currentObj)
        {
            DlgEnteringData = new DlgEnteringData();
            DlgEnteringDataVM = currentObj == null ? new DlgEnteringDataVM(title, currentObj)
                : new DlgEnteringDataVM(title, currentObj);
            DlgEnteringData.DataContext = DlgEnteringDataVM;
            DlgEnteringData.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            DlgEnteringDataVM.EventCommandCancel += () => DlgEnteringData.Close();
            DlgEnteringDataVM.EventCommandSave += () => SaveChanges();
            DlgEnteringData.ShowDialog();
        }

        /// <summary>
        /// Сохранить изменения при добавлении или редактирования
        /// </summary>
        private void SaveChanges()
        {
            try
            {
                if (DlgEnteringDataVM.EnteringObject is Post post)
                {
                    if (post.Id == null)
                    {
                        ListPosts.Add(post);
                    }
                    DlgEnteringData.Close();
                }

                if (DlgEnteringDataVM.EnteringObject is Sector sector)
                {
                    if (sector.Id == null)
                    {
                        ListSectors.Add(sector);
                    }
                    DlgEnteringData.Close();
                }

                if (DlgEnteringDataVM.EnteringObject is Clothes clothes)
                {
                    if (clothes.Id == null)
                    {
                        ListClothes.Add(clothes);
                    }
                    DlgEnteringData.Close();
                }
            }
            catch
            {

            }

            
        }

        private void DeleteSelectedValue()
        {
            if (SelectedObject == null)
            {
                return;
            }
            if (SelectedObject is Post post)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить?", "Удаление элемента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                ListPosts.Remove(post);
            }
            if (SelectedObject is Sector sector)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить?", "Удаление элемента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                ListSectors.Remove(sector);
            }
            if (SelectedObject is Clothes clothes)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить?", "Удаление элемента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                ListClothes.Remove(clothes);
            }
        }
    }


}
