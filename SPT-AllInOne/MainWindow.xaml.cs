using System.Diagnostics;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

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

        #pragma warning disable CA1869
        Console.WriteLine(JsonSerializer.Serialize(quests[0], new JsonSerializerOptions { WriteIndented = true }));
        
        QuestSetup(quests, locale, enums);
        
        // Close();
    }

    #region MainWindow Event Handlers

    private void IdGen_OnClick(object sender, RoutedEventArgs e)
    {
        IdName.Text = Utils.generateId();
        Clipboard.SetText(IdName.Text);
    }

    #endregion

    private void QuestSetup(List<Quest> quests, dynamic locale, FinishEnums enums)
    {
        AppStartup(quests, enums);
        
        QuestListBox.SelectionChanged += (sender, args) =>
        {
            var selectedQuest = quests[QuestListBox.SelectedIndex];
            IdName.Text = selectedQuest._id;
            QuestName.Text = locale[selectedQuest.name];
            CurrentQuest.Text = locale[selectedQuest.name];
            TraderComboBox.Text = enums.TRADER_IDS.TryGetValue(selectedQuest.traderId, out var traderName) ? traderName : selectedQuest.traderId;
            LocationComboBox.Text = enums.MAP_IDS.TryGetValue(selectedQuest.location, out var locationName) ? locationName : selectedQuest.location;
            //SideComboBox.Text = enums.SIDE.TryGetValue(selectedQuest.side, out var sideName) ? sideName : selectedQuest.side; // TODO: Fix so this works
            //TypeComboBox.Text = enums.ROOT_CONDITIONS.TryGetValue(selectedQuest.type, out var typeName) ? typeName : selectedQuest.type; // TODO: Fix so this works
            RestartableCheckBox.IsChecked = selectedQuest.restartable;
            InstantCheckBox.IsChecked = selectedQuest.instantComplete;
            SecretCheckBox.IsChecked = selectedQuest.secretQuest;
            NotificationCheckBox.IsChecked = selectedQuest.canShowNotificationsInGame;
            KeyCheckBox.IsChecked = selectedQuest.isKey;
            Description.Text = locale[selectedQuest.description];
            Fail.Text = locale[selectedQuest.failMessageText];
            Success.Text = locale[selectedQuest.successMessageText];
        };
    }

    private void AppStartup(List<Quest> quests, FinishEnums enums)
    {
        #region Quests

        foreach (var quest in quests)
        {
            QuestListBox.Items.Add(quest.questName);
        }

        #endregion
        
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

        #region DefaultParams

        TraderId.Text = "TraderID - Not available for 0.0.1-Alpha";
        LocationId.Text = "LocationID - Not available for 0.0.1-Alpha";
        SideComboBox.Text = "Side (Disabled)";
        TypeComboBox.Text = "Type (Disabled)";
        Change.Text = "Not available for 0.0.1-Alpha";
        Note.Text = "Not available for 0.0.1-Alpha";

        #endregion
    }
}