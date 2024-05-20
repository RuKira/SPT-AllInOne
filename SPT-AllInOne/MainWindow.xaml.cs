using System.CodeDom.Compiler;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        
        // TODO: Build/Copy the quests.json file to the output directory
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
        foreach (var traders in enums.TRADER_IDS.Keys)
        {
            TraderComboBox.Items.Add(traders);
        }
        
        foreach (var side in enums.SIDE.Keys)
        {
            SideComboBox.Items.Add(side);
        }

        foreach (var location in enums.MAP_IDS.Keys)
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
            TraderId.Text = selectedQuest.traderId; // TODO: This should be used to set a custom trader name
            TraderComboBox.Text = selectedQuest.traderId; // TODO: We somehow need to cast to the ComboBox
            LocationComboBox.Text = selectedQuest.location; // TODO: We somehow need to cast to the ComboBox
            LocationId.Text = selectedQuest.location; // TODO: This should be used to set a custom location name (Typically never used)
            SideComboBox.Text = selectedQuest.side; // TODO: We somehow need to cast to the ComboBox
            TypeComboBox.Text = selectedQuest.type; // TODO: We somehow need to cast to the ComboBox
            RestartableCheckBox.IsChecked = selectedQuest.restartable;
            InstantCheckBox.IsChecked = selectedQuest.instantComplete;
            SecretCheckBox.IsChecked = selectedQuest.secretQuest;
            NotificationCheckBox.IsChecked = selectedQuest.canShowNotificationsInGame;
            KeyCheckBox.IsChecked = selectedQuest.isKey;
            Description.Text = locale[selectedQuest.description];
            Fail.Text = locale[selectedQuest.failMessageText];
            Success.Text = locale[selectedQuest.successMessageText];
            try{Change.Text = locale[selectedQuest.changeQuestMessageText];} catch {Change.Text = "Change Message (Disabled)";} // Are these even used?
            try{Note.Text = locale[selectedQuest.note];} catch {Note.Text = "Note (Disabled)";} // Are these even used?
        };
    }
}