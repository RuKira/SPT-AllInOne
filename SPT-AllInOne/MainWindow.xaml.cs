using System.Text.Json;
using System.Windows;

namespace SPT_AllInOne;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Utils.test();
        
        var quests = Utils.readQuestsFile(QuestFilePath.Text);
        var locale = Utils.readLocaleFile(LocaleFilePath.Text);
        var enums = new FinishEnums();
        
        Console.WriteLine(JsonSerializer.Serialize(quests[0], options: new JsonSerializerOptions { WriteIndented = true }));
        
        AppSetup(quests, locale, enums);
        // Close();

    }

    private void AppSetup(List<Quest> quests, dynamic locale, FinishEnums enums)
    {
        #region ComboBoxesSetup
        foreach (var traders in enums.TRADER_IDS.Values)
        {
            TraderComboBox.Items.Add(traders);
        }
        
        foreach (var side in enums.SIDE.Keys)
        {
            SideComboBox.Items.Add(side);
        }

        foreach (var location in enums.MAP_IDS.Values)
        {
            LocationComboBox.Items.Add(location);
        }

        foreach (var type in enums.ROOT_CONDITIONS.Keys)
        {
            TypeComboBox.Items.Add(type);
        }
        #endregion
        
        foreach (var quest in quests)
        {
            QuestListBox.Items.Add(quest.questName);
        }

        QuestListBox.SelectionChanged += (sender, args) =>
        {
            var selectedQuest = quests[QuestListBox.SelectedIndex];
            IdName.Text = selectedQuest._id;
            QuestName.Text = locale[selectedQuest.name];
            CurrentQuest.Text = locale[selectedQuest.name];
            TraderId.Text = selectedQuest.traderId + " (Disabled)"; // TODO: This should be used to set a custom trader name
            TraderComboBox.Text = enums.TRADER_IDS.TryGetValue(selectedQuest.traderId, out var traderName) ? traderName : selectedQuest.traderId;
            LocationComboBox.Text = enums.MAP_IDS.TryGetValue(selectedQuest.location, out var locationName) ? locationName : selectedQuest.location;
            LocationId.Text = selectedQuest.location + " (Disabled)"; // TODO: This should be used to set a custom location name (Typically never used)
            //SideComboBox.Text = enums.SIDE.TryGetValue(selectedQuest.side, out var sideName) ? sideName : selectedQuest.side; // TODO: Fix so this works
            SideComboBox.Text = "Side (Disabled)";
            //TypeComboBox.Text = enums.ROOT_CONDITIONS.TryGetValue(selectedQuest.type, out var typeName) ? typeName : selectedQuest.type; // TODO: Fix so this works
            TypeComboBox.Text = "Type (Disabled)";
            RestartableCheckBox.IsChecked = selectedQuest.restartable;
            InstantCheckBox.IsChecked = selectedQuest.instantComplete;
            SecretCheckBox.IsChecked = selectedQuest.secretQuest;
            NotificationCheckBox.IsChecked = selectedQuest.canShowNotificationsInGame;
            KeyCheckBox.IsChecked = selectedQuest.isKey;
            Description.Text = locale[selectedQuest.description];
            Fail.Text = locale[selectedQuest.failMessageText];
            Success.Text = locale[selectedQuest.successMessageText];
            try{Change.Text = locale[selectedQuest.changeQuestMessageText];} catch {Change.Text = "Change Message (Disabled)";} 
            try{Note.Text = locale[selectedQuest.note];} catch {Note.Text = "Note (Disabled)";}
        };
    }
}