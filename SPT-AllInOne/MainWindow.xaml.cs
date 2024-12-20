using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace SPT_AllInOne;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region Variables
    private readonly List<Quest> _quests = Utils.readQuestsFile("~/../../../../Data/quests.json");
    private readonly dynamic _locale = Utils.readLocaleFile("~/../../../../Data/locale.json");
    private readonly FinishEnums _enums = new FinishEnums();
    #endregion

    public MainWindow()
    {
        InitializeComponent();
        // Utils.test();
        
        AppStartup(_quests, _enums);
        
        // Close();
    }

    #region OLD

    

    //{
    //    var selectedQuest = _quests[QuestListBox.SelectedIndex];
    //    IdName.Text = selectedQuest._id;
    //    QuestName.Text = _locale[selectedQuest.name];
    //    TraderComboBox.Text = _enums.TRADER_IDS.TryGetValue(selectedQuest.traderId, out var traderName) ? traderName : selectedQuest.traderId;
    //    LocationComboBox.Text = _enums.MAP_IDS.TryGetValue(selectedQuest.location, out var locationName) ? locationName : selectedQuest.location;
    //    SideComboBox.Text = selectedQuest.side;
    //    TypeComboBox.Text = selectedQuest.type;
    //    RestartableCheckBox.IsChecked = selectedQuest.restartable;
    //    InstantCheckBox.IsChecked = selectedQuest.instantComplete;
    //    SecretCheckBox.IsChecked = selectedQuest.secretQuest;
    //    NotificationCheckBox.IsChecked = selectedQuest.canShowNotificationsInGame;
    //    KeyCheckBox.IsChecked = selectedQuest.isKey;
    //    Description.Text = _locale[selectedQuest.description];
    //    Fail.Text = _locale[selectedQuest.failMessageText];
    //    Success.Text = _locale[selectedQuest.successMessageText];
    //}
    //private void SearchQuest_OnTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    QuestListBox.Items.Clear();
    //    foreach (var quest in _quests)
    //    {
    //        if (quest.questName.ToLower().Contains(SearchQuest.Text.ToLower()))
    //        {
    //            QuestListBox.Items.Add(quest.questName);
    //        }
    //    }
    //}

    #endregion

    private void AppStartup(List<Quest> quests, FinishEnums enums)
    {
        
        
        
        
        
        

        #region OLD

        
        #region Quests

        //foreach (var quest in quests)
        //{
        //    QuestListBox.Items.Add(quest.questName);
        //}

        #endregion
        
        #region ComboBoxesSetup
        
        //foreach (var traders in enums.TRADER_IDS.Values)
        //{
        //    TraderComboBox.Items.Add(traders);
        //}
        //
        //foreach (var side in enums.SIDE)
        //{
        //    SideComboBox.Items.Add(side);
        //}
        //foreach (var location in enums.MAP_IDS.Values)
        //{
        //    LocationComboBox.Items.Add(location);
        //}
        //foreach (var type in enums.ROOT_CONDITIONS)
        //{
        //    TypeComboBox.Items.Add(type);
        //}
        
        #endregion

        #region DefaultParams

        //QuestFilePath.Text = "Quests file path - Disabled";
        //LocaleFilePath.Text = "Locale file path - Disabled";
        //TraderId.Text = "TraderID - Not available for 0.0.1-Alpha";
        //LocationId.Text = "LocationID - Not available for 0.0.1-Alpha";
        //Change.Text = "Not available for 0.0.1-Alpha";
        //Note.Text = "Not available for 0.0.1-Alpha";

        #endregion
        #endregion
    }
    
}